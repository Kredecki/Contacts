<template>
    <div>
        <h2>Edit Contact</h2>
        <form @submit.prevent="EditContact">
            <label for="name">Name:</label>
            <input v-model="Name" type="text" id="name">

            <label for="surname">Surname:</label>
            <input v-model="Surname" type="text" id="surname">

            <label for="phone">Phone:</label>
            <input v-model="Phone" type="text" id="phone">

            <label for="email">Email:</label>
            <input v-model="Email" type="email" id="email">

            <label for="password">Password:</label>
            <input v-model="Password" type="password" id="password">

            <label for="categoryId">Category ID:</label>
            <input v-model="CategoryId" type="number" id="categoryId">

            <label for="subcategoryId">Subcategory ID:</label>
            <input v-model="SubcategoryId" type="number" id="subcategoryId">

            <label for="birthDate">Birth Date:</label>
            <input v-model="BirthDate" type="date" id="birthDate">

            <button type="submit">Edit Contact</button>
        </form>
    </div>
</template>

<script lang="ts">
import { ref, onMounted } from 'vue';
import axios from 'axios';
import { useRouter, useRoute } from 'vue-router';

export default {
  setup() {
    const route = useRoute();
    const router = useRouter();

    const Name = ref();
    const Surname = ref();
    const Phone = ref();
    const Email = ref();
    const Password = ref();
    const CategoryId = ref();
    const SubcategoryId = ref();
    const BirthDate = ref('');

    async function GetContact(id: any){
        const response = await axios.get(`/api/GetContactById?id=${id}`);
        const contactData = response.data;
        Name.value = contactData.name;
        Surname.value = contactData.surname;
        Phone.value = contactData.phone;
        Email.value = contactData.email;
        Password.value = contactData.password;
        CategoryId.value=contactData.categoryId;
        SubcategoryId.value = contactData.subcategoryId;

        const formattedBirthDate = new Date(contactData.birthDate).toISOString().slice(0, 10);
        BirthDate.value = formattedBirthDate;
    }

    async function EditContact() {
        const updatedContact = {
            ContactId: route.query.id,
            Name: Name.value,
            Surname: Surname.value,
            Phone: Phone.value,
            Email: Email.value,
            Password: Password.value,
            CategoryId: CategoryId.value,
            SubcategoryId: SubcategoryId.value,
            BirthDate: BirthDate.value,
        };
        try {
            await axios.post(`/api/UpdateContact`, updatedContact);
        } catch (error) {
            console.error('Error updating contact:', error);
        }
    }

    onMounted(() => {
        const id = route.query.id ?? " ";
        GetContact(id)
    });

    return {
      Name,
      Surname,
      Phone,
      Email,
      Password,
      CategoryId,
      SubcategoryId,
      BirthDate,
      EditContact
    };
  }
};
</script>