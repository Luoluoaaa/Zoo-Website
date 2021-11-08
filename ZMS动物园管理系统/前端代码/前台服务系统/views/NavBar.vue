<!---主页主导航栏--->
<template>
  <div>
    <div class="line"></div>
    <el-menu
      :default-active="activeIndex2"
      class="el-menu-demo"
      mode="horizontal"
      @select="handleSelect"
      text-color="#ffffff"
      active-text-color="#a6cd39"
      shadow="always"
      style="background: linear-gradient(to right,rgb(194, 229, 156),rgb(100, 179, 244));"
    >
      <el-menu-item index="0">
        <img src="../picture/002.png" />
      </el-menu-item>
      <el-menu-item index="1">首页</el-menu-item>
      <el-submenu index="2">
        <template slot="title">信息介绍</template>
        <el-menu-item index="2-1" class="infoBg">动物百科</el-menu-item>
        <el-menu-item index="2-2" class="infoBg">场馆信息</el-menu-item>
        <el-menu-item index="2-3" class="infoBg">交通指南</el-menu-item>
        <el-menu-item index="2-4" class="infoBg">周边酒店</el-menu-item>
        <el-menu-item index="2-5" class="infoBg">便民服务</el-menu-item>
      </el-submenu>
      <el-menu-item index="3">网上预订</el-menu-item>
      <el-menu-item index="4">信息反馈</el-menu-item>

      <el-button
        @click="iflogin"
        type="text"
        style="position: absolute; right: 20px; height: 8px"
      >
        <el-avatar
          src="https://cube.elemecdn.com/0/88/03b0d39583f48206768a7534e55bcpng.png"
        ></el-avatar>
      </el-button>

      <el-drawer class="hidden" :visible.sync="drawer" :with-header="false">
        <span style=""><afterLogIn /></span>
      </el-drawer>
    </el-menu>
  </div>
</template>
<script>
import AfterLogIn from "./after.vue";
import Utils from "../utils/utils";

export default {
  data() {
    return {
      activeNames: ["1"],
      input10: "",
      drawer: false,
      activeIndex: "1",
      activeIndex2: "1",
      logo: "https://cdn.chimelong.com/assets/images/logo@2x.0a2366b.png",
      imgPris: require("../picture/0.png"),
    };
  },

  components: {
    AfterLogIn,
  },

  mounted() {
    var that = this;
    Utils.$on("drawer", function () {
      that.closeB();
    });
  },
  methods: {
    closeB() {
      this.drawer = false;
    },
    iflogin() {
      var tokenow = localStorage.getItem("zmsToken");
      if (tokenow) {
        this.drawer = true;
      } else {
        this.gotoLogin();
      }
    },

    handleSelect(key) {
      if (key === "1") {
        this.gotoHome();
      }
      if (key === "2-1") {
        this.gotoAnimalScience();
      }
      if (key === "2-2") {
        this.gotoVenue();
      }
      if (key === "2-3") {
        this.gotoTransportation();
      }
      if (key === "2-4") {
        this.gotoHotel();
      }
      if (key === "2-5") {
        this.gotoService();
      }
      if (key === "3") {
        this.gotoConsume();
      }
      if (key === "4") {
        this.gotoFeedback();
      }
    },

    gotoConsume() {
      this.$router.push("/Consume");
    },
    gotoFeedback() {
      this.$router.push("/Feedback");
    },
    gotoHome() {
      this.$router.push("/");
    },
    gotoService() {
      this.$router.push("/service");
    },
    gotoVenue() {
      this.$router.push("/venue");
    },
    gotoAnimalScience() {
      this.$router.push("/animal");
    },
    gotoTransportation() {
      this.$router.push("/transportation");
    },
    gotoHotel() {
      this.$router.push("/hotel");
    },
    gotoLogin() {
      this.$router.push("/Login");
    },
  },
};
</script>
<style scoped>
.infoBg {
  color: #777777 !important;
}
.infoBg:hover {
  background-color: #cccccc !important;
}
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
