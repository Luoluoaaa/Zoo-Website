<template>
  <div class="zms-anicare">
    <template>
      <v-tabs v-model="tab" vertical background-color="primary" dark>
        <v-tab :key="1"> <v-icon left> mdi-magnify </v-icon>采购总览 </v-tab>
        <v-tab :key="2">
          <v-icon left> mdi-arrow-collapse-up </v-icon>发起采购
        </v-tab>
        <v-tab :key="3">
          <v-icon left> mdi-checkbox-marked-circle-outline </v-icon>采购审批
        </v-tab>
        <v-tabs-items v-model="tab" class="rounded-lg">
          <v-tab-item
            :key="1"
            class="rounded-lg zms-vert-tabitem zms-transparent-bg"
          >
            <procurement-overview />
          </v-tab-item>
          <v-tab-item :key="2" class="rounded-lg zms-vert-tabitem">
            <procurement-initiation />
          </v-tab-item>
          <v-tab-item :key="3" class="rounded-lg zms-vert-tabitem">
            <procurement-approve />
          </v-tab-item>
        </v-tabs-items>
      </v-tabs>
    </template>
  </div>
</template>
<script>
import ProcurementOverview from "./ProcurementOverview.vue";
import ProcurementInitiation from "./ProcurementInitiation.vue";
import ProcurementApprove from "./ProcurementApprove.vue";
export default {
  name: "ProcurementContainer",
  components: {
    ProcurementOverview,
    ProcurementInitiation,
    ProcurementApprove,
  },
  data: () => {
    return {
      tab: null,
    };
  },
  created() {},
  methods: {},
};
</script>
<style scoped lang="scss">
.zms-vert-tabitem {
  margin-left: 20px;
  margin-top: 20px;
}
</style>
