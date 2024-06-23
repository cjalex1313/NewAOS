<template>
  <div>
    <label
      v-if="label"
      for="password"
      class="block text-sm font-medium leading-6 text-gray-900 mb-2"
      >{{ label }}</label
    >
    <div class="relative">
      <input
        :type="visible ? 'text' : 'password'"
        :value="modelValue"
        name="password"
        @input="updateValue"
        class="block w-full rounded-md border-0 py-1.5 px-2 shadow-sm ring-1 ring-inset ring-gray-300 placeholder:text-gray-400 focus:ring-2 focus:ring-inset sm:text-sm sm:leading-6"
        :class="classes"
        :placeholder="placeholder"
      />
      <div class="absolute inset-y-0 right-0 flex items-center pr-3">
        <nuxt-icon
          @click="togglePasswordVisibility"
          class="h-5 w-5"
          :class="{
            'text-gray-500': !error,
            'text-red-500': error,
          }"
          :name="!visible ? 'visible/eye-slash-solid' : 'visible/eye-solid'"
        />
        <nuxt-icon
          v-if="error"
          @click="togglePasswordVisibility"
          class="h-5 w-5 text-red-500"
          name="error"
        />
      </div>
    </div>
    <div v-if="error" class="mt-2 text-sm text-red-600">
      {{ error }}
    </div>
  </div>
</template>

<script setup lang="ts">
const props = defineProps({
  modelValue: {
    type: String,
    default: "",
  },
  errors: {
    type: Array,
    default: null,
  },
  label: {
    type: String,
    default: "",
  },
  placeholder: {
    type: String,
    default: "",
  },
});

const visible = ref(false);

const emit = defineEmits(["update:modelValue"]);

const updateValue = (event: any) => {
  emit("update:modelValue", event.target.value);
};

const togglePasswordVisibility = () => {
  visible.value = !visible.value;
};

const classes = computed(() => {
  if (error.value) {
    return "text-red-500 ring-red-300 placeholder:text-red-300 focus:ring-red-500";
  }
  return "text-gray-900 ring-gray-300 placeholder:text-gray-400 focus:ring-blue-600";
});

const error = computed(() => {
  if (props.errors && props.errors.length > 0) {
    const error: any = props.errors[0];
    return error.$message;
  }
  return null;
});
</script>
