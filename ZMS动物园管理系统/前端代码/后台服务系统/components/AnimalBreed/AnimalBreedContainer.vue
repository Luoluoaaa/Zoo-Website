<template>
  <div>
    <!--繁育信息选项卡-->
    <v-tabs
      v-model="tab"
      fixed-tabs
      background-color="primary"
      class="rounded"
      dark
    >
      <v-tab :key="1"> 繁育信息记录 </v-tab>
      <v-tab :key="2"> 繁育信息上报 </v-tab>
    </v-tabs>
    <v-tabs-items v-model="tab" color="transparent" class="rounded-lg">
      <v-tab-item :key="1" class="rounded-lg">
        <animal-breed-info />
      </v-tab-item>
      <v-tab-item :key="2" class="rounded-lg">
        <create-new-born-info />
      </v-tab-item>
    </v-tabs-items>
  </div>
</template>
<script>
//组件引入
import AnimalBreedInfo from "./AnimalBreedInfo.vue";
import CreateNewBornInfo from "./CreateNewBornInfo.vue";

//Vue组件导出
export default {
  name: "AnimalBreedContainer",
  components: {
    AnimalBreedInfo,
    CreateNewBornInfo,
  },
  data: () => {
    return {
      tab: 0,
    };
  },
  created() {},
};
</script>
