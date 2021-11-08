<template>
  <div class="zms-aniShow" :class="nmNightClass">
    <div class="zms-query-filter">
      <!-- 提交进度条 -->
      <v-dialog v-model="submitStat" persistent width="300">
        <v-card>
          <v-card-title>
            {{ $t("vehicleManagement.Submitting") }}
          </v-card-title>
          <v-divider />
          <br />
          <v-card-text>
            {{ $t("vehicleManagement.PleaseWait") }} <br />
            <br />
            <v-progress-linear
              indeterminate
              striped
              color="primary"
              class="mb-0"
            />
          </v-card-text>
        </v-card>
      </v-dialog>
      <!-- 不写备注 -->
      <v-dialog v-model="noNoteWarning" persistent width="500">
        <v-card color="" :ripple="{ class: null }">
          <v-card-title
            class="zms-strip-bg text-h5 text--white orange darken-3"
            color="warning"
          >
            <v-icon color="white"> mdi-alert </v-icon>&nbsp;<span
              class="text--white"
              style="color: #ffffff !important"
            >
              {{ $t("vehicleManagement.NoNoteTitle") }}
            </span>
          </v-card-title>
          <v-divider />
          <br />
          <v-card-text>
            <span class="zms-poptip-body" :class="txNightClass">
              {{ $t("vehicleManagement.NoNoteInfo") }}
            </span>
            <br />
            <br />
          </v-card-text>
          <v-divider />
          <v-card-actions>
            <v-spacer />
            <v-btn
              class="zms-fullwidth"
              v-bind="attrs"
              light
              color="primary"
              v-on="on"
              @click="
                noNoteWarning = false;
                submitVehicleManagement();
              "
            >
              <v-icon>mdi-exclamation</v-icon> {{ $t("common.confirm") }}
            </v-btn>
            <v-btn
              class="zms-fullwidth"
              v-bind="attrs"
              light
              color="error"
              v-on="on"
              @click="noNoteWarning = false"
            >
              <v-icon>mdi-arrow-left</v-icon> {{ $t("common.cancel") }}
            </v-btn>
          </v-card-actions>
        </v-card>
      </v-dialog>
      <!-- 提交错误 -->
      <v-dialog v-model="errorReturn" persistent width="500">
        <v-card color="" :ripple="{ class: null }">
          <v-card-title
            class="zms-strip-bg text-h5 text--white red"
            color="warning"
          >
            <v-icon color="white"> mdi-close-thick </v-icon>&nbsp;<span
              class="text--white"
              style="color: #ffffff !important"
            >
              {{ errorTitle }}
            </span>
          </v-card-title>
          <v-divider />
          <br />
          <v-card-text>
            <span class="zms-poptip-body" :class="txNightClass">
              {{ errorInfo }}
            </span>
            <br />
            <br />
          </v-card-text>
          <v-divider />
          <v-card-actions>
            <v-spacer />
            <v-btn
              class="zms-fullwidth"
              v-bind="attrs"
              light
              color="primary"
              v-on="on"
              @click="errorReturn = false"
            >
              <v-icon>mdi-exclamation</v-icon> {{ $t("common.confirm") }}
            </v-btn>
          </v-card-actions>
        </v-card>
      </v-dialog>
      <v-icon color="primary"> mdi-filter-plus </v-icon>
      <span class="zms-query-title"> {{ $t("vehicleManagement.title") }} </span>
      <div>
        <v-container>
          <v-row>
            <v-col class="d-flex" cols="12" sm="6" md="3">
              <v-select
                v-model="submit_vehicle_category"
                :items="admissitems"
                :label="$t('vehicleManagement.vehicle_category')"
                prepend-icon="el-icon-view"
              />
            </v-col>
            <v-col cols="12" sm="6" md="3">
              <v-text-field
                v-model="submit_departure_interval"
                :label="$t('vehicleManagement.departure_interval')"
                :placeholder="
                  $t('common.pleaseInput') +
                  $t('vehicleManagement.departure_interval')
                "
                prepend-icon="el-icon-link"
              />
            </v-col>
            <v-col cols="12" sm="6" md="3">
              <v-text-field
                v-model="submit_trans_duration"
                :label="$t('vehicleManagement.trans_duration')"
                :placeholder="
                  $t('common.pleaseInput') +
                  $t('vehicleManagement.trans_duration')
                "
                prepend-icon="el-icon-time"
              />
            </v-col>
            <v-col cols="12" sm="6" md="3">
              <v-text-field
                v-model="submit_price"
                :label="$t('vehicleManagement.price')"
                :placeholder="
                  $t('common.pleaseInput') + $t('vehicleManagement.price')
                "
                prepend-icon="el-icon-s-opportunity"
              />
            </v-col>
            <v-col cols="12" sm="6" md="3">
              <v-text-field
                v-model="submit_boarding_location"
                :label="$t('vehicleManagement.boarding_location')"
                :placeholder="
                  $t('common.pleaseInput') +
                  $t('vehicleManagement.boarding_location')
                "
                prepend-icon="el-icon-position"
              />
            </v-col>
          </v-row>
        </v-container>
        <v-container>
          <v-row>
            <v-col cols="12" sm="6" md="3" />
            <v-col cols="12" sm="6" md="3" />
            <v-col cols="12" sm="6" md="3" />
            <v-col cols="12" sm="6" md="3">
              <v-btn
                :disabled="submitStat"
                block
                class="zms-width"
                color="primary"
                @click="submitPrejudge()"
              >
                <v-icon>mdi-arrow-collapse-up</v-icon>&nbsp;&nbsp;{{
                  $t("common.report")
                }}
              </v-btn>
            </v-col>
          </v-row>
        </v-container>
      </div>
    </div>
  </div>
