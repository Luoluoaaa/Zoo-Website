<template>
  <div class="create-new-info">
    <!--生产信息保存提示框-->
    <alert-messagebox
      ref="insertalert1"
      alert-title="保存生产信息"
      :alert-body="`是否保存编号为` + insertId + `生产信息?`"
      alert-level="warning"
      :alert-model="{}"
      @alertConfirm="insertBirthInfoAfter"
    />
    <!--新建生产信息提示框-->
    <alert-messagebox
      ref="commit_done"
      :alert-title="$t('common3.transactionDoneTitle')"
      :alert-body="`新建信息保存成功`"
      :alert-level="`success`"
      :alert-only-confirm="true"
    />
    <!--事务失败提示框-->
    <alert-messagebox
      ref="error_done"
      :alert-title="$t('common3.transactionFailTitle')"
      :alert-body="$t('common3.transactionFail') + errorInfo"
      :alert-level="`error`"
      :alert-only-confirm="true"
    />
    <!--加载条-->
    <pending-progress-card :zms-show="zmsShowLoadingBar" />
    <!--主UI-->
    <v-row>
      <v-col cols="6" flex align-stretch>
        <v-card>
          <v-card-title>
            <span class="birth-info-title">生产信息登记</span>
          </v-card-title>
          <v-card-text>
            <!--表单正文-->
            <v-form ref="form" v-model="valid" lazy-validation>
              <v-container>
                <v-row>
                  <v-col cols="12">
                    <v-text-field
                      v-model="birthinfo.ani_id"
                      label="动物编号*"
                      :rules="rules"
                      hide-details="auto"
                      required
                    />
                  </v-col>
                  <v-col cols="12">
                    <v-select
                      v-model="birthinfo.success"
                      label="是否顺利*"
                      :items="['顺利', '不顺利']"
                      :rules="rules"
                      hide-details="auto"
                      required
                    />
                  </v-col>
                  <v-col cols="12">
                    <v-text-field
                      v-model="birthinfo.children_num"
                      label="孩子数量*"
                      :rules="rules"
                      hide-details="auto"
                      required
                    />
                  </v-col>
                  <v-col cols="12" class="temp">
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
                          v-model="birthinfo.date_of_birth"
                          label="出生日期"
                          prepend-icon="mdi-calendar"
                          readonly
                          v-bind="attrs"
                          v-on="on"
                        />
                      </template>
                      <v-date-picker
                        v-model="birthinfo.date_of_birth"
                        color="primary"
                        width="400"
                        :allowed-dates="allowedDates"
                        @input="menu2 = false"
                      />
                    </v-menu>
                  </v-col>
                </v-row>
              </v-container>
              <!--表单操作按钮-->
              <v-row margin-top="50px" class="botton-style">
                <v-col cols="6" />
                <v-col>
                  <v-btn
                    :disabled="!valid"
                    color="success"
                    class="mr-4"
                    right
                    @click="validate(birthinfo)"
                  >
                    提交
                  </v-btn>
                  <v-btn color="error" class="mr-4" right @click="reset">
                    清除
                  </v-btn>
                </v-col>
              </v-row>
            </v-form>
          </v-card-text>
        </v-card>
      </v-col>
      <!--新生儿登记组件-->
      <v-col cols="6" flex align-self>
        <new-born-form />
      </v-col>
    </v-row>
  </div>
</template>
<script>
//API 引入
import { createBreedInfo } from "../../apis/animalBreed";
//组件引入
import NewBornForm from "./NewBornForm.vue";
import AlertMessagebox from "../CommonComponents/AlertMessagebox.vue";
import PendingProgressCard from "../CommonComponents/PendingProgressCard.vue";
//Vue 组件导出
export default {
  name: "CreateNewBornInfo",
  components: {
    NewBornForm,
    AlertMessagebox,
    PendingProgressCard,
  },
  data: () => ({
    valid: true, //有效位
    zmsShowLoadingBar: false, //进度条显示
    rules: [(value) => !!value || "不能为空"], //表单验证规则
    //表单数据存储对象
    birthinfo: {
      ani_id: "",
      success: "",
      date_of_birth: "",
      children_num: "",
    },
  }),
  methods: {
    //表单验证
    validate(birthinfo) {
      if (this.$refs.form.validate() === true) {
        this.insertbirthinfo(birthinfo);
      }
    },
    //插入生产信息
    insertbirthinfo(birthinfo) {
      this.insertId = birthinfo.ani_id;
      this.$refs.insertalert1.updateBody(
        `是否保存编号为` + this.insertId + `生产信息?`
      );
      this.$refs.insertalert1.showAlert();
    },
    //在插入生产信息（后续处理）
    insertBirthInfoAfter() {
      this.zmsShowLoadingBar = true;
      createBreedInfo({
        ani_id: this.birthinfo.ani_id,
        time: this.birthinfo.date_of_birth,
        success: this.birthinfo.success === "顺利" ? true : false,
        children_num: parseInt(this.birthinfo.children_num),
      })
        .then(() => {
          //参数为birthinfo
          this.$refs.form.reset();
          this.$refs.commit_done.showAlert();
          this.zmsShowLoadingBar = false;
          this.reset();
        })
        .catch((err) => {
          this.submitStat = false;
          this.$refs.error_done.updateBody(
            this.$t("common3.transactionFail") + err
          );
          this.$refs.error_done.showAlert();
          this.zmsShowLoadingBar = false;
        });
    },
    //表单充值
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
.temp {
  display: block;
  margin-bottom: 50px;
}
.create-new-info {
  padding-left: 60px;
  padding-right: 60px;
  padding-top: 20px;
  padding-bottom: 20px;
  width: 90vw;
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
