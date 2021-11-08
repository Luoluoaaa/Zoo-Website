<template>
  <div class="zms-anicare" :class="nmNightClass">
    <alert-messagebox
      ref="error_done"
      :alert-title="$t('common3.transactionFailTitle')"
      :alert-body="$t('common3.transactionFail') + errorInfo"
      :alert-level="`error`"
      :alert-only-confirm="true"
    />
    <v-container>
      <v-row>
        <v-col cols="12" sm="3" md="3" xl="3" lg="3">
          <div class="zms-query-filter">
            <v-icon color="primary"> mdi-filter-plus </v-icon>
            <span class="zms-query-title">查询条件</span>
            <div>
              <v-container>
                <v-row>
                  <v-col
                    cols="12"
                    sm="12"
                    md="12"
                    class="zms-vertical-col-height"
                  >
                    <v-text-field
                      v-model="sA"
                      :label="$t('procure.procid')"
                      :placeholder="
                        $t('common.pleaseInput') + $t('procure.procid')
                      "
                      prepend-icon="mdi-identifier"
                    />
                  </v-col>
                  <v-col
                    cols="12"
                    sm="12"
                    md="12"
                    class="zms-vertical-col-height"
                  >
                    <v-text-field
                      v-model="sB"
                      :label="$t('procure.procname')"
                      :placeholder="
                        $t('common.pleaseInput') + $t('procure.procname')
                      "
                      prepend-icon="mdi-tag"
                    />
                  </v-col>
                  <v-col
                    cols="12"
                    sm="12"
                    md="12"
                    class="zms-vertical-col-height"
                  >
                    <v-select
                      v-model="sC"
                      :items="['待审批', '拒绝', '通过']"
                      :label="$t('procure.procstat')"
                      :placeholder="
                        $t('common.pleaseInput') + $t('procure.procstat')
                      "
                      prepend-icon="mdi-alarm-light"
                    />
                  </v-col>
                  <v-col
                    cols="12"
                    sm="12"
                    md="12"
                    class="zms-vertical-col-height"
                  >
                    <v-menu
                      v-model="menu2"
                      :close-on-content-click="false"
                      :nudge-right="40"
                      transition="scale-transition"
                      offset-y
                      min-width="290px"
                    >
                      <template v-slot:activator="{ on, attrs }">
                        <v-text-field
                          v-model="date"
                          :label="$t('procure.procdate')"
                          prepend-icon="mdi-calendar"
                          readonly
                          v-bind="attrs"
                          v-on="on"
                        />
                      </template>
                      <v-date-picker
                        v-model="date"
                        color="primary"
                        width="400"
                        @input="menu2 = false"
                      />
                    </v-menu>
                  </v-col>
                </v-row>
              </v-container>
              <v-container>
                <v-row>
                  <v-col cols="12" sm="12" md="12" />
                  <v-col cols="12" sm="12" md="12">
                    <v-btn
                      v-ripple
                      :disabled="queryLoaderDialog === true"
                      block
                      class="zms-width"
                      color="error"
                      @click="clrFilters"
                    >
                      <v-icon>mdi-filter-minus</v-icon>&nbsp;&nbsp;{{
                        $t("common.deletefilter")
                      }}
                    </v-btn>
                  </v-col>
                  <v-col cols="12" sm="12" md="12">
                    <v-btn
                      v-ripple
                      :disabled="queryLoaderDialog === true"
                      block
                      class="zms-width"
                      color="primary"
                      @click="fetchCareInfo(1)"
                    >
                      <v-icon>mdi-filter</v-icon>&nbsp;&nbsp;{{
                        $t("common.filterself")
                      }}
                    </v-btn>
                  </v-col>
                  <v-dialog v-model="queryLoaderDialog" persistent width="300">
                    <v-card color="">
                      <v-card-title> {{ $t("common.finding") }} </v-card-title>
                      <v-divider />
                      <br />
                      <v-card-text>
                        {{ $t("common.pleasewait") }} <br />
                        <br />
                        <v-progress-linear
                          indeterminate
                          striped
                          color="primary"
                          class="mb-0"
                        />
                      </v-card-text>
                    </v-card>
                  </v-dialog>
                  <v-dialog v-model="submitStat" persistent width="300">
                    <v-card>
                      <v-card-title>
                        {{ $t("animalCare.Submitting") }}
                      </v-card-title>
                      <v-divider />
                      <br />
                      <v-card-text>
                        {{ $t("animalCare.PleaseWait") }} <br />
                        <br />
                        <v-progress-linear
                          indeterminate
                          striped
                          color="primary"
                          class="mb-0"
                        />
                      </v-card-text>
                    </v-card>
                  </v-dialog>
                  <v-col cols="12" sm="12" md="12">
                    <v-btn
                      v-ripple
                      :disabled="queryLoaderDialog === true"
                      block
                      class="zms-width"
                      color="primary"
                      @click="fetchCareInfo(0)"
                    >
                      <v-icon>mdi-filter</v-icon>&nbsp;&nbsp;{{
                        $t("common.filter")
                      }}
                    </v-btn>
                  </v-col>
                </v-row>
              </v-container>
            </div>
          </div>
        </v-col>
        <v-divider />
        <v-dialog v-model="errorReturn" persistent width="500">
          <v-card color="" :ripple="{ class: null }">
            <v-card-title
              class="zms-strip-bg text-h5 text--white red"
              color="warning"
            >
              <v-icon color="white"> mdi-close-thick </v-icon>&nbsp;<span
                class="text--white"
                style="color: #ffffff !important"
              >
                {{ errorTitle }}
              </span>
            </v-card-title>
            <v-divider />
            <br />
            <v-card-text>
              <span class="zms-poptip-body" :class="txNightClass">
                {{ errorInfo }}
              </span>
              <br />
              <br />
            </v-card-text>
            <v-divider />
            <v-card-actions>
              <v-spacer />
              <v-btn
                class="zms-fullwidth"
                v-bind="attrs"
                light
                color="primary"
                v-on="on"
                @click="errorReturn = false"
              >
                <v-icon>mdi-exclamation</v-icon> {{ $t("common.confirm") }}
              </v-btn>
            </v-card-actions>
          </v-card>
        </v-dialog>
        <v-col cols="12" sm="9" md="9" xl="9" lg="9">
          <div class="zms-query-result">
            <v-icon color="primary"> mdi-note-search </v-icon>
            <span class="zms-query-title">
              {{ $t("common.query_result") }}
            </span>
            <div class="zms-query-result-table">
              <v-data-table
                :headers="headers"
                :items="queryData"
                :page.sync="page"
                :items-per-page="5"
                hide-default-footer
                class="elevation-1"
                @page-count="pageCount = $event"
              >
                <template v-slot:top>
                  <v-toolbar flat>
                    <v-toolbar-title>
                      {{ $t("common.query_result") }}
                    </v-toolbar-title>
                    <v-spacer />
                    <v-dialog v-model="dialog" persistent max-width="700px">
                      <v-card :ripple="{ class: null }">
                        <v-card-title
                          class="zms-strip-bg text-h5 text--white primary"
                          color="warning"
                        >
                          <v-icon color="white">
                            mdi-note-search-outline </v-icon
                          >&nbsp;
                          <span
                            class="text--white"
                            style="color: #ffffff !important"
                          >
                            {{ $t("proc2.modifyEntry") }}
                          </span>
                        </v-card-title>
                        <br />
                        <v-card-text>
                          <v-container>
                            <v-row>
                              <v-icon color="primary"> mdi-information </v-icon>
                              <span class="zms-query-titlex">
                                {{ $t("fund.basicInfo") }}
                              </span>
                            </v-row>
                            <br />
                            <br />
                            <v-alert
                              type="info"
                              class="zms-force-nowrap-e"
                              text
                              border="left"
                            >
                              {{ $t("proc2.noModifyTip") }}
                            </v-alert>
                            <v-row>
                              <v-container>
                                <v-row>
                                  <v-col cols="12" sm="6" md="6">
                                    <v-text-field
                                      v-model="editedItem['id']"
                                      readonly
                                      :label="$t('proc2.id')"
                                      prepend-icon="mdi-identifier"
                                    />
                                  </v-col>
                                  <!--<v-col cols="12" sm="6" md="4">
                                                                        <v-text-field v-model="editedItem['content']" readonly :label="$t('proc2.content')" prepend-icon="mdi-file"> </v-text-field>
                                                                    </v-col>-->
                                  <v-col cols="12" sm="6" md="6">
                                    <v-text-field
                                      v-model="editedItem['stat']"
                                      readonly
                                      :label="$t('proc2.stat')"
                                      prepend-icon="mdi-alarm-light"
                                    />
                                  </v-col>
                                  <v-col cols="12" sm="6" md="6">
                                    <v-text-field
                                      v-model="editedItem['initiator']"
                                      readonly
                                      :label="$t('proc2.initiator')"
                                      prepend-icon="mdi-account"
                                    />
                                  </v-col>
                                  <v-col cols="12" sm="6" md="6">
                                    <v-text-field
                                      v-model="editedItem['inittime']"
                                      readonly
                                      :label="$t('proc2.inittime')"
                                      prepend-icon="mdi-calendar"
                                    />
                                  </v-col>
                                </v-row>
                              </v-container>
                            </v-row>
                          </v-container>
                        </v-card-text>
                        <v-card-actions>
                          <v-spacer />
                          <v-btn
                            class="zms-halfwidth3"
                            light
                            color="primary"
                            @click="close"
                          >
                            <v-icon>mdi-close</v-icon> {{ $t("common.close") }}
                          </v-btn>
                        </v-card-actions>
                      </v-card>
                    </v-dialog>
                  </v-toolbar>
                </template>
                <template v-slot:[`item.actions`]="{ item }">
                  <v-icon small class="mr-2" @click="editItem(item)">
                    mdi-pencil
                  </v-icon>
                  <!--<v-icon small class="mr-2">
                                        mdi-delete
                                    </v-icon>-->
                </template>
              </v-data-table>
            </div>
            <div class="zms-query-pagination">
              <v-pagination v-model="page" :length="pageCount" />
            </div>
          </div>
        </v-col>
      </v-row>
    </v-container>
  </div>