</template>
<script>
import { createVehicleManagementInfo } from "../../apis/vehicleManagement";
export default {
  name: "VehicleManagementCreates",
  data: () => {
    return {
      submit_ID: null,
      submit_vehicle_category: null,
      submit_departure_interval: null,
      submit_trans_duration: null,
      submit_price: null,
      submit_boarding_location: null,
      submitNote: null,
      submitStat: false,
      noNoteWarning: false,
      errorReturn: false,
      errorTitle: "",
      errorInfo: "",
      menu2: false,
      admissitems: ["高铁", "地铁", "飞机", "苏浙", "上海迪士尼", "高速公路"],
    };
  },
  computed: {
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
  },
  created() {},
  methods: {
    submitVehicleManagement() {
      this.submitStat = true;
      setTimeout(() => {
        createVehicleManagementInfo({
          vehicle_category: this.submit_vehicle_category,
          departure_interval: this.submit_departure_interval,
          trans_duration: this.submit_trans_duration,
          price: this.submit_price,
          boarding_location: this.submit_boarding_location,
        })
          .then(() => {
            this.submitStat = false;
            this.submitSuccTip(this.$t("信息填报成功！"));
          })
          .catch((err) => {
            this.queryLoaderDialog = false;
            this.submitStat = false;
            this.$store.dispatch("showToastNotify", {
              type: "error",
              info: this.$t("信息填报失败" + err),
            });
          });
      }, 2000);
    },
    submitSuccTip(x) {
      this.$store.dispatch("showToastNotify", { type: "success", info: x });
    },
    submitFailTip(x) {
      this.$store.dispatch("showToastNotify", { type: "error", info: x });
    },
    submitPrejudge() {
      if (
        this.submit_departure_interval != null &&
        this.submit_departure_interval < 0
      ) {
        this.submitFailTip(this.$t("发车频率不能为负！"));
        return 0;
      }
      if (
        this.submit_departure_interval != null &&
        this.submit_departure_interval > 99999
      ) {
        this.submitFailTip(this.$t("发车频率超出限制！"));
        return 0;
      }
      if (
        this.submit_trans_duration != null &&
        this.submit_trans_duration < 0
      ) {
        this.submitFailTip(this.$t("车程时长不能为负！"));
        return 0;
      }
      if (
        this.submit_trans_duration != null &&
        this.submit_trans_duration > 999
      ) {
        this.submitFailTip(this.$t("车程时长超出限制！"));
        return 0;
      }
      if (this.submit_price != null && this.submit_price < 0) {
        this.submitFailTip(this.$t("票价不能为负！"));
        return 0;
      }
      if (this.submit_price != null && this.submit_price > 99999) {
        this.submitFailTip(this.$t("票价超出限制！"));
        return 0;
      }
      this.submitVehicleManagement();
    },
  },
};
</script>
<style scoped lang="scss">
.zms-query-pagination {
  margin-top: 10px;
  transition: all 0.5s;
}
.zms-query-result {
  margin-top: 20px;
}
.zms-aniShow {
  padding-left: 50px;
  padding-right: 50px;
  padding-top: 20px;
  padding-bottom: 20px;
  background-color: #fafafa;
}
.zms-query-title {
  font-weight: bold;
  letter-spacing: 1px;
  position: relative;
  top: 3px;
}
.zms-query-result-table {
  margin-top: 10px;
}
</style>
