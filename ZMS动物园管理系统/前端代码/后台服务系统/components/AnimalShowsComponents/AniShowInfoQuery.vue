<!---训练信息管理--->
<template>
  <div class="zms-anishowinfo" :class="nmNightClass">
    <div class="zms-query-filter">
      <v-icon color="primary"> mdi-filter-plus </v-icon>
      <span class="zms-query-title">查询条件</span>
      <div>
        <v-container>
          <v-row>
            <!---训练编号--->
            <v-col cols="12" sm="6" md="3">
              <v-text-field
                v-model="submit_show_id"
                :label="$t('animalShow.show_id')"
                :placeholder="
                  $t('common.pleaseInput') + $t('animalShow.show_id')
                "
                prepend-icon="mdi-music-accidental-sharp"
              />
            </v-col>
            <!---动物编号--->
            <v-col cols="12" sm="6" md="3">
              <v-text-field
                v-model="submit_show_name"
                :label="$t('animalShow.show_name')"
                :placeholder="
                  $t('common.pleaseInput') + $t('animalShow.show_name')
                "
                prepend-icon="el-icon-view"
              />
            </v-col>
            <!---训练员工编号--->
            <v-col cols="12" sm="6" md="3">
              <v-text-field
                v-model="submit_principal_id"
                :label="$t('负责人姓名')"
                :placeholder="$t('common.pleaseInput') + $t('负责人姓名')"
                prepend-icon="el-icon-s-custom"
              />
            </v-col>
            <!---训练地点--->
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
                    v-model="submit_show_date"
                    :label="$t('animalShow.show_date')"
                    prepend-icon="mdi-calendar"
                    readonly
                    v-bind="attrs"
                    v-on="on"
                  />
                </template>
                <v-date-picker
                  v-model="submit_show_date"
                  color="primary"
                  width="400"
                  @input="menu2 = false"
                />
              </v-menu>
              <!---训练日期--->
            </v-col>
            <v-col class="d-flex" cols="12" sm="6" md="3">
              <v-select
                v-model="submit_start_time"
                :items="start_time_items"
                :label="$t('animalShow.start_time')"
                prepend-icon="el-icon-sort-up"
              />
            </v-col>
            <!---训练技能--->
            <v-col class="d-flex" cols="12" sm="6" md="3">
              <v-select
                v-model="submit_end_time"
                :items="end_time_items"
                :label="$t('animalShow.end_time')"
                prepend-icon="el-icon-sort-down"
              />
            </v-col>
            <v-col cols="12" sm="6" md="3">
              <v-text-field
                v-model="submit_show_site"
                :label="$t('animalShow.show_site')"
                :placeholder="
                  $t('common.pleaseInput') + $t('animalShow.show_site')
                "
                prepend-icon="el-icon-position"
              />
              <!---训练道具--->
            </v-col>
            <v-col cols="12" sm="6" md="3">
              <v-text-field
                v-model="submit_show_props"
                :label="$t('animalShow.show_props')"
                :placeholder="
                  $t('common.pleaseInput') + $t('animalShow.show_props')
                "
                prepend-icon="el-icon-box"
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
                      {{ $t("animalShow.itemAlter") }}
                    </span>
                  </v-card-title>
                  <!---查询结果输出--->
                  <v-card-text>
                    <v-container>
                      <v-row>
                        <!---训练编号--->
                        <v-col cols="12" sm="6" md="4">
                          <v-text-field
                            v-model="editedItem['showId']"
                            disabled
                            :label="$t('animalShow.show_id')"
                          />
                        </v-col>
                        <!---训练姓名--->
                        <v-col cols="12" sm="6" md="4">
                          <v-text-field
                            v-model="editedItem['showName']"
                            :label="$t('animalShow.show_name')"
                          />
                        </v-col>
                        <v-col cols="12" sm="6" md="4">
                          <v-text-field
                            v-model="editedItem['principalName']"
                            :label="$t('负责人姓名')"
                          />
                        </v-col>
                        <!---训练时间--->
                        <v-col cols="12" sm="6" md="3">
                          <v-menu
                            v-model="menu5"
                            :close-on-content-click="false"
                            :nudge-right="40"
                            transition="scale-transition"
                            offset-y
                            min-width="290px"
                          >
                            <template v-slot:activator="{ on, attrs }">
                              <v-text-field
                                v-model="editedItem['showDate']"
                                :label="$t('animalShow.show_date')"
                                readonly
                                v-bind="attrs"
                                v-on="on"
                              />
                            </template>
                            <v-date-picker
                              v-model="editedItem['showDate']"
                              color="primary"
                              width="400"
                              @input="menu5 = false"
                            />
                          </v-menu>
                        </v-col>
                        <!---开始时间--->
                        <v-col cols="12" sm="6" md="3">
                          <v-menu
                            v-model="menu6"
                            :close-on-content-click="false"
                            :nudge-right="40"
                            transition="scale-transition"
                            offset-y
                            min-width="290px"
                          >
                            <template v-slot:activator="{ on, attrs }">
                              <v-text-field
                                v-model="editedItem['startTime']"
                                :label="$t('animalShow.start_time')"
                                readonly
                                v-bind="attrs"
                                v-on="on"
                              />
                            </template>
                            <v-time-picker
                              v-model="editedItem['startTime']"
                              format="24hr"
                              color="primary"
                              width="400"
                              @input="menu6 = false"
                            />
                          </v-menu>
                        </v-col>
                        <!---结束时间--->
                        <v-col cols="12" sm="6" md="3">
                          <v-menu
                            v-model="menu7"
                            :close-on-content-click="false"
                            :nudge-right="40"
                            transition="scale-transition"
                            offset-y
                            min-width="290px"
                          >
                            <template v-slot:activator="{ on, attrs }">
                              <v-text-field
                                v-model="editedItem['endTime']"
                                :label="$t('animalShow.end_time')"
                                readonly
                                v-bind="attrs"
                                v-on="on"
                              />
                            </template>
                            <v-time-picker
                              v-model="editedItem['endTime']"
                              format="24hr"
                              color="primary"
                              width="400"
                              @input="menu7 = false"
                            />
                          </v-menu>
                        </v-col>
                        <!---训练技能--->
                        <v-col cols="12" sm="6" md="4">
                          <v-text-field
                            v-model="editedItem['showSite']"
                            :label="$t('animalShow.show_site')"
                          />
                        </v-col>
                        <!---训练道具--->
                        <v-col cols="12" sm="6" md="4">
                          <v-text-field
                            v-model="editedItem['showProps']"
                            :label="$t('animalShow.show_props')"
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
          <!---查找按钮--->
          <template v-slot:[`item.actions`]="{ item }">
            <v-icon small class="mr-2" @click="editItem(item)">
              mdi-pencil
            </v-icon>
            <!---删除按钮--->
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
    <!---查找进度条--->
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
            {{ $t("animalShow.delete") }}</span
          >
        </v-card-title>
        <v-divider />
        <br />
        <v-card-text>
          <span class="zms-poptip-body">
            {{ $t("animalShow.delete_content") }}</span
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
  getShowData,
  updateShowInfo,
  deleteShowInfo,
} from "../../apis/animalShow";
export default {
  name: "AniShowInfoQuery",
  data: () => {
    //提交信息
    return {
      submit_show_id: null,
      submit_show_name: null,
      submit_principal_id: null,
      submit_show_date: null,
      submit_start_time: null,
      submit_end_time: null,
      submit_show_site: null,
      submit_show_props: null,
      start_time_items: ["14：00", "17：00"],
      end_time_items: ["18：00", "21：00"],
      headers: [
        { text: "演出编号", value: "showId" },
        { text: "演出名称", value: "showName" },
        { text: "负责人姓名", value: "principalName" },
        { text: "演出日期", value: "showDate" },
        { text: "开始时间", value: "startTime" },
        { text: "结束时间", value: "endTime" },
        { text: "演出场地", value: "showSite" },
        { text: "演出道具", value: "showProps" },
        { text: "操作", value: "actions", sortable: false },
      ],
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
      //编辑信息
      editedItem: {
        show_id: "",
        show_name: "",
        principal_id: 0,
        show_date: 0,
        start_time: 0,
        end_time: 0,
        show_site: 0,
        show_props: 0,
      },
      //删除信息
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
    //返回输入值
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
    //返回查找信息接口
    fetchItemInfo() {
      this.queryLoaderDialog = true;
      setTimeout(() => {
        getShowData({
          show_id: this.submit_show_id,
          show_name: this.submit_show_name,
          principal_id: this.submit_principal_id,
          show_date: this.submit_show_date,
          start_time: this.submit_start_time,
          end_time: this.submit_end_time,
          show_site: this.submit_show_site,
          show_props: this.submit_show_props,
        })
          .then((response) => {
            for (let i = 0; i < response.data.length; i++) {
              response.data[i].showDate = response.data[i].showDate.substring(
                0,
                10
              );
              response.data[i].startTime = response.data[i].startTime.substring(
                11,
                16
              );
              response.data[i].endTime = response.data[i].endTime.substring(
                11,
                16
              );
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
              info: this.$t("信息查询失败") + err,
            });
          });
      }, 2000);
    },
    //更新信息接口
    updateItemInfo() {
      this.queryLoaderDialog2 = true;
      setTimeout(() => {
        updateShowInfo({
          show_id: this.editedItem["showId"],
          show_name: this.editedItem["showName"],
          principal_id: this.editedItem["principalName"],
          show_date: this.editedItem["showDate"],
          start_time: this.editedItem["startTime"],
          end_time: this.editedItem["endTime"],
          show_site: this.editedItem["showSite"],
          show_props: this.editedItem["showProps"],
        })
          .then(() => {
            this.queryLoaderDialog2 = false;
            this.dialog = false;
            this.$store.dispatch("showToastNotify", {
              type: "success",
              info: "信息更新成功",
            });
            getShowData({
              show_id: this.submit_show_id,
              show_name: this.submit_show_name,
              principal_id: this.submit_principal_id,
              show_date: this.submit_show_date,
              start_time: this.submit_start_time,
              end_time: this.submit_end_time,
              show_site: this.submit_show_site,
              show_props: this.submit_show_props,
            })
              .then((response) => {
                for (let i = 0; i < response.data.length; i++) {
                  response.data[i].showDate = response.data[
                    i
                  ].showDate.substring(0, 10);
                  response.data[i].startTime = response.data[
                    i
                  ].startTime.substring(11, 19);
                  response.data[i].endTime = response.data[i].endTime.substring(
                    11,
                    19
                  );
                }
                this.queryData = response.data;
              })
              .catch(() => {});
          })
          .catch((err) => {
            this.queryLoaderDialog2 = false;
            this.$store.dispatch("showToastNotify", {
              type: "error",
              info: this.$t("信息更新失败") + err,
            });
          });
      }, 2000);
    },
    deleteItem(item) {
      this.delIndex = this.queryData.indexOf(item);
      this.delItem = Object.assign({}, item);
      //this.dialog = true
      this.deleteDialog = true;
    },
    //删除信息接口
    deleteItemconfirm() {
      this.queryLoaderDialog2 = true;
      setTimeout(() => {
        deleteShowInfo({
          show_id: this.delItem["showId"],
        })
          .then(() => {
            this.deleteDialog = false;
            this.queryLoaderDialog2 = false;
            this.$store.dispatch("showToastNotify", {
              type: "success",
              info: "信息删除成功",
            });
            this.close();
            getShowData({
              show_id: this.submit_show_id,
              show_name: this.submit_show_name,
              principal_id: this.submit_principal_id,
              show_date: this.submit_show_date,
              start_time: this.submit_start_time,
              end_time: this.submit_end_time,
              show_site: this.submit_show_site,
              show_props: this.submit_show_props,
            })
              .then((response) => {
                for (let i = 0; i < response.data.length; i++) {
                  response.data[i].showDate = response.data[
                    i
                  ].showDate.substring(0, 10);
                  response.data[i].startTime = response.data[
                    i
                  ].startTime.substring(11, 19);
                  response.data[i].endTime = response.data[i].endTime.substring(
                    11,
                    19
                  );
                }
                this.queryData = response.data;
              })
              .catch(() => {});
          })
          .catch((err) => {
            this.deleteDialog = false;
            this.queryLoaderDialog2 = false;
            this.$store.dispatch("showToastNotify", {
              type: "error",
              info: this.$t("信息删除失败") + err,
            });
          });
      }, 2000);
    },
    //清空后赋值
    deleteItemInfo() {
      this.submit_show_id = null;
      this.submit_show_name = null;
      this.submit_show_date = null;
      this.submit_start_time = null;
      this.submit_end_time = null;
      this.submit_show_site = null;
      this.submit_position = null;
      this.submit_show_props = null;
    },
    //关闭窗口
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
.zms-anishowinfo {
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
