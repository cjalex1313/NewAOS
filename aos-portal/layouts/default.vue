<template>
  <div>
    <!-- Static sidebar for desktop -->
    <SideMenu />

    <main class="py-10 pl-72">
      <div class="px-4 sm:px-6 lg:px-8">
        <slot />
      </div>
    </main>
  </div>
</template>

<script setup></script>
