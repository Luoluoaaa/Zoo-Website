<template>
<div class="ShowT showpage">
<ul>
  <el-header class="header1"><span>马戏介绍</span></el-header>
  <li class="li1"> 
          <el-card class="card1" :body-style="{ padding: '0px' }">
               <img class="introImg" src="https://cdn.chimelong.com/assets/images/pic-pc.72843be.jpg" />
             <el-row align="middle" >
             <el-col :span="20" justify="space-around">
                <span class="text">
                同济大马戏位于全国AAAAA景区嘉定同济大学附属动物园，拥有实景式马戏舞台，数千万巨资打造极致奢华尖端舞美科技和数亿巨资建造的马戏表演场，能容纳近7000名观众同时观看。全球高规格的舞台设施和主题节目，自然少不了庞大的国际化演艺团队，拥有来自20多个国家，横跨亚洲、欧洲、美洲、非洲共300余名...</span>
             </el-col>
             <el-col :span="4" justify-content="space-around">
                <el-button class="button" type="success" @click="DialogVisible = true" round><i class="el-icon-thumb"
                  style="font-size: 16px"></i>了解更多</el-button>
             </el-col>
            </el-row>
                                            <el-dialog
                                            custom-class="dialog-wrapper"
                                                :visible.sync="DialogVisible"
                                                width="80%"
                                                :modal-append-to-body="false"
                                                center>
                                                <el-row  :gutter="6">
                                                  <el-col :span="12" >
                                                      <el-card class="card4" shadow="hover" :body-style="{ padding: '0px' }"><img class="msbImg" src="https://cdn.chimelong.com/assets/images/pic-3.e65a90d.jpg" alt="">
                                                      <el-row style="font-size: 20px;text-align:center;">马戏好莱坞</el-row>
                                                      </el-card>
                                                  </el-col>
                                                  <el-col :span="6">
                                                      <el-card class="card4" shadow="hover" :body-style="{ padding: '0px' }"><img class="msbImg" src="https://cdn.chimelong.com/assets/images/pic-2.b6ee5da.jpg" alt="">
                                                      <el-row style="font-size: 20px;text-align:center;">魔幻开启</el-row>
                                                      </el-card>
                                                  </el-col>
                                                  <el-col :span="6">
                                                        <el-card class="card4" shadow="hover" :body-style="{ padding: '0px' }"><img class="msbImg" src="https://cdn.chimelong.com/assets/images/pic-1.f16880a.jpg" alt="">
                                                      <el-row style="font-size: 20px;text-align:center;">光影传说</el-row>
                                                      </el-card>
                                                  </el-col>
                                              </el-row>
                                              <el-row  :gutter="6" style="margin-top:px;">
                                                  <el-col :span="6" > 
                                                      <el-card class="card4" shadow="hover" :body-style="{ padding: '0px' }"><img class="msbImg" src="https://cdn.chimelong.com/assets/images/pic-7.a109adb.jpg" alt="">
                                                      <el-row style="font-size: 20px;text-align:center;">魔域仙境</el-row>
                                                      </el-card>
                                                  </el-col>
                                                  <el-col :span="6">
                                                      <el-card class="card4" shadow="hover" :body-style="{ padding: '0px' }"><img class="msbImg" src="https://cdn.chimelong.com/assets/images/pic-6.232201d.jpg" alt="">
                                                      <el-row style="font-size: 20px;text-align:center;">环球飞车</el-row>
                                                      </el-card>
                                                  </el-col>
                                                  <el-col :span="12">
                                                      <el-card class="card4" shadow="hover" :body-style="{ padding: '0px' }"><img class="msbImg" src="https://cdn.chimelong.com/upload/8f1a304b9350d20c/376ca5340eb529b5.jpg" alt="">
                                                      <el-row style="font-size: 20px;text-align:center;">魔幻火轮</el-row>
                                                      </el-card>
                                                  </el-col>
                                              </el-row>
                                          
                                              </el-dialog>
           </el-card>
           </li>
  <li class="li2">
      <el-col :span="8">
        <el-card class="card2">
        <span class="header2">超值预订</span>
        <el-card class="card3" :body-style="{ padding: '0px' }">
          <el-col :span="6" ><span class="blockT">￥{{p1}}元/人</span></el-col>
          <el-col :span="18" class="rela">
                    <div class="spanLine" ></div>
                     <div style="padding: 20px; font-size: 18px; text-align: center">
                      <span>全价票</span></div>
                    <el-row type="flex" justify="center">
                    <el-button class="link" type="text" @click="dialogFormVisible=true"
                      >立即预订>></el-button
                    >
                    </el-row>
          </el-col>
        </el-card>
                <el-card class="card3" :body-style="{ padding: '0px' }">
          <el-col :span="6" ><span class="blockT">￥{{p2}}元/人</span></el-col>
          <el-col :span="18" class="rela">
                    <div class="spanLine" ></div>
                     <div style="padding: 20px; font-size: 18px; text-align: center">
                      <span>儿童/长者/优待票</span></div>
                    <el-row type="flex" justify="center">
                    <el-button class="link" type="text" @click="dialogFormVisible=true"
                      >立即预订>></el-button
                    >
                    </el-row>
          </el-col>
        </el-card>
                <el-card class="card3" :body-style="{ padding: '0px' }">
          <el-col :span="6" ><span class="blockT">￥{{p3}}元/人</span></el-col>
          <el-col :span="18" class="rela">
                    <div class="spanLine" ></div>
                     <div style="padding: 20px; font-size: 18px; text-align: center">
                      <span>学生票</span></div>
                    <el-row type="flex" justify="center">
                    <el-button class="link" type="text" @click="dialogFormVisible=true"
                      >立即预订>></el-button
                    >
                    </el-row>
          </el-col>
        </el-card>
                <el-card class="card3" :body-style="{ padding: '0px' }">
          <el-col :span="6" ><span class="blockT">￥{{p4}}元/人</span></el-col>
          <el-col :span="18" class="rela">
                    <div class="spanLine" ></div>
                     <div style="padding: 20px; font-size: 18px; text-align: center">
                      <span>VIP座票</span></div>
                    <el-row type="flex" justify="center">
                    <el-button class="link" type="text" @click="dialogFormVisible=true"
                      >立即预订>></el-button
                    >
                    </el-row>
          </el-col>
        </el-card>
        </el-card>  
                                        <el-dialog style="width: 100%;margin:auto;" title="套票预订" :visible.sync="dialogFormVisible" :modal-append-to-body="false">
                                          <el-form  :model="showForm" :rules="rules" ref="showForm" label-width="100px" :show-message="true">
                                              <el-form-item style="width: 50%;" label="演出日期" required>
                                                <el-select v-model="showForm.dateID" placeholder="请选择演出日期">
                                                  <el-option
                                                    v-for="item in showData"
                                                    :key="item.showDate"
                                                    :label="item.showDate.substring(0,10)"
                                                    :value="item.showId">
                                                  </el-option>
                                                </el-select>
                                              </el-form-item>
                                              <el-form-item  label="套票类型" prop="value">
                                                <el-radio-group v-model="showForm.value">
                                                  <el-row  style="font-size:16px;width: auto;margin:5px">
                                                  <el-radio label="全价票"></el-radio>
                                                  <el-radio label="优惠票"></el-radio></el-radio>
                                                  <el-radio label="学生票"></el-radio>
                                                  <el-radio label="VIP座票"></el-radio>
                                                  </el-row>
                                                </el-radio-group>
                                              </el-form-item>
                                              <el-form-item  label="演出场数">
                                                <el-radio-group v-model="showForm.num" text-color="#fff" fill="#a6ce39">
                                                  <el-radio-button label=1>第一场</el-radio-button>
                                                  <el-radio-button label=2>第二场</el-radio-button>
                                                </el-radio-group>
                                              </el-form-item>
                                              <span style= "font-weight: bold;font-size: 24px;float:right;margin:-10px 20px" >票价:{{howMuch(showForm.value)}}元</span>
                                            </el-form>
                                          <div slot="footer" class="dialog-footer">
                                            <el-button class="button2" type="success"@click="resetForm('showForm')">清 空</el-button>
                                            <el-button  @click="submitForm('showForm')">确 定</el-button>
                                            <el-button class="button2" type="success"@click="[resetForm('showForm'),dialogFormVisible = false]">取 消</el-button>
                                          </div>
                                        </el-dialog>  
      </el-col>
      <el-col :span="8">
        <el-card class="card2">
        <span class="header2">表演安排</span>
         <el-col :span="6" ><span style="font-size:96px;color:#a6cd39;"><i class="el-icon-time"></i></span></el-col>
        <el-col :span="18"><div style="font-size:30px;color:#a6cd39;  display: block;  padding:25px 20px;"><p>近期剧目：</p><p style="color:#111;">《{{showName}}》</p></div></el-col>
        <img src="https://cdn.chimelong.com/assets/images/pic-5.538ba90.jpg" style="width:100%;  border-radius: 10px;"/>
        <div style="font-size:20px;color:#111;  display: block;  padding:10px 20px;line-height:1.5;"><p style="color:#a6cd39;">演出时间:</p><p style="font-weight:bold;">第一场：{{showStart[0]}}-{{showEnd[0]}}<br>第二场：{{showStart[1]}}-{{showEnd[1]}}</p></div>
        </el-card>
      </el-col> 
      <el-col :span="8">
        <el-card class="card2">
        <span class="header2">剧院地图</span>
        <div class="demo-image__preview">
        <el-image 
         style="width: 100%; height: 100%;padding: 20px 0;"
         :src="mapS" 
         :preview-src-list="mapL">
        </el-image>
        </div>
        <div style="font-size: 18px;text-align: center;padding: 10px;"> (<i class="el-icon-zoom-in" ></i>点击图片 查看大图)</div>
        </el-card>
      </el-col></li>
  <el-footer><span></span></el-footer>
