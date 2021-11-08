<template>
  <div class="home">这里放动物食谱管理</div>
</template>
<script>
export default {
  name: "AnimalRecipeManagement",
  created() {
    this.$store.dispatch("alterTopNavTitle", {
      title: this.$store.state.sPageName.animalRecipe,
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
