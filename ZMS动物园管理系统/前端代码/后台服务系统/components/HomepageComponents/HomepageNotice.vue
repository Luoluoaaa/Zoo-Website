<template>
  <div class="zms-home-notice">
    <v-card
      :ripple="{ class: null }"
      elevation="10"
      class="zms-card-noborder"
      :class="cardNightClass"
    >
      <div class="zms-home-title2 zms-home-body2">
        <v-icon>mdi-bell-alert</v-icon> {{ $t("home.faclNotice") }}
      </div>
      <div class="zms-home-body">
        <div v-for="item in this.notice" :key="item.id" class="zms-notice">
          <v-chip
            class="ma-2"
            :color="getNoticeTag(item).color"
            :ripple="false"
            label
            text-color="white"
          >
            <v-icon left> {{ getNoticeTag(item).icon }} </v-icon>
            {{ getNoticeTag(item).capt }}
          </v-chip>
          <v-dialog v-model="item.openStat" width="700">
            <template v-slot:activator="{ on, attrs }">
              <span v-bind="attrs" v-on="on">
                {{ item.title }}
              </span>
              <span v-bind="attrs" v-on="on">
                {{ item.time }} &nbsp;&nbsp;&nbsp;
              </span>
            </template>
            <v-card :ripple="{ class: null }">
              <v-card-title
                class="zms-strip-bg text-h5 text--white primary"
                color="warning"
              >
                <v-icon color="white"> mdi-pen </v-icon>&nbsp;<span
                  class="text--white"
                  style="color: #ffffff !important"
                >
                  {{ $t("home.faclNotice") }}
                </span>
              </v-card-title>
              <v-divider />
              <v-card-text>
                <span class="zms-poptip-body zms-poptip-bodyx">
                  <b class="zms-poptip-bodyxa">
                    <span class="zms-sharp primary--text">#</span>
                    {{ item.title }}
                  </b>
                  <br />
                  {{ item.time }} - {{ item.initiator }} <br />
                  <v-divider />
                  <br />
                  {{ item.content }}
                </span>
              </v-card-text>
              <v-divider />
              <v-card-actions>
                <v-spacer />
                <v-btn
                  class="zms-fullwidth"
                  light
                  color="primary"
                  @click="item.openStat = false"
                >
                  <v-icon>mdi-check</v-icon> {{ $t("common.confirm") }}
                </v-btn>
              </v-card-actions>
            </v-card>
          </v-dialog>
        </div>
      </div>
    </v-card>
  </div>
</template>
<script>
import { getNotice } from "../../apis/homePage";
export default {
  name: "HomepageNotice",
  components: {},
  props: {},
  data: () => {
    return {
      notice: [],
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
  created() {
    this.fetchNotice();
  },
  methods: {
    fetchNotice() {
      getNotice().then((response) => {
        this.notice = response.data;
        this.notice.openStat = false;
      });
    },
    getNoticeTag(x) {
      if (x.level == "top") {
        return {
          icon: "mdi-format-vertical-align-top",
          capt: "置顶",
          color: "error",
        };
      } else {
        return {
          icon: "mdi-information",
          capt: "通知",
          color: "primary",
        };
      }
    },
  },
};
</script>
<style scoped lang="scss">
.zms-poptip-bodyx {
  //color:#111111;
  padding-top: 20px;
  padding-bottom: 40px;
  line-height: 150%;
}
.zms-notice {
  overflow: hidden;
  white-space: nowrap;
  text-overflow: ellipsis;
}
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
  padding-bottom: 30px;
  //color:#111111;
}
.zms-poptip-bodyxa {
  font-size: 20px !important;
}
.zms-home-body2 {
  margin-left: 5%;
  margin-right: 5%;
  padding-top: 20px;
  padding-bottom: 10px;
  //color:#111111;
}
.zms-sharp {
  font-weight: bold;
  font-size: 25px;
}
</style>
