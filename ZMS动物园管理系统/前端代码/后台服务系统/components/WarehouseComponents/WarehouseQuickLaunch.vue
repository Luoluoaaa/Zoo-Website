<template>
  <div class="zms-home-notice">
    <v-card
      :ripple="{ class: null }"
      elevation="10"
      :class="cardNightClass"
      style="zms-transparent-bg"
      class="zms-card-noborder"
    >
      <div class="zms-home-title2 zms-home-body2">
        <v-icon>mdi-star-shooting</v-icon> 快速导航
      </div>
      <div class="zms-home-body">
        <v-container fluid class="fill-height justify-center">
          <v-row align="center" class="mx-0">
            <v-col cols="12" md="3" class="align-self-stretch">
              <homepage-quick-launch-button
                icon="mdi-database-edit"
                title="进出仓管理"
                info="记录物品出仓与入库"
                zmsroute="/warehouseManagement/flowManagement"
              />
            </v-col>
            <v-col cols="12" md="3" class="align-self-stretch">
              <homepage-quick-launch-button
                icon="mdi-warehouse"
                title="仓库信息"
                info="查看所有仓库的信息"
                zmsroute="/warehouseManagement/infoManagement"
              />
            </v-col>
            <v-col cols="12" md="3" class="align-self-stretch">
              <homepage-quick-launch-button
                icon="mdi-cube"
                title="货物管理"
                info="查看当前所有物品"
                zmsroute="/warehouseManagement/itemManagement"
              />
            </v-col>
            <v-col cols="12" md="3" class="align-self-stretch">
              <homepage-quick-launch-button
                icon="mdi-cart"
                title="采购管理"
                info="处理采购信息"
                zmsroute="/procurementManagement"
              />
            </v-col>
          </v-row>
        </v-container>
      </div>
    </v-card>
  </div>
</template>
<script>
import HomepageQuickLaunchButton from "../HomepageComponents/HomepageQuickLaunchButton.vue";
export default {
  name: "WarehouseQuickLaunch",
  components: { HomepageQuickLaunchButton },
  props: {
    drawer: Boolean,
  },
  computed: {
    cardNightClass() {
      return {
        "zms-cardcolor-light": !this.$vuetify.theme.dark,
        "zms-cardcolor-dark": this.$vuetify.theme.dark,
      };
    },
  },
  methods: {
    routerGo(x) {
      this.$router.push(x);
    },
  },
};
</script>
<style scoped lang="scss">
.zms-home-ql {
  cursor: pointer;
}
.zms-ql-title-text-sub {
  margin-top: 10px;
}
.zms-ql-title-text {
  font-size: 20px;
  font-weight: bold;
  margin-top: 20px;
  display: block;
}
.zms-ql-title {
  padding-top: 20px;
  padding-bottom: 20px;
  text-align: center;
}
.zms-ql-icon-xl {
  transform: scaleX(150%) scaleY(150%);
}
.zms-ql-icon {
  text-align: center;
}
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
.zms-home-body {
  margin-left: 7%;
  margin-right: 7%;
  padding-top: 10px;
  padding-bottom: 10px;
}
.zms-home-body2 {
  margin-left: 5%;
  margin-right: 5%;
  padding-top: 20px;
  padding-bottom: 10px;
}
</style>
