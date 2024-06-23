<template>
  <div class="flex min-h-full flex-col justify-center px-6 py-12 lg:px-8">
    <div class="sm:mx-auto sm:w-full sm:max-w-sm">
      <img class="mx-auto h-10 w-auto" src="/ATrackLogo.png" alt="ATrack" />
      <h2
        class="mt-10 text-center text-2xl font-bold leading-9 tracking-tight text-gray-900"
      >
        Sign in to your account
      </h2>
    </div>

    <div class="mt-10 sm:mx-auto sm:w-full sm:max-w-sm">
      <form class="space-y-6" @submit.prevent>
        <div>
          <TextInput
            v-model="loginData.username"
            label="Username"
            :errors="v$.username.$errors"
          />
        </div>

        <div>
          <Password
            v-model="loginData.password"
            label="Password"
            :errors="v$.password.$errors"
          />
        </div>

        <div>
          <ATrackButton @click="tryLogin" text="Sign in" class="w-full" />
        </div>
      </form>
    </div>
  </div>
</template>

<script setup lang="ts">
import { required, helpers } from "@vuelidate/validators";
import { useVuelidate } from "@vuelidate/core";
import { reactive } from "vue";
import { login } from "~/api-services/authService";

const router = useRouter();
const userStore = useUserStore();

const loginData = reactive({
  username: "",
  password: "",
});

const rules = computed(() => ({
  username: {
    required: helpers.withMessage("Username is required", required),
  },
  password: {
    required: helpers.withMessage("Password is required", required),
  },
}));

const tryLogin = async () => {
  await v$.value.$validate();
  if (v$.value.$invalid) {
    return;
  }
  try {
    const data = await login(loginData.username, loginData.password);
    if (data) {
      userStore.setIsLoggedIn(true);
      router.push("/");
    }
  } catch {
    useNuxtApp().$toast.error("Invalid username or password");
  }
};

const v$ = useVuelidate(rules, loginData);
</script>
