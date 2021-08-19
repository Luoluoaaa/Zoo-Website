<template>
<div id = "app"  style=" background: #EDEDEF;">
  <el-carousel :interval="3000" indicator-position="outside" height="400px">
      <el-carousel-item v-for="(img, index) in imgArrag" :key="index">
        <a href="#">
          <img :src="img" alt="" height="100%" width="100%" />
        </a>
        <router-view></router-view>
      </el-carousel-item>
  </el-carousel>
  <el-image class="imgPri" :src="imgPris" ></el-image>

  <div>
    
  </div>
  

</div>
</template>




<style scoped>
.con {
  width: 80%;
  left: 50%;
}
#app {
  background: #ededef;
}
body > .el-container {
  margin-bottom: 40px;
  z-index: 1;
}
.imgPri {
  height: 160px;
  position: relative;
  top: -240px;
  margin-bottom: -200px;
  z-index: 2;
}
.logoimg {
  display: block;
  margin-top: -20px;
  margin-left: auto;
  margin-right: auto;
  width: 25%;
  height: 25%;
}
.consumeTabs {
  margin: 25px 75px 50px 75px;
  background: #fff;
}
.el-tag {
  color: #a6cd39 !important;
  text-align: center !important;
  font-weight: bold !important;
  font-size: 18px !important;
  padding: 10px 20px 10px 20px !important;
  background-color: #fff !important;
  width: 100% !important;
  height: 100% !important;
  border-left: 6px solid #a6cd39 !important;
}

.el-header,
.el-footer {
  background-color: #b3c0d1;
  color: #333;
  text-align: center;
  line-height: 60px;
}

.el-aside {
  background-color: #d3dce6;
  color: #333;
  text-align: center;
  line-height: 200px;
}

.el-main {
  background-color: #e9eef3;
  color: #333;
  text-align: center;
  line-height: 160px;
}

body > .el-container {
  margin-bottom: 40px;
}
.icon {
  width: 18px;
  height: 18px;
  margin-bottom: -2px;
}
</style>


<script>
import Information from "./text.vue";
import Card from "./card.vue";
import Card2 from "./card2.vue";
import Card3 from "./card3.vue";
import Card4 from "./card4.vue";
import foot from "./foot.vue";
import AfterLogIn from "./after.vue";

export default {
  data() {
    return {
      activeNames: ["1"],
      input10: "",
      drawer: false,
      activeIndex: "1",
      activeIndex2: "1",
      logo: "https://cdn.chimelong.com/assets/images/logo@2x.0a2366b.png",
      imgArrag: [
        "https://cdn.chimelong.com/upload/4f17fdf0386d6acb/d50da0b6dca88bd2.jpg",
        "https://cdn.chimelong.com/upload/8c812667e21b4797/e0a65322449fb3b5.jpg",
        "https://cdn.chimelong.com/upload/4f17fdf0386d6acb/d50da0b6dca88bd2.jpg",
        "https://cdn.chimelong.com/upload/8c812667e21b4797/e0a65322449fb3b5.jpg",
      ],
      imgPris: require("../picture/0.png"),
      icon1: require("../picture/icon_f70qqjo14pr/menpiao.png"),
      icon2: require("../picture/icon_f70qqjo14pr/yanchupiao.png"),
      icon3: require("../picture/icon_f70qqjo14pr/youleche.png"),
      icon4: require("../picture/icon_f70qqjo14pr/gongjudaoyou.png"),
    };
  },

  components: {
    Information,
    AfterLogIn,
    Card,
    Card2,
    Card3,
    Card4,
    foot,
  },

  methods: {
    handleSelect(key, keyPath) {
      console.log(key, keyPath);
    },
    handleChange(val) {
      console.log(val);
    },
    handleClick(tab, event) {
      console.log(tab, event);
    },
    gotoConsume() {
      this.$router.push("/Consume");
    },
    gotoFeedback() {
      this.$router.push("/Feedback");
    },
  },
};
</script>