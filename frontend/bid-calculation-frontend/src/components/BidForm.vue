<template>
  <form class="space-y-6">
    <div>
      <label class="block text-sm font-medium mb-1 text-transparent bg-clip-text bg-gradient-to-r from-[#A37F57] to-[#f5deb3] ">Vehicle Base Price</label>
      <input
        v-model.number="price"
        type="number"
        min="0"
        placeholder="$"
        class="w-full rounded-lg bg-neutral-800 text-white px-4 py-2 border border-neutral-700 focus:outline-none focus:ring-1 focus:ring-yellow-950"
      />
    </div>

    <div>
      <label class="block text-sm font-medium mb-1 text-transparent bg-clip-text bg-gradient-to-r from-[#A37F57] to-[#f5deb3] ">Vehicle Type</label>
      <div class="flex space-x-8">
        <label class="inline-flex items-center space-x-2">
          <input type="radio" :value="0" v-model.number="vehicleType" class="form-radio text-yellow-500 bg-neutral-800 border-neutral-600" />
          <span>Common</span>
        </label>
        <label class="inline-flex items-center space-x-2">
          <input type="radio" :value="1" v-model.number="vehicleType" class="form-radio text-yellow-500 bg-neutral-800 border-neutral-600" />
          <span>Luxury</span>
        </label>
      </div>
    </div>

    <div v-if="fees" class="pt-4 text-sm text-gray-300 space-y-2">
      <div class="flex justify-between">
        <span>Basic Buyer Fee</span>
        <span>${{ fees.basicFee.toFixed(2) }}</span>
      </div>
      <div class="flex justify-between">
        <span>Seller Special Fee</span>
        <span>${{ fees.specialFee.toFixed(2) }}</span>
      </div>
      <div class="flex justify-between">
        <span>Association Fee</span>
        <span>${{ fees.associationFee.toFixed(2) }}</span>
      </div>
      <div class="flex justify-between">
        <span>Storage Fee</span>
        <span>${{ fees.storageFee.toFixed(2) }}</span>
      </div>

      <div class="border-t border-yellow-900 mt-4 py-4 flex justify-between font-semibold text-lg text-transparent bg-clip-text bg-gradient-to-r from-[#A37F57] to-[#f5deb3]">
        <span>Total Cost</span>
        <span>${{ fees.total.toFixed(2) }}</span>
      </div>
    </div>
  </form>
</template>

<script setup lang="ts">
import { ref, watch } from 'vue'
import { calculateBid, type VehicleResponse } from '../api/bidService'

const price = ref<number>(0)
const vehicleType = ref<0 | 1>(0)
const fees = ref<VehicleResponse | null>(null)

const handleCalculate = async () => {
  if (price.value <= 0) return
  fees.value = await calculateBid({ price: price.value, vehicleType: vehicleType.value })
}

watch([price, vehicleType], () => {
  if (price.value > 0) handleCalculate()
})
</script>