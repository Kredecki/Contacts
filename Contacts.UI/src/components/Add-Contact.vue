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

        <label for="category">Category:</label>
        <select v-model="selectedCategoryId" id="category" required>
          <option v-for="category in categories" :key="category.categoryId" :value="category.categoryId">{{ category.categoryName }}</option>
        </select>

        <label for="subcategoryId">Subcategory ID:</label>
        <input v-model="SubcategoryId" type="number" id="subcategoryId" required>

        <label for="birthDate">Birth Date:</label>
        <input v-model="BirthDate" type="date" id="birthDate" required>

        <button type="submit">Add Contact</button>
      </form>
    </div>
  </template>


<script lang="ts">
import { ref, onMounted } from 'vue';
import axios from 'axios';

export default {
  setup() {
    const Name = ref();
    const Surname = ref();
    const Phone = ref();
    const Email = ref();
    const Password = ref();
    const selectedCategoryId = ref();
    const CategoryId = ref();
    const SubcategoryId = ref();
    const BirthDate = ref('');
    const categories = ref([]);
    const subcategories = ref([]);

    const addContact = async () => {
      try {
        await axios.post(
        "api/AddContact",
        {
          Name: Name.value,
          Surname: Surname.value,
          Phone: Phone.value,
          Email: Email.value,
          Password: Password.value,
          CategoryId: selectedCategoryId.value,
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

    const fetchCategories = async () => {
      try {
        const response = await axios.get('/api/GetCategories', {
          headers: {
            accept: 'application/json',
          },
        });
        categories.value = response.data;
        console.log(response.data)
      } catch (error) {
        console.error('Error fetching categories:', error);
      }
    };

    onMounted(() => {
      fetchCategories();
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
      addContact,
      categories,
      selectedCategoryId
    };
  }
};
</script>