<template>
  <div class="home">
    <span class="zms-anicare-title zms-primary-color" color="primary">
      <v-icon color="primary">mdi-information</v-icon> 动物信息管理
    </span>
    <ani-info-container />
  </div>
</template>
<script>
import AniInfoContainer from "../components/AnimalInformation/AniInfoContainer.vue";
export default {
  name: "AnimalInfoManagement",
  components: {
    AniInfoContainer,
  },
  created() {
    this.$store.dispatch("alterTopNavTitle", {
      title: this.$store.state.sPageName.animalInfo,
    });
  },
};
</script>
<style scoped lang="scss">
.zms-anicare {
  margin-top: 10px;
}
.zms-anicare-title {
  font-size: 23px !important;
  font-weight: bold;
  letter-spacing: 1px;
}
</style>
