<template>
    <div>
      <h2>Add New Contact</h2>
      <form @submit.prevent="addContact">
        <label for="name">Name:</label>
        <input v-model="Name" type="text" id="name" required>

        <label for="surname">Surname:</label>
        <input v-model="Surname" type="text" id="surname" required>

        <label for="phone">Phone:</label>
        <input v-model="Phone" type="text" id="phone" required>

        <label for="email">Email:</label>
        <input v-model="Email" type="email" id="email" required>

        <label for="password">Password:</label>
        <input v-model="Password" type="password" id="password" required>

        <label for="categoryId">Category ID:</label>
        <input v-model="CategoryId" type="number" id="categoryId" required>

        <label for="subcategoryId">Subcategory ID:</label>
        <input v-model="SubcategoryId" type="number" id="subcategoryId" required>

        <label for="birthDate">Birth Date:</label>
        <input v-model="BirthDate" type="date" id="birthDate" required>

        <button type="submit">Add Contact</button>
      </form>
    </div>
  </template>


<script lang="ts">
import { ref } from 'vue';
import axios from 'axios';

export default {
  setup() {
    const Name = ref();
    const Surname = ref();
    const Phone = ref();
    const Email = ref();
    const Password = ref();
    const CategoryId = ref();
    const SubcategoryId = ref();
    const BirthDate = ref('');

    const addContact = async () => {
      try {
        const response = await axios.post(
        "api/AddContact",
        {
          Name: Name.value,
          Surname: Surname.value,
          Phone: Phone.value,
          Email: Email.value,
          Password: Password.value,
          CategoryId: CategoryId.value,
          SubcategoryId: SubcategoryId.value,
          BirthDate: BirthDate.value
        },
        {
          headers: {
            Accept: "*/*",
            "Content-Type": "multipart/form-data",
          },
        }
      );
      } catch (error) {
        console.error('An error occurred:', error);
      }
    };

    return {
      Name,
      Surname,
      Phone,
      Email,
      Password,
      CategoryId,
      SubcategoryId,
      BirthDate,
      addContact
    };
  }
};
</script>