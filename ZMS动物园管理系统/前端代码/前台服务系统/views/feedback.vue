<!---信息反馈--->
<template>
<!---海报栏--->
  <div style="background: #ededef">
    <el-carousel :interval="3000" indicator-position="outside" height="400px">
      <el-carousel-item v-for="(img, index) in imgArrag" :key="index">
        <a href="#">
          <img :src="img" alt="" height="100%" width="100%" />
        </a>
        <router-view></router-view>
      </el-carousel-item>
    </el-carousel>
    <el-image class="imgPri" :src="imgPris"></el-image>-- <br /><br />
    <br />
    <!---信息反馈部分表单--->
    <h1 icon="el-icon-s-comment" style="color: #a6ce39; text-align: center">
      信息反馈
    </h1>
    <br /><br /><br />
    <el-form
      :label-position="labelPosition"
      :model="ruleForm"
      :rules="rules"
      ref="ruleForm"
      label-width="100px"
      class="demo-ruleForm"
      style="width: 60%; margin: auto"
    >
      <el-form-item label="姓名" prop="name">
        <el-input
          v-model="ruleForm.name"
          placeholder="请输入您的姓名"
        ></el-input>
      </el-form-item>
      <el-form-item label="联系方式" prop="tel">
        <el-input
          v-model="ruleForm.tel"
          placeholder="请输入您的联系方式"
        ></el-input>
      </el-form-item>

      <el-form-item label="反馈类型" prop="type">
        <el-radio-group v-model="ruleForm.type">
          <el-radio label="信息勘误" name="type"></el-radio>
          <el-radio label="消费问题" name="type"></el-radio>
          <el-radio label="求助引导" name="type"></el-radio>
          <el-radio label="意见建议" name="type"></el-radio>
          <el-radio label="其他" name="type"></el-radio>
        </el-radio-group>
      </el-form-item>
      <el-form-item label="反馈内容" prop="desc">
        <el-input type="textarea" v-model="ruleForm.desc"></el-input>
      </el-form-item>
      <br /><br />
      <el-form-item class="center">
        <el-button class="button" type="success" @click="submitForm('ruleForm')"
          >立即反馈</el-button
        >
        <el-button @click="resetForm('ruleForm')" style="color: grey"
          >重置</el-button
        >
      </el-form-item>
    </el-form>
    <!---成功反馈弹窗--->
    <el-dialog title="提示" width="30%" center>
      <template #footer>
        <span class="dialog-footer">
          <el-button @click="centerDialogVisible = false">取 消</el-button>
          <el-button type="primary" @click="centerDialogVisible = false"
            >确 定</el-button
          >
        </span>
      </template>
    </el-dialog>
    <br /><br /><br />
  </div>
</template>


<script>
import { feedback } from "@/api/feedback";

export default {
  data() {
    return {
      labelPosition: "left",
      logo: "https://cdn.chimelong.com/assets/images/logo@2x.0a2366b.png",
      imgPris: require("../picture/0.png"),
      imgArrag: [
        "https://cdn.chimelong.com/upload/4f17fdf0386d6acb/d50da0b6dca88bd2.jpg",
        "https://cdn.chimelong.com/upload/8c812667e21b4797/e0a65322449fb3b5.jpg",
        "https://cdn.chimelong.com/upload/4f17fdf0386d6acb/d50da0b6dca88bd2.jpg",
        "https://cdn.chimelong.com/upload/8c812667e21b4797/e0a65322449fb3b5.jpg",
      ],
      ruleForm: {
        name: "",
        tel: "",
        type: "",
        desc: "",
      },
      rules: {
        name: [
          { required: true, message: "请输入您的姓名", trigger: "blur" },
          { min: 2, max: 5, message: "长度在 2 到 5 个字符", trigger: "blur" },
        ],
        tel: [
          { required: true, message: "请输入联系方式", trigger: "blur" },
          {
            pattern: /^((0\d{2,3}-\d{7,8})|(1[34578]\d{9}))$/,
            message: "请输入正确的联系方式",
            trigger: "blur",
          },
        ],
        type: [
          {
            required: true,
            message: "请选择一个类型",
            trigger: "change",
          },
        ],
        desc: [{ required: true, message: "请填写反馈内容", trigger: "blur" }],
      },
    };
  },

  components: {},
  methods: {
    gohome() {
      this.$router.push("/");
    },
    gotoFeedback() {
      this.$router.push("/Feedback");
    },
    submitForm(formName) {
      this.$refs[formName].validate((valid) => {
        if (valid) {
          var iflogin = localStorage.getItem("zmsToken");
          if (iflogin) {
            feedback({
              name: this.ruleForm.name,
              Tel: this.ruleForm.tel,
              type: this.ruleForm.type,
              dese: this.ruleForm.desc,
            })
              .then(() => {
                this.$alert("感谢您的反馈，祝您生活愉快", "反馈成功", {
                  confirmButtonText: "确定",
                  callback: () => {
                    this.$router.push("/");
                  },
                });
              })
              .catch(() => {
                this.$alert("权限错误，请先进行登录或信息验证", "提示", {
                  confirmButtonText: "确定",
                  callback: () => {
                    this.$router.push("/Login");
                  },
                });
              });
          } else {
            this.$alert("请先进行登录", "提示", {
              confirmButtonText: "确定",
              callback: () => {
                this.$router.push("/Login");
              },
            });
          }
        } else {
          return false;
        }
      });
    },
    resetForm(formName) {
      this.$refs[formName].resetFields();
    },
  },
};
</script>

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
.button {
  background-color: #a6ce39;
  font-size: 14px;
  color: #fff;
  margin-right: 10%;
}
.center {
  position: relative;
  left: 23%;
  right: auto;
}
</style>
