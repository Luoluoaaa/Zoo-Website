<template>
  <div class="zms-anicare" :class="nmNightClass">
    <!--失败警告框-->
    <alert-messagebox
      ref="error_done"
      :alert-title="$t('common3.transactionFailTitle')"
      :alert-body="$t('common3.transactionFail')"
      :alert-level="`error`"
      :alert-only-confirm="true"
    />
    <animal-selector />
    <!--选择部分-->
    <div class="zms-query-filter">
      <v-icon color="primary"> mdi-filter-plus </v-icon>
      <span class="zms-query-title">查询条件</span>
      <div>
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
        <!--过滤条件表单-->
        <v-container>
          <v-row>
            <v-col cols="12" sm="6" md="3">
              <v-text-field
                v-model="submitId"
                label="动物编号"
                :hint="$t('animalCare2.chooseByMagnify')"
                placeholder="请输入动物编号"
                readonly
                prepend-icon="mdi-music-accidental-sharp"
                append-icon="mdi-magnify"
                @click:append="calloutAnimalSelect"
              />
            </v-col>
            <v-col cols="12" sm="6" md="3">
              <v-text-field
                v-model="submitType"
                label="疾病类型"
                placeholder="请输入疾病类型"
                prepend-icon="mdi-heart-pulse"
              />
            </v-col>
            <v-col cols="12" sm="6" md="3">
              <v-text-field
                v-model="submitVetName"
                label="兽医名称"
                :hint="$t('animalCare2.chooseByMagnify')"
                placeholder="请输入兽医名称"
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
                    v-model="date"
                    label="患病日期"
                    prepend-icon="mdi-calendar"
                    readonly
                    v-bind="attrs"
                    v-on="on"
                  />
                </template>
                <v-date-picker
                  v-model="date"
                  color="primary"
                  width="400"
                  @input="menu2 = false"
                />
              </v-menu>
            </v-col>
          </v-row>
        </v-container>
        <v-container>
          <v-row>
            <v-col cols="12" sm="6" md="3" />
            <v-col cols="12" sm="6" md="3">
              <v-btn
                v-ripple
                :disabled="queryLoaderDialog === true"
                block
                class="zms-width"
                color="error"
                @click="clearData"
              >
                <v-icon>mdi-filter-minus</v-icon>&nbsp;&nbsp;删除过滤条件
              </v-btn>
            </v-col>
            <v-col cols="12" sm="6" md="3">
              <v-btn
                v-ripple
                :disabled="queryLoaderDialog === true"
                block
                class="zms-width"
                color="primary"
                @click="fetchCareInfo()"
              >
                <v-icon>mdi-filter</v-icon>&nbsp;&nbsp;查找负责项目
              </v-btn>
            </v-col>
            <v-dialog v-model="queryLoaderDialog" persistent width="300">
              <v-card color="">
                <v-card-title>正在查找</v-card-title>
                <v-divider />
                <br />
                <v-card-text>
                  请稍后<br />
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
            <v-col cols="12" sm="6" md="3">
              <v-btn
                v-ripple
                :disabled="queryLoaderDialog === true"
                block
                class="zms-width"
                color="primary"
                @click="fetchCareInfo()"
              >
                <v-icon>mdi-filter</v-icon>&nbsp;&nbsp;按条件查找
              </v-btn>
            </v-col>
          </v-row>
        </v-container>
      </div>
    </div>
    <v-divider />
    <!--表格主体-->
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
    <div class="zms-query-result">
      <v-icon color="primary"> mdi-note-search </v-icon>
      <span class="zms-query-title">查询结果</span> <br />
      <br />
      <v-fade-transition>
        <v-alert
          v-if="queryData.length === 0 || queryData === null"
          type="info"
          class="zms-force-nowrap-e"
          text
          border="left"
        >
          {{ $t("animalCare2.overviewFirstFind") }}
        </v-alert>
      </v-fade-transition>
      <div class="zms-query-result-table">
        <v-data-table
          :headers="headers"
          :items="queryData"
          :page.sync="page"
          :items-per-page="5"
          hide-default-footer
          class="elevation-1"
          @page-count="pageCount = $event"
        >
          <template v-slot:top>
            <v-toolbar flat>
              <v-toolbar-title>查询结果</v-toolbar-title>
              <v-spacer />
              <v-dialog v-model="dialog" scrollable persistent max-width="700">
                <v-card class="zms-ignore-overflowx" :ripple="{ class: null }">
                  <v-card-title
                    class="zms-strip-bg text-h5 text--white primary"
                    color="warning"
                  >
                    <v-icon color="white"> mdi-lead-pencil </v-icon>&nbsp;
                    <span class="text--white" style="color: #ffffff !important">
                      {{ $t("animalCare2.traceSuccour") }}
                    </span>
                  </v-card-title>
                  <v-stepper
                    v-model="stepperCount"
                    class="zms-ignore-overflow"
                    flat
                    :value="stepperCount + 1"
                  >
                    <v-stepper-header flat>
                      <v-stepper-step :complete="stepperCount > 1" step="1">
                        {{ $t("animalCare2.alterStep1") }}
                      </v-stepper-step>
                      <v-divider />
                      <v-stepper-step :complete="stepperCount > 2" step="2">
                        {{ $t("animalCare2.alterStep2") }}
                      </v-stepper-step>
                      <v-divider />
                      <v-stepper-step :complete="stepperCount > 3" step="3">
                        {{ $t("animalCare2.alterStep3") }}
                      </v-stepper-step>
                    </v-stepper-header>
                    <div>
                      <v-stepper-items>
                        <!--过程追踪-->
                        <v-stepper-content step="2">
                          <v-icon color="primary"> mdi-pen </v-icon>
                          <span class="zms-query-title">
                            {{ $t("animalCare2.alterProcess") }}
                          </span>
                          <v-card-text class="zms-ignore-overflowx">
                            <v-container>
                              <v-row>
                                {{ $t("animalCare2.traceProcessDescription2") }}
                              </v-row>
                              <v-row>
                                <v-col cols="12" sm="6" md="6">
                                  <v-text-field
                                    v-model="editedItem['animalId']"
                                    disabled
                                    :label="$t('animalCare.animalId')"
                                  />
                                </v-col>
                                <v-col cols="12" sm="6" md="6">
                                  <v-text-field
                                    v-model="editedItem['diseaseName']"
                                    disabled
                                    :label="$t('animalCare.diseaseName')"
                                  />
                                </v-col>
                                <v-col cols="12" sm="6" md="6">
                                  <v-text-field
                                    v-model="editedItem['veterinaryId']"
                                    disabled
                                    :label="$t('animalCare.vetName')"
                                  />
                                </v-col>
                                <v-col cols="12" sm="6" md="6">
                                  <v-text-field
                                    v-model="editedItem['drug']"
                                    :label="$t('animalCare.drugName')"
                                  />
                                </v-col>
                              </v-row>
                            </v-container>
                          </v-card-text>
                          <v-divider />
                          <br />
                          <!--提交完成申请-->
                          <v-icon color="primary"> mdi-pen </v-icon>
                          <span class="zms-query-title">
                            {{ $t("animalCare2.markComplete") }}
                          </span>
                          <br />
                          <br />
                          <v-alert
                            type="warning"
                            class="zms-force-nowrap-e"
                            text
                            border="left"
                          >
                            {{ $t("animalCare2.closeReqWarning") }}
                          </v-alert>
                          <v-card-text>
                            <v-container>
                              <v-row>
                                {{ $t("animalCare2.closeReqDesc2") }}
                              </v-row>
                              <v-row>
                                <v-col cols="12" sm="6" md="6">
                                  <v-menu
                                    v-model="menu3"
                                    :close-on-content-click="false"
                                    :nudge-right="40"
                                    transition="scale-transition"
                                    offset-y
                                    min-width="290px"
                                  >
                                    <template v-slot:activator="{ on, attrs }">
                                      <v-text-field
                                        v-model="cureDate"
                                        :label="$t('animalCare2.cureDate')"
                                        prepend-icon="mdi-calendar"
                                        readonly
                                        v-bind="attrs"
                                        v-on="on"
                                      />
                                    </template>
                                    <v-date-picker
                                      v-model="cureDate"
                                      color="primary"
                                      width="400"
                                      @input="menu3 = false"
                                    />
                                  </v-menu>
                                </v-col>
                              </v-row>
                            </v-container>
                          </v-card-text>
                          <!--确认提交提示框-->
                          <alert-messagebox
                            ref="closeReqMsgbox"
                            :alert-title="$t('animalCare2.closeReqMsgTitle')"
                            :alert-body="$t('animalCare2.closeReqMsgBody')"
                            :alert-level="`warning`"
                            @alertConfirm="submitCloseReq"
                          />
                          <pending-progress-card
                            :zms-show="completeSubmitWaitingBox"
                          />
                          <v-card-text>
                            <v-container>
                              <v-row>
                                <v-col cols="12" sm="6" md="4">
                                  <v-btn
                                    class="zms-strip-bg-slim"
                                    block
                                    light
                                    color="error"
                                    @click="calloutCloseReqMsgbox(0)"
                                  >
                                    <v-icon>mdi-close</v-icon>
                                    {{ $t("common2.abort") }}
                                  </v-btn>
                                </v-col>
                                <v-col cols="12" sm="6" md="4">
                                  <v-btn
                                    class="zms-strip-bg-slim"
                                    block
                                    light
                                    color="success"
                                    @click="calloutCloseReqMsgbox(1)"
                                  >
                                    <v-icon>mdi-check-bold</v-icon>
                                    {{ $t("common2.complete") }}
                                  </v-btn>
                                </v-col>
                              </v-row>
                            </v-container>
                          </v-card-text>
                        </v-stepper-content>
                        <!--已经治愈-->
                        <v-stepper-content step="3">
                          <v-icon color="primary"> mdi-information </v-icon>
                          <span class="zms-query-title">
                            {{ $t("animalCare2.processDone") }}
                          </span>
                          <br />
                          <br />
                          <v-alert
                            type="error"
                            class="zms-force-nowrap-e"
                            text
                            border="left"
                          >
                            {{ $t("animalCare2.completeWork") }}
                          </v-alert>
                          <v-card-text class="zms-ignore-overflowx">
                            <v-container>
                              <v-row>
                                {{ $t("animalCare2.traceProcessDescription3") }}
                              </v-row>
                              <v-row>
                                <v-col cols="12" sm="6" md="6">
                                  <v-text-field
                                    v-model="editedItem['animalId']"
                                    disabled
                                    :label="$t('animalCare.animalId')"
                                  />
                                </v-col>
                                <v-col cols="12" sm="6" md="6">
                                  <v-text-field
                                    v-model="editedItem['diseaseName']"
                                    disabled
                                    :label="$t('animalCare.diseaseName')"
                                  />
                                </v-col>
                                <v-col cols="12" sm="6" md="6">
                                  <v-text-field
                                    v-model="editedItem['veterinaryId']"
                                    disabled
                                    :label="$t('animalCare.vetName')"
                                  />
                                </v-col>
                                <v-col cols="12" sm="6" md="6">
                                  <v-text-field
                                    v-model="editedItem['drug']"
                                    disabled
                                    :label="$t('animalCare.drugName')"
                                  />
                                </v-col>
                                <v-col cols="12" sm="6" md="6">
                                  <v-text-field
                                    v-model="editedItem['isCured']"
                                    disabled
                                    :label="$t('animalCare2.currentStatus')"
                                  />
                                </v-col>
                              </v-row>
                            </v-container>
                          </v-card-text>
                        </v-stepper-content>
                      </v-stepper-items>
                    </div>
                  </v-stepper>
                  <v-card-actions>
                    <v-spacer />
                    <v-btn
                      class="zms-halfwidth3"
                      light
                      color="primary"
                      @click="close"
                    >
                      <v-icon>mdi-arrow-left</v-icon> {{ $t("common.cancel") }}
                    </v-btn>
                    <v-btn
                      class="zms-halfwidth3"
                      light
                      color="success"
                      @click="submitCareInfo(editedItem)"
                    >
                      <v-icon>mdi-check</v-icon> {{ $t("common.save") }}
                    </v-btn>
                  </v-card-actions>
                </v-card>
              </v-dialog>
            </v-toolbar>
          </template>
          <template v-slot:[`item.actions`]="{ item }">
            <v-icon small class="mr-2" @click="editItem(item)">
              mdi-pencil
            </v-icon>
          </template>
        </v-data-table>
      </div>
      <div class="zms-query-pagination">
        <v-pagination v-model="page" :length="pageCount" />
      </div>
    </div>
  </div>
