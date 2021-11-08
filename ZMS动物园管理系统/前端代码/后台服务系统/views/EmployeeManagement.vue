<template>
  <div class="home">
    <span class="zms-view-title zms-primary-color">
      <v-icon color="primary">el-icon-user-solid</v-icon> 员工管理
    </span>
    <Employee-container />
  </div>
</template>
<script>
import EmployeeContainer from "../components/EmployeeComponents/EmployeeContainer.vue";
export default {
  name: "EmployeeManagement",
  components: {
    EmployeeContainer,
  },
  created() {
    this.$store.dispatch("alterTopNavTitle", {
      title: this.$store.state.sPageName.employeeManagement,
    });
  },
};
</script>
<style scoped lang="scss"></style>
