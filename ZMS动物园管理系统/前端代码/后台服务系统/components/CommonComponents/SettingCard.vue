<!---设置部分--->
<template>
  <div class="zms-setting-card">
    <!--清除缓存提示-->
    <alert-messagebox
      ref="clr_ls_msgbox"
      :alert-body="$t('setting2.clearDataMsg')"
      :alert-title="$t('setting2.clearDataMsgTitle')"
      :alert-level="`warning`"
      @alertConfirm="clearLocalStorage"
    />
    <v-container>
      <!---设置模型--->
      <v-row>
        <v-subheader> {{ $t("settings.modelSetting") }}</v-subheader>
      </v-row>
      <v-row>
        <v-switch
          v-model="l2dStat"
          inset
          :label="$t('settings.useL2d')"
          @click="setL2DStat"
        />
      </v-row>
      <!---设置语言--->
      <v-row>
        <v-subheader> {{ $t("settings.langSetting") }}</v-subheader>
      </v-row>
      <v-row>
        <v-select
          v-model="langRet"
          :items="this.$store.state.langOpts"
          item-text="sw"
          item-value="cd"
          filled
          return-object
          @change="langChange"
        />
      </v-row>
      <!---保留偏好设置--->
      <v-row>
        <v-subheader> {{ $t("setting2.privacySetting") }}</v-subheader>
      </v-row>
      <v-row>
        <v-col>
          {{ $t("setting2.lsClearDescription") }}
        </v-col>
        <v-col>
          <v-btn
            block
            class="zms-strip-bg-slim"
            v-bind="attrs"
            color="error"
            v-on="on"
            @click="calloutClearLsMsg"
          >
            <v-icon>mdi-delete</v-icon> {{ $t("setting2.clearData") }}
          </v-btn>
        </v-col>
      </v-row>
    </v-container>
  </div>
</template>
<script>
import AlertMessagebox from "./AlertMessagebox.vue";
export default {
  name: "SettingCard",
  components: { AlertMessagebox },
  props: {
    drawer: Boolean,
  },
  data() {
    return {
      l2dSwitch: false,
      l2dStat: false,
      langRet: null,
    };
  },
  computed: {},
  created() {
    this.getL2DStat();
    this.langRet = this.$store.state.langOpts[this.$store.state.defaultLang];
  },
  methods: {
    setL2DStat() {
      this.$store.state.bUseL2D = !this.$store.state.bUseL2D;
      this.getL2DStat();
    },
    getL2DStat() {
      this.l2dStat = this.$store.state.bUseL2D;
      return this.$store.state.bUseL2D;
    },
    langChange() {
      this.$i18n.locale = this.langRet.cd;

      localStorage.setItem("zmsAppearance.lang", this.langRet.id);
    },
    calloutClearLsMsg() {
      this.$refs.clr_ls_msgbox.showAlert();
    },
    clearLocalStorage() {
      localStorage.clear();
      this.$store.dispatch("showToastNotify", {
        type: "success",
        info: this.$t("setting2.lsCleared"),
      });
    },
  },
};
</script>
<style scoped lang="scss">
.zms-setting-card {
  margin-top: 10px;
  display: block;
  //color:#222222;
  font-size: 16px;
}
</style>
