<template>
  <div class="home">
    <span class="zms-view-title zms-primary-color">
      <v-icon color="primary">mdi-database</v-icon> 货物信息管理
    </span>
    &nbsp;&nbsp;&nbsp;&nbsp;
    <v-btn light color="primary" @click="routerGo('/warehouseManagement')">
      <v-icon>mdi-arrow-left</v-icon>返回仓库管理
    </v-btn>
    <div class="zms-wareitem">
      <warehouse-item-overview />
    </div>
  </div>
</template>

<script>
import WarehouseItemOverview from "../components/WarehouseComponents/WarehouseItemOverview.vue";
export default {
  name: "WarehouseItemManagement",
  components: {
    WarehouseItemOverview,
  },
  created() {
    this.$store.dispatch("alterTopNavTitle", {
      title: this.$store.state.sPageName.warehouseManagement_item,
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
