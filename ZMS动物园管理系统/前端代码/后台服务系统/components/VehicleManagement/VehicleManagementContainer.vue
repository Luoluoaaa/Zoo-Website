<template>
  <div class="zms-VehicleManagement">
    <template>
      <v-tabs
        v-model="tab"
        fixed-tabs
        background-color="primary"
        class="rounded"
        dark
      >
        <v-tab :key="1"> 交通信息概览 </v-tab>
        <v-tab :key="2"> 填报交通信息 </v-tab>
      </v-tabs>
      <v-tabs-items v-model="tab" color="transparent" class="rounded-lg">
        <v-tab-item
          :key="1"
          color="transparent"
          class="rounded-lg zms-transparent-bg"
        >
          <vehicle-management-query />
        </v-tab-item>
        <v-tab-item :key="2" color="transparent" class="rounded-lg">
          <vehicle-management-create />
        </v-tab-item>
      </v-tabs-items>
    </template>
  </div>
</template>
<script>
import VehicleManagementCreate from "./VehicleManagementCreates.vue";
import VehicleManagementQuery from "./VehicleManagementQuery.vue";
export default {
  name: "VehicleManagementContainer",
  components: {
    VehicleManagementQuery,
    VehicleManagementCreate,
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
