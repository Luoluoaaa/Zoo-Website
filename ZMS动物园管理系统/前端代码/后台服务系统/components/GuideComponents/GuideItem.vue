<template>
  <v-container fluid>
    <div class="zms-anicare" :class="nmNightClass">
      <alert-messagebox
        ref="error_done"
        :alert-title="$t('common3.transactionFailTitle')"
        :alert-body="$t('common3.transactionFail')"
        :alert-level="`error`"
        :alert-only-confirm="true"
      />
      <div class="zms-query-filter">
        <v-icon color="primary"> mdi-filter-plus </v-icon>
        <span class="zms-query-title">查询条件</span>
        <div>
          <v-container>
            <v-row>
              <v-col cols="12" sm="6" md="3">
                <v-text-field
                  v-model="searchItem['id']"
                  label="导游ID"
                  placeholder="请输入导游ID"
                  prepend-icon="el-icon-discover"
                />
              </v-col>
              <v-col cols="12" sm="6" md="3">
                <v-text-field
                  v-model="searchItem['name']"
                  label="导游姓名"
                  placeholder="请输入导游姓名"
                  prepend-icon="mdi-form-textbox"
                />
              </v-col>
              <v-col cols="12" sm="6" md="3">
                <v-text-field
                  v-model="searchItem['type']"
                  label="服务类型"
                  placeholder="请输入服务类型"
                  prepend-icon="mdi-tag"
                />
              </v-col>
              <v-col cols="12" sm="6" md="3">
                <v-text-field
                  v-model="searchItem['price']"
                  label="服务费用"
                  placeholder="请输入服务费用"
                  prepend-icon="el-icon-coin"
                />
              </v-col>
            </v-row>
          </v-container>
        </div>
      </div>
    </div>
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
            <v-icon>mdi-filter</v-icon>&nbsp;&nbsp;查找导游
          </v-btn>
        </v-col>
      </v-row>
    </v-container>
    <v-dialog v-model="queryLoaderDialog2" persistent width="300">
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
    <v-dialog v-model="submitStat" persistent width="300">
      <v-card>
        <v-card-title> {{ $t("animalCare.Submitting") }}</v-card-title>
        <v-divider />
        <br />
        <v-card-text>
          {{ $t("animalCare.PleaseWait") }}<br />
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
    <v-data-iterator
      :items="items"
      :items-per-page.sync="itemsPerPage"
      :page.sync="page"
      :search="search"
      :sort-by="sortBy.toLowerCase()"
      :sort-desc="sortDesc"
      hide-default-footer
    >
      <template v-slot:header>
        <v-toolbar dark color="blue darken-3" class="mb-1">
          <v-text-field
            v-model="search"
            clearable
            flat
            solo-inverted
            hide-details
            prepend-inner-icon="mdi-magnify"
            label="Search"
          />
          <template v-if="$vuetify.breakpoint.mdAndUp">
            <v-spacer />
            <v-select
              v-model="sortBy"
              flat
              solo-inverted
              hide-details
              :items="keys"
              prepend-inner-icon="mdi-magnify"
              label="Sort by"
            />
            <v-spacer />
            <v-btn-toggle v-model="sortDesc" mandatory>
              <v-btn large depressed color="blue" :value="false">
                <v-icon>mdi-arrow-up</v-icon>
              </v-btn>
              <v-btn large depressed color="blue" :value="true">
                <v-icon>mdi-arrow-down</v-icon>
              </v-btn>
            </v-btn-toggle>
          </template>
        </v-toolbar>
      </template>
      <template v-slot:default="props">
        <v-row>
          <v-col
            v-for="item in props.items"
            :key="item.name"
            cols="12"
            sm="6"
            md="4"
            lg="3"
          >
            <v-card>
              <v-card-title class="subheading font-weight-bold">
                {{ item.name }}
              </v-card-title>
              <v-divider />
              <v-list dense>
                <v-list-item v-for="(key, index) in filteredKeys" :key="index">
                  <v-list-item-content
                    :class="{ 'blue--text': sortBy === key }"
                  >
                    {{ key }}:
                  </v-list-item-content>
                  <v-list-item-content
                    class="align-end"
                    :class="{ 'blue--text': sortBy === key }"
                  >
                    {{ item[key.toLowerCase()] }}
                  </v-list-item-content>
                </v-list-item>
              </v-list>
            </v-card>
          </v-col>
        </v-row>
      </template>
      <template v-slot:footer>
        <v-row class="mt-2" align="center" justify="center">
          <span class="grey--text">Items per page</span>
          <v-menu offset-y>
            <template v-slot:activator="{ on, attrs }">
              <v-btn
                dark
                text
                color="primary"
                class="ml-2"
                v-bind="attrs"
                v-on="on"
              >
                {{ itemsPerPage }}
                <v-icon>mdi-chevron-down</v-icon>
              </v-btn>
            </template>
            <v-list>
              <v-list-item
                v-for="(number, index) in itemsPerPageArray"
                :key="index"
                @click="updateItemsPerPage(number)"
              >
                <v-list-item-title> {{ number }}</v-list-item-title>
              </v-list-item>
            </v-list>
          </v-menu>
          <v-spacer />
          <span class="mr-4 grey--text">
            Page {{ page }} of {{ numberOfPages }}
          </span>
          <v-btn
            fab
            dark
            color="blue darken-3"
            class="mr-1"
            @click="formerPage"
          >
            <v-icon>mdi-chevron-left</v-icon>
          </v-btn>
          <v-btn fab dark color="blue darken-3" class="ml-1" @click="nextPage">
            <v-icon>mdi-chevron-right</v-icon>
          </v-btn>
        </v-row>
      </template>
    </v-data-iterator>
  </v-container>
