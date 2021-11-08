<template>
  <div>
    <div class="demo-1">
      <div class="content">
        <div class="slideshow" v-html="wordHtml" />
        <div class="slideshow_append">
          {{ $t("gadget.loading") }}
        </div>
      </div>
    </div>
  </div>
</template>
<script>
import Word, { WorkEffect } from "@/utils/wordfx.js";
export default {
  props: {},
  data: () => ({
    logoSrc: "",
    captchaSrc: "",
    text: "ZMS System",
    model: {
      loginId: "",
      mode: "password",
      password: "",
      captcha: "",
    },
    birds: {
      color1: "#000000",
      color2: "#271e1e",
      quantity: 4,
      canvasBgAlpha: 0,
      wingsSpan: 20,
      colorEffect: 2,
    },
    wordHtml: ``,
  }),
  mounted() {
    window.addEventListener("resize", this.handleResize);
    const workHtml = (
      index
    ) => ` <div class="slide slide--current" style="width:100%">
    <div class="slide__bg slide__bg--${index}" > </div>
        <h2 id="word" style="color:#fff" class="word word--${index}">${this.text}</h2>
    </div>`;
    let word;
    const vm = this;
    let index = 0;
    const showWordEffect = () => {
      vm.wordHtml = workHtml(index);
      vm.$nextTick(() => {
        word = new Word(document.getElementById("word"), WorkEffect[index]);
        word.show().then(() => {
          index = 0;
          setTimeout(function () {
            vm.wordHtml = "";
            vm.$nextTick(() => {
              showWordEffect();
            });
          }, 5000);
        });
      });
    };
    showWordEffect();
  },
  beforeDestroy() {
    window.removeEventListener("resize", this.handleResize);
  },
  methods: {
    handleResize() {
      this.$root.$emit("resized");
    },
  },
};
</script>
<style scoped lang="stylus">
.content
  background-color: #f6f7ff;
.login-form
  position: absolute;
  width: 100vw;
  height: 100vh;
  top: 35%;
  right: 0;
  display: flex;
  align-content: center;
  justify-content: center;
/* W3C, IE 10+/ Edge, Firefox 16+, Chrome 26+, Opera 12+, Safari 7+ */
.color-white
  background-color #fff
.captcha
  cursor pointer
  z-index 999
  position relative
  top -8px
.submit-btn
  background #536976; /* fallback for old browsers */
  background -webkit-linear-gradient(to right, #292E49, #536976); /* Chrome 10-25, Safari 5.1-6 */
  background linear-gradient(to right, #292E49, #536976);
/* W3C, IE 10+/ Edge, Firefox 16+, Chrome 26+, Opera 12+, Safari 7+ */
.bg-white
  background-color: rgba(255, 255, 255, 0.6) !important
input::-webkit-input-placeholder
  color rgba(255, 255, 255, 0.1) !important
.login-block
  width 80%
.logo-mount:before {
  content: '';
  position: absolute;
  z-index: 2;
  left: 45%;
  width: 50px;
  height: 50px;
  background-size: 100% 100%;
  border-radius: 2px;
  -webkit-animation: box .8s infinite;
}
.logo-mount:after {
  content: '';
  position: absolute;
  z-index: 1;
  top: -11px;
  width: 44px;
  height: 3px;
  background: #eaeaea;
  border-radius: 100%;
  -webkit-animation: shadow .8s infinite;
}
//底部阴影动效
@-webkit-keyframes shadow {
  0%, 100% {
    left: 46%;
    width: 40px;
    background: #eaeaea;
  }
  50% {
    top: -9px;
    left: 45%;
    width: 50px;
    height: 7px;
    background: #eee;
  }
}
//box跳动+旋转效果
@-webkit-keyframes box {
  0% {
    top: -86px;
  }
  20% {
    border-radius: 2px;
  }
  50% {
    top: -57px;
    border-bottom-right-radius: 25px;
  }
  80% {
    border-radius: 2px;
  }
  100% {
    top: -86px;
  }
}
</style>
