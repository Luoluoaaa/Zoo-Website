<template>
  <div>
    <alert-messagebox
      ref="error_done"
      :alert-title="$t('common3.transactionFailTitle')"
      :alert-body="$t('common3.transactionFail') + errorInfo"
      :alert-level="`error`"
      :alert-only-confirm="true"
    />
    <v-container>
      <v-row>
        <item-selector
          ref="itemselector"
          :zms-selector-mode="2"
          @itemSelectorSelect="itemSelectorResponse(arguments)"
        />
        <v-col>
          <v-container>
            <v-row>
              <v-icon color="primary"> mdi-filter-plus </v-icon>
              <span class="zms-query-titlex">
                {{ $t("proc2.addprocContent") }}</span
              >
            </v-row>
            <br />
            <br />
            <v-row>
              <v-card flat :ripple="{ class: null }">
                <v-container>
                  <v-row>
                    <v-col
                      cols="12"
                      sm="12"
                      md="12"
                      class="zms-vertical-col-height"
                    >
                      <v-text-field
                        v-model="itemName"
                        readonly
                        :label="$t('proc2.name')"
                        placeholder="从物品列表选择选项，选择物品"
                        prepend-icon="mdi-tag"
                      />
                    </v-col>
                    <v-col
                      cols="12"
                      sm="12"
                      md="12"
                      class="zms-vertical-col-height"
                    >
                      <v-text-field
                        v-model="itemQty"
                        :label="$t('proc2.quantity')"
                        :placeholder="
                          $t('common.pleaseInput') + $t('proc2.quantity')
                        "
                        prepend-icon="mdi-numeric"
                      />
                    </v-col>
                    <v-col
                      cols="12"
                      sm="12"
                      md="12"
                      class="zms-vertical-col-height"
                    >
                      <v-text-field
                        v-model="itemPrice"
                        :label="$t('proc2.price')"
                        :placeholder="
                          $t('common.pleaseInput') + $t('proc2.price')
                        "
                        prepend-icon="mdi-currency-cny"
                      />
                    </v-col>
                  </v-row>
                </v-container>
                <v-container>
                  <v-row>
                    <v-col cols="12" sm="12" md="12" />
                    <v-col cols="12" sm="12" md="12">
                      <v-btn
                        v-ripple
                        block
                        class="zms-width"
                        color="success"
                        @click="addNewItem"
                      >
                        <v-icon>mdi-arrow-right-thick</v-icon>&nbsp;&nbsp;{{
                          $t("proc2.addToSchedList")
                        }}
                      </v-btn>
                    </v-col>
                    <v-col cols="12" sm="12" md="12">
                      <v-btn
                        v-ripple
                        block
                        class="zms-width"
                        color="primary"
                        @click="showSw"
                      >
                        <v-icon>mdi-arrow-up</v-icon>&nbsp;&nbsp;从物品列表选择
                      </v-btn>
                    </v-col>
                  </v-row>
                  <br />
                  <v-row>
                    <v-icon color="primary"> mdi-filter-plus </v-icon>
                    <span class="zms-query-titlex">采购细节</span>
                  </v-row>
                  <v-row>
                    <v-col
                      cols="12"
                      sm="12"
                      md="12"
                      class="zms-vertical-col-height"
                    >
                      <v-text-field
                        v-model="procNameX"
                        :label="`采购名称`"
                        :placeholder="$t('common.pleaseInput') + `采购名称`"
                        prepend-icon="mdi-tag"
                      />
                    </v-col>
                  </v-row>
                </v-container>
              </v-card>
            </v-row>
          </v-container>
        </v-col>
        <v-divider vertical />
        <v-col>
          <v-container>
            <v-row>
              <v-icon color="primary"> mdi-format-list-text </v-icon>
              <span class="zms-query-titlex"> {{ $t("proc2.procList") }}</span>
            </v-row>
            <br />
            <br />
            <v-row>
              <v-col cols="12">
                <div style="height: 400px; overflow-y: scroll">
                  <v-list dense>
                    <v-list-item-group
                      v-model="zmsselectedItem"
                      color="primary"
                    >
                      <v-list-item
                        v-for="(item, i) in zmsItem"
                        :key="i"
                        @click="fselectItem(i)"
                      >
                        <v-list-item-icon>
                          <v-icon>mdi-cube-outline</v-icon>
                        </v-list-item-icon>
                        <v-list-item-content>
                          <!--物品选择器-->
                          <span>
                            <span class="zms-anisel-av">
                              <span class="zms-anisel-bold">
                                {{ item.name }}</span
                              >
                              &nbsp;x{{ item.quantity }}&nbsp;&nbsp;<br />
                              <span class="zms-anisel-small">
                                {{ item.price }} × {{ item.quantity }} =
                                {{ item.price * item.quantity }}</span
                              >
                            </span>
                          </span>
                        </v-list-item-content>
                      </v-list-item>
                      <v-list-item v-if="zmsItem.length == 0" disabled>
                        <v-list-item-icon>
                          <v-icon>mdi-information</v-icon>
                        </v-list-item-icon>
                        <v-list-item-content>
                          <small> {{ $t("proc2.havntSelectAny") }}</small>
                        </v-list-item-content>
                      </v-list-item>
                    </v-list-item-group>
                  </v-list>
                </div>
                <v-container>
                  <v-row>
                    <v-col cols="12" sm="12" md="12">
                      <v-btn
                        v-ripple
                        block
                        class="zms-width"
                        color="error"
                        @click="removeItem"
                      >
                        <v-icon>mdi-arrow-left-thick</v-icon>&nbsp;&nbsp;{{
                          $t("proc2.removeFrSchedList")
                        }}
                      </v-btn>
                    </v-col>
                  </v-row>
                </v-container>
              </v-col>
            </v-row>
          </v-container>
        </v-col>
        <v-divider vertical />
        <v-col>
          <v-container class="zms-fullrow">
            <v-row class="zms-fullrow">
              <v-icon color="primary"> mdi-view-dashboard-outline </v-icon>
              <span class="zms-query-titlex">
                {{ $t("proc2.submitOverview") }}</span
              >
            </v-row>
            <br />
            <br />
            <v-row class="zms-fullrow">
              <v-col cols="12" sm="12" md="12">
                <v-card>
                  <div class="zms-fullrow">
                    <v-container>
                      <v-row class="zms-fullrow">
                        <v-col cols="12" sm="12" md="12">
                          <b>// 预计采购物品总共预算</b>
                        </v-col>
                      </v-row>
                      <v-row class="zms-fullrow zms-rightalign">
                        <v-col cols="12" sm="12" md="12">
                          <v-spacer />
                          <span class="zms-bender zms-fontlarge primary--text">
                            <animated-number
                              :format-value="formatToInt"
                              :value="totalPrice"
                              :duration="300"
                            />
                          </span>
                        </v-col>
                      </v-row>
                      <br />
                      <br />
                      <v-row class="zms-fullrow">
                        <v-col cols="12" sm="12" md="12">
                          <b>// 预计采购物品数量</b>
                        </v-col>
                      </v-row>
                      <v-row class="zms-fullrow zms-rightalign">
                        <v-col cols="12" sm="12" md="12">
                          <v-spacer />
                          <span class="zms-bender zms-fontlarge primary--text">
                            <animated-number
                              :format-value="formatToInt"
                              :value="totalCount"
                              :duration="300"
                            />
                          </span>
                        </v-col>
                      </v-row>
                      <br />
                      <br />
                      <v-row class="zms-fullrow">
                        <v-col cols="12" sm="12" md="12">
                          <b>// 发起时间</b>
                        </v-col>
                      </v-row>
                      <v-row class="zms-fullrow zms-rightalign">
                        <v-col cols="12" sm="12" md="12">
                          <v-spacer />
                          <span class="zms-bender zms-fontlarge primary--text">
                            {{ curDateX }}</span
                          >
                        </v-col>
                      </v-row>
                    </v-container>
                  </div>
                </v-card>
              </v-col>
            </v-row>
            <v-row>
              <v-col cols="12" sm="12" md="12">
                <v-btn
                  v-ripple
                  block
                  class="zms-width"
                  color="success"
                  @click="submitProcFirst"
                >
                  <v-icon>mdi-arrow-up-thick</v-icon>&nbsp;&nbsp;{{
                    $t("common2.submit")
                  }}
                </v-btn>
              </v-col>
            </v-row>
          </v-container>
        </v-col>
      </v-row>
    </v-container>
    <!--事务进行提示框/删除-->
    <pending-progress-card
      :zms-pending-list="pendingList"
      :zms-show="pendingShow"
    />
    <!--确认提交提示-->
    <alert-messagebox
      ref="confirm_submit"
      :alert-title="$t('proc2.submitPurchaseTitle')"
      :alert-body="$t('proc2.submitPurchase')"
      :alert-level="`warning`"
      @alertConfirm="submitProc"
    />
  </div>