</template>
<script>
import { getguideItemInfo, updateguideItemInfo } from "../../apis/guide.js";
import AlertMessagebox from "../CommonComponents/AlertMessagebox.vue";
export default {
  components: { AlertMessagebox },
  data() {
    return {
      itemsPerPageArray: [4, 8, 12],
      search: "",
      filter: {},
      sortDesc: false,
      page: 1,
      searchItem: {
        id: null,
        name: null,
        type: null,
        price: null,
      },
      itemsPerPage: 4,
      sortBy: "name",
      keys: ["订单号", "游客账号", "导游工号", "导游姓名", "费用", "服务种类"],
      items: [],
    };
  },
  computed: {
    numberOfPages() {
      return Math.ceil(this.items.length / this.itemsPerPage);
    },
    filteredKeys() {
      return this.keys.filter((key) => key !== "Name");
    },
  },
  created() {
    if (this.$route.params.id != undefined) {
      this.fetchItemInfo();
    }
  },
  methods: {
    nextPage() {
      if (this.page + 1 <= this.numberOfPages) this.page += 1;
    },
    formerPage() {
      if (this.page - 1 >= 1) this.page -= 1;
    },
    updateItemsPerPage(number) {
      this.itemsPerPage = number;
    },
    fetchItemInfo() {
      (this.queryLoaderDialog = true),
        (this.submitStat = true),
        setTimeout(() => {
          getguideItemInfo({
            guideId: this.searchItem["id"],
            name: this.searchItem["name"],
            price: this.searchItem["price"],
            type: this.searchItem["type"],
          })
            .then((response) => {
              this.items = response.data;
              for (let i = 0; i < this.items.length; i++) {
                this.items[i]["订单号"] = this.items[i].id;
                this.items[i]["游客账号"] = this.items[i].tourId;
                this.items[i]["导游工号"] = this.items[i].guideId;
                this.items[i]["导游姓名"] = this.items[i].name;
                this.items[i]["费用"] = this.items[i].price;
                this.items[i]["服务种类"] = this.items[i].type;
              }
              this.queryLoaderDialog = false;
              this.submitStat = false;
              if (this.items.length > 0) {
                this.$store.dispatch("showToastNotify", {
                  type: "success",
                  info: "信息查询成功",
                });
              } else {
                this.$store.dispatch("showToastNotify", {
                  type: "error",
                  info: "无数据",
                });
              }
            })
            .catch((err) => {
              this.$refs.error_done.updateBody(
                this.$t("common3.transactionFail") + err
              );
              this.$refs.error_done.showAlert();
              this.queryLoaderDialog = false;
              this.submitStat = false;
            });
        }, 2000);
    },
    deleteItemInfo() {
      this.searchItem["id"] = null;
      this.searchItem["name"] = null;
      this.searchItem["type"] = null;
      this.searchItem["price"] = null;
    },
    updateItemInfo() {
      this.queryLoaderDialog2 = true;
      setTimeout(() => {
        updateguideItemInfo().then((response) => {
          this.queryLoaderDialog2 = false;
          if (response.data.statcode != 0) {
            this.errorTitle = this.$t("common.error");
            this.errorInfo = this.$t("warehouse.Info.generalError");
            this.errorReturn = true;
            return 0;
          }
          this.$store.dispatch("showToastNotify", {
            type: "success",
            info: "信息查询成功",
          });
          this.close();
        });
      }, 2000);
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
