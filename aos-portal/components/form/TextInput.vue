<template>
  <div>
    <label
      v-if="label"
      :for="name"
      class="block text-sm font-medium leading-6 text-gray-900 mb-2"
    >
      {{ label }}
    </label>
    <div class="relative">
      <input
        type="text"
        :value="modelValue"
        :name="name"
        :class="classes"
        @input="updateValue"
        class="block w-full rounded-md border-0 py-1.5 px-2 shadow-sm ring-1 ring-inset focus:ring-2 focus:ring-inset sm:text-sm sm:leading-6"
        :placeholder="placeholder"
      />
      <div
        v-if="error"
        class="pointer-events-none absolute inset-y-0 right-0 flex items-center pr-3"
      >
        <svg
          class="h-5 w-5 text-red-500"
          viewBox="0 0 20 20"
          fill="currentColor"
          aria-hidden="true"
        >
          <path
            fill-rule="evenodd"
            d="M18 10a8 8 0 11-16 0 8 8 0 0116 0zm-8-5a.75.75 0 01.75.75v4.5a.75.75 0 01-1.5 0v-4.5A.75.75 0 0110 5zm0 10a1 1 0 100-2 1 1 0 000 2z"
            clip-rule="evenodd"
          />
        </svg>
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
  name: {
    type: String,
    default: "",
  },
  placeholder: {
    type: String,
    default: "",
  },
});

const emit = defineEmits(["update:modelValue"]);

const updateValue = (event: any) => {
  emit("update:modelValue", event.target.value);
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
