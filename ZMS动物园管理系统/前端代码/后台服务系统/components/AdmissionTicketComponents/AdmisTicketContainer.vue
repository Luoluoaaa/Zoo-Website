<template>
  <div class="zms-showticket">
    <template>
      <!--门票选择框-->
      <v-tabs
        v-model="tab"
        fixed-tabs
        background-color="primary"
        class="rounded"
        dark
      >
        <v-tab :key="1"> 门票概览 </v-tab>
      </v-tabs>
      <v-tabs-items v-model="tab" color="transparent" class="rounded-lg">
        <v-tab-item
          :key="1"
          color="transparent"
          class="rounded-lg zms-transparent-bg"
        >
          <show-ticket-query />
        </v-tab-item>
        <v-tab-item :key="2" color="transparent" class="rounded-lg">
        </v-tab-item>
      </v-tabs-items>
    </template>
  </div>
</template>
<script>
import ShowTicketQuery from "./AdmisTicketQuery.vue";
export default {
  name: "ShowTicketContainer",
  components: {
    ShowTicketQuery,
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
