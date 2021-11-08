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
                v-model="searchItem['eId']"
                :label="$t('employeecheck.item.employee_id')"
                :placeholder="
                  $t('common.pleaseInput') +
                  $t('employeecheck.item.employee_id')
                "
                prepend-icon="el-icon-files"
              />
            </v-col>
            <v-col cols="12" sm="6" md="3">
              <v-text-field
                v-model="searchItem['mId']"
                :label="$t('employeecheck.item.manager_id')"
                :placeholder="
                  $t('common.pleaseInput') + $t('employeecheck.item.manager_id')
                "
                prepend-icon="el-icon-document-copy"
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
                    v-model="searchItem['assessmentDate']"
                    :label="$t('employeecheck.item.assessment_time')"
                    prepend-icon="mdi-calendar"
                    readonly
                    v-bind="attrs"
                    v-on="on"
                  />
                </template>
                <v-date-picker
                  v-model="searchItem['assessmentDate']"
                  color="primary"
                  width="400"
                  @input="menu2 = false"
                />
              </v-menu>
            </v-col>
            <v-col class="d-flex" cols="12" sm="6" md="3">
              <v-select
                v-model="searchItem['grade']"
                :items="gradeitems"
                label="考核等级"
                prepend-icon="el-icon-data-board"
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
                <v-icon>mdi-filter</v-icon>&nbsp;&nbsp;查找员工考核信息
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
                      {{ $t("employeecheck.item.alter") }}
                    </span>
                  </v-card-title>
                  <v-card-text>
                    <v-card>
                      <v-container fluid>
                        <v-row>
                          <v-col cols="12" sm="6" md="4">
                            <v-text-field
                              v-model="editedItem['employeeId']"
                              disabled
                              :label="$t('employeecheck.item.employee_id')"
                            />
                          </v-col>
                          <v-col cols="12" sm="6" md="4">
                            <v-text-field
                              v-model="editedItem['managerId']"
                              disabled
                              :label="$t('employeecheck.item.manager_id')"
                            />
                          </v-col>
                          <v-col cols="12" sm="6" md="4">
                            <v-text-field
                              v-model="editedItem['assessmentTime']"
                              disabled
                              :label="$t('employeecheck.item.assessment_time')"
                            />
                          </v-col>
                          <v-col class="d-flex" cols="12" sm="6" md="4">
                            <v-select
                              v-model="editedItem['assessmentGrade']"
                              :items="gradeitems"
                              label="考核等级"
                            />
                          </v-col>
                          <v-col cols="12" sm="6" md="4">
                            <v-text-field
                              v-model="editedItem['remarks']"
                              :label="$t('employeecheck.item.remarks')"
                            />
                          </v-col>
                        </v-row>
                      </v-container>
                    </v-card>
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
            {{ $t("employeecheck.item.delete") }}
          </span>
        </v-card-title>
        <v-divider />
        <br />
        <v-card-text>
          <span class="zms-poptip-body">
            {{ $t("employeecheck.item.delete_content") }}
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
            @click="deletecheckItemInfo()"
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
  getemployeecheckInfo,
  updateemployeecheckInfo,
  deleteemployeecheckInfo,
} from "../../apis/employeecheck.js";
import AlertMessagebox from "../CommonComponents/AlertMessagebox.vue";
export default {
  name: "EmployeeCheckItemOverview",
  components: { AlertMessagebox },
  data: () => {
    return {
      headers: [
        { text: "工作人员工号", value: "employeeId" },
        { text: "管理人员工号", value: "managerId" },
        { text: "考核时间", value: "assessmentTime" },
        { text: "考核等级", value: "assessmentGrade" },
        { text: "备注", value: "remarks" },
        { text: "操作", value: "actions", sortable: false },
      ],
      eId: null, //员工工号
      mId: null, //管理人员工号
      Date: null, //考核时间
      grade: null, //考核等级
      note: null, //备注信息
      Type: null,
      assessmentDate: null,
      gradeitems: ["A", "B", "C", "D", "E"],
      value: ["foo", "bar", "fizz", "buzz"],
      searchItem: {
        eId: null,
        mId: null,
        assessmentDate: null,
        grade: null,
      },
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
        name: "",
        calories: 0,
        fat: 0,
        carbs: 0,
        protein: 0,
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
        getemployeecheckInfo({
          employeeid: this.searchItem["eId"],
          managerid: this.searchItem["mId"],
          assessmenttime: this.searchItem["assessmentDate"],
          assessmentgrade: this.searchItem["grade"],
        })
          .then((response) => {
            for (let i = 0; i < response.data.length; i++) {
              response.data[i].assessmentTime = response.data[
                i
              ].assessmentTime.substring(0, 10);
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
                info: this.$t("animalCare.emptyInfo"),
              });
            }
          })
          .catch((err) => {
            this.$refs.error_done.updateBody(
              this.$t("common3.transactionFail") + err
            );
            this.$refs.error_done.showAlert();
            this.queryLoaderDialog = false;
            this.errorTitle = this.$t("common.error");
          });
      }, 2000);
    },
    updateItemInfo() {
      this.queryLoaderDialog2 = true;
      setTimeout(() => {
        updateemployeecheckInfo({
          employeeid: this.editedItem["employeeId"],
          managerid: this.editedItem["managerId"],
          assessmenttime: this.editedItem["assessmentTime"],
          assessmentgrade: this.editedItem["assessmentGrade"],
          remarks: this.editedItem["remarks"],
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
            this.errorInfo = "考核信息编辑失败";
            this.errorReturn = true;
          });
      }, 2000);
    },
    deletecheckItemInfo() {
      this.queryLoaderDialog2 = true;
      setTimeout(() => {
        deleteemployeecheckInfo({
          employeeid: this.delItem["employeeId"],
          managerid: this.delItem["managerId"],
          assessmenttime: this.delItem["assessmentTime"],
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
            this.errorInfo = this.$t("warehouse.Info.generalError");
            this.errorReturn = true;
          });
      }, 2000);
    },
    deleteItemInfo() {
      (this.searchItem["eId"] = null),
        (this.searchItem["mId"] = null),
        (this.searchItem["assessmentDate"] = null),
        (this.searchItem["grade"] = null);
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
