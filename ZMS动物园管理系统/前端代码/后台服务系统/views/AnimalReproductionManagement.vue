<template>
  <div class="home">
    <span class="zms-anicare-title zms-primary-color" color="primary">
      <v-icon color="primary">mdi-needle</v-icon> 动物繁育管理
    </span>
    <animal-breed-container />
  </div>
</template>
<script>
import AnimalBreedContainer from "../components/AnimalBreed/AnimalBreedContainer.vue";
export default {
  name: "AnimalRecipeManagement",
  components: { AnimalBreedContainer },
  created() {
    this.$store.dispatch("alterTopNavTitle", {
      title: this.$store.state.sPageName.animalReproduction,
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
