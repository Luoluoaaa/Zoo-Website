
<template>
  <div class="GuideT guidePage">
    <el-container class="consumeTabs">
      <el-aside width="200px">
        <el-card class="box-card">
          <div class="box-item"><h1>评价反馈</h1></div>
          <div class="box-item" style="text-align: left">
            <el-row
              ><el-col :span="6">
                <el-avatar
                  shape="square"
                  size="middle"
                  :src="avatar"
                ></el-avatar>
              </el-col>
              <el-col :span="18">
                <h3
                  style="
                    color: #a6ce39;
                    font-size: 20px;
                    text-align: center;
                    margin: 5px;
                  "
                >
                  Windy:
                </h3>
              </el-col></el-row
            >
            <el-row>
              <p
                style="
                  text-indent: 28px;
                  font-size: 14px;
                  text-align: justify;
                  margin: 5px;
                "
              >
                服务周到，讲解详细，有吸引力，将动物科普讲解的生动有趣，孩子玩得很开心。
              </p></el-row
            >
          </div>
          <div class="box-item" style="text-align: left">
            <el-row
              ><el-col :span="6">
                <el-avatar
                  shape="square"
                  size="middle"
                  :src="avatar"
                ></el-avatar>
              </el-col>
              <el-col :span="18">
                <h3
                  style="
                    color: #a6ce39;
                    font-size: 20px;
                    text-align: center;
                    margin: 5px;
                  "
                >
                  陈先生:
                </h3>
              </el-col></el-row
            >
            <el-row>
              <p
                style="
                  text-indent: 28px;
                  font-size: 14px;
                  text-align: justify;
                  margin: 5px;
                "
              >
                多语讲解服务太给力了，讲解员很幽默有趣，能够照顾到所有人，同行的外国朋友也玩得很愉快，不愧是同济大学附属的动物园，五星好评！
              </p></el-row
            >
          </div>
        </el-card>
      </el-aside>
      <el-container>
        <el-main>
          <el-card class="card1" :body-style="{ padding: '0px' }">
            <img
              class="introImg"
              src="https://cdn.chimelong.com/upload/bae3c3b9f536786b/3b5958d9a3c04b12.jpg"
            />
            <el-row align="middle">
              <el-col :span="20" justify="space-around">
                <span class="text">
                  同济大学附属动物园有经验丰富的导游团队，团队依托同济大学，拥有优秀全职、兼职的人才资源，同时多语导游还能够为来自世界各地的游客朋友提供服务...</span
                >
              </el-col>
              <el-col :span="4" justify-content="space-around">
                <el-button
                  class="button"
                  type="success"
                  @click="dialogFormVisible = true"
                  round
                  ><i class="el-icon-thumb" style="font-size: 16px"></i
                  >立即预约</el-button
                >
              </el-col>
            </el-row>
            <el-dialog
              style="width: 100%; margin: auto"
              title="导游服务预约"
              :visible.sync="dialogFormVisible"
              :modal-append-to-body="false"
            >
              <el-form
                :model="guideForm"
                :rules="rules"
                ref="guideForm"
                label-width="100px"
                :show-message="true"
              >
                <el-form-item type="success" label="入园日期" required>
                  <el-form-item prop="date">
                    <el-date-picker
                      type="date"
                      placeholder="选择日期"
                      v-model="guideForm.date"
                      style="width: 50%"
                      :picker-options="pickerOptions"
                    ></el-date-picker>
                  </el-form-item>
                </el-form-item>
                <el-form-item label="导游姓名" prop="value">
                  <el-radio-group v-model="guideForm.value">
                    <el-row
                      style="
                        font-size: 16px;
                        width: auto;
                        margin: 5px;
                        color: #fff;
                      "
                    >
                      <el-radio label="0">Alma</el-radio>
                      <el-radio label="1">Irma</el-radio>
                      <el-radio label="2">Anton</el-radio>
                    </el-row>
                  </el-radio-group>
                </el-form-item>
                <el-form-item label="服务语言">
                  <el-radio-group
                    v-model="guideForm.value"
                    text-color="#a6ce39"
                    disabled
                  >
                    <el-radio-button label="0">德语</el-radio-button>
                    <el-radio-button label="1">英语</el-radio-button>
                    <el-radio-button label="2">西班牙语</el-radio-button>
                  </el-radio-group>
                </el-form-item>
                <span
                  style="
                    font-weight: bold;
                    font-size: 24px;
                    float: right;
                    margin: -10px 20px;
                  "
                  >票价:{{ price[guideForm.value] }}元</span
                >
              </el-form>
              <div slot="footer" class="dialog-footer">
                <el-button
                  class="button2"
                  type="success"
                  @click="resetForm('guideForm')"
                  >清 空</el-button
                >
                <el-button @click="submitForm('guideForm')" style="color:grey">确 定</el-button>
                <el-button
                  class="button2"
                  type="success"
                  @click="[resetForm('guideForm'), (dialogFormVisible = false)]"
                  >取 消</el-button
                >
              </div>
            </el-dialog>
          </el-card>
          <el-header><span style="color: grey">多语导游介绍</span></el-header>
          <el-row>
            <el-col :span="8">
              <div class="person">
                <div class="container" @click="check1">
                  <div class="container-inner">
                    <img class="circle" :src="bg01" />
                    <img class="img img1" :src="guide01" />
                  </div>
                </div>
                <div class="divider"></div>
                <div class="name">Alma</div>
                <div class="title">From：Germany</div>
              </div>
            </el-col>
            <el-col :span="8">
              <div class="person">
                <div class="container" @click="check2">
                  <div class="container-inner">
                    <img class="circle" :src="bg02" />
                    <img class="img img2" :src="guide02" />
                  </div>
                </div>
                <div class="divider"></div>
                <div class="name">Irma</div>
                <div class="title">From: America</div>
              </div>
            </el-col>
            <el-col :span="8">
              <div class="person">
                <div class="container" @click="check3">
                  <div class="container-inner">
                    <img class="circle" :src="bg03" />
                    <img class="img img3" :src="guide03" />
                  </div>
                </div>
                <div class="divider"></div>
                <div class="name">Anton</div>
                <div class="title">From: Spain</div>
              </div>
            </el-col>
          </el-row>
        </el-main>
      </el-container>
    </el-container>
    <div class="blockTran"></div>
  </div>
