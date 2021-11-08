<!---调用页脚--->
<template>
  <div class="footx">
    <foot class="footx" v-if="showFoot" />
  </div>
</template>
<script>
import foot from "./foot.vue";
export default {
  components: {
    foot,
  },
  computed: {
    showFoot() {
      if (
        this.$route.path.toLowerCase() != "/login" &&
        this.$route.path.toLowerCase() != "/register"
      ) {
        return true;
      }
      return false;
    },
  },
};
</script>
<style scoped>
.footx {
  z-index: 1;
  position: relative;
}
</style>