<template>
  <div>
    <el-form
      :model="ruleForm"
      status-icon
      :rules="rules"
      ref="ruleForm"
      label-width="100px"
      class="demo-ruleForm"
    >
      <el-form-item label="密码" prop="pass" style="width:80%">
        <el-input
          type="password"
          v-model="ruleForm.pass"
          autocomplete="off"
          
        ></el-input>
      </el-form-item>
      <br />
      <el-form-item label="确认密码" prop="checkPass" style="width:80%">
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
              >立即注册</el-button
            >

      
      </el-form-item>
    </el-form>
  <div class="out">
              <el-dialog
                modal="true"
                modal-append-to-body="false"
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
                  <el-button
                     @click="gotoLogin"
                     style="color:grey"
                    >确 定</el-button
                  >
                </span>
              </el-dialog>
            </div>
  </div>
</template>

<script>
import { postInformation } from "@/api/register";
export default {
  data() {
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
    return {
      centerDialogVisible: false,
      ruleForm: {
        pass: "",
        checkPass: "",
      },
      rules: {
        pass: [{ validator: validatePassword, trigger: "blur" }],
        checkPass: [{ validator: validatePassword2, trigger: "blur" }],
      },
    };
  },
  
  methods: {
      post1() {
        var Name=localStorage.getItem("name");
        var Realname=localStorage.getItem("realname");
        var Sex=localStorage.getItem("sex");
        var idcard=localStorage.getItem("IDcard");
        var Tel=localStorage.getItem("tel");
        var Mail=localStorage.getItem("mail")
      postInformation({
        name: Name,
        realname: Realname,
        sex: Sex,
        IDcard: idcard,
        tel: Tel,
        mail: Mail,
        password: this.ruleForm.pass,
      })
        .then((response) => {
          console.log("submit");
        })
        .catch(function (error) {
          console.log(error);
        });
    },
    submitForm(formName) {
      this.$refs[formName].validate((valid) => {
        if (valid) {
          console.log(this.Name);
          console.log(this.Realname);
          console.log(this.Sex);
          console.log(this.idcard);
          console.log(this.Tel);
          console.log(this.Mail);
          console.log(this.ruleForm.pass);
          this.post1();
          this.centerDialogVisible = true;
        } else {
          console.log("error submit!!");
          return false;
        }
      });
    },
    resetForm(formName) {
      this.$refs[formName].resetFields();
    },
    gotoLogin() {
      this.$router.push("/Login");
    },
  },
};
</script>

