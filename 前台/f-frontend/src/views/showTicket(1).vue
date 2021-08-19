<template>
  <div id="app">
    <div class="ShowT showpage">
      <ul>
        <el-header class="header1"><span>马戏介绍</span></el-header>
        <li class="li1">
          <el-card class="card1" :body-style="{ padding: '0px' }">
            <img
              class="introImg"
              src="https://cdn.chimelong.com/assets/images/pic-pc.72843be.jpg"
            />
            <el-row align="middle">
              <el-col :span="20" justify="space-around">
                <span class="text">
                  同济大马戏位于全国AAAAA景区嘉定同济大学附属动物园，拥有实景式马戏舞台，数千万巨资打造极致奢华尖端舞美科技和数亿巨资建造的马戏表演场，能容纳近7000名观众同时观看。全球高规格的舞台设施和主题节目，自然少不了庞大的国际化演艺团队，拥有来自20多个国家，横跨亚洲、欧洲、美洲、非洲共300余名...</span
                >
              </el-col>
              <el-col :span="4" justify-content="space-around">
                <el-button class="button" type="success" round
                  ><i class="el-icon-thumb" style="font-size: 16px"></i
                  >了解更多</el-button
                >
              </el-col>
            </el-row>
          </el-card>
        </li>
        <li class="li2">
          <el-col :span="8">
            <el-card class="card2">
              <span class="header2">超值预订</span>
              <el-card class="card3" :body-style="{ padding: '0px' }">
                <el-col :span="6"
                  ><span class="blockT">￥{{ showPrice[0] }}元/人</span></el-col
                >
                <el-col :span="18" class="rela">
                  <div class="spanLine"></div>
                  <div
                    style="padding: 20px; font-size: 18px; text-align: center"
                  >
                    <span>普通票</span>
                  </div>
                  <el-row type="flex" justify="center">
                    <el-button
                      class="link"
                      type="text"
                      @click="dialogFormVisible = true"
                      >立即预订>></el-button
                    >
                  </el-row>
                </el-col>
              </el-card>
              <el-card class="card3" :body-style="{ padding: '0px' }">
                <el-col :span="6"
                  ><span class="blockT">￥{{ showPrice[1] }}元/人</span></el-col
                >
                <el-col :span="18" class="rela">
                  <div class="spanLine"></div>
                  <div
                    style="padding: 20px; font-size: 18px; text-align: center"
                  >
                    <span>儿童/长者/优待票</span>
                  </div>
                  <el-row type="flex" justify="center">
                    <el-button
                      class="link"
                      type="text"
                      @click="dialogFormVisible = true"
                      >立即预订>></el-button
                    >
                  </el-row>
                </el-col>
              </el-card>
              <el-card class="card3" :body-style="{ padding: '0px' }">
                <el-col :span="6"
                  ><span class="blockT">￥{{ showPrice[2] }}元/人</span></el-col
                >
                <el-col :span="18" class="rela">
                  <div class="spanLine"></div>
                  <div
                    style="padding: 20px; font-size: 18px; text-align: center"
                  >
                    <span>学生票</span>
                  </div>
                  <el-row type="flex" justify="center">
                    <el-button
                      class="link"
                      type="text"
                      @click="dialogFormVisible = true"
                      >立即预订>></el-button
                    >
                  </el-row>
                </el-col>
              </el-card>
              <el-card class="card3" :body-style="{ padding: '0px' }">
                <el-col :span="6"
                  ><span class="blockT">￥{{ showPrice[3] }}元/人</span></el-col
                >
                <el-col :span="18" class="rela">
                  <div class="spanLine"></div>
                  <div
                    style="padding: 20px; font-size: 18px; text-align: center"
                  >
                    <span>VIP座票</span>
                  </div>
                  <el-row type="flex" justify="center">
                    <el-button
                      class="link"
                      type="text"
                      @click="dialogFormVisible = true"
                      >立即预订>></el-button
                    >
                  </el-row>
                </el-col>
              </el-card>
            </el-card>
            <el-dialog
              style="width: 100%; margin: auto"
              title="套票预订"
              :visible.sync="dialogFormVisible"
              :modal-append-to-body="false"
            >
              <el-form
                :model="showForm"
                :rules="rules"
                ref="showForm"
                label-width="100px"
                :show-message="true"
              >
                <el-form-item type="success" label="入园日期" required>
                  <el-form-item prop="date">
                    <el-date-picker
                      type="date"
                      placeholder="选择日期"
                      v-model="showForm.date"
                      style="width: 50%"
                      :picker-options="pickerOptions"
                    ></el-date-picker>
                  </el-form-item>
                </el-form-item>
                <el-form-item label="套票类型" prop="value">
                  <el-radio-group v-model="showForm.value">
                    <el-row style="font-size: 16px; width: auto; margin: 5px">
                      <el-radio label="0">普通票</el-radio>
                      <el-radio label="1">儿童/长者/优待票</el-radio>
                      <el-radio label="2">学生票</el-radio>
                      <el-radio label="3">VIP座票</el-radio>
                    </el-row>
                  </el-radio-group>
                </el-form-item>
                <span
                  style="
                    font-weight: bold;
                    font-size: 24px;
                    float: right;
                    margin: -10px 20px;
                  "
                  >票价:{{ showPrice[showForm.value] }}元</span
                >
              </el-form>
              <div slot="footer" class="dialog-footer">
                <el-button
                  class="button2"
                  type="success"
                  @click="resetForm('showForm')"
                  >清 空</el-button
                >
                <el-button style="color: grey" @click="submitForm('showForm')"
                  >确 定</el-button
                >
                <el-button
                  class="button2"
                  type="success"
                  @click="[resetForm('showForm'), (dialogFormVisible = false)]"
                  >取 消</el-button
                >
              </div>
            </el-dialog>
          </el-col>
          <el-col :span="8">
            <el-card class="card2">
              <span class="header2">表演安排</span>
              <el-col :span="6"
                ><span style="font-size: 96px; color: #a6cd39"
                  ><i class="el-icon-time"></i></span
              ></el-col>
              <el-col :span="18"
                ><div
                  style="
                    font-size: 30px;
                    color: #a6cd39;
                    display: block;
                    padding: 25px 20px;
                  "
                >
                  <p>近期剧目：</p>
                  <p style="color: #111">{{ showName }}</p>
                </div></el-col
              >
              <img
                src="https://cdn.chimelong.com/assets/images/pic-5.538ba90.jpg"
                style="width: 100%; border-radius: 10px"
              />
              <div
                style="
                  font-size: 20px;
                  color: #111;
                  display: block;
                  padding: 10px 20px;
                  line-height: 1.5;
                "
              >
                <p style="color: #a6cd39">演出时间:</p>
                <p style="font-weight: bold">
                  第一场：{{ showStart1 }}-{{ showEnd1 }}<br />第二场：{{
                    showStart2
                  }}-{{ showEnd2 }}
                </p>
              </div>
            </el-card>
          </el-col>
          <el-col :span="8">
            <el-card class="card2">
              <span class="header2">剧院地图</span>
              <div class="demo-image__preview">
                <el-image
                  style="width: 100%; height: 100%; padding: 20px 0"
                  :src="mapS"
                  :preview-src-list="mapL"
                >
                </el-image>
              </div>
              <div style="font-size: 18px; text-align: center; padding: 10px">
                (<i class="el-icon-zoom-in"></i>点击查看大图)
              </div>
            </el-card>
          </el-col>
        </li>
        <el-footer><span></span></el-footer>
      </ul>
    </div>
  </div>
