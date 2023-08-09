<template>
    <form @submit.prevent="SubmitForm" method="post">
      <div>
        <label for="Email">Email</label>
        <input v-model="email" id="Email" />
      </div>
      <div>
        <label for="Password">Password</label>
        <input v-model="password" id="Password" type="password" />
      </div>
      <input type="submit" value="Login" />
    </form>
</template>

<script setup lang="ts">
  import { ref } from 'vue';
  import axios from 'axios';
  import { useRouter } from 'vue-router';

  const email = ref('');
  const password = ref('');

  const router = useRouter(); //init routera

  const SubmitForm = async () => { //Przy zatwierdzeniu formularza wysyłamy requesta (z wykorzystaniem biblioteki axios) do API wraz z danymi z formularza. Zwrotka loguje użytkownika.
    try {
      await axios.post(
        "api/SignIn",
        {
          Email: email.value,
          Password: password.value, //parametry
        },
        {
          headers: {
            Accept: "*/*",
            "Content-Type": "multipart/form-data", //Nagłówki
          },
        }
      );
      router.push('/list'); //Przeniesienie na strone z listą.
    } catch (error) {
      console.error(error); //Wyłapanie błędów do konsoli.
    }
  };
</script>

<style>
    @import "../styles/SignIn.css";
</style>