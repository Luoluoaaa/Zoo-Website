<template>
  <div class="zms-anicare" :class="nmNightClass">
    <!-- 物品选择器 -->
    <item-selector
      ref="itemselector"
      :zms-selector-mode="2"
      @itemSelectorSelect="itemSelectorResponse(arguments)"
    />
    <v-icon color="primary"> mdi-plus </v-icon>
    <span class="zms-query-title">物品入库和出仓操作</span>
    <div class="zms-query-filter">
      <div>
        <v-container>
          <v-row>
            <v-col cols="12" sm="6" md="3">
              <v-text-field
                v-model="itemId"
                label="物品编号"
                placeholder="请输入编号"
                prepend-icon="mdi-music-accidental-sharp"
                append-icon="mdi-magnify"
                @click:append="showItemSelectBox"
              />
            </v-col>
            <v-col cols="12" sm="6" md="3">
              <v-text-field
                v-model="sA"
                label="仓库ID"
                placeholder="请输入仓库ID"
                prepend-icon="mdi-account-key"
              />
            </v-col>
            <v-col cols="12" sm="6" md="3">
              <v-text-field
                v-model="sB"
                label="数量"
                placeholder="请输入增量（正表示入库）"
                prepend-icon="mdi-numeric"
              />
            </v-col>
          </v-row>
        </v-container>
        <v-container>
          <v-row>
            <v-col cols="12" sm="6" md="3" />
            <v-col cols="12" sm="6" md="3" />
            <v-col cols="12" sm="6" md="3" />
            <v-col cols="12" sm="6" md="3">
              <v-btn
                v-ripple
                block
                class="zms-width"
                color="primary"
                @click="submitItem"
              >
                <v-icon>mdi-arrow-collapse-up</v-icon>&nbsp;&nbsp;提交
              </v-btn>
            </v-col>
          </v-row>
        </v-container>
      </div>
    </div>
  </div>
</template>
<script>
import ItemSelector from "../CommonComponents/ItemSelector.vue";
import { modifyItem } from "../../apis/warehouse";
export default {
  name: "WarehouseFlow",
  components: {
    ItemSelector,
  },
  data: () => {
    return {
      curDate: "1970-01-01",
      itemId: null,
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
    let x = new Date();
    this.curDate =
      x.getFullYear() + "-" + (x.getMonth() + 1) + "-" + x.getDay();
  },
  methods: {
    submitItem() {
      modifyItem({
        id: this.itemId,
        store_id: this.sA,
        cnt: this.sB,
      }).then((response) => {
        if (response.data.length > 0) {
          this.$store.dispatch("showToastNotify", {
            type: "success",
            info: "操作已经提交！",
          });
        } else {
          this.$store.dispatch("showToastNotify", {
            type: "error",
            info: "操作失败",
          });
        }
      });
    },
    showItemSelectBox() {
      this.$refs.itemselector.show();
    },
    itemSelectorResponse(x) {
      this.itemId = x[0];
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
