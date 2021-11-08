<template>
  <div class="zms-wrapper" :style="slidebarStyle">
    <div class="zms-wrapper-inside">
      <transition name="slide-fade" mode="out-in">
        <router-view :key="$route.fullpath" />
      </transition>
    </div>
    <div class="zms-wrapper-background" :style="getBg" />
    <div :class="getWrapClass">
      <vue-particles
        color="#dedede"
        :particle-opacity="0.7"
        :particles-number="50"
        shape-type="star"
        :particle-size="4"
        lines-color="#777777"
        :lines-width="1"
        :line-linked="true"
        :line-opacity="0.5"
        :lines-distance="150"
        :move-speed="1"
        :hover-effect="true"
        hover-mode="grab"
        :click-effect="true"
        click-mode="push"
      />
    </div>
  </div>
</template>
<script>
export default {
  name: "PageContainer",
  components: {},
  data: () => {
    return {
      HeadImg: null,
    };
  },
  computed: {
    slidebarStyle() {
      return {
        //left:this.$store.state.sSlideBarLeft+'px',
        left: "0px",
      };
    },
    getProjectName() {
      return this.$store.state.sProjectName;
    },
    getBg() {
      return {
        background: "url(" + this.HeadImg + ")  no-repeat bottom right ",
        "background-size": "cover",
      };
    },
    getWrapClass() {
      return {
        "zms-wrapper-background-sec": !this.$vuetify.theme.dark,
        "zms-wrapper-background-sec-dark": this.$vuetify.theme.dark,
      };
    },
  },
  created() {
    let urlTemp = this.$store.state.sAsset_PageBackground;
    this.HeadImg = require("@/" + urlTemp);
  },
};
</script>
<style scoped lang="scss">
.zms-anim-shorter-delays {
  --animate-delay: 0.5s;
}
.zms-wrapper {
  z-index: 2;
  position: fixed;
  right: 0px;
  bottom: 0px;
  top: 55px;
  transition: all 0.5s;
  text-align: left;
  padding-left: 50px;
  padding-right: 50px;
  padding-top: 30px;
  background-color: #f0f0f0;
  overflow-y: scroll;
}
.zms-wrapper-background {
  z-index: -2;
  position: fixed;
  left: 0px;
  right: 0px;
  top: 0px;
  bottom: 0px;
  background-size: cover;
  height: 100%;
  width: 100%;
  background-position: bottom right;
}
.zms-wrapper-background-sec {
  z-index: -1;
  position: fixed;
  left: 0px;
  right: 0px;
  top: 0px;
  bottom: 0px;
  background-image: linear-gradient(0deg, #f0f0f09f, #f0f0f0, 90%, #f0f0f0);
  height: 100%;
  transition: background-image 1s;
  width: 100%;
}
.zms-wrapper-background-sec-dark {
  z-index: -1;
  position: fixed;
  left: 0px;
  right: 0px;
  top: 0px;
  bottom: 0px;
  background-image: linear-gradient(0deg, #2020209f, #202020, 90%, #202020);
  transition: background-image 1s;
  height: 100%;
  width: 100%;
}
</style>
