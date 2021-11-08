<template>
  <!--动物喂养Wrapper-->
  <div class="zms-animal-feed">
    <table>
      <tr>
        <td>
          <div class="zms-fixed-height">
            <!--食谱信息-->
            <animal-recipes-info />
          </div>
        </td>
        <td valign="top">
          <div class="zms-fixed-height">
            <!--喂养信息-->
            <animal-feed-info />
          </div>
        </td>
      </tr>
    </table>
  </div>
</template>
<script>
//组件引入
import AnimalRecipesInfo from "./AnimalRecipesInfo.vue";
import AnimalFeedInfo from "./AnimalFeedInfo.vue";
//组件导出
export default {
  name: "AnimalFeedContainer",
  components: {
    AnimalRecipesInfo,
    AnimalFeedInfo,
  },
};
</script>
<style scoped lang="scss">
.zms-fixed-height {
  width: 95%;
  margin-right: 20px;
  bottom: 0px;
  top: 95px;
  overflow: scroll;
  display: inline-block;
}
table {
  width: 100%;
}
table,
td,
tr {
  table-layout: fixed;
}
td {
  width: 50%;
  vertical-align: top;
}
</style>
