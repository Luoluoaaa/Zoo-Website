
<template>
    <div class="footx">
        <foot class="footx" v-if="showFoot"/>
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
    computed:{
        showFoot(){
            if(this.$route.path.toLowerCase()!='/login'
            &&this.$route.path.toLowerCase()!='/register'){
                return true
            }
            return false
        }
    }
}
</script>
<style scoped>
    .footx{
        z-index: 1;
        Position:relative;
    }
</style>