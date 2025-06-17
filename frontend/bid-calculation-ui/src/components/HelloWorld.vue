<script setup lang="ts">
import { ref } from "vue";

defineProps<{ msg: string }>();

const count = ref(0);
</script>

<template>
  <h1>{{ msg }}</h1>

  <div class="card">
    <button type="button" @click="count++">count is {{ count }}</button>
  </div>
  <p>
    By Julian Osorio ->
    <a
      href="https://www.linkedin.com/in/julian-emilio-osorio-larroche-574591150/"
      target="_blank"
      >Linkedin</a
    >.
  </p>
</template>

<style scoped>
.read-the-docs {
  color: #888;
}
</style>
