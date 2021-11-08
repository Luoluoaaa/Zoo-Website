<template>
  <div>
    <!--事务失败提示框-->
    <alert-messagebox
      ref="error_done"
      :alert-title="$t('common3.transactionFailTitle')"
      :alert-body="$t('common3.transactionFail')"
      :alert-level="`error`"
      :alert-only-confirm="true"
    />
    <v-card :ripple="{ class: null }">
      <v-tabs v-model="sortTypeTab">
        <v-tabs-slider />
        <v-tab href="#tab-1">
          {{ $t("fund.byAccounts") }}
          <v-icon>mdi-account</v-icon>
        </v-tab>
        <v-tab href="#tab-2" @change="activateCateTabs">
          {{ $t("fund.byCategory") }}
          <v-icon>mdi-tag</v-icon>
        </v-tab>
      </v-tabs>
      <v-tabs-items v-model="sortTypeTab">
        <v-tab-item :value="`tab-1`">
          <v-container>
            <v-row>
              <v-col cols="12" md="6" sm="6" xl="6" lg="6">
                <div class="zms-qtx-adjust">
                  <span class="zms-query-titlex primary--text">
                    {{ $t("fund.accIncome") }}</span
                  >
                  <br />
                </div>
                <ec-pie-charts
                  ref="ec_acc_income"
                  :zms-chart-title="$t('fund.incomeOverview')"
                  :zms-chart-legend="accIncomeLegends"
                  :zms-chart-data="accIncomeData"
                />
              </v-col>
              <v-divider vertical class="zms-vert-divider-adjust" />
              <v-col cols="12" md="6" sm="6" xl="6" lg="6">
                <div class="zms-qtx-adjust">
                  <span class="zms-query-titlex primary--text">
                    {{ $t("fund.accExpense") }}</span
                  >
                  <br />
                </div>
                <ec-pie-charts
                  ref="ec_acc_expense"
                  :zms-chart-title="$t('fund.expenseOverview')"
                  :zms-chart-legend="accExpenseLegends"
                  :zms-chart-data="accExpenseData"
                />
              </v-col>
            </v-row>
          </v-container>
        </v-tab-item>
        <v-tab-item :value="`tab-2`">
          <v-container>
            <v-row>
              <v-col cols="12" md="6" sm="6" xl="6" lg="6">
                <div class="zms-qtx-adjust">
                  <span class="zms-query-titlex primary--text">
                    {{ $t("fund.cateIncome") }}</span
                  >
                  <br />
                </div>
                <ec-pie-charts
                  ref="ec_cate_income"
                  :zms-chart-title="$t('fund.incomeOverview')"
                  :zms-chart-legend="cateIncomeLegends"
                  :zms-chart-data="cateIncomeData"
                />
                />
              </v-col>
              <v-divider vertical />
              <v-col cols="12" md="6" sm="6" xl="6" lg="6">
                <div class="zms-qtx-adjust">
                  <span class="zms-query-titlex primary--text">
                    {{ $t("fund.cateExpense") }}</span
                  >
                  <br />
                </div>
                <ec-pie-charts
                  ref="ec_cate_expense"
                  :zms-chart-title="$t('fund.expenseOverview')"
                  :zms-chart-legend="cateExpenseLegends"
                  :zms-chart-data="cateExpenseData"
                />
              </v-col>
            </v-row>
          </v-container>
        </v-tab-item>
      </v-tabs-items>
    </v-card>
  </div>
