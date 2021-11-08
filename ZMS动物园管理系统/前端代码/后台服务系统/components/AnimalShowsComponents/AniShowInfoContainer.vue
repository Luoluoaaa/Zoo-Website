<!---动物演出信息 演出信息概览--->
<template>
  <div class="zms-anishow">
    <template>
      <v-tabs
        v-model="tab"
        fixed-tabs
        background-color="primary"
        class="rounded"
        dark
      >
        <v-tab :key="1"> 演出信息概览 </v-tab>
        <v-tab :key="2"> 填报演出信息 </v-tab>
      </v-tabs>
      <v-tabs-items v-model="tab" color="transparent" class="rounded-lg">
        <v-tab-item
          :key="1"
          color="transparent"
          class="rounded-lg zms-transparent-bg"
        >
          <ani-show-info-query />
        </v-tab-item>
        <v-tab-item :key="2" color="transparent" class="rounded-lg">
          <ani-show-info-create />
        </v-tab-item>
        <v-tab-item :key="2" color="transparent" class="rounded-lg" />
      </v-tabs-items>
    </template>
  </div>
</template>
<script>
import AniShowInfoCreate from "./AniShowInfoCreates.vue";
import AniShowInfoQuery from "./AniShowInfoQuery.vue";
export default {
  name: "AniShowInfoContainer",
  components: {
    AniShowInfoQuery,
    AniShowInfoCreate,
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
