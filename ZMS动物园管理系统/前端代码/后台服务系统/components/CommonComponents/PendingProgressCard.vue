<template>
  <v-dialog v-model="zmsShow" persistent width="400">
    <v-card>
      <v-card-title>
        <span class="zms-pending-title">
          {{ $t("pendingProg.Submitting") }}
        </span>
      </v-card-title>
      <v-divider />
      <br />
      <v-card-text>
        {{ $t("pendingProg.PleaseWait") }}
        <span
          v-if="
            zmsPendingList != null &&
            zmsPendingList != undefined &&
            zmsPendingList.length > 0
          "
        >
          <br />
          <br />
          <span
            v-for="i in zmsPendingList.length"
            :key="i - 1"
            class="zms-block"
          >
            <span v-if="getStatus(i - 1)" :key="'p' + i + 'xa'">
              <v-progress-circular
                :size="15"
                :width="1"
                indeterminate
                color="black"
                class="zms-right-padding-adjust"
              />
            </span>
            <span v-else :key="'p' + i + 'xb'">
              <v-icon>mdi-check</v-icon>
            </span>
            <span> {{ zmsPendingList[i - 1] }} </span> <br />
          </span>
        </span>
        <br />
        <br />
        <v-progress-linear indeterminate striped color="primary" class="mb-0" />
      </v-card-text>
    </v-card>
  </v-dialog>
</template>
<script>
export default {
  name: "PendingProgressCard",
  components: {},
  props: {
    zmsShow: Boolean,
    zmsPendingList: {
      type: Array,
      default: () => [],
    },
  },
  data() {
    return {
      zmsPendingStatus: [],
    };
  },
  computed: {
    getStatus() {
      return (x) => {
        return this.zmsPendingStatus[x] === 0;
      };
    },
  },
  beforeCreate() {},
  created() {
    let i = 0;
    for (; i < this.zmsPendingList.length; i++) {
      this.zmsPendingStatus.push(0);
    }
  },
  methods: {
    show() {
      this.zmsDisplay = true;
    },
    reset() {
      let i = 0;
      for (; i < this.zmsPendingList.length; i++) {
        this.$set(this.zmsPendingStatus, i, 0);
      }
    },
    complete(x) {
      this.$set(this.zmsPendingStatus, x, 1);
    },
  },
};
</script>
<style scoped>
.zms-block {
  display: block !important;
}
.zms-right-padding-adjust {
  margin-right: 10px;
}
</style>
