<template>
  <div class="zms-home-notice">
    <alert-messagebox
      ref="error_done"
      :alert-title="`退出登录`"
      :alert-body="`是否退出 ZMS 动物园管理系统？`"
      :alert-level="`warning`"
      @alertConfirm="exitLogin"
    />
    <v-card
      :ripple="{ class: null }"
      elevation="10"
      class="zms-card-noborder"
      :class="cardNightClass"
    >
      <div class="zms-home-title2 zms-home-body2">
        <v-icon>mdi-account-circle</v-icon> {{ $t("home.accountOv") }}
      </div>
      <div class="zms-home-body">
        <v-container>
          <v-row>
            <v-col cols="3" style="padding-right: 10px">
              <v-avatar size="112" color="grey">
                <v-img
                  contain
                  :src="avatarImg"
                  aspect-ratio="16/9"
                  height="100px"
                  class="zms-img zms-img-demo"
                />
              </v-avatar>
            </v-col>
            <v-col cols="9">
              <b> {{ userNameX }} </b> {{ userIdX }} <br />
              {{ userPositionX }} <br />
              <br />
              <v-btn class="zms-fullwidth" color="error" @click="exitLoginCall">
                <v-icon>mdi-exit-to-app</v-icon>退出
              </v-btn>
            </v-col>
          </v-row>
        </v-container>
      </div>
    </v-card>
  </div>
</template>
<script>
import AlertMessagebox from "../CommonComponents/AlertMessagebox.vue";
export default {
  name: "HomepageAccountOverview",
  components: { AlertMessagebox },
  props: {
    drawer: Boolean,
  },
  data: () => {
    return {
      avatarImg: null,
      dialog_logout: false,
      userInfo: {
        userid: "---",
        name: "---",
        permission: "---",
      },
    };
  },
  computed: {
    userNameX() {
      return localStorage.getItem("zmsBKName");
    },
    userIdX() {
      return localStorage.getItem("zmsBKId");
    },
    userPositionX() {
      if (localStorage.getItem("zmsBKPosition") === "Admin") {
        return "系统管理员 (特权用户)";
      }
      return localStorage.getItem("zmsBKPosition") + " (普通用户)";
    },
    cardNightClass() {
      return {
        "zms-cardcolor-light": !this.$vuetify.theme.dark,
        "zms-cardcolor-dark": this.$vuetify.theme.dark,
      };
    },
  },
  created() {
    let urlTemp = this.$store.state.sAsset_WelcomeIcon;
    this.avatarImg = require("@/" + urlTemp);
  },
  methods: {
    exitLogin() {
      localStorage.setItem("zmsToken", "");
      localStorage.setItem("zmsBKId", "");
      this.$router.push("/Login");
    },
    exitLoginCall() {
      this.$refs.error_done.showAlert();
    },
    exitLoginEmit() {
      this.$emit("exitLogin");
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
.zms-img-demo {
  filter: brightness(19200%) saturate(0%);
}
</style>
