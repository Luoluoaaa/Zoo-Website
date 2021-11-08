<template>
  <div>
    <alert-messagebox
      ref="error_done"
      :alert-title="$t('common3.transactionFailTitle')"
      :alert-body="$t('common3.transactionFail')"
      :alert-level="`error`"
      :alert-only-confirm="true"
    />
    <ec-waterfall-bar-chart
      ref="ec_balance_shift"
      :zms-chart-title="$t('fund.balanceShiftChartTitle')"
      :zms-chart-x-axis="chartXAxis"
      :zms-chart-data="chartData"
    />
  </div>
</template>
<script>
import EcWaterfallBarChart from "../ChartComponents/EcWaterfallBarChart.vue";
import { getOverallBalanceShift } from "../../apis/fund";
import AlertMessagebox from "../CommonComponents/AlertMessagebox.vue";
export default {
  name: "FlowStatisticsBalanceShift",
  components: { EcWaterfallBarChart, AlertMessagebox },
  props: {
    bgDate: String,
    edDate: String,
  },
  data() {
    return {
      completeStat: 0,
      chartXAxis: [],
      chartData: [],
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
        getOverallBalanceShift({
          begin_date: this.beginDate,
          end_date: this.endDate,
        })
          .then((response) => {
            let r = response.data;
            let i = 0;
            for (let i = 0; i < response.data.length; i++) {
              r[i].year = r[i].date.substring(0, 4);
              r[i].month = r[i].date.substring(5, 7);
              r[i].weight = parseInt(
                parseInt(r[i].year) * 100 + parseInt(r[i].month)
              );
            }
            r = r.sort((a, b) => {
              return parseInt(a.weight) - parseInt(b.weight);
            });

            i = 0;
            this.chartXAxis.splice(0, this.chartXAxis.length);
            this.chartData.splice(0, this.chartData.length);
            for (; i < response.data.length; i++) {
              this.chartXAxis.push(null);
              this.$set(this.chartXAxis, i, r[i].date);
            }
            i = 0;
            let preq = 0;
            for (; i < response.data.length; i++) {
              preq = preq + r[i].values;
              this.chartData.push(null);
              this.$set(this.chartData, i, preq);
            }

            this.completeStat++;
            this.checkComplete();
            this.$refs.ec_balance_shift.applyChanges();
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
<style scoped></style>
