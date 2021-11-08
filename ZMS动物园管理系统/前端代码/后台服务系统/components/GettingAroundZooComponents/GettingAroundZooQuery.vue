<template>
  <div class="zms-anicare" :class="nmNightClass">
    <div class="zms-query-filter">
      <v-icon color="primary"> mdi-filter-plus </v-icon>
      <span class="zms-query-title">查询条件</span>
      <div>
        <v-container>
          <v-row>
            <v-col cols="12" sm="6" md="3">
              <v-text-field
                v-model="submit_ID"
                :label="$t('gettingAroundZoo.ID')"
                :placeholder="
                  $t('common.pleaseInput') + $t('gettingAroundZoo.ID')
                "
                prepend-icon="el-icon-view"
              />
            </v-col>
            <v-col cols="12" sm="6" md="3">
              <v-text-field
                v-model="submit_tour_id"
                :label="$t('gettingAroundZoo.tour_id')"
                :placeholder="
                  $t('common.pleaseInput') + $t('gettingAroundZoo.tour_id')
                "
                prepend-icon="el-icon-user-solid"
              />
            </v-col>
            <v-col class="d-flex" cols="12" sm="6" md="3">
              <v-select
                v-model="submit_vehicle_category"
                :items="vehicle_category_items"
                :label="$t('gettingAroundZoo.vehicle_category')"
                prepend-icon="el-icon-link"
              />
            </v-col>
            <v-col class="d-flex" cols="12" sm="6" md="3">
              <v-select
                v-model="submit_ticket_type"
                :items="admissitems"
                :label="$t('gettingAroundZoo.ticket_type')"
                prepend-icon="el-icon-s-operation"
              />
            </v-col>
            <v-col cols="12" sm="6" md="3">
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
                    v-model="submit_date"
                    :label="$t('gettingAroundZoo.date')"
                    prepend-icon="mdi-calendar"
                    readonly
                    v-bind="attrs"
                    v-on="on"
                  />
                </template>
                <v-date-picker
                  v-model="submit_date"
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
            <v-col cols="12" sm="6" md="3" />
            <v-col cols="12" sm="6" md="3">
              <v-btn
                v-ripple
                :disabled="queryLoaderDialog === true"
                block
                class="zms-width"
                color="error"
                @click="deleteItemInfo"
              >
                <v-icon>mdi-filter-minus</v-icon>&nbsp;&nbsp;删除过滤条件
              </v-btn>
            </v-col>
            <v-col cols="12" sm="6" md="3">
              <v-btn
                v-ripple
                :disabled="queryLoaderDialog === true"
                block
                class="zms-width"
                color="primary"
                @click="fetchItemInfo"
              >
                <v-icon>mdi-filter</v-icon>&nbsp;&nbsp;按条件查找
              </v-btn>
            </v-col>
          </v-row>
        </v-container>
      </div>
    </div>
    <v-divider />
    <div class="zms-query-result">
      <v-icon color="primary"> mdi-note-search </v-icon>
      <span class="zms-query-title">查询结果</span>
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
              <v-toolbar-title>查询结果</v-toolbar-title>
              <v-spacer />
              <v-dialog v-model="dialog" max-width="600px" persistent>
                <v-card :ripple="{ class: null }">
                  <v-card-title
                    class="zms-strip-bg text-h5 text--white primary"
                    color="warning"
                  >
                    <v-icon color="white"> mdi-pen </v-icon>&nbsp;<span
                      class="text--white"
                      style="color: #ffffff !important"
                    >
                      {{ $t("gettingAroundZoo.itemAlter") }}
                    </span>
                  </v-card-title>
                  <v-card-text>
                    <v-container>
                      <v-row>
                        <v-col cols="12" sm="6" md="4">
                          <v-text-field
                            v-model="editedItem['ID']"
                            :label="$t('gettingAroundZoo.ID')"
                          />
                        </v-col>
                        <v-col cols="12" sm="6" md="4">
                          <v-text-field
                            v-model="editedItem['tour_id']"
                            :label="$t('gettingAroundZoo.tour_id')"
                          />
                        </v-col>
                        <v-col cols="12" sm="6" md="4">
                          <v-text-field
                            v-model="editedItem['vehicle_category']"
                            :label="$t('gettingAroundZoo.vehicle_category')"
                          />
                        </v-col>
                        <v-col cols="12" sm="6" md="4">
                          <v-text-field
                            v-model="editedItem['price']"
                            :label="$t('gettingAroundZoo.price')"
                          />
                        </v-col>
                        <v-col class="d-flex" cols="12" sm="6" md="3">
                          <v-select
                            v-model="editedItem['ticket_type']"
                            :items="admissitems"
                            :label="$t('gettingAroundZoo.ticket_type')"
                            prepend-icon="el-icon-s-operation"
                          />
                        </v-col>
                        <v-col cols="12" sm="6" md="4">
                          <v-text-field
                            v-model="editedItem['deposit']"
                            :label="$t('gettingAroundZoo.deposit')"
                          />
                        </v-col>
                        <v-col cols="12" sm="6" md="4">
                          <v-text-field
                            v-model="editedItem['age_limit']"
                            :label="$t('gettingAroundZoo.age_limit')"
                          />
                        </v-col>
                        <v-col cols="12" sm="6" md="4">
                          <v-text-field
                            v-model="editedItem['weight_limit']"
                            :label="$t('gettingAroundZoo.weight_limit')"
                          />
                        </v-col>
                        <v-col cols="12" sm="6" md="4">
                          <v-text-field
                            v-model="editedItem['rental_duration']"
                            :label="$t('gettingAroundZoo.rental_duration')"
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
                      @click="close()"
                    >
                      <v-icon>mdi-close</v-icon> {{ $t("common.cancel") }}
                    </v-btn>
                    <v-btn
                      class="zms-fullwidth"
                      v-bind="attrs"
                      light
                      color="success"
                      v-on="on"
                      @click="updateItemInfo()"
                    >
                      <v-icon>mdi-check</v-icon> {{ $t("common.confirm") }}
                    </v-btn>
                  </v-card-actions>
                </v-card>
              </v-dialog>
            </v-toolbar>
          </template>
          <template v-slot:[`item.actions`]="{ item }">
            <v-icon small class="mr-2" @click="deleteItem(item)">
              mdi-delete
            </v-icon>
          </template>
        </v-data-table>
      </div>
      <div class="zms-query-pagination">
        <v-pagination v-model="page" :length="pageCount" />
      </div>
    </div>
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
    <v-dialog v-model="queryLoaderDialog2" persistent width="300">
      <v-card color="">
        <v-card-title>正在提交</v-card-title>
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
            {{ errorTitle }}</span
          >
        </v-card-title>
        <v-divider />
        <br />
        <v-card-text>
          <span class="zms-poptip-body"> {{ errorInfo }}</span> <br />
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
    <v-dialog v-model="deleteDialog" persistent width="600">
      <v-card color="" :ripple="{ class: null }">
        <v-card-title
          class="zms-strip-bg text-h5 text--white orange darken-3"
          color="warning"
        >
          <v-icon color="white"> mdi-close-thick </v-icon>&nbsp;<span
            class="text--white"
            style="color: #ffffff !important"
          >
            {{ $t("gettingAroundZoo.delete") }}</span
          >
        </v-card-title>
        <v-divider />
        <br />
        <v-card-text>
          <span class="zms-poptip-body">
            {{ $t("gettingAroundZoo.delete_content") }}</span
          >
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
            @click="deleteItemconfirm()"
          >
            <v-icon>mdi-exclamation</v-icon> {{ $t("common.confirm") }}
          </v-btn>
          <v-btn
            class="zms-fullwidth"
            v-bind="attrs"
            light
            color="error"
            v-on="on"
            @click="close()"
          >
            <v-icon>mdi-arrow-left</v-icon> {{ $t("common.cancel") }}
          </v-btn>
        </v-card-actions>
      </v-card>
    </v-dialog>
  </div>