</template>

<script>
export default {
  data() {
    return {
      price: [120, 150, 200],
      bg01: require("../picture/bg01.jpg"),
      guide01: require("../picture/guide01.png"),
      bg02: require("../picture/bg02.jpg"),
      guide02: require("../picture/guide02.png"),
      bg03: require("../picture/bg03.jpg"),
      guide03: require("../picture/guide03.png"),
      avatar:
        "https://cube.elemecdn.com/9/c2/f0ee8a3c7c9638a54940382568c9dpng.png",

      ID: 1234567,
      dialogFormVisible: false,
      valid: true,
      guideForm: {
        date: "",
        value: "",
      },
      rules: {
        date: [
          {
            type: "date",
            required: true,
            message: "请选择入园日期",
            trigger: "blur",
          },
        ],
        value: [
          { required: true, message: "请选择您要预约的导游", trigger: "blur" },
        ],
      },
      pickerOptions: {
        disabledDate(time) {
          return time.getTime() < Date.now();
        },
      },
    };
  },
  methods: {

    gotoLogin(){
        this.$router.push('/Login')
      },
    submitForm(formname) {
      this.$refs[formname].validate((valid) => {
        if (valid) {
          var iflogin = localStorage.getItem("zmsToken");
          console.log(iflogin);
          if(iflogin){
          console.log('login');
         this.resetForm("guideForm");
          this.dialogFormVisible = false;
          alert(
            "预定成功！您的单号是：" +
              this.ID +
              "\n请凭此单号，持身份原证及其他证件到园区正门售票处付费取票！"
          );}
          else{
            this.$alert('请先进行登录', '提示', {
          confirmButtonText: '确定',
          callback: action => {
            this.gotoLogin();
          }
        });
          }
        } else {
          console.log("error submit!!");
          return false;
        }
      })
      },
    resetForm(formName) {
      this.$refs[formName].resetFields();
    },
    check1() {
      const h = this.$createElement;
      this.$msgbox({
        title: "导游介绍——Alma",
        message: h("p", null, [
          h(
            "p",
            {
              style: "text-indent: 28px;font-size: 14px; text-align: justify; ",
            },
            "Alma，来自德国，同济大学留学生。五年任职期间，她工作认真，讲解清晰，风趣幽默，收获好评无数，被多次评为“金牌讲解员”"
          ),
          h(
            "span",
            { style: "font-weight: bold;color:#ff5353;font-size: 16px" },
            ["费用：￥", this.price[0], "元/小时"]
          ),
        ]),
        showConfirmButton: false,
      });
    },
    check2() {
      const h = this.$createElement;
      this.$msgbox({
        title: "导游介绍——Irma",
        message: h("p", null, [
          h(
            "p",
            {
              style: "text-indent: 28px;font-size: 14px; text-align: justify; ",
            },
            "Irma，来自美国，同济大学留学生。五年任职期间，她工作认真，讲解清晰，风趣幽默，收获好评无数，被多次评为“金牌讲解员”"
          ),
          h(
            "span",
            { style: "font-weight: bold;color:#ff5353;font-size: 16px;" },
            ["费用：￥", this.price[1], "元/小时"]
          ),
        ]),
        showConfirmButton: false,
      });
    },
    check3() {
      const h = this.$createElement;
      this.$msgbox({
        title: "导游介绍——Anton",
        message: h("p", null, [
          h(
            "p",
            {
              style: "text-indent: 28px;font-size: 14px; text-align: justify; ",
            },
            "Anton，来自西班牙，同济大学留学生。五年任职期间，她工作认真，讲解清晰，风趣幽默，收获好评无数，被多次评为“金牌讲解员”"
          ),
          h(
            "span",
            { style: "font-weight: bold;color:#ff5353;font-size: 16px" },
            ["费用：￥", this.price[2], "元/小时"]
          ),
        ]),
        showConfirmButton: false,
      });
    },
  },
};
</script>

