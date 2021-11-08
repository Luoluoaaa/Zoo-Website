<template>
  <div class="zms-home-notice">
    <v-card
      :ripple="{ class: null }"
      elevation="10"
      class="zms-card-noborder"
      :class="cardNightClass"
    >
      <div class="zms-home-title2 zms-home-body2">
        <v-icon>mdi-clipboard-check-multiple</v-icon> {{ $t("home.wkOv") }}
      </div>
      <div class="zms-home-body">
        <v-calendar :events="events" @change="getEvents" />
      </div>
    </v-card>
  </div>
</template>
<script>
export default {
  name: "HomepageWorkOverview",
  components: {},
  props: {
    drawer: Boolean,
  },
  data: () => {
    return {
      events: [],
      colors: [
        "blue",
        "indigo",
        "deep-purple",
        "cyan",
        "green",
        "orange",
        "grey darken-1",
      ],
      names: [
        "Meeting",
        "Holiday",
        "PTO",
        "Travel",
        "Event",
        "Birthday",
        "Conference",
        "Party",
      ],
    };
  },
  computed: {
    cardNightClass() {
      return {
        "zms-cardcolor-light": !this.$vuetify.theme.dark,
        "zms-cardcolor-dark": this.$vuetify.theme.dark,
      };
    },
  },
  methods: {
    getEvents({ start, end }) {
      const events = [];
      const min = new Date(`${start.date}T00:00:00`);
      const max = new Date(`${end.date}T23:59:59`);
      const days = (max.getTime() - min.getTime()) / 86400000;
      const eventCount = this.rnd(days, days + 20);
      for (let i = 0; i < eventCount; i++) {
        const allDay = this.rnd(0, 3) === 0;
        const firstTimestamp = this.rnd(min.getTime(), max.getTime());
        const first = new Date(firstTimestamp - (firstTimestamp % 900000));
        const secondTimestamp = this.rnd(2, allDay ? 288 : 8) * 900000;
        const second = new Date(first.getTime() + secondTimestamp);
        events.push({
          name: this.names[this.rnd(0, this.names.length - 1)],
          start: first,
          end: second,
          color: this.colors[this.rnd(0, this.colors.length - 1)],
          timed: !allDay,
        });
      }
      this.events = events;
    },
    getEventColor(event) {
      return event.color;
    },
    rnd(a, b) {
      return Math.floor((b - a + 1) * Math.random()) + a;
    },
  },
};
</script>
<style scoped lang="scss">
.zms-home-notice {
  margin: 0px 20px 0px 20px;
  padding-top: 10px;
  padding-bottom: 10px;
}
.zms-home-center {
  text-align: center;
}
.zms-card-noborder {
  border-width: 0px;
  //background:-webkit-repeating-linear-gradient( 135deg, rgba(245, 245, 245, 0.98), rgba(245, 245, 245, 0.98) 45px, rgba(255, 255, 255, 0.9) 45px, rgba(255, 255, 255, 0.9) 90px ) !important;
}
.zms-home-title2 {
  font-size: 18px;
  font-weight: bold;
  display: block;
}
.zms-home-body {
  margin-left: 7%;
  margin-right: 7%;
  padding-top: 10px;
  padding-bottom: 10px;
}
.zms-home-body2 {
  margin-left: 5%;
  margin-right: 5%;
  padding-top: 20px;
  padding-bottom: 10px;
}
</style>
