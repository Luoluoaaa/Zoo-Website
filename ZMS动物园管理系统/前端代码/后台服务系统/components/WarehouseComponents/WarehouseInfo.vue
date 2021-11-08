<template>
  <div class="zms-home-notice">
    <span>下方列出了园区内所有的仓库</span>
    <v-btn color="primary" text @click="newDialog = true">
      {{ $t("warehouse.Info.create") }}
    </v-btn>
    <alert-messagebox
      ref="error_done"
      :alert-title="$t('common3.transactionFailTitle')"
      :alert-body="$t('common3.transactionFail') + errorInfo"
      :alert-level="`error`"
      :alert-only-confirm="true"
    />
    <alert-messagebox
      ref="commit_done"
      :alert-title="$t('common3.transactionDoneTitle')"
      :alert-body="$t('common3.transactionDone')"
      :alert-level="`success`"
      :alert-only-confirm="true"
    />
    <v-container>
      <v-row>
        <v-col
          v-for="item in warehouseDetail"
          :key="item.storeId"
          cols="12"
          md="4"
          class="align-self-stretch"
        >
          <v-card
            :class="cardNightClass"
            :ripple="{ class: null }"
            class="mx-auto"
            max-width="400"
          >
            <v-img
              class="white--text align-end"
              height="200px"
              src="https://cdn.vuetifyjs.com/images/cards/docks.jpg"
            >
              <v-card-title> {{ item.name }} </v-card-title>
            </v-img>
            <v-card-subtitle class="pb-0">
              <b>编号</b> {{ item.storeId }}
            </v-card-subtitle>
            <v-card-text class="text--primary pb-0">
              <div><b>位置</b></div>
              <div>{{ item.location }}</div>
            </v-card-text>
            <v-card-actions> </v-card-actions>
          </v-card>
        </v-col>
      </v-row>
    </v-container>
    <v-dialog v-model="newDialog" persistent max-width="600px">
      <v-card :ripple="{ class: null }">
        <v-card-title
          class="zms-strip-bg text-h5 text--white primary"
          color="warning"
        >
          <v-icon color="white"> mdi-plus-thick </v-icon>&nbsp;<span
            class="text--white"
            style="color: #ffffff !important"
          >
            {{ $t("warehouse.Info.new") }}
          </span>
        </v-card-title>
        <v-card-text>
          <v-container>
            <v-row>
              <v-col cols="12" lg="12">
                <v-text-field
                  v-model="alterItem.storeId"
                  :label="$t('warehouse.Info.wareid')"
                />
              </v-col>
              <v-col cols="12" lg="12">
                <v-text-field
                  v-model="alterItem.name"
                  :label="$t('warehouse.Info.wareName')"
                />
              </v-col>
              <v-col cols="12" lg="12">
                <v-text-field
                  v-model="alterItem.location"
                  :label="$t('warehouse.Info.wareLocation')"
                />
              </v-col>
            </v-row>
          </v-container>
        </v-card-text>
        <v-card-actions>
          <v-spacer />
          <v-btn
            class="zms-fullwidth"
            v-bind="attrs"
            light
            color="primary"
            v-on="on"
            @click="newDialog = false"
          >
            <v-icon>mdi-close</v-icon> {{ $t("common.cancel") }}
          </v-btn>
          <v-btn
            class="zms-fullwidth"
            v-bind="attrs"
            light
            color="success"
            v-on="on"
            @click="createInfo()"
          >
            <v-icon>mdi-check</v-icon> {{ $t("common.confirm") }}
          </v-btn>
        </v-card-actions>
      </v-card>
    </v-dialog>
    <v-dialog v-model="alterDialog" persistent max-width="600px">
      <v-card :ripple="{ class: null }">
        <v-card-title
          class="zms-strip-bg text-h5 text--white primary"
          color="warning"
        >
          <v-icon color="white"> mdi-pen </v-icon>&nbsp;<span
            class="text--white"
            style="color: #ffffff !important"
          >
            {{ $t("warehouse.Info.alter") }}
          </span>
        </v-card-title>
        <v-card-text>
          <v-container>
            <v-row>
              <v-col cols="12" lg="12">
                <v-text-field
                  v-model="alterItem.storeId"
                  disabled
                  :label="$t('warehouse.Info.wareid')"
                />
              </v-col>
              <v-col cols="12" lg="12">
                <v-text-field
                  v-model="alterItem.name"
                  :label="$t('warehouse.Info.wareName')"
                />
              </v-col>
              <v-col cols="12" lg="12">
                <v-text-field
                  v-model="alterItem.location"
                  :label="$t('warehouse.Info.wareLocation')"
                />
              </v-col>
            </v-row>
          </v-container>
        </v-card-text>
        <v-card-actions>
          <v-spacer />
          <v-btn
            class="zms-fullwidth"
            v-bind="attrs"
            light
            color="primary"
            v-on="on"
            @click="alterDialog = false"
          >
            <v-icon>mdi-close</v-icon> {{ $t("common.cancel") }}
          </v-btn>
          <v-btn
            class="zms-fullwidth"
            v-bind="attrs"
            light
            color="success"
            v-on="on"
            @click="updateInfo()"
          >
            <v-icon>mdi-check</v-icon> {{ $t("common.confirm") }}
          </v-btn>
        </v-card-actions>
      </v-card>
    </v-dialog>
    <v-dialog v-model="queryLoaderDialog" persistent width="300">
      <v-card color="">
        <v-card-title>正在查找</v-card-title>
        <v-divider />
        <br />
        <v-card-text>
          请稍后<br />
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
        <v-card-title> {{ $t("animalCare.Submitting") }} </v-card-title>
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
          <span class="zms-poptip-body"> {{ errorInfo }} </span> <br />
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
  </div>
