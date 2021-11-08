<template>
  <div class="zms-anicare" :class="nmNightClass">
    <!--事务成功进度条-->
    <alert-messagebox
      ref="commit_done"
      :alert-title="$t('common3.transactionDoneTitle')"
      :alert-body="$t('common3.transactionDone')"
      :alert-level="`success`"
      :alert-only-confirm="true"
    />
    <!--事务失败提示框-->
    <alert-messagebox
      ref="error_done"
      :alert-title="$t('common3.transactionFailTitle')"
      :alert-body="$t('common3.transactionFail') + errorInfo"
      :alert-level="`error`"
      :alert-only-confirm="true"
    />
    <div class="zms-query-filter">
      <!-- 提交进度条 -->
      <v-dialog v-model="submitStat" persistent width="300">
        <v-card>
          <v-card-title> {{ $t("animalCare.Submitting") }} </v-card-title>
          <v-divider />
          <br />
          <v-card-text>
            {{ $t("animalCare.PleaseWait") }} <br />
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
              {{ $t("animalCare.NoNoteTitle") }}
            </span>
          </v-card-title>
          <v-divider />
          <br />
          <v-card-text>
            <span class="zms-poptip-body" :class="txNightClass">
              {{ $t("animalCare.NoNoteInfo") }}
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
                submitCareInfo();
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
      <!-- 动物选择器 -->
      <item-selector
        ref="aniselector"
        :zms-selector-mode="0"
        @itemSelectorSelect="animalSelectorResponse(arguments)"
      />
      <!-- 员工选择器 -->
      <item-selector
        ref="staselector"
        :zms-selector-mode="1"
        @itemSelectorSelect="staffSelectorResponse(arguments)"
      />
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
      <v-icon color="primary"> mdi-upload-multiple </v-icon>
      <span class="zms-query-title"> {{ $t("animalCare.title") }} </span>
      <!--主请求部分-->
      <div>
        <v-container>
          <v-row>
            <v-col cols="12" sm="6" md="3">
              <v-text-field
                v-model="submitId"
                :label="$t('animalCare.animalId')"
                :hint="$t('animalCare2.chooseByMagnify')"
                :placeholder="
                  $t('common.pleaseInput') + $t('animalCare.animalId')
                "
                prepend-icon="mdi-identifier"
                readonly
                append-icon="mdi-magnify"
                @click:append="calloutAnimalSelect"
              />
            </v-col>
            <v-col cols="12" sm="6" md="3">
              <v-text-field
                v-model="submitVetname"
                :label="$t('animalCare.vetName')"
                :hint="$t('animalCare2.chooseByMagnify')"
                :placeholder="
                  $t('common.pleaseInput') + $t('animalCare.vetName')
                "
                prepend-icon="mdi-doctor"
                readonly
                append-icon="mdi-magnify"
                @click:append="calloutStaffSelect"
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
                    :label="$t('animalCare.illDate')"
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
          </v-row>
        </v-container>
        <v-textarea
          v-model="submitNote"
          outlined
          counter
          prepend-inner-icon="mdi-information"
          name="input-7-4"
          :label="$t('animalCare.diseaseName')"
          :placeholder="$t('common.pleaseInput') + $t('animalCare.diseaseName')"
        />
      </div>
      <!--辅助请求部分-->
      <v-icon color="primary"> mdi-filter-plus </v-icon>
      <span class="zms-query-title">
        {{ $t("animalCare2.secondaryTitle") }}
      </span>
      <br />
      <br />
      <v-alert type="info" text border="left">
        {{ $t("animalCare2.description") }}
      </v-alert>
      <div>
        <v-container>
          <v-row>
            <v-col cols="12" sm="6" md="6">
              <v-combobox
                v-model="illInput"
                :hint="$t('animalCare2.custSymptoms')"
                clearable
                multiple
                :items="illList"
                :label="$t('animalCare2.symptoms')"
                prepend-icon="mdi-emoticon-sick"
              />
            </v-col>
          </v-row>
          <v-row>
            <v-col cols="12" sm="6" md="6">
              <v-slider
                v-model="submitTemp"
                prepend-icon="mdi-thermometer-lines"
                :label="$t('animalCare2.temperature')"
                max="5000"
              >
                <template v-slot:thumb-label="{ value }">
                  {{ value / 100 }}
                </template>
              </v-slider>
            </v-col>
            <v-col cols="12" sm="6" md="6">
              <v-slider
                v-model="submitHeartRate"
                prepend-icon="mdi-heart"
                :label="$t('animalCare2.heartRate')"
                max="400"
              >
                <template v-slot:thumb-label="{ value }">
                  {{ value }}
                </template>
              </v-slider>
            </v-col>
          </v-row>
        </v-container>
      </div>
      <!--菜单栏-->
      <div>
        <v-container>
          <v-row>
            <v-col cols="12" sm="6" md="3" />
            <v-col cols="12" sm="6" md="3">
              <v-btn
                :disabled="submitStat"
                block
                class="zms-width"
                color="primary"
                @click="generateAutoReport()"
              >
                <v-icon>mdi-file-chart</v-icon>&nbsp;&nbsp;{{
                  $t("animalCare2.generateDescription")
                }}
              </v-btn>
            </v-col>
            <v-col cols="12" sm="6" md="3">
              <v-btn
                :disabled="submitStat"
                block
                class="zms-width"
                color="primary"
                @click="calloutAnimalSelect()"
              >
                <v-icon>mdi-paw</v-icon>&nbsp;&nbsp;{{
                  $t("animalselector.externalUse")
                }}
              </v-btn>
            </v-col>
            <v-col cols="12" sm="6" md="3">
              <v-btn
                :disabled="submitStat"
                block
                class="zms-width"
                color="success"
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
//API 导入
import { createCareInfo } from "../../apis/animalCare";
//组件导入
import ItemSelector from "../CommonComponents/ItemSelector.vue";
import AlertMessagebox from "../CommonComponents/AlertMessagebox.vue";
//组件导出
export default {
  name: "AniCareCreate",
  components: {
    ItemSelector,
    AlertMessagebox,
  },
  data: () => {
    return {
      //提交信息暂存
      submitId: null,
      submitType: null,
      submitVetname: null,
      submitDate: null,
      submitNote: null,
      submitStat: false,
      //警告框弹出
      noNoteWarning: false,
      //错误弹出相关
      errorReturn: false,
      errorTitle: "",
      errorInfo: "",
      menu2: false,
      //部分常见症状(用户可自由附加,通过Vuetify组件)
      illList: [
        "头痛",
        "发热",
        "腹泻",
        "细菌感染",
        "真菌感染",
        "器官衰竭",
        "呼吸道感染",
        "食物中毒",
      ],
      //严重等级
      severityList: ["严重", "重要", "中等", "较轻", "轻症"],
      //疾病输入
      illInput: null,
      //体温
      submitTemp: 3700,
      //心率
      submitHeartRate: 60,
      //严重等级(输入项)
      severeInput: "中等",
    };
  },
  computed: {
    //夜间模式附加
    nmNightClass() {
      return {
        "zms-background-nm-dark": this.$vuetify.theme.dark,
      };
    },
    //夜间模式附加
    txNightClass() {
      return {
        "zms-text-dark": this.$vuetify.theme.dark,
      };
    },
  },
  created() {},
  methods: {
    //自动症状生成
    generateAutoReport() {
      let st = "";
      if (this.illInput != null && this.illInput != "") {
        st += "症状:";
        st += this.illInput;
        st += ". ";
      }
      st += "体温" + this.submitTemp / 100 + "度";
      st += ". 心率" + this.submitHeartRate + " bpm.";
      this.submitNote = st;
      this.$store.dispatch("showToastNotify", {
        type: "success",
        info: this.$t("animalCare2.reportGenSuccessful"),
      });
      return st;
    },
    //选择器响应事件
    animalSelectorResponse(arg) {
      this.submitId = arg[0];
    },
    //选择器调出接口
    calloutAnimalSelect() {
      this.$refs.aniselector.show();
    },
    //员工选择器响应事件
    staffSelectorResponse(arg) {
      this.submitVetname = arg[0];
    },
    //员工选择器调出事件
    calloutStaffSelect() {
      this.$refs.staselector.show();
    },
    //医疗信息提交
    submitCareInfo() {
      //打开进度条
      this.submitStat = true;
      // 数据有效性预判
      // eslint-disable-next-line no-control-regex
      if (this.submitNote.replace(/[^\u0000-\u00ff]/g, "aaa").length >= 50) {
        this.$refs.error_done.updateBody(
          "疾病名称输入过长，请保证输入数据在25字节内。"
        );
        this.$refs.error_done.showAlert();
      }
      if (this.submitNote == null || this.submitNote == "") {
        this.$refs.error_done.updateBody("请输入疾病名称");
        this.$refs.error_done.showAlert();
      }
      //延时后发送情况(防止恶意请求)
      setTimeout(() => {
        createCareInfo(
          {
            diseaseName: this.submitNote,
            veterinaryId: this.veterinaryId,
            drug: "(暂无)",
            dateIll: this.submitDate,
            dateCure: null,
            animalId: this.submitId,
          },
          2
        )
          .then(() => {
            this.submitStat = false;
            this.submitSuccTip(this.$t("animalCare.SubmitComplete"));
            this.$refs.commit_done.showAlert();
          })
          .catch((err) => {
            this.submitStat = false;
            this.$refs.error_done.updateBody(
              this.$t("common3.transactionFail") + err
            );
            this.$refs.error_done.showAlert();
          });
      }, 2000);
    },
    //成功Toast提示
    submitSuccTip(x) {
      this.$store.dispatch("showToastNotify", { type: "success", info: x });
    },
    //失败Toast提示
    submitFailTip(x) {
      this.$store.dispatch("showToastNotify", { type: "error", info: x });
    },
    //数据预判(有效性提前检查)
    submitPrejudge() {
      if (
        this.submitId == null ||
        this.submitId == undefined ||
        this.submitId == 0
      ) {
        this.submitFailTip(this.$t("animalCare_SubmitEmptyId"));
        return 0;
      }
      if (
        this.submitVetname == null ||
        this.submitVetname == undefined ||
        this.submitVetname == 0
      ) {
        this.submitFailTip(this.$t("animalCare_SubmitVetName"));
        return 0;
      }
      if (
        this.submitDate == null ||
        this.submitDate == undefined ||
        this.submitDate == 0
      ) {
        this.submitFailTip(this.$t("animalCare_SubmitDate"));
        return 0;
      }
      let year = this.submitDate.split("-")[0];
      let month = this.submitDate.split("-")[1] - 1;
      let day = this.submitDate.split("-")[2];
      let date1 = new Date(year, month, day);
      let date2 = new Date();
      if (date1 > date2) {
        this.submitFailTip(this.$t("animalCare.DateAhead"));
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
      this.submitCareInfo();
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
.zms-anicare {
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
