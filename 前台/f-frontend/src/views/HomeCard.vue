<template>
    <div  style=" background: #EDEDEF;">
        <br>
        <h1 style="color:grey; text-align: center;">信息推荐</h1>
        <br><br>
        <span><card/></span>
        <br><br>
        <h1 style="color:grey; text-align: center;">活动展示</h1>
        <br>
        <span><card2/></span>
        <h1 style="color:grey; text-align: center;">新闻推荐</h1>
        <br><br>

        <span><card4/></span>
    </div>
</template>
<script>
import Information from "./text.vue";
import Card from "./card.vue";
import Card2 from "./card2.vue";
import Card3 from "./card3.vue";
import Card4 from "./card4.vue";
import foot from "./foot.vue";
import AfterLogIn from "./after.vue";
export default {
    components: {
    Information,
    AfterLogIn,
    Card,
    Card2,
    Card3,
    Card4,
    foot,
  },
}
</script>