</template>
<script>
import { getProcOverview } from "../../apis/procurement";
import AlertMessagebox from "../CommonComponents/AlertMessagebox.vue";
export default {
  name: "AnicareQuery",
  components: { AlertMessagebox },
  data: () => {
    return {
      queryLoaderDialog: false,
      submitStat: 0,
      errorReturn: false,
      errorTitle: "",
      errorInfo: "",
      pageCount: 0,
      menu2: 0,
      on: 0,
      sA: "",
      sB: "",
      sC: "",
      sD: 0,
      attrs: 0,
      page: 1,
      dialog: 0,
      date: "",
      queryData: [],
      editedIndex: -1,
      editedItem: {
        name: "",
        calories: 0,
        fat: 0,
        carbs: 0,
        protein: 0,
      },
      defaultItem: {
        name: "",
        calories: 0,
        fat: 0,
        carbs: 0,
        protein: 0,
      },
    };
  },
  computed: {
    nmNightClass() {
      return {
        "zms-background-nm-dark": this.$vuetify.theme.dark,
      };
    },
    txNightClass() {
      return {
        "zms-text-dark": this.$vuetify.theme.dark,
      };
    },
    headers() {
      return [
        { text: this.$t("procure.procid"), value: "id" },
        { text: this.$t("procure.procname"), value: "name" },
        //{text: this.$t('procure.proccontent'), value: 'content'},
        { text: this.$t("procure.procstat"), value: "stat" },
        { text: this.$t("procure.initiator"), value: "initiator" },
        { text: this.$t("procure.inittime"), value: "inittime" },
        { text: this.$t("common.action"), value: "actions", sortable: false },
      ];
    },
  },
  created() {},
  methods: {
    clrFilters() {
      this.sA = "";
      this.sB = "";
      this.sC = "";
      this.date = "";
      this.$store.dispatch("showToastNotify", {
        type: "primary",
        info: "查询条件已经清除",
      });
    },
    fetchCareInfo(T) {
      this.queryLoaderDialog = true;
      setTimeout(() => {
        getProcOverview()
          .then((response) => {
            let W = [];
            let X = [];
            //this.queryData = response.data
            this.queryLoaderDialog = false;
            if (response.data.length > 0) {
              this.$store.dispatch("showToastNotify", {
                type: "success",
                info: this.$t("common.findSuccess"),
              });
              for (let i = 0; i < response.data.length; i++) {
                //window.alert(response.data[i].id,response.data[i].name,response.data[i].stat,response.data[i].inittime)
                if (T === 0) {
                  if (
                    (this.sA == "" ||
                      (this.sA != "" && response.data[i].id == this.sA)) &&
                    (this.sB == "" ||
                      (this.sB != "" && response.data[i].name == this.sB)) &&
                    (this.sC == "" ||
                      (this.sC != "" && response.data[i].stat == this.sC)) &&
                    (this.date == "" ||
                      (this.date != "" &&
                        response.data[i].inittime == this.date))
                  ) {
                    if (X.indexOf(response.data[i].id) != -1) {
                      continue;
                    }
                    X.push(response.data[i].id);
                    W.push(response.data[i]);
                  }
                } else {
                  if (
                    (this.sA == "" ||
                      (this.sA != "" && response.data[i].id == this.sA)) &&
                    (this.sB == "" ||
                      (this.sB != "" && response.data[i].name == this.sB)) &&
                    (this.sC == "" ||
                      (this.sC != "" && response.data[i].stat == this.sC)) &&
                    (this.date == "" ||
                      (this.date != "" &&
                        response.data[i].inittime == this.date)) &&
                    response.data[i].initiator ===
                      localStorage.getItem("zmsBKId")
                  ) {
                    if (X.indexOf(response.data[i].id) != -1) {
                      continue;
                    }
                    X.push(response.data[i].id);
                    W.push(response.data[i]);
                  }
                }
              }
              for (let i = 0; i < W.length; i++) {
                W[i].inittime = W[i].inittime.substring(0, 10);
              }
              this.queryData = W;
            } else {
              this.$store.dispatch("showToastNotify", {
                type: "error",
                info: this.$t("animalCare.emptyInfo"),
              });
            }
          })
          .catch((err) => {
            this.queryLoaderDialog = 0;
            this.$refs.error_done.updateBody(
              this.$t("common3.transactionFail") + err
            );
            this.$refs.error_done.showAlert();
          });
      }, 2000);
    },
    close() {
      this.dialog = false;
      this.$nextTick(() => {
        this.editedItem = Object.assign({}, this.defaultItem);
        this.editedIndex = -1;
      });
    },
    editItem(item) {
      this.editedIndex = this.queryData.indexOf(item);
      this.editedItem = Object.assign({}, item);
      this.dialog = true;
    },
    submitCareInfo() {
      this.submitStat = true;
      setTimeout(() => {}, 2000);
    },
    submitSuccTip(x) {
      this.$store.dispatch("showToastNotify", { type: "success", info: x });
    },
    submitFailTip(x) {
      this.$store.dispatch("showToastNotify", { type: "error", info: x });
    },
  },
};
</script>
<style scoped lang="scss">
.zms-query-pagination {
  margin-top: 10px;
  transition: all 0.5s;
}
.zms-query-result {
  margin-top: 0px;
}
.zms-anicare {
  padding-left: 0px;
  padding-right: 0px;
  padding-top: 20px;
  padding-bottom: 20px;
  background-color: #fafafa;
}
.zms-query-title {
  font-weight: bold;
  letter-spacing: 1px;
  position: relative;
  top: 3px;
}
.zms-query-result-table {
  margin-top: 10px;
}
.zms-vertical-col-height {
  height: 75px !important;
}
</style>
