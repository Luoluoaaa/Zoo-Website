<template >

<!-- horizontal -->
<div class="block">
  <div class="flip">
    <div class="front" style="background-image: url(bird_1.jpg)">
       <h1 class="text-shadow" style="margin-top:150px">黑颈天鹅</h1>
    </div>
    <div class="back">
       <br><h2>黑颈天鹅</h2><br>
       <p> 黑颈天鹅生活在生存着狭叶香蒲、蕉草、灯心草、芦苇、浮萍等水生植物的淡水或稍咸水的沼泽、湖泊和泻湖中，到了旱季就扩散到内陆草地、河口以及沙滩等地活动，有时甚至也栖息于生长着大量海藻的沿海区域，采食岩石上着生的各种藻类。</p>
    </div>
</div>
<div class="flip">
    <div class="front" style="background-image: url(bird_2.jpg)">
       <h1 class="text-shadow" style="margin-top:150px">扁嘴天鹅</h1>
    </div>
    <div class="back">
       <br><h2>扁嘴天鹅</h2><br>
       <p>扁嘴天鹅通常在低海拔区域活动，最高记录达1000米。偏好大型湖泊、沼泽和淡水池塘，也出现于半咸水的巴西海滩上。</p>
    </div>
</div>
<div class="flip">
    <div class="front" style="background-image: url(bird_3.jpg)">
       <h1 class="text-shadow" style="margin-top:150px">赤麻鸭</h1>
    </div>
    <div class="back">
       <br><h2>赤麻鸭</h2><br>
       <p>赤麻鸭栖息于江河、湖泊、河口、水塘及其附近的草原、荒地、沼泽、沙滩、农田和平原疏林等各类生境中，尤喜平原上的湖泊地带。</p>
    </div>
</div>
<div class="flip">
    <div class="front" style="background-image: url(bird_4.jpg)">
       <h1 class="text-shadow" style="margin-top:150px">黑天鹅</h1>
    </div>
    <div class="back">
       <br><h2>黑天鹅</h2><br>
       <p>黑天鹅原产于澳大利亚，包括塔斯马尼亚。</p>
    </div>
</div>
<div class="flip">
    <div class="front" style="background-image: url(bird_5.jpg)">
       <h1 class="text-shadow" style="margin-top:150px">斑头雁</h1>
    </div>
    <div class="back">
       <br><h2>斑头雁</h2><br>
       <p>斑头雁分布于中亚、克什米尔及蒙古国，越冬在印度、巴基斯坦、缅甸和中国云南等地。</p>
    </div>
</div>
<div class="flip">
    <div class="front" style="background-image: url(bird_6.jpg)">
       <h1 class="text-shadow" style="margin-top:150px">白额雁</h1>
    </div>
    <div class="back">
       <br><h2>白额雁</h2><br>
       <p>白额雁繁殖于西伯利亚北极海岸到白令海峡、北美洲极北部、欧洲西部及格陵兰岛西部。越冬在中国、北美洲、墨西哥、里海、黑海、地中海、中亚、印度、缅甸、日本、朝鲜。</p>
    </div>
</div>

<!-- <div class="flip" v-for="(item,i) in list" :key="i">
    <div class="front" :style="getBg(i)">
      <h1 class="text-shadow" style="margin-top:150px;text-align:center;">{{item.name}}</h1>
    </div>
    <div class="back">
      <br><h2 style="text-align:center;">{{item.name}}</h2><br>
      <p>{{item.content}}</p>
    </div>
</div> -->

</div>
</template>

<style scoped lang="scss">

* {
  box-sizing: border-box;
  font-weight: normal;
}

body {
  position: relative;
  color: rgb(255, 255, 255);
  text-align: center;
  padding: 1em;
}

h1 {
  font-size: 2.2em;
}
</style>
<style scoped lang="less">
// base
.flip {
  position: absolute;
  > .front,
  > .back {
    display: block;
    transition-timing-function: cubic-bezier(0.175, 0.885, 0.32, 1.275);
    transition-duration: 1.5s;
    transition-property: transform, opacity;
  }
  > .front {
    transform: rotateY(0deg);
  }
  > .back {
    position: absolute;
    opacity: 0;
    top: 0px;
    left: 0px;
    width: 100%;
    height: 100%;
    transform: rotateY(-180deg);
  }
  &:hover {
    > .front {
      transform: rotateY(180deg);
    }
    > .back {
      opacity: 1;
      transform: rotateY(0deg);
    }
  }
  &.flip-vertical {
    > .back {
      transform: rotateX(-180deg);
    }
    &:hover {
      > .front {
        transform: rotateX(180deg);
      }
      > .back {
        transform: rotateX(0deg);
      }
    }
  }
}

// custom
.flip {
  position: relative;
  display: inline-block;
  margin-right: 20px;
  margin-bottom: 1em;
  width: 260px;
  > .front,
  > .back {
    display: block;
    color: white;
    width: inherit;
    background-size: cover !important;
    background-position: center !important;
    height: 360px;
    padding: 1em 2em;
    background:linear-gradient(to right, rgb(218, 210, 153), rgb(176, 218, 185));
    border-radius: 10px;
    p {
      font-size: 0.9125rem;
      line-height: 160%;
      color: #999;
    }
  }
}

.text-shadow {
  text-shadow: 1px 1px rgba(0, 0, 0, 0.04), 2px 2px rgba(0, 0, 0, 0.04),
    3px 3px rgba(0, 0, 0, 0.04), 4px 4px rgba(0, 0, 0, 0.04),
    0.125rem 0.125rem rgba(0, 0, 0, 0.04), 6px 6px rgba(0, 0, 0, 0.04),
    7px 7px rgba(0, 0, 0, 0.04), 8px 8px rgba(0, 0, 0, 0.04),
    9px 9px rgba(0, 0, 0, 0.04), 0.3125rem 0.3125rem rgba(0, 0, 0, 0.04),
    11px 11px rgba(0, 0, 0, 0.04), 12px 12px rgba(0, 0, 0, 0.04),
    13px 13px rgba(0, 0, 0, 0.04), 14px 14px rgba(0, 0, 0, 0.04),
    0.625rem 0.625rem rgba(0, 0, 0, 0.04), 16px 16px rgba(0, 0, 0, 0.04),
    17px 17px rgba(0, 0, 0, 0.04), 18px 18px rgba(0, 0, 0, 0.04),
    19px 19px rgba(0, 0, 0, 0.04), 1.25rem 1.25rem rgba(0, 0, 0, 0.04);
}
.block{
position: relative;
left:120px;
}
h1{
  text-align: center !important;
}
</style>
<script>
import {getAnimalInfo} from '../api/animalInfo'
import axios from 'axios'
      export default{
        data(){
          return{
            list:[]
          }
        },
        computed:{
          getBg(){
            return(x)=>{
              return {'background-image': 'url('+this.list[x].img+')'}
            }
          }
        },
        
        created(){
          getAnimalInfo({
            species:'鸟类'
          }).then(response=>{
            this.list=response.data
            for(let i=0;i<this.list.length;i++){
              this.list[i].img='data:image/jpeg;base64,'+this.list[i].img
            }
          }).catch(()=>{
          })
        },

        mounted(){
          //this.getAnimal()
        },
        methods:{
          getAnimal(){
            axios.get('/api/animal.json').then(this.getAnimalSucc)

          },
          getAnimalSucc(res){
            this.list=res.data.list
            
          }

        }

      }
</script>