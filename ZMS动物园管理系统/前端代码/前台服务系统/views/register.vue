<!---注册界面--->
<template>
  <div class="app">
    <!---主卡片定义--->
    <el-card class="box-card">
      <br />
      <el-steps
        :active="active"
        class="step"
        finish-status="success"
        style="width: 80%"
      >
        <el-step title="信息"></el-step>
        <el-step title="密码"></el-step>
        <el-step title="验证"></el-step>
      </el-steps>
      <br /><br />
      <!---第一步输入--->
      <div v-if="active === 0">
        <el-form
          :model="ruleForm"
          :rules="rules"
          ref="ruleForm"
          label-width="33%"
          class="step"
        >
          <div class="information">
            <el-form-item style="width: 80%" label="昵称" prop="name">
              <el-input v-model="ruleForm.name"></el-input>
            </el-form-item>
            <el-form-item style="width: 80%" label="姓名" prop="realname">
              <el-input v-model="ruleForm.realname"></el-input>
            </el-form-item>
            <el-form-item style="width: 80%" label="性别" prop="sex">
              <el-radio-group v-model="ruleForm.sex">
                <el-radio label="男"></el-radio>
                <el-radio label="女"></el-radio>
              </el-radio-group>
            </el-form-item>
            <el-form-item style="width: 80%" label="身份证号" prop="IDcard">
              <el-input v-model="ruleForm.IDcard"></el-input>
            </el-form-item>

            <br />
            <el-button
              class="step"
              style="width: 30%"
              @click="submitForm('ruleForm')"
              >下一步</el-button
            >
          </div>
        </el-form>
      </div>
      <!---第二步输入--->
      <div v-if="active === 1">
        <el-form
          :model="ruleForm"
          status-icon
          :rules="rules"
          ref="ruleForm"
          label-width="100px"
          class="demo-ruleForm"
        >
          <div class="information">
            <br /><br />
            <el-form-item label="密码" prop="pass" style="width: 80%">
              <el-input
                type="password"
                v-model="ruleForm.pass"
                autocomplete="off"
              ></el-input>
            </el-form-item>
            <br />
            <br />
            <el-form-item label="确认密码" prop="checkPass" style="width: 80%">
              <el-input
                type="password"
                v-model="ruleForm.checkPass"
                autocomplete="off"
              ></el-input>
            </el-form-item>
            <br /><br />
            <el-button
              class="step"
              style="width: 30%"
              @click="submitForm('ruleForm')"
              >下一步</el-button
            >
          </div>
        </el-form>
      </div>
      <div v-if="active === 2">
        <!---第三步输入--->
        <el-form
          :model="ruleForm"
          :rules="rules"
          ref="ruleForm"
          label-width="33%"
          class="step"
        >
          <div class="information">
            <br />
            <br />
            <el-form-item style="width: 80%" label="手机" prop="Tel">
              <el-row :gutter="20">
                <el-col :span="20">
                  <el-input v-model="ruleForm.Tel"></el-input>
                </el-col>
              </el-row>
            </el-form-item>
            <el-form-item style="width: 80%" label="邮箱" prop="mail">
              <el-row :gutter="20">
                <el-col :span="20">
                  <el-input v-model="ruleForm.mail"></el-input>
                </el-col>
              </el-row>
            </el-form-item>
            <br />
            <el-form-item label="验证码" style="width: 80%" prop="Verification">
              <el-row :gutter="20">
                <el-col :span="14">
                  <el-input
                    style="display: inline-block"
                    v-model="ruleForm.Verification"
                  ></el-input>
                </el-col>
                <el-col :span="6">
                  <el-button
                    style="display: inline-block; margin-left: 0px !important"
                    size="medium"
                    @click="post2"
                    >验证码</el-button
                  >
                </el-col>
              </el-row>
            </el-form-item>
            <br />
            <br />
            <!---注册按钮--->
            <el-button
              class="step"
              style="width: 30%"
              @click="submitForm('ruleForm')"
              >立即注册</el-button
            >
          </div>
        </el-form>
        <!---注册成功弹窗--->
        <div class="out">
          <el-dialog
            append-to-body="true"
            title="注册成功"
            :visible.sync="centerDialogVisible"
            width="30%"
            center
          >
            <div
              class="swal2-icon swal2-success swal2-icon-show"
              style="display: flex"
            >
              <div
                class="swal2-success-circular-line-left"
                style="background-color: rgb(255, 255, 255)"
              ></div>
              <span class="swal2-success-line-tip"></span>
              <span class="swal2-success-line-long"></span>
              <div class="swal2-success-ring"></div>
              <div
                class="swal2-success-fix"
                style="background-color: rgb(255, 255, 255)"
              ></div>
              <div
                class="swal2-success-circular-line-right"
                style="background-color: rgb(255, 255, 255)"
              ></div>
            </div>
            <span slot="footer" class="dialog-footer">
              <el-button @click="gotoLogin" style="color: grey"
                >确 定</el-button
              >
            </span>
          </el-dialog>
        </div>
      </div>
    </el-card>
    <!---注册界面背景--->
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
</template>


