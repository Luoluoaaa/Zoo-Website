<!---首页卡片--->
<template>
  <div style="background: #ededef">
    <br />
    <h1 style="color: grey; text-align: center">信息推荐</h1>
    <br /><br />
    <span><card /></span>
    <br /><br />
    <h1 style="color: grey; text-align: center">活动展示</h1>
    <br />
    <span><card2 /></span>
    <h1 style="color: grey; text-align: center">新闻推荐</h1>
    <br /><br />

    <span><card4 /></span>
  </div>
</template>
<script>
import Card from "./card.vue";
import Card2 from "./card2.vue";
import Card4 from "./card4.vue";
export default {
  components: {
    Card,
    Card2,
    Card4,
  },
};
</script>