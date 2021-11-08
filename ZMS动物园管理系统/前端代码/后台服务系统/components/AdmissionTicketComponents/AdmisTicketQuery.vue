<template>
  <div class="zms-anicare" :class="nmNightClass">
    <!--查询部分-->
    <div class="zms-query-filter">
      <v-icon color="primary"> mdi-filter-plus </v-icon>
      <span class="zms-query-title">查询条件</span>
      <div>
        <v-container fluid>
          <v-row>
            <v-col class="d-flex" cols="12" sm="6" md="3">
              <v-select
                v-model="searchItem['seType']"
                :items="admissitems"
                label="票种"
                prepend-icon="el-icon-files"
              />
            </v-col>

            <v-col cols="12" sm="6" md="3">
              <v-text-field
                v-model="searchItem['sePrice']"
                :label="$t('admissionTicketsManagement.admis_price')"
                :placeholder="
                  $t('common.pleaseInput') +
                  $t('admissionTicketsManagement.admis_price')
                "
                prepend-icon="el-icon-coin"
              />
            </v-col>

            <v-col cols="12" sm="6" md="3">
              <v-menu
                v-model="menu8"
                :close-on-content-click="false"
                :nudge-right="40"
                transition="scale-transition"
                offset-y
                min-width="290px"
              >
                <template v-slot:activator="{ on, attrs }">
                  <v-text-field
                    v-model="searchItem['seStart_time']"
                    :label="$t('admissionTicketsManagement.admis_starttime')"
                    prepend-icon="el-icon-time"
                    readonly
                    v-bind="attrs"
                    v-on="on"
                  />
                </template>
                <v-time-picker
                  v-model="searchItem['seStart_time']"
                  format="24hr"
                  color="primary"
                  width="400"
                  @input="menu8 = false"
                />
              </v-menu>
            </v-col>
            <v-col cols="12" sm="6" md="3">
              <v-menu
                v-model="menu4"
                :close-on-content-click="false"
                :nudge-right="40"
                transition="scale-transition"
                offset-y
                min-width="290px"
              >
                <template v-slot:activator="{ on, attrs }">
                  <v-text-field
                    v-model="searchItem['seEnd_time']"
                    :label="$t('admissionTicketsManagement.admis_endtime')"
                    prepend-icon="el-icon-time"
                    readonly
                    v-bind="attrs"
                    v-on="on"
                  />
                </template>
                <v-time-picker
                  v-model="searchItem['seEnd_time']"
                  format="24hr"
                  color="primary"
                  width="400"
                  @input="menu3 = false"
                />
              </v-menu>
            </v-col>

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
                    v-model="searchItem['seenterdate']"
                    :label="$t('admissionTicketsManagement.admis_date')"
                    prepend-icon="mdi-calendar"
                    readonly
                    v-bind="attrs"
                    v-on="on"
                  />
                </template>
                <v-date-picker
                  v-model="searchItem['seenterdate']"
                  color="primary"
                  width="400"
                  @input="menu5 = false"
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
                <v-icon>mdi-filter</v-icon>&nbsp;&nbsp;查找门票记录
              </v-btn>
            </v-col>
          </v-row>
        </v-container>
      </div>
    </div>
    <v-divider />
    <!--查询结果部分-->
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
              <!--查询结果提示框-->
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
                      {{ $t("admissTickets.item.alter") }}
                    </span>
                  </v-card-title>

                  <v-card-text>
                    <v-container fluid>
                      <v-row>
                        <v-col cols="12" sm="6" md="4">
                          <v-text-field
                            v-model="editedItem['id']"
                            :label="$t('admissionTicketsManagement.admis_id')"
                          />
                        </v-col>
                        <v-col cols="12" sm="6" md="4">
                          <v-text-field
                            v-model="editedItem['tourId']"
                            :label="
                              $t('admissionTicketsManagement.admistour_id')
                            "
                          />
                        </v-col>
                        <v-col class="d-flex" cols="12" sm="6" md="4">
                          <v-select
                            v-model="editedItem['ticketType']"
                            :items="admissitems"
                            label="票种"
                            prepend-icon="el-icon-files"
                          />
                        </v-col>
                        <v-col cols="12" sm="6" md="4">
                          <v-text-field
                            v-model="editedItem['price']"
                            :label="
                              $t('admissionTicketsManagement.admis_price')
                            "
                          />
                        </v-col>

                        <v-col cols="12" sm="6" md="4">
                          <v-menu
                            v-model="menu8"
                            :close-on-content-click="false"
                            :nudge-right="40"
                            transition="scale-transition"
                            offset-y
                            min-width="290px"
                          >
                            <template v-slot:activator="{ on, attrs }">
                              <v-text-field
                                v-model="editedItem['startTime']"
                                :label="
                                  $t(
                                    'admissionTicketsManagement.admis_starttime'
                                  )
                                "
                                prepend-icon="el-icon-time"
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
                              @input="menu3 = false"
                            />
                          </v-menu>
                        </v-col>
                        <v-col cols="12" sm="6" md="4">
                          <v-menu
                            v-model="menu9"
                            :close-on-content-click="false"
                            :nudge-right="40"
                            transition="scale-transition"
                            offset-y
                            min-width="290px"
                          >
                            <template v-slot:activator="{ on, attrs }">
                              <v-text-field
                                v-model="editedItem['endTime']"
                                :label="
                                  $t('admissionTicketsManagement.admis_endtime')
                                "
                                prepend-icon="el-icon-time"
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
                              @input="menu3 = false"
                            />
                          </v-menu>
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
                                v-model="editedItem['enteringDate']"
                                :label="
                                  $t('admissionTicketsManagement.admis_date')
                                "
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
                      @click="updateItemInfo(), save()"
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
    <!--进度条-->
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
    <!--错误对话框-->
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
    <!--删除对话框-->
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
            {{ $t("admissTickets.item.delete") }}
          </span>
        </v-card-title>
        <v-divider />
        <br />
        <v-card-text>
          <span class="zms-poptip-body">
            {{ $t("admissTickets.item.delete_content") }}
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
            @click="deleteadmissItemInfo()"
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
// API导入
import {
  getAdmissData,
  updateAdmissInfo,
  deleteAdmissInfo,
} from "../../apis/TicketsAdmiss";

