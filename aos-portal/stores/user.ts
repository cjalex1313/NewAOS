
export const useUserStore = defineStore('user', () => {

  const isLoggedIn = ref(false);

  const setIsLoggedIn = async (value: boolean) => {
    isLoggedIn.value = value;
  };

  return { isLoggedIn, setIsLoggedIn }
});