<template>
  <VCard title="Create Character" variant="tonal">
    <VForm
      validate-on="blur"
      @submit.prevent="submit"
    >
      <VCardText>
        <VTextField
          v-model="selectedName"
          :rules="[required('Character name')]"
          label="Character Name"
        />
      </VCardText>

      <VCardText>
        <VSelect
          v-model="selectedFlower"
          :rules="[required('Flower type')]"
          label="Select Flower Type"
          :items=flowers
          :item-title="item => item.name"
          :item-value="item => item.id"
          variant="outlined"></VSelect>
      </VCardText>

      <VCardText>
        <VSelect
          v-model="selectedMaterial"
          :rules="[required('Material type')]"
          label="Select Material Type"
          :items=materials
          :item-title="item => item.nameLow"
          :item-value="item => item.id"
          variant="outlined"></VSelect>
      </VCardText>

      <VCardText>
        <VSelect
          v-model="selectedTacetCore"
          :rules="[required('Tacet core type')]"
          label="Select Tacet Core Type"
          :items=tacetcores
          :item-title="item => item.name"
          :item-value="item => item.id"
          variant="outlined"></VSelect>
      </VCardText>

      <VCardActions>
        <VBtn
          type="submit"
        >
          submit
        </VBtn>
      </VCardActions>
    </VForm>
  </VCard>
</template>

<script setup lang="ts">

import axios from "axios";
import {onMounted, ref} from "vue";
import router from "@/router";
import {SubmitEventPromise} from "vuetify";

let flowers = ref<Flower[]>([]);
let materials = ref<Material[]>([]);
let tacetcores = ref<TacetCore[]>([]);

const selectedName = ref('');
const selectedFlower = ref('');
const selectedMaterial = ref('');
const selectedTacetCore = ref('');

onMounted(() => {
  getAllFlowers()
  getAllMaterials()
  getAllTacetCores()
})

interface Flower {
  id: string
  name: string
}

interface Material {
  id: string
  nameLow: string
  nameMedium: string
  nameHigh: string
  nameHighest: string
}

interface TacetCore {
  id: string
  name: string
}

async function getAllFlowers(){
  const options = {
    method: 'GET',
    url: 'https://localhost:7198/api/Flower/GetAllFlowers',
    param: ''
  };
  axios
    .request(options)
    .then(response => flowers.value = response.data)
    .catch(error => {
      console.log(error)
    })
}

async function getAllMaterials(){
  const options = {
    method: 'GET',
    url: 'https://localhost:7198/api/Material/GetAllMaterials',
    param: ''
  };
  axios
    .request(options)
    .then(response => materials.value = response.data)
    .catch(error => {
      console.log(error)
    })
}

async function getAllTacetCores(){
  const options = {
    method: 'GET',
    url: 'https://localhost:7198/api/TacetCore/GetAllTacetCores',
    param: ''
  };
  axios
    .request(options)
    .then(response => tacetcores.value = response.data)
    .catch(error => {
      console.log(error)
    })
}

async function createCharacter(){
  if (selectedName.value != null && selectedFlower.value != null && selectedMaterial.value != null && selectedTacetCore.value != null){
    const options = {
      method: 'POST',
      url: 'https://localhost:7198/api/Character/CreateCharacter',
      data: JSON.stringify({ name: selectedName.value, flowerID: selectedFlower.value, materialID: selectedMaterial.value, tacetCoreID: selectedTacetCore.value}),
      headers: {
        "Content-Type": "application/json",
        "Accept": "application/json"
      }
    };
    axios
      .request(options)
      .then(response => {
        console.log(response.status);
      })
      .catch(error => {
        console.log(error)
      })
  }

}

async function submit(event: SubmitEventPromise){
  const { valid } = await event
  if(valid){
    await createCharacter()
    await router.push('/')
  }

}

function required(fieldName: string): (v: string) => true | string {
  return v => !!v || `${fieldName} is required`}
</script>
