<template>
  <div class="zms-vehicleManagement">
    <span class="zms-vehicleManagement-title zms-primary-color" color="primary">
      <v-icon color="primary">el-icon-tickets</v-icon> 交通信息管理
    </span>
    <vehicle-management-container />
  </div>
</template>
<script>
import VehicleManagementContainer from "../components/VehicleManagement/VehicleManagementContainer.vue";
export default {
  name: "VehicleManagement",
  components: {
    VehicleManagementContainer,
  },
  created() {
    this.$store.dispatch("alterTopNavTitle", {
      title: this.$store.state.sPageName.vehicleManagement,
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
.zms-vehicleManagement {
  margin-top: 10px;
}
.zms-vehicleManagement-title {
  font-size: 23px;
  font-weight: bold;
  letter-spacing: 1px;
}
</style>
