<template>
  <div class="zms-animal-feed-info">
    <!--喂养信息保存提示框-->
    <alert-messagebox
      ref="insertalert2"
      alert-title="保存喂养信息"
      :alert-body="`是否保存喂养信息?`"
      alert-level="warning"
      :alert-model="{}"
      @alertConfirm="insertInfoAfter"
    />
    <!--insertInfoAfter-->
    <!--事务失败提示框-->
    <alert-messagebox
      ref="error_done"
      :alert-title="$t('common3.transactionFailTitle')"
      :alert-body="$t('common3.transactionFail') + errorInfo"
      :alert-level="`error`"
      :alert-only-confirm="true"
    />
    <!--事务成功提示-->
    <alert-messagebox
      ref="commit_donex"
      :alert-title="$t('common3.transactionDoneTitle')"
      :alert-body="$t('common3.transactionDone')"
      :alert-level="`success`"
      :alert-only-confirm="true"
    />
    <!--信息保存成功提示-->
    <alert-messagebox
      ref="commit_done"
      :alert-title="$t('common3.transactionDoneTitle')"
      :alert-body="`新建信息保存成功`"
      :alert-level="`success`"
      :alert-only-confirm="true"
    />
    <!--主UI-->
    <v-container>
      <v-row position="fixed" class="toprow">
        <v-col cols="12" sm="8">
          <v-text-field
            v-model="search"
            solo
            label="请输入搜索关键词"
            append-icon="mdi-magnify"
            @click:append="searchApp"
          />
        </v-col>
        <v-col cols="12" sm="4">
          <v-dialog v-model="dialog" persistent max-width="500px">
            <!--新增喂养信息对话框-->
            <template v-slot:activator="{ on, attrs }">
              <v-btn
                v-ripple
                color="primary"
                block
                class="zms-width"
                dark
                v-bind="attrs"
                height="50px"
                v-on="on"
              >
                新增喂养信息
              </v-btn>
            </template>
            <v-card>
              <v-card-title>
                <span class="text-h5">喂养信息</span>
              </v-card-title>
              <v-card-text>
                <v-form ref="form" v-model="valid" lazy-validation>
                  <v-container>
                    <v-row>
                      <v-col cols="12" sm="6">
                        <v-text-field
                          v-model="editedItem.animalId"
                          label="动物编号*"
                          :rules="rules"
                          hide-details="auto"
                          required
                        />
                      </v-col>
                      <v-col cols="12" sm="6">
                        <v-text-field
                          v-model="editedItem.keeperId"
                          label="员工编号*"
                          :rules="rules"
                          hide-details="auto"
                          required
                        />
                      </v-col>
                    </v-row>
                    <v-row>
                      <v-col cols="12" sm="6">
                        <v-text-field
                          v-model="editedItem.foodId"
                          label="食谱编号"
                          :rules="rules"
                          hide-details="auto"
                          required
                        />
                      </v-col>
                      <v-col cols="12" sm="6">
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
                              v-model="editedItem.date"
                              label="日期"
                              prepend-icon="mdi-calendar"
                              readonly
                              :rules="rules"
                              hide-details="auto"
                              required
                              v-bind="attrs"
                              v-on="on"
                            />
                          </template>
                          <v-date-picker
                            v-model="editedItem.date"
                            color="primary"
                            width="400"
                            :allowed-dates="allowedDates"
                            @input="menu2 = false"
                          />
                        </v-menu>
                      </v-col>
                      <v-col cols="12" sm="6">
                        <v-menu
                          ref="menu"
                          v-model="menu1"
                          :close-on-content-click="false"
                          :nudge-right="40"
                          :return-value.sync="feedday"
                          transition="scale-transition"
                          offset-y
                          max-width="290px"
                          min-width="290px"
                        >
                          <template v-slot:activator="{ on, attrs }">
                            <v-text-field
                              v-model="feedday"
                              label="时间"
                              prepend-icon="mdi-alarm"
                              readonly
                              v-bind="attrs"
                              v-on="on"
                            />
                          </template>
                          <v-time-picker
                            v-if="menu1"
                            v-model="feedday"
                            full-width
                            @click:minute="$refs.menu.save(feedday)"
                          />
                        </v-menu>
                      </v-col>
                    </v-row>
                    <v-row>
                      <v-col cols="12">
                        <v-text-field v-model="editedItem.note" label="备注" />
                      </v-col>
                    </v-row>
                    <v-row>
                      <!--按钮-->
                      <v-col cols="6">
                        <v-btn
                          class="zms-btn-save"
                          :disabled="!valid"
                          color="blue darken-1"
                          text
                          @click="validate(editedItem)"
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
    <!--主数据表-->
    <v-data-table
      :headers="headers"
      :items="Feedrecords"
      :page.sync="page"
      :search="search"
      :items-per-page="10"
      hide-default-footer
      class="elevation-1"
      @page-count="pageCount = $event"
    />
    <!--数据表分页-->
    <div class="zms-query-pagination">
      <v-pagination v-model="page" :length="pageCount" />
    </div>
  </div>
