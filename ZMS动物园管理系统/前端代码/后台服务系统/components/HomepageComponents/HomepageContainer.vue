<template>
  <div class="zms-home-container">
    <v-container fluid class="fill-height justify-center">
      <v-row align="center" class="mx-0">
        <v-col cols="12" lg="6" xl="6" class="zms-top-align">
          <homepage-welcome />
        </v-col>
        <v-col cols="12" lg="6" xl="6" class="zms-top-align">
          <homepage-account-overview @exitLogin="exitLogin" />
          <homepage-overview />
        </v-col>
        <v-col cols="12" md="6" class="align-self-stretch">
          <homepage-notice />
        </v-col>
        <v-col cols="12" md="6" class="align-self-stretch">
          <homepage-quick-launch />
        </v-col>
      </v-row>
    </v-container>
  </div>
</template>
<script>
import HomepageWelcome from "./HomepageWelcome.vue";
import HomepageNotice from "./HomepageNotice.vue";
import HomepageOverview from "./HomepageOverview.vue";
import HomepageQuickLaunch from "./HomepageQuickLaunch.vue";
import HomepageAccountOverview from "./HomepageAccountOverview.vue";
export default {
  name: "HomepageContainer",
  components: {
    HomepageWelcome,
    HomepageNotice,
    HomepageOverview,
    HomepageQuickLaunch,
    HomepageAccountOverview,
  },
  props: {
    drawer: Boolean,
  },
  data: () => ({}),
  computed: {},
  methods: {
    exitLogin() {
      this.$emit("exitLogin");
    },
  },
};
</script>
<style scoped lang="scss">
.zms-top-align {
  vertical-align: top;
}
</style>
