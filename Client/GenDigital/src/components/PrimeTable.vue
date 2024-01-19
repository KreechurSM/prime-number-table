<template>
  <div class="flex flex-column flex-wrap items-center content-start justify-center h-screen">
    <div style="width: 100%" class="flex justify-center">
      <p class="text-lg my-12" style="text-align: center">
        Enter an integer to view multiple tables
      </p>
    </div>
    <div class="flex flex-col space-y-2">
      <input
        type="number"
        placeholder="Enter an integer"
        class="px-3 py-2 border border-gray-300 rounded-md focus:outline-none focus:ring-2 focus:ring-blue-500"
        style="color: black"
        v-model="inputValue"
      />
      <button
        class="px-4 py-2 text-white bg-blue-500 rounded-md hover:bg-blue-700"
        @click="generatePrime"
      >
        Submit
      </button>
    </div>
    <div class="flex justify-center" style="width: 100%; max-height: 500px">
      <div class="flex justify-center" style="width: 75%; overflow-x: auto; overflow-y: auto">
        <table
          v-if="primeTable.length > 0"
          class="text-lg table-auto"
          style="max-width: 75%; overflow-x: auto"
        >
          <thead>
            <tr
              style="
                font-weight: bold;
                color: white;
                border-bottom-width: 2px;
                border-bottom-color: whitesmoke;
              "
            >
              <td
                class="mx-4"
                style="border-right-width: 2px; border-right-color: whitesmoke; text-align: center"
              >
                X
              </td>
              <th v-for="i in rowSize" class="mx-4">
                {{ i }}
              </th>
            </tr>
          </thead>
          <tbody>
            <tr v-for="(row, i) in tableRows" class="my-1">
              <td
                class="header mx-4"
                style="
                  font-weight: bold;
                  color: white;
                  border-right-width: 2px;
                  border-right-color: whitesmoke;
                "
              >
                {{ i + 1 }}
              </td>
              <td class="mx-4" v-for="node in row" :class="{ prime: node.isPrime }">
                {{ node.number }}
              </td>
            </tr>
          </tbody>
        </table>
      </div>
    </div>
  </div>
</template>

<script setup lang="ts">
import { computed, ref } from 'vue'
import { usePrimesStore } from '@/stores/primes'

const inputValue = ref(1)
const input = ref(1)
const loading = ref(false as boolean)
const primeTable = ref([])

const primeStore = usePrimesStore()

const rowSize = computed(() => input.value + 1)
const tableRows = computed(() => {
  let rows = []
  for (var i = 0; i < primeTable.value.length; i += rowSize.value) {
    rows.push(primeTable.value.slice(i, i + rowSize.value))
  }

  return rows
})

const generatePrime = async () => {
  if (Number.isInteger(inputValue.value) && inputValue.value > 1) {
    input.value = inputValue.value
    loading.value = true
    primeTable.value = await primeStore.fetchPrimeTable(input.value)
    console.log(primeTable.value)
  }
}
</script>

<style>
.prime {
  color: violet;
}
</style>