</template>
<script>
import EcPieCharts from "../ChartComponents/EcPieCharts.vue";
import {
  getAccountIncomesOverview,
  getAccountExpenseOverview,
  getCategoryIncomesOverview,
  getCategoryExpenseOverview,
} from "../../apis/fund";
import AlertMessagebox from "../CommonComponents/AlertMessagebox.vue";
export default {
  name: "FlowStatisticsPieOverview",
  components: { EcPieCharts, AlertMessagebox },
  props: {
    bgDate: String,
    edDate: String,
  },
  data() {
    return {
      sortTypeTab: "tab-1",
      completeStat: 0,
      accIncomeLegends: [],
      accIncomeData: [],
      accExpenseLegends: [],
      accExpenseData: [],
      cateIncomeLegends: [],
      cateIncomeData: [],
      cateExpenseLegends: [],
      cateExpenseData: [],
      beginDate: "2000-01-01",
      endDate: "2100-01-01",
      cardArray: ["1", "4"],
    };
  },
  mounted() {
    this.loadData();
  },
  methods: {
    checkComplete() {
      if (this.completeStat === 4) {
        this.$emit("zmsComplete");
      }
    },
    activateCateTabs() {
      this.$refs.ec_cate_expense.applyChanges();
      this.$refs.ec_cate_income.applyChanges();
    },
    loadData() {
      this.completeStat = 0;
      setTimeout(() => {
        getAccountIncomesOverview({
          begin_date: this.bgDate,
          end_date: this.edDate,
        })
          .then((response) => {
            this.completeStat++;
            this.accIncomeLegends.splice(0, this.accIncomeLegends.length);
            let i = 0;
            for (i; i < response.data.length; i++) {
              response.data[i].name =
                this.$t("fund.account") + " " + response.data[i].name;
              this.accIncomeLegends.push(null);
              this.$set(this.accIncomeLegends, i, response.data[i].name);
              this.accIncomeData.push(null);
              this.$set(this.accIncomeData, i, response.data[i]);
            }

            this.checkComplete();
            this.$refs.ec_acc_income.applyChanges();
          })
          .catch((err) => {
            this.completeStat++;
            this.$refs.error_done.updateBody(
              this.$t("common3.transactionFail") + err
            );
            this.$refs.error_done.showAlert();
            this.checkComplete();
          });
      }, 1000);
      setTimeout(() => {
        getAccountExpenseOverview({
          begin_date: this.bgDate,
          end_date: this.edDate,
        })
          .then((response) => {
            this.completeStat++;
            this.accExpenseLegends.splice(0, this.accExpenseLegends.splice);
            let i = 0;
            for (i; i < response.data.length; i++) {
              response.data[i].name =
                this.$t("fund.account") + " " + response.data[i].name;
              this.accExpenseLegends.push(null);
              this.$set(this.accExpenseLegends, i, response.data[i].name);
              this.accExpenseData.push(null);
              this.$set(this.accExpenseData, i, response.data[i]);
            }
            this.checkComplete();
            this.$refs.ec_acc_expense.applyChanges();
          })
          .catch((err) => {
            this.completeStat++;
            this.$refs.error_done.updateBody(
              this.$t("common3.transactionFail") + err
            );
            this.$refs.error_done.showAlert();
            this.checkComplete();
          });
      }, 1000);
      setTimeout(() => {
        getCategoryIncomesOverview({
          begin_date: this.bgDate,
          end_date: this.edDate,
        })
          .then((response) => {
            this.completeStat++;
            this.cateIncomeLegends.splice(0, this.cateIncomeLegends.length);
            let i = 0;
            for (i; i < response.data.length; i++) {
              response.data[i].name =
                this.$t("fund.category") + " " + response.data[i].name;
              this.cateIncomeLegends.push(null);
              this.$set(this.cateIncomeLegends, i, response.data[i].name);
              this.cateIncomeData.push(null);
              this.$set(this.cateIncomeData, i, response.data[i]);
            }

            this.checkComplete();
          })
          .catch((err) => {
            this.completeStat++;
            this.$refs.error_done.updateBody(
              this.$t("common3.transactionFail") + err
            );
            this.$refs.error_done.showAlert();
            this.checkComplete();
          });
      }, 1000);
      setTimeout(() => {
        getCategoryExpenseOverview({
          begin_date: this.bgDate,
          end_date: this.edDate,
        })
          .then((response) => {
            this.completeStat++;
            this.cateExpenseLegends.splice(0, this.cateExpenseLegends.length);
            let i = 0;
            for (i; i < response.data.length; i++) {
              response.data[i].name =
                this.$t("fund.category") + " " + response.data[i].name;
              this.cateExpenseLegends.push(null);
              this.$set(this.cateExpenseLegends, i, response.data[i].name);
              this.cateExpenseData.push(null);
              this.$set(this.cateExpenseData, i, response.data[i]);
            }
            this.checkComplete();
          })
          .catch((err) => {
            this.completeStat++;
            this.$refs.error_done.updateBody(
              this.$t("common3.transactionFail") + err
            );
            this.$refs.error_done.showAlert();
            this.checkComplete();
          });
      }, 1000);
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
.zms-vert-divider-adjust {
  position: relative;
  padding-right: 0 !important;
}
</style>
