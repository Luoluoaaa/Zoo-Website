<template>
  <div class="AdmissionT admissionPage">
    <el-container class="consumeTabs">
      <el-aside width="282px">
        <el-card class="box-card">
          <div class="box-item"><h2>说明:</h2></div>
          <div class="box-item" style=" text-align: justify;">①“免票”对象：身高未达1.0米的小童 (1名成人仅限携带1名免票小童入园)</div>
          <div class="box-item" style=" text-align: justify;">②2021年公园票类特定日和平日定义：
            <p><li>特定日：元旦（1月1日至3日）、春节（2月11至17日）、清明（4月3日至5日）、五一劳动节（5月1日至5月5日）、端午节（6月12日至14日）、暑期（7月1日至8月31日）、中秋节（9月19日至21日）以及国庆节（10月1日至7日）
            所有的周末（周六、周日）及各园区的特别主题活动日。<br></li>
            【如国家法定假日及调休后连休日的具体日期有变动则另行调整。】</p>
            <p><li>平日： 除以上定义为“特定日”具体日期之外的所有日子。</li></p></div>
          <div class="box-item" style=" text-align: justify;">③入园方式：<br>1、为提升游客游玩体验，确保大家购票权益，实现安全有序快速进园，TJ Zoo已实行刷有效内地居民二代身份证原件入园措施；游客需成功进行入园预约后在预约时间内，携带与订单匹配的有效居民二代身份证原件，人、证合一验证通过方可入园游玩；请确保预订时填写游玩人/使用人的证件资料准确、真实、完整，如因所提交信息资料不实、错误所造成无法验证使用、入园或任何损失的，均由用户本人承担。
          <b>*儿童游客请填写同行的成人游客证件预订，并与该成人游客一起入园。</b>
