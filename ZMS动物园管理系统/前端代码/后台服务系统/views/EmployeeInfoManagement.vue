<template>
  <div class="home">
    <span class="zms-view-title zms-primary-color">
      <v-icon color="primary">el-icon-user</v-icon> 员工信息管理
    </span>
    &nbsp;&nbsp;&nbsp;&nbsp;
    <v-btn light color="primary" @click="routerGo('/employeeManagement')">
      <v-icon>mdi-arrow-left</v-icon>返回员工管理
    </v-btn>
    <div class="zms-employeeitem">
      <Employeee-info />
    </div>
  </div>
</template>
<script>
import EmployeeeInfo from "../components/EmployeeComponents/EmployeeInfo.vue";
export default {
  name: "EmployeeeInfoManagement",
  components: {
    EmployeeeInfo,
  },
  created() {
    this.$store.dispatch("alterTopNavTitle", {
      title: this.$store.state.sPageName.employeeManagement_info,
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
.zms-employeeitem {
  margin-top: 20px;
}
</style>
