<template>
  <div>
    <h1 class="text-2xl">Domains</h1>
  </div>
</template>

<script setup lang="ts">
import { getWeather, getSecureAuthWeather } from "~/api-services/watherService";

definePageMeta({
  name: "Domains and Goals",
});

const tryGetWeather = async () => {
  const data = await getWeather();
  console.log(data);
};
const tryGetWeatherSecure = async () => {
  const data = await getSecureAuthWeather();
  console.log(data);
};
const data = await getWeather();
</script>
