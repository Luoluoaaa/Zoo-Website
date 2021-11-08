<template>
  <div class="zms-home-notice">
    <v-card
      :ripple="{ class: null }"
      elevation="10"
      class="zms-card-noborder"
      :class="cardNightClass"
    >
      <div class="zms-home-title2 zms-home-body2">
        <v-icon>mdi-clock-check-outline</v-icon> {{ $t("home.wtTsk") }}
      </div>
      <div class="zms-home-body">
        <ec-line-chart />
      </div>
    </v-card>
  </div>
</template>
<script>
import EcLineChart from "../ChartComponents/EcLineChart.vue";
export default {
  name: "HomepageTaskOverview",
  components: { EcLineChart },
  props: {
    drawer: Boolean,
  },
  data: () => {
    return {
      currentTouristCnt: 0,
    };
  },
  computed: {
    cardNightClass() {
      return {
        "zms-cardcolor-light": !this.$vuetify.theme.dark,
        "zms-cardcolor-dark": this.$vuetify.theme.dark,
      };
    },
  },
};
</script>
<style scoped lang="scss">
.zms-home-notice {
  margin: 0px 20px 0px 20px;
  padding-top: 10px;
  padding-bottom: 10px;
}
.zms-home-center {
  text-align: center;
}
.zms-card-noborder {
  border-width: 0px;
}
.zms-home-title2 {
  font-size: 18px;
  font-weight: bold;
  display: block;
}
.zms-home-body2 {
  margin-left: 5%;
  margin-right: 5%;
  padding-top: 20px;
  padding-bottom: 10px;
}
</style>
