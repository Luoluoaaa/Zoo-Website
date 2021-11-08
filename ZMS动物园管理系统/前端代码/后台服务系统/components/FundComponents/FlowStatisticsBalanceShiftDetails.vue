<template>
  <div>
    <alert-messagebox
      ref="error_done"
      :alert-title="$t('common3.transactionFailTitle')"
      :alert-body="$t('common3.transactionFail')"
      :alert-level="`error`"
      :alert-only-confirm="true"
    />
    <ec-line-chart
      ref="ec_balance_shift_acc"
      :zms-chart-data="chartData"
      :zms-chart-title="$t('fund.balanceShiftChartTitle')"
      :zms-chart-x-axis="chartXAxis"
      :zms-chart-legend="chartLegends"
    />
  </div>
</template>
<script>
import EcLineChart from "../ChartComponents/EcLineChart.vue";
import AlertMessagebox from "../CommonComponents/AlertMessagebox.vue";
import { getAccountBalanceShift } from "../../apis/fund";
export default {
  name: "FlowStatisticsBalanceShiftDetails",
  components: { EcLineChart, AlertMessagebox },
  props: {
    bgDate: String,
    edDate: String,
  },
  data() {
    return {
      completeStat: 0,
      chartData: [],
      chartLegends: [],
      chartXAxis: [],
    };
  },
  mounted() {
    this.loadData();
  },
  methods: {
    checkComplete() {
      if (this.completeStat === 1) {
        this.$emit("zmsComplete");
      }
    },
    loadData() {
      this.completeStat = 0;
      setTimeout(() => {
        getAccountBalanceShift().then((response) => {
          this.chartXAxis.splice(0, this.chartXAxis.length);
          this.chartData.splice(0, this.chartData.length);
          this.chartLegends.splice(0, this.chartLegends.length);
          //#####数据预处理开始#####

          let r = response.data;
          let accountList = [];
          let accountListX = [];
          let dateX = [];
          let enq = [];

          for (let k = 0; k < r.length; k++) {
            //取得银行账户

            if (accountList.indexOf(r[k].id) === -1) {
              accountList.push(r[k].id);
              accountListX.push({ name: r[k].name, id: r[k].id });
            }
            //取得日期列表
            if (dateX.indexOf(r[k].date) === -1) {
              dateX.push(r[k].date);
            }
          }

          //日期排序
          dateX = dateX.sort((a, b) => {
            let aW =
              parseInt(a.substring(0, 4)) * 100 + parseInt(a.substring(5, 7));
            let bW =
              parseInt(b.substring(0, 4)) * 100 + parseInt(b.substring(5, 7));
            return aW < bW;
          });
          //对数据按日期排序
          r = r.sort((a, b) => {
            let aW =
              parseInt(a.date.substring(0, 4)) * 100 +
              parseInt(a.date.substring(5, 7));
            let bW =
              parseInt(b.date.substring(0, 4)) * 100 +
              parseInt(b.date.substring(5, 7));
            return aW < bW;
          });

          //对每一个账户进行处理
          for (let j = 0; j < accountList.length; j++) {
            let s = {};
            s.name = accountListX[j].name;
            s.id = accountListX[j].id;
            s.type = "line";
            s.data = [];
            //遍历所有日期
            for (let t = 0; t < dateX.length; t++) {
              s.data.push(0);
              let dateLim =
                parseInt(dateX[t].substring(0, 4)) * 100 +
                parseInt(dateX[t].substring(5, 7));
              for (let k = 0; k < r.length; k++) {
                let dateVal =
                  parseInt(r[k].date.substring(0, 4)) * 100 +
                  parseInt(r[k].date.substring(5, 7));
                if (dateVal <= dateLim && r[k].id === s.id) {
                  s.data[t] += r[k].values;
                }
              }
            }
            enq.push(s);
          }

          //####数据预处理结束####
          let i = 0;
          for (; i < dateX.length; i++) {
            this.chartXAxis.push(null);
            this.$set(this.chartXAxis, i, dateX[i]);
          }
          i = 0;
          for (; i < enq.length; i++) {
            this.chartData.push(null);
            this.$set(this.chartData, i, enq[i]);
            this.chartLegends.push(null);
            this.$set(this.chartLegends, i, enq[i].name);
          }
          this.completeStat++;
          this.checkComplete();
          this.$refs.ec_balance_shift_acc.applyChanges();
        });
      }, 1000);
    },
  },
};
</script>
<style scoped></style>
