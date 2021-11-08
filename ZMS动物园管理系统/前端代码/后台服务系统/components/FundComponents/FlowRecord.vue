<template>
  <div class="zms-anicare" :class="nmNightClass">
    <alert-messagebox
      ref="error_done"
      :alert-title="$t('common3.transactionFailTitle')"
      :alert-body="$t('common3.transactionFail') + errorInfo"
      :alert-level="`error`"
      :alert-only-confirm="true"
    />
    <!--删除项目提示框-->
    <alert-messagebox
      ref="delete_entry_box"
      :alert-title="$t('fund.deleteRecordTitle')"
      :alert-body="$t('fund.deleteRecord')"
      :alert-level="`warning`"
      @alertConfirm="deleteEntry"
    />
    <!--无权查看提示框-->
    <alert-messagebox
      ref="operator_mismatch_box"
      :alert-title="$t('fund.operatorMismatchTitle')"
      :alert-body="$t('fund.operatorMismatch')"
      :alert-level="`error`"
    />
    <!--转移提示框-->
    <alert-messagebox
      ref="permission_transfer_box"
      :alert-title="$t('fund.permissionTransferTitle')"
      :alert-body="
        $t('fund.permissionTransfer') +
        $t('fund.permissionTransferPref') +
        transferTo
      "
      :alert-level="`warning`"
      @alertConfirm="transferFinal"
    />
    <!--事务进行提示框/删除-->
    <pending-progress-card
      :zms-pending-list="pendingList"
      :zms-show="pendingShow"
    />
    <!--事务进行提示框/更新-->
    <pending-progress-card
      :zms-pending-list="pendingList2"
      :zms-show="pendingShow2"
    />
    <!--事务进行提示框/查询-->
    <pending-progress-card
      :zms-pending-list="pendingList3"
      :zms-show="pendingShow3"
    />
    <!--事务进行提示框/账户查询-->
    <pending-progress-card
      :zms-pending-list="pendingList4"
      :zms-show="pendingShow4"
    />
    <v-container>
      <v-row>
        <v-col lg="3" xl="3">
          <v-icon color="primary"> mdi-filter-plus </v-icon>
          <span class="zms-query-title">查询条件</span>
        </v-col>
        <v-col lg="8" xl="8">
          <v-icon color="primary"> mdi-note-search </v-icon>
          <span class="zms-query-title">查询结果</span>
        </v-col>
      </v-row>
      <v-row>
        <v-col lg="3" xl="3">
          <v-card class="zms-special-card" :ripple="{ class: null }">
            <div class="zms-query-filter">
              <div>
                <v-container>
                  <v-row>
                    <v-col cols="12" class="zms-vertical-col-height">
                      <v-text-field
                        v-model="sA"
                        label="流水编号"
                        placeholder="请输入流水编号"
                        prepend-icon="mdi-music-accidental-sharp"
                      />
                    </v-col>
                    <v-col cols="12" class="zms-vertical-col-height">
                      <v-text-field
                        v-model="sB"
                        label="交易名称"
                        placeholder="请输入疾病类型"
                        prepend-icon="mdi-form-textbox"
                      />
                    </v-col>
                    <v-col cols="12" class="zms-vertical-col-height">
                      <v-text-field
                        v-model="sC"
                        label="交易类型"
                        placeholder="请输入交易类型"
                        prepend-icon="mdi-tag"
                      />
                    </v-col>
                    <v-col cols="12" class="zms-vertical-col-height">
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
                            label="最早交易日期"
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
                    <v-col cols="12" class="zms-vertical-col-height">
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
                            v-model="date2"
                            label="最晚交易日期"
                            prepend-icon="mdi-calendar"
                            readonly
                            v-bind="attrs"
                            v-on="on"
                          />
                        </template>
                        <v-date-picker
                          v-model="date2"
                          color="primary"
                          width="400"
                          @input="menu3 = false"
                        />
                      </v-menu>
                    </v-col>
                  </v-row>
                </v-container>
                <v-container>
                  <v-row>
                    <v-col cols="12" />
                    <v-col cols="12">
                      <v-btn
                        v-ripple
                        block
                        class="zms-width"
                        color="error"
                        @click="clearInfo"
                      >
                        <v-icon>mdi-filter-minus</v-icon
                        >&nbsp;&nbsp;删除过滤条件
                      </v-btn>
                    </v-col>
                    <v-col cols="12">
                      <v-btn
                        v-ripple
                        block
                        class="zms-width"
                        color="primary"
                        @click="fetchResponseX"
                      >
                        <v-icon>mdi-filter</v-icon>&nbsp;&nbsp;查找负责项目
                      </v-btn>
                    </v-col>
                    <v-col cols="12">
                      <v-btn
                        v-ripple
                        block
                        class="zms-width"
                        color="primary"
                        @click="fetchFlowEntries(undefined)"
                      >
                        <v-icon>mdi-filter</v-icon>&nbsp;&nbsp;按条件查找
                      </v-btn>
                    </v-col>
                  </v-row>
                </v-container>
              </div>
            </div>
          </v-card>
        </v-col>
        <v-divider vertical />
        <v-col lg="9" xl="9">
          <div class="zms-query-result">
            <div class="zms-query-result-table">
              <v-data-table
                :headers="headers"
                :items="queryData"
                :page.sync="page"
                :items-per-page="10"
                hide-default-footer
                class="elevation-1"
                @page-count="pageCount = $event"
              >
                <template v-slot:top>
                  <v-toolbar flat>
                    <v-toolbar-title>查询结果</v-toolbar-title>
                    <v-spacer />
                    <v-dialog v-model="dialog" persistent max-width="700">
                      <v-card :ripple="{ class: null }">
                        <v-card-title
                          class="zms-strip-bg text-h5 text--white primary"
                          color="warning"
                        >
                          <v-icon color="white"> mdi-lead-pencil </v-icon>&nbsp;
                          <span
                            class="text--white"
                            style="color: #ffffff !important"
                          >
                            {{ $t("fund.modifyEntry") }}
                          </span>
                        </v-card-title>
                        <v-card-text>
                          <br />
                          <v-container>
                            <v-row>
                              <v-icon color="primary"> mdi-information </v-icon>
                              <span class="zms-query-title">
                                {{ $t("fund.basicInfo") }}
                              </span>
                            </v-row>
                            <v-row>
                              <v-col cols="12" sm="6" md="3">
                                <v-text-field
                                  v-model="editedItem['fund_acc_id']"
                                  disabled
                                  :label="$t('fund.id')"
                                  prepend-icon="mdi-identifier"
                                />
                              </v-col>
                              <v-col cols="12" sm="6" md="3">
                                <v-text-field
                                  v-model="editedItem['name']"
                                  :label="$t('fund.name')"
                                  prepend-icon="mdi-tag"
                                />
                              </v-col>
                              <v-col cols="12" sm="6" md="3">
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
                                      v-model="editedItem['transaction_time']"
                                      :label="$t('fund.tranTime')"
                                      prepend-icon="mdi-calendar"
                                      readonly
                                      v-bind="attrs"
                                      v-on="on"
                                    />
                                  </template>
                                  <v-date-picker
                                    v-model="editedItem['transaction_time']"
                                    color="primary"
                                    width="400"
                                    @input="menu3 = false"
                                  />
                                </v-menu>
                              </v-col>
                              <v-col cols="12" sm="6" md="3">
                                <v-text-field
                                  v-model="editedItem['type']"
                                  :label="$t('fund.type')"
                                  prepend-icon="mdi-tag-plus"
                                />
                              </v-col>
                              <v-col cols="12" sm="6" md="3">
                                <v-text-field
                                  v-model="editedItem['amount']"
                                  :label="$t('fund.amount')"
                                  prepend-icon="mdi-currency-cny"
                                />
                              </v-col>
                              <v-col cols="12" sm="6" md="3">
                                <v-select
                                  v-model="editedItem['bank_acc_id']"
                                  :items="accountList"
                                  :label="$t('fund.bankaccid')"
                                  prepend-icon="mdi-card-account-details"
                                />
                              </v-col>
                            </v-row>
                            <v-divider />
                            <v-row> &nbsp; </v-row>
                            <v-row>
                              <v-icon color="primary">
                                mdi-book-arrow-right
                              </v-icon>
                              <span class="zms-query-title">
                                {{ $t("fund.permissionTransferTitle") }}
                              </span>
                            </v-row>
                            <v-row>
                              <v-col>
                                {{ $t("fund.permissionTransferDetail") }}
                              </v-col>
                              <v-col>
                                <v-btn
                                  class="zms-strip-bg-slim"
                                  block
                                  light
                                  color="error"
                                  @click="transferFirst"
                                >
                                  <v-icon>mdi-arrow-horizontal-lock</v-icon>
                                  {{ $t("fund.permissionTransferTitle") }}
                                </v-btn>
                              </v-col>
                            </v-row>
                            <!-- 员工选择器 -->
                            <item-selector
                              ref="staselector"
                              :zms-selector-mode="1"
                              @itemSelectorSelect="transferSecond(arguments)"
                            />
                          </v-container>
                        </v-card-text>
                        <v-divider />
                        <v-card-actions>
                          <v-spacer />
                          <v-btn
                            class="zms-halfwidth3"
                            light
                            color="primary"
                            @click="close"
                          >
                            <v-icon>mdi-arrow-left</v-icon>
                            {{ $t("common.cancel") }}
                          </v-btn>
                          <v-btn
                            class="zms-halfwidth3"
                            light
                            color="success"
                            @click="updateEntry"
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
                  <v-icon small class="mr-2" @click="deleteItem(item)">
                    mdi-delete
                  </v-icon>
                </template>
              </v-data-table>
            </div>
            <div class="zms-query-pagination">
              <v-pagination v-model="page" :length="pageCount" />
            </div>
          </div>
        </v-col>
      </v-row>
    </v-container>
  </div>