</ul>
</div>
</template>

<script>
import {getSTD,getSD,postST} from "@/api/ST";
export default {
  created(){
      getSTD({
        Ticket_type:'普通票',
      })
      .then(response=>{
        this.p1=(response.data)[0].price;
      })
      .catch(err=>{
        console.log('error')
      });
      getSTD({
        Ticket_type:'优惠票',
      })
      .then(response=>{
        this.p2=(response.data)[0].price;
      })
      .catch(err=>{
        console.log('error')
      });
      getSTD({
        Ticket_type:'学生票',
      })
      .then(response=>{
        this.p3=(response.data)[0].price;
      })
      .catch(err=>{
        console.log('error')
      });
      getSTD({
        Ticket_type:'VIP座票',
      })
      .then(response=>{
        this.p4=(response.data)[0].price;
      })
      .catch(err=>{
        console.log('error')
      });
      //
      getSD({
        show_name:this.showName,
        start_time:this.showStart[1],
       })
       .then(response=>{
         this.showData=response.data;
         for(let i=0;i<this.showData.length;i++){
         this.showData[i].showDate.substring(0,10);
         }
      })
      .catch(err=>{
        console.log('error')
      })  
  },
  data() {
    return {
      p1:null,
      p2:null,
      p3:null,
      p4:null,
      showData:[],
      //  showPrice:[450,450*0.7,450*0.8,450*1.2],
      showName:"马戏好莱坞",
       showStart:["14:00","17:00"],
       showEnd:["18:00","21:00"], 
       mapS:"https://cdn.chimelong.com/upload/4bd565ac4c4ab924/cce70c70e0f9b53a.jpg",
       mapL:["https://cdn.chimelong.com/upload/cfd283954d3ca65f/fb31a0b9dd0a54a6.jpg"],

      
      dialogFormVisible: false,
      DialogVisible: false,
      valid:true,
        showForm: {
          ID:'',
          dateID: '',
          value:'',
          num:'',
        },
        rules: {
          date: [
             { type: 'date', required: true, message: '请选择入园日期', trigger: 'blur' }
          ],
          value: [
            { required: true, message: '请选择一种票种',trigger: 'blur'}
          ],
        },
    };
  },
  computed: {},
  methods: {
    post(){
      postST({
        ID:localStorage.getItem("ID"),       //////////////////////////localStorage.getItem("ID"),
        show_id:this.showForm.dateID,
        Ticket_type:this.showForm.value,
      })
      .then((response)=>{        
        console.log(response.data);
        this.showForm.ID=response.data.id;
        this.$alert('预定成功！您的单号是：'+this.showForm.ID+'。请凭此单号，持身份原证及其他证件到园区正门售票处付费取票！');
      })
      .catch(function(error){
        console.log(error);
      });
    },
    gotoLogin(){
            this.$router.push('/Login')
          },
    submitForm(formname) {
      this.$refs[formname].validate((valid) => {
        if (valid) {
          var iflogin = localStorage.getItem("zmsToken");
          console.log(iflogin);
            if(iflogin){
            this.post();
            this.resetForm('showForm');
            this.dialogFormVisible =false;}
          else{
              this.$alert('请先进行登录', '提示', {
              confirmButtonText: '确定',
              callback: action => {
              this.gotoLogin();
              }
              });
            }
          }
          else {
            console.log('error submit!!');
            return false;
          }
      });},
      resetForm(formName) {
        this.$refs[formName].resetFields();
      },
      howMuch(value){
        if(value=='全价票')
          return this.p1;
        else if(value=='优惠票')
          return this.p2;
        else if(value=='学生票')
          return this.p3;
        else if(value=='VIP座票')
          return this.p4;          
        else
          return 0;
    },
    open() {
      const h = this.$createElement;
      this.$msgbox({
        title: "精彩演出",
        message: h('div', null, [
          h("span",{ style: "font-weight: bold;color:#ff5353;font-size: 16px" }, ["费用：￥",,"人/元"]),
          h('img',{style:"introImg"},"https://cdn.chimelong.com/assets/images/pic-pc.72843be.jpg" ),
          h("p",null,"费用包含：同济大学附属动物园学生票一张。"),
          h("p",null,"有效期限：指定入园日当天可入园一次。"),
          h("p",null,"入园时间：08:00 至 18:00"),
          h("p",{ style: "font-weight: bold;text-align: justify;"},"适用条件：1、身高达到1.5米及以上的未成年人；2、持有本人有效学生证件；3、2021年应届中高考毕业生也适用该票种，购票中高考生需本人持年度准考证或毕业证验证入园。"),
        ]),
        dangerouslyUseHTMLString: true,
        showConfirmButton: false,
        center:true,
      });
      }
  },
};
</script>

