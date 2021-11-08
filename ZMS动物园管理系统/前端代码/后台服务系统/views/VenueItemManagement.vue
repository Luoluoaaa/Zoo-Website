<template>
  <div class="home">
    <span class="zms-view-title zms-primary-color">
      <v-icon color="primary">el-icon-s-home</v-icon> 场馆信息管理
    </span>
    &nbsp;&nbsp;&nbsp;&nbsp;
    <v-btn
      light
      color="primary"
      @click="routerGo('/venue/AnimalExhibitionManagement')"
    >
      <v-icon>mdi-arrow-left</v-icon>返回场馆管理
    </v-btn>
    <div class="zms-venueitem">
      <Venue-item-overview />
    </div>
  </div>
</template>
<script>
import VenueItemOverview from "../components/VenueComponents/VenuesItemOverview.vue";
export default {
  name: "VenueItemManagement",
  components: {
    VenueItemOverview,
  },
  created() {
    this.$store.dispatch("alterTopNavTitle", {
      title: this.$store.state.sPageName.venueManagement,
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
.zms-venueitemoverview {
  margin-top: 20px;
}
</style>
