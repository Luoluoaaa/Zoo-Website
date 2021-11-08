<template>
  <div>
    <nav-bar />
    <router-view />
    <router-view name="content" />
    <footerx />
  </div>
</template>
>
<script>
import footerx from "./views/Footer.vue";
import NavBar from "./views/NavBar.vue";
export default {
  components: {
    footerx,
    NavBar,
  },
};
</script>
<style scoped>
body {
  padding: 0 !important;
}
</style>
