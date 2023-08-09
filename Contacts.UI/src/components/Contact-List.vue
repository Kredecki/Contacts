<template>
  <div class="container">
    <button class="Add" v-if="isAuthorized" @click="GotoAdd">+</button> <!-- Widoczne tylko po zalogowaniu -->
    <div v-for="contact in contacts" :key="contact.contactId" class="contact"> <!-- Pętlą listujemy wszystkie kontakty z bazy. -->
      <div class="contact-details" @click="togglePhoneNumber(contact)">
        {{ contact.name }} {{ contact.surname }}
        <button class="Delete" v-if="isAuthorized" @click="removeContact(contact.contactId)">DELETE</button> <!-- Widoczne tylko po zalogowaniu -->
      </div>
      <div class="buttons" v-if="contact.showPhoneNumber">
        Phone number: {{ contact.phone }}
        <div>
          <button class="Call">Call</button>
          <button class="Message">Message</button>
          <button class="VideoCall">Video Call</button>
          <button class="Info" @click="GoToDetails(contact.contactId)">Info</button>
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

    function GetContacts() { //Pobieramy kontakty z bazy.
      axios
        .get('/api/GetContacts', {
          headers: {
            accept: 'application/json',
          },
        })
        .then(response => {
          const contactsData = response.data.map((contact: Contact) => ({ //Mapujemy do obiektu
            ...contact,
            showPhoneNumber: false,
          }));
          contacts.value = contactsData;
        })
        .catch(error => {
          console.error('Error fetching contacts:', error);
        });
    }

    function togglePhoneNumber(clickedContact: Contact) { //Po naciśnięciu pojawia się numer telefonu oraz przyciski. Możemy wyświetlić dane dla max jednego kontaktu.
      contacts.value.forEach(contact => {
        if (contact !== clickedContact) {
          contact.showPhoneNumber = false;
        }
      });
      clickedContact.showPhoneNumber = !clickedContact.showPhoneNumber;
    }

    function IsAuthorized() { //Metoda spawdzająca, czy użytkownik jest zalogowany.
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

    async function removeContact(contactId: number) { //Zapytanie API o usunięcie kontaktu.
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

    function GotoAdd(){ //Przekierowanie do dodawania kontaktu.
      router.push('/add');
    }

    function GoToDetails(Id: Number){ //Przekierowanie do szczegółów kontaktu.
      router.push(`/Details?id=${Id}`);
    }

    onBeforeMount(async () => { //Cykl życia strony - wykonywane przed mountem strony.
      await IsAuthorized(); //Sprawdzanie czy użytkownik jest zalogowany.
    });

    onMounted(() => { //Cykl życia strony.
      GetContacts(); //Pobieranie kontaktów.
    });

    return { //Zwrotka w architekturze MVVM
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
