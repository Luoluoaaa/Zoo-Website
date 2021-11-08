<!---财务管理 图表--->
<template>
  <div>
    <v-chart
      v-if="showX"
      class="chart"
      :theme="this.$vuetify.theme.dark ? 'dark' : 'light'"
      :option.sync="option"
      autoresize
    />
  </div>
</template>
<script>
import { use } from "echarts/core";
import { CanvasRenderer } from "echarts/renderers";
import { PieChart } from "echarts/charts";
import {
  TitleComponent,
  TooltipComponent,
  LegendComponent,
} from "echarts/components";
import VChart from "vue-echarts";
use([
  CanvasRenderer,
  PieChart,
  TitleComponent,
  TooltipComponent,
  LegendComponent,
]);
export default {
  name: "ECPieCharts",
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
      showX: false,
      option: {
        title: {
          text: "Traffic Sources",
          left: "center",
        },
        legend: {
          orient: "horizontal",
          x: "center",
          y: "bottom",
          data: ["A", "B", "C", "D"],
        },
        tooltip: {
          trigger: "axis", 
        },
        xAxis: {
          type: "category", 
          data: ["Mon", "Tue", "Wed", "Thu", "Fri", "Sat", "Sun"], // x轴数据
          name: "Date", // x轴名称
          // x轴名称样式
          nameTextStyle: {
            fontWeight: 600,
            fontSize: 18,
          },
        },
        yAxis: {
          type: "value",
          name: "金额", // y轴名称
          nameTextStyle: {
            fontWeight: 600,
            fontSize: 18,
          },
        },
        series: [
          {
            name: "A",
            data: [820, 932, 901, 934, 1290, 1330, 1320],
            type: "line",
          },
          {
            name: "B",
            data: [620, 711, 823, 934, 1445, 1456, 1178],
            type: "line",
          },
          {
            name: "C",
            data: [612, 920, 1140, 1160, 1190, 1234, 1321],
            type: "line",
          },
          {
            name: "D",
            data: [234, 320, 453, 567, 789, 999, 1200],
            type: "line",
          },
        ],
      },
    };
  },
  mounted() {},
  methods: {
    setResize() {
      let _this = this;
      window.onresize = function () {
        _this.option.resize();
      };
    },
    applyChanges() {
      this.option.title.text = this.zmsChartTitle;
      this.option.series.splice(0, this.option.series.length);
      for (let i = 0; i < this.zmsChartData.length; i++) {
        this.$set(this.option.series, i, this.zmsChartData[i]);
      }
      this.option.legend.data.splice(0, this.option.legend.data.length);
      for (let i = 0; i < this.option.legend.data.length; i++) {
        this.$set(this.option.legend.data, i, this.zmsChartLegend[i]);
      }
      this.option.xAxis.data = this.zmsChartXAxis;
      this.showX = true;
    },
  },
};
</script>
<style scoped>
.chart {
  height: 400px;
}
</style>
