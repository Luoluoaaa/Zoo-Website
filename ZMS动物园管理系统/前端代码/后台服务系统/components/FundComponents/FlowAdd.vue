<template>
  <div class="zms-qtx-adjust">
    <pending-progress-card :zms-show="zmsX" />
    <!--事务成功进度条-->
    <alert-messagebox
      ref="commit_done"
      :alert-title="$t('common3.transactionDoneTitle')"
      :alert-body="$t('common3.transactionDone')"
      :alert-level="`success`"
      :alert-only-confirm="true"
    />
    <!--事务失败提示框-->
    <alert-messagebox
      ref="error_done"
      :alert-title="$t('common3.transactionFailTitle')"
      :alert-body="$t('common3.transactionFail')"
      :alert-level="`error`"
      :alert-only-confirm="true"
    />
    <v-icon color="primary"> mdi-upload-multiple </v-icon>
    <span class="zms-query-titlex">新增账目</span> <br />
    <v-container>
      <v-row>
        <v-col cols="12" md="3">
          <v-text-field v-model="name" label="流水名称" />
        </v-col>
        <v-col cols="12" md="3">
          <v-text-field v-model="type" label="流水类别" />
        </v-col>
        <v-col cols="12" md="3">
          <v-text-field v-model="amount" label="流水数额" />
        </v-col>
        <v-col cols="12" md="3">
          <v-text-field v-model="staff_id" label="负责人" disabled />
        </v-col>
        <v-col cols="12" md="12">
          <v-text-field v-model="note" label="备注" />
        </v-col>
        <v-col cols="12" sm="6" md="6">
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
                v-model="transactionTime"
                label="交易时间"
                prepend-icon="mdi-calendar"
                readonly
                v-bind="attrs"
                v-on="on"
              />
            </template>
            <v-date-picker
              v-model="transactionTime"
              :allowed-dates="allowedDates"
              color="primary"
              width="400"
              @input="menu3 = false"
            />
          </v-menu>
        </v-col>
        <v-col cols="12" sm="6" md="6">
          <v-select
            v-model="bankAccId"
            :items="bankAccList"
            :label="$t('fund.bankaccid')"
            prepend-icon="mdi-card-account-details"
          />
        </v-col>
      </v-row>
      <v-row>
        <v-btn block color="success" @click="submitTp"> 提交流水记录 </v-btn>
      </v-row>
    </v-container>
  </div>
</template>
<script>
import { AddFundAccount, getAccountList } from "../../apis/fund";
import PendingProgressCard from "../CommonComponents/PendingProgressCard.vue";
import AlertMessagebox from "../CommonComponents/AlertMessagebox.vue";
export default {
  name: "FlowAdd",
  components: {
    PendingProgressCard,
    AlertMessagebox,
  },
  data() {
    return {
      zmsX: false,
      name: null,
      type: null,
      amount: null,
      staff_id: localStorage.getItem("zmsBKId"),
      note: null,
      transactionTime: null,
      fundAccId: "x",
      bankAccList: [],
      bankAccId: null,
      menu3: false,
    };
  },
  created() {
    this.getBankAcc();
  },
  methods: {
    allowedDates: (val) =>
      val <=
      new Date(Date.now() - new Date().getTimezoneOffset() * 60000)
        .toISOString()
        .substr(0, 10),
    getBankAcc() {
      this.zmsX = true;
      setTimeout(() => {
        getAccountList()
          .then((response) => {
            for (let i = 0; i < response.data.length; i++) {
              this.bankAccList.push(null);
              this.$set(this.bankAccList, i, response.data[i].id);
            }
            this.zmsX = false;
          })
          .catch((err) => {
            this.zmsX = false;
            this.$refs.error_done.updateBody(
              this.$t("common3.transactionFail") + err
            );
            this.$refs.error_done.showAlert();
          });
      }, 500);
    },
    submitTp() {
      if (this.name === "" || this.name === null) {
        this.$refs.error_done.updateBody(
          this.$t("common3.transactionFail") + "填写错误：请填写名称"
        );
        this.$refs.error_done.showAlert();
        return;
      }
      if (this.type === "" || this.type === null) {
        this.$refs.error_done.updateBody(
          this.$t("common3.transactionFail") + "填写错误：请填写类型"
        );
        this.$refs.error_done.showAlert();
        return;
      }
      if (isNaN(parseInt(this.amount)) || this.amount.indexOf(".") != -1) {
        this.$refs.error_done.updateBody(
          this.$t("common3.transactionFail") +
            "填写错误：请填写金额，保证为整数"
        );
        this.$refs.error_done.showAlert();
        return;
      }
      if (this.note === "" || this.note === null) {
        this.$refs.error_done.updateBody(
          this.$t("common3.transactionFail") +
            "填写错误：请填写备注，为空请填写无"
        );
        this.$refs.error_done.showAlert();
        return;
      }
      if (this.transactionTime === "" || this.transactionTime === null) {
        this.$refs.error_done.updateBody(
          this.$t("common3.transactionFail") + "填写错误：请填写交易时间"
        );
        this.$refs.error_done.showAlert();
        return;
      }
      if (this.bankAccId === "" || this.bankAccId === null) {
        this.$refs.error_done.updateBody(
          this.$t("common3.transactionFail") + "填写错误：请选择银行账户ID"
        );
        this.$refs.error_done.showAlert();
        return;
      }
      this.zmsX = true;
      AddFundAccount({
        name: this.name,
        type: this.type,
        amount: parseInt(this.amount),
        staffId: this.staff_id,
        note: this.note,
        transactionTime: this.transactionTime,
        fundAccId: "1919810",
        bankAccId: this.bankAccId,
      })
        .then(() => {
          this.zmsX = false;
          this.$refs.commit_done.showAlert();
        })
        .catch((err) => {
          this.zmsX = false;
          this.$refs.error_done.updateBody(
            this.$t("common3.transactionFail") + err
          );
          this.$refs.error_done.showAlert();
        });
    },
  },
};
</script>
<style scoped>
.zms-qtx-adjust {
  margin-top: 10px;
  margin-bottom: 20px;
  display: block;
}
</style>
