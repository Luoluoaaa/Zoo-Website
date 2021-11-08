<!---首页导航栏--->
<template>
<!---退出登录--->
  <div class="zms-appbar-ext">
    <alert-messagebox
      ref="error_done"
      :alert-title="`退出登录`"
      :alert-body="`是否退出 ZMS 动物园管理系统？`"
      :alert-level="`warning`"
      @alertConfirm="exitLogin"
    />
    <!---返回上一级--->
    <span class="zms-appbar-acc"> {{ userNameX }} ({{ userIdX }})</span>
    <v-tooltip bottom>
      <template v-slot:activator="{ on, attrs }">
        <v-btn
          class="zms-margin-rt"
          color="primary"
          text
          v-bind="attrs"
          v-on="on"
        >
          <v-icon color="white" class="float-right" @click="goBack">
            mdi-arrow-left
          </v-icon>
        </v-btn>
      </template>
      上一页
    </v-tooltip>
    <!---锁定功能--->
    <v-tooltip bottom>
      <template v-slot:activator="{ on, attrs }">
        <v-btn
          class="zms-margin-rt"
          color="primary"
          text
          v-bind="attrs"
          v-on="on"
        >
          <v-icon color="white" class="float-right" @click="switchLock">
            mdi-lock
          </v-icon>
        </v-btn>
      </template>
      锁定ZMS
    </v-tooltip>
    <!---退出系统--->
    <v-tooltip bottom>
      <template v-slot:activator="{ on, attrs }">
        <v-btn
          class="zms-margin-rt"
          color="primary"
          text
          v-bind="attrs"
          @click="exitLoginCall"
          v-on="on"
        >
          <v-icon color="white" class="float-right"> mdi-exit-to-app </v-icon>
        </v-btn>
      </template>
      退出ZMS
    </v-tooltip>
    <!--夜间模式--->
    <v-tooltip bottom>
      <template v-slot:activator="{ on, attrs }">
        <v-btn
          stclass="zms-margin-rt"
          color="primary"
          text
          v-bind="attrs"
          @click="switchNightMode"
          v-on="on"
        >
          <v-icon color="white" class="float-right"> mdi-weather-night </v-icon>
        </v-btn>
      </template>
      切换夜间模式
    </v-tooltip>
  </div>
</template>

<script>
import AlertMessagebox from "../CommonComponents/AlertMessagebox.vue";
export default {
  name: "AppbarExt",
  components: { AlertMessagebox },
  data() {
    return {
      //锁定定义
      locked: false,
    };
  },
  computed: {
    //锁定界面判断
    zmsLock() {
      return {
        "zms-hidden": this.locked == false,
      };
    },
    userNameX() {
      return localStorage.getItem("zmsBKName");
    },
    userIdX() {
      return localStorage.getItem("zmsBKId");
    },
  },
  methods: {
    //返回上一级
    goBack() {
      this.$router.back();
    },
    //退出登录
    exitLogin() {
      localStorage.setItem("zmsToken", "");
      localStorage.setItem("zmsBKId", "");
      this.$router.push("/Login");
    },
    exitLoginCall() {
      this.$refs.error_done.showAlert();
    },
    //黑夜模式
    switchNightMode() {
      this.$vuetify.theme.dark = !this.$vuetify.theme.dark;
      localStorage.setItem("zmsAppearance.darkMode", this.$vuetify.theme.dark);
    },
    //锁定界面
    switchLock() {
      this.$emit("lockPress");
    },
  },
};
</script>

<style scoped lang="scss">
.zms-hidden {
  display: none;
}
.zms-margin-rt {
  margin-right: 10px;
}
.zms-appbar-acc {
  font-weight: bold;
  color: #ffffff;
  margin-right: 15px;
}
.zms-lock-screen {
  position: fixed;
  left: 0px;
  right: 0px;
  top: 0px;
  bottom: 0px;
}
</style>
