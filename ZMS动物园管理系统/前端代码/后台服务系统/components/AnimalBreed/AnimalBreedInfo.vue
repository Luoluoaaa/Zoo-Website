<template>
  <div class="zms-animalbreedinfo">
    <!--失败提示框-->
    <alert-messagebox
      ref="error_done"
      :alert-title="$t('common3.transactionFailTitle')"
      :alert-body="$t('common3.transactionFail') + errorInfo"
      :alert-level="`error`"
      :alert-only-confirm="true"
    />
    <!--成功提示框-->
    <alert-messagebox
      ref="commit_done"
      :alert-title="$t('common3.transactionDoneTitle')"
      :alert-body="$t('common3.transactionDone')"
      :alert-level="`success`"
      :alert-only-confirm="true"
    />
    <!--加载条-->
    <div class="breed-info-filter">
      <pending-progress-card :zms-show="zmsShowLoadingBar" />
    </div>
    <!--正文-->
    <v-container>
      <v-container>
        <v-row>
          <v-col cols="12" sm="6">
            <span class="zms-breed-info-title">生产信息</span>
          </v-col>
          <v-col cols="12" sm="6">
            <v-text-field
              v-model="search"
              append-icon="mdi-magnify"
              label="Search"
              single-line
              hide-details
              :hint="$t('animalbreed.chooseByMagnify')"
              placeholder="请输入搜索关键词"
              prepend-icon="mdi-music-accidental-sharp"
            />
          </v-col>
        </v-row>
      </v-container>
      <div class="birth-table">
        <v-data-table
          :items="birthinfo"
          :headers="headers"
          :page.sync="page"
          :items-per-page="5"
          :search="search"
          hide-default-footer
          class="elevation-1"
          @page-count="pageCount = $event"
        />
      </div>
      <div class="zms-query-pagination">
        <v-pagination v-model="page" :length="pageCount" />
      </div>
    </v-container>
  </div>
</template>

<script>
//API 引入
import { getPregnent } from "../../apis/animalBreed";
//组件引入
import PendingProgressCard from "../CommonComponents/PendingProgressCard.vue";
import AlertMessagebox from "../CommonComponents/AlertMessagebox.vue";

//Vue 组件导出
export default {
  name: "AnimalBreedInfo",
  components: {
    PendingProgressCard,
    AlertMessagebox,
  },
  data: () => {
    return {
      search: "", //搜索文字
      headers: [
        { text: "动物编号", value: "id" },
        { text: "生产时间", value: "time" },
        { text: "成功情况", value: "success" },
        { text: "孩子数量", value: "childrenNum" },
      ], //表格标头
      pageCount: 0, //表格总页数
      zmsShowLoadingBar: false,
      page: 1, //表格当前页数
      birthinfo: [], //表格信息
    };
  },
  created() {
    this.initial();
  },
  methods: {
    //构造函数调用
    initial() {
      this.zmsShowLoadingBar = true;

      getPregnent()
        .then((response) => {
          this.birthinfo = response.data;
          this.zmsShowLoadingBar = false;
          this.$store.dispatch("showToastNotify", {
            type: "success",
            info: "信息获取成功",
          });
          for (let i = 0; i < this.birthinfo.length; i++) {
            this.birthinfo[i].success = this.birthinfo[i].success
              ? "顺利"
              : "不顺利";
          }
        })
        .catch((err) => {
          this.zmsShowLoadingBar = false;
          this.submitStat = false;
          this.$refs.error_done.updateBody(
            this.$t("common3.transactionFail") + err
          );
          this.$refs.error_done.showAlert();
        });
    },
  },
};
</script>
<style scoped lang="scss">
.zms-animalbreedinfo {
  padding-left: 60px;
  padding-right: 60px;
  padding-top: 20px;
  padding-bottom: 20px;
  width: 90vw;
}
.zms-breed-info-title {
  font-size: 100%;
  font-weight: bold;
  color: #1976d2;
  letter-spacing: 1px;
  position: relative;
  top: 0px;
}
</style>
