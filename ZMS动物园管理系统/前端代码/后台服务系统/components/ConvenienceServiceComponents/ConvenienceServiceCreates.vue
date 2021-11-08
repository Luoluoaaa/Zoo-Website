<template>
  <div class="zms-convenienceService" :class="nmNightClass">
    <div class="zms-query-filter">
      <!-- 提交进度条 -->
      <v-dialog v-model="submitStat" persistent width="300">
        <v-card>
          <v-card-title>
            {{ $t("convenienceService.Submitting") }}</v-card-title
          >
          <v-divider />
          <br />
          <v-card-text>
            {{ $t("convenienceService.PleaseWait") }}<br />
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
              {{ $t("convenienceService.NoNoteTitle") }}</span
            >
          </v-card-title>
          <v-divider />
          <br />
          <v-card-text>
            <span class="zms-poptip-body" :class="txNightClass">
              {{ $t("convenienceService.NoNoteInfo") }}</span
            >
            <br />
            <br />
          </v-card-text>
          <v-divider />
          <!---提交信息动作--->
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
                submitConvenienceService();
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
              {{ errorTitle }}</span
            >
          </v-card-title>
          <v-divider />
          <br />
          <v-card-text>
            <span class="zms-poptip-body" :class="txNightClass">
              {{ errorInfo }}</span
            >
            <br />
            <br />
          </v-card-text>
          <v-divider />
          <!---提交信息动作--->
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
      <span class="zms-query-title"> {{ $t("convenienceService.title") }}</span>
      <div>
        <v-container>
          <v-row>
            <v-col cols="12" sm="6" md="3">
              <v-text-field
                v-model="submit_name"
                :label="$t('convenienceService.name')"
                :placeholder="
                  $t('common.pleaseInput') + $t('convenienceService.name')
                "
                prepend-icon="mdi-music-accidental-sharp"
              />
            </v-col>
          </v-row>
        </v-container>
        <v-textarea
          v-model="submit_intro"
          outlined
          counter
          prepend-inner-icon="mdi-information"
          name="input-7-4"
          :label="$t('convenienceService.intro')"
          :placeholder="
            $t('common.pleaseInput') + $t('convenienceService.intro')
          "
        />
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
import { createConvenienceServiceInfo } from "../../apis/convenienceService";
export default {
  name: "ConvenienceServiceCreates",
  data: () => {
    return {
      //提交信息数据
      submit_name: null,
      submit_intro: null,
      submit_ID: null,
      submit_position: null,
      submitNote: null,
      submitStat: false,
      noNoteWarning: false,
      errorReturn: false,
      errorTitle: "",
      errorInfo: "",
      menu2: false,
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
    //填写信息接口
    submitConvenienceService() {
      this.submitStat = true;
      setTimeout(() => {
        createConvenienceServiceInfo({
          name: this.submit_name,
          intro: this.submit_intro,
        })
          .then(() => {
            this.submitStat = false;
            this.submitSuccTip(this.$t("信息填报成功"));
          })
          .catch((err) => {
            this.queryLoaderDialog = false;
            this.submitStat = false;
            this.$store.dispatch("showToastNotify", {
              type: "error",
              info: this.$t("信息填报失败") + err,
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
    //提交信息接口
    submitPrejudge() {
      if (this.submit_name == null || this.submit_name == undefined) {
        this.submitFailTip(this.$t("convenienceService.submit_Empty_name"));
        return 0;
      }
      this.submitConvenienceService();
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
.zms-convenienceService {
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