<style scoped lang="scss">

.showpage {
  display: block;
  padding: 0px;
  background-color: transparent;
  background-size:100% 50%;
  background-image: url("https://cdn.chimelong.com/assets/images/pic.b0b9598.png");
  background-repeat: no-repeat;
  background-position: center bottom;
}
.header1 {
  background-color: transparent;
  text-align: center;
  margin-top:20px;
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
.card3{
  position: relative;
  margin-top: 10px;
  width: 350px;
  height: 100px;
  border-radius: 20px;
  display: block;
  margin-left: auto;
  margin-right: auto;
}
.card4 {
  position: relative;
  padding: 0px;
  border-radius: 20px;
  width: 100%;
  height: auto;
  display: block;
  margin-top:10px;
  background:#f6faeb;
}
.msbImg{
   width: 100%;
   
}
.blockT{
  position: relative;
  display: block;
  color: #fff;
  text-align: center;
  padding: 45% 0;
  height: 100px;
  width:100%;
  background: #a6cd39;
  border-radius: 20px 0em 0em 20px;
  z-index: 100;
}
.spanLine {
  position: absolute;
  direction:"vertical";
  top: 50%;
  left: 0;
  width: 100%;
  display: block;
  border-bottom: 2px dashed rgba(0, 0, 0, 0.1);
  z-index: 0;
}
.button {
  position: relative;
  width:100%;
  margin-left: -40px;
  margin-top: 30px;
  float:center;
  background-color: #a6ce39;
  font-size: 16px;
  color: #fff;
}
.button2 {
  background-color: #a6ce39;
  font-size: 14px;
  color: #fff;
}
.introImg{
  width:100%;
  height: 80%;
}
.text{
  width:90%;
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
  background:  #f6faeb;
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
  background:  transparent;
  box-shadow: 0px 10px 60px 10px rgba(0, 0, 0, 0.1);
   z-index: 100;
}
            .el-dialog__body{
              background: #ededef;
              padding: 1px;
            }
            .el-dialog__header{
              background: #ededef;
              padding: 2px;
            }


</style>
<style lang="less">
/* 选中后的字体颜色 */
.el-radio__input.is-checked+.el-radio__label {
  color: #a6ce39 !important;
}
/* 选中后小圆点的颜色 */
.el-radio__input.is-checked .el-radio__inner {
  background: #a6ce39 !important;
  border-color: #a6ce39 !important;
}
 //item选项的hover样式
  .el-select-dropdown__item.hover, 
  .el-select-dropdown__item:hover{
    color:#a6ce39;
  }



</style>