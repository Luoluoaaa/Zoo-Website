<template>
  <div class="zms-home-notice">
    <alert-messagebox
      ref="error_done"
      :alert-title="$t('common3.transactionFailTitle')"
      :alert-body="$t('common3.transactionFail') + errorInfo"
      :alert-level="`error`"
      :alert-only-confirm="true"
    />
    <div class="zms-bankaccount-op">
      <div class="zms-bankaccount-optitle">
        <v-icon color="primary"> mdi-cog </v-icon>
        <span class="zms-query-title">账户信息管理</span>
      </div>
      <span class="zms-bankaccount-subtext">可以进行下列操作</span>
      <v-btn light color="primary" @click="calloutNewBankAccountBox">
        <v-icon>mdi-plus-thick</v-icon> {{ $t("fund.newBankAccountBtn") }}
      </v-btn>
    </div>
    <v-divider />
    <div class="zms-bankaccount-list">
      <div class="zms-bankaccount-optitle">
        <v-icon color="primary"> mdi-cog </v-icon>
        <span class="zms-query-title">账户概览</span>
      </div>
      <span>下方列出了当前所有的园区账户信息</span>
      <v-container>
        <v-row>
          <v-col
            v-for="item in accountList.length"
            :key="item"
            cols="12"
            md="4"
            class="align-self-stretch"
          >
            <v-card
              :class="cardNightClass"
              :ripple="{ class: null }"
              class="mx-auto"
              max-width="400"
            >
              <v-img
                class="white--text align-end"
                height="170px"
                src="https://cdn.vuetifyjs.com/images/cards/docks.jpg"
              >
                <v-card-title>
                  {{ $t("fund.account") + ` ` + accountList[item - 1].name }}
                </v-card-title>
              </v-img>
              <v-card-subtitle class="pb-0">
                {{ `ID ` + accountList[item - 1].id }}
              </v-card-subtitle>
              <v-card-text class="text--primary">
                <div>
                  <b> {{ $t("fund.balance") }} </b>
                  {{ `: ` + accountList[item - 1].balance }}
                </div>
                <div>
                  <b> {{ $t("fund.owner") }} </b>
                  {{ `: ` + accountList[item - 1].owner }}
                </div>
              </v-card-text>
              <v-card-actions> </v-card-actions>
            </v-card>
          </v-col>
        </v-row>
      </v-container>
      <!--获取账户列表-->
      <pending-progress-card
        :zms-show="pendingBoxAccountFetch"
        :zms-pending-list="pendingBoxAccountFetchList"
      />
      <!--创建新账户-->
      <pending-progress-card
        :zms-show="pendingBoxNewAccount"
        :zms-pending-list="pendingBoxNewAccountList"
      />
      <alert-messagebox
        ref="new_bank_account_box"
        :alert-mode="`new`"
        :alert-customize-toolbox="true"
        :alert-level="`info`"
        :alert-title="$t('fund.newBankAccount')"
        :alert-width="`700`"
        :alert-icon="`mdi-star-plus`"
      >
        <template v-slot:body>
          <v-icon color="primary"> mdi-plus-thick </v-icon>
          <span class="zms-query-titlex"> {{ $t("fund.fillInfo") }} </span>
          <v-alert type="info" class="zms-force-nowrap-e" text border="left">
            {{ $t("fund.initialOwnerTip") }}
          </v-alert>
          <v-container>
            <v-row>
              <v-col cols="12" sm="6" md="6">
                <v-text-field
                  v-model="newItem['id']"
                  :label="$t('fund.id')"
                  prepend-icon="mdi-identifier"
                />
              </v-col>
              <v-col cols="12" sm="6" md="6">
                <v-text-field
                  v-model="newItem['name']"
                  :label="$t('fund.name')"
                  prepend-icon="mdi-tag"
                />
              </v-col>
              <v-col cols="12" sm="6" md="6">
                <v-text-field
                  v-model="newItem['type']"
                  :label="`类别`"
                  prepend-icon="mdi-currency-cny"
                />
              </v-col>
              <v-col cols="12" sm="6" md="6">
                <v-text-field
                  v-model="newItem['owner']"
                  disabled
                  :label="`所有者`"
                  prepend-icon="mdi-file-outline"
                />
              </v-col>
            </v-row>
          </v-container>
        </template>
        <template v-slot:toolbar>
          <v-btn
            class="zms-fullwidth"
            v-bind="attrs"
            light
            color="error"
            v-on="on"
            @click="closeNewBanAccBox"
          >
            <v-icon>mdi-arrow-left</v-icon> {{ $t("common.cancel") }}
          </v-btn>
          <v-btn
            class="zms-fullwidth"
            v-bind="attrs"
            light
            color="success"
            v-on="on"
            @click="createBankAccount"
          >
            <v-icon>mdi-exclamation</v-icon> {{ $t("common.confirm") }}
          </v-btn>
        </template>
      </alert-messagebox>
      <!--授权查询-->
      <pending-progress-card
        :zms-show="pendingBoxAuthFetch"
        :zms-pending-list="pendingBoxAuthFetchList"
      />
      <pending-progress-card
        :zms-show="pendingBoxAuthOp"
        :zms-pending-list="pendingBoxAuthOpList"
      />
      <item-selector
        ref="staselector"
        :zms-selector-mode="1"
        @itemSelectorSelect="staffSelectorResponse(arguments)"
      />
      <!--取消授权提示-->
      <alert-messagebox
        ref="revoke_auth_msgbox"
        :alert-title="$t('fund.revokeAuthBoxTitle')"
        :alert-body="$t('fund.revokeAuthBox')"
        :alert-level="`warning`"
        @alertConfirm="revokeAuthSingle"
      />
      <!--授权提示-->
      <alert-messagebox
        ref="grant_auth_msgbox"
        :alert-title="$t('fund.grantAuthBoxTitle')"
        :alert-body="$t('fund.grantAuthBox')"
        :alert-level="`warning`"
        @alertConfirm="grantAuthSingle"
      />
      <alert-messagebox
        ref="authorize_box"
        :alert-mode="`new`"
        :alert-customize-toolbox="true"
        :alert-level="`info`"
        :alert-title="$t('fund.authorization')"
        :alert-width="`700`"
        :alert-icon="`mdi-key-chain`"
      >
        <template v-slot:body>
          <v-icon color="primary"> mdi-plus-thick </v-icon>
          <span class="zms-query-titlex">
            {{ $t("fund.authorizationStatus") }}
          </span>
          <!--带权限员工列表-->
          <v-container>
            <v-row>
              <v-col>
                <v-subheader> {{ $t("fund.authorizedUsers") }} </v-subheader>
                <div style="height: 400px; overflow-y: scroll">
                  <v-list dense>
                    <v-list-item-group
                      v-model="zmsselectedItem"
                      mandatory
                      color="primary"
                    >
                      <v-list-item v-for="(item, i) in authList" :key="i">
                        <v-list-item-icon>
                          <v-icon>mdi-account</v-icon>
                        </v-list-item-icon>
                        <v-list-item-content>
                          <span class="zms-anisel-av">
                            <span class="zms-anisel-bold"> {{ item.id }} </span>
                            &nbsp;{{ item.name }}&nbsp;&nbsp;<br />
                            <span class="zms-anisel-small">
                              {{ item.position }} · {{ item.park }}
                            </span>
                          </span>
                        </v-list-item-content>
                      </v-list-item>
                      <v-list-item v-if="authList.length == 0" disabled>
                        <v-list-item-icon>
                          <v-icon>mdi-information</v-icon>
                        </v-list-item-icon>
                        <v-list-item-content>
                          <small> {{ $t("animalselector.emptyTip") }} </small>
                        </v-list-item-content>
                      </v-list-item>
                    </v-list-item-group>
                  </v-list>
                </div>
              </v-col>
              <v-col>
                <v-subheader> {{ $t("fund.authOps") }} </v-subheader>
                <v-btn
                  block
                  color="error"
                  class="zms-strip-bg-slim"
                  @click="revokeFirst"
                >
                  <v-icon>mdi-lock-off</v-icon>&nbsp;{{ $t("fund.revoke") }}
                </v-btn>
                <br />
                <v-btn
                  block
                  color="success"
                  class="zms-strip-bg-slim"
                  @click="grantFirst"
                >
                  <v-icon>mdi-key-plus</v-icon>&nbsp;{{ $t("fund.grant") }}
                </v-btn>
              </v-col>
            </v-row>
          </v-container>
          <!--列表结束-->
        </template>
        <template v-slot:toolbar>
          <v-btn
            class="zms-fullwidth"
            v-bind="attrs"
            light
            color="success"
            v-on="on"
            @click="closeAuthBox"
          >
            <v-icon>mdi-check</v-icon> {{ $t("common2.applyChange") }}
          </v-btn>
        </template>
      </alert-messagebox>
    </div>
  </div>
