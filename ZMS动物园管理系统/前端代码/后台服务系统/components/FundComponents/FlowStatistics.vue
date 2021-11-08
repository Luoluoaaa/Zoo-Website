<template>
  <div>
    <alert-messagebox
      ref="error_done"
      :alert-title="$t('common3.transactionFailTitle')"
      :alert-body="$t('common3.transactionFail')"
      :alert-level="`error`"
      :alert-only-confirm="true"
    />
    <!--等待进度条-->
    <pending-progress-card
      ref="pending"
      :zms-show="showPending"
      :zms-pending-list="showPendingList"
    />
    <!--分析选项-->
    <div class="zms-qtx-adjust">
      <v-icon color="primary"> mdi-upload-multiple </v-icon>
      <span class="zms-query-titlex"> {{ $t("fund.selectCond") }}</span> <br />
    </div>
    <v-container>
      <v-row>
        <v-col cols="12" sm="6" md="3">
          <v-menu
            v-model="menuBeginDate"
            :close-on-content-click="false"
            :nudge-right="40"
            transition="scale-transition"
            offset-y
            min-width="290px"
          >
            <template v-slot:activator="{ on, attrs }">
              <v-text-field
                v-model="submitBeginDate"
                :label="$t('fund.startDate')"
                v-bind="attrs"
                prepend-icon="mdi-calendar"
                readonly
                v-on="on"
              />
            </template>
            <v-date-picker
              v-model="submitBeginDate"
              color="primary"
              width="400"
              @input="menuBeginDate = false"
            />
          </v-menu>
        </v-col>
        <v-col cols="12" sm="6" md="3">
          <v-menu
            v-model="menuEndDate"
            :close-on-content-click="false"
            :nudge-right="40"
            transition="scale-transition"
            offset-y
            min-width="290px"
          >
            <template v-slot:activator="{ on, attrs }">
              <v-text-field
                v-model="submitEndDate"
                :label="$t('fund.endDate')"
                v-bind="attrs"
                prepend-icon="mdi-calendar"
                readonly
                v-on="on"
              />
            </template>
            <v-date-picker
              v-model="submitEndDate"
              color="primary"
              width="400"
              @input="menuEndDate = false"
            />
          </v-menu>
        </v-col>
      </v-row>
      <v-row>
        <v-spacer />
        <v-col cols="12" sm="6" md="3">
          <v-btn
            block
            class="zms-width"
            color="success"
            @click="initiateFilter"
          >
            <v-icon>mdi-filter-plus</v-icon>&nbsp;&nbsp;{{
              $t("common2.filter")
            }}
          </v-btn>
        </v-col>
      </v-row>
    </v-container>
    <v-divider />
    <!--分析结果-->
    <div class="zms-qtx-adjust">
      <v-icon color="primary"> mdi-upload-multiple </v-icon>
      <span class="zms-query-titlex"> {{ $t("fund.inexOverview") }}</span>
      <br />
    </div>
    <flow-statistics-pie-overview
      ref="flowstat_bk1"
      :bg-date="submitBeginDate"
      :ed-date="submitEndDate"
      @zmsComplete="completeTask(0)"
    />
    <br />
    <br />
    <v-divider />
    <div class="zms-qtx-adjust">
      <v-icon color="primary"> mdi-upload-multiple </v-icon>
      <span class="zms-query-titlex"> {{ $t("fund.balanceShift") }}</span>
      <br />
    </div>
    <div>
      <flow-statistics-balance-shift-trend
        ref="flowstat_bk2"
        :bg-date="submitBeginDate"
        :ed-date="submitEndDate"
        @zmsComplete="completeTask(1)"
      />
    </div>
    <br />
    <br />
    <v-divider />
    <div class="zms-qtx-adjust">
      <v-icon color="primary"> mdi-upload-multiple </v-icon>
      <span class="zms-query-titlex">
        {{ $t("fund.balanceShiftPerAccount") }}</span
      >
      <br />
    </div>
    <div>
      <flow-statistics-balance-shift-details
        ref="flowstat_bk3"
        :bg-date="submitBeginDate"
        :ed-date="submitEndDate"
        @zmsComplete="completeTask(2)"
      />
    </div>
  </div>
