<!---动物演出信息 填报演出信息--->
<template>
  <div class="zms-aniShow" :class="nmNightClass">
    <div class="zms-query-filter">
      <!-- 提交进度条 -->
      <v-dialog v-model="submitStat" persistent width="300">
        <v-card>
          <v-card-title> {{ $t("animalShow.Submitting") }}</v-card-title>
          <v-divider />
          <br />
          <v-card-text>
            {{ $t("animalShow.PleaseWait") }}<br />
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
      <!-- 提交信息 -->
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
              {{ $t("animalShow.NoNoteTitle") }}</span
            >
          </v-card-title>
          <v-divider />
          <br />
          <v-card-text>
            <span class="zms-poptip-body" :class="txNightClass">
              {{ $t("animalShow.NoNoteInfo") }}</span
            >
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
                submitShowInfo();
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
      <span class="zms-query-title"> {{ $t("animalShow.title") }}</span>
      <div>
        <v-container>
          <v-row>
            <v-col cols="12" sm="6" md="3">
              <v-text-field
                v-model="submit_show_name"
                :label="$t('animalShow.show_name')"
                :placeholder="
                  $t('common.pleaseInput') + $t('animalShow.show_name')
                "
                prepend-icon="el-icon-view"
              />
            </v-col>
            <v-col cols="12" sm="6" md="3">
              <v-text-field
                v-model="submit_principal_id"
                :label="$t('负责人姓名')"
                :placeholder="$t('common.pleaseInput') + $t('负责人姓名')"
                prepend-icon="el-icon-s-custom"
              />
            </v-col>
            <v-col cols="12" sm="6" md="3">
              <v-menu
                v-model="menu2"
                :close-on-content-click="false"
                :nudge-right="40"
                transition="scale-transition"
                offset-y
                min-width="290px"
              >
                <template v-slot:activator="{ on, attrs }">
                  <v-text-field
                    v-model="submit_show_date"
                    :label="$t('animalShow.show_date')"
                    prepend-icon="mdi-calendar"
                    readonly
                    v-bind="attrs"
                    v-on="on"
                  />
                </template>
                <v-date-picker
                  v-model="submit_show_date"
                  color="primary"
                  width="400"
                  @input="menu2 = false"
                />
              </v-menu>
            </v-col>
            <v-col class="d-flex" cols="12" sm="6" md="3">
              <v-select
                v-model="submit_start_time"
                :items="start_time_items"
                :label="$t('animalShow.start_time')"
                prepend-icon="el-icon-sort-up"
              />
            </v-col>
            <v-col class="d-flex" cols="12" sm="6" md="3">
              <v-select
                v-model="submit_end_time"
                :items="end_time_items"
                :label="$t('animalShow.end_time')"
                prepend-icon="el-icon-sort-down"
              />
            </v-col>
            <v-col cols="12" sm="6" md="3">
              <v-text-field
                v-model="submit_show_site"
                :label="$t('animalShow.show_site')"
                :placeholder="
                  $t('common.pleaseInput') + $t('animalShow.show_site')
                "
                prepend-icon="el-icon-position"
              />
            </v-col>
            <v-col cols="12" sm="6" md="3">
              <v-text-field
                v-model="submit_show_props"
                :label="$t('animalShow.show_props')"
                :placeholder="
                  $t('common.pleaseInput') + $t('animalShow.show_props')
                "
                prepend-icon="el-icon-box"
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
import { createShowInfo } from "../../apis/animalShow";
export default {
  name: "AniShowInfoCreates",
  data: () => {
    return {
      submit_show_id: null,
      submit_show_name: null,
      submit_principal_id: null,
      submit_show_date: null,
      submit_start_time: null,
      submit_end_time: null,
      submit_show_site: null,
      submit_show_props: null,
      submitStat: false,
      noNoteWarning: false,
      errorReturn: false,
      errorTitle: "",
      errorInfo: "",
      menu2: false,
      start_time_items: ["14：00", "17：00"],
      end_time_items: ["18：00", "21：00"],
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
  watch: {},
  created() {},
  methods: {
    submitShowInfo() {
      this.submitStat = true;
      setTimeout(() => {
        createShowInfo({
          show_name: this.submit_show_name,
          principal_id: this.submit_principal_id,
          show_date: this.submit_show_date,
          start_time: this.submit_start_time,
          end_time: this.submit_end_time,
          show_site: this.submit_show_site,
          show_props: this.submit_show_props,
        })
          .then(() => {
            this.queryLoaderDialog = false;
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
    submitPrejudge() {
      if (
        this.submit_start_time != null &&
        this.submit_start_time != undefined &&
        this.submit_end_time != null &&
        this.submit_end_time != undefined
      ) {
        let time1 = this.submit_start_time;
        let time2 = this.submit_end_time;
        if (time1 > time2) {
          this.submitFailTip(this.$t("animalShow.DateAhead"));
          return 0;
        }
      }
      if (
        (this.submit_start_time == "14:00" &&
          this.submit_end_time == "21:00") ||
        (this.submit_start_time == "17:00" && this.submit_end_time == "18:00")
      ) {
        this.submitFailTip(
          this.$t(
            "开始时间14:00必须对应结束时间18:00 开始时间17:00必须对应结束时间21：00"
          )
        );
        return 0;
      }
      this.submitShowInfo();
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
