<template>
  <div class="zms-animalinfo">
    <ani-info-query />
  </div>
</template>
<script>
import AniInfoQuery from "./AniInfoQuery.vue";
export default {
  name: "AniInfoContainer",
  components: {
    AniInfoQuery,
  },
  data: () => {
    return {
      tab: null,
    };
  },
  created() {},
};
</script>
<style scoped lang="scss"></style>
