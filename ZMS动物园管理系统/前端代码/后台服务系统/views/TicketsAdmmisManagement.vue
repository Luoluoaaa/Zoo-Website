<template>
  <div class="home">
    <span class="zms-admissticket-title zms-primary-color">
      <v-icon color="primary">el-icon-document-remove</v-icon>
      门票信息管理
    </span>
    &nbsp;&nbsp;&nbsp;&nbsp;
    <div class="zms-admissitem">
      <admiss-ticket-container />
    </div>
  </div>
</template>
<script>
import AdmissTicketContainer from "../components/AdmissionTicketComponents/AdmisTicketContainer.vue";
export default {
  name: "AdmissTicketManagement",
  components: {
    AdmissTicketContainer,
  },
  created() {
    this.$store.dispatch("alterTopNavTitle", {
      title: this.$store.state.sPageName.admissionTicketManagement,
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
.zms-admissitem {
  margin-top: 10px;
}
.zms-admissticket-title {
  font-size: 23px;
  font-weight: bold;
  letter-spacing: 1px;
}
</style>