</template>
<script>
//API引入
import { createFeedRecord } from "../../apis/animalFeed";
import { getFeedRecord } from "../../apis/animalFeed";
//组件引入
import AlertMessagebox from "../CommonComponents/AlertMessagebox.vue";
//组件导出
export default {
  name: "AnimalFeedInfo",
  components: { AlertMessagebox },
  data: () => {
    return {
      rules: [(value) => !!value || "不能为空"],
      dialogDelete: false,
      menu1: false,
      dialog: false,
      search: "",
      pageCount: 0,
      page: 1,
      //表格标头
      headers: [
        { text: "动物编号", value: "animalId" },
        { text: "员工编号", value: "keeperId" },
        { text: "食谱编号", value: "foodId" },
        { text: "喂食时间", value: "day" },
        { text: "备注", value: "note" },
      ],
      //表格正文
      Feedrecords: [],
      //编辑项暂存
      editedItem: {
        animalId: "",
        keeperId: "",
        foodId: "",
        date: "",
        feedday: "",
        note: "",
      },
      defaultItem: {
        animalId: "",
        keeperId: "",
        foodId: "",
        date: "",
        feedday: "",
        note: "",
      },
    };
  },
  created() {
    //获取喂养关系API
    getFeedRecord({})
      .then((response) => {
        this.pageCount = 0;
        this.page = 1;
        this.Feedrecords = response.data;
      })
      .catch((err) => {
        this.$refs.error_done.updateBody(
          this.$t("common3.transactionFail") + err
        );
        this.$refs.error_done.showAlert();
      });
  },
  methods: {
    //搜索和获取符合条件选项
    searchApp() {
      getFeedRecord()
        .then((response) => {
          this.pageCount = 0;
          this.page = 1;
          this.Feedrecords = response.data;
        })
        .catch((err) => {
          this.$refs.error_done.updateBody(
            this.$t("common3.transactionFail") + err
          );
          this.$refs.error_done.showAlert();
        });
    },
    //表单验证
    validate(item) {
      if (this.$refs.form.validate() === true) {
        this.dialog = false;
        this.insertInfo(item);
      }
    },
    //信息插入
    insertInfo() {
      this.$refs.insertalert2.showAlert();
    },
    //信息插入(确认后)
    insertInfoAfter() {
      createFeedRecord({
        AnimalId: this.editedItem.animalId,
        KeeperId: this.editedItem.keeperId,
        FoodId: this.editedItem.foodId,
        Day: this.editedItem.date + this.editedItem.feedday,
        Note: this.editedItem.note,
      })
        .then(() => {
          //传item
          this.$refs.form.reset();
          this.$refs.commit_done.showAlert();
        })
        .catch((err) => {
          this.$refs.error_done.updateBody(
            this.$t("common3.transactionFail") + err
          );
          this.$refs.error_done.showAlert();
        });
    },
    //表单重置
    reset() {
      this.$refs.form.reset();
    },
    //调出信息编辑弹窗
    editItem(item) {
      this.editedIndex = this.Feedrecords.indexOf(item);
      this.editedItem = Object.assign({}, item);
      this.dialog = true;
    },
    //信息修改并保存
    save() {
      //确认当前不处于新增模式
      if (this.editedIndex > -1) {
        Object.assign(this.Feedrecords[this.editedIndex], this.editedItem);
      } else {
        this.Feedrecords.push(this.editedItem);
        createFeedRecord({
          AnimalId: this.editedItem.animalId,
          KeeperId: this.editedItem.keeperId,
          FoodId: this.editedItem.foodId,
          Day: this.editedItem.date + this.editedItem.feedday,
          Note: this.editedItem.note,
        })
          .then(() => {
            this.$refs.commit_donex.showAlert();
          })
          .catch((err) => {
            this.$refs.error_done.updateBody(
              this.$t("common3.transactionFail") + err
            );
            this.$refs.error_done.showAlert();
          });
      }
      this.close();
    },
    //获取可供选择的日期
    allowedDates: (val) =>
      val <=
      new Date(Date.now() - new Date().getTimezoneOffset() * 60000)
        .toISOString()
        .substr(0, 10),
  },
};
</script>
<style scoped lang="scss">
.zms-query-pagination {
  margin-top: 10px;
  transition: all 0.5s;
}
</style>
