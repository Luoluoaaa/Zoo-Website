<!---网上预订 游园交通--->
<template>
  <div class="VehicleT vechiclePage">
    <el-header><span>特色游园</span></el-header>
    <el-main>
      <el-card class="mainCard">
        <el-row>
          <div class="Cards">
            <el-col :span="8" justify="space-around">
              <el-card :body-style="{ padding: '0px' }">
                <div style="padding: 20px; font-size: 18px; text-align: center">
                  <span>环园小火车</span>
                </div>
                <img
                  src="https://cdn.chimelong.com/upload/eaa5ec555452a0a4/266e8bad2e088404.jpg"
                  class="introImg"
                />
                <el-button
                  class="link"
                  type="text"
                  @click="get('全价票', '环园小火车')"
                  >查看详情></el-button
                >
                <div
                  style="padding: 0px 0 0; font-size: 20px; text-align: center"
                >
                  <span style="color: #ff5353">￥{{ this.p1 }}元/人</span>
                </div>
                <el-row type="flex" justify="center">
                  <el-button
                    class="button"
                    type="success"
                    @click="dialogFormVisible = true"
                    round
                    ><i class="el-icon-price-tag" style="font-size: 16px"></i
                    >立即预订</el-button
                  >
                </el-row>
              </el-card>
            </el-col>
            <el-col :span="8" justify="space-around">
              <el-card :body-style="{ padding: '0px' }">
                <div style="padding: 20px; font-size: 18px; text-align: center">
                  <span>空中观光缆车</span>
                </div>
                <img
                  src="https://cdn.chimelong.com/upload/4b26f3741ce67587/af56df792008e445.jpg"
                  class="introImg"
                />
                <el-button
                  class="link"
                  type="text"
                  @click="get('全价票', '空中缆车')"
                  >查看详情></el-button
                >
                <div
                  style="padding: 0px 0 0; font-size: 20px; text-align: center"
                >
                  <span style="color: #ff5353">￥{{ this.p2 }}元/人</span>
                </div>
                <el-row type="flex" justify="center">
                  <el-button
                    class="button"
                    type="success"
                    @click="dialogFormVisible = true"
                    round
                    ><i class="el-icon-price-tag" style="font-size: 16px"></i
                    >立即预订</el-button
                  >
                </el-row>
              </el-card>
            </el-col>
            <el-col :span="8" justify="space-around">
              <el-card :body-style="{ padding: '0px' }">
                <div style="padding: 20px; font-size: 18px; text-align: center">
                  <span>观光马车</span>
                </div>
                <img :src="iV3" class="introImg" />
                <el-button
                  class="link"
                  type="text"
                  @click="get('全价票', '观光马车')"
                  >查看详情></el-button
                >
                <div
                  style="padding: 0px 0 0; font-size: 20px; text-align: center"
                >
                  <span style="color: #ff5353">￥{{ this.p3 }}元/人</span>
                </div>
                <el-row type="flex" justify="center">
                  <el-button
                    class="button"
                    type="success"
                    @click="dialogFormVisible = true"
                    round
                    ><i class="el-icon-price-tag" style="font-size: 16px"></i
                    >立即预订</el-button
                  >
                </el-row>
              </el-card>
            </el-col>
            <el-dialog
              style="width: 100%; margin: auto"
              title="游园交通预订"
              :visible.sync="dialogFormVisible"
              :modal-append-to-body="false"
            >
              <el-form
                :model="vehicleForm"
                :rules="rules"
                ref="vehicleForm"
                label-width="100px"
                :show-message="true"
              >
                <el-form-item type="success" label="入园日期" required>
                  <el-form-item prop="date">
                    <el-date-picker
                      type="date"
                      placeholder="选择日期"
                      v-model="vehicleForm.date"
                      style="width: 50%"
                      :picker-options="pickerOptions"
                    ></el-date-picker>
                  </el-form-item>
                </el-form-item>
                <el-form-item label="游园交通" prop="value">
                  <el-radio-group v-model="vehicleForm.value">
                    <el-row style="font-size: 16px; width: auto; margin: 5px">
                      <el-radio label="环园小火车"></el-radio>
                      <el-radio label="空中缆车"></el-radio>
                      <el-radio label="观光马车"></el-radio>
                    </el-row>
                  </el-radio-group>
                </el-form-item>
                <el-form-item label="购票类型" prop="type" required>
                  <el-radio-group
                    v-model="vehicleForm.type"
                    text-color="#fff"
                    fill="#a6ce39"
                  >
                    <el-radio-button label="全价票"></el-radio-button>
                    <el-radio-button label="优惠票"></el-radio-button>
                  </el-radio-group>
                </el-form-item>
                <span
                  style="
                    font-weight: bold;
                    font-size: 24px;
                    float: right;
                    margin: -10px 20px;
                  "
                  >票价:{{
                    (vehicleForm.price = howMuch(
                      vehicleForm.type,
                      vehicleForm.value
                    ))
                  }}元</span
                >
              </el-form>
              <div slot="footer" class="dialog-footer">
                <el-button
                  class="button2"
                  type="success"
                  @click="resetForm('vehicleForm')"
                  >清 空</el-button
                >
                <el-button @click="submitForm('vehicleForm')">确 定</el-button>
                <el-button
                  class="button2"
                  type="success"
                  @click="
                    [resetForm('vehicleForm'), (dialogFormVisible = false)]
                  "
                  >取 消</el-button
                >
              </div>
            </el-dialog>
          </div>
        </el-row>
        <div
          style="
            font-weight: bold;
            text-align: left;
            display: block;
            margin-top: 20px;
            margin-left: 20px;
          "
        >
          <h2>注意事项:</h2>
        </div>
        <div style="text-align: justify; display: block; margin-left: 20px">
          <li>
            适合1.2米及以上宾客参玩年龄在10岁（含）以下的儿童参玩时需成人陪同，体重大于158公斤的宾客禁止参玩
          </li>
          <li>高血压/心脑血管系统疾病患者；颈椎病/腰、背疾病/近期手术者</li>
          <li>孕妇、可能因参玩本设施而导致身体病症恶化者禁止参玩</li>
          <li>游客都应有独自能力参玩，并且能自行站立</li>
          <li>体验时请勿饮食或吸烟</li>
          <li>请勿携带尖锐、容易松脱物品参玩</li>
          <li>体验过程中，严禁奔跑、打闹及跳跃</li>
        </div>
      </el-card>
    </el-main>
    <el-header><span>园区地图</span></el-header>
    <el-main>
      <el-card class="mainCard">
        <div
          style="
            font-size: 18px;
            text-align: center;
            padding: 10px;
            color: #a6ce39;
          "
        >
          (<i class="el-icon-zoom-in"></i>点击查看大图细节)
        </div>
        <div class="demo-image__preview">
          <el-image class="map" :src="mapS" :preview-src-list="mapL">
          </el-image>
        </div>
      </el-card>
    </el-main>
  </div>
