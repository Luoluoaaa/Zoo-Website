<!---网上预订主导航栏--->
<template>
  <div id="app">
    <el-carousel :interval="3000" indicator-position="outside" height="400px">
      <el-carousel-item v-for="(img, index) in imgArrag" :key="index">
        <a href="#">
          <img :src="img" alt="" height="100%" width="100%" />
        </a>
        <router-view></router-view>
      </el-carousel-item>
    </el-carousel>
    <el-image class="imgPri" :src="imgPris"></el-image>

    <el-row>
      <div class="consumeTabs">
        <el-col :span="6"
          ><router-link to="/AdmissionT"
            ><el-tag>
              <img :src="icon1" class="icon" /> 门票预订</el-tag
            ></router-link
          ></el-col
        >
        <el-col :span="6"
          ><router-link to="/ShowT"
            ><el-tag>
              <img :src="icon2" class="icon" /> 演出活动</el-tag
            ></router-link
          ></el-col
        >
        <el-col :span="6"
          ><router-link to="/VehicleT"
            ><el-tag>
              <img :src="icon3" class="icon" /> 游园交通</el-tag
            ></router-link
          ></el-col
        >
        <el-col :span="6"
          ><router-link to="/GuideT"
            ><el-tag>
              <img :src="icon4" class="icon" /> 导游讲解</el-tag
            ></router-link
          ></el-col
        >
      </div>
    </el-row>
    <router-view />
  </div>
</template>

<style scoped lang="scss">
#app {
  background: #ededef;
}
body > .el-container {
  margin-bottom: 40px;
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
  background: #ededef;
}
.el-tag {
  color: #a6cd39;
  text-align: center;
  font-weight: bold;
  font-size: 18px;
  padding: 10px 20px 10px 20px;
  background-color: #fff;
  width: 100%;
  height: 100%;
  border-left: 6px solid #a6cd39;
}
.icon {
  width: 18px;
  height: 18px;
  margin-bottom: -2px;
}
.conPage {
  display: block;
  padding: 0px;
  margin-left: 10px;
  background: #f6faeb;
  border-radius: 20px;
}
</style>

<script>
export default {
  data() {
    return {
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
  components: {},
  methods: {

  },
};
</script>


