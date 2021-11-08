<template>
  <div class="home">
    <span class="zms-view-title zms-primary-color">
      <v-icon color="primary">mdi-database</v-icon> 进出仓管理
    </span>
    &nbsp;&nbsp;&nbsp;&nbsp;
    <v-btn light color="primary" @click="routerGo('/warehouseManagement')">
      <v-icon>mdi-arrow-left</v-icon>返回仓库管理
    </v-btn>
    <div class="zms-wareitem">
      <warehouse-flow />
      <!--<warehouse-info/>-->
    </div>
  </div>
</template>
<script>
import WarehouseFlow from "../components/WarehouseComponents/WarehouseFlow.vue";
export default {
  name: "WarehouseFlowManagement",
  components: {
    WarehouseFlow,
  },
  created() {
    this.$store.dispatch("alterTopNavTitle", {
      title: this.$store.state.sPageName.warehouseManagement_flowRecord,
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