<br>2、如您所持身份证件为非内地居民二代身份证（例如持港澳居民居住证、台胞证、护照、回乡证等），如需购买或取票入园/观演，请持本人有效身份证件原件，当天前往TJ园区/马戏剧院售票处专窗购买或取票，取票后凭票及对应证件验证入园；
<br>3、如预订包括但不限于会员积分兑换、会员专属权益及限购类产品等特殊产品，须持与订单匹配的有效身份证件原件进行人证相符验证；人、票、证三者合一验证入园；
<br>4、如遇游玩当天因证件漏带、丢失、损坏或其他情况导致无法验票的游客，请持预订时填写的带有照片和身份证号码的其他证件，如临时身份证、驾照、社保卡等，在相应公园或马戏售票处进行人证相符验证取票。</div>
        </el-card>
      </el-aside>
      <el-container>
        <div class="conPage">
          <el-header><span>全部门票</span></el-header>
          <el-main>
            <el-row>
              <div class="Cards">
                <el-col :span="8" justify="space-around">
                  <el-card class="miniCard">
                    <div class="spanLine"></div>
                    <div
                      style="padding: 10px; font-size: 18px; text-align: center"
                    >
                      <span>全价票</span>
                    </div>
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
                      <el-button class="button1" type="success" @click="dialogFormVisible1=true" round><i
                          class="el-icon-price-tag"
                          style="font-size: 16px"></i>立即预订</el-button>                             
                    </el-row>
                  </el-card>
                </el-col>
                <el-col :span="8" justify="space-around">
                  <el-card class="miniCard">
                    <div class="spanLine"></div>
                    <div
                      style="padding: 10px; font-size: 18px; text-align: center"
                    >
                      <span>儿童票</span>
                    </div>
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
                        >￥{{ price[1] }}元/人</span
                      >
                    </div>
                    <el-row type="flex" justify="center">
                      <el-button class="button1" type="success" @click="dialogFormVisible1=true" round
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
                  <el-card class="miniCard">
                    <div class="spanLine"></div>
                    <div
                      style="padding: 10px; font-size: 18px; text-align: center"
                    >
                      <span>长者票</span>
                    </div>
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
                        >￥{{ price[2]  }}元/人</span
                      >
                    </div>
                    <el-row type="flex" justify="center">
                      <el-button class="button1" type="success" @click="dialogFormVisible1=true" round
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
                  <el-card class="miniCard">
                    <div class="spanLine"></div>
                    <div
                      style="padding: 10px; font-size: 18px; text-align: center"
                    >
                      <span>优待票</span>
                    </div>
                    <el-button class="link" type="text" @click="check4"
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
                        >￥{{ price[3]}}元/人</span
                      >
                    </div>
                    <el-row type="flex" justify="center">
                      <el-button class="button1" type="success" @click="dialogFormVisible1=true" round
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
                  <el-card class="miniCard">
                    <div class="spanLine"></div>
                    <div
                      style="padding: 10px; font-size: 18px; text-align: center"
                    >
                      <span>学生票</span>
                    </div>
                    <el-button class="link" type="text" @click="check5"
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
                        >￥{{ price[4]}}元/人</span
                      >
                    </div>
                    <el-row type="flex" justify="center">
                      <el-button class="button1" type="success" @click="dialogFormVisible1=true" round
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
                  <el-card class="miniCard">
                    <div class="spanLine"></div>
                    <div
                      style="padding: 10px; font-size: 18px; text-align: center"
                    >
                      <span>夜场票</span>
                    </div>
                    <el-button class="link" type="text" @click="check9"
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
                        >￥{{ price[5]}}元/人</span
                      >
                    </div>
                    <el-row type="flex" justify="center">
                      <el-button class="button1" type="success" @click="dialogFormVisible1=true" round
                        ><i
                          class="el-icon-price-tag"
                          style="font-size: 16px"
                        ></i
                        >立即预订</el-button
                      >
                    </el-row>
                  </el-card>
                </el-col>

                                      <el-dialog style="width: 80%;margin:auto;" title="门票预订" :visible.sync="dialogFormVisible1" >
                                          <el-form  :model="admissionForm" :rules="rules" ref="admissionForm" label-width="100px" :show-message="true">
                                              <el-form-item type="success" label="入园日期" required>
                                                  <el-form-item prop="date">
                                                    <el-date-picker type="date" placeholder="选择日期" v-model="admissionForm.date" style="width: 50%;":picker-options="pickerOptions"></el-date-picker>
                                                  </el-form-item>
                                              </el-form-item>
                                              <el-form-item  label="门票类型" prop="value">
                                                <el-radio-group v-model="admissionForm.value">
                                                  <el-row  style="font-size:16px;width: auto;margin:5px">
                                                  <el-radio label="0">全价票</el-radio>
                                                  <el-radio label="1">儿童票</el-radio>
                                                  <el-radio label="2">长者票</el-radio>
                                                  </el-row>
                                                  <el-row  style="font-size:16px;width: auto;margin:5px">
                                                  <el-radio label="3">优待票</el-radio>
                                                  <el-radio label="4">学生票</el-radio>
                                                  <el-radio label="5">夜场票</el-radio>
                                                  </el-row>
                                                </el-radio-group>
                                              </el-form-item>
                                              <span style= "font-weight: bold;font-size: 24px;float:right;margin:-10px 20px" >票价:{{price[admissionForm.value]}}元</span>
                                            </el-form>
                                          <div slot="footer" class="dialog-footer">
                                            <el-button class="button2" type="success"@click="resetForm('admissionForm')">清 空</el-button>
                                            <el-button  @click="submitForm('admissionForm')"  style="color:grey">确 定</el-button>
                                            <el-button class="button2" type="success"@click="[resetForm('admissionForm'),dialogFormVisible1 = false]">取 消</el-button>
                                          </div>
                                        </el-dialog>  

              </div>
            </el-row>
          </el-main>
          <el-header><span>优惠套票</span></el-header>
          <el-main>
            <el-row>
              <div class="Cards">
                <el-col :span="8" justify="space-around">
                  <el-card class="miniCard">
                    <div class="spanLine"></div>
                    <div
                      style="padding: 10px; font-size: 18px; text-align: center" 
                    >
                      <span>畅享套票（全价）</span>
                    </div>
                    <el-button class="link" type="text" @click="check6"
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
                        >￥{{ price[6]}}元/人</span
                      >
                    </div>
                    <el-row type="flex" justify="center">
                      <el-button class="button1" type="success"  @click="dialogFormVisible2=true"round
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
                  <el-card class="miniCard">
                    <div class="spanLine"></div>
                    <div
                      style="padding: 10px; font-size: 18px; text-align: center"
                    >
                      <span>畅享套票（优惠）</span>
                    </div>
                    <el-button class="link" type="text" @click="check7"
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
                        >￥{{ price[7]}}元/人</span
                      >
                    </div>
                    <el-row type="flex" justify="center">
                      <el-button class="button1" type="success" @click="dialogFormVisible2=true" round
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
                  <el-card class="miniCard">
                    <div class="spanLine"></div>
                    <div
                      style="padding: 10px; font-size: 18px; text-align: center"
                    >
                      <span>畅享套票（学生）</span>
                    </div>
                    <el-button class="link" type="text" @click="check8"
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
                        >￥{{ price[8]  }}元/人</span
                      >
                    </div>
                    <el-row type="flex" justify="center">
                      <el-button class="button1" type="success" @click="dialogFormVisible2=true" round
                        ><i
                          class="el-icon-price-tag"
                          style="font-size: 16px"
                        ></i
                        >立即预订</el-button
                      >
                    </el-row>
                  </el-card>
                </el-col>
              </div>
            </el-row>
                                        <el-dialog style="width: 100%;margin:auto;" title="套票预订" :visible.sync="dialogFormVisible2" >
                                          <el-form  :model="admissionForm" :rules="rules" ref="admissionForm" label-width="100px" :show-message="true">
                                              <el-form-item type="success" label="入园日期" required>
                                                  <el-form-item prop="date">
                                                    <el-date-picker type="date" placeholder="选择日期" v-model="admissionForm.date" style="width: 50%;":picker-options="pickerOptions"></el-date-picker>
                                                  </el-form-item>
                                              </el-form-item>
                                              <el-form-item  label="套票类型" prop="value">
                                                <el-radio-group v-model="admissionForm.value">
                                                  <el-row  style="font-size:16px;width: auto;margin:5px">
                                                  <el-radio label="6">畅享套票（全价）</el-radio>
                                                  <el-radio label="7">畅享套票（优惠）</el-radio>
                                                  <el-radio label="8">畅享套票（学生）</el-radio>
                                                  </el-row>
                                                </el-radio-group>
                                              </el-form-item>
                                              <span style= "font-weight: bold;font-size: 24px;float:right;margin:-10px 20px" >票价:{{price[admissionForm.value]}}元</span>
                                            </el-form>
                                          <div slot="footer" class="dialog-footer">
                                            <el-button class="button2" type="success"@click="resetForm('admissionForm')">清 空</el-button>
                                            <el-button  @click="submitForm('admissionForm')">确 定</el-button>
                                            <el-button class="button2" type="success"@click="[resetForm('admissionForm'),dialogFormVisible2 = false]">取 消</el-button>
                                          </div>
                                        </el-dialog>  
          </el-main>
          <el-header><span>VIP特惠说明</span></el-header>
          <el-main>
            <el-row>
              <div style="padding: 20px; font-size: 18px; text-align: center">
                <img
                  src="../picture/vipchart.png"
                  style="
                    display: block;
                    margin-left: auto;
                    margin-right: auto;
                    width: 70%;
                    height: 70%;
                  "
                />
              </div>
            </el-row>
          </el-main>
        </div>
      </el-container>
    </el-container>


  </div>
