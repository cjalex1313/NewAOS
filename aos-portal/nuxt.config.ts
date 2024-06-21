// https://nuxt.com/docs/api/configuration/nuxt-config
export default defineNuxtConfig({
  devtools: { enabled: true },
  modules: ['@pinia/nuxt', "@nuxtjs/tailwindcss", "nuxt-primevue"],
  app:{
    head: {
      title: 'ATrack Admin',
    }
  },
  runtimeConfig: {
    public: {
      apiBaseUrl: process.env.AOS_API_BASE_URL
    }
  },
  components: [{
    path: '~/components',
    pathPrefix: false
  }]
})