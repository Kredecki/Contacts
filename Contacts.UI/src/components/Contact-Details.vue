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

            <label for="categoryId">Category:</label>
            <select v-model="CategoryId" id="categoryId">
                <option v-for="category in categories" :key="category.categoryId" :value="category.categoryId">{{ category.categoryName }}</option>
            </select>

            <label v-if="CategoryId === 1 || CategoryId === 3" for="subcategoryLabel">Subcategory:</label>
            <input v-if="CategoryId === 3" v-model="SubcategoryId" id="subcategoryInput">

            <select v-if="CategoryId === 1" v-model="SubcategoryId" id="subcategoryOption">
                <option v-for="subcategory in subcategories" :key="subcategory.subcategoryId" :value="subcategory.subcategoryId">{{ subcategory.subcategoryName }}</option>
            </select>

            <label for="birthDate">Birth Date:</label>
            <input v-model="BirthDate" type="date" id="birthDate">

            <button type="submit">Edit Contact</button>
        </form>
    </div>
</template>

<script lang="ts">
import { ref, onMounted } from 'vue';
import axios from 'axios';
import { useRoute } from 'vue-router';

export default {
  setup() {
    const route = useRoute();

    const Name = ref();
    const Surname = ref();
    const Phone = ref();
    const Email = ref();
    const Password = ref();
    const CategoryId = ref();
    const SubcategoryId = ref();
    const BirthDate = ref('');
    const categories = ref([]);
    const subcategories = ref([]);

    async function GetContact(id: any){
        const response = await axios.get(`/api/GetContactById?id=${id}`);
        const contactData = response.data;
        Name.value = contactData.name;
        Surname.value = contactData.surname;
        Phone.value = contactData.phone;
        Email.value = contactData.email;
        Password.value = contactData.password;
        CategoryId.value=contactData.categoryId;

        if(CategoryId.value === 3){
            const subcategoryName = await axios.get(`/api/GetSubcategoryNameById?id=${contactData.subcategoryId}`)
            SubcategoryId.value = subcategoryName.data;
        }else{
            SubcategoryId.value = contactData.subcategoryId;
        }


        const formattedBirthDate = new Date(contactData.birthDate).toISOString().slice(0, 10);
        BirthDate.value = formattedBirthDate;
    }

    async function EditContact() {
        let cat = 0;

        await axios.post(
          "api/AddNewSubcategory",
          {
            subcategoryName: SubcategoryId.value,
          },
          {
            headers: {
              Accept: "*/*",
              "Content-Type": "multipart/form-data",
            },
          }
        );

        if(CategoryId.value === 3){
            const response = await axios
            .get(`/api/GetSubcategoryIdBySubcategoryName?subcategoryName=${SubcategoryId.value}`, {
            headers: {
                accept: 'application/json',
            },
            })
            .then(response => {
                cat = response.data;
                console.log(cat)
            })
            .catch(error => {
                console.error('Error fetching contacts:', error);
            });
        }else{
            cat = SubcategoryId.value;
        }

        const updatedContact = {
            ContactId: route.query.id,
            Name: Name.value,
            Surname: Surname.value,
            Phone: Phone.value,
            Email: Email.value,
            Password: Password.value,
            CategoryId: CategoryId.value,
            SubcategoryId: cat,
            BirthDate: BirthDate.value,
        };
        try {
            await axios.post(`/api/UpdateContact`, updatedContact);
        } catch (error) {
            console.error('Error updating contact:', error);
        }
    }

    const fetchCategories = async () => {
      try {
        const response = await axios.get('/api/GetCategories', {
          headers: {
            accept: 'application/json',
          },
        });
        categories.value = response.data;
      } catch (error) {
        console.error('Error fetching categories:', error);
      }
    };

    const fetchSubcategories = async () => {
      try {
        const response = await axios.get('/api/GetBusinessSubcategories', {
          headers: {
            accept: 'application/json',
          },
        });
        subcategories.value = response.data;
      } catch (error) {
        console.error('Error fetching subcategories:', error);
      }
    };

    onMounted(() => {
        const id = route.query.id ?? " ";
        GetContact(id);
        fetchCategories();
        fetchSubcategories();
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
      EditContact,
      categories,
      subcategories
    };
  }
};
</script>