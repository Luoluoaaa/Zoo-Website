<template>
  <div class="zms-showticket">
    <template>
      <v-tabs
        v-model="tab"
        fixed-tabs
        background-color="primary"
        class="rounded"
        dark
      >
        <v-tab :key="1"> 演出票流水查询 </v-tab>
        <v-tab :key="2"> 修改演出票信息 </v-tab>
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
          <show-ticket-motify />
        </v-tab-item>
      </v-tabs-items>
    </template>
  </div>
</template>
<script>
import ShowTicketQuery from "./ShowTicketQuery.vue";
import ShowTicketMotify from "./ShowTicketMotify.vue";
export default {
  name: "ShowTicketContainer",
  components: {
    ShowTicketQuery,
    ShowTicketMotify,
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
