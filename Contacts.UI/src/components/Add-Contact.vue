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

        <label v-if="selectedCategoryId === 1 || selectedCategoryId === 3" for="subcategory">Subcategory:</label>
        <select v-if="selectedCategoryId === 1" v-model="selectedSubcategoryId" id="subcategoryOption" required>
          <option v-for="subcategory in subcategories" :key="subcategory.subcategoryId" :value="subcategory.subcategoryId">{{ subcategory.subcategoryName }}</option>
        </select>

        <input v-if="selectedCategoryId === 3" v-model="selectedSubcategoryId" id="subcategoryInput" required>

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
    const selectedSubcategoryId = ref();
    const SubcategoryId = ref();
    const BirthDate = ref('');
    const categories = ref([]);
    const subcategories = ref([]);
    let cat = 0

    const addContact = async () => {

      if(selectedCategoryId.value === 3){
          await axios.post(
          "api/AddNewSubcategory",
          {
            subcategoryName: selectedSubcategoryId.value,
          },
          {
            headers: {
              Accept: "*/*",
              "Content-Type": "multipart/form-data",
            },
          }
        );

        const response = await axios
        .get(`/api/GetSubcategoryIdBySubcategoryName?subcategoryName=${selectedSubcategoryId.value}`, {
          headers: {
            accept: 'application/json',
          },
        })
        .then(response => {
          cat = response.data;
        })
        .catch(error => {
          console.error('Error fetching contacts:', error);
        });
      }
      else{
        cat = selectedSubcategoryId.value;
      }

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
          SubcategoryId: cat,
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
      addContact,
      categories,
      selectedCategoryId,
      selectedSubcategoryId,
      subcategories
    };
  }
};
</script>