<template>
  <div id="app">
    <!--<div class="line"></div>
    <el-menu
      :default-active="activeIndex2"
      class="el-menu-demo"
      mode="horizontal"
      @select="handleSelect"
      background-color="#fff"
      text-color="#2f4858"
      active-text-color="#a6cd39"
      shadow="always">
      <el-menu-item index="0">
        <img src="../picture/002.png" />
      </el-menu-item>
      <el-menu-item index="1">首页</el-menu-item>
      <el-submenu index="2">
        <template slot="title">信息介绍</template>
        <el-menu-item index="2-1">动物科普</el-menu-item>
        <el-menu-item index="2-2">场馆信息</el-menu-item>
        <el-menu-item index="2-3">交通工具</el-menu-item>
        <el-menu-item index="2-4">酒店信息</el-menu-item>
        <el-menu-item index="2-5">便民服务</el-menu-item>
      </el-submenu>
      <el-submenu index="3">
        <template slot="title">消费信息</template>
        <el-menu-item index="3-1">门票</el-menu-item>
        <el-menu-item index="3-2">演出票</el-menu-item>
        <el-menu-item index="3-3">园内交通</el-menu-item>
        <el-menu-item index="3-4">导游服务</el-menu-item>
      </el-submenu>
      <el-menu-item index="4">信息反馈</el-menu-item>
      <el-menu-item index="6" style="float:right">
        <el-button @click="drawer = true" type="text" style="margin-left:20px;">
          <el-avatar
            src="https://wx1.sinaimg.cn/mw690/005YWthOly1gr8nij1k99j302601njr7.jpg"
          ></el-avatar>
        </el-button>
      </el-menu-item>
      <el-menu-item index="5" style="float:right">
        <i class="el-icon-search"></i>
        <el-input v-model="input" placeholder="请输入内容"></el-input>
      </el-menu-item>
    </el-menu>-->

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
          ><router-link to="/AdmissionT"><el-tag > <img :src="icon1" class="icon" /> 门票预订</el-tag></router-link></el-col
        >
        <el-col :span="6"
          ><router-link to="/ShowT"><el-tag> <img :src="icon2" class="icon" /> 演出活动</el-tag></router-link></el-col
        >
        <el-col :span="6"
          ><router-link to="/VehicleT"><el-tag> <img :src="icon3" class="icon" /> 游园交通</el-tag></router-link></el-col
        >
        <el-col :span="6"
          ><router-link to="/GuideT"><el-tag> <img :src="icon4" class="icon" /> 导游讲解</el-tag></router-link></el-col
        >
      </div>
    </el-row>
    <router-view/>
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
.conPage{
  display: block;
  padding: 0px;
  margin-left:10px;
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
  components: {
  },
  methods: {
    handleClick(tab, event) {
      console.log(tab, event);
    },
  }
};
</script>


