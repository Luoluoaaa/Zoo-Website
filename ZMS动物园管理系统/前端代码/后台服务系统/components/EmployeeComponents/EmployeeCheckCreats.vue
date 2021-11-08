<template>
  <div class="zms-employeecheck" :class="nmNightClass">
    <alert-messagebox
      ref="error_done"
      :alert-title="$t('common3.transactionFailTitle')"
      :alert-body="$t('common3.transactionFail')"
      :alert-level="`error`"
      :alert-only-confirm="true"
    />
    <div class="zms-query-filter">
      <!-- 提交进度条 -->
      <v-dialog v-model="submitStat" persistent width="300">
        <v-card>
          <v-card-title> {{ $t("employeecheck.Submitting") }}</v-card-title>
          <v-divider />
          <br />
          <v-card-text>
            {{ $t("employeecheck.PleaseWait") }}<br />
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
              {{ $t("employeecheck.NoNoteTitle") }}</span
            >
          </v-card-title>
          <v-divider />
          <br />
          <v-card-text>
            <span class="zms-poptip-body" :class="txNightClass">
              {{ $t("employeecheck.NoNoteInfo") }}</span
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
                submitEmployeecheckInfo();
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
      <span class="zms-query-title"> {{ $t("employeecheck.Info.title") }}</span>
      <div>
        <v-container>
          <v-row>
            <v-col cols="12" sm="6" md="3">
              <v-text-field
                v-model="submiteId"
                :label="$t('employeecheck.item.employee_id')"
                :placeholder="
                  $t('common.pleaseInput') +
                  $t('employeecheck.item.employee_id')
                "
                prepend-icon="el-icon-files"
              />
            </v-col>
            <v-col cols="12" sm="6" md="3">
              <v-text-field
                v-model="submitmId"
                :label="$t('employeecheck.item.manager_id')"
                :placeholder="
                  $t('common.pleaseInput') + $t('employeecheck.item.manager_id')
                "
                prepend-icon="el-icon-document-copy"
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
                    v-model="submitDate"
                    :label="$t('employeecheck.item.assessment_time')"
                    prepend-icon="mdi-calendar"
                    readonly
                    v-bind="attrs"
                    v-on="on"
                  />
                </template>
                <v-date-picker
                  v-model="submitDate"
                  color="primary"
                  width="400"
                  @input="menu2 = false"
                />
              </v-menu>
            </v-col>
            <v-col class="d-flex" cols="12" sm="6" md="3">
              <v-select
                v-model="submitgrade"
                :items="gradeitems"
                label="考核等级"
                prepend-icon="el-icon-data-board"
              />
            </v-col>
          </v-row>
        </v-container>
        <v-textarea
          v-model="submitNote"
          outlined
          counter
          prepend-inner-icon="mdi-information"
          name="input-7-4"
          :label="$t('employeecheck.note')"
          :placeholder="$t('common.pleaseInput') + $t('employeecheck.note')"
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
import { createEmployeecheckInfo } from "../../apis/employeecheck.js";
import AlertMessagebox from "../CommonComponents/AlertMessagebox.vue";
export default {
  name: "EmployeeCheckCreate",
  components: { AlertMessagebox },
  data: () => {
    return {
      submiteId: null, //员工工号
      submitmId: null, //管理人员工号
      submitDate: null, //考核时间
      submitgrade: null, //考核等级
      submitnote: null, //备注信息
      submitType: null,
      submitPrincipalName: null,
      submitNote: null,
      submitStat: null,
      noNoteWarning: false,
      errorReturn: false,
      errorTitle: "",
      errorInfo: "",
      menu2: false,
      gradeitems: ["A", "B", "C", "D", "E"],
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
    submitEmployeecheckInfo() {
      this.submitStat = true;
      setTimeout(() => {
        createEmployeecheckInfo({
          employeeid: this.submiteId,
          managerid: this.submitmId,
          assessmentgrade: this.submitgrade,
          assessmenttime: this.submitDate,
          remarks: this.submitNote,
        })
          .then((response) => {
            this.submitStat = true;
            if (response.code == 404) {
              this.$store.dispatch("showToastNotify", {
                type: "error",
                info: response.message,
              });
              this.errorTitle = this.$t("common.error");
              this.errorInfo = response.message;
              return 0;
            }
            this.submitSuccTip(this.$t("employeecheck.SubmitComplete"));
            this.submitStat = false;
          })
          .catch((err) => {
            this.$refs.error_done.updateBody(
              this.$t("common3.transactionFail") + err
            );
            this.$refs.error_done.showAlert();
            this.submitStat = false;
            this.errorTitle = this.$t("common.error");
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
        this.submiteId == null ||
        this.submiteId == undefined ||
        this.submiteId == 0
      ) {
        this.submitFailTip(this.$t("员工工号为空"));
        return 0;
      }
      if (
        this.submitmId == null ||
        this.submitmId == undefined ||
        this.submitmId == 0
      ) {
        this.submitFailTip(this.$t("管理人员工号为空"));
        return 0;
      }
      if (
        this.submitDate == null ||
        this.submitDate == undefined ||
        this.submitDate == 0
      ) {
        this.submitFailTip(this.$t("考核时间为空"));
        return 0;
      }
      if (
        this.submitgrade == null ||
        this.submitgrade == undefined ||
        this.submitgrade == 0
      ) {
        this.submitFailTip(this.$t("考核等级为空"));
        return 0;
      }
      if (
        this.submitNote == null ||
        this.submitNote == undefined ||
        this.submitNote == 0
      ) {
        this.noNoteWarning = true;
        return 0;
      }
      this.submitEmployeecheckInfo();
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
.zms-employeecheck {
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
