<template>
  <div class="zms-animal-recipe">
    <!--进度条-->
    <pending-progress-card
      :zms-pending-list="pendingList"
      :zms-show="pendingShow"
    />
    <!--失败弹窗-->
    <alert-messagebox
      ref="error_done"
      :alert-title="$t('common3.transactionFailTitle')"
      :alert-body="$t('common3.transactionFail')"
      :alert-level="`error`"
      :alert-only-confirm="true"
    />
    <!--成功弹窗-->
    <alert-messagebox
      ref="commit_donex"
      :alert-title="$t('common3.transactionDoneTitle')"
      :alert-body="$t('common3.transactionDone')"
      :alert-level="`success`"
      :alert-only-confirm="true"
    />
    <!--删除确认提示框-->
    <alert-messagebox
      ref="deletealert"
      alert-title="删除食谱信息"
      :alert-body="`是否删除编号为` + delId + `的食谱信息?`"
      alert-level="warning"
      :alert-model="{}"
      @alertConfirm="DeleteRecipeConfirm()"
    />
    <!--修改提示框-->
    <alert-messagebox
      ref="updatealert"
      alert-title="修改食谱信息"
      :alert-body="`是否保存对编号为` + updateId + `的食谱的修改?`"
      alert-level="warning"
      :alert-model="{}"
      @alertConfirm="insertRecipeConfirm"
    />
    <!--弹出的待确认窗口相同-->
    <alert-messagebox
      ref="insertalert2"
      alert-title="保存新建食谱信息"
      :alert-body="`是否创建新的食谱信息?`"
      alert-level="warning"
      :alert-model="{}"
      @alertConfirm="insertRecipeConfirm"
    />
    <!--insertInfoAfter-->
    <alert-messagebox
      ref="commit_done"
      :alert-title="$t('common3.transactionDoneTitle')"
      :alert-body="`修改成功`"
      :alert-level="`success`"
      :alert-only-confirm="true"
    />
    <!--新建信息成功提示-->
    <alert-messagebox
      ref="commit_done"
      :alert-title="$t('common3.transactionDoneTitle')"
      :alert-body="`新建信息保存成功`"
      :alert-level="`success`"
      :alert-only-confirm="true"
    />
    <v-container fluid>
      <!--搜索栏-->
      <v-row class="toprow">
        <v-col cols="12" sm="8">
          <div @keyup.enter="search">
            <v-menu offset-y>
              <template v-slot:activator="{ on }">
                <v-text-field
                  ref="search"
                  v-model="text_search"
                  solo
                  hide-details
                  label="请输入食谱的对应物种"
                  append-icon="mdi-magnify"
                  @click:append="showSearchTips"
                  v-on="on"
                />
              </template>
            </v-menu>
          </div>
        </v-col>
        <v-col cols="12" sm="4">
          <v-dialog v-model="dialog" persistent max-width="500px">
            <template v-slot:activator="{ on, attrs }">
              <v-btn
                v-ripple
                color="primary"
                block
                class="zms-width"
                dark
                height="50px"
                align-center
                @click="createItem({ p: on, x: attrs })"
              >
                新增食谱
              </v-btn>
            </template>
            <!--主体-->
            <v-card>
              <v-card-title>
                <span class="text-h5"> {{ formTitle }}</span>
              </v-card-title>
              <v-card-text>
                <v-form ref="form">
                  <v-container>
                    <v-row dense>
                      <v-col cols="12" sm="6">
                        <v-text-field
                          v-model="editedItem.id"
                          label="食谱编号*"
                          :rules="rules"
                          hide-details="auto"
                          required
                        />
                      </v-col>
                      <v-col cols="12" sm="6">
                        <v-text-field
                          v-model="editedItem.species"
                          label="物种*"
                          :rules="rules"
                          hide-details="auto"
                          required
                        />
                      </v-col>
                    </v-row>
                    <v-row dense>
                      <v-col cols="12" sm="6">
                        <v-text-field
                          v-model="editedItem.foodList1"
                          label="食材1*"
                          :rules="rules"
                          hide-details="auto"
                          required
                        />
                      </v-col>
                      <v-col cols="12" sm="6">
                        <v-text-field
                          v-model="editedItem.foodWeight1"
                          label="重量1*"
                          :rules="rules"
                          hide-details="auto"
                          required
                        />
                      </v-col>
                      <v-col cols="12" sm="6">
                        <v-text-field
                          v-model="editedItem.foodList2"
                          label="食材2"
                        />
                      </v-col>
                      <v-col cols="12" sm="6">
                        <v-text-field
                          v-model="editedItem.foodWeight2"
                          label="重量2"
                        />
                      </v-col>
                    </v-row>
                    <v-row dense>
                      <v-col cols="12" sm="6">
                        <v-text-field
                          v-model="editedItem.foodList3"
                          label="食材3"
                        />
                      </v-col>
                      <v-col cols="12" sm="6">
                        <v-text-field
                          v-model="editedItem.foodWeight3"
                          label="重量3"
                        />
                      </v-col>
                    </v-row>
                    <v-row dense>
                      <v-col cols="12" sm="6">
                        <v-text-field
                          v-model="editedItem.foodList4"
                          label="食材4"
                        />
                      </v-col>
                      <v-col cols="12" sm="6">
                        <v-text-field
                          v-model="editedItem.foodWeight4"
                          label="重量4"
                        />
                      </v-col>
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
      <!--食谱清单显示-->
      <v-row>
        <v-col
          v-for="(recipe, i) in recipes"
          :key="i"
          :cols="12"
          :sm="6"
          :page.sync="page"
          :recipes-per-page="10"
          hide-default-footer
          @page-count="pageCount = $event"
        >
          <v-card class="new-recipe">
            <v-row>
              <v-col cols="3" class="block-T">
                <span height="50%">
                  <br />
                  <h4>{{ recipe.species }}食谱</h4>
                  <h4>{{ recipe.id }}</h4>
                </span>
              </v-col>
              <v-col cols="15" class="right-block">
                <v-row v-if="recipe.foodList1 != null" no-gutters>
                  <v-col cols="6"> {{ recipe.foodList1 }} </v-col>
                  <v-col cols="6"> {{ recipe.foodWeight1 }}kg </v-col>
                </v-row>
                <v-row v-if="recipe.foodList2 != null" no-gutters>
                  <v-col cols="6"> {{ recipe.foodList2 }} </v-col>
                  <v-col cols="6"> {{ recipe.foodWeight2 }}kg </v-col>
                </v-row>
                <v-row v-if="recipe.foodList2 == null" no-gutters>
                  <v-col cols="6"> 没有食材2 </v-col>
                </v-row>
                <v-row v-if="recipe.foodList3 != null" no-gutters>
                  <v-col cols="6"> {{ recipe.foodList3 }} </v-col>
                  <v-col cols="6"> {{ recipe.foodWeight3 }}kg </v-col>
                </v-row>
                <v-row v-if="recipe.foodList3 == null" no-gutters>
                  <v-col cols="6"> 没有食材3 </v-col>
                </v-row>
                <v-row v-if="recipe.foodList4 != null" no-gutters>
                  <v-col cols="6"> {{ recipe.foodList4 }} </v-col>
                  <v-col cols="6"> {{ recipe.foodWeight4 }}kg </v-col>
                </v-row>
                <v-row v-if="recipe.foodList4 == null" no-gutters>
                  <v-col cols="6"> 没有食材4 </v-col>
                </v-row>
                <v-divider margin-left="-5" width="80%" />
                <v-row dense>
                  <v-col cols="6">
                    <v-btn icon>
                      <v-icon small class="mr-2" @click="editItem2(recipe)">
                        mdi-pencil
                      </v-icon>
                    </v-btn>
                  </v-col>
                  <v-col cols="6">
                    <v-btn icon>
                      <v-icon
                        small
                        class="mr-2"
                        @click="deleteItem2(recipe.id)"
                      >
                        mdi-delete
                      </v-icon>
                    </v-btn>
                  </v-col>
                </v-row>
              </v-col>
            </v-row>
          </v-card>
        </v-col>
      </v-row>
    </v-container>
  </div>
