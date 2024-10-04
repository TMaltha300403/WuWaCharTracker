<template>
  <div style="padding: 50px">
    <VCard variant="tonal">
      {{selectedcharacter}}
    </VCard>
  </div>

</template>

<script lang="ts" setup>
import {onMounted, ref} from "vue";
import axios from "axios";

const url = window.location.href;
const characterid = url.split("/").slice(-1)[0];
const selectedcharacter = ref<Character>();

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
}


interface Character {
  id: string
  name: string
  flowerID: string
  materialID: string
  tacetCoreID: string
}
</script>