</template>
<script>
//API 引入
import { getCareData, updateCareInfo } from "../../apis/animalCare";
//组件引入
import AlertMessagebox from "../CommonComponents/AlertMessagebox.vue";
import PendingProgressCard from "../CommonComponents/PendingProgressCard.vue";
import ItemSelector from "../CommonComponents/ItemSelector.vue";
export default {
  name: "AnicareQuery",
  components: { AlertMessagebox, PendingProgressCard, ItemSelector },
  data: () => {
    return {
      stepperCount: 2,
      queryLoaderDialog: false,
      headers: [
        { text: "流程编号", value: "cureId" },
        { text: "动物编号", value: "animalId" },
        { text: "疾病名称", value: "diseaseName" },
        { text: "兽医名称", value: "veterinaryId" },
        { text: "药物名称", value: "drug" },
        { text: "当前状态", value: "isCured" },
        { text: "患病时间", value: "dateIll" },
        { text: "治愈时间", value: "dateCure" },
        { text: "操作", value: "actions", sortable: false },
      ],
      submitStat: 0,
      errorReturn: false,
      errorTitle: "",
      submitType: null,
      errorInfo: "",
      pageCount: 0,
      menu2: 0,
      menu3: 0,
      on: 0,
      attrs: 0,
      page: 1,
      atpx: 0,
      cureDate: null,
      dialog: 0,
      date: null,
      queryData: [],
      editedIndex: -1,
      editedItem: {
        name: "",
        calories: 0,
        fat: 0,
        carbs: 0,
        protein: 0,
      },
      defaultItem: {
        name: "",
        calories: 0,
        fat: 0,
        carbs: 0,
        protein: 0,
      },
      submitNote: "",
      submitId: null,
      submitVetName: null,
      completeSubmitWaitingBox: 0,
      completeMsgboxModel: 0,
      completeType: null,
      completeList: ["已经治愈", "放弃治疗"],
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
    //选择器响应
    animalSelectorResponse(arg) {
      this.submitId = arg[0];
    },
    //选择器调出
    calloutAnimalSelect() {
      this.$refs.aniselector.show();
    },
    //员工选择响应
    staffSelectorResponse(arg) {
      this.submitVetName = arg[0];
    },
    //员工选择调出
    calloutStaffSelect() {
      this.$refs.staselector.show();
    },
    //关闭弹框调出
    calloutCloseReqMsgbox(x) {
      this.atpx = x;
      this.$refs.closeReqMsgbox.showAlert();
    },
    //关闭请求提示框调出
    showcloseReqMsgbox() {
      this.$refs.closeReqMsgbox.showAlert();
    },
    //信息获取
    fetchCareInfo() {
      //有效性检查
      this.queryLoaderDialog = true;
      if (this.submitVetName != null && this.submitVetName.length >= 50) {
        this.$store.dispatch("showToastNotify", {
          type: "success",
          info: "疾病情况字段过长",
        });
        return;
      }
      //API获取和处理
      setTimeout(() => {
        getCareData({
          animalId: this.submitId,
          veterinaryId: this.submitVetName,
          dateIll: this.date,
          diseaseName: this.submitType,
        })
          .then((response) => {
            this.queryData = response.data;
            this.queryLoaderDialog = false;
            for (let i = 0; i < this.queryData.length; i++) {
              if (this.queryData[i].drug === null) {
                this.queryData[i].drug = "暂无药物";
              }
              if (this.queryData[i].isCured === 2) {
                this.queryData[i].isCured = "暂未治愈";
              }
              if (this.queryData[i].isCured === 1) {
                this.queryData[i].isCured = "已经治愈";
              }
              if (this.queryData[i].isCured === 0) {
                this.queryData[i].isCured = "放弃治疗";
              }
              if (
                this.queryData[i].dateCure != "" &&
                this.queryData[i].dateCure != null
              ) {
                this.queryData[i].dateCure = this.queryData[
                  i
                ].dateCure.substring(0, 10);
              }
              if (
                this.queryData[i].dateIll != "" &&
                this.queryData[i].dateIll != null
              ) {
                this.queryData[i].dateIll = this.queryData[i].dateIll.substring(
                  0,
                  10
                );
              }
            }
            if (this.queryData.length > 0) {
              this.$store.dispatch("showToastNotify", {
                type: "success",
                info: "信息查询成功",
              });
            } else {
              this.$store.dispatch("showToastNotify", {
                type: "error",
                info: this.$t("animalCare.emptyInfo"),
              });
            }
          })
          .catch((err) => {
            this.queryLoaderDialog = false;
            this.$refs.error_done.updateBody(
              this.$t("common3.transactionFail") + err
            );
            this.$refs.error_done.showAlert();
          });
      }, 1000);
    },
    //信息修改和提交
    submitCloseReq() {
      //已经治愈或结束的,不再进行更新
      if (this.stepperCount != 2) {
        this.close();
      }
      //数据有效性检查
      if (this.cureDate == null || this.cureDate == 0) {
        this.submitFailTip(this.$t("animalCare2.emptyCureDate"));
        return 0;
      }
      let year = this.cureDate.split("-")[0];
      let month = this.cureDate.split("-")[1] - 1;
      let day = this.cureDate.split("-")[2];
      let date1 = new Date(year, month, day);
      let date2 = new Date();
      if (date1 > date2) {
        this.submitFailTip(this.$t("animalCare2.dateAhead"));
        return 0;
      }
      //开始处理API
      this.completeSubmitWaitingBox = 1;
      setTimeout(() => {
        updateCareInfo({
          animalId: this.editedItem.animalId,
          veterinaryId: this.editedItem.veterinaryId,
          dateIll: this.editedItem.dateIll,
          diseaseName: this.editedItem.diseaseName,
          isCured: this.atpx,
          dateCure: this.cureDate,
          cureId: this.editedItem.cureId,
          drug: this.editedItem.drug,
        })
          .then(() => {
            this.completeSubmitWaitingBox = 0;
            this.close();
            if (this.queryData.length > 0) {
              this.$store.dispatch("showToastNotify", {
                type: "success",
                info: this.$t("common2.transactionDone"),
              });
            } else {
              this.$store.dispatch("showToastNotify", {
                type: "error",
                info: this.$t("animalCare.emptyInfo"),
              });
            }
            this.fetchCareInfo();
          })
          .catch((err) => {
            this.completeSubmitWaitingBox = 0;
            this.$refs.error_done.updateBody(
              this.$t("common3.transactionFail") + err
            );
            this.$refs.error_done.showAlert();
          });
      }, 1000);
    },
    //修改框关闭
    close() {
      this.dialog = false;
      this.$nextTick(() => {
        this.editedItem = Object.assign({}, this.defaultItem);
        this.editedIndex = -1;
      });
    },
    //项目编辑
    editItem(item) {
      this.editedIndex = this.queryData.indexOf(item);
      if (item.isCured === "暂未治愈") {
        this.stepperCount = 2;
      } else {
        this.stepperCount = 3;
      }
      this.editedItem = Object.assign({}, item);
      this.dialog = true;
    },
    //筛选条件删除
    clearData() {
      this.submitId = null;
      this.submitVetName = null;
      this.submitType = null;
      this.date = null;
      this.$store.dispatch("showToastNotify", {
        type: "default",
        info: "条件成功删除",
      });
    },
    //治疗信息提交
    submitCareInfo() {
      this.submitStat = true;
      setTimeout(() => {
        let p = this.editedItem.dateCure;
        if (p == "" || p == null || p == undefined) {
          p = "";
        }
        let s = this.editedItem.isCured;
        if (s === "暂未治愈") {
          s = 2;
        } else if (s === "已经治愈") {
          s = 1;
        } else {
          s = 0;
        }
        let x = {
          animalId: this.editedItem.animalId,
          cureId: this.editedItem.cureId,
          dateCure: p,
          dateIll: this.editedItem.dateIll,
          diseaseName: this.editedItem.diseaseName,
          drug: this.editedItem.drug,
          isCured: s,
          veterinaryId: this.editedItem.veterinaryId,
        };
        updateCareInfo(x)
          .then(() => {
            this.submitStat = false;
            this.submitSuccTip(this.$t("animalCare.SubmitComplete2"));
            this.close();
            this.fetchCareInfo();
          })
          .catch((err) => {
            this.submitStat = false;
            this.$refs.error_done.updateBody(
              this.$t("common3.transactionFail") + err
            );
            this.$refs.error_done.showAlert();
          });
      }, 1000);
    },
    //成功Toast提示
    submitSuccTip(x) {
      this.$store.dispatch("showToastNotify", { type: "success", info: x });
    },
    //失败Toast提示
    submitFailTip(x) {
      this.$store.dispatch("showToastNotify", { type: "error", info: x });
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
.zms-ignore-overflow {
  overflow: scroll !important;
}
.zms-ignore-overflowx {
  overflow: hidden !important;
}
</style>
