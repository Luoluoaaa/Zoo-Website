<template>
<div id = "app">
<div class = "line"></div>
<el-menu
	:default-active = "activeIndex2"
	class = "el-menu-demo"
	mode = "horizontal"
	@select = "handleSelect"
	text-color = "#ffffff"
	active-text-color = "#a6cd39"
   shadow="always"
   style="background: linear-gradient(to right, rgb(194, 229, 156), rgb(100, 179, 244));"
  >
 
 <el-menu-item index = "0">
    <img src="./picture/002.png"/>
 </el-menu-item style="white">
	<el-menu-item index = "1" @click="gohome">首页</el-menu-item>
	<el-menu-item index = "2" >信息介绍</el-menu-item>
  <el-menu-item index = "3" >消费信息</el-menu-item>
  <el-menu-item index = "4" >信息反馈</el-menu-item>

<el-menu-item index = "6" style="float:right">
<el-button @click="drawer = true" type="text" style="margin-left:0px;">
   <el-avatar src="https://cube.elemecdn.com/0/88/03b0d39583f48206768a7534e55bcpng.png"></el-avatar>
</el-button>

<el-drawer
  :visible.sync="drawer"
  :with-header="false"
  >
  <span><information/></span>
</el-drawer>

</el-menu-item>
  <el-menu-item index = "5" style="float:right">
    <el-input v-model="input" placeholder="请输入内容"></el-input>
  </el-menu-item>
</el-menu>


<el-carousel :interval="3000" indicator-position="outside" height="400px">
    <el-carousel-item v-for="(img, index) in imgArrag" :key="index">
      <a href="#">
        <img :src="img" alt="" height="100%" width="100%" />
      </a>
      <router-view></router-view>
    </el-carousel-item>
</el-carousel>
<el-image class="imgPri" :src="imgPris" ></el-image>

<el-row>
  <el-col :span="24">
	  <img  class="logoimg" :src="logo" />
	  </el-col>
</el-row>

<el-row>
	<div class="consumeTabs">
		<el-col :span="6"><el-tag> <img :src="icon1" class="icon"/> 门票预订</el-tag></el-col>
		<el-col :span="6"><el-tag > <img :src="icon2" class="icon"/> 演出活动</el-tag></el-col>
		<el-col :span="6"><el-tag > <img :src="icon3" class="icon"/> 游园交通</el-tag></el-col>
		<el-col :span="6"><el-tag > <img :src="icon4" class="icon"/> 导游讲解</el-tag></el-col>
	</div>
</el-row>

<el-container class="consumeTabs">
  <el-aside width="200px">Aside</el-aside>
  <el-container>
    <el-header>Header</el-header>
    <el-main>Main</el-main>
    <el-footer>Footer</el-footer>
  </el-container>
</el-container>


</div>
	</template>


<style scoped>
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
      imgPris: require("./picture/0.png"),
      icon1: require("./picture/icon_f70qqjo14pr/menpiao.png"),
      icon2: require("./picture/icon_f70qqjo14pr/yanchupiao.png"),
      icon3: require("./picture/icon_f70qqjo14pr/youleche.png"),
      icon4: require("./picture/icon_f70qqjo14pr/gongjudaoyou.png"),
    };
  },

  components: {
    Information,
  },
  methods: {
    handleClick(tab, event) {
      console.log(tab, event);
    },
    
    handleChange(val) {
      console.log(val);
    },
    handleClick(tab, event) {
      console.log(tab, event);
    },
    gohome() {
      this.$router.push("/");
    },

  },
};
</script>