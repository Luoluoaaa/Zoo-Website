<template>
  <div class="service">
    <div class="border"></div>
    <convenience-service />
  </div>
</template>
<script>
import ConvenienceService from "@/components/ConvenienceService.vue";
export default {
  components: {
    ConvenienceService,
  },
};
</script>
<style scoped>
.border {
  height: 100px;
}
</style>