</template>
<script>
import AlertMessagebox from "../CommonComponents/AlertMessagebox.vue";
import PendingProgressCard from "../CommonComponents/PendingProgressCard.vue";
import ItemSelector from "../CommonComponents/ItemSelector.vue";
import {
  deleteFlowEntry,
  updateFlowEntry,
  getFlowEntries,
  getAccountList,
} from "../../apis/fund";
export default {
  name: "FlowRecord",
  components: {
    AlertMessagebox,
    PendingProgressCard,
    ItemSelector,
  },
  data() {
    return {
      headers: [
        { text: "流水号", value: "fund_acc_id" },
        { text: "名称", value: "name" },
        { text: "时间", value: "transaction_time" },
        { text: "类型", value: "type" },
        { text: "金额", value: "amount" },
        { text: "账户", value: "bank_acc_id" },
        { text: "处理人", value: "staff_id" },
        { text: "操作", value: "actions", sortable: false },
      ],
      pageCount: 0,
      page: 1,
      menu3: false,
      date2: null,
      delId: 0,
      transferTo: 0,
      sA: null,
      sB: null,
      sC: null,
      pendingList: [this.$t("fund.deleteRecordTran")],
      pendingShow: 0,
      pendingList2: [this.$t("fund.updateRecordTran")],
      pendingShow2: 0,
      pendingList3: [this.$t("fund.fetchRecordTran")],
      pendingShow3: 0,
      pendingList4: [this.$t("fund.fetchAccountTran")],
      pendingShow4: 0,
      accountList: [],
      dialog: 0,
      menu2: 0,
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
    };
  },
  computed: {
    cardNightClass() {
      return {
        "zms-cardcolor-light": !this.$vuetify.theme.dark,
        "zms-cardcolor-dark": this.$vuetify.theme.dark,
      };
    },
    nmNightClass() {
      return {
        "zms-background-nm-dark": this.$vuetify.theme.dark,
      };
    },
  },
  created() {},
  mounted() {
    this.fetchAccountList();
  },
  methods: {
    fetchAccountList() {
      this.pendingShow4 = 1;
      setTimeout(() => {
        getAccountList()
          .then((response) => {
            this.fetchFlowEntries();
            this.accountList.splice(0, this.accountList.length);
            let i = 0;
            for (; i < response.data.length; i++) {
              this.accountList.push(null);
              this.$set(this.accountList, i, response.data[i].id);
            }
            this.pendingShow4 = 0;
          })
          .catch((err) => {
            this.pendingShow4 = 0;
            this.$refs.error_done.updateBody(
              this.$t("common3.transactionFail") + err
            );
            this.$refs.error_done.showAlert();
          });
      }, 1000);
    },
    clearInfo() {
      this.sA = null;
      this.sB = null;
      this.sC = null;
      this.date = null;
      this.date2 = null;
      this.$store.dispatch("showToastNotify", {
        type: "primary",
        info: "信息已经清空",
      });
    },
    fetchFlowEntries(x) {
      this.pendingShow3 = 1;
      setTimeout(() => {
        getFlowEntries({
          id: this.sA,
          name: this.sB,
          type: this.sC,
          trans_time_begin: this.date,
          trans_time_end: this.date2,
          staff_id: x,
        })
          .then((response) => {
            this.pendingShow3 = 0;
            this.$store.dispatch("showToastNotify", {
              type: "success",
              info: this.$t("common2.transactionDone"),
            });
            this.queryData = response.data;
            for (let i = 0; i < this.queryData.length; i++) {
              this.queryData[i].transaction_time = this.queryData[
                i
              ].transaction_time.substring(0, 10);
            }
          })
          .catch((err) => {
            this.pendingShow3 = 0;
            this.$refs.error_done.updateBody(
              this.$t("common3.transactionFail") + err
            );
            this.$refs.error_done.showAlert();
          });
      }, 1000);
    },
    close() {
      this.dialog = false;
      this.$nextTick(() => {
        this.editedItem = Object.assign({}, this.defaultItem);
        this.editedIndex = -1;
      });
    },
    transferFirst() {
      this.$refs.staselector.show();
    },
    transferSecond(x) {
      this.transferTo = x[0];
      this.$refs.permission_transfer_box.updateBody(
        this.$t("fund.permissionTransfer") +
          this.$t("fund.permissionTransferPref") +
          this.transferTo
      );
      this.$refs.permission_transfer_box.showAlert();
    },
    transferFinal() {
      this.pendingShow2 = 1;
      setTimeout(() => {
        updateFlowEntry({
          flow_id: this.editedItem.fund_acc_id,
          id: this.editedItem.bank_acc_id,
          name: this.editedItem.name,
          type: this.editedItem.type,
          trans_time: this.editedItem.transaction_time,
          amount: this.editedItem.amount,
          staff_id: this.transferTo,
        })
          .then(() => {
            this.pendingShow2 = 0;
            this.close();
            this.$store.dispatch("showToastNotify", {
              type: "success",
              info: this.$t("common2.transactionDone"),
            });
            this.fetchFlowEntries();
          })
          .catch((err) => {
            this.pendingSHow2 = 0;
            this.$refs.error_done.updateBody(
              this.$t("common3.transactionFail") + err
            );
            this.$refs.error_done.showAlert();
          });
      }, 1000);
    },
    fetchResponseX() {
      this.fetchFlowEntries(localStorage.getItem("zmsBKId"));
    },
    updateEntry() {
      this.pendingShow2 = 1;
      setTimeout(() => {
        updateFlowEntry({
          flow_id: this.editedItem.fund_acc_id,
          id: this.editedItem.bank_acc_id,
          name: this.editedItem.name,
          type: this.editedItem.type,
          trans_time: this.editedItem.transaction_time,
          amount: this.editedItem.amount,
          staff_id: this.editedItem.staff_id,
        })
          .then(() => {
            this.pendingShow2 = 0;
            this.close();
            this.$store.dispatch("showToastNotify", {
              type: "success",
              info: this.$t("common2.transactionDone"),
            });
            this.fetchFlowEntries();
          })
          .catch((err) => {
            this.pendingShow2 = 0;
            this.$refs.error_done.updateBody(
              this.$t("common3.transactionFail") + err
            );
            this.$refs.error_done.showAlert();
          });
      }, 1000);
    },
    editItem(item) {
      let x = 0;
      if (x) {
        this.$refs.operator_mismatch_box.showAlert();
        return;
      }
      this.editedIndex = this.queryData.indexOf(item);
      this.editedItem = Object.assign({}, item);
      this.dialog = true;
    },
    deleteItem(item) {
      this.delId = item.fund_acc_id;
      this.editedIndex = this.queryData.indexOf(item);
      this.editedItem = Object.assign({}, item);
      this.$refs.delete_entry_box.showAlert();
    },
    deleteEntry() {
      this.pendingShow = 1;
      setTimeout(() => {
        deleteFlowEntry(this.delId)
          .then(() => {
            this.pendingShow = 0;
            this.fetchFlowEntries();
            this.$store.dispatch("showToastNotify", {
              type: "success",
              info: this.$t("common2.transactionDone"),
            });
            this.fetchFlowEntries();
          })
          .catch((err) => {
            this.pendingShow = 0;
            this.$refs.error_done.updateBody(
              this.$t("common3.transactionFail") + err
            );
            this.$refs.error_done.showAlert();
          });
      }, 1000);
    },
  },
};
</script>
<style scoped lang="scss">
.zms-special-card {
  margin-top: 10px;
}
.zms-query-pagination {
  margin-top: 10px;
  transition: all 0.5s;
}
.zms-query-result {
  margin-top: 0px;
}
.zms-anicare {
  padding-left: 10px;
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
.zms-vertical-col-height {
  height: 75px !important;
}
</style>