</template>
<script>
import ItemSelector from "../CommonComponents/ItemSelector.vue";
import AlertMessagebox from "../CommonComponents/AlertMessagebox.vue";
import PendingProgressCard from "../CommonComponents/PendingProgressCard.vue";
import { addBankAccount, getAccountList } from "../../apis/fund.js";
export default {
  name: "BankAccountOverview",
  components: { AlertMessagebox, PendingProgressCard, ItemSelector },
  props: {
    drawer: Boolean,
  },
  data() {
    return {
      newItem: {
        id: null,
        name: null,
        type: null,
        owner: localStorage.getItem("zmsBKId"),
      },
      accountList: [],
      zmsselectedItem: null,
      zmsItem: [],
      authList: [],
      pendingBoxNewAccount: 0,
      pendingBoxNewAccountList: [this.$t("fund.newBankAccountTran")],
      pendingBoxAccountFetch: 0,
      pendingBoxAccountFetchList: [this.$t("fund.fetchAccountTran")],
      pendingBoxAuthFetch: 0,
      pendingBoxAuthFetchList: [this.$t("fund.fetchAuthListTran")],
      pendingBoxAuthOp: 0,
      pendingBoxAuthOpList: [this.$t("fund.alertingAuthListTran")],
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
    this.fetchAccountList();
  },
  methods: {
    gotoItem(x) {
      this.$store.dispatch("showToastNotify", {
        type: "default",
        info: this.$t("fund.searchRelatedTrans"),
      });
      this.$emit("searchRelatedTransactions", x);
    },
    calloutNewBankAccountBox() {
      this.$refs.new_bank_account_box.showAlert();
    },
    calloutAuthBox() {
      this.$refs.authorize_box.showAlert();
    },
    closeNewBanAccBox() {
      this.$refs.new_bank_account_box.clickCancel();
    },
    closeAuthBox() {
      this.$refs.authorize_box.clickCancel();
    },
    revokeFirst() {
      this.$refs.revoke_auth_msgbox.showAlert();
    },
    staffSelectorResponse() {
      this.$refs.grant_auth_msgbox.showAlert();
    },
    grantFirst() {
      this.$refs.staselector.show();
    },
    grantAuthSingle() {
      this.pendingBoxAuthOp = 1;
    },
    revokeAuthSingle() {
      this.pendingBoxAuthOp = 1;
    },
    fetchAccountList() {
      this.pendingBoxAccountFetch = 1;
      setTimeout(() => {
        getAccountList()
          .then((response) => {
            this.pendingBoxAccountFetch = 0;
            this.accountList = response.data;
            this.$store.dispatch("showToastNotify", {
              type: "success",
              info: this.$t("common2.transactionDone"),
            });
          })
          .catch((err) => {
            this.pendingBoxAccountFetch = 0;
            this.$refs.error_done.updateBody(
              this.$t("common3.transactionFail") + err
            );
            this.$refs.error_done.showAlert();
          });
      }, 1000);
    },
    createBankAccount() {
      this.pendingBoxNewAccount = 1;
      setTimeout(() => {
        addBankAccount({
          id: this.newItem.id,
          name: this.newItem.name,
          type: this.newItem.type,
          owner: localStorage.getItem("zmsBKId"),
        })
          .then(() => {
            this.pendingBoxNewAccount = 0;
            this.closeNewBanAccBox();
            this.$store.dispatch("showToastNotify", {
              type: "success",
              info: this.$t("common2.transactionDone"),
            });
          })
          .catch((err) => {
            this.pendingBoxNewAccount = 0;
            this.$refs.error_done.updateBody(
              this.$t("common3.transactionFail") + err
            );
            this.$refs.error_done.showAlert();
          });
      }, 1000);
    },
  },
};
</script>
<style scoped lang="scss">
.zms-bankaccount-subtext {
  margin-bottom: 5px;
  display: block;
}
.zms-bankaccount-op {
  margin-bottom: 30px;
}
.zms-bankaccount-list {
  margin-top: 10px;
}
.zms-bankaccount-optitle {
  font-weight: bold;
  margin-bottom: 10px;
}
.zms-stat {
  font-family: "benderregular";
  font-size: 25px;
}
.zms-home-notice {
  margin: 0px 20px 0px 20px;
  padding-top: 10px;
  padding-bottom: 10px;
}
.zms-home-center {
  text-align: center;
}
.zms-card-noborder {
  border-width: 0px;
}
.zms-home-title2 {
  font-size: 18px;
  font-weight: bold;
  display: block;
}
.zms-home-body {
  margin-left: 7%;
  margin-right: 7%;
  padding-top: 10px;
  padding-bottom: 10px;
}
.zms-home-body2 {
  margin-left: 5%;
  margin-right: 5%;
  padding-top: 20px;
  padding-bottom: 10px;
}
</style>