</template>

<script>
export default {
  data() {
    return {
      imgArrag: [
        "https://cdn.chimelong.com/upload/4f17fdf0386d6acb/d50da0b6dca88bd2.jpg",
        "https://cdn.chimelong.com/upload/8c812667e21b4797/e0a65322449fb3b5.jpg",
        "https://cdn.chimelong.com/upload/4f17fdf0386d6acb/d50da0b6dca88bd2.jpg",
        "https://cdn.chimelong.com/upload/8c812667e21b4797/e0a65322449fb3b5.jpg",
      ],
      imgPris: require("../picture/0.png"),
      icon1: require("../picture/icon_f70qqjo14pr/menpiao.png"),
      icon2: require("../picture/icon_f70qqjo14pr/yanchupiao.png"),
      icon3: require("../picture/icon_f70qqjo14pr/youleche.png"),
      icon4: require("../picture/icon_f70qqjo14pr/gongjudaoyou.png"),
      showPrice: [450, 450 * 0.7, 450 * 0.8, 450 * 1.2],
      showName: "《马戏好莱坞》",
      showStart1: "14:00",
      showEnd1: "18:00",
      showStart2: "17:00",
      showEnd2: "21:00",
      mapS: "https://cdn.chimelong.com/upload/4bd565ac4c4ab924/cce70c70e0f9b53a.jpg",
      mapL: [
        "https://cdn.chimelong.com/upload/cfd283954d3ca65f/fb31a0b9dd0a54a6.jpg",
      ],

      ID: 1234567,
      dialogFormVisible: false,
      valid: true,
      showForm: {
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
        value: [{ required: true, message: "请选择一种票种", trigger: "blur" }],
      },
      pickerOptions: {
        disabledDate(time) {
          return time.getTime() < Date.now();
        },
      },
    };
  },
  computed: {},
  methods: {
    handleClick(tab, event) {
      console.log(tab, event);
    },
    submitForm(formname) {
      this.$refs[formname].validate((valid) => {
        if (valid) {

          var iflogin = localStorage.getItem("zmsToken");
          if(iflogin){
          console.log('login');
          this.resetForm("showForm");
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
           
           // this.gotoLogin();
          }
        } else {
          console.log("error submit!!");
          return false;
        }
      });
    },
    resetForm(formName) {
      this.$refs[formName].resetFields();
    },
    gotoLogin(){
      this.$router.push('/Login')
      },
  },
};
</script>

