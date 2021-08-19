<template>
  <div>
    <div class="app" style="text-align: center">
      <el-card class="box-cardLogin" shadow="always">
        <div class="logo">
          <div class="block" :key="fit">
            <span class="demonstration">{{ fit }}</span>
            <el-image
              style="width: 100px; height: 70px"
              :src="url"
              :fit="fit"
            ></el-image>
          </div>
        </div>
        <span
          style="
            font-size: 18px;
            color: rgb(100, 100, 100);
            margin-top: 20px;
            display: block;
          "
          >登 录 | Log In</span
        >
        <br /><br />
        <el-input placeholder="账号" v-model="input1" clearable> </el-input>
        <br /><br /><br />
        <el-input placeholder="密码" v-model="input2" show-password> </el-input>
        <br /><br />
        <br />
        <el-button
          round
          type="success" plain
          style="background-color: rgb(52, 232, 158); color: white"
          @click="gohome"
        >
          登录
        </el-button>
        <span
          style="
            font-size: 10px;
            color: rgb(100, 100, 100);
            margin-top: 20px;
            display: block;
          "
          >没有账号，
          <el-button
            type="text"
            @click="gotoRegister"
            style="font-size: 10px; color: rgb(50, 50, 100)"
            >立即注册</el-button
          ></span
        >
      </el-card>
      <vue-particles
        color="#dedede"
        class="app particlebg"
        :particleOpacity="0.7"
        :particlesNumber="80"
        shapeType="circle"
        :particleSize="4"
        linesColor="#dedede"
        :linesWidth="1"
        :lineLinked="true"
        :lineOpacity="0.4"
        :linesDistance="150"
        :moveSpeed="3"
        :hoverEffect="true"
        hoverMode="grab"
        :clickEffect="true"
        clickMode="push"
      >
      </vue-particles>
    </div>
  </div>
</template>


<script>
export default {
  data() {
    return {
      input1: "",
      input2: "",
      fits: ["fill"],
      url: "https://wx1.sinaimg.cn/mw2000/005YWthOly1gs7fpau959j302601njr7.jpg",
    };
  },
  methods: {
    gohome() {
      this.$router.push("/");
    },
    gotoRegister() {
      this.$router.push("/Register");
    },
  },
};
</script>

<style scoped>
.particlebg {
  z-index: -1;
}
.box-cardLogin {
  height: 510px;
  width: 360px;
  position: absolute;
  top: 45%;
  left: 50%;
  transform: translate(-50%, -50%);
  background-color: rgb(255, 255, 255);
  opacity: 0.9;
}
.app {
  position: fixed;
  top: 0;
  bottom: 0;
  left: 0;
  right: 0;
  background: linear-gradient(to right, rgb(52, 232, 158), rgb(15, 52, 67));
}
.text {
  font-size: 14px;
}
.item {
  padding: 18px 0;
}
</style>
