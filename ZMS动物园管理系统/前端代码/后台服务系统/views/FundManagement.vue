<template>
  <div class="home">
    <span class="zms-view-title zms-primary-color">
      <v-icon color="primary">mdi-sack</v-icon> 资金管理
    </span>
    <div class="zms-wareitem">
      <fund-container />
    </div>
  </div>
</template>
<script>
import FundContainer from "../components/FundComponents/FundContainer.vue";
export default {
  name: "FundManagement",
  components: {
    FundContainer,
  },
  created() {
    this.$store.dispatch("alterTopNavTitle", {
      title: this.$store.state.sPageName.fundManagement,
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
.zms-wareitem {
  margin-top: 20px;
}
</style>
