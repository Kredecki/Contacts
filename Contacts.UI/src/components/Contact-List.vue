<template>
  <div class="container">
    <button class="Add" v-if="isAuthorized">+</button>
    <div v-for="contact in contacts" :key="contact.ContactId" class="contact">
      <div class="contact-details" @click="togglePhoneNumber(contact)">
        {{ contact.name }} {{ contact.surname }} {{ contact.ContactId }}
        <button class="Delete" v-if="isAuthorized">DELETE</button>
      </div>
      <div class="buttons" v-if="contact.showPhoneNumber">
        Phone number: {{ contact.phone }}
        <div>
          <button class="Call">Call</button>
          <button class="Message">Message</button>
          <button class="VideoCall">Video Call</button>
          <button class="Info">Info</button>
        </div>
      </div>
    </div>
  </div>
</template>

<script lang="ts">
import { onMounted, ref, defineComponent } from 'vue';
import axios from 'axios';

interface Contact {
  ContactId: number;
  name: string;
  surname: string;
  phone: string;
  showPhoneNumber: boolean;
}

export default defineComponent({
  components: {},
  setup() {
    const contacts = ref<Contact[]>([]);
    let isAuthorized = false;

    function GetContacts() {
      axios
        .get('/api/GetContacts', {
          headers: {
            accept: 'application/json',
          },
        })
        .then(response => {
          const contactsData = response.data.map((contact: Contact) => ({
            ...contact,
            showPhoneNumber: false,
          }));
          contacts.value = contactsData;
        })
        .catch(error => {
          console.error('Error fetching contacts:', error);
        });
    }

    function togglePhoneNumber(clickedContact: Contact) {
      contacts.value.forEach(contact => {
        if (contact !== clickedContact) {
          contact.showPhoneNumber = false;
        }
      });
      clickedContact.showPhoneNumber = !clickedContact.showPhoneNumber;
    }

    function IsAuthorized(){
      axios
        .get('/api/IsAuthorized', {
          headers: {
            accept: 'application/json',
          },
        })
        .then(response => {
          if (response.status === 200) {
            isAuthorized = true;
          } else {
            isAuthorized = false;
          }
        })
        .catch(error => {
          console.error('Error fetching authorization status:', error);
        });
    }

    onMounted(() => {
      GetContacts();
      IsAuthorized();
    });

    return {
      contacts,
      togglePhoneNumber,
      isAuthorized
    };
  },
});
</script>

<style>
  @import "../styles/List.css";
</style>
