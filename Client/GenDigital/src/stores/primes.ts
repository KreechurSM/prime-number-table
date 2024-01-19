import { ref, computed } from 'vue'
import { defineStore } from 'pinia'
import axios from 'axios'

export const usePrimesStore = defineStore('primes', () => {
  const count = ref(0)
  const doubleCount = computed(() => count.value * 2)
  function increment() {
    count.value++
  }

  async function fetchPrimeTable(number: Number) {
    const data = await axios.get(`http://localhost:5122/generatetable/${number}`)
    return data.data
  }

  return { count, doubleCount, increment, fetchPrimeTable }
})