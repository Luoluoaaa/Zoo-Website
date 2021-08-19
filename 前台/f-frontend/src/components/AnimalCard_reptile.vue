<template >
<div class="block">
<!-- horizontal -->
  <div class="flip">
    <div class="front" style="background-image: url(reptile_1.jpg)">
       <h1 class="text-shadow" style="margin-top:150px">变色树蜥</h1>
    </div>
    <div class="back">
       <br><h2>变色树蜥</h2><br>
       <p> 变色树蜥栖息地在海拔80-2000米左右热带亚热带地区。</p>
    </div>
</div>
<div class="flip">
    <div class="front" style="background-image: url(reptile_2.jpg)">
       <h1 class="text-shadow" style="margin-top:150px">平原巨蜥</h1>
    </div>
    <div class="back">
       <br><h2>平原巨蜥</h2><br>
       <p>平原巨蜥分布范围遍及整个撒哈拉以南非洲地区，东至塞内加尔，南至苏丹，南至刚果河和大裂谷。</p>
    </div>
</div>
<div class="flip">
    <div class="front" style="background-image: url(reptile_3.jpg)">
       <h1 class="text-shadow" style="margin-top:150px">马来鳄</h1>
    </div>
    <div class="back">
       <br><h2>马来鳄</h2><br>
       <p>马来鳄是大型鳄鱼，口鼻部很细长，口内有76-84枚大小一致的尖锐牙齿。马来鳄有一个流线型的身体和肌肉发达的尾巴，头部上方有眼睛和鼻孔，还有一个防止水在水下进入喉咙的腭瓣。</p>
    </div>
</div>
<div class="flip">
    <div class="front" style="background-image: url(reptile_4.jpg)">
       <h1 class="text-shadow" style="margin-top:150px">鳄蜥</h1>
    </div>
    <div class="back">
       <br><h2>鳄蜥</h2><br>
       <p>鳄蜥分布于中国（广东，广西）和越南。</p>
    </div>
</div>
<div class="flip">
    <div class="front" style="background-image: url(reptile_5.jpg)">
       <h1 class="text-shadow" style="margin-top:150px">地毯蟒</h1>
    </div>
    <div class="back">
       <br><h2>地毯蟒</h2><br>
       <p>地毯蟒栖息地遍布森林及热带草原等各式各样不同的环境。</p>
    </div>
</div>
<div class="flip">
    <div class="front" style="background-image: url(reptile_6.jpg)">
       <h1 class="text-shadow" style="margin-top:150px">高冠变色龙</h1>
    </div>
    <div class="back">
       <br><h2>高冠变色龙</h2><br>
       <p>高冠变色龙喜欢栖于树上或大型植物上。</p>
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

<style  scoped lang="scss">

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
  text-align: center !important;
}

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

</style>
<script>
// import axios from 'axios'
//       export default{
//         data(){
//           return{
//             list:""
//           }
//         },
//         mounted(){
//           this.getAnimal()
//         },
//         methods:{
//           getAnimal(){
//             axios.get('/api/animal.json').then(this.getAnimalSucc)

//           },
//           getAnimalSucc(res){
//             this.list=res.data.list
            
//           }

//         }
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
            species:'爬行动物类'
          }).then(response=>{
            console.log('succ')
            this.list=response.data
            for(let i=0;i<this.list.length;i++){
              this.list[i].img='data:image/jpeg;base64,'+this.list[i].img
            }
          }).catch(err=>{
            console.log('error')
          })
        },
      }
</script>