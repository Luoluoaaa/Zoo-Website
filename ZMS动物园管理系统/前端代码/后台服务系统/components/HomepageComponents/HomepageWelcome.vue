<template>
  <div class="zms-home-notice">
    <v-card
      :ripple="{ class: null }"
      elevation="10"
      class="zms-card-noborder"
      :class="cardNightClass"
      color="transparent"
    >
      <div :style="getBg" class="zms-home-welcome-wrapper" />
      <div :class="cardNightClassX" />
      <div class="zms-home-body">
        <div class="zms-home-centerx">
          <v-img
            contain
            :src="avatarImg"
            aspect-ratio="16/9"
            height="150px"
            width="150px"
            class="zms-img zms-imgx"
          />
        </div>
        <div class="zms-home-title">
          <span class="primary--text zms-sharp">#</span>
          {{ $t("home.greeting") }}
        </div>
        <div class="zms-home-description">
          {{ $t("home.greetinginf") }}
        </div>
      </div>
    </v-card>
  </div>
</template>
<script>
export default {
  name: "HomepageWelcome",
  components: {},
  props: {
    drawer: Boolean,
  },
  data: () => {
    return {
      avatarImg: null,
      welcomeBg: null,
    };
  },
  computed: {
    cardNightClass() {
      return {
        "zms-cardcolor-light": !this.$vuetify.theme.dark,
        "zms-cardcolor-dark": this.$vuetify.theme.dark,
      };
    },
    cardNightClassX() {
      return {
        "zms-home-welcome-wrapperx": !this.$vuetify.theme.dark,
        "zms-home-welcome-wrapperx-dark": this.$vuetify.theme.dark,
      };
    },
    getBg() {
      return {
        background: "url(" + this.welcomeBg + ")  no-repeat center center ",
        "background-size": "cover",
      };
    },
  },
  created() {
    let urlTemp = this.$store.state.sAsset_WelcomeIcon;
    this.avatarImg = require("@/" + urlTemp);
    let urlTemp2 = this.$store.state.sAsset_PageBackground2;
    this.welcomeBg = require("@/" + urlTemp2);
  },
  methods: {},
};
</script>
<style scoped lang="scss">
.zms-sharp {
  font-size: 30px;
}
.zms-img {
  filter: grayscale(100%) contrast(200%);
}
.zms-home-welcome-wrapper {
  z-index: 0;
  position: absolute;
  width: 100%;
  height: 100%;
}
.zms-home-welcome-wrapperx {
  z-index: 1;
  position: absolute;
  width: 100%;
  height: 100%;
  background-color: #ffffffcc;
}
.zms-home-welcome-wrapperx-dark {
  z-index: 1;
  position: absolute;
  width: 100%;
  height: 100%;
  background-color: #000000cc;
}
.zms-home-notice {
  margin: 0px 20px 0px 20px;
  padding-top: 10px;
  padding-bottom: 10px;
}
.zms-card-noborder {
  border-width: 0px;
  padding-top: 0px;
  height: 400px;
}
.zms-home-title {
  font-size: 25px;
  font-weight: bold;
  display: block;
}
.zms-home-body {
  padding-top: 20px;
  position: absolute;
  margin-left: 7%;
  margin-right: 7%;
  z-index: 32;
}
.zms-home-description {
  z-index: 32;
}
.zms-home-welcome {
  display: inline-block;
  vertical-align: top;
  margin-bottom: 20px;
  background: transparent;
}
/* Overriding Vuetify Img Style */
.v-image__image {
  background-position-x: 0 !important;
}
</style>