</template>
<script>
import PendingProgressCard from "../CommonComponents/PendingProgressCard.vue";
import FlowStatisticsBalanceShiftDetails from "./FlowStatisticsBalanceShiftDetails.vue";
import FlowStatisticsBalanceShiftTrend from "./FlowStatisticsBalanceShiftTrend.vue";
import FlowStatisticsPieOverview from "./FlowStatisticsPieOverview.vue";
import AlertMessagebox from "../CommonComponents/AlertMessagebox.vue";
import { getAccountList } from "../../apis/fund";
export default {
  name: "FlowStatistics",
  components: {
    FlowStatisticsPieOverview,
    FlowStatisticsBalanceShiftDetails,
    FlowStatisticsBalanceShiftTrend,
    PendingProgressCard,
    AlertMessagebox,
  },
  data() {
    return {
      intervalX: null,
      submitBeginDate: localStorage.getItem("zmsFundBgDate"),
      submitEndDate: localStorage.getItem("zmsFundEdDate"),
      menuBeginDate: 0,
      menuEndDate: 0,
      accountList: [],
      ast: [0, 0, 0, 0],
      submitAccountList: null,
      submitStat: 0,
      showPending: true,
      showPendingList: [
        this.$t("fund.fetchIncExpData"),
        this.$t("fund.fetchBalanceShift"),
        this.$t("fund.fetchBalanceShiftAc"),
        this.$t("fund.findAccounts"),
      ],
      showPendingCnt: 0,
    };
  },
  mounted() {
    if (
      localStorage.getItem("zmsFundBgDate") === undefined ||
      localStorage.getItem("zmsFundBgDate") === ""
    ) {
      localStorage.setItem("zmsFundBgDate", "1921-01-01");
      this.submitBeginDate = "1921-01-01";
    }
    if (
      localStorage.getItem("zmsFundEdDate") === undefined ||
      localStorage.getItem("zmsFundEdDate") === ""
    ) {
      localStorage.setItem("zmsFundEdDate", "2099-01-01");
      this.submitEndDate = "2099-01-01";
    }
    this.fetchAccountList();
  },
  created() {
    this.intervalX = setInterval(() => {
      if (this.ast[0] && this.ast[1] & this.ast[2] && this.ast[3]) {
        this.showPending = false;
        this.$store.dispatch("showToastNotify", {
          type: "success",
          info: this.$t("common2.transactionDone"),
        });
        clearInterval(this.intervalX);
      }
    }, 500);
  },
  methods: {
    fetchAccountList() {
      setTimeout(() => {
        getAccountList()
          .then((response) => {
            this.accountList.splice(0, this.accountList.length);
            let i = 0;
            for (; i < response.data.length; i++) {
              this.accountList.push(null);
              this.$set(
                this.accountList,
                i,
                "(" + response.data[i].id + ")" + response.data[i].name
              );
            }

            this.showPendingCnt++;
            this.completeTask(3);
          })
          .catch((err) => {
            this.showPendingCnt++;
            this.completeTask(3);
            this.$refs.error_done.updateBody(
              this.$t("common3.transactionFail") + err
            );
            this.$refs.error_done.showAlert();
          });
      }, 1000);
    },
    submitFailTip(x) {
      this.$store.dispatch("showToastNotify", { type: "error", info: x });
    },
    initiateFilter() {
      let year0 = this.submitEndDate.split("-")[0];
      let month0 = this.submitEndDate.split("-")[1] - 1;
      let day0 = this.submitEndDate.split("-")[2];
      let date0 = new Date(year0, month0, day0);
      let year1 = this.submitBeginDate.split("-")[0];
      let month1 = this.submitBeginDate.split("-")[1] - 1;
      let day1 = this.submitBeginDate.split("-")[2];
      let date1 = new Date(year1, month1, day1);
      let date2 = new Date();
      if (date1 > date2) {
        this.submitFailTip(this.$t("fund.DateAhead"));
        return 0;
      }
      if (date0 > date2) {
        this.submitFailTip(this.$t("fund.DateAhead"));
        return 0;
      }
      if (date1 > date0) {
        this.submitFailTip(this.$t("fund.endDateTooEarly"));
        return 0;
      }
      localStorage.setItem("zmsFundBgDate", this.submitBeginDate);
      localStorage.setItem("zmsFundEdDate", this.submitEndDate);
      localStorage.setItem("zmsSkipAniT", "1");
      this.$router.go(this.$router.currentRoute);
      return;
    },
    completeTask(x) {
      this.$refs.pending.complete(x);

      this.showPendingCnt++;
      this.ast[x] = 1;
    },
  },
};
</script>
<style scoped>
.zms-qtx-adjust {
  margin-top: 10px;
  margin-bottom: 10px;
  display: block;
}
</style>
