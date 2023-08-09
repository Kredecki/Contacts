<template>
  <div class="container">
    <button class="Add" v-if="isAuthorized" @click="GotoAdd">+</button>
    <div v-for="contact in contacts" :key="contact.contactId" class="contact">
      <div class="contact-details" @click="togglePhoneNumber(contact)">
        {{ contact.name }} {{ contact.surname }}
        <button class="Delete" v-if="isAuthorized" @click="removeContact(contact.contactId)">DELETE</button>
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
import { onMounted, ref, defineComponent, onBeforeMount } from 'vue';
import axios from 'axios';
import { useRouter } from 'vue-router';

interface Contact {
  contactId: number;
  name: string;
  surname: string;
  phone: string;
  showPhoneNumber: boolean;
}

export default defineComponent({
  components: {},
  setup() {
    const router = useRouter();

    const contacts = ref<Contact[]>([]);
    let isAuthorized = ref();

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

    function IsAuthorized() {
      axios
        .get("api/IsAuthorized", {
          headers: {
            accept: "*/*",
          },
        })
        .then(() => {
          isAuthorized.value = true;
        })
        .catch(() => {
          isAuthorized.value = false;
        });
    }

    async function removeContact(contactId: number) {
      try {
        const response = await axios.post('/api/RemoveContact', null, {
          params: {
            id: contactId
          },
          headers: {
            'Content-Type': 'application/json'
          }
        });

        if (response.status === 200) {
          console.log('Contact removed successfully.');
        } else {
          console.error('Failed to remove contact.');
        }
        GetContacts();
      } catch (error) {
        console.error('Error removing contact:', error);
      }
    }

    function GotoAdd(){
      router.push('/add');
    }

    function GoToDetails(){
      router.push('/Details');
    }

    onBeforeMount(async () => {
      await IsAuthorized();
    });

    onMounted(() => {
      GetContacts();
    });

    return {
      contacts,
      togglePhoneNumber,
      isAuthorized,
      removeContact,
      GotoAdd,
      GoToDetails
    };
  },
});
</script>

<style>
  @import "../styles/List.css";
</style>