//Vue组件内容
export default {
  name: "TicketsAdmissItemOverview",
  data: () => {
    return {
      //Vuetify组件表格标头
      headers: [
        { text: "订单号", value: "id" },
        { text: "游客账号", value: "tourId" },
        { text: "票种", value: "ticketType" },
        { text: "票价", value: "price" },
        { text: "入园开始时间", value: "startTime" },
        { text: "入园结束时间", value: "endTime" },
        { text: "入园日期", value: "enteringDate" },
        { text: "操作", value: "actions" },
      ],
      //门票类型
      admissitems: [
        "全价票",
        "儿童票",
        "长者票",
        "优待票",
        "学生票",
        "夜场票",
        "畅想套票（全价）",
        "畅想套票（优惠）",
        "畅想套票（学生）",
      ],
      //表格及辅助组件参数
      Id: null,
      tour_id: null,
      Type: null,
      Price: null,
      Date: null,
      Note: null,
      Stat: null,
      Sat: null,
      End_time: null,
      Start_time: null,
      enterdate: null,
      noNoteWarning: false,
      errorReturn: false,
      errorTitle: "",
      errorInfo: "",
      menu2: false,
      queryLoaderDialog: false,
      pageCount: 0,
      page: 1,
      dialog: false,
      //表格正文内容
      queryData: [
        {
          id: null,
          tourId: null,
        },
      ],
      //编辑和修改辅助变量
      editedIndex: -1,
      delIndex: -1,
      queryLoaderDialog2: false,
      deleteDialog: false,
      searchItem: {
        seType: null,
        sePrice: null,
        seStart_time: null,
        seEnd_time: null,
        seenterdate: null,
      },
      //编辑暂存对象
      editedItem: {
        id: "",
        tourId: "",
        ticketType: "",
        price: "",
        startTime: "",
        endTime: "",
        enteringDate: "",
      },
      //删除暂存对象
      delItem: {
        admis_id: "",
        admistour_id: "",
        admis_type: "",
        admis_price: "",
        admis_starttime: "",
        admis_endtime: "",
        admis_date: null,
      },
      //临时存储对象
      defaultItem: {
        admis_id: "",
        admistour_id: "",
        admis_type: "",
        admis_price: "",
        admis_starttime: "",
        admis_endtime: "",
        admis_date: "",
      },
    };
  },
  computed: {
    //夜间模式应用（附加）
    cardNightClass() {
      return {
        "zms-cardcolor-light": !this.$vuetify.theme.dark,
        "zms-cardcolor-dark": this.$vuetify.theme.dark,
      };
    },
    //夜间模式应用（附加）
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
    //加载项目
    fetchItemInfo() {
      this.queryLoaderDialog = true;
      setTimeout(() => {
        getAdmissData({
          type: this.searchItem["seType"],
          price: this.searchItem["sePrice"],
          starttime: this.searchItem["seStart_time"],
          endtime: this.searchItem["seEnd_time"],
          date: this.searchItem["seenterdate"],
        })
          .then((response) => {
            for (let i = 0; i < response.data.length; i++) {
              response.data[i].enteringDate = response.data[
                i
              ].enteringDate.substring(0, 10);
              response.data[i].startTime = response.data[i].startTime.substring(
                11,
                19
              );
              response.data[i].endTime = response.data[i].endTime.substring(
                11,
                19
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
                info: "无法找到信息",
              });
            }
          })
          .catch(() => {
            this.queryLoaderDialog = false;
          });
      }, 2000);
    },
    //删除项目
    deleteadmissItemInfo() {
      this.queryLoaderDialog2 = true;
      this.deleteDialog = true;
      setTimeout(() => {
        deleteAdmissInfo({
          id: this.delItem["id"],
        })
          .then(() => {
            this.queryLoaderDialog2 = false;

            this.$store.dispatch("showToastNotify", {
              type: "success",
              info: "信息修改成功",
            });
            this.fetchItemInfo();
            this.close();
          })
          .catch(() => {
            this.queryLoaderDialog2 = false;
            this.errorTitle = this.$t("common.error");
            this.errorInfo = this.$t("warehouse.Info.generalError");
            this.errorReturn = true;
          });
      }, 2000);
    },
    //清空暂存对象
    deleteItemInfo() {
      this.searchItem["seType"] = null;
      this.searchItem["sePrice"] = null;
      this.searchItem["seStart_time"] = null;
      this.searchItem["seEnd_time"] = null;
      this.searchItem["seenterdate"] = null;
    },
    //更新项目
    updateItemInfo() {
      this.queryLoaderDialog2 = true;
      setTimeout(() => {
        updateAdmissInfo({})
          .then((response) => {
            this.queryLoaderDialog2 = false;
            if (response.data.statcode != 0) {
              this.errorTitle = this.$t("common.error");
              this.errorInfo = this.$t("admissTickets.Info.generalError");
              this.errorReturn = true;
              return 0;
            }
            this.$store.dispatch("showToastNotify", {
              type: "success",
              info: "信息查询成功",
            });
            this.close();
          })
          .catch(() => {
            this.queryLoaderDialog2 = false;
          });
      }, 2000);
    },
    //关闭弹出窗口(V-Card)
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
    //编辑项目
    editItem(item) {
      this.editedIndex = this.queryData.indexOf(item);
      this.editedItem = Object.assign({}, item);
      this.dialog = true;
    },
    //删除项目
    deleteItem(item) {
      this.delIndex = this.queryData.indexOf(item);
      this.delItem = Object.assign({}, item);

      this.deleteDialog = true;
    },
    //删除项目确认
    deleteItemConfirm() {
      this.deleteDialog = false;
      this.queryData.splice(this.delIndex, 1);
      this.closeDelete();
    },
    //信息保存
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
