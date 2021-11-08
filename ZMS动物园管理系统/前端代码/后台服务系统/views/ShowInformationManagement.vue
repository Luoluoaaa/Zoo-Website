<template>
  <div class="zms-anishowinfo">
    <span class="zms-anishowinfo-title zms-primary-color" color="primary">
      <v-icon color="primary">el-icon-tickets</v-icon> 演出信息管理
    </span>
    <ani-show-info-container />
  </div>
</template>
<script>
import AniShowInfoContainer from "../components/AnimalShowsComponents/AniShowInfoContainer.vue";
export default {
  name: "AnimalShowInfoManagement",
  components: {
    AniShowInfoContainer,
  },
  created() {
    this.$store.dispatch("alterTopNavTitle", {
      title: this.$store.state.sPageName.animalShowInfoManagement,
    });
  },
  methods: {
    routerGo(x) {
      this.$router.push(x);
    },
  },
};
</script>
<style scoped lang="scss">
.zms-anishowinfo {
  margin-top: 10px;
}
.zms-anishowinfo-title {
  font-size: 23px;
  font-weight: bold;
  letter-spacing: 1px;
}
</style>
