<template>
  <div class="zms-anicare">
    <span class="zms-anicare-title zms-primary-color" color="primary">
      <v-icon color="primary">mdi-food</v-icon> 动物喂养和饲料管理
    </span>
    <animal-feed-container />
  </div>
</template>
<script>
import AnimalFeedContainer from "../components/AnimalFeed/AnimalFeedContainer.vue";
export default {
  name: "AnimalFeedManagement",
  components: { AnimalFeedContainer },
  created() {
    this.$store.dispatch("alterTopNavTitle", {
      title: this.$store.state.sPageName.animalFeed,
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
