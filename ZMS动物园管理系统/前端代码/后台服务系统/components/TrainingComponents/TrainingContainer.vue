<template>
  <div class="zms-training">
    <template>
      <v-tabs
        v-model="tab"
        fixed-tabs
        background-color="primary"
        class="rounded"
        dark
      >
        <v-tab :key="1"> 训练信息概览 </v-tab>
        <v-tab :key="2"> 填报训练信息 </v-tab>
      </v-tabs>
      <v-tabs-items v-model="tab" color="transparent" class="rounded-lg">
        <v-tab-item
          :key="1"
          color="transparent"
          class="rounded-lg zms-transparent-bg"
        >
          <training-query />
        </v-tab-item>
        <v-tab-item :key="2" color="transparent" class="rounded-lg">
          <training-create />
        </v-tab-item>
      </v-tabs-items>
    </template>
  </div>
</template>
<script>
import TrainingCreate from "./TrainingCreates.vue";
import TrainingQuery from "./TrainingQuery.vue";
export default {
  name: "TrainingContainer",
  components: {
    TrainingQuery,
    TrainingCreate,
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
