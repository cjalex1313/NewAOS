export default defineNuxtRouteMiddleware((to, from) => {
  const jwt = useCookie('jwt') // Use the name of your JWT cookie

  if (!jwt.value) {
    if (to.path !== '/auth/login') {
      return navigateTo('/auth/login')
    }
  }
})