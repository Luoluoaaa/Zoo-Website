<template>
  <div class="zms-showticketinfo">
    <span class="zms-showticket-title zms-primary-color" color="primary">
      <v-icon color="primary">el-icon-tickets</v-icon> 演出票信息管理
    </span>
    <show-ticket-container />
  </div>
</template>
<script>
import ShowTicketContainer from "../components/ShowTicketComponents/ShowTicketContainer.vue";
export default {
  name: "ShowTicketManagement",
  components: {
    ShowTicketContainer,
  },
  created() {
    this.$store.dispatch("alterTopNavTitle", {
      title: this.$store.state.sPageName.showTicketManagement,
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
.zms-showticketinfo {
  margin-top: 10px;
}
.zms-showticket-title {
  font-size: 23px;
  font-weight: bold;
  letter-spacing: 1px;
}
</style>
