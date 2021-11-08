<template>
  <div class="home">
    <span class="zms-view-title zms-primary-color">
      <v-icon color="primary">mdi-database</v-icon> 仓库管理
    </span>
    <warehouse-container />
  </div>
</template>
<script>
import WarehouseContainer from "../components/WarehouseComponents/WarehouseContainer.vue";
export default {
  name: "WarehouseManagement",
  components: {
    WarehouseContainer,
  },
  created() {
    this.$store.dispatch("alterTopNavTitle", {
      title: this.$store.state.sPageName.warehouseManagement,
    });
  },
};
</script>
<style scoped lang="scss"></style>
