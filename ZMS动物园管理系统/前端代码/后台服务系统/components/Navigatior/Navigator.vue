<template>
  <div class="zms-navigator-container" style="transition: all 0.5s">
    <slidebar-head-icon />
    <v-divider />
    <div class="zms-navigator-body">
      <v-list dense nav class="zms-bold">
        <v-list-item app link nav class="zms-vlist-item" @click="routerGo('/')">
          <v-list-item-icon> <v-icon>mdi-home</v-icon> </v-list-item-icon>
          <v-list-item-content>
            <v-list-item-title>
              <span class="font-weight-bold zms-nav-font">
                {{ $t("common.homepage") }}
              </span>
            </v-list-item-title>
          </v-list-item-content>
        </v-list-item>
        <v-list-group
          v-for="item in getNavigatorPrimaryItems"
          :key="item.name"
          app
          link
          nav
          class="zms-vlist-group"
        >
          <template v-slot:activator app link nav>
            <v-list-item-icon>
              <v-icon> {{ item.icon }} </v-icon>
            </v-list-item-icon>
            <v-list-item-content>
              <v-list-item-title class="font-weight-bold zms-nav-font">
                <span class=".zms-nav-font"> {{ $t(item.name) }} </span>
              </v-list-item-title>
            </v-list-item-content>
          </template>
          <router-link
            v-for="item2 in item.child"
            :key="item2.name"
            :to="item2.route == undefined ? '/' : item2.route"
            style="text-decoration: none"
          >
            <v-list-item app link nav class="zms-vlist-item">
              <v-list-item-content>
                <v-list-item-title>
                  <span class="zms-nav-padding zms-nav-font">
                    {{ $t(item2.name) }}
                  </span>
                </v-list-item-title>
              </v-list-item-content>
              <v-list-item-icon>
                <v-icon> {{ item2.icon }} </v-icon>
              </v-list-item-icon>
            </v-list-item>
          </router-link>
        </v-list-group>
      </v-list>
      <hr />
      <div class="zms-halfwidth zms-inlb">
        <v-btn
          outlined
          block
          class="zms-fullwidth"
          color=""
          style="border-color: #aaaaaa"
          @click="reloadPage"
        >
          <v-icon>mdi-refresh</v-icon> {{ $t("common.reload") }}
        </v-btn>
      </div>
      <div class="zms-halfwidth zms-inlb">
        <v-btn
          outlined
          block
          class="zms-fullwidth"
          style="border-color: #aaaaaa"
          v-bind="attrs"
          color=""
          v-on="on"
          @click="dialog_setting = true"
        >
          <v-icon>mdi-cog</v-icon> {{ $t("settings.title") }}
        </v-btn>
        <v-dialog v-model="dialog_setting" width="700">
          <v-card :ripple="{ class: null }">
            <v-card-title
              class="zms-strip-bg text-h5 text--white darken-3 blue"
              color="warning"
            >
              <v-icon color="white"> mdi-cog </v-icon>&nbsp;
              <span class="text--white" style="color: #ffffff !important">
                {{ $t("settings.title") }}
              </span>
            </v-card-title>
            <v-card-text>
              <setting-card />
            </v-card-text>
            <v-divider />
            <v-card-actions>
              <v-spacer />
              <v-btn
                class="zms-fullwidth"
                light
                color="primary"
                @click="dialog_setting = false"
              >
                <v-icon>mdi-close</v-icon> {{ $t("common.close") }}
              </v-btn>
            </v-card-actions>
          </v-card>
        </v-dialog>
      </div>
    </div>
  </div>
</template>
<script>
import SettingCard from "../CommonComponents/SettingCard.vue";
import SlidebarHeadIcon from "./SlidebarHeadIcon.vue";
export default {
  name: "Navigator",
  components: { SlidebarHeadIcon, SettingCard },
  props: {
    drawer: Boolean,
    lock: Boolean,
  },
  data: () => ({
    items: [
      { title: "Home", icon: "dashboard" },
      { title: "About", icon: "question_answer" },
    ],
    placeholders: [SlidebarHeadIcon],
    dialog_setting: false,
  }),
  computed: {
    getNavigatorPrimaryItems() {
      return this.$store.state.sProjectFunctions;
    },
  },
  methods: {
    reloadPage() {
      window.location.reload();
    },
    routerGo(x) {
      this.$router.push(x);
    },
  },
};
</script>
<style scoped lang="scss">
.zms-navigator-container {
  //height:100%;
  overflow: overlay;
  padding-bottom: 200px;
}
.zms-navigator-pri-item {
  border-radius: 15px;
  font-size: 17px;
  font-weight: bold;
}
</style>
