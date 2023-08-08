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

  const router = useRouter();

  const SubmitForm = async () => {
    try {
      await axios.post(
        "api/SignIn",
        {
          Email: email.value,
          Password: password.value,
        },
        {
          headers: {
            Accept: "*/*",
            "Content-Type": "multipart/form-data",
          },
        }
      );
      router.push('/list');
    } catch (error) {
      console.error(error);
    }
  };
</script>

<style>
    @import "../styles/SignIn.css";
</style>