</template>

<script>
import { getVT, postVT } from "@/api/VT";
export default {
  created() {
    getVT({
      ticket_type: "全价票",
      vehicle_category: "环园小火车",
    })
      .then((response) => {
        this.p1 = response.data[0].price;
      })
      .catch(() => {});
    getVT({
      ticket_type: "全价票",
      vehicle_category: "空中缆车",
    })
      .then((response) => {
        this.p2 = response.data[0].price;
      })
      .catch(() => {});
    getVT({
      ticket_type: "全价票",
      vehicle_category: "观光马车",
    })
      .then((response) => {
        this.p3 = response.data[0].price;
      })
      .catch(() => {});
  },
  data() {
    return {
      p1: null,
      p2: null,
      p3: null,
      mapS: "https://cdn.chimelong.com/upload/d646304b7be5eff5/371f7fd5588ed16c.jpg",
      mapL: [
        "https://cdn.chimelong.com/upload/d646304b7be5eff5/371f7fd5588ed16c.jpg",
      ],
      iV3: require("../picture/introV3.jpg"),

      dialogFormVisible: false,
      valid: true,
      vehicleForm: {
        id: "",
        value: "",
        price: "",
        type: "",
        date: "",
        temp: "",
      },
      rules: {
        date: [{ required: true, message: "请选择入园日期", trigger: "blur" }],
        value: [
          { required: true, message: "请选择游园交通工具", trigger: "blur" },
        ],
        type: [{ required: true, message: "请选择票种", trigger: "blur" }],
      },
      pickerOptions: {
        disabledDate(time) {
          return time.getTime() < Date.now();
        },
      },
    };
  },
  methods: {
    get(typeT, valueT) {
      getVT({
        ticket_type: typeT,
        vehicle_category: valueT,
      })
        .then((response) => {
          this.vehicleData = response.data;
          this.check();
        })
        .catch(() => {});
    },
    post() {
      postVT({
        tour_ID: localStorage.getItem("ID"), //////////////////////////localStorage.getItem("ID"),
        vehicle_category: this.vehicleForm.value,
        price: this.vehicleForm.price,
        ticket_type: this.vehicleForm.type,
        date: this.vehicleForm.date,
      })
        .then((response) => {
          this.vehicleForm.ID = response.data.id;
          this.$alert(
            "预定成功！您的单号是：" +
              this.vehicleForm.ID +
              "。请凭此单号，持身份原证及其他证件到园区正门售票处付费取票！"
          );
        })
        .catch(() => {});
    },
    //提交表单
    gotoLogin() {
      this.$router.push("/Login");
    },
    submitForm(formname) {
      this.$refs[formname].validate((valid) => {
        if (valid) {
          var iflogin = localStorage.getItem("zmsToken");

          if (iflogin) {
            this.post();
            this.resetForm("vehicleForm");
            this.dialogFormVisible = false;
          } else {
            this.$alert("请先进行登录", "提示", {
              confirmButtonText: "确定",
              callback: () => {
                this.gotoLogin();
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
    check() {
      const h = this.$createElement;
      this.$msgbox({
        title: "项目说明",
        message: h("p", null, [
          h(
            "span",
            { style: "font-weight: bold;color:#ff5353;font-size: 16px" },
            ["费用：￥", this.vehicleData[0].price, "元/人"]
          ),
          h("p", null, [
            "费用包含：同济大学附属动物园",
            this.vehicleData[0].vehicleCategory,
            "一人次。",
          ]),
          h("p", null, "有效期限：入园日当天。"),
          h("p", null, [
            "年龄限制：",
            this.vehicleData[0].ageLimit,
            "岁以上。",
          ]),
          h("p", null, [
            "体重限制：",
            this.vehicleData[0].weightLimit,
            "kg以下。",
          ]),
          h("p", null, [
            "预计乘坐时长：大约",
            this.vehicleData[0].rentalDuration,
            "小时。",
          ]),
          h("p", null, [
            "费用包含人身意外险：",
            this.vehicleData[0].deposit,
            "万元。",
          ]),
        ]),
        showConfirmButton: false,
      });
    },
    howMuch(type, value) {
      if (type == "全价票") {
        if (value == "环园小火车") return this.p1;
        else if (value == "空中缆车") return this.p2;
        else if (value == "观光马车") return this.p3;
        else return 0;
      } else if (type == "优惠票") {
        if (value == "环园小火车") return this.p1 * 0.8;
        else if (value == "空中缆车") return this.p2 * 0.8;
        else if (value == "观光马车") return this.p3 * 0.8;
        else return 0;
      } else return 0;
    },
  },
};
</script>

<style scoped lang="scss">
.vechiclePage {
  display: block;
  padding: 0px;
  background-color: transparent;
  background-size: 100% 30%;
  background-image: url("https://cdn.chimelong.com/assets/images/pic.123eeaa.png");
  background-repeat: no-repeat;
  background-position: center bottom;
}
.icon {
  width: 18px;
  height: 18px;
  margin-bottom: -2px;
}
.el-header {
  background-color: #f6faeb00;
  text-align: center;
  line-height: 120px;
  font-size: 28px;
  z-index: 1;
}
.el-main-style {
  position: relative;
  margin-top: -20px;
  background-color: #f6faeb;
}
.el-card {
  position: relative;
  width: 95%;
  height: auto;
  border-radius: 20px;
}
.Cards {
  display: block;
  margin: 5px 0px 25px 0px;
  background: #fff;
}
.mainCard {
  position: relative;
  display: block;
  margin-top: 30px;
  margin-left: auto;
  margin-right: auto;
  background-color: #f6faeb;
  border-radius: 20px;
  width: 90%;
}

.button {
  position: relative;
  bottom: 5px;
  margin: 20px;
  background-color: #a6ce39;
  font-size: 14px;
  color: #fff;
}
.button2 {
  background-color: #a6ce39;
  font-size: 14px;
  color: #fff;
}
.link {
  position: relative;
  display: block;
  margin-left: auto;
  margin-right: auto;
  margin-top: 5px;
  color: #a6ce39;
  font-size: 14px;
}
.introImg {
  width: 90%;
  height: 200px;
  border-radius: 10px;
  display: block;
  margin: auto;
}
.map {
  width: 50vw;
  height: 100vh;
  padding: 20px 0;
  display: block;
  margin-right: auto;
  margin-left: auto;
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