</template>
<script>
import {
  getGettingAroundZooFlowInfo,
  deleteGettingAroundZooFlowInfo,
  updateGettingAroundZooInfo,
} from "../../apis/gettingAroundZoo";
export default {
  name: "GettingAroundZooQuery",
  data: () => {
    return {
      submit_ID: null,
      submit_tour_id: null,
      submit_vehicle_category: null,
      submit_price: null,
      submit_ticket_type: null,
      submit_deposit: null,
      submit_age_limit: null,
      submit_weight_limit: null,
      submit_rental_duration: null,
      submit_date: null,
      headers: [
        { text: "订单号", value: "id" },
        { text: "客户编号", value: "tourId" },
        { text: "交通工具类别", value: "vehicleCategory" },
        { text: "票种", value: "ticketType" },
        { text: "入园日期", value: "date" },
        { text: "操作", value: "actions", sortable: false },
      ],
      admissitems: ["全价票", "优惠票"],
      vehicle_category_items: ["环园小火车", "空中缆车", "观光马车"],
      min: 0,
      max: 500,
      slider: 400,
      queryLoaderDialog: false,
      pageCount: 0,
      page: 1,
      dialog: false,
      queryData: [],
      editedIndex: -1,
      delIndex: -1,
      queryLoaderDialog2: false,
      deleteDialog: false,
      errorReturn: false,
      errorTitle: "",
      errorInfo: "",
      editedItem: {
        ID: "",
        tour_id: 0,
        vehicle_category: 0,
        ticket_type: 0,
        date: 0,
      },
      delItem: {
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
    if (this.$route.params.id != undefined) {
      this.fetchItemInfo();
    }
  },
  methods: {
    fetchItemInfo() {
      this.queryLoaderDialog = true;
      setTimeout(() => {
        getGettingAroundZooFlowInfo({
          ID: this.submit_ID,
          tour_id: this.submit_tour_id,
          vehicle_category: this.submit_vehicle_category,
          price: this.submit_price,
          date: this.submit_date,
          ticket_type: this.submit_ticket_type,
        })
          .then((response) => {
            for (let i = 0; i < response.data.length; i++) {
              response.data[i].date = response.data[i].date.substring(0, 10);
            }
            this.queryData = response.data;
            this.queryLoaderDialog = false;
            if (this.queryData.length > 0) {
              this.$store.dispatch("showToastNotify", {
                type: "success",
                info: "信息查询成功",
              });
            } else {
              this.$store.dispatch("showToastNotify", {
                type: "error",
                info: this.$t("未找到符合条件的选项"),
              });
            }
          })
          .catch((err) => {
            this.queryLoaderDialog = false;
            this.$store.dispatch("showToastNotify", {
              type: "error",
              info: this.$t("信息查询失败" + err),
            });
          });
      }, 2000);
    },
    updateItemInfo() {
      this.queryLoaderDialog2 = true;
      setTimeout(() => {
        updateGettingAroundZooInfo({
          ID: this.editedItem["ID"],
          tour_id: this.editedItem["tour_id"],
          vehicle_category: this.editedItem["vehicle_category"],
          price: this.editedItem["price"],
          ticket_type: this.editedItem["ticket_type"],
          date: this.editedItem["ticket_type"],
        })
          .then((response) => {
            this.queryLoaderDialog2 = false;
            if (response.data.statcode != 0) {
              this.errorTitle = this.$t("common.error");
              this.errorInfo = this.$t("warehouse.Info.generalError");
              this.errorReturn = true;
              return 0;
            }
            this.$store.dispatch("showToastNotify", {
              type: "success",
              info: "信息更新成功",
            });
            this.close();
            getGettingAroundZooFlowInfo({
              ID: this.submit_ID,
              tour_id: this.submit_tour_id,
              vehicle_category: this.submit_vehicle_category,
              price: this.submit_price,
              date: this.submit_date,
              ticket_type: this.submit_ticket_type,
            })
              .then((response) => {
                for (let i = 0; i < response.data.length; i++) {
                  response.data[i].date = response.data[i].date.substring(
                    0,
                    10
                  );
                }
                this.queryData = response.data;
              })
              .catch(() => {});
          })
          .catch((err) => {
            this.queryLoaderDialog = false;
            this.$store.dispatch("showToastNotify", {
              type: "error",
              info: this.$t("信息更新失败" + err),
            });
          });
      }, 2000);
    },
    deleteItem(item) {
      this.delIndex = this.queryData.indexOf(item);
      this.delItem = Object.assign({}, item);
      this.deleteDialog = true;
    },
    deleteItemconfirm() {
      this.deleteDialog = true;
      setTimeout(() => {
        deleteGettingAroundZooFlowInfo({
          ID: this.delItem["id"],
        })
          .then(() => {
            this.deleteDialog = false;
            this.$store.dispatch("showToastNotify", {
              type: "success",
              info: "信息删除成功",
            });
            this.close();
            getGettingAroundZooFlowInfo({
              ID: this.submit_ID,
              tour_id: this.submit_tour_id,
              vehicle_category: this.submit_vehicle_category,
              price: this.submit_price,
              date: this.submit_date,
              ticket_type: this.submit_ticket_type,
            })
              .then((response) => {
                for (let i = 0; i < response.data.length; i++) {
                  response.data[i].date = response.data[i].date.substring(
                    0,
                    10
                  );
                }
                this.queryData = response.data;
              })
              .catch(() => {});
          })
          .catch((err) => {
            this.queryLoaderDialog = false;
            this.$store.dispatch("showToastNotify", {
              type: "error",
              info: "信息删除失败" + err,
            });
          });
      }, 2000);
    },
    deleteItemInfo() {
      this.submit_ID = null;
      this.submit_vehicle_category = null;
      this.submit_price = null;
      this.submit_ticket_type = null;
      this.submit_deposit = null;
      this.submit_age_limit = null;
      this.submit_weight_limit = null;
      this.submit_rental_duration = null;
      this.submit_tour_id = null;
      this.submit_vehicle_category = null;
      this.submit_date = null;
    },
    close() {
      this.dialog = false;
      this.deleteDialog = false;
      this.$nextTick(() => {
        this.editedItem = Object.assign({}, this.defaultItem);
        this.editedIndex = -1;
        this.delIndex = -1;
        this.delItem = Object.assign({}, this.defaultItem);
      });
    },
    editItem(item) {
      this.editedIndex = this.queryData.indexOf(item);
      this.editedItem = Object.assign({}, item);
      this.dialog = true;
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
  margin-top: 20px;
}
.zms-anicare {
  padding-left: 50px;
  padding-right: 50px;
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
</style>
