<template>
  <div class="zms-anicare">
    <template>
      <!--动物医疗管理选项卡-->
      <v-tabs
        v-model="tab"
        fixed-tabs
        background-color="primary"
        class="rounded"
        dark
      >
        <v-tab :key="1">
          {{ $t("animalCareMain.infoOverview") }}
        </v-tab>
        <v-tab :key="2">
          {{ $t("animalCareMain.initiateRequest") }}
        </v-tab>
      </v-tabs>
      <!--选项卡正文-->
      <v-tabs-items v-model="tab" color="transparent" class="rounded-lg">
        <v-tab-item
          :key="1"
          color="transparent"
          class="rounded-lg zms-transparent-bg"
        >
          <ani-care-query />
        </v-tab-item>
        <v-tab-item :key="2" color="transparent" class="rounded-lg">
          <ani-care-create />
        </v-tab-item>
      </v-tabs-items>
    </template>
  </div>
</template>
<script>
//组件导入
import AniCareCreate from "./AniCareCreates.vue";
import AniCareQuery from "./AniCareQuery.vue";
//组件导出
export default {
  name: "AniCareContainer",
  components: {
    AniCareQuery,
    AniCareCreate,
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
