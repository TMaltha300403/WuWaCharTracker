<template>
  <div style="padding: 50px">
    <v-card title="Characters" variant="tonal">
      <v-text-field
        v-model="search"
        label="Search"
        prepend-inner-icon="mdi-magnify"
        variant="outlined"
        hide-details
        single-line
      ></v-text-field>
      <v-data-table
        v-model="selectedChar"
        :items-per-page="5"
        :items="characters"
        :search="search"
        select-strategy="single"
        show-select
        item-value="id"
      >
      </v-data-table>
      <v-card-actions>
        <v-btn
        to="/characters/create"
        >Add</v-btn>
        <v-btn
        @click="deleteCharacter">Remove</v-btn>
        <v-btn>Edit</v-btn>
      </v-card-actions>
    </v-card>
  </div>

</template>

<script lang="ts" setup>
import axios from "axios";
import {onMounted, ref} from "vue";
let characters = ref<Character[]>([]);
const search = ref('')
const selectedChar = ref('')

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

async function deleteCharacter(){
  if(selectedChar.value != null){
    const options ={
      method: 'DELETE',
      url: `https://localhost:7198/api/Character/DeleteCharacter/`,
      params: { id: selectedChar.value.at(0)}
    };
    axios
      .request(options)
      .then(response => console.log(response.status))
      .catch(error => {
        console.log(error)
      })
  }
}

interface Character {
  id: string
  name: string
  flowerID: string
  materialID: string
  tacetCoreID: string

}

</script>
