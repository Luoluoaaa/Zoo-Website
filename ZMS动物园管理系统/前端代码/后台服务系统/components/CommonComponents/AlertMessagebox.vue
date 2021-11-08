<template>
  <v-dialog v-model="zmsShowAlert" persistent :width="alertWidth" class="zmsAM">
    <v-card color="" :ripple="{ class: null }">
      <v-card-title
        class="zms-strip-bg text-h5 text--white darken-3"
        :class="headBannerClass"
        color="warning"
      >
        <v-icon color="white"> {{ alertIcon }} </v-icon>&nbsp;
        <span class="text--white" style="color: #ffffff !important">
          {{ alertTitle }}
        </span>
      </v-card-title>
      <v-divider />
      <br />
      <v-card-text>
        <span
          v-if="alertMode == 'traditional'"
          class="zms-poptip-body"
          :class="txNightClass"
        >
          <div v-if="this.alertLevel === 'success'" class="zms-swal2">
            <div
              class="swal2-icon swal2-success swal2-icon-show"
              style="display: flex"
            >
              <div
                class="swal2-success-circular-line-left"
                :style="swalNightStyle"
              />
              <span class="swal2-success-line-tip" />
              <span class="swal2-success-line-long" />
              <div class="swal2-success-ring" />
              <div class="swal2-success-fix" :style="swalNightStyle" />
              <div
                class="swal2-success-circular-line-right"
                :style="swalNightStyle"
              />
            </div>
          </div>
          <div v-if="this.alertLevel === 'error'" class="zms-swal2">
            <div
              class="swal2-icon swal2-error swal2-icon-show"
              style="display: flex"
            >
              <span class="swal2-x-mark">
                <span class="swal2-x-mark-line-left" />
                <span class="swal2-x-mark-line-right" />
              </span>
            </div>
          </div>
          <div v-if="this.alertLevel === 'warning'" class="zms-swal2">
            <div
              class="swal2-icon swal2-warning swal2-icon-show"
              style="display: flex"
            >
              <div class="swal2-icon-content">!</div>
            </div>
          </div>
          <div v-if="this.alertLevel === 'info'" class="zms-swal2">
            <div
              class="swal2-icon swal2-info swal2-icon-show"
              style="display: flex"
            >
              <div class="swal2-icon-content">i</div>
            </div>
          </div>
          <!--图标结束-->
          {{ zmsAlertBody }}
        </span>
        <span v-else class="" :class="txNightClass">
          <slot name="body" />
        </span>
        <br />
        <br />
      </v-card-text>
      <v-divider />
      <v-card-actions>
        <v-spacer />
        <v-btn
          v-if="!alertCustomizeToolbox && !alertOnlyConfirm"
          class="zms-fullwidth"
          light
          color="error"
          @click="clickCancel"
        >
          <v-icon>mdi-arrow-left</v-icon> {{ $t("common.cancel") }}
        </v-btn>
        <v-btn
          v-if="!alertCustomizeToolbox"
          class="zms-fullwidth"
          light
          color="success"
          @click="clickConfirm"
        >
          <v-icon>mdi-exclamation</v-icon> {{ $t("common.confirm") }}
        </v-btn>
        <slot v-if="alertCustomizeToolbox" name="toolbar" />
      </v-card-actions>
    </v-card>
  </v-dialog>
</template>
<script>
export default {
  name: "AlertMessagebox",
  props: {
    alertTitle: String,
    alertBody: String,
    alertLevel: String,
    alertModel: Object,
    alertMode: {
      type: String,
      default: () => "traditional",
    },
    alertIcon: {
      type: String,
      default: () => "mdi-alert",
    },
    alertCustomizeToolbox: {
      type: Boolean,
      default: () => false,
    },
    alertWidth: {
      type: String,
      default: () => "600",
    },
    alertOnlyConfirm: {
      type: Boolean,
      default: () => false,
    },
  },
  data() {
    return {
      zmsShowAlert: false,
      zmsAlertBody: "",
    };
  },
  computed: {
    headBannerClass() {
      return {
        red: this.alertLevel === "error",
        orange: this.alertLevel === "warning",
        blue: this.alertLevel === "info",
        green: this.alertLevel === "success",
      };
    },
    nmNightClass() {
      return {
        "zms-background-nm-dark": this.$vuetify.theme.dark,
      };
    },
    txNightClass() {
      return {
        "zms-text-dark": this.$vuetify.theme.dark,
      };
    },
    swalNightClass() {
      return {
        "zms-swal-correct-light": !this.$vuetify.theme.dark,
        "zms-swal-correct-dark": this.$vuetify.theme.dark,
      };
    },
    swalNightStyle() {
      if (!this.$vuetify.theme.dark) {
        return {
          "background-color": "rgb(255,255,255)",
        };
      } else {
        return {
          "background-color": "rgb(30,30,30)",
        };
      }
    },
  },
  created() {
    this.zmsAlertBody = this.alertBody;
  },
  methods: {
    clickConfirm() {
      this.zmsShowAlert = false;
      this.$emit("alertConfirm");
    },
    clickCancel() {
      this.zmsShowAlert = false;
      this.$emit("alertCancel");
    },
    showAlert() {
      this.zmsShowAlert = true;
    },
    updateBody(x) {
      this.zmsAlertBody = x;
    },
  },
};
</script>
<style scoped>
.zms-swal-correct-dark {
  background-color: #1e1e1e00;
}
.zms-swal-correct-light {
  background-color: #ffffff;
}
.zmsAM {
  z-index: 9999999999999999999;
}
</style>
