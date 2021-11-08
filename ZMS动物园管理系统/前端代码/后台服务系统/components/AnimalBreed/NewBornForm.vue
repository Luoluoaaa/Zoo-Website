<template>
  <div>
    <pending-progress-card :zms-show="zmsShowLoadingBar" />
    <!--新生儿信息提示弹窗-->
    <alert-messagebox
      ref="insertalert2"
      alert-title="保存新生儿信息"
      :alert-body="`是否创建新生动物档案信息?`"
      alert-level="warning"
      :alert-model="{}"
      @alertConfirm="insertInfoAfter"
    />
    <!--新建成功弹窗-->
    <alert-messagebox
      ref="commit_done"
      :alert-title="$t('common3.transactionDoneTitle')"
      :alert-body="`新建信息保存成功`"
      :alert-level="`success`"
      :alert-only-confirm="true"
    />
    <!--失败弹窗-->
    <alert-messagebox
      ref="error_done"
      :alert-title="$t('common3.transactionFailTitle')"
      :alert-body="$t('common3.transactionFail') + errorInfo"
      :alert-level="`error`"
      :alert-only-confirm="true"
    />
    <!--主UI-->
    <v-card>
      <v-card-title>
        <span class="child-info-title">新生儿信息登记</span>
      </v-card-title>
      <v-card-text>
        <!--主表单-->
        <v-form ref="form" v-model="valid" lazy-validation>
          <v-container>
            <v-row>
              <v-col cols="12" sm="6">
                <v-text-field
                  v-model="animalinfo.id"
                  label="动物编号"
                  :rules="rules"
                  hide-details="auto"
                  required
                />
              </v-col>
              <v-col cols="12" sm="6">
                <v-text-field
                  v-model="animalinfo.species"
                  label="物种*"
                  :rules="rules"
                  hide-details="auto"
                  required
                />
              </v-col>
              <v-col cols="12" sm="6">
                <v-text-field
                  v-model="animalinfo.name"
                  label="动物姓名*"
                  :rules="rules"
                  hide-details="auto"
                  required
                />
              </v-col>
            </v-row>

            <v-row>
              <v-col cols="12" sm="6" md="4">
                <v-select
                  v-model="animalinfo.gender"
                  :items="['雄性', '雌性']"
                  label="动物性别*"
                  :rules="rules"
                  hide-details="auto"
                  required
                />
              </v-col>
              <v-col cols="12" sm="6" md="4">
                <v-text-field
                  v-model="animalinfo.age"
                  label="年龄*"
                  :rules="rules"
                  hide-details="auto"
                  required
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
                      v-model="animalinfo.birthDate"
                      label="出生日期"
                      prepend-icon="mdi-calendar"
                      readonly
                      v-bind="attrs"
                      v-on="on"
                    />
                  </template>
                  <v-date-picker
                    v-model="animalinfo.birthDate"
                    color="primary"
                    width="400"
                    :allowed-dates="allowedDates"
                    @input="menu2 = false"
                  />
                </v-menu>
              </v-col>
            </v-row>
            <v-row class="last-row" margin-bottom="0">
              <v-col cols="12" sm="6">
                <v-text-field
                  v-model="animalinfo.bodyLength"
                  label="身高/体长"
                />
              </v-col>
              <v-col cols="12" sm="6">
                <v-text-field
                  v-model="animalinfo.weight"
                  label="体重*"
                  :rules="rules"
                  hide-details="auto"
                  required
                />
              </v-col>
              <v-col cols="12" sm="6">
                <v-select
                  v-model="animalinfo.physicalCondition"
                  :items="['良好', '生病', '虚弱']"
                  label="健康状态*"
                  :rules="rules"
                  hide-details="auto"
                  required
                />
              </v-col>
            </v-row>
            <!--表单操作-->
            <v-row class="botton-style">
              <v-col cols="6" />
              <v-col>
                <v-btn
                  :disabled="!valid"
                  color="success"
                  class="mr-4"
                  right
                  @click="validate(animalinfo)"
                >
                  提交
                </v-btn>

                <v-btn color="error" class="mr-4" right @click="reset">
                  清除
                </v-btn>
              </v-col>
            </v-row>
          </v-container>
        </v-form>
      </v-card-text>
    </v-card>
  </div>
</template>

<script>
//组件引入
import PendingProgressCard from "../CommonComponents/PendingProgressCard.vue";
import AlertMessagebox from "../CommonComponents/AlertMessagebox.vue";
//API 引入
import { createinformation } from "../../apis/animalInfo";
//组件导出
export default {
  name: "NewBornForm",
  components: {
    AlertMessagebox,
    PendingProgressCard,
  },
  data: () => ({
    valid: true, //有效位
    zmsShowLoadingBar: false, //进度条显示
    rules: [(value) => !!value || "不能为空"], //表单验证规则
    //动物信息暂存
    animalinfo: {
      id: "",
      species: "",
      name: "",
      gender: "",
      age: "",
      weight: "",
      physicalCondition: "",
      breedSituation: "",
      photo: "/static/images/panda.jpg",
    },
  }),
  methods: {
    //表单验证
    validate(item) {
      if (this.$refs.form.validate() === true) {
        this.insertInfo(item);
      }
    },
    //信息插入操作
    insertInfo() {
      this.$refs.insertalert2.showAlert();
    },
    //信息插入操作（确认后）
    insertInfoAfter() {
      this.zmsShowLoadingBar = true;
      //调用API
      createinformation({
        id: this.animalinfo.id,
        species: this.animalinfo.species,
        name: this.animalinfo.name,
        gender: this.animalinfo.gender,
        birthDate: this.animalinfo.birthDate,
        weight: parseInt(this.animalinfo.weight),
        age: parseInt(this.animalinfo.age),
        bodyLength: parseInt(this.animalinfo.bodyLength),
        photo: "Cz==",
        physicalCondition: this.animalinfo.physicalCondition,
        breedSituation: "无",
      })
        .then(() => {
          this.$refs.form.reset();
          this.$refs.commit_done.showAlert();
          this.zmsShowLoadingBar = false;
        })
        .catch((err) => {
          this.zmsShowLoadingBar = false;
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
    //获取可选日期
    allowedDates: (val) =>
      val <=
      new Date(Date.now() - new Date().getTimezoneOffset() * 60000)
        .toISOString()
        .substr(0, 10),
  },
};
</script>

<style scoped lang="scss">
.create-new-info {
  padding-left: 0px;
  padding-right: 20px;
  padding-top: 50px;
  padding-bottom: 50px;
  background-color: #fafafa;
}
.birth-info-title {
  font-size: 100%;
  font-weight: bold;
  color: #dd2666;
  letter-spacing: 1px;
  position: relative;
  top: 0px;
}
.child-info-title {
  font-size: 100%;
  font-weight: bold;
  color: #dd2666;
  letter-spacing: 1px;
  position: relative;
  top: 0px;
}
</style>