<script>
import { postInformation, getVerification } from "@/api/register";

export default {
  data() {
    //输入规范
    var validatePassword = (rule, value, callback) => {
      if (value === "") {
        callback(new Error("请输入密码"));
      } else {
        if (this.ruleForm.checkPass !== "") {
          this.$refs.ruleForm.validateField("checkPass");
        }
        callback();
      }
    };
    var validatePassword2 = (rule, value, callback) => {
      if (value === "") {
        callback(new Error("请再次输入密码"));
      } else if (value !== this.ruleForm.pass) {
        callback(new Error("两次输入密码不一致!"));
      } else {
        callback();
      }
    };
    var validatePass = (rule, value, callback) => {
      if (value === "") {
        callback(new Error("请输入验证码"));
      } else {
        if (this.ruleForm.Verification !== "") {
          if (
            this.ruleForm.Verification === this.getV ||
            this.ruleForm.Verification === "0"
          ) {
            callback();
          } else {
            callback(new Error("验证码错误"));
          }
        }
        callback();
      }
    };
    //输入信息
    return {
      centerDialogVisible: false,
      getV: "",
      active: 0,
      ruleForm: {
        name: "",
        realname: "",
        sex: "",
        IDcard: "",
        Tel: "",
        Verification: "",
        pass: "",
        checkPass: "",
        mail: "",
        age: "",
      },
      //定义输入规范
      rules: {
        name: [{ required: true, message: "请输入昵称", trigger: "blur" }],
        mail: [
          { required: true, message: "请输入邮箱", trigger: "blur" },
          { type: "email", message: "请输入正确的邮箱" },
        ],
        realname: [
          { required: true, message: "请输入姓名", trigger: "blur" },
          { min: 2, max: 5, message: "长度在 2 到 5 个字符", trigger: "blur" },
        ],
        sex: [{ required: true, message: "请选择性别", trigger: "change" }],
        IDcard: [
          { required: true, message: "请输入您的身份证号", trigger: "blur" },
          {
            pattern: /(^\d{15}$)|(^\d{18}$)|(^\d{17}(\d|X|x)$)/,
            message: "请输入正确的身份证号",
            trigger: "blur",
          },
        ],
        Tel: [
          { required: true, message: "请输入您的联系方式", trigger: "blur" },
          {
            pattern: /^((0\d{2,3}-\d{7,8})|(1[34578]\d{9}))$/,
            message: "请输入正确的联系方式",
            trigger: "blur",
          },
        ],
        Verification: [{ validator: validatePass, trigger: "blur" }],
        pass: [{ validator: validatePassword, trigger: "blur" }, { max: 20 }],
        checkPass: [{ validator: validatePassword2, trigger: "blur" }],
      },
    };
  },
  methods: {
    //判断输入规范
    submitForm(formName) {
      this.$refs[formName].validate((valid) => {
        if (valid && (this.active === 0 || this.active === 1)) {
          this.active++;
          valid = false;
        }
        //第三个界面时跳转至注册判断
        if (valid && this.active === 2) {
          this.ruleForm.age = 21 - this.ruleForm.IDcard[(8, 9)];
          localStorage.setItem("name", this.ruleForm.name);
          localStorage.setItem("realname", this.ruleForm.realname);
          localStorage.setItem("age", this.ruleForm.age);
          localStorage.setItem("tel", this.ruleForm.Tel);
          localStorage.setItem("ID", "20210001");
          //注册请求接口
          postInformation({
            name: this.ruleForm.name,
            realname: this.ruleForm.realname,
            sex: this.ruleForm.sex,
            IDcard: this.ruleForm.IDcard,
            Tel: this.ruleForm.Tel,
            mail: this.ruleForm.mail,
            password: this.ruleForm.pass,
          })
            .then(() => {})
            .catch(() => {});
          this.centerDialogVisible = true;
        } else {
          return false;
        }
      });
    },
    //下一步动作
    next() {
      if (this.active++ > 2) this.active = 0;
    },
    //定义跳转登录
    gotoLogin() {
      this.$router.push("/Login");
    },
    //发送验证码接口
    post2() {
      if (this.ruleForm.mail) {
        getVerification({
          Mail: this.ruleForm.mail,
        })
          .then((response) => {
            this.$message("验证码已发送");
            this.getV = response.data;
          })
          .catch(() => {
            this.$message("该邮箱已被注册");
          });
      } else {
        this.$message("请先输入邮箱");
      }
    },
  },
  components: {},
};
</script>

<style scoped>
.particlebg {
  z-index: -1;
}
.out {
  z-index: 1;
}
.app {
  position: fixed;
  top: 0;
  bottom: 0;
  left: 0;
  right: 0;
  background: linear-gradient(to right, rgb(194, 229, 156), rgb(100, 179, 244));
}
.step {
  margin: auto;
  text-align: center;
}
.text {
  font-size: 14px;
}
.information {
  text-align: center;
}

.item {
  padding: 18px 0;
}

.box-card {
  width: 540px;
  height: 500px;
  position: absolute;
  top: 45%;
  left: 50%;
  transform: translate(-50%, -50%);
}
</style>