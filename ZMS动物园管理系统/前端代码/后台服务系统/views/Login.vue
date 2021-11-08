<template>
  <div>
    <div class="app" style="text-align: center">
      <el-card class="box-cardLogin" shadow="always">
        <div class="logo">
          <div class="block">
            <span class="demonstration" /> <br />
            <br />
            <el-image style="width: 100px; height: 70px" :src="url" />
          </div>
        </div>
        <span
          style="
            font-size: 18px;
            color: rgb(100, 100, 100);
            margin-top: 10px;
            display: block;
          "
          >登 录 | Log In</span
        >
        <br />
        <br />
        <el-form
          ref="ruleForm"
          :model="ruleForm"
          status-icon
          :rules="rules"
          label-width="100px"
          class="demo-ruleForm"
        >
          <el-form-item
            label="账号"
            prop="pass"
            style="position: absolute; left: -20px; top: 42%"
          >
            <el-input v-model="ruleForm.pass" autocomplete="off" />
          </el-form-item>
          <br />
          <el-form-item
            label="密码"
            prop="checkPass"
            style="position: absolute; left: -20px; top: 58%"
          >
            <el-input
              v-model="ruleForm.checkPass"
              type="password"
              autocomplete="off"
            />
          </el-form-item>
          <br />
          <br />
          <el-button
            class="step"
            style="
              width: 30%;
              position: absolute;
              left: 16%;
              top: 76%;
              background-color: rgb(52, 232, 158);
              color: white;
            "
            round
            type="success"
            plain
            @click="checkAuth()"
          >
            登录
          </el-button>
          <el-button
            class="step"
            style="width: 32%; position: absolute; left: 48%; top: 76%"
            round
            type="primary"
            plain
            @click="fakeToken"
          >
            游客登陆
          </el-button>
        </el-form>
        <br />
        <br />
        <br />
        <br />
        <br />
      </el-card>
      <vue-particles
        color="#dedede"
        class="app particlebg"
        :particle-opacity="0.7"
        :particles-number="80"
        shape-type="circle"
        :particle-size="4"
        lines-color="#dedede"
        :lines-width="1"
        :line-linked="true"
        :line-opacity="0.4"
        :lines-distance="150"
        :move-speed="3"
        :hover-effect="true"
        hover-mode="grab"
        :click-effect="true"
        click-mode="push"
      />
    </div>
  </div>
</template>
<script>
import { userAuth, userAuthTest } from "../apis/login";
export default {
  data() {
    var validatePass = (rule, value, callback) => {
      if (value === "") {
        callback(new Error("请输入账号"));
      } else {
        callback();
      }
    };
    return {
      ruleForm: {
        pass: "",
        checkPass: "",
        password: "",
      },
      fits: ["fill"],
      url: "https://wx1.sinaimg.cn/mw2000/005YWthOly1gs7fpau959j302601njr7.jpg",
      rules: {
        pass: [{ validator: validatePass, trigger: "blur" }],
      },
    };
  },
  methods: {
    fakeToken() {
      window.location.href = "/tourism";
    },
    checkAuth() {
      userAuth({
        id: this.ruleForm.pass,
        password: this.ruleForm.checkPass,
      })
        .then((response) => {
          if (response.data[0].jurisdiction != "1") {
            this.$store.dispatch("showToastNotify", {
              type: "error",
              info: "游客无权进行此操作",
            });
            return;
          }
          localStorage.setItem("zmsBKId", this.ruleForm.pass);
          localStorage.setItem("zmsBKName", response.data[0].employee.name);

          localStorage.setItem(
            "zmsBKPosition",
            response.data[0].employee.position
          );
          localStorage.setItem("zmsToken", "Bearer " + response.data[0].token);
          this.gohome();
        })
        .catch(() => {
          this.$store.dispatch("showToastNotify", {
            type: "error",
            info: "用户名或密码错误",
          });
        });
    },
    tokenTest() {
      userAuthTest()
        .then(() => {})
        .catch(() => {});
    },
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
  width: 320px;
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
  background: linear-gradient(to right, rgb(52, 148, 230), rgb(236, 110, 173));
}
.text {
  font-size: 14px;
}
.item {
  padding: 18px 0;
}
</style>
