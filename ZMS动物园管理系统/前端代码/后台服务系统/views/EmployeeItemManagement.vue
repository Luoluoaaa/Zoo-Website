<template>
  <div class="home">
    <span class="zms-view-title zms-primary-color">
      <v-icon color="primary">el-icon-s-custom</v-icon> 员工信息管理
    </span>
    &nbsp;&nbsp;&nbsp;&nbsp;
    <v-btn light color="primary" @click="routerGo('/EmployeeManagement')">
      <v-icon>mdi-arrow-left</v-icon>返回员工管理
    </v-btn>
    <div class="zms-employeeitem">
      <Employee-item-overview />
    </div>
  </div>
</template>
<script>
import EmployeeItemOverview from "../components/EmployeeComponents/EmployeeItemOverview.vue";
export default {
  name: "EmployeeItemManagement",
  components: {
    EmployeeItemOverview,
  },
  created() {
    this.$store.dispatch("alterTopNavTitle", {
      title: this.$store.state.sPageName.EmployeeItemManagement_item,
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
