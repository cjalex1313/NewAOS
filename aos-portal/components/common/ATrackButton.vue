<template>
  <button
    type="button"
    :class="[variantStyles[variant], sizeStyles[size], roundedStyles]"
  >
    {{ text }}
  </button>
</template>

<script setup lang="ts">
const props = withDefaults(
  defineProps<{
    text: string;
    variant?: Variant;
    size?: Size;
    rounded?: boolean;
  }>(),
  {
    variant: "primary",
    size: "medium",
    rounded: false,
  }
);

const variantStyles = {
  primary:
    "bg-blue-600 text-white shadow-sm hover:bg-blue-500 focus-visible:outline focus-visible:outline-2 focus-visible:outline-offset-2 focus-visible:outline-blue-600",
  secondary:
    "bg-white text-gray-900 shadow-sm ring-1 ring-inset ring-gray-300 hover:bg-gray-50",
};

const sizeStyles = {
  medium: "rounded-md px-2.5 py-1.5 text-sm font-semibold",
};

const roundedStyles = props.rounded ? "rounded-full" : "";
</script>
