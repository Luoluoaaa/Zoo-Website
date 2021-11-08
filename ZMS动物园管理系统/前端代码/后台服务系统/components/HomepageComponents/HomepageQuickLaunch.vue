<template>
  <div class="zms-home-notice">
    <v-card
      :ripple="{ class: null }"
      elevation="10"
      class="zms-card-noborder"
      :class="cardNightClass"
    >
      <div class="zms-home-title2 zms-home-body2">
        <v-icon>mdi-star-shooting</v-icon> {{ $t("home.ql") }}
      </div>
      <div class="zms-home-body">
        <v-container fluid class="fill-height justify-center">
          <v-row align="center" class="mx-0">
            <v-col cols="12" md="6" class="align-self-stretch">
              <homepage-quick-launch-button
                icon="mdi-cat"
                zmsroute="/animalInfoManagement"
                title="动物管理"
                info="查看动物信息状况"
              />
            </v-col>
            <v-col cols="12" md="6" class="align-self-stretch">
              <homepage-quick-launch-button
                icon="mdi-account-edit"
                zmsroute="/employeeManagement/check"
                title="工作考核"
                info="检查工作考核安排"
              />
            </v-col>
            <v-col cols="12" md="6" class="align-self-stretch">
              <homepage-quick-launch-button
                icon="mdi-home"
                zmsroute="/venue/AnimalExhibitionManagement"
                title="场馆信息"
                info="检查当前的场馆信息状况"
              />
            </v-col>
            <v-col cols="12" md="6" class="align-self-stretch">
              <homepage-quick-launch-button
                icon="mdi-comment-quote"
                zmsroute="/fundManagement"
                title="资金分析"
                info="分析资金流动趋势"
              />
            </v-col>
          </v-row>
        </v-container>
      </div>
    </v-card>
  </div>
</template>
<script>
import HomepageQuickLaunchButton from "./HomepageQuickLaunchButton.vue";
export default {
  name: "HomepageQuickLaunch",
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
    goto() {},
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
