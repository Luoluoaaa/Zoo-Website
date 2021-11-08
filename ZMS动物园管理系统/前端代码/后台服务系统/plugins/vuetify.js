import Vue from "vue";
import Vuetify from "vuetify/lib/framework";
import zhHans from "vuetify/es5/locale/zh-Hans";
Vue.use(Vuetify);
//let x=Vue.component('VCard');
//x.options.props.ripple.default=false;
export default new Vuetify({
  lang: {
    locales: { zhHans },
    current: "zhHans",
  },
  theme: {
    default: "light",
    dark: false,
    themes: {
      light: {
        primary: "#1867C0",
        secondary: "#2196f3",
        accent: "#00bcd4",
        error: "#f44336",
        warning: "#ff5722",
        info: "#03a9f4",
        success: "#4caf50",
      },
      dark: {
        primary: "#2196F3",
        secondary: "#424242",
        accent: "#FF4081",
        error: "#FF5252",
        info: "#2196F3",
        success: "#4CAF50",
        warning: "#FB8C00",
      },
    },
  },
});