</template>
<script>
//API 导入
import {
  getRecipe,
  createRecipe,
  updateRecipe,
  deleteRecipe,
} from "../../apis/recipe";
//组件导入
import PendingProgressCard from "../CommonComponents/PendingProgressCard.vue";
import AlertMessagebox from "../CommonComponents/AlertMessagebox.vue";
//组件导出
export default {
  name: "AnimalRecipeInfo",
  components: {
    PendingProgressCard,
    AlertMessagebox,
  },
  data: () => ({
    //表单和验证相关
    valid: true,
    updateId: 0,
    isToCreateItem: false, //真为新建，假为修改
    dialogDelete: false,
    rules: [(value) => !!value || "不能为空"],
    text: "",
    dialog: false,
    showSelect: false,
    text_search: "",
    pageCount: 0,
    page: 1,
    //食谱列表
    recipes: [],
    //进度条相关
    pendingList: [],
    pendingShow: false,
    //搜索建议
    showSearchSuggestion: false,
    //编辑下标
    editedIndex: -1,
    //编辑信息暂存
    editedItem: {
      id: "",
      species: "",
      foodList1: "",
      foodWeight1: "",
      foodList2: "",
      weight2: "",
      foodList3: "",
      weight3: "",
      foodList4: "",
      weight4: "",
    },
    //删除信息暂存
    defaultItem: {
      id: "",
      species: "",
      foodList1: "",
      foodWeight1: "",
      foodList2: "",
      foodWeight2: "",
      foodList3: "",
      foodWeight3: "",
      foodList4: "",
      foodWeight4: "",
    },
  }),
  computed: {
    //弹框标题
    formTitle() {
      return this.editedIndex === -1 ? "新增食谱" : "修改食谱";
    },
  },
  watch: {
    text: "inputHandle",
    dialog(val) {
      val || this.close();
    },
    dialogDelete(val) {
      val || this.closeDelete();
    },
  },
  created() {
    //载入时获取食谱信息
    this.pendingShow = true;
    getRecipe({
      recipe_id: "",
      species: "",
    })
      .then((response) => {
        this.recipes = response.data;
        this.pendingShow = false;
      })
      .catch((err) => {
        this.$refs.error_done.updateBody(
          this.$t("common3.transactionFail") + err
        );
        this.$refs.error_done.showAlert();
        this.pendingShow = false;
      });
  },
  methods: {
    //创建食谱调出
    createItem(item) {
      this.dialog = true;
      this.isToCreateItem = true;
      this.editItem(item);
    },
    //编辑信息(更新)
    editItem2(item) {
      this.updateId = item.id;
      this.isToCreateItem = false;
      this.editItem(item);
    },
    //编辑信息
    editItem(item) {
      this.insertId = item.id;
      this.editedIndex = this.recipes.indexOf(item);
      this.editedItem = Object.assign({}, item);
      this.dialog = true;
    },
    //删除信息
    deleteItem(item) {
      this.editedIndex = this.recipes.indexOf(item);
      this.editedItem = Object.assign({}, item);
      this.dialogDelete = true;
    },
    //删除信息(确认)
    deleteItemConfirm() {
      this.recipes.splice(this.editedIndex, 1);
      this.closeDelete();
    },
    //关闭弹框
    close() {
      this.dialog = false;
      this.$nextTick(() => {
        this.editedItem = Object.assign({}, this.defaultItem);
        this.editedIndex = -1;
      });
    },
    //关闭删除确认弹框
    closeDelete() {
      this.dialogDelete = false;
      this.$nextTick(() => {
        this.editedItem = Object.assign({}, this.defaultItem);
        this.editedIndex = -1;
      });
    },
    //搜索和获取食谱信息
    showSearchTips() {
      this.pendingShow = true;
      setTimeout(() => {
        getRecipe({
          recipe_id: "",
          species: this.text_search,
        })
          .then((response) => {
            this.recipes = response.data;
            this.show = false;
            this.pendingShow = false;
            this.$store.dispatch("showToastNotify", {
              type: "success",
              info: this.$t("common2.transactionDone"),
            });
          })
          .catch((err) => {
            this.$refs.error_done.updateBody(
              this.$t("common3.transactionFail") + err
            );
            this.$refs.error_done.showAlert();
            this.pendingShow = false;
          });
      }, 500);
    },
    //保存修改信息
    save() {
      if (this.editedIndex > -1) {
        Object.assign(this.recipes[this.editedIndex], this.editedItem);
      } else {
        this.recipes.push(this.editedItem);
      }
      this.close();
    },
    //表单验证
    validate(id) {
      if (this.$refs.form.validate() === true) {
        this.insertrecipe(id); //新增或修改的对象的ID
      }
    },
    //新增或修改食谱
    insertrecipe() {
      if (this.isToCreateItem) {
        this.$refs.insertalert2.showAlert(); //新建
      } else {
        this.$refs.updatealert.updateBody(
          `是否保存对编号为` + this.updateId + `的食谱的修改?`
        );
        this.$refs.updatealert.showAlert(); //修改
      }
    },
    //新增或修改食谱(确认后)
    insertRecipeConfirm() {
      //表单输入有效性验证
      if (this.editedItem.foodList2 === undefined) {
        this.editedItem.foodList2 = "";
      }
      if (this.editedItem.foodList3 === undefined) {
        this.editedItem.foodList3 = "";
      }
      if (this.editedItem.foodList4 === undefined) {
        this.editedItem.foodList4 = "";
      }

      if (
        this.editedItem.foodList2 === "" &&
        (this.editedItem.foodList3 != "" || this.editedItem.foodList4 != "")
      ) {
        this.$refs.error_done.updateBody("食谱2此时需要进行填写");
        this.$refs.error_done.showAlert();
        return;
      }
      if (this.editedItem.foodList3 === "" && this.editedItem.foodList4 != "") {
        this.$refs.error_done.updateBody("食谱3此时需要进行填写");
        this.$refs.error_done.showAlert();
        return;
      }
      if (
        this.editedItem.foodList3 === "" &&
        !isNaN(parseInt(this.editedItem.foodWeight3)) &&
        parseInt(this.editedItem.foodWeight3) <= 0
      ) {
        this.$refs.error_done.updateBody("食谱3此时需要进行填写");
        this.$refs.error_done.showAlert();
        return;
      }
      if (
        this.editedItem.foodList4 === "" &&
        !isNaN(parseInt(this.editedItem.foodWeight4)) &&
        parseInt(this.editedItem.foodWeight4) <= 0
      ) {
        this.$refs.error_done.updateBody("食谱4此时需要进行填写");
        this.$refs.error_done.showAlert();
        return;
      }
      if (
        this.editedItem.foodList2 === "" &&
        !isNaN(parseInt(this.editedItem.foodWeight2)) &&
        parseInt(this.editedItem.foodWeight2) <= 0
      ) {
        this.$refs.error_done.updateBody("食谱2此时需要进行填写");
        this.$refs.error_done.showAlert();
        return;
      }
      if (
        this.editedItem.foodWeight4 != "" &&
        parseInt(this.editedItem.foodWeight4) <= 0
      ) {
        this.$refs.error_done.updateBody("食谱4重量非法");
        this.$refs.error_done.showAlert();
        return;
      }
      if (
        this.editedItem.foodWeight3 != "" &&
        parseInt(this.editedItem.foodWeight3) <= 0
      ) {
        this.$refs.error_done.updateBody("食谱3重量非法");
        this.$refs.error_done.showAlert();
        return;
      }
      if (
        this.editedItem.foodWeight2 != "" &&
        parseInt(this.editedItem.foodWeight2) <= 0
      ) {
        this.$refs.error_done.updateBody("食谱2重量非法");
        this.$refs.error_done.showAlert();
        return;
      }
      if (
        this.editedItem.foodWeight1 != "" &&
        parseInt(this.editedItem.foodWeight1) <= 0
      ) {
        this.$refs.error_done.updateBody("食谱1重量非法");
        this.$refs.error_done.showAlert();
        return;
      }
      if (
        this.editedItem.foodWeight4 != "" &&
        parseInt(this.editedItem.foodWeight4) > 999
      ) {
        this.$refs.error_done.updateBody("食谱4重量非法");
        this.$refs.error_done.showAlert();
        return;
      }
      if (
        this.editedItem.foodWeight3 != "" &&
        parseInt(this.editedItem.foodWeight3) > 999
      ) {
        this.$refs.error_done.updateBody("食谱3重量非法");
        this.$refs.error_done.showAlert();
        return;
      }
      if (
        this.editedItem.foodWeight2 != "" &&
        parseInt(this.editedItem.foodWeight2) > 999
      ) {
        this.$refs.error_done.updateBody("食谱2重量非法");
        this.$refs.error_done.showAlert();
        return;
      }
      if (
        this.editedItem.foodWeight1 != "" &&
        parseInt(this.editedItem.foodWeight1) > 999
      ) {
        this.$refs.error_done.updateBody("食谱1重量非法");
        this.$refs.error_done.showAlert();
        return;
      }
      //判断新增还是创建
      if (this.isToCreateItem) {
        this.pendingShow = true;
        //API调用
        createRecipe({
          id: this.editedItem.id,
          species: this.editedItem.species,
          foodList1: this.editedItem.foodList1,
          foodWeight1: parseInt(this.editedItem.foodWeight1),
          foodList2: this.editedItem.foodList2,
          foodWeight2: parseInt(this.editedItem.foodWeight2),
          foodList3: this.editedItem.foodList3,
          foodWeight3: parseInt(this.editedItem.foodWeight3),
          foodList4: this.editedItem.foodList4,
          foodWeight4: parseInt(this.editedItem.foodWeight4),
        })
          .then(() => {
            this.dialog = false;
            this.$refs.form.reset();
            this.$refs.commit_donex.showAlert();
            this.pendingShow = false;
            this.showSearchTips();
          })
          .catch((err) => {
            this.$refs.error_done.updateBody(
              this.$t("common3.transactionFail") + err
            );
            this.$refs.error_done.showAlert();
            this.pendingShow = false;
          });
      } else {
        this.pendingShow = true;
        //更新食谱
        updateRecipe(
          {
            id: this.editedItem.id,
            species: this.editedItem.species,
            foodList1: this.editedItem.foodList1,
            foodWeight1: parseInt(this.editedItem.foodWeight1),
            foodList2: this.editedItem.foodList2,
            foodWeight2: parseInt(this.editedItem.foodWeight2),
            foodList3: this.editedItem.foodList3,
            foodWeight3: parseInt(this.editedItem.foodWeight3),
            foodList4: this.editedItem.foodList4,
            foodWeight4: parseInt(this.editedItem.foodWeight4),
          },
          this.editedItem.id
        )
          .then(() => {
            this.dialog = false;
            this.$refs.form.reset();
            this.$refs.commit_done.showAlert();
            this.pendingShow = false;
            this.showSearchTips();
          })
          .catch((err) => {
            this.$refs.error_done.updateBody(
              this.$t("common3.transactionFail") + err
            );
            this.$refs.error_done.showAlert();
            this.pendingShow = false;
          });
      }
    },
    //删除食谱
    deleteItem2(x) {
      this.delId = x;

      this.$refs.deletealert.updateBody(
        `是否删除编号为` + this.delId + `的食谱信息?`
      );
      this.$refs.deletealert.showAlert();
    },
    //删除食谱(确认后)
    DeleteRecipeConfirm() {
      this.pendingShow = true;
      deleteRecipe({}, this.delId)
        .then(() => {
          this.$refs.commit_done.showAlert();
          this.pendingShow = false;
          this.showSearchTips();
        })
        .catch((err) => {
          this.$refs.error_done.updateBody(
            this.$t("common3.transactionFail") + err
          );
          this.$refs.error_done.showAlert();
          this.pendingShow = false;
        });
    },
  },
};
</script>

<style scoped lang="scss">
.new-recipe {
  border-radius: 10px;
  margin-top: 20px;
}
.spanLine {
  direction: "vertical";
  z-index: 10000;
  color: #69585e;
}
.block-T {
  color: #fff;
  text-align: center;
  z-index: 100;
  margin-left: 10px;
  border-top-left-radius: 10px;
  border-bottom-left-radius: 10px;
  background: #1976d2;
}
.small-cols {
  margin-top: 0%;
  margin-bottom: 0%;
  padding: 5px 5px 1px 1px;
}
.small-cols-left {
  margin-top: 0%;
  margin-bottom: 0%;
  padding: 5px 5px 1px 1px;
}
</style>
