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
                :label="$t('training.ID')"
                :placeholder="$t('common.pleaseInput') + $t('training.ID')"
                prepend-icon="mdi-music-accidental-sharp"
              />
            </v-col>
            <v-col cols="12" sm="6" md="3">
              <v-text-field
                v-model="submit_animal_id"
                :label="$t('training.animal_id')"
                :placeholder="
                  $t('common.pleaseInput') + $t('training.animal_id')
                "
                prepend-icon="el-icon-view"
              />
            </v-col>
            <v-col cols="12" sm="6" md="3">
              <v-text-field
                v-model="submit_trainer_id"
                :label="$t('training.trainer_id')"
                :placeholder="
                  $t('common.pleaseInput') + $t('training.trainer_id')
                "
                prepend-icon="el-icon-s-custom"
              />
            </v-col>
            <v-col cols="12" sm="6" md="3">
              <v-text-field
                v-model="submit_train_site"
                :label="$t('training.train_site')"
                :placeholder="
                  $t('common.pleaseInput') + $t('training.train_site')
                "
                prepend-icon="el-icon-position"
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
                    v-model="submit_training_date"
                    :label="$t('training.training_date')"
                    prepend-icon="mdi-calendar"
                    readonly
                    v-bind="attrs"
                    v-on="on"
                  />
                </template>
                <v-date-picker
                  v-model="submit_training_date"
                  color="primary"
                  width="400"
                  @input="menu2 = false"
                />
              </v-menu>
            </v-col>
            <v-col cols="12" sm="6" md="3">
              <v-menu
                v-model="menu3"
                :close-on-content-click="false"
                :nudge-right="40"
                transition="scale-transition"
                offset-y
                min-width="290px"
              >
                <template v-slot:activator="{ on, attrs }">
                  <v-text-field
                    v-model="submit_start_time"
                    :label="$t('training.start_time')"
                    prepend-icon="el-icon-sort-up"
                    readonly
                    v-bind="attrs"
                    v-on="on"
                  />
                </template>
                <v-time-picker
                  v-model="submit_start_time"
                  format="24hr"
                  color="primary"
                  width="400"
                  @input="menu3 = false"
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
                    v-model="submit_end_time"
                    :label="$t('training.end_time')"
                    prepend-icon="el-icon-sort-up"
                    readonly
                    v-bind="attrs"
                    v-on="on"
                  />
                </template>
                <v-time-picker
                  v-model="submit_end_time"
                  format="24hr"
                  color="primary"
                  width="400"
                  @input="menu4 = false"
                />
              </v-menu>
            </v-col>
            <v-col cols="12" sm="6" md="3">
              <v-text-field
                v-model="submit_skill"
                :label="$t('training.skill')"
                :placeholder="$t('common.pleaseInput') + $t('training.skill')"
                prepend-icon="el-icon-unlock"
              />
            </v-col>
            <v-col cols="12" sm="6" md="3">
              <v-text-field
                v-model="submit_props"
                :label="$t('training.props')"
                :placeholder="$t('common.pleaseInput') + $t('training.props')"
                prepend-icon="el-icon-baseball"
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
                      {{ $t("training.itemAlter") }}
                    </span>
                  </v-card-title>

                  <v-card-text>
                    <v-container>
                      <v-row>
                        <v-col cols="12" sm="6" md="4">
                          <v-text-field
                            v-model="editedItem['id']"
                            disabled
                            :label="$t('training.ID')"
                          />
                        </v-col>
                        <v-col cols="12" sm="6" md="4">
                          <v-text-field
                            v-model="editedItem['animalId']"
                            :label="$t('training.animal_id')"
                          />
                        </v-col>
                        <v-col cols="12" sm="6" md="4">
                          <v-text-field
                            v-model="editedItem['trainerId']"
                            :label="$t('training.trainer_id')"
                          />
                        </v-col>
                        <v-col cols="12" sm="6" md="4">
                          <v-text-field
                            v-model="editedItem['trainSite']"
                            :label="$t('training.train_site')"
                          />
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
                                v-model="editedItem['trainDate']"
                                :label="$t('training.training_date')"
                                readonly
                                v-bind="attrs"
                                v-on="on"
                              />
                            </template>
                            <v-date-picker
                              v-model="editedItem['trainDate']"
                              color="primary"
                              width="400"
                              @input="menu5 = false"
                            />
                          </v-menu>
                        </v-col>
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
                                :label="$t('training.start_time')"
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
                                :label="$t('training.end_time')"
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

                        <v-col cols="12" sm="6" md="4">
                          <v-text-field
                            v-model="editedItem['skill']"
                            :label="$t('training.skill')"
                          />
                        </v-col>
                        <v-col cols="12" sm="6" md="4">
                          <v-text-field
                            v-model="editedItem['props']"
                            :label="$t('training.props')"
                          />
                        </v-col>
                        <v-col cols="12" sm="6" md="4">
                          <v-text-field
                            v-model="editedItem['remarks']"
                            :label="$t('training.trainer_id')"
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
            {{ $t("training.delete") }}</span
          >
        </v-card-title>
        <v-divider />
        <br />
        <v-card-text>
          <span class="zms-poptip-body">
            {{ $t("training.delete_content") }}</span
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
  getTrainingData,
  updateTrainingInfo,
  deleteTrainingInfo,
} from "../../apis/training";

