<template>
  <div class="home">
    <span class="zms-view-title zms-primary-color">
      <v-icon color="primary">mdi-cart</v-icon> 采购管理
    </span>
    <div class="zms-wareitem">
      <procurement-container />
    </div>
  </div>
</template>
<script>
import ProcurementContainer from "../components/ProcurementComponents/ProcurementContainer.vue";
export default {
  name: "FundManagement",
  components: {
    ProcurementContainer,
  },
  created() {
    this.$store.dispatch("alterTopNavTitle", {
      title: this.$store.state.sPageName.procurement,
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
