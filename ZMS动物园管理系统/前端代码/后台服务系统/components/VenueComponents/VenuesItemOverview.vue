<template>
  <div class="zms-anicare" :class="nmNightClass">
    <alert-messagebox
      ref="error_done"
      :alert-title="$t('common3.transactionFailTitle')"
      :alert-body="$t('common3.transactionFail')"
      :alert-level="`error`"
      :alert-only-confirm="true"
    />
    <div class="zms-query-filter">
      <v-icon color="primary"> mdi-filter-plus </v-icon>
      <span class="zms-query-title">查询条件</span>
      <div>
        <v-container>
          <v-row>
            <v-col cols="12" sm="6" md="3">
              <v-text-field
                v-model="searchItem['id']"
                :label="$t('venue.item.id')"
                placeholder="请输入场馆编号"
                prepend-icon="mdi-music-accidental-sharp"
              />
            </v-col>
            <v-col cols="12" sm="6" md="3">
              <v-text-field
                v-model="searchItem['name']"
                :label="$t('venue.item.name')"
                placeholder="请输入场馆名称"
                prepend-icon="mdi-tag"
              />
            </v-col>
            <v-col class="d-flex" cols="12" sm="6" md="3">
              <v-select
                v-model="searchItem['location']"
                :items="venuelocaitems"
                :label="$t('venue.item.location')"
                placeholder="请输入场馆位置"
                prepend-icon="el-icon-location-information"
              />
            </v-col>
            <v-col class="d-flex" cols="12" sm="6" md="3">
              <v-select
                v-model="searchItem['status']"
                :items="items"
                :label="$t('venue.item.status')"
                placeholder="请输入场馆开放状态"
                prepend-icon="mdi-account-key"
              />
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
                <v-icon>mdi-filter</v-icon>&nbsp;&nbsp;查找场馆信息
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
                      {{ $t("venue.item.alter") }}
                    </span>
                  </v-card-title>
                  <v-card-text>
                    <v-container>
                      <v-row>
                        <v-col cols="12" sm="6" md="4">
                          <v-text-field
                            v-model="editedItem['areaId']"
                            disabled
                            :label="$t('venue.item.id')"
                            prepend-icon="el-icon-map-location"
                          />
                        </v-col>
                        <v-col cols="12" sm="6" md="4">
                          <v-text-field
                            v-model="editedItem['name']"
                            :label="$t('venue.item.name')"
                            prepend-icon="el-icon-ship"
                          />
                        </v-col>
                        <v-col cols="12" sm="6" md="4">
                          <v-text-field
                            v-model="editedItem['zone']"
                            :label="$t('venue.item.zone')"
                            prepend-icon="el-icon-goblet-square-full"
                          />
                        </v-col>
                        <v-col class="d-flex" cols="12" sm="6" md="4">
                          <v-select
                            v-model="editedItem['location']"
                            :items="venuelocaitems"
                            :label="$t('venue.item.location')"
                            placeholder="请输入场馆位置"
                            prepend-icon="el-icon-location-information"
                          />
                        </v-col>
                        <v-col cols="12" sm="6" md="4">
                          <v-text-field
                            v-model="editedItem['additionalFee']"
                            :label="$t('venue.item.additional_fee')"
                            prepend-icon="el-icon-s-order"
                          />
                        </v-col>
                        <v-col cols="12" sm="6" md="4">
                          <v-text-field
                            v-model="editedItem['telephone']"
                            :label="$t('venue.item.telephone')"
                            prepend-icon="el-icon-lollipop"
                          />
                        </v-col>
                        <v-col cols="12" sm="6" md="4">
                          <v-text-field
                            v-model="editedItem['touristCapacity']"
                            :label="$t('venue.item.capacity')"
                            prepend-icon="el-icon-goblet-square"
                          />
                        </v-col>
                        <v-col class="d-flex" cols="12" sm="6" md="4">
                          <v-select
                            v-model="editedItem['status']"
                            :items="items"
                            :label="$t('venue.item.status')"
                            prepend-icon="el-icon-cold-drink"
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
            <v-icon small class="mr-2" @click="editItem(item)">
              mdi-pencil
            </v-icon>
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
            {{ $t("venue.item.delete") }}
          </span>
        </v-card-title>
        <v-divider />
        <br />
        <v-card-text>
          <span class="zms-poptip-body">
            {{ $t("venue.item.delete_content") }}
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
            @click="deleteInfo()"
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
import { getVenueItemInfo, updateVenueItemInfo } from "../../apis/venue";
import { deleteVenueItemInfo } from "../../apis/venue";
import AlertMessagebox from "../CommonComponents/AlertMessagebox.vue";
export default {
  name: "VenueItemOverview",
  components: { AlertMessagebox },
  data: () => {
    return {
      headers: [
        { text: "场馆编号", value: "areaId" },
        { text: "场馆名称", value: "name" },
        { text: "场馆简介", value: "introduction" },
        { text: "所属园区", value: "zone" },
        { text: "场馆位置", value: "location" },
        { text: "额外票价", value: "additionalFee" },
        { text: "场馆管理电话", value: "telephone" },
        { text: "场馆游客最大容量", value: "touristCapacity" },
        { text: "场馆开放状态", value: "status" },
        { text: "操作", value: "actions", sortable: false },
      ],
      items: ["开", "关"],
      venueitems: ["食肉动物展区", "火烈鸟展区", "袋鼠坡", "长颈鹿馆"],
      venuelocaitems: ["A区", "B区", "C区", "D区", "E区"],
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
      searchItem: {
        id: null,
        location: null,
        name: null,
        status: null,
      },
      editedItem: {
        id: "",
        name: "",
        zone: "",
        location: "",
        current_tourist_cnt: "",
        status: "",
        telephone: "",
        capacity: "",
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
        getVenueItemInfo({
          areaId: this.searchItem["id"],
          name: this.searchItem["name"],
          location: this.searchItem["location"],
          status: this.searchItem["status"],
        }).then((response) => {
          this.queryData = response.data;
          this.deleteItemInfo();
          this.queryLoaderDialog = false;
          if (this.queryData.length > 0) {
            this.$store.dispatch("showToastNotify", {
              type: "success",
              info: "信息查询成功",
            });
          } else {
            this.$store.dispatch("showToastNotify", {
              type: "error",
              info: this.$t("animalCare.emptyInfo"),
            });
          }
        });
      }, 2000);
    },
    deleteItemInfo() {
      this.searchItem["id"] = null;
      this.searchItem["name"] = null;
      this.searchItem["location"] = null;
      this.searchItem["status"] = null;
    },
    updateItemInfo() {
      if (isNaN(parseInt(this.editedItem["touristCapacity"]))) {
        this.$store.dispatch("showToastNotify", {
          type: "error",
          info: "容量输入无效",
        });
        return;
      }
      if (isNaN(parseInt(this.editedItem["additionalFee"]))) {
        this.$store.dispatch("showToastNotify", {
          type: "error",
          info: "费用输入无效",
        });
        return;
      }
      this.queryLoaderDialog2 = true;
      setTimeout(() => {
        updateVenueItemInfo({
          areaid: this.editedItem["areaId"],
          name: this.editedItem["name"],
          zone: this.editedItem["zone"],
          location: this.editedItem["location"],
          additionalFee: parseInt(this.editedItem["additionalFee"]),
          telephone: this.editedItem["telephone"],
          touristCapacity: parseInt(this.editedItem["touristCapacity"]),
          status: this.editedItem["status"],
        })
          .then(() => {
            this.queryLoaderDialog2 = false;
            this.$store.dispatch("showToastNotify", {
              type: "success",
              info: "信息更新成功",
            });
            this.fetchItemInfo();
            this.close();
          })
          .catch((err) => {
            this.$refs.error_done.updateBody(
              this.$t("common3.transactionFail") + err
            );
            this.$refs.error_done.showAlert();
            this.queryLoaderDialog2 = false;
            this.alterDialog = false;
          });
      }, 2000);
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
    deleteItem(item) {
      this.delIndex = this.queryData.indexOf(item);
      this.delItem = Object.assign({}, item);
      this.deleteDialog = true;
    },
    deleteItemConfirm() {
      this.deleteDialog = false;
      this.queryData.splice(this.delIndex, 1);
      this.closeDelete();
    },
    deleteInfo() {
      this.queryLoaderDialog2 = true;
      setTimeout(() => {
        deleteVenueItemInfo({
          areaid: this.delItem["areaId"],
        })
          .then(() => {
            this.queryLoaderDialog2 = false;
            this.$store.dispatch("showToastNotify", {
              type: "success",
              info: "信息删除成功",
            });
            this.fetchItemInfo();
            this.close();
          })
          .catch(() => {
            this.queryLoaderDialog2 = false;
            this.errorTitle = this.$t("common.error");
            this.errorInfo = "删除失败";
            this.errorReturn = true;
          });
      }, 2000);
    },
    save() {
      if (this.editedIndex > -1) {
        Object.assign(this.queryData[this.editedIndex], this.editedItem);
      } else {
        this.queryData.push(this.editedItem);
      }
      this.close();
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
