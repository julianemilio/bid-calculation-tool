<script setup lang="ts">
import HelloWorld from "./components/HelloWorld.vue";
</script>

<template>
  <div>
    <a href="https://progi.com/" target="_blank">
      <img
        src="https://progi.com/wp-content/uploads/2022/05/Progi_adm_300-600x228.png"
        class="logo"
        alt="Progi logo"
      />
    </a>
  </div>
  <HelloWorld msg="Bit Calculator" />
</template>

<style scoped>
.logo {
  height: 6em;
  padding: 1.5em;
  will-change: filter;
  transition: filter 300ms;
}
.logo:hover {
  filter: drop-shadow(0 0 2em #646cffaa);
}
</style>
