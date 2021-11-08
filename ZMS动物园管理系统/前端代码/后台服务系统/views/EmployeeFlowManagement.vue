<template>
  <div class="home">
    <span class="zms-view-title zms-primary-color">
      <v-icon color="primary">el-icon-upload2</v-icon> 员工信息录入
    </span>
    &nbsp;&nbsp;&nbsp;&nbsp;
    <v-btn light color="primary" @click="routerGo('/employeeManagement')">
      <v-icon>mdi-arrow-left</v-icon>返回员工管理
    </v-btn>
    <div class="zms-Employeeeitem">
      <employee-flow />
    </div>
  </div>
</template>
<script>
import EmployeeFlow from "../components/EmployeeComponents/EmployeeFlow.vue";
export default {
  name: "EmployeeeFlowManagement",
  components: {
    EmployeeFlow,
  },
  created() {
    this.$store.dispatch("alterTopNavTitle", {
      title: this.$store.state.sPageName.employeeManagement_flowRecord,
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
