<template>
  <div>
    <v-chart
      class="chart"
      :theme="this.$vuetify.theme.dark ? 'dark' : 'light'"
      :option="option"
      autoresize
    />
  </div>
</template>
<script>
import { use } from "echarts/core";
import { CanvasRenderer } from "echarts/renderers";
import { PieChart, BarChart } from "echarts/charts";
import {
  TitleComponent,
  TooltipComponent,
  LegendComponent,
} from "echarts/components";
import VChart from "vue-echarts";
use([
  CanvasRenderer,
  PieChart,
  BarChart,
  TitleComponent,
  TooltipComponent,
  LegendComponent,
]);
export default {
  name: "EcWaterfallBarChart",
  components: {
    VChart,
  },
  provide: {},
  props: {
    zmsChartTitle: String,
    zmsChartLegend: Array,
    zmsChartData: Array,
    zmsChartXAxis: Array,
  },
  data() {
    return {
      option: {
        title: {
          text: "阶梯瀑布图",
        },
        tooltip: {
          trigger: "axis",
          axisPointer: {
            type: "shadow",
          },
          formatter: function (params) {
            var tar;
            if (params[1].value !== "-") {
              tar = params[1];
            } else {
              tar = params[0];
            }
            return tar.name + "<br/>" + tar.seriesName + " : " + tar.value;
          },
        },
        legend: {
          data: ["支出", "收入"],
        },
        grid: {
          left: "3%",
          right: "4%",
          bottom: "3%",
          containLabel: true,
        },
        xAxis: {
          type: "category",
          splitLine: { show: false },
          data: (function () {
            var list = [];
            for (var i = 1; i <= 11; i++) {
              list.push("11月" + i + "日");
            }
            return list;
          })(),
        },
        yAxis: {
          type: "value",
        },
        series: [
          {
            name: "辅助",
            type: "bar",
            stack: "总量",
            itemStyle: {
              barBorderColor: "rgba(0,0,0,0)",
              color: "rgba(0,0,0,0)",
            },
            emphasis: {
              itemStyle: {
                barBorderColor: "rgba(0,0,0,0)",
                color: "rgba(0,0,0,0)",
              },
            },
            data: [
              0, 900, 1245, 1530, 1376, 1376, 1511, 1689, 1856, 1495, 1292,
            ],
          },
          {
            name: "收入",
            type: "bar",
            stack: "总量",
            label: {
              show: true,
              position: "top",
            },
            data: [900, 345, 393, "-", "-", 135, 178, 286, "-", "-", "-"],
          },
          {
            name: "支出",
            type: "bar",
            stack: "总量",
            label: {
              show: true,
              position: "bottom",
            },
            data: ["-", "-", "-", 108, 154, "-", "-", "-", 119, 361, 203],
          },
        ],
      },
    };
  },
  mounted() {
    let _this = this;
    window.onresize = function () {
      _this.option.resize();
    };
  },
  methods: {
    applyChanges() {
      this.option.title.text = this.zmsChartTitle;
      this.option.xAxis.data = this.zmsChartXAxis;
      this.option.xAxis.data.splice(this.option.xAxis.data.length - 1, 1);
      let incomes = [],
        expense = [];
      let i = 0;
      for (; i < this.zmsChartData.length; i++) {
        incomes.push(null);
        this.$set(incomes, i, this.zmsChartData[i + 1] - this.zmsChartData[i]);
        if (incomes[i] < 0) {
          this.$set(incomes, i, "-");
        }
        expense.push(null);
        this.$set(expense, i, -this.zmsChartData[i + 1] + this.zmsChartData[i]);
        if (expense[i] <= 0) {
          this.$set(expense, i, "-");
        }
      }
      this.option.series[1].data = incomes;
      this.option.series[2].data = expense;
    },
  },
};
</script>
<style scoped>
.chart {
  height: 400px;
}
</style>
