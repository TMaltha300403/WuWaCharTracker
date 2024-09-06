<template>
  <div style="padding: 50px">
    <v-card title="Characters" variant="tonal">
      <v-data-table :items-per-page="5" :items="characters"></v-data-table>
      <v-card-actions>
        <v-btn
        to="/characters/create"
        >Add</v-btn>
        <v-btn>Remove</v-btn>
        <v-btn>Edit</v-btn>
      </v-card-actions>
    </v-card>
  </div>

</template>

<script lang="ts" setup>
import axios from "axios";
import {onMounted, ref} from "vue";
let characters = ref<Character[]>([]);

onMounted(() => {
  getAllCharacters()
})

async function getAllCharacters(){
  const options = {
    method: 'GET',
    url: 'https://localhost:7198/api/Character/GetAllCharacters',
    param: ''
  };
  axios
    .request(options)
    .then(response => characters.value = response.data)
    .catch(error => {
      console.log(error)
    })
}

interface Character {
  id: string
  name: string
  flowerID: string
  materialID: string
  tacetCoreID: string

}

</script>
