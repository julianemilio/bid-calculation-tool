<template>
  <div class="min-h-screen flex items-center justify-center bg-gradient-to-br from-black via-gray-900 to-neutral-900 text-white px-4">
    <div class="w-full max-w-md bg-black/30 rounded-2xl p-8 shadow-lg backdrop-blur-md">
      <div class="flex flex-col items-center text-center space-y-2 mb-6">
      <Logo/>
      <BigTitle  msg="Bit Calculator" />
      </div>
      <BidForm />
      <p class="text-sm text-gray-400">
         Made with <span class="text-yellow-400">♥</span> for Progi | © 2025 Julian Osorio → <a href="https://www.linkedin.com/in/julianemilio/" target="_blank" class="text-blue-400 hover:underline">Linkedin</a>.
      </p>
     
    </div>
  </div>
</template>

<script setup lang="ts">
import BigTitle from '@/components/BigTitle.vue';
import BidForm from '../components/BidForm.vue';
import Logo from '@/components/Logo.vue';
</script>