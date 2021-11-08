<template>
  <div class="home">
    <span class="zms-view-title zms-primary-color">
      <v-icon color="primary">mdi-database</v-icon> 仓库信息管理
    </span>
    &nbsp;&nbsp;&nbsp;&nbsp;
    <v-btn light color="primary" @click="routerGo('/warehouseManagement')">
      <v-icon>mdi-arrow-left</v-icon>返回仓库管理
    </v-btn>
    <div class="zms-wareitem">
      <warehouse-info />
    </div>
  </div>
</template>
<script>
import WarehouseInfo from "../components/WarehouseComponents/WarehouseInfo.vue";
export default {
  name: "WarehouseInfoManagement",
  components: {
    WarehouseInfo,
  },
  created() {
    this.$store.dispatch("alterTopNavTitle", {
      title: this.$store.state.sPageName.warehouseManagement_info,
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
