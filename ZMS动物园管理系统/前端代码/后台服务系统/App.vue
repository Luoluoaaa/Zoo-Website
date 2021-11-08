<template>
  <v-app>
    <v-fab-transition>
      <div v-if="showLoadingComponent" class="wrap">
        <dynamic-title />
      </div>
    </v-fab-transition>
    <v-navigation-drawer
      v-model="drawer"
      :class="rejectMouse"
      absolute
      temporary
      app
      style="width: 350px"
    >
      <navigator :lock="locked" />
    </v-navigation-drawer>
    <v-app-bar
      v-if="showTopNavbar"
      app
      color="primary"
      transition="slide-x-transition"
    >
      <v-app-bar-nav-icon color="white" @click="switchDrawer" />
      <vue-typing
        :text="$t(getAppbarTitle)"
        :rewrite="true"
        class="zms-wider-letterspacing zms-app-barx"
        :class="getAppbarStyleClass"
        :framerate="2"
        :cursor-options="zmsVueTypingCursor"
      />
      <appbar-ext class="zms-right" @lockPress="switchLock()" />
    </v-app-bar>
    <v-main>
      <div class="wrap" :class="zmsLock">
        <disintegrate-button
          ref="disint_btn"
          class="zms-lock-screen"
          @disbtn_complete_all="unlockLockBtn"
          @disbtn_complete="switchLock2"
        />
      </div>
      <v-container fluid>
        <embedded-frame
          v-if="this.$store.state.bUseL2D"
          path="/live2d-gadget.html"
        />
        <page-container />
      </v-container>
    </v-main>
  </v-app>
</template>
<script>
import AppbarExt from "./components/AppBar/AppbarExt.vue";
import EmbeddedFrame from "./components/Gadgets/EmbeddedFrame.vue";
import Navigator from "./components/Navigatior/Navigator.vue";
import PageContainer from "./components/PageContainer.vue";
import DisintegrateButton from "./components/Gadgets/DisintegrateButton.vue";
import DynamicTitle from "./components/Gadgets/DynamicTitle.vue";
import VueTyping from "vue-typing";
export default {
  name: "App",
  components: {
    Navigator,
    AppbarExt,
    PageContainer,
    EmbeddedFrame,
    DynamicTitle,
    DisintegrateButton,
    VueTyping,
  },
  EmbeddedFrame,
  data: () => {
    return {
      drawer: false,
      allowL2D: true,
      locked: false,
      lockStatus: false,
      showLoadingComponent: true,
      zmsVueTypingCursor: {
        blinking: true,
        cursor: "|",
        color: "black",
        framerate: 5,
      },
    };
  },
  computed: {
    rejectMouse() {
      return {
        "zms-reject-mouse": this.locked,
      };
    },
    zmsLock() {
      return {
        "zms-hidden": this.locked == false,
      };
    },
    getAppbarTitle() {
      return this.$store.state.sTopBarTitle;
    },
    getAppbarStyleClass() {
      return {
        "zms-white": true,
      };
    },
    showTopNavbar() {
      if (this.$route.path.toLowerCase() != "/login") {
        return true;
      }
      return false;
    },
  },
  created() {
    //Apply Dark Mode
    let darkMode = localStorage.getItem("zmsAppearance.darkMode");
    if (isNaN(darkMode) || darkMode == "" || darkMode === "false") {
      this.$vuetify.theme.dark = false;
    }
    if (darkMode === "true") {
      this.$vuetify.theme.dark = true;
    }
    //Default Lang Setting
    let defLang = localStorage.getItem("zmsAppearance.lang");
    if (!isNaN(defLang) && defLang != "" && !isNaN(parseInt(defLang))) {
      this.$store.state.defaultLang = parseInt(defLang);

      if (
        Object.prototype.hasOwnProperty.call(
          this.$store.state.langOpts[this.$store.state.defaultLang],
          "cd"
        )
      ) {
        this.$i18n.locale =
          this.$store.state.langOpts[this.$store.state.defaultLang].cd;
      } else {
        this.$i18n.locale = "zh-CN";
      }
    }
    //Hide Loading Wrapper
    if (localStorage.getItem("zmsSkipAniT") === "1") {
      this.showLoadingComponent = false;
      localStorage.setItem("zmsSkipAniT", "0");
    } else {
      setTimeout(() => {
        this.showLoadingComponent = false;
      }, 2000);
    }
    //Lock
  },
  mounted() {
    //getList();
    this.$nextTick(() => {
      setTimeout(() => {
        if (localStorage.getItem("zmsToken2") === "1") {
          this.switchLock();
        }
      }, 500);
    });
  },
  methods: {
    switchDrawer() {
      if (this.locked) {
        return 0;
      }
      this.drawer = !this.drawer;
    },
    switchLock() {
      if (this.lockStatus) {
        return;
      }
      localStorage.setItem("zmsToken2", "1");
      this.lockStatus = true;
      if (this.locked === false) {
        this.locked = !this.locked;
        this.$refs.disint_btn.switchState();
      } else {
        this.$refs.disint_btn.switchState();
      }
    },
    switchLock2() {
      this.locked = !this.locked;
    },
    unlockLockBtn() {
      //this.lockStatus=false;
    },
  },
};
</script>
<style scoped lang="scss">
$body-font-family: "PTSans", "HanSans";
.v-application {
  font-family: $body-font-family, sans-serif !important;
}
.zms-right {
  position: fixed;
  right: 20px;
}
.zms-hidden {
  display: none;
}
.wrap {
  position: absolute;
  bottom: 0px;
  top: 0px;
  left: 0px;
  right: 0px;
  z-index: 99999999;
  overflow: hidden;
}
#app {
  user-select: none;
}
.zms-app-barx {
  font-size: 21px;
}
</style>