</template>

<script>
export default {
  data() {
    return {
      price: [250,250*0.7,250*0.7,250*0.7,250*0.8,250*0.4,520,488,499],
      startTime:[8,8,8,8,8,18],
      endTime:[17,17,17,17,17,22],
      ID:1234567,
      dialogFormVisible1: false,
      dialogFormVisible2: false,
      valid:true,
        admissionForm: {
          date: '',
          type: '',
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
           this.resetForm('admissionForm');
            this.dialogFormVisible1 =false;
            this.dialogFormVisible2 =false;
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
      });},
      resetForm(formName) {
        this.$refs[formName].resetFields();
      },
    check1() {
      const h = this.$createElement;
      this.$msgbox({
        title: "产品说明",
        message: h("p", null, [
          h("span",{ style: "font-weight: bold;color:#ff5353;font-size: 16px" }, ["费用：￥",this.price[0],"人/元"]),
          h("p",null,"费用包含：同济大学附属动物园门票一张。"),
          h("p",null,"有效期限：指定入园日当天可入园一次。"),
          h("p",null,["入园时间：",this.startTime[0],"至",this.endTime[0]]),
        ]),
        showConfirmButton: false,
      });
    },
    check2() {
      const h = this.$createElement;
      this.$msgbox({
        title: "产品说明",
        message: h("p", null, [
          h("span",{ style: "font-weight: bold;color:#ff5353;font-size: 16px" }, ["费用：￥",this.price[1],"人/元"]),
          h("p",null,"费用包含：同济大学附属动物园儿童票一张。"),
          h("p",null,"有效期限：指定入园日当天可入园一次。"),
          h("p",null,["入园时间：",this.startTime[1],"至",this.endTime[1]]),
          h("p",{ style: "font-weight: bold;"},"适用条件：身高达到1.0米但未达1.5米。"),
        ]),
        showConfirmButton: false,
      });
    },
    check3() {
      const h = this.$createElement;
      this.$msgbox({
        title: "产品说明",
        message: h("p", null, [
          h("span",{ style: "font-weight: bold;color:#ff5353;font-size: 16px" }, ["费用：￥",this.price[2],"人/元"]),
          h("p",null,"费用包含：同济大学附属动物园长者票一张。"),
          h("p",null,"有效期限：指定入园日当天可入园一次。"),
          h("p",null,["入园时间：",this.startTime[2],"至",this.endTime[2]]),
          h("p",{ style: "font-weight: bold;"},"适用条件：年满65周岁人士，长者凭居民身份证验票入园；（长者购票可由家人代为操作，现场设有人工服务窗口换取门票）"),
        ]),
        showConfirmButton: false,
      });
    },
    check4(){
      const h = this.$createElement;
      this.$msgbox({
        title: "产品说明",
        message: h("p", null, [
          h("span",{ style: "font-weight: bold;color:#ff5353;font-size: 16px" }, ["费用：￥",this.price[3],"人/元"]),
          h("p",null,"费用包含：同济大学附属动物园优待票一张。"),
          h("p",null,"有效期限：指定入园日当天可入园一次。"),
          h("p",null,["入园时间：",this.startTime[3],"至",this.endTime[3]]),
          h("p",{ style: "font-weight: bold;"},"适用条件：持有国家民政部、残联、部队核发的有效残疾军人证及残疾证之人士，可购买优待票，凭有效残疾军人证/残疾证验票入园。"),
        ]),
        showConfirmButton: false,
      });
    },
    check5() {
      const h = this.$createElement;
      this.$msgbox({
        title: "产品说明",
        message: h("p", null, [
          h("span",{ style: "font-weight: bold;color:#ff5353;font-size: 16px" }, ["费用：￥",this.price[4],"人/元"]),
          h("p",null,"费用包含：同济大学附属动物园学生票一张。"),
          h("p",null,"有效期限：指定入园日当天可入园一次。"),
          h("p",null,["入园时间：",this.startTime[4],"至",this.endTime[4]]),
          h("p",{ style: "font-weight: bold;"},"适用条件：1、身高达到1.5米及以上的未成年人；2、持有本人有效学生证件；3、2021年应届中高考毕业生也适用该票种，购票中高考生需本人持年度准考证或毕业证验证入园。"),
        ]),
        showConfirmButton: false,
      });
    },    
    check9() {
      const h = this.$createElement;
      this.$msgbox({
        title: "产品说明",
        message: h("p", null, [
          h("span",{ style: "font-weight: bold;color:#ff5353;font-size: 16px" }, ["费用：￥",this.price[5],"人/元"]),
          h("p",null,"费用包含：同济大学附属动物园夜场票一张。"),
          h("p",null,"有效期限：指定入园日当天指定时间段可入园一次。"),
          h("p",null,["入园时间：",this.startTime[5],"至",this.endTime[5]]),
        ]),
        showConfirmButton: false,
      });
    },
    check6(){
      const h = this.$createElement;
      this.$msgbox({
        title: "产品说明",
        message: h("p", null, [
          h("span",{ style: "font-weight: bold;color:#ff5353;font-size: 16px" }, ["费用：￥",this.price[6],"人/元"]),
          h("p",null,"费用包含：同济大学附属动物园门票+马戏演出票。"),
          h("p",null,"有效期限：指定入园日当天使用。"),
        ]),
        showConfirmButton: false,
      });
    },
    check7(){
      const h = this.$createElement;
      this.$msgbox({
        title: "产品说明",
        message: h("p", null, [
          h("span",{ style: "font-weight: bold;color:#ff5353;font-size: 16px" }, ["费用：￥",this.price[7],"人/元"]),
          h("p",null,"费用包含：同济大学附属动物园门票+马戏演出票。"),
          h("p",null,"有效期限：指定入园日当天使用。"),
          h("p",{ style: "font-weight: bold;"},"适用条件：可购买儿童/长者/优待票的优惠群体。"),
        ]),
        showConfirmButton: false,
      });
    },
    check8(){
      const h = this.$createElement;
      this.$msgbox({
        title: "产品说明",
        message: h("p", null, [
          h("span",{ style: "font-weight: bold;color:#ff5353;font-size: 16px" }, ["费用：￥",this.price[8]*0.9,"人/元"]),
          h("p",null,"费用包含：同济大学附属动物园优惠门票+马戏演出票。"),
          h("p",null,"有效期限：指定入园日当天使用。"),
          h("p",{ style: "font-weight: bold;"},"适用条件：1、身高达到1.5米及以上的未成年人；2、持有本人有效学生证件；3、2021年应届中高考毕业生也适用该票种，购票中高考生需本人持年度准考证或毕业证验证入园。"),
        ]),
        showConfirmButton: false,
      });
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
  background: transparent;
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
.admissionPage{
  display: block;
  padding: 0px;
  background-color: transparent;
  background-size:100% 50%;
  background-image: url("https://cdn.chimelong.com/assets/images/pic.6e73287.png");
  background-repeat: no-repeat;
  background-position: center bottom;
}
.conPage {
  display: block;
  padding: 0px;
  margin-left: 5px;
  background: #f6faeb;
  border-radius: 20px;
}
.el-aside{
  background-color: transparent;
  color: #333;
  text-align: center;
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
.el-card {
  position: relative;
  width: 100%;
  height: 200px;
  border-radius: 20px;
  display: block;
  margin-left: auto;
  margin-right: auto;
}
.Cards {
  display: block;
  background: #fff;
}
.miniCard{
   padding: 0px 0px 30px 0px;
   margin:10px 5px 10px 5px;
}
.spanLine {
  position: absolute;
  top: 50%;
  left: 0;
  width: 100%;
  display: block;
  border-bottom: 2px dashed rgba(0, 0, 0, 0.1);
}
.button1 {
  position: relative;
  top: 5px;
  background-color: #a6ce39;
  font-size: 14px;
  color: #fff;
}
.button2 {
  background-color: #a6ce39;
  font-size: 14px;
  color: #fff;
}
.confirmButton{
  background-color: #a6ce39 !important;
  color: #fff !important;
  font-size: 10px !important;
}
.link {
  position: relative;
  padding: 20px 0px 10px;
  bottom: 15px;
  display: block;
  margin-left: auto;
  margin-right: auto;
  color: #a6ce39;
  font-size: 14px;
}
// .el-aside{
//   position: sticky;
//   top: 0;
// }
.box-item {
  padding: 14px 0;
  text-align: left;
}
.box-card {
  position: sticky;
  top: 0px;
  width: 100%;
  height:auto;
  background: #f6faeb;
}

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
.conPage{
  display: block;
  padding: 0px;
  margin-left:10px;
  background: #f6faeb;
  border-radius: 20px;
}

</style>
