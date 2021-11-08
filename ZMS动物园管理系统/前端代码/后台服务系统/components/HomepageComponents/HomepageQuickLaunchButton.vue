<template>
  <v-card class="rounded zms-pointer">
    <div
      class="zms-ql-title"
      :class="btnNightClass"
      @click="routerGo(zmsroute)"
    >
      <div class="zms-ql-icon">
        <v-icon x-large class="zms-ql-icon-xl">
          {{ icon }}
        </v-icon>
      </div>
      <span class="zms-ql-title-text"> {{ title }}</span>
      <span class="zms-ql-title-text-sub"> {{ info }}</span>
    </div>
  </v-card>
</template>
<script>
export default {
  name: "HomepageQLButton",
  components: {},
  props: {
    title: String,
    info: String,
    icon: String,
    zmsroute: String,
  },
  computed: {
    btnNightClass() {
      return {
        "zms-background-wg": !this.$vuetify.theme.dark,
        "zms-background-wg-dark": this.$vuetify.theme.dark,
      };
    },
  },
  methods: {
    routerGo(x) {
      this.$router.push(x);
    },
  },
};
</script>
<style scoped lang="scss">
.zms-ql-title-text-sub {
  margin-top: 10px;
}
.zms-ql-title-text {
  font-size: 20px;
  font-weight: bold;
  margin-top: 20px;
  display: block;
}
.zms-ql-title {
  padding-top: 20px;
  padding-bottom: 20px;
  text-align: center;
}
.zms-ql-icon-xl {
  transform: scaleX(150%) scaleY(150%);
}
.zms-ql-icon {
  text-align: center;
}
</style>