export default {
  name: "TrainingQuery",
  data: () => {
    return {
      submit_ID: null,
      submit_animal_id: null,
      submit_trainer_id: null,
      submit_train_site: null,
      submit_training_date: null,
      submit_start_time: null,
      submit_end_time: null,
      submit_skill: null,
      submit_props: null,
      submitNote: null,

      headers: [
        { text: "训练编号", value: "id" },
        { text: "动物编号", value: "animalId" },
        { text: "训练员工编号", value: "trainerId" },
        { text: "训练地点", value: "trainSite" },
        { text: "训练时间", value: "trainDate" },
        { text: "开始时间", value: "startTime" },
        { text: "结束时间", value: "endTime" },
        { text: "训练技能", value: "skill" },
        { text: "训练道具", value: "props" },
        { text: "备注信息", value: "remarks" },
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
      editedItem: {
        ID: "",
        animal_id: 0,
        trainer_id: 0,
        train_site: 0,
        training_date: 0,
        start_time: 0,
        end_time: 0,
        skill: 0,
        props: 0,
        remarks: 0,
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
        getTrainingData({
          ID: this.submit_ID,
          animal_id: this.submit_animal_id,
          trainer_id: this.submit_trainer_id,
          train_site: this.submit_train_site,
          training_date: this.submit_training_date,
          start_time: this.submit_start_time,
          end_time: this.submit_end_time,
          skill: this.submit_skill,
          props: this.submit_props,
          remarks: this.submit_remarks,
        })
          .then((response) => {
            for (let i = 0; i < response.data.length; i++) {
              response.data[i].trainDate = response.data[i].trainDate.substring(
                0,
                10
              );
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
            console.log(err);
          });
      }, 2000);
    },
    updateItemInfo() {
      this.queryLoaderDialog2 = true;
      setTimeout(() => {
        updateTrainingInfo({
          ID: this.editedItem["id"],
          animal_id: this.editedItem["animalId"],
          trainer_id: this.editedItem["trainerId"],
          train_site: this.editedItem["trainSite"],
          training_date: this.editedItem["trainDate"],
          start_time: this.editedItem["startTime"],
          end_time: this.editedItem["endTime"],
          skill: this.editedItem["skill"],
          props: this.editedItem["props"],
          remarks: this.editedItem["remarks"],
        })
          .then(() => {
            this.queryLoaderDialog2 = false;
            (this.dialog = false),
              this.$store.dispatch("showToastNotify", {
                type: "success",
                info: "信息更新成功",
              });
            this.close();

            getTrainingData({
              ID: this.submit_ID,
              animal_id: this.submit_animal_id,
              trainer_id: this.submit_trainer_id,
              train_site: this.submit_train_site,
              training_date: this.submit_training_date,
              start_time: this.submit_start_time,
              end_time: this.submit_end_time,
              skill: this.submit_skill,
              props: this.submit_props,
              remarks: this.submit_remarks,
            })
              .then((response) => {
                for (let i = 0; i < response.data.length; i++) {
                  response.data[i].trainDate = response.data[
                    i
                  ].trainDate.substring(0, 10);
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
          .catch(() => {});
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
        deleteTrainingInfo({
          id: this.delItem["id"],
        }).then(() => {
          this.deleteDialog = false;
          this.$store.dispatch("showToastNotify", {
            type: "success",
            info: "信息删除成功",
          });
          this.close();

          getTrainingData({
            ID: this.submit_ID,
            animal_id: this.submit_animal_id,
            trainer_id: this.submit_trainer_id,
            train_site: this.submit_train_site,
            training_date: this.submit_training_date,
            start_time: this.submit_start_time,
            end_time: this.submit_end_time,
            skill: this.submit_skill,
            props: this.submit_props,
            remarks: this.submit_remarks,
          })
            .then((response) => {
              for (let i = 0; i < response.data.length; i++) {
                response.data[i].trainDate = response.data[
                  i
                ].trainDate.substring(0, 10);
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
        }, 2000);
      }).catch((err) => {
        this.queryLoaderDialog = false;
        this.$store.dispatch("showToastNotify", {
          type: "error",
          info: "信息删除失败" + err,
        });
        console.log(err);
      });
    },
    deleteItemInfo() {
      this.submit_ID = null;
      this.submit_animal_id = null;
      this.submit_trainer_id = null;
      this.submit_train_site = null;
      this.submit_training_date = null;
      this.submit_start_time = null;
      this.submit_end_time = null;
      this.submit_skill = null;
      this.submit_props = null;
      this.submit_remarks = null;
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
