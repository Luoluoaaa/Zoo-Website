
<template>
<div class="VehicleT vechiclePage">
           <el-header><span>特色游园</span></el-header>
          <el-main>
            <el-card class="mainCard">
            <el-row>
              <div class="Cards">
                <el-col :span="8" justify="space-around">
                  <el-card :body-style="{ padding: '0px' }">
                    <div
                      style="padding: 20px; font-size: 18px; text-align: center">
                      <span>游园小火车</span>
                    </div>
                    <img src="https://cdn.chimelong.com/upload/eaa5ec555452a0a4/266e8bad2e088404.jpg" class="introImg"/>
                    <el-button class="link" type="text" @click="check1"
                      >查看详情></el-button
                    >
                    <div
                      style="
                        padding: 0px 0 0;
                        font-size: 20px;
                        text-align: center;
                      "
                    >
                      <span style="color: #ff5353"
                        >￥{{ price[0] }}元/人</span
                      >
                    </div>
                    <el-row type="flex" justify="center">
                      <el-button class="button" type="success" @click="dialogFormVisible=true" round 
                        ><i
                          class="el-icon-price-tag"
                          style="font-size: 16px"
                        ></i
                        >立即预订</el-button
                      >
                    </el-row>
                  </el-card>
                </el-col>
                <el-col :span="8" justify="space-around">
                  <el-card :body-style="{ padding: '0px' }">
                    <div
                      style="padding: 20px; font-size: 18px; text-align: center"
                    >
                      <span>空中观光缆车</span>
                    </div>
                     <img src="https://cdn.chimelong.com/upload/4b26f3741ce67587/af56df792008e445.jpg" class="introImg"/>
                    <el-button class="link" type="text" @click="check2"
                      >查看详情></el-button
                    >
                    <div
                      style="
                        padding: 0px 0 0;
                        font-size: 20px;
                        text-align: center;
                      "
                    >
                      <span style="color: #ff5353"
                        >￥{{price[1] }}元/人</span
                      >
                    </div>
                    <el-row type="flex" justify="center">
                      <el-button class="button" type="success" @click="dialogFormVisible=true" round
                        ><i
                          class="el-icon-price-tag"
                          style="font-size: 16px"
                        ></i
                        >立即预订</el-button
                      >
                    </el-row>
                  </el-card>
                </el-col>
                <el-col :span="8" justify="space-around">
                  <el-card :body-style="{ padding: '0px' }">
                    <div
                      style="padding: 20px; font-size: 18px; text-align: center"
                    >
                      <span>观光马车</span>
                    </div>
                    <img :src="iV3" class="introImg"/>
                    <el-button class="link" type="text" @click="check3"
                      >查看详情></el-button
                    >
                    <div
                      style="
                        padding: 0px 0 0;
                        font-size: 20px;
                        text-align: center;
                      "
                    >
                      <span style="color: #ff5353"
                        >￥{{ price[2] }}元/人</span
                      >
                    </div>
                    <el-row type="flex" justify="center">
                      <el-button class="button" type="success" @click="dialogFormVisible=true" round
                        ><i
                          class="el-icon-price-tag"
                          style="font-size: 16px"
                        ></i
                        >立即预订</el-button
                      >
                    </el-row>
                  </el-card>
                </el-col>
                                        <el-dialog style="width: 100%;margin:auto;" title="游园交通预订" :visible.sync="dialogFormVisible" :modal-append-to-body="false">
                                          <el-form  :model="vehicleForm" :rules="rules" ref="vehicleForm" label-width="100px" :show-message="true">
                                              <el-form-item type="success" label="入园日期" required>
                                                  <el-form-item prop="date">
                                                    <el-date-picker type="date" placeholder="选择日期" v-model="vehicleForm.date" style="width: 50%;":picker-options="pickerOptions"></el-date-picker>
                                                  </el-form-item>
                                              </el-form-item>
                                              <el-form-item  label="游园交通" prop="value">
                                                <el-radio-group v-model="vehicleForm.value">
                                                  <el-row  style="font-size:16px;width: auto;margin:5px">
                                                  <el-radio label="0">游园小火车</el-radio>
                                                  <el-radio label="1">空中缆车</el-radio>
                                                  <el-radio label="2">观光马车</el-radio>
                                                  </el-row>
                                                </el-radio-group>
                                              </el-form-item>
                                              <span style= "font-weight: bold;font-size: 24px;float:right;margin:-10px 20px" >票价:{{price[vehicleForm.value]}}元</span>
                                            </el-form>
                                          <div slot="footer" class="dialog-footer">
                                            <el-button class="button2" type="success"@click="resetForm('vehicleForm')">清 空</el-button>
                                            <el-button  @click="submitForm('vehicleForm')">确 定</el-button>
                                            <el-button class="button2" type="success"@click="[resetForm('vehicleForm'),dialogFormVisible = false]">取 消</el-button>
                                          </div>
                                        </el-dialog>  
              </div>
            </el-row>
            <div style="font-weight:bold;text-align: left;display:block;margin-top:20px;margin-left:20px;"><h2>注意事项:</h2></div>
          <div style=" text-align: justify;display:block;margin-left:20px;">
            <li>适合1.2米及以上宾客参玩年龄在10岁（含）以下的儿童参玩时需成人陪同，体重大于158公斤的宾客禁止参玩</li>
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
             <div style="font-size: 18px;text-align: center;padding: 10px;color:#a6ce39"> (<i class="el-icon-zoom-in" ></i>点击查看大图细节)</div>
        <div class="demo-image__preview">
        <el-image 
         class="map"
         :src="mapS" 
         :preview-src-list="mapL">
        </el-image>
        </div>
        </el-card>
        </el-main>
        
