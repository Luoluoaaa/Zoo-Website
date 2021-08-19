<template>
    <div class="transport">
        <div class="test">
          <vue-particles color="#8a0f86"
                  :particleOpacity="0.8"
                  :particlesNumber="80"
                  shapeType="polygon"
                  :particleSize="4"
                  linesColor="#e79bbd"
                  :linesWidth="1"
                  :lineLinked="true"
                  :lineOpacity="0.7"
                  :linesDistance="150"
                  :moveSpeed="3"
                  :hoverEffect="true"
                  hoverMode="grab"
                  :clickEffect="true"
                  clickMode="bubble">
                

                </vue-particles>
      </div>
        <el-card class="card1" shadow="hover">
            <h1 style="font-size:30px;text-align:center;color:#a6cd39;margin-bottom:40px">交通指南</h1>
            <el-row style="margin:40px 0 0 0 ">
                <el-button type="success"><i class="el-icon-discover" style="font-size:16px"></i> 前往度假区</el-button>
            </el-row>
            <el-divider></el-divider>
            <el-row type="flex" justify="space-between" style="margin:20px">
                <el-col :span="8">
                    <el-card class="small_card" shadow="hover" >
                        <img src="transport_1.jpg" class="image">
                        <el-row style="margin:20px 0 0 0">
                            <el-button type="success" @click="dialogTableVisible = true;clickHandler('飞机')">
                                <i class="el-icon-map-location" style="font-size:16px"></i>
                                从机场出发
                            </el-button>    
                        </el-row>
                    </el-card>
                </el-col>
                <el-col :span="8" >
                    <el-card class="small_card" shadow="hover">
                        <img src="transport_2.jpg" class="image">
                        <el-row style="margin:20px 0 0 0">
                            <el-button type="success" @click="dialogTableVisible = true;clickHandler('高铁')">
                                <i class="el-icon-map-location" style="font-size:16px"></i>
                                从高铁/火车站出发
                            </el-button>    
                        </el-row>
                    </el-card>
                </el-col>
                <el-col :span="8">
                    <el-card class="small_card" shadow="hover">
                        <img src="transport_3.jpg" class="image">
                        <el-row style="margin:20px 0 0 0">
                            <el-button type="success" @click="dialogTableVisible = true;clickHandler('高速公路')">
                                <i class="el-icon-map-location" style="font-size:16px"></i>
                                从高速公路出发
                            </el-button>    
                        </el-row>
                    </el-card>
                    
                </el-col>
            </el-row>
             <el-row type="flex" justify="space-between" style="margin:20px">
                <el-col :span="8">
                    <el-card class="small_card" shadow="hover">
                        <img src="transport_4.jpg" class="image">
                        <el-row style="margin:20px 0 0 0">
                            <el-button type="success" @click="dialogTableVisible = true;clickHandler('地铁')">
                                <i class="el-icon-map-location" style="font-size:16px"></i>
                                从地铁站/公交出发
                            </el-button>    
                        </el-row>
                    </el-card>
                </el-col>
                <el-col :span="8" >
                    <el-card class="small_card" shadow="hover">
                        <img src="transport_5.jpg" class="image">
                        <el-row style="margin:20px 0 0 0">
                            <el-button type="success" @click="dialogTableVisible = true;clickHandler('苏浙')">
                                <i class="el-icon-map-location" style="font-size:16px"></i>
                                从苏浙出发
                            </el-button>    
                        </el-row>
                    </el-card>
                </el-col>
                <el-col :span="8">
                    <el-card class="small_card" shadow="hover">
                        <img src="transport_6.jpg" class="image">
                        <el-row style="margin:20px 0 0 0">
                            <el-button type="success" @click="dialogTableVisible = true;clickHandler('上海迪士尼')">
                                <i class="el-icon-map-location" style="font-size:16px"></i>
                                从上海迪士尼出发
                            </el-button>
                            <el-dialog title="具体信息" :visible.sync="dialogTableVisible">
                                <el-table :data="list">
                                    <el-table-column property="id" label="交通工具编号" width="150"></el-table-column>
                                    <el-table-column property="departureInterval" label="发车频率" width="150"></el-table-column>
                                    <el-table-column property="transDuration" label="车程时长"></el-table-column>
                                    <el-table-column property="price" label="票价"></el-table-column>
                                    <el-table-column property="boardingLocation" label="上车地点"></el-table-column>
                                </el-table>
                            </el-dialog>    
                        </el-row>
                    </el-card>
                    
                </el-col>
            </el-row>
            
        </el-card>
       
    </div>
        
    
</template>
<script>
import {getTransportInfo} from '../api/transportation'
export default {
   
    data(){
        return{
            dialogTableVisible:false,
        
        list:[]
        }
    },
    methods:{
        clickHandler(x){
            getTransportInfo({
                type:x
            }).then(response =>{
                console.log('succ')
                this.list=response.data
            }).catch(err =>{
                console.log('error')
            })
        }
    }
  
}
</script>
<style scoped>
    .el-card{
        background-color: #f6faeb;
        width: 1000px;
        margin: 0 auto;
        box-shadow: 0 2px 12px 0 rgb(0,0,0,0.1);
    }
    .el-divider{
        margin: 0 auto;
        height: 10px;
        background-color: #a6ce39;
        border-radius: 30px;
    }
    .el-button{
        background-color: #a6ce39;
        font-size: 16px;
        color: #fff;
        display: block;
        text-align:center;
        margin-left:auto;
        margin-right:auto;
        box-shadow: 0 2px 12px 0 rgb(0,0,0,0.1);
}
     .image {
    width: 100%;
    height: 150px;
    display: block;
  
  }
  .small_card{
      width: 250px;
      background-color: #f8fbeb;
      border-radius: 30px;
  }
  .test{
      position: fixed;
      top:0px;
      bottom:0px;
      left:0px;
      right:0px;
      z-index:-1;
      background-image: linear-gradient(#f6faeb,#c7effd);
      
    }
</style>