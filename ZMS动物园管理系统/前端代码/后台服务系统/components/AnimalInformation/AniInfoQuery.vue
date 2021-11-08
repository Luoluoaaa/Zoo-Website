<template>
  <div class="zms-animalinfo" :class="nmNightClass">
    <pending-progress-card
      :zms-pending-list="pendingList"
      :zms-show="pendingShow"
    />
    <!--事务失败提示框-->
    <alert-messagebox
      ref="error_done"
      :alert-title="$t('common3.transactionFailTitle')"
      :alert-body="$t('common3.transactionFail') + errorInfo"
      :alert-level="`error`"
      :alert-only-confirm="true"
    />
    <!---相关动作提示框--->
    <alert-messagebox
      ref="deletealert"
      alert-title="删除动物档案信息"
      :alert-body="`是否删除编号为` + delId + `的档案信息?`"
      alert-level="warning"
      :alert-model="{}"
      @alertConfirm="deleteAniInfo"
    />
    <alert-messagebox
      ref="insertalert"
      alert-title="保存动物档案信息"
      :alert-body="`是否保存编号为` + insertId + `的档案信息?`"
      alert-level="warning"
      :alert-model="{}"
      @alertConfirm="insertInfoAfter"
    />
    <alert-messagebox
      ref="insertalert2"
      alert-title="保存动物档案信息"
      :alert-body="`是否创建新的动物信息?`"
      alert-level="warning"
      :alert-model="{}"
      @alertConfirm="insertInfoAfter"
    />
    <!---成功失败提示框--->
    <alert-messagebox
      ref="commit_done"
      :alert-title="$t('common3.transactionDoneTitle')"
      :alert-body="$t('common3.transactionDone')"
      :alert-level="`success`"
      :alert-only-confirm="true"
    />
    <alert-messagebox
      ref="commit_error"
      :alert-title="$t('common3.transactionDoneTitle')"
      :alert-body="$t('common3.transactionDone')"
      :alert-level="`error`"
      :alert-only-confirm="true"
    />
    <!---查询部分--->
    <pending-progress-card />
    <div class="zms-animalinfo-query-filter">
      <v-icon color="primary"> mdi-filter-plus </v-icon>
      <span class="zms-query-title">查询条件</span>
      <div>
        <v-container>
          <v-row>
            <v-col cols="12" sm="6" md="3">
              <v-text-field
                v-model="select_ani_id"
                label="动物编号"
                placeholder="请输入动物编号"
                prepend-icon="mdi-music-accidental-sharp"
              />
            </v-col>
            <v-col cols="12" sm="6" md="3">
              <v-text-field
                v-model="select_species"
                label="动物种类"
                placeholder="请输入动物种类"
                prepend-icon="mdi-owl"
              />
            </v-col>
            <v-col cols="12" sm="6" md="3">
              <v-text-field
                v-model="select_ani_name"
                label="动物姓名"
                placeholder="请输入动物姓名"
                prepend-icon="mdi-paw"
              />
            </v-col>
          </v-row>
        </v-container>
        <v-container>
          <v-row>
            <v-col cols="12" sm="6" md="3">
              <v-btn
                v-ripple
                block
                class="zms-width"
                color="error"
                @click="clearFilter"
              >
                <v-icon>mdi-filter-minus</v-icon>&nbsp;&nbsp;删除过滤条件
              </v-btn>
            </v-col>
            <v-col cols="12" sm="6" md="3">
              <v-btn
                v-ripple
                block
                class="zms-width"
                color="primary"
                @click="
                  searchInfo(select_ani_id, select_ani_name, select_species)
                "
              >
                <v-icon>mdi-filter</v-icon>&nbsp;&nbsp;按条件查找
              </v-btn>
            </v-col>
            <v-col cols="12" sm="6" md="3">
              <v-dialog
                v-model="dialog"
                persistent
                position="fixed"
                max-width="600px"
              >
                <template v-slot:activator="{ on, attrs }">
                  <v-btn
                    v-ripple
                    color="#00BED8"
                    block
                    class="zms-width"
                    dark
                    @click="createItem({ p: on, x: attrs })"
                  >
                    新增档案
                  </v-btn>
                </template>
                <v-card :ripple="{ class: null }">
                  <v-card-title
                    class="zms-strip-bg text-h5 text--white darken-3"
                    :class="`blue`"
                    color="warning"
                  >
                    <v-icon color="white"> mdi-plus </v-icon>&nbsp;
                    <span class="text--white" style="color: #ffffff !important">
                      {{ formTitle }}
                    </span>
                  </v-card-title>
                  <v-card-text>
                    <br />
                    <br />
                    <v-form ref="form">
                      <v-container>
                        <v-row>
                          <v-col>
                            <v-btn @click="showX = !showX"> 设置照片 </v-btn>
                          </v-col>
                          <!---查询结果部分--->
                          <v-col>
                            <v-avatar size="72" color="primary" tile>
                              <img :src="editedItem.photo" />
                            </v-avatar>
                          </v-col>
                          <my-upload
                            v-model="showX"
                            field="img"
                            url=""
                            :width="100"
                            :height="100"
                            :params="paramsX"
                            :headers="headersX"
                            img-format="jpg"
                            @crop-success="cropSuccess(arguments)"
                            @crop-upload-success="cropUploadSuccess(arguments)"
                            @crop-upload-fail="cropUploadFail(arguments)"
                          />
                        </v-row>
                        <v-row>
                          <v-col cols="12" sm="6" md="4">
                            <v-text-field
                              v-model="editedItem.id"
                              label="动物编号*"
                              :rules="rules"
                              hide-details="auto"
                              required
                              :disabled="!isToCreateItem"
                            />
                          </v-col>
                          <v-col cols="12" sm="6" md="4">
                            <v-text-field
                              v-model="editedItem.species"
                              label="物种*"
                              :rules="rules"
                              hide-details="auto"
                              required
                            />
                          </v-col>
                          <v-col cols="12" sm="6" md="4">
                            <v-text-field
                              v-model="editedItem.name"
                              label="动物姓名*"
                              :rules="rules"
                              hide-details="auto"
                              required
                            />
                          </v-col>
                        </v-row>
                        <v-row>
                          <v-col cols="12" sm="6" md="6">
                            <v-select
                              v-model="editedItem.gender"
                              :items="['雌性', '雄性']"
                              label="动物性别*"
                              :rules="rules"
                              hide-details="auto"
                              required
                            />
                          </v-col>
                          <v-col cols="12" sm="6" md="6">
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
                                  v-model="editedItem.birthDate"
                                  label="出生日期"
                                  prepend-icon="mdi-calendar"
                                  readonly
                                  v-bind="attrs"
                                  v-on="on"
                                />
                              </template>
                              <v-date-picker
                                v-model="editedItem.birthDate"
                                color="primary"
                                width="400"
                                :allowed-dates="allowedDates"
                                @input="menu2 = false"
                              />
                            </v-menu>
                          </v-col>
                        </v-row>
                        <v-row>
                          <v-col cols="12" sm="6">
                            <v-text-field
                              v-model="editedItem.bodyLength"
                              label="身高/体长/cm"
                              :rules="rules"
                              hide-details="auto"
                              required
                            />
                          </v-col>
                          <v-col cols="12" sm="6">
                            <v-text-field
                              v-model="editedItem.weight"
                              label="体重/kg*"
                              :rules="rules"
                              hide-details="auto"
                              required
                            />
                          </v-col>
                        </v-row>
                        <v-row margin-bottom="30px">
                          <v-col cols="12" sm="6">
                            <v-select
                              v-model="editedItem.physicalCondition"
                              :items="['良好', '生病', '虚弱', '健康']"
                              label="健康状态*"
                              :rules="rules"
                              hide-details="auto"
                              required
                            />
                          </v-col>
                          <v-col cols="12" sm="6"> </v-col>
                        </v-row>
                        <v-row>
                          <v-col cols="6">
                            <v-btn
                              class="zms-btn-save"
                              :disabled="!valid"
                              color="blue darken-1"
                              text
                              @click="validate(editedItem.id)"
                            >
                              保存
                            </v-btn>
                          </v-col>
                          <v-col cols="6">
                            <v-btn
                              class="zms-btn-clear"
                              color="blue darken-1"
                              right
                              text
                              @click="
                                reset;
                                dialog = false;
                              "
                            >
                              取消
                            </v-btn>
                          </v-col>
                        </v-row>
                      </v-container>
                    </v-form>
                  </v-card-text>
                </v-card>
              </v-dialog>
            </v-col>
          </v-row>
        </v-container>
      </div>
    </div>
    <v-divider />
    <pending-progress-card :zms-show="show" />
    <div class="zms-animalinfo-query-result">
      <v-icon color="primary"> mdi-note-search </v-icon>
      <span class="zms-animalinfo-query-title">查询结果</span>
      <div class="zms-animalinfo-query-result-table">
        <v-data-table
          :headers="headers"
          dialog
          :items="queryData"
          :single-expand="singleExpand"
          :expanded.sync="expanded"
          show-expand
          :page.sync="page"
          :items-per-page="10"
          hide-default-footer
          item-key="id"
          class="elevation-1"
          @page-count="pageCount = $event"
        >
          <!--展开行-->
          <!-- -->
          <template v-slot:expanded-item="{ headers, item }">
            <td :colspan="headers.length">
              <v-row>
                <v-col cols="12" md="4">
                  <v-img
                    :aspect-ratio="4 / 3"
                    :src="item.photo"
                    class="white--text align-end"
                    gradient="to bottom, rgba(0,0,0,.1), rgba(0,0,0,.5)"
                    height="125"
                  />
                </v-col>
                <v-col cols="12" md="8">
                  <br />
                  <v-text color="primary">
                    出生日期：{{ item.birthDate }} <br />
                    <br />
                  </v-text>
                  <v-text color="primary">
                    身高体长：{{ item.bodyLength }}
                    <br />
                    <br />
                  </v-text>
                </v-col>
              </v-row>
            </td>
          </template>
          <!--删除dialog弹出框-->
          <v-dialog v-model="dialogDelete" max-width="500px">
            <template />
            <v-card>
              <v-card-title class="text-h5" color="#FB8C00">
                确认删除？
              </v-card-title>
              <v-card-actions>
                <v-spacer />
                <v-btn color="blue darken-1" text @click="closeDelete">
                  取消
                </v-btn>
                <v-btn color="blue darken-1" text @click="deleteItemConfirm">
                  确认
                </v-btn>
                <v-spacer />
              </v-card-actions>
            </v-card>
          </v-dialog>
          <template v-slot:[`item.actions`]="{ item }">
            <v-icon small class="mr-2" @click="editItem2(item)">
              mdi-pencil
            </v-icon>
            <v-icon small @click="deleteItem2(item)"> mdi-delete </v-icon>
          </template>
        </v-data-table>
      </div>
      <div class="zms-query-pagination">
        <v-pagination v-model="page" :length="pageCount" />
      </div>
    </div>
  </div>
