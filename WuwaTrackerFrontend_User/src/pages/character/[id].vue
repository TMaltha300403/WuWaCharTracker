<template>
  <div style="padding: 50px">
    <VCard title="Character Info" variant="tonal">
      a
      <br />
      {{selectedcharacter[0].flowerID}}
      {{selectedflower[0]}}
    </VCard>
  </div>

</template>

<script lang="ts" setup>
import {onMounted, ref} from "vue";
import axios from "axios";

const url = window.location.href;
const characterid = url.split("/").slice(-1)[0];

const selectedcharacter = ref<Character[]>([]);
const selectedflower = ref<Flower[]>([]);
const flowerid = selectedcharacter.value[0]?.flowerID;

onMounted(() => {
  getCharacter()
})

async function getCharacter(){
  const options ={
    method: 'GET',
    url: 'https://localhost:7198/api/Character/GetCharacter',
    params: { id: characterid }
  };
  axios
    .request(options)
    .then(response => selectedcharacter.value = response.data)
    .catch(error => {
      console.log(error)
    })
  getFlower()
}

async function getFlower(){
  const options ={
    method: 'GET',
    url: 'https://localhost:7198/api/Flower/GetFlower',
    params: { id: flowerid }
  };
  axios
    .request(options)
    .then(response => selectedflower.value = response.data)
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

interface Flower {
  id: string
  name: string
}
</script>
