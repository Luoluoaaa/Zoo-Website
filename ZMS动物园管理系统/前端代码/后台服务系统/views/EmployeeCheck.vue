<template>
  <div class="home">
    <span class="zms-view-title zms-primary-color">
      <v-icon color="primary">el-icon-s-check</v-icon> 员工考核信息管理
    </span>
    &nbsp;&nbsp;&nbsp;&nbsp;
    <v-btn light color="primary" @click="routerGo('/employeeManagement')">
      <v-icon>mdi-arrow-left</v-icon>返回员工管理
    </v-btn>
    <div class="zms-Employeeeitem">
      <Employeee-item-overview />
    </div>
  </div>
</template>
<script>
import EmployeeeItemOverview from "../components/EmployeeComponents/EmployeeCheckContainer.vue";
export default {
  name: "EmployeeeItemManagement",
  components: {
    EmployeeeItemOverview,
  },
  created() {
    this.$store.dispatch("alterTopNavTitle", {
      title: this.$store.state.sPageName.EmployeeManagement_check,
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
.zms-Employeeeitem {
  margin-top: 20px;
}
</style>