</ul>
</div>
</template>

<script>
export default {
  data() {
    return {
       price:[60,100,150],
       ageLimit:[3,3,5],
       weightLimit:[150,150,150],
       deposit:[5,5,10],
       time:[1,1,0.5],
       mapS:"https://cdn.chimelong.com/upload/d646304b7be5eff5/371f7fd5588ed16c.jpg",
       mapL:["https://cdn.chimelong.com/upload/d646304b7be5eff5/371f7fd5588ed16c.jpg"],
       iV3:require("../picture/introV3.jpg"),

      ID:1234567,
      dialogFormVisible: false,
      valid:true,
        vehicleForm: {
          date: '',
          value:'',
        },
        rules: {
          date: [
             { type: 'date', required: true, message: '请选择入园日期', trigger: 'blur' }
          ],
          value: [
            { required: true, message: '请选择一种票种',trigger: 'blur'}
          ],
        },
        pickerOptions: {
          disabledDate(time) {
            return time.getTime() < Date.now();
          },
        }
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
          this.resetForm("vehicleForm");
          this.dialogFormVisible = false;
          alert(
            "预定成功！您的单号是：" +
              this.ID +
              "\n请凭此单号，持身份原证及其他证件到园区正门售票处付费取票！"
          );
          iflogin='';
          }
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
      });
      },
      resetForm(formName) {
        this.$refs[formName].resetFields();
      },
    check1() {
      const h = this.$createElement;
      this.$msgbox({
        title: "项目说明",
        message: h("p", null, [
          h("span",{ style: "font-weight: bold;color:#ff5353;font-size: 16px" }, ["费用：￥",this.price[0],"元/人"]),
          h("p",null,"费用包含：同济大学附属动物园环园小火车一人次。"),
          h("p",null,"有效期限：入园日当天。"),
          h("p",null,["年龄限制：",this.ageLimit[0],"岁以上。"]),
          h("p",null,["体重限制：",this.weightLimit[0],"kg以下。"]),
          h("p",null,["预计乘坐时长：大约",this.time[0],"小时。"]),
          h("p",null,["费用包含人身意外险：",this.deposit[0],"万元。"]),
        ]),
        showConfirmButton: false,
      });
    },
    check2() {
      const h = this.$createElement;
      this.$msgbox({
        title: "产品说明",
        message: h("p", null, [
          h("span",{ style: "font-weight: bold;color:#ff5353;font-size: 16px" }, ["费用：￥",this.price[1],"元/人"]),
          h("p",null,"费用包含：同济大学附属动物园空中缆车一人次。"),
          h("p",null,"有效期限：入园日当天。"),
          h("p",null,["年龄限制：",this.ageLimit[1],"岁以上。"]),
          h("p",null,["体重限制：",this.weightLimit[1],"kg以下。"]),
          h("p",null,["预计乘坐时长：大约",this.time[1],"小时。"]),
          h("p",null,["费用包含人身意外险：",this.deposit[1],"万元。"]),
        ]),
        showConfirmButton: false,
      });
    },
    check3() {
      const h = this.$createElement;
      this.$msgbox({
        title: "产品说明",
        message: h("p", null, [
          h("span",{ style: "font-weight: bold;color:#ff5353;font-size: 16px" }, ["费用：￥",this.price[2],"元/人"]),
          h("p",null,"费用包含：同济大学附属动物园观光马车一人次。"),
          h("p",null,"有效期限：入园日当天。"),
          h("p",null,["年龄限制：",this.ageLimit[2],"岁以上。"]),
          h("p",null,["体重限制：",this.weightLimit[2],"kg以下。"]),
          h("p",null,["预计乘坐时长：大约",this.time[2],"小时。"]),
          h("p",null,["费用包含人身意外险：",this.deposit[2],"万元。"]),
        ]),
        showConfirmButton: false,
      });
    },
    }
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
.mainCard{
  position: relative;
  display: block;
  margin-top: 30px;
  margin-left: auto;
  margin-right: auto;
  background-color: #f6faeb;
  border-radius: 20px;
  width:90%
}

.button {
  position: relative;
  bottom:5px;
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
.map{
  width: 50vw; 
  height: 100vh; 
  padding: 20px 0;
  display:block;
  margin-right:auto;
  margin-left:auto;
}
</style>