</template>
<script>
import PendingProgressCard from "../CommonComponents/PendingProgressCard.vue";
import AlertMessagebox from "../CommonComponents/AlertMessagebox.vue";
import AnimatedNumber from "animated-number-vue";
import ItemSelector from "../CommonComponents/ItemSelector.vue";
import { createNewProc } from "../../apis/procurement";
export default {
  name: "ProcurementInitiation",
  components: {
    AnimatedNumber,
    PendingProgressCard,
    AlertMessagebox,
    ItemSelector,
  },
  data() {
    return {
      zmsItem: [
        //{name:'Abc',quantity:2,price:4.3}
      ],
      itemName: null,
      itemQty: null,
      procNameX: null,
      itemPrice: null,
      selectItem: null,
      pendingShow: 0,
      pendingList: [this.$t("proc2.submitProcTran")],
    };
  },
  computed: {
    curDateX() {
      let x = new Date();
      let s = "";
      s = x.getFullYear();
      if (x.getMonth() + 1 < 10) {
        s = s + "-0" + (x.getMonth() + 1);
      } else {
        s = s + "-" + (x.getMonth() + 1);
      }
      if (x.getDate() + 1 < 10) {
        s = s + "-0" + x.getDate();
      } else {
        s = s + "-" + x.getDate();
      }
      return s;
    },
    totalPrice() {
      let ans = 0;
      for (let i = 0; i < this.zmsItem.length; i++) {
        ans += this.zmsItem[i].price * this.zmsItem[i].quantity;
      }
      return ans;
    },
    totalCount() {
      let ans = 0;
      for (let i = 0; i < this.zmsItem.length; i++) {
        ans += 1 * this.zmsItem[i].quantity;
      }
      return ans;
    },
  },
  methods: {
    showSw() {
      this.$refs.itemselector.show();
    },
    formatToInt(value) {
      return `${value.toFixed(0)}`;
    },
    fselectItem(x) {
      this.selectItem = x;
    },
    submitProcFirst() {
      this.$refs.confirm_submit.showAlert();
    },
    submitProc() {
      this.pendingShow = 1;
      let itemIds = [];
      let itemIdx = "";
      let itemCnts = [];
      let itemCntx = "";
      for (let i = 0; i < this.zmsItem.length; i++) {
        if (i != 0) {
          itemIdx += ",";
          itemCntx += ",";
        }
        if (itemIds.indexOf(this.zmsItem[i].name) != -1) {
          this.$refs.error_done.updateBody("请将ID重复的物品进行合并或删除");
          this.$refs.error_done.showAlert();
          return;
        }
        itemIds.push(this.zmsItem[i].name);
        itemIdx = itemIdx + this.zmsItem[i].name;
        itemCnts.push(this.zmsItem[i].quantity);
        itemCntx = itemCntx + "" + this.zmsItem[i].quantity + "";
      }
      let rr = {
        name: this.procNameX,
        itemid: itemIdx,
        qty: itemCntx,
        status: "待审批",
        staffId: localStorage.getItem("zmsBKId"),
        procureDate: this.curDateX,
        budget: this.totalPrice,
        remarks: "无",
      };
      if (this.procNameX === "" || this.procNameX === null) {
        this.$store.dispatch("showToastNotify", {
          type: "error",
          info: "请填写采购名称",
        });
        return;
      }

      setTimeout(() => {
        createNewProc(rr)
          .then(() => {
            this.pendingShow = 0;
            this.$store.dispatch("showToastNotify", {
              type: "success",
              info: this.$t("common2.transactionDone"),
            });
          })
          .catch((err) => {
            this.pendingShow = 0;
            this.$refs.error_done.updateBody(
              this.$t("common3.transactionFail") + err
            );
            this.$refs.error_done.showAlert();
          });
      }, 1000);
    },
    itemSelectorResponse(x) {
      this.itemName = x[0];
    },
    removeItem() {
      if (this.selectItem === null) {
        this.$store.dispatch("showToastNotify", {
          type: "error",
          info: this.$t("proc2.havntSelectAny"),
        });
        return;
      }
      this.zmsItem.splice(this.selectItem, 1);
      this.selectItem = null;
      this.$store.dispatch("showToastNotify", {
        type: "success",
        info: this.$t("proc2.itemRemoved"),
      });
      return;
    },
    addNewItem() {
      if (this.itemName == "" || this.itemName === null) {
        this.$store.dispatch("showToastNotify", {
          type: "error",
          info: this.$t("proc2.nameNeedNonempty"),
        });
        return;
      }
      if (
        this.itemQty === "" ||
        this.itemQty === null ||
        isNaN(this.itemQty) ||
        this.itemQty == 0
      ) {
        this.$store.dispatch("showToastNotify", {
          type: "error",
          info: this.$t("proc2.qtyNeedNum"),
        });
        return;
      }
      if (this.itemQty.indexOf(".") != -1 || this.itemQty.indexOf("-") != -1) {
        this.$store.dispatch("showToastNotify", {
          type: "error",
          info: this.$t("proc2.qtyNeedNum"),
        });
        return;
      }
      if (
        this.itemPrice === "" ||
        this.itemPrice === null ||
        isNaN(this.itemPrice)
      ) {
        this.$store.dispatch("showToastNotify", {
          type: "error",
          info: this.$t("proc2.priceNeedNum"),
        });
        return;
      }
      this.zmsItem.push({
        name: this.itemName,
        quantity: parseInt(this.itemQty),
        price: parseFloat(this.itemPrice),
      });
      this.$store.dispatch("showToastNotify", {
        type: "success",
        info: this.$t("proc2.itemAdded"),
      });
    },
  },
};
</script>
<style scoped lang="scss">
.zms-vertical-col-height {
  height: 75px !important;
}
.zms-fontlarge {
  font-size: 25px;
  font-weight: bold;
}
.zms-rightalign {
  text-align: right;
}
</style>
