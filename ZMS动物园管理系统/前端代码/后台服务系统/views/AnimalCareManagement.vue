<template>
  <div class="zms-anicare">
    <span class="zms-anicare-title zms-primary-color" color="primary">
      <v-icon color="primary">mdi-needle</v-icon>
      {{ $t("viewTitles.animalCareMan") }}
    </span>
    <ani-care-container />
  </div>
</template>
<script>
import AniCareContainer from "../components/AnimalCareComponents/AniCareContainer.vue";
export default {
  name: "AnimalCareManagement",
  components: {
    AniCareContainer,
  },
  created() {
    this.$store.dispatch("alterTopNavTitle", {
      title: this.$store.state.sPageName.animalCare,
    });
  },
};
</script>
<style scoped lang="scss">
.zms-anicare {
  margin-top: 10px;
}
.zms-anicare-title {
  font-size: 23px;
  font-weight: bold;
  letter-spacing: 1px;
}
</style>