</template>
<script>
import {
  getWarehouseInfo,
  updateWarehouseInfo,
  createWarehouse,
} from "../../apis/warehouse.js";
import AlertMessagebox from "../CommonComponents/AlertMessagebox.vue";
export default {
  name: "WarehouseInfo",
  components: { AlertMessagebox },
  props: {
    drawer: Boolean,
  },
  data: () => {
    return {
      queryLoaderDialog: true,
      warehouseDetail: [],
      alterDialog: false,
      alterId: -1,
      alterItem: {},
      submitStat: false,
      errorReturn: false,
      newDialog: false,
      errorTitle: "",
      errorInfo: "",
      sA: null,
      sB: null,
      sC: null,
    };
  },
  computed: {
    cardNightClass() {
      return {
        "zms-cardcolor-light": !this.$vuetify.theme.dark,
        "zms-cardcolor-dark": this.$vuetify.theme.dark,
      };
    },
    nmNightClass() {
      return {
        "zms-background-nm-dark": this.$vuetify.theme.dark,
      };
    },
  },
  created() {
    this.fetchWarehouseInfo();
  },
  methods: {
    openDialog(id) {
      this.alterDialog = true;
      this.alterId = id;
      this.alterItem = this.warehouseDetail[id];
    },
    createInfo() {
      createWarehouse({
        id: this.alterItem.storeId,
        name: this.alterItem.name,
        location: this.alterItem.location,
      })
        .then(() => {
          this.newDialog = false;
          this.$store.dispatch("showToastNotify", {
            type: "success",
            info: "仓库已经创建",
          });
          this.fetchWarehouseInfo();
        })
        .catch((err) => {
          this.$refs.error_done.updateBody(
            this.$t("common3.transactionFail") + err
          );
          this.$refs.error_done.showAlert();
        });
    },
    updateInfo() {
      this.submitStat = true;
      setTimeout(() => {
        updateWarehouseInfo()
          .then(() => {
            this.submitStat = false;
            (this.alterDialog = false),
              this.$store.dispatch("showToastNotify", {
                type: "success",
                info: this.$t("warehouse.Info.alterDone"),
              });
            this.fetchWarehouseInfo();
          })
          .catch((err) => {
            this.queryLoaderDialog = false;
            this.$refs.error_done.updateBody(
              this.$t("common3.transactionFail") + err
            );
            this.$refs.error_done.showAlert();
          });
      }, 1000);
    },
    fetchWarehouseInfo() {
      this.queryLoaderDialog = true;
      setTimeout(() => {
        getWarehouseInfo()
          .then((response) => {
            this.warehouseDetail = response.data;

            this.queryLoaderDialog = false;
            this.$store.dispatch("showToastNotify", {
              type: "success",
              info: this.$t("warehouse.Info.queryDone"),
            });
            let i = 0;
            for (; i < this.warehouseDetail.length; i++) {
              this.warehouseDetail[i].dialogOpen = false;
              this.warehouseDetail[i].storeId = i;
            }
          })
          .catch((err) => {
            this.queryLoaderDialog = false;
            this.$refs.error_done.updateBody(
              this.$t("common3.transactionFail") + err
            );
            this.$refs.error_done.showAlert();
          });
      }, 1000);
    },
    gotoItem() {
      this.$store.dispatch("showToastNotify", {
        type: "default",
        info: this.$t("warehouse.Info.search"),
      });
      this.$router.push({
        name: "WarehouseItemManagement",
        params: { id: "11" },
      });
    },
  },
};
</script>
<style scoped lang="scss">
.zms-stat {
  font-family: "benderregular";
  font-size: 25px;
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
