<template>
  <div class="app">
    <el-card class="box-card">
      <br />
      <el-steps
        :active="active"
        class="step"
        finish-status="success"
        style="width: 80%"
      >
        <el-step title="基本信息"></el-step>
        <el-step title="验证"></el-step>
        <el-step title="完成"></el-step>
      </el-steps>
      <br /><br />
      <div v-if="active === 0">
        <el-form ref="form" :model="form" label-width="33%" class="step">
          <div class="information">
            <el-form-item style="width: 80%" label="姓名">
              <el-input v-model="form.name"></el-input>
            </el-form-item>
            <el-form-item style="width: 80%" label="性别">
              <el-radio-group v-model="form.resource">
                <el-radio label="男"></el-radio>
                <el-radio label="女"></el-radio>
              </el-radio-group>
            </el-form-item>
            <el-form-item style="width: 80%" label="身份证号">
              <el-input v-model="form.IDcard"></el-input>
            </el-form-item>
            <el-form-item style="width: 80%" label="出生日期">
              <el-col :span="11">
                <el-date-picker
                  type="date"
                  placeholder="选择日期"
                  v-model="form.date"
                  style="width: 220%"
                ></el-date-picker>
              </el-col>
            </el-form-item>
            <br />

            <el-button class="step" style="width: 30%" @click="next"
              >下一步</el-button
            >
          </div>
        </el-form>
      </div>
      <div v-if="active === 1">
        <el-form ref="form" :model="form" label-width="33%" class="step">
          <div class="information">
            <br />
            <br />
            <el-form-item style="width: 80%" label="手机">
              <el-row :gutter="20">
                <el-col :span="20">
                  <el-input v-model="form.Tel"></el-input>
                </el-col>
              </el-row>
            </el-form-item>
            <br />

            <el-form-item label="验证码" style="width: 80%">
              <el-row :gutter="20">
                <el-col :span="14">
                  <el-input
                    style="display: inline-block"
                    v-model="form.Verification"
                  ></el-input>
                </el-col>
                <el-col :span="6">
                  <el-button
                    style="display: inline-block; margin-left: 0px !important"
                    size="medium"
                    >验证码</el-button
                  >
                </el-col>
              </el-row>
            </el-form-item>
            <br />
            <br />
            <el-button class="step" style="width: 30%" @click="next"
              >下一步</el-button
            >
          </div>
        </el-form>
      </div>
      <div v-if="active === 2">
        <el-form ref="form" :model="form" label-width="33%" class="step">
          <div class="information">
            <br />
            <br />
            <el-form-item style="width: 80%" label="密码">
              <el-input v-model="form.password1" show-password></el-input>
            </el-form-item>
            <br />
            <el-form-item style="width: 80%" label="确认密码">
              <el-input v-model="form.password2" show-password></el-input>
            </el-form-item>
            <br /><br />
            <el-button
              class="step"
              style="width: 30%"
              @click="centerDialogVisible = true"
              >下一步</el-button
            >
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
                    >确 定</el-button
                  >
                </span>
              </el-dialog>
            </div>
          </div>
        </el-form>
      </div>
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
</template>
<script>
export default {
  data() {
    return {
      form: {
        name: "",
        IDcard: "",
        region: "",
        date: "",
        Tel: "",
        password1: "",
        password2: "",
        Verification: "",
      },
      active: 0,
      centerDialogVisible: false,
    };
  },
  methods: {
    next() {
      if (this.active++ > 2) this.active = 0;
      console.log("submit!");
    },
    gotoLogin(){
        this.$router.push('/Login')
      },
  },
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
  background: linear-gradient(to right, rgb(52, 232, 158), rgb(15, 52, 67));
}
.step {
  margin: auto;
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