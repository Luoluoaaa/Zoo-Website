<template>
  <div class="home">
    <span class="zms-view-title zms-primary-color">
      <v-icon color="primary">el-icon-s-home</v-icon> 场馆管理
    </span>
    &nbsp;&nbsp;&nbsp;&nbsp;
    <v-btn light color="primary" @click="routerGo('/')">
      <v-icon>mdi-arrow-left</v-icon>返回主页
    </v-btn>
    <div class="zms-venueinfo">
      <Venue-info />
    </div>
  </div>
</template>
<script>
import VenueInfo from "../components/VenueComponents/venueInfo.vue";
export default {
  name: "VenueInfoManagement",
  components: {
    VenueInfo,
  },
  created() {
    this.$store.dispatch("alterTopNavTitle", {
      title: this.$store.state.sPageName.VenueExhiManagement_info,
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
.zms-venueinfo {
  margin-top: 20px;
}
</style>
