<template>
  <div class="zms-anicare">
    <template>
      <v-tabs v-model="tab" vertical background-color="primary" dark>
        <v-tab :key="1"> <v-icon left> mdi-chart-bar </v-icon>统计分析 </v-tab>
        <v-tab :key="2"> <v-icon left> mdi-note-text </v-icon>流水记录 </v-tab>
        <v-tab :key="3">
          <v-icon left> mdi-card-bulleted </v-icon>账户管理
        </v-tab>
        <v-tab :key="4"> <v-icon left> mdi-plus </v-icon>新增账目 </v-tab>
        <v-tab-item
          :key="1"
          color="transparent"
          class="rounded-lg zms-vert-tabitem zms-transparent-bg"
        >
          <flow-statistics />
        </v-tab-item>
        <v-tab-item
          :key="2"
          color="transparent"
          class="rounded-lg zms-vert-tabitem"
        >
          <flow-record />
        </v-tab-item>
        <v-tab-item
          :key="3"
          color="transparent"
          class="rounded-lg zms-vert-tabitem"
        >
          <bank-account-overview
            @searchRelatedTransactions="tackleRelatedTrans(arguments)"
          />
        </v-tab-item>
        <v-tab-item
          :key="4"
          color="transparent"
          class="rounded-lg zms-vert-tabitem"
        >
          <flow-add />
        </v-tab-item>
      </v-tabs>
    </template>
  </div>
</template>
<script>
import BankAccountOverview from "./BankAccountOverview.vue";
import FlowAdd from "./FlowAdd.vue";
import FlowRecord from "./FlowRecord.vue";
import FlowStatistics from "./FlowStatistics.vue";
export default {
  name: "FundContainer",
  components: {
    BankAccountOverview,
    FlowRecord,
    FlowStatistics,
    FlowAdd,
  },
  data: () => {
    return {
      tab: null,
    };
  },
  created() {},
  methods: {
    tackleRelatedTrans() {
      this.tab = 1;
    },
  },
};
</script>
<style scoped lang="scss">
.zms-vert-tabitem {
  margin-left: 20px;
  margin-top: 20px;
  //height: 500px;
}
</style>
