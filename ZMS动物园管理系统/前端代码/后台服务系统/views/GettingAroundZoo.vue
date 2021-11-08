<template>
  <div class="zms-gettingAroundZooinfo">
    <span class="zms-gettingAroundZoo-title zms-primary-color" color="primary">
      <v-icon color="primary">el-icon-tickets</v-icon> 园内交通信息管理
    </span>
    <getting-around-zoo-container />
  </div>
</template>
<script>
import GettingAroundZooContainer from "../components/GettingAroundZooComponents/GettingAroundZooContainer.vue";
export default {
  name: "GettingAroundZooManagement",
  components: {
    GettingAroundZooContainer,
  },
  created() {
    this.$store.dispatch("alterTopNavTitle", {
      title: this.$store.state.sPageName.gettingAroundZoo,
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
.zms-gettingAroundZoo {
  margin-top: 10px;
}
.zms-gettingAroundZoo-title {
  font-size: 23px;
  font-weight: bold;
  letter-spacing: 1px;
}
</style>
