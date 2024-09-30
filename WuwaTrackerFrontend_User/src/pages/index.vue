<template>
  <div style="padding: 50px">
    <v-card title="Characters" variant="tonal">
      <VTable>
        <thead>
          <tr>
            <th class="text-left">
              Name
            </th>
            <th class="text-left">
              Flower
            </th>
            <th class="text-left">
              Material
            </th>
            <th class="text-left">
              Tacet Core
            </th>
          </tr>
        </thead>
        <tbody>
        <tr
          v-for="item in characters"
          :key="item.name"
        >
          <td>
            <RouterLink
              :to="`/character/${item.id}`"
            >
              {{item.name}}
            </RouterLink>
          </td>
          <td>
            {{item.flowerID}}
          </td>
          <td>
            {{item.materialID}}
          </td>
          <td>
            {{item.tacetCoreID}}
          </td>
        </tr>
        </tbody>
      </VTable>

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
