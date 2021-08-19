<template>
    <div class="animal">
        <div class="test">
          <vue-particles color="#444"
                  :particleOpacity="0.5"
                  :particlesNumber="80"
                  shapeType="star"
                  :particleSize="4"
                  linesColor="#555"
                  :linesWidth="1"
                  :lineLinked="true"
                  :lineOpacity="0.1"
                  :linesDistance="150"
                  :moveSpeed="3"
                  :hoverEffect="true"
                  hoverMode="grab"
                  :clickEffect="true"
                  clickMode="push">
                

                </vue-particles>
      </div>
        <el-card>
            <h1 style="font-size:30px;text-align:center;color:#46897d;margin-bottom:40px">动物百科</h1>
         
                
                <div class="center">
                    
                     <el-radio-group fill="#46897d" type="border-card" v-model="radio1" @change="handleClick(arguments)">
                        <el-radio-button label="哺乳类" name="first" @change="switchTabs(arguments)">哺乳类</el-radio-button>
                        <el-radio-button label="鸟类" name="second" @change="switchBird(arguments)">鸟类</el-radio-button>
                        <el-radio-button label="爬行动物类" name="third">爬行动物类</el-radio-button>
                        <el-radio-button label="两栖类" name="fourth">两栖类</el-radio-button>
                        <el-radio-button label="鱼类" name="fifth">鱼类</el-radio-button>
                        <el-radio-button label="无脊椎类" name="sixth">无脊椎类</el-radio-button>
                     </el-radio-group>
                </div>
               
           
            <el-divider></el-divider>
            <div  v-if="radio1===`哺乳类`">
              <br>
              <animalcard1/>
          
            
            </div>
            <div  v-if="radio1===`鸟类`">
              <br>
              <animalcard2/>
            </div>
            <div  v-if="radio1===`爬行动物类`">
              <br>
              <animalcard3/>
            </div>
            <div  v-if="radio1===`两栖类`">
              <br>
              <animalcard4/>
            </div>
            <div  v-if="radio1===`鱼类`">
              <br>
              <animalcard5/>
            </div>
            <div  v-if="radio1===`无脊椎类`">
              <br>
              <animalcard6/>
            </div>
        </el-card>
      
    </div>
</template>
<script>
import animalcard1 from "@/components/AnimalCard_mammal.vue"
import animalcard2 from "@/components/AnimalCard_bird.vue"
import animalcard3 from "@/components/AnimalCard_reptile.vue"
import animalcard4 from "@/components/AnimalCard_frog.vue"
import animalcard5 from "@/components/AnimalCard_fish.vue"
import animalcard6 from "@/components/AnimalCard_invertebrate.vue"
export default {
  components:{
    animalcard1,
    animalcard2,
    animalcard3,
    animalcard4,
    animalcard5,
    animalcard6,
  },
    data () {
      return {
        radio1: '鸟类',
        activeName: 'second',
        activeTab:0,
      };
    },
 
    methods: {
    
      handleClick(tab, event) {
        console.log(tab, event);
      },
      switchBird(x){
        console.log(x)
        this.switchTabs(1)
        console.log("bird")
      },
      switchTabs(x){
        this.activeTab=x
      }
    }
  };
    
</script>
<style scoped>
     .el-card{
        background-color: #ecf3f2;
        width: 85%;
        margin: 0 auto;
    }
     .el-divider{
        margin: 0 auto;
        height: 10px;
        background-color: #46897d;
        border-radius: 30px;
    }
 
  .small_card{
      background-color:rgba(236, 243, 242,0.1);
      width: 300px;
  }
  img{
      width:250px;
  }
    .center{
      position: relative;
      right: auto;
      left: 25%;
    }
    .green{
        background-color:#46897d;

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