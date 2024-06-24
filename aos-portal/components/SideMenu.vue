<template>
  <div class="fixed inset-y-0 z-50 flex w-72 flex-col p-2">
    <!-- Sidebar component, swap this element with another sidebar if you like -->
    <div
      class="flex grow flex-col gap-y-5 overflow-y-auto bg-blue-950 px-6 rounded-lg"
    >
      <div class="flex h-16 shrink-0 items-center mt-4">
        <img class="w-full h-auto" src="/ATrackLogo.png" alt="ATrack" />
      </div>
      <nav class="flex flex-1 flex-col">
        <ul role="list" class="flex flex-1 flex-col gap-y-7">
          <li>
            <ul role="list" class="-mx-2 space-y-1">
              <li v-for="item in items" :key="item.id">
                <nuxt-link
                  :to="item.route"
                  class="group flex gap-x-3 rounded-md p-2 text-sm font-semibold leading-6"
                  :class="{
                    'bg-blue-700 text-white': route.path === item.route,
                    'text-blue-200 hover:text-white hover:bg-blue-700':
                      route.path !== item.route,
                  }"
                >
                  <nuxt-icon
                    class="h-6 w-6 shrink-0 menu-item-icon"
                    color="white"
                    :name="item.icon"
                  />
                  {{ item.text }}
                </nuxt-link>
              </li>
            </ul>
          </li>
        </ul>
        <div class="mt-auto text-blue-200 pb-2">
          © 2024 ATrack Solutions, Inc.
        </div>
      </nav>
    </div>
  </div>
</template>

<script setup lang="ts">
const route = useRoute();
const items = [
  {
    id: "DomainsAndGoals",
    text: "Domains and Goals",
    icon: "list",
    route: "/",
  },
  {
    id: "ParameterLibrary",
    text: "Parameter Library",
    icon: "book",
    route: "/parameter-library",
  },
];
</script>

<style>
.menu-item-icon svg {
  color: white !important;
  width: 100%;
  height: 100%;
}
</style>
