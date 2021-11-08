<!---登录界面--->
<template>
  <div>
    <div class="app" style="text-align: center">
      <el-card class="box-cardLogin" shadow="always">
        <div class="logo">
          <div class="block">
            <span class="demonstration"></span><br /><br />
            <el-image style="width: 100px; height: 70px" :src="url"></el-image>
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
        <br /><br />
        <el-form
          :model="ruleForm"
          status-icon
          :rules="rules"
          ref="ruleForm"
          label-width="100px"
          class="demo-ruleForm"
        >
          <el-form-item
            label="账号"
            prop="pass"
            style="position: absolute; left: -20px; top: 42%"
          >
            <el-input v-model="ruleForm.pass" autocomplete="off"></el-input>
          </el-form-item>
          <br />
          <el-form-item
            label="密码"
            prop="checkPass"
            style="position: absolute; left: -20px; top: 58%"
          >
            <el-input
              type="password"
              v-model="ruleForm.checkPass"
              autocomplete="off"
            ></el-input>
          </el-form-item>
          <br /><br />
          <!---登录按钮--->
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
            @click="submitForm('ruleForm')"
            >登录</el-button
          >
          <el-button
            class="step"
            style="width: 32%; position: absolute; left: 48%; top: 76%"
            round
            type="primary"
            plain
            @click="tokenTest"
            >员工登录</el-button
          >
        </el-form>
        <br /><br />
        <br />
        <br /><br />

        <span
          style="
            font-size: 10px;
            color: rgb(100, 100, 100);
            margin-top: 20px;
            display: block;
            position: absolute;
            top: 84%;
            left: 32%;
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
      <!---背景模块--->
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
import {userAuth,userAuthTest} from '../api/login'
export default {
  data() {
    //输入判断
    var validatePass = (rule, value, callback) => {
      if (value === "") {
        callback(new Error("请输入账号"));
      } else {
        callback();
      }
    };
    var validatePass2 = (rule, value, callback) => {
      if (value === "") {
        callback(new Error("请输入密码"));
      } 
      else {
        //判断密码正确接口
        userAuth(
            {
              id:this.ruleForm.pass,
              password:this.ruleForm.checkPass
            }
          ).then(response=>{
            this.gohome();
            localStorage.setItem('zmsToken','Bearer '+response.data[0].token)
            localStorage.setItem('ID',response.data[0].tourist.id)
            localStorage.setItem('name',response.data[0].tourist.nickName)
            localStorage.setItem('age',response.data[0].tourist.age)
            localStorage.setItem('tel',response.data[0].tourist.phoneNumber)
            localStorage.setItem('realname',response.data[0].tourist.realName)
          })
          .catch(()=>{
            callback(new Error("用户名或密码错误"));
          })
      }
    };
    return {
      //输入规范规定
      ruleForm: {
        pass: "",
        checkPass: "",
        password: "",
      },
      fits: ["fill"],
      url: "https://wx1.sinaimg.cn/mw2000/005YWthOly1gs7fpau959j302601njr7.jpg",
      rules: {
        pass: [{ validator: validatePass, trigger: "blur" }],
        checkPass: [{ validator: validatePass2, trigger: "blur" }],
      },
    };
  },
  methods: {
    //判断输入规范
    submitForm(formName) {
        this.$refs[formName].validate((valid) => {
          if (valid) {
            alert('submit!');
          } else {
            console.log('error submit!!');
            return false;
          }
        });
      },
    tokenTest(){
      userAuthTest().then(()=>{
      }).catch(()=>{
      })
    },
    //定义跳转主界面
    gohome() {
      this.$router.push("/");
    },
    //定义跳转注册
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
  background: linear-gradient(to right, rgb(194, 229, 156), rgb(100, 179, 244));
}
.text {
  font-size: 14px;
}
.item {
  padding: 18px 0;
}
</style>
