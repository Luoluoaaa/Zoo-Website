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
                v-model="searchItem['id']"
                :label="$t('employee.item.id')"
                placeholder="请输入工号"
                prepend-icon="el-icon-s-custom"
              />
            </v-col>
            <v-col cols="12" sm="6" md="3">
              <v-text-field
                v-model="searchItem['name']"
                :label="$t('employee.item.name')"
                placeholder="请输入员工姓名"
                prepend-icon="el-icon-document-copy"
              />
            </v-col>
            <v-col cols="12" sm="6" md="3">
              <v-text-field
                v-model="searchItem['park']"
                :label="$t('employee.item.park')"
                placeholder="请输入员工所属园区"
                prepend-icon="el-icon-coordinate"
              />
            </v-col>
            <v-col cols="12" sm="6" md="3">
              <v-text-field
                v-model="searchItem['position']"
                :label="$t('employee.item.position')"
                placeholder="请输入员工的职务"
                prepend-icon="el-icon-document-checked"
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
                <v-icon>mdi-filter</v-icon>&nbsp;&nbsp;查找相应员工
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
                      {{ $t("employee.item.alter") }}
                    </span>
                  </v-card-title>
                  <v-card-text>
                    <v-container>
                      <v-row>
                        <v-col cols="12" sm="6" md="4">
                          <v-text-field
                            v-model="editedItem['id']"
                            disabled
                            :label="$t('employee.item.id')"
                            prepend-icon="el-icon-s-help"
                          />
                        </v-col>
                        <v-col cols="12" sm="6" md="4">
                          <v-text-field
                            v-model="editedItem['name']"
                            :label="$t('employee.item.name')"
                            prepend-icon="el-icon-video-camera-solid"
                          />
                        </v-col>
                        <v-col class="d-flex" cols="12" sm="6" md="4">
                          <v-select
                            v-model="editedItem['gender']"
                            :items="items"
                            label="性别"
                            prepend-icon="el-icon-notebook-2"
                          />
                        </v-col>
                        <v-col cols="12" sm="6" md="4">
                          <v-text-field
                            v-model="editedItem['age']"
                            :label="$t('employee.item.age')"
                            prepend-icon="el-icon-s-flag"
                          />
                        </v-col>
                        <v-col cols="12" sm="6" md="4">
                          <v-text-field
                            v-model="editedItem['wage']"
                            :label="$t('employee.item.wage')"
                            prepend-icon="el-icon-caret-left"
                          />
                        </v-col>
                        <v-col cols="12" sm="6" md="4">
                          <v-text-field
                            v-model="editedItem['position']"
                            :label="$t('employee.item.position')"
                            prepend-icon="el-icon-c-scale-to-original"
                          />
                        </v-col>
                        <v-col cols="12" sm="6" md="4">
                          <v-text-field
                            v-model="editedItem['park']"
                            :label="$t('employee.item.park')"
                            prepend-icon="el-icon-document-remove"
                          />
                        </v-col>
                        <v-col cols="12" sm="6" md="4">
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
                                v-model="editedItem['employmentYear']"
                                :label="$t('employee.item.date')"
                                prepend-icon="mdi-calendar"
                                readonly
                                v-bind="attrs"
                                v-on="on"
                              />
                            </template>
                            <v-date-picker
                              v-model="editedItem['employmentYear']"
                              color="primary"
                              width="400"
                              @input="menu2 = false"
                            />
                          </v-menu>
                        </v-col>
                        <v-col cols="12" sm="6" md="4">
                          <v-text-field
                            v-model="editedItem['password']"
                            :label="$t('employee.item.password')"
                            prepend-icon="el-icon-s-help"
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
            {{ $t("employee.item.delete") }}</span
          >
        </v-card-title>
        <v-divider />
        <br />
        <v-card-text>
          <span class="zms-poptip-body">
            {{ $t("employee.item.delete_content") }}</span
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
            @click="deleteItemConfirm()"
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
  getEmployeeItemInfo,
  updateEmployeeItemInfo,
} from "../../apis/employee.js";
export default {
  name: "EmployeeItemOverview",
  data: () => {
    return {
      headers: [
        { text: "工号", value: "id" },
        { text: "姓名", value: "name" },
        { text: "性别", value: "gender" },
        { text: "年龄", value: "age" },
        { text: "工资", value: "wage" },
        { text: "职务", value: "position" },
        { text: "园区", value: "park" },
        { text: "入职年份", value: "employmentYear" },
        { text: "密码", value: "password" },
        { text: "操作", value: "actions", sortable: false },
      ],
      items: ["男", "女"],
      searchItem: {
        id: null,
        name: null,
        park: null,
        position: null,
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
        date: "",
        password: "",
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
        getEmployeeItemInfo({
          id: this.searchItem["id"],
          name: this.searchItem["name"],
          park: this.searchItem["park"],
          position: this.searchItem["position"],
        })
          .then((response) => {
            for (let i = 0; i < response.data.length; i++) {
              response.data[i].employmentYear = response.data[
                i
              ].employmentYear.substring(0, 4);
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
          .catch(() => {
            this.queryLoaderDialog = false;
            this.errorTitle = this.$t("common.error");
            this.errorInfo = "查找失败";
            this.errorReturn = true;
          });
      }, 2000);
    },
    updateItemInfo() {
      if (isNaN(parseInt(this.editedItem["age"]))) {
        this.$store.dispatch("showToastNotify", {
          type: "error",
          info: "年龄输入无效",
        });
        return;
      }
      if (isNaN(parseInt(this.editedItem["wage"]))) {
        this.$store.dispatch("showToastNotify", {
          type: "error",
          info: "工资输入无效",
        });
        return;
      }
      this.queryLoaderDialog2 = true;
      setTimeout(() => {
        updateEmployeeItemInfo({
          id: this.editedItem["id"],
          name: this.editedItem["name"],
          gender: this.editedItem["gender"],
          age: parseInt(this.editedItem["age"]),
          wage: parseInt(this.editedItem["wage"]),
          position: this.editedItem["position"],
          park: this.editedItem["park"],
          employmentYear: this.editedItem["employmentYear"].substring(0, 5),
          password: this.editedItem["password"],
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
            this.errorInfo = "员工信息修改失败";
            this.errorReturn = true;
          });
      }, 2000);
    },
    deleteItemInfo() {
      this.searchItem["id"] = null;
      this.searchItem["name"] = null;
      this.searchItem["park"] = null;
      this.searchItem["position"] = null;
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