</template>
<script>
import { getinformation } from "../../apis/animalInfo";
import {
  createinformation,
  deleteinformation,
  updateinformation,
} from "../../apis/animalInfo";
import PendingProgressCard from "../CommonComponents/PendingProgressCard.vue";
import AlertMessagebox from "../CommonComponents/AlertMessagebox.vue";
import myUpload from "vue-image-crop-upload/upload-2.vue";
import "babel-polyfill";
export default {
  name: "AnicareQuery",
  components: { PendingProgressCard, AlertMessagebox, myUpload },
  data: () => {
    return {
      imgX: "",
      select_ani_id: "",
      select_ani_name: "",
      select_species: "",
      valid: true,
      delId: 0,
      expanded: [],
      rules: [(value) => !!value || "不能为空"],
      dialogDelete: false,
      headers: [
        { text: "", value: "data-table-expand" },
        { text: "编号", value: "id" },
        { text: "物种", value: "species", sortable: false },
        { text: "姓名", value: "name", sortable: false },
        { text: "性别", value: "gender" },
        { text: "体重/Kg", value: "weight" },
        { text: "健康状态", value: "physicalCondition", sortable: false },
        { text: "操作", value: "actions", sortable: false },
      ],
      showX: false,
      paramsX: {
        token: "123456798",
        name: "avatar",
      },
      headersX: {
        smail: "*_~",
      },
      imgDataUrlX: ["", "", ""],
      show: false,
      pageCount: 0,
      page: 1,
      queryData: [],
      editedIndex: -1,
      pendingShow: false,
      pendingList: [],
      editedItem: {
        id: "",
        species: "",
        name: "",
        gender: "",
        age: "",
        weight: "",
        physicalCondition: "",
        breedSituation: "",
        birthDate: "",
        bodyLength: "",
        photo: "/static/images/panda.jpg",
      },
      isToCreateItem: false,
      defaultItem: {
        id: "",
        species: "",
        name: "",
        gender: "",
        age: "",
        weight: "",
        physicalCondition: "",
        breedSituation: "",
        birthDate: "",
        bodyLength: "",
        photo: "/static/images/panda.jpg",
      },
      dialog: false,
    };
  },
  computed: {
    formTitle() {
      return this.editedIndex === -1 ? "新增档案" : "修改档案";
    },
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
  },
  watch: {
    dialog(val) {
      val || this.close();
    },
    dialogDelete(val) {
      val || this.closeDelete();
    },
  },
  created() {},
  methods: {
    cropSuccess(imgDataUrl) {
      this.imgDataUrlX = imgDataUrl;
      this.editedItem.photo = imgDataUrl[0];
    },
    cropUploadSuccess(jsonData, field) {},
    cropUploadFail(status, field) {},
    createItem(item) {
      this.dialog = true;
      this.isToCreateItem = true;
      this.editItem(item);
    },
    editItem2(item) {
      this.isToCreateItem = false;
      this.editItem(item);
    },
    validate(id) {
      if (this.$refs.form.validate() === true) {
        this.insertInfo(id);
      }
    },
    insertInfo(x) {
      this.insertId = x;
      this.$refs.insertalert.updateBody(
        `是否保存编号为` + this.insertId + `的档案信息?`
      );
      if (this.isToCreateItem) {
        this.$refs.insertalert2.showAlert();
      } else {
        this.$refs.insertalert.showAlert();
      }
    },
    insertInfoAfter() {
      if (this.isToCreateItem) {
        if (this.editedItem.age < 0) {
          this.$refs.error_done.updateBody(this.$t("common3.transactionFail"));
          this.$refs.error_done.showAlert();
          return;
        }
        if (
          parseInt(this.editedItem.weight) <= 0 ||
          isNaN(parseInt(this.editedItem.weight)) ||
          parseInt(this.editedItem.weight) > 999
        ) {
          this.$refs.error_done.updateBody("体重输入非法");
          this.$refs.error_done.showAlert();
          return;
        }
        if (
          parseInt(this.editedItem.bodyLength) <= 0 ||
          isNaN(parseInt(this.editedItem.bodyLength)) ||
          parseInt(this.editedItem.bodyLength) > 999
        ) {
          this.$refs.error_done.updateBody("体长输入非法");
          this.$refs.error_done.showAlert();
          return;
        }
        if ((this.editedItem.weight + "").indexOf(".") != -1) {
          this.$refs.error_done.updateBody(
            "体重需要输入整数，请进行舍入后继续"
          );
          this.$refs.error_done.showAlert();
          return;
        }
        if ((this.editedItem.bodyLength + "").indexOf(".") != -1) {
          this.$refs.error_done.updateBody(
            "体长需要输入整数，请进行舍入后继续"
          );
          this.$refs.error_done.showAlert();
          return;
        }
        if (this.editedItem.id.length > 50) {
          this.$refs.error_done.updateBody("ID不能输入过长");
          this.$refs.error_done.showAlert();
          return;
        }
        if (this.editedItem.species.length > 50) {
          this.$refs.error_done.updateBody("物种输入过长");
          this.$refs.error_done.showAlert();
          return;
        }
        if (this.editedItem.name.length > 50) {
          this.$refs.error_done.updateBody("名称输入过长");
          this.$refs.error_done.showAlert();
          return;
        }
        this.pendingShow = true;
        let x = new Date();
        x = x.getFullYear();
        createinformation({
          id: this.editedItem.id,
          species: this.editedItem.species,
          name: this.editedItem.name,
          gender: this.editedItem.gender,
          birthDate: this.editedItem.birthDate,
          age: x - parseInt(this.editedItem.birthDate.substring(0, 4)) + 1,
          bodyLength: parseInt(this.editedItem.bodyLength),
          weight: parseInt(this.editedItem.weight),
          physicalCondition: this.editedItem.physicalCondition,
          breedSituation: this.editedItem.breedSituation,
          photo:
            this.editedItem.photo === "" || this.editedItem.photo === undefined
              ? "Cz=="
              : this.editedItem.photo.substring(23),
        })
          .then(() => {
            this.dialog = false;
            this.$refs.form.reset();
            this.$refs.commit_done.showAlert();
            this.pendingShow = false;
            this.searchInfo(
              this.select_ani_id,
              this.select_ani_name,
              this.select_species
            );
          })
          .catch((err) => {
            this.$refs.error_done.updateBody(
              this.$t("common3.transactionFail") + err
            );
            this.$refs.error_done.showAlert();
            this.pendingShow = false;
          });
      } else {
        if (this.editedItem.age < 0) {
          this.$refs.error_done.updateBody(this.$t("common3.transactionFail"));
          this.$refs.error_done.showAlert();
          return;
        }
        if (
          parseInt(this.editedItem.weight) <= 0 ||
          isNaN(parseInt(this.editedItem.weight)) ||
          parseInt(this.editedItem.weight) > 999
        ) {
          this.$refs.error_done.updateBody("体重输入非法");
          this.$refs.error_done.showAlert();
          return;
        }
        if (
          parseInt(this.editedItem.bodyLength) <= 0 ||
          isNaN(parseInt(this.editedItem.bodyLength)) ||
          parseInt(this.editedItem.bodyLength) > 999
        ) {
          this.$refs.error_done.updateBody("体长输入非法");
          this.$refs.error_done.showAlert();
          return;
        }
        if ((this.editedItem.weight + "").indexOf(".") != -1) {
          this.$refs.error_done.updateBody(
            "体重需要输入整数，请进行舍入后继续"
          );
          this.$refs.error_done.showAlert();
          return;
        }
        if ((this.editedItem.bodyLength + "").indexOf(".") != -1) {
          this.$refs.error_done.updateBody(
            "体长需要输入整数，请进行舍入后继续"
          );
          this.$refs.error_done.showAlert();
          return;
        }
        if (this.editedItem.id.length > 50) {
          this.$refs.error_done.updateBody("ID不能输入过长");
          this.$refs.error_done.showAlert();
          return;
        }
        if (this.editedItem.species.length > 50) {
          this.$refs.error_done.updateBody("物种输入过长");
          this.$refs.error_done.showAlert();
          return;
        }
        if (this.editedItem.name.length > 50) {
          this.$refs.error_done.updateBody("名称输入过长");
          this.$refs.error_done.showAlert();
          return;
        }
        this.pendingShow = true;
        updateinformation({
          id: this.editedItem.id,
          species: this.editedItem.species,
          name: this.editedItem.name,
          gender: this.editedItem.gender,
          birthDate: this.editedItem.birthDate,
          age: parseInt(this.editedItem.age),
          bodyLength: parseInt(this.editedItem.bodyLength),
          weight: parseInt(this.editedItem.weight),
          physicalCondition: this.editedItem.physicalCondition,
          breedSituation: this.editedItem.breedSituation,
          //photo:'/static/images/panda.jpg'
        })
          .then(() => {
            this.dialog = false;
            this.$refs.form.reset();
            this.$refs.commit_done.showAlert();
            this.pendingShow = false;
            this.searchInfo(
              this.select_ani_id,
              this.select_ani_name,
              this.select_species
            );
          })
          .catch((err) => {
            //this.show=false;
            this.$refs.error_done.updateBody(
              this.$t("common3.transactionFail") + err
            );
            this.$refs.error_done.showAlert();
            this.pendingShow = false;
          });
      }
    },
    reset() {
      this.$refs.form.reset();
    },
    resetValidation() {
      this.$refs.form.resetValidation();
      this.dialog = "false";
    },
    searchInfo(ani_id, ani_name, species) {
      this.show = true;
      setTimeout(() => {
        getinformation({
          ani_id: ani_id,
          ani_name: ani_name,
          species: species,
        })
          .then((response) => {
            this.queryData = response.data;
            for (let i = 0; i < this.queryData.length; i++) {
              this.queryData[i].photo =
                "data:image/jpeg;base64," + this.queryData[i].photo;
              this.queryData[i].birthDate = this.queryData[
                i
              ].birthDate.substring(0, 10);
            }

            this.show = false;
          })
          .catch((err) => {
            this.show = false;
            this.$refs.error_done.updateBody(
              this.$t("common3.transactionFail") + err
            );
            this.$refs.error_done.showAlert();
          });
      }, 500);
    },
    editItem(item) {
      this.insertId = item.id;
      this.editedIndex = this.queryData.indexOf(item);
      this.editedItem = Object.assign({}, item);
      this.dialog = true;
    },
    clearFilter() {
      this.select_ani_id = "";
      this.select_ani_name = "";
      this.select_species = "";
    },
    deleteItem(item) {
      this.editedIndex = this.queryData.indexOf(item);
      this.editedItem = Object.assign({}, item);
      this.dialogDelete = true;
    },
    deleteItem2(x) {
      this.delId = x.id;

      this.$refs.deletealert.updateBody(
        `是否删除编号为` + this.delId + `的档案信息?`
      );
      this.$refs.deletealert.showAlert();
    },
    deleteItemConfirm() {
      this.queryData.splice(this.editedIndex, 1);
      this.closeDelete();
    },
    insertItemConfirm() {
      this.queryData.splice(this.editedIndex, 1);
      this.closeDelete();
    },
    close() {
      this.dialog = false;
      this.$nextTick(() => {
        this.editedItem = Object.assign({}, this.defaultItem);
        this.editedIndex = -1;
      });
    },
    deleteAniInfo() {
      this.pendingShow = true;
      deleteinformation(this.delId)
        .then(() => {
          this.$refs.commit_done.showAlert();
          this.pendingShow = false;
          this.searchInfo(
            this.select_ani_id,
            this.select_ani_name,
            this.select_species
          );
        })
        .catch((err) => {
          this.$refs.error_done.updateBody(
            this.$t("common3.transactionFail") + err
          );
          this.$refs.error_done.showAlert();
          this.pendingShow = false;
        });
    },
    insertAniInfo() {},
    closeDelete() {
      this.dialogDelete = false;
      this.$nextTick(() => {
        this.editedItem = Object.assign({}, this.defaultItem);
        this.editedIndex = -1;
      });
    },
    save() {
      if (this.editedIndex > -1) {
        Object.assign(this.queryData[this.editedIndex], this.editedItem);
      } else {
        this.queryData.push(this.editedItem);
      }
      this.close();
    },
    allowedDates: (val) =>
      val <=
      new Date(Date.now() - new Date().getTimezoneOffset() * 60000)
        .toISOString()
        .substr(0, 10),
  },
};
</script>
<style scoped lang="scss">
.btn-close {
  position: relative;
  display: block;
  margin-left: 80%;
}
.zms-btn-clear {
  position: relative;
  display: block;
  margin-left: 80%;
}
.zms-animalinfo-query-pagination {
  margin-top: 10px;
  transition: all 0.5s;
}
.zms-animalinfo-query-result {
  margin-top: 20px;
}
.zms-animalinfo {
  padding-left: 50px;
  padding-right: 50px;
  padding-top: 20px;
  padding-bottom: 20px;
  background-color: #fafafa;
}
.zms-animalinfo-query-title {
  font-weight: bold;
  letter-spacing: 1px;
  position: relative;
  top: 3px;
}
.zms-animalinfo-query-result-table {
  margin-top: 10px;
}
</style>
