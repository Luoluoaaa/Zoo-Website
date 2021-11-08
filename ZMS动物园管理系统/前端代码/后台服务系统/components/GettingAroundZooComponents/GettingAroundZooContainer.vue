<template>
  <div class="zms-GettingAroundZoo">
    <template>
      <v-tabs
        v-model="tab"
        fixed-tabs
        background-color="primary"
        class="rounded"
        dark
      >
        <v-tab :key="1"> 园内交通流水查询 </v-tab>
        <v-tab :key="2"> 修改园内交通信息 </v-tab>
      </v-tabs>
      <v-tabs-items v-model="tab" color="transparent" class="rounded-lg">
        <v-tab-item
          :key="1"
          color="transparent"
          class="rounded-lg zms-transparent-bg"
        >
          <getting-around-zoo-query />
        </v-tab-item>
        <v-tab-item :key="2" color="transparent" class="rounded-lg">
          <getting-around-zoo-motify />
        </v-tab-item>
      </v-tabs-items>
    </template>
  </div>
</template>
<script>
import GettingAroundZooQuery from "./GettingAroundZooQuery.vue";
import GettingAroundZooMotify from "./GettingAroundZooMotify.vue";
export default {
  name: "GettingAroundZooContainer",
  components: {
    GettingAroundZooQuery,
    GettingAroundZooMotify,
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
<style scoped lang="scss"></style>
