<template>
  <div class="zms-warehouse zms-view-public">
    <v-container fluid class="fill-height justify-center">
      <v-row align="center" class="mx-0">
        <v-col cols="12" md="12" class="align-self-stretch">
          <warehouse-quick-launch />
        </v-col>
        <v-col cols="12" md="12" class="align-self-stretch"> </v-col>
      </v-row>
    </v-container>
  </div>
</template>
<script>
import WarehouseQuickLaunch from "./WarehouseQuickLaunch.vue";
export default {
  name: "WarehouseContainer",
  components: {
    WarehouseQuickLaunch,
  },
  data: () => {
    return {
      tab: null,
    };
  },
  created() {},
  methods: {
    routerGo(x) {
      this.$router.push(x);
    },
  },
};
</script>
<style scoped lang="scss"></style>