<style scoped lang="scss">
#app {
  background: #ededef;
}
body > .el-container {
  margin-bottom: 40px;
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
  background: #ededef;
}
.el-tag {
  color: #a6cd39;
  text-align: center;
  font-weight: bold;
  font-size: 18px;
  padding: 10px 20px 10px 20px;
  background-color: #fff;
  width: 100%;
  height: 100%;
  border-left: 6px solid #a6cd39;
}
.icon {
  width: 18px;
  height: 18px;
  margin-bottom: -2px;
}
.conPage {
  display: block;
  padding: 0px;
  margin-left: 10px;
  background: #f6faeb;
  border-radius: 20px;
}

.showpage {
  display: block;
  padding: 0px;
  background-color: transparent;
  background-size: 100% 50%;
  background-image: url("https://cdn.chimelong.com/assets/images/pic.b0b9598.png");
  background-repeat: no-repeat;
  background-position: center bottom;
}
.header1 {
  background-color: transparent;
  text-align: center;
  margin-top: 20px;
  line-height: 200px;
  font-size: 28px;
  z-index: 1;
}
.header2 {
  display: block;
  margin-left: 0 auto;
  margin-right: 0 auto;
  text-align: center;
  font-size: 28px;
  z-index: 1;
}
.card1 {
  position: relative;
  margin-top: 0px;
  width: 100%;
  height: 100%;
  display: block;
  margin-left: auto;
  margin-right: auto;
  text-align: justify;
}
.card2 {
  position: relative;
  border-radius: 20px;
  margin-top: 0px;
  width: 100%;
  height: 100%;
  display: block;
  margin-left: auto;
  margin-right: auto;
  background: #f6faeb;
}
.card3 {
  position: relative;
  margin-top: 10px;
  width: 350px;
  height: 100px;
  border-radius: 20px;
  display: block;
  margin-left: auto;
  margin-right: auto;
}
.blockT {
  position: relative;
  display: block;
  color: #fff;
  text-align: center;
  padding: 45% 0;
  height: 100px;
  width: 100%;
  background: #a6cd39;
  border-radius: 20px 0em 0em 20px;
  z-index: 100;
}
.spanLine {
  position: absolute;
  direction: "vertical";
  top: 50%;
  left: 0;
  width: 100%;
  display: block;
  border-bottom: 2px dashed rgba(0, 0, 0, 0.1);
  z-index: 0;
}
.button {
  position: relative;
  width: 100%;
  margin-left: -40px;
  margin-top: 30px;
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
.introImg {
  width: 100%;
  height: 80%;
}
.text {
  width: 90%;
  font-size: 18px;
  margin: 10px 0px 0px 30px;
  height: auto;
  display: block;
  text-overflow: ellipsis;
}

.link {
  position: relative;
  bottom: 10px;
  display: block;
  margin-left: auto;
  margin-right: auto;
  color: #a6ce39;
  font-size: 14px;
}

ul {
  height: 90vh;
  width: 100vw;
  overflow: auto;
  position: relative;
  scroll-snap-type: y mandatory;
}
.li1 {
  scroll-snap-align: center;
  height: 70vh;
  width: 90vw;
  border-radius: 20px;
  overflow: hidden;
  position: relative;
  display: flex;
  justify-content: center;
  margin: 10vh auto;
  box-shadow: 0px 10px 60px 10px rgba(0, 0, 0, 0.3);
  z-index: 100;
  background: #f6faeb;
}
.li2 {
  scroll-snap-align: center;
  height: 70vh;
  width: 90vw;
  border-radius: 20px;
  overflow: hidden;
  position: relative;
  display: flex;
  justify-content: center;
  margin: 10vh auto;
  background: transparent;
  box-shadow: 0px 10px 60px 10px rgba(0, 0, 0, 0.1);
  z-index: 100;
}
</style>
