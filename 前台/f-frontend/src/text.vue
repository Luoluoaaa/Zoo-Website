<template>
  <div>
    <div class="demo-basic--circle">
      <div class="block"><el-avatar :size="80" :src="circleUrl"></el-avatar></div>
    </div>
    <div class="text">
      <br>
      <span >TJUniversity</span><br>
      <div class="text_title">
      <el-button type="text" @click="gotoRegister"> 注 册 </el-button> 
      <span > | </span>
      <el-button type="text" @click="gotoLogin"> 登 录 </el-button> 
      <el-divider></el-divider>
      </div>
    </div>
  </div>
</template>


<script>

    export default {
    data () {
      return {
        circleUrl: "https://cube.elemecdn.com/3/7c/3ea6beec64369c2642b92c6726f1epng.png",
        sizeList: ["large"]
      }
    },
    methods:{
      gotoLogin(){
        this.$router.push('/Login')
      },
      gotoRegister(){
        this.$router.push('/Register')
      }
    }
  }
</script>

<style scoped>
  .block {
    text-align:center;
    margin-top:50px;
  }
.text  {
    font-size:15px ;
    line-height: 100%;
    text-align: center;
    color: rgb(36, 36, 36) ;
  }
.text_title  {
    font-size:15px ;
    line-height: 0%;
    text-align: center;
    color: rgb(36, 36, 36) ;
  }
</style>