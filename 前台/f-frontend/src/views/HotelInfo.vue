<template>
    <div class="hotel">
      <div class="test">
          <vue-particles color="#dedede"
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
                  clickMode="push">
                

                </vue-particles>
      </div>
          <div class="block">
        <el-carousel  :interval="4000" type="card" height="300px" >
            <el-carousel-item v-for="item in pics"  :key="item">
                <img :src="item.url" />
            <!-- <h3>{{ item }}</h3> -->
            </el-carousel-item>
        </el-carousel>
        </div>
        <!-- <el-row style="margin:20px">
            <el-card>
                <el-row>
                    <el-col :span="6">
                        <el-container>
                            <el-header style="height: 15px;">选择酒店</el-header>
                            <el-main>
                                <el-select v-model="value" placeholder="请选择">
                                    <el-option
                                    v-for="item in options"
                                    :key="item.value"
                                    :label="item.label"
                                    :value="item.value">
                                    </el-option>
                                </el-select>
                            </el-main>
                        </el-container>
                    </el-col>
                    <el-col :span="6">
                         <el-container>
                            <el-header style="height: 15px;">入住时间</el-header>
                            <el-main>
                                    <el-date-picker
                                        v-model="value1"
                                        type="date"
                                        placeholder="选择入住日期">
                                        </el-date-picker>
                            </el-main>
                        </el-container>
                    </el-col>
                    <el-col :span="6">
                      <el-container>
                            <el-header style="height: 15px;">退房时间</el-header>
                            <el-main>
                                    <el-date-picker
                                        v-model="value2"
                                        type="date"
                                        placeholder="选择退房日期">
                                        </el-date-picker>
                            </el-main>
                        </el-container>
                    </el-col>
                    <el-col :span="6">
                        <el-row style="height:15px"></el-row>
                        <el-button type="info" round @click="open">
                            立刻预定
                        </el-button>
                    </el-col>
                </el-row>
            </el-card>
        </el-row> -->
      <notice/>
      <card/>
    </div>
   
 
</template>
<script>
import card from "@/components/Card.vue"
import notice from "@/components/Notice.vue"
export default {
  components:{
    card,
    notice
  },
  
   methods: {
      open() {
        this.$confirm('此操作将预定该时间段酒店, 是否继续?', '提示', {
          confirmButtonText: '确定',
          cancelButtonText: '取消',
          type: 'warning'
        }).then(() => {
          this.$message({
            type: 'success',
            message: '预定成功!'
          });
        }).catch(() => {
          this.$message({
            type: 'info',
            message: '已取消预定'
          });          
        });
      }
    },
  
    data(){
        return{
            pics:[
                {url:"hotel_1.jpg"},
                {url:"hotel_2.jpg"},
                {url:"hotel_3.jpg"},
                {url:"hotel_4.jpg"},
                ],
            options: [{
                value: '选项1',
                label: '格林豪泰酒店'
                }, {
                value: '选项2',
                label: '上海虹桥枢纽美居酒店'
                }, {
                value: '选项3',
                label: '汉庭酒店'
                }, {
                value: '选项4',
                label: '全季酒店'
                }],
                value:"",
                value1:"",
                value2:""
    }
    }
}
</script>
<style>

    
  .test{
      position: fixed;
      top:0px;
      bottom:0px;
      left:0px;
      right:0px;
      z-index:-1;
      background-image: linear-gradient(#f6faeb,#c7effd);
      
    }
.block{
	position: relative;
	left:60px;
}
    
  
</style>