<style scoped lang="scss">
.guidePage {
  display: block;
  padding: 0px;
  background-color: transparent;
  background-size: 100% 50%;
  background-image: url("https://cdn.chimelong.com/assets/images/pic.6e73287.png");
  background-repeat: no-repeat;
  background-position: center bottom;
}
.consumeTabs {
  margin: 25px 75px 50px 75px;
  background: transparent;
}
.el-container {
  margin-bottom: 40px;
}
.el-header {
  background-color: #f6faeb00;
  text-align: center;
  line-height: 120px;
  font-size: 28px;
  z-index: 1;
}

.el-aside {
  background-color: transparent;
  color: #333;
  text-align: center;
}

.el-card {
  position: relative;
  margin-top: 10px;
  width: 250px;
  height: 200px;
  border-radius: 20px;
  display: block;
  margin-left: auto;
  margin-right: auto;
}
.card1 {
  position: relative;
  margin-top: 0px;
  width: 100%;
  height: auto;
  display: block;
  margin-left: auto;
  margin-right: auto;
  text-align: justify;
  background: #f6faeb;
}
.button {
  position: relative;
  width: 100%;
  margin-left: -40px;
  margin-right: auto;
  margin-top: 20px;
  margin-bottom: 20px;
  float: center;
  background-color: #a6ce39;
  font-size: 16px;
  color: #fff;
}
.button2 {
  background-color: #a6ce39;
  font-size: 14px;
  color: #fff;
}

.text {
  width: 90%;
  font-size: 18px;
  margin: 10px 0px 0px 30px;
  height: auto;
  display: block;
}
.introImg {
  width: 100%;
  height: 70vh;
}
.box-item {
  padding: 18px 0;
}
.box-card {
  width: 100%;
  height: auto;
  background: #f6faeb;
  position: relative;
  border-radius: 20px;
}
.blockTran {
  height: 150px;
  background: transparent;
}
//people components

.person {
  align-items: center;
  display: flex;
  flex-direction: column;
  width: 280px;
}
.container {
  border-radius: 50%;
  height: 300px;
  -webkit-tap-highlight-color: transparent;
  transform: scale(0.48);
  transition: transform 250ms cubic-bezier(0.4, 0, 0.2, 1);
  width: 400px;
}

.container:hover {
  transform: scale(0.54);
}
.container-inner {
  clip-path: path(
    "M 390,400 C 390,504.9341 304.9341,590 200,590 95.065898,590 10,504.9341 10,400 V 10 H 200 390 Z"
  );
  position: relative;
  transform-origin: 50%;
  top: -200px;
}
.circle {
  background-color: #fee7d3;
  border-radius: 50%;
  cursor: pointer;
  height: 380px;
  left: 10px;
  pointer-events: none;
  position: absolute;
  top: 210px;
  width: 380px;
}
.img {
  pointer-events: none;
  position: relative;
  transform: translateY(20px) scale(1.15);
  transform-origin: 50% bottom;
  transition: transform 300ms cubic-bezier(0.4, 0, 0.2, 1);
}
.container:hover .img {
  transform: translateY(0) scale(1.2);
}
.img1 {
  left: 22px;
  top: 164px;
  width: 340px;
}
.img2 {
  left: -46px;
  top: 174px;
  width: 444px;
}
.img3 {
  left: -16px;
  top: 144px;
  width: 466px;
}
.divider {
  background-color: #a6ce39;
  height: 1px;
  width: 160px;
}
.name {
  color: #404245;
  font-size: 36px;
  font-weight: 600;
  margin-top: 16px;
  text-align: center;
}
.title {
  color: #6e6e6e;
  font-family: arial;
  font-size: 14px;
  font-style: italic;
  margin-top: 4px;
}
</style>
<style lang="less">
/* 选中后的字体颜色 */
.el-radio__input.is-checked + .el-radio__label {
  color: #a6ce39 !important;
}
/* 选中后小圆点的颜色 */
.el-radio__input.is-checked .el-radio__inner {
  background: #a6ce39 !important;
  border-color: #a6ce39 !important;
}
</style>