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
      <div>
        <label for="Repassword">Password</label>
        <input v-model="repassword" id="Repassword" type="password" />
      </div>
      <input type="submit" value="Register" />
    </form>
</template>

<script setup lang="ts">
  import { ref } from 'vue';
  import axios from 'axios';

  const email = ref('');
  const password = ref('');
  const repassword = ref('');

  const SubmitForm = async () => { //Przy zatwierdzeniu formularza wysyłamy requesta (z wykorzystaniem biblioteki axios) do API wraz z danymi z formularza. Zwrotka rejestruje użytkownika.
    try {
      await axios.post(
        "api/SignUp",
        {
          Email: email.value,
          Password: password.value,
          Repassword: repassword.value //Parametry
        },
        {
          headers: {
            Accept: "*/*",
            "Content-Type": "multipart/form-data", //Nagłowki
          },
        }
      );
    } catch (error) {
      console.error(error); //Wyłapujemy błąd do konsoli (zazwyczaj 400 jak coś nie przejdzie, albo 500 jak serwer API nie odpowiada.)
    }
  };
</script>

<style scoped>
  @import "../styles/SignUp.css";
</style>
