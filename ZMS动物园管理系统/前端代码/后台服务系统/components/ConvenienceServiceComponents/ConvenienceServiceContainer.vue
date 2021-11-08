<!---便民服务信息框架--->
<template>
  <div class="zms-ConvenienceService">
    <template>
      <v-tabs
        v-model="tab"
        fixed-tabs
        background-color="primary"
        class="rounded"
        dark
      >
        <v-tab :key="1"> 便民服务信息概览 </v-tab>
        <v-tab :key="2"> 填报便民服务信息 </v-tab>
      </v-tabs>
      <!---跳转相关界面--->
      <v-tabs-items v-model="tab" color="transparent" class="rounded-lg">
        <v-tab-item
          :key="1"
          color="transparent"
          class="rounded-lg zms-transparent-bg"
        >
          <convenience-service-query />
        </v-tab-item>
        <v-tab-item :key="2" color="transparent" class="rounded-lg">
          <convenience-service-create />
        </v-tab-item>
      </v-tabs-items>
    </template>
  </div>
</template>
<script>
import ConvenienceServiceCreate from "./ConvenienceServiceCreates.vue";
import ConvenienceServiceQuery from "./ConvenienceServiceQuery.vue";
export default {
  name: "ConvenienceServiceContainer",
  components: {
    ConvenienceServiceQuery,
    ConvenienceServiceCreate,
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
<style scoped lang="scss"> </style>
