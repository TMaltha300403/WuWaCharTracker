<template>
  <div style="padding: 50px">
    <VCard title="Character Info" variant="tonal">
      <div style = "padding: 20px">
        <div v-if="selectedcharacter.length > 0">
          Name: {{selectedcharacter[0].name}}
        </div>
        <div v-if="selectedflower.length > 0">
          Flower: {{selectedflower[0].name}}
        </div>
        <br />
        <br />
        <v-select
          label="Upgrade Level"
          :items="['0 Upgrades', '1 Upgrade', '2 Upgrades', '3 Upgrades', '4 Upgrades', '5 Upgrades', '6 Upgrades']"
          v-model="upgradelevel"
          @update:model-value="UpdateUpgrade"
        ></v-select>
        Low materials: {{lowMaterialAmount}} <br />
        Med Materials: {{medMaterialAmount}} <br />
        High materials: {{highMaterialAmount}} <br />
        Highest materials: {{highestMaterialAmount}} <br />
        Tacet cores: {{tacetCoreAmount}} <br />
        Flowers: {{flowerAmount}} <span v-if="selectedflower.length > 0">{{selectedflower[0].name}}</span>
      </div>
    </VCard>
  </div>

</template>

<script lang="ts" setup>
import {onMounted, ref} from "vue";
import axios from "axios";

const url = window.location.href;
const characterid = url.split("/").slice(-1)[0];

const lowMaterialAmount = ref<number>(0);
const medMaterialAmount = ref<number>(0);
const highMaterialAmount = ref<number>(0);
const highestMaterialAmount = ref<number>(0);
const tacetCoreAmount = ref<number>(0);
const flowerAmount = ref<number>(0);
const upgradelevel = ref<string>('');
const selectedcharacter = ref<Character[]>([]);
const selectedflower = ref<Flower[]>([]);

const selectedUpgradeLevel = ref<number[]>([]);

onMounted(() => {
  getCharacter()
})

async function getCharacter(){
  const options ={
    method: 'GET',
    url: 'https://localhost:7198/api/Character/GetCharacter',
    params: { id: characterid }
  };
  await axios
    .request(options)
    .then(response => selectedcharacter.value = response.data)
    .catch(error => {
      console.log(error)
    })
  if(selectedcharacter.value.length > 0) {
    await getFlower(selectedcharacter.value[0].flowerID)
  }
}

async function getFlower(flowerid: string){
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

async function UpdateUpgrade(){
  let upgradeamount = 0;
  switch(upgradelevel.value){
    case '0 Upgrades':
      upgradeamount = 0;
      break;
    case '1 Upgrade':
      upgradeamount = 1;
      break;
    case '2 Upgrades':
      upgradeamount = 2;
      break;
    case '3 Upgrades':
      upgradeamount = 3;
      break;
    case '4 Upgrades':
      upgradeamount = 4;
      break;
    case '5 Upgrades':
      upgradeamount = 5;
      break;
    case '6 Upgrades':
      upgradeamount = 6;
      break;
  }
  await getUpgrade(upgradeamount);
}

async function getUpgrade(upgradeamount: number) {
  const options = {
    method: 'GET',
    url: 'https://localhost:7198/api/Character/GetUpgradeAmount',
    params: {upgradeLevel: upgradeamount}
  };
  axios
    .request(options)
    .then(response => {
      selectedUpgradeLevel.value = response.data;

      if(selectedUpgradeLevel.value.length > 0){
        lowMaterialAmount.value = selectedUpgradeLevel.value[0]
        medMaterialAmount.value = selectedUpgradeLevel.value[1]
        highMaterialAmount.value = selectedUpgradeLevel.value[2]
        highestMaterialAmount.value = selectedUpgradeLevel.value[3]
        tacetCoreAmount.value = selectedUpgradeLevel.value[4]
        flowerAmount.value = selectedUpgradeLevel.value[5]
      }
    })
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
