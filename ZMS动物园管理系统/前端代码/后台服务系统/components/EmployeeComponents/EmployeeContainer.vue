<template>
  <div class="zms-employee zms-view-public">
    <v-container fluid class="fill-height justify-center">
      <v-row align="center" class="mx-0">
        <v-col cols="12" md="12" class="align-self-stretch">
          <Employee-quick-launch />
        </v-col>
      </v-row>
    </v-container>
  </div>
</template>
<script>
import EmployeeQuickLaunch from "./EmployeeQuickLaunch.vue";
export default {
  name: "EmployeeContainer",
  components: {
    EmployeeQuickLaunch,
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
<style scoped lang="scss">
.zms-employee {
  padding-left: 50px;
  padding-right: 50px;
  padding-top: 20px;
  padding-bottom: 20px;
}
</style>
