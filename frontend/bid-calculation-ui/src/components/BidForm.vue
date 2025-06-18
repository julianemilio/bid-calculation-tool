<template>
  <div class="space-y-4">
    <input v-model.number="price" type="number" min="0" placeholder="Vehicle Price" class="input" />
    <select v-model="type" class="input">
      <option value="Common">Common</option>
      <option value="Luxury">Luxury</option>
    </select>

    <button @click="handleCalculate" class="bg-blue-600 text-white px-4 py-2 rounded">
      Calculate
    </button>

    <div v-if="fees">
      <p>Basic Fee: ${{ fees.basicFee }}</p>
      <p>Special Fee: ${{ fees.specialFee }}</p>
      <p>Association Fee: ${{ fees.associationFee }}</p>
      <p>Storage Fee: ${{ fees.storageFee }}</p>
      <p class="font-bold text-lg">Total: ${{ fees.total }}</p>
    </div>
  </div>
</template>

<script lang="ts" setup>
import { ref, watch } from 'vue'
import { calculateBid, type VehicleResponse } from '@/api/bidService'

const price = ref<number>(0)
const type = ref<'Common' | 'Luxury'>('Common')
const fees = ref<VehicleResponse | null>(null)

const handleCalculate = async () => {
  if (price.value <= 0) return
  fees.value = await calculateBid({ price: price.value, type: type.value })
}

watch([price, type], () => {
  if (price.value > 0) handleCalculate()
})
</script>

<style scoped>
.input {
  @apply border border-gray-300 rounded px-3 py-2 w-full;
}
</style>
