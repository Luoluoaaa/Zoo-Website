<template >
  <div class="block">
    <!-- horizontal -->

    <div class="flip">
      <div class="front" style="background-image: url(invertebrate_1.jpg)">
        <h1 class="text-shadow" style="margin-top: 150px">海月水母</h1>
      </div>
      <div class="back">
        <br />
        <h2>海月水母</h2>
        <br />
        <p>
          海月水母是羊须水母科海月水母属下的一种水母。海月水母属物种的水母体单从外观根本不能分辨，必须要以基因来作出分析......
        </p>
      </div>
    </div>
    <div class="flip">
      <div class="front" style="background-image: url(invertebrate_2.jpg)">
        <h1 class="text-shadow" style="margin-top: 150px">原瘤海星</h1>
      </div>
      <div class="back">
        <br />
        <h2>原瘤海星</h2>
        <br />
        <p>
          原瘤海星大多为红色、橙色或棕色，偶见白色、粉色、蓝色或绿色的个体....
        </p>
      </div>
    </div>
    <div class="flip">
      <div class="front" style="background-image: url(invertebrate_3.jpg)">
        <h1 class="text-shadow" style="margin-top: 150px">巨型章鱼</h1>
      </div>
      <div class="back">
        <br />
        <h2>巨型章鱼</h2>
        <br />
        <p>
          北太平洋巨型章鱼有八只腕足，每只腕足上覆盖着280个吸盘,
          吸盘上有数以千计的化学感受器，使它的触觉和味觉非常敏锐，有助于捕食......
        </p>
      </div>
    </div>
    <div class="flip">
      <div class="front" style="background-image: url(invertebrate_4.jpg)">
        <h1 class="text-shadow" style="margin-top: 150px">日本蜘蛛蟹</h1>
      </div>
      <div class="back">
        <br />
        <h2>日本蜘蛛蟹</h2>
        <br />
        <p>
          日本蜘蛛蟹是现存最大的甲壳动物，也是十足目短尾下目蜘蛛蟹科巨螯蟹属唯一的品种.....
        </p>
      </div>
    </div>
    <!-- <div class="flip" v-for="(item,i) in list" :key="i">
    <div class="front" :style="getBg(i)">
      <h1 class="text-shadow" style="margin-top:150;text-align:center;">{{item.name}}</h1>
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
    background: linear-gradient(
      to right,
      rgb(218, 210, 153),
      rgb(176, 218, 185)
    );
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
.block {
  position: relative;
  left: 120px;
}
h1 {
  text-align: center !important;
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
import { getAnimalInfo } from "../api/animalInfo";
//import axios from "axios";
export default {
  data() {
    return {
      list: [],
    };
  },
  computed: {
    getBg() {
      return (x) => {
        return { "background-image": "url(" + this.list[x].img + ")" };
      };
    },
  },

  created() {
    getAnimalInfo({
      species: "无脊椎动物类",
    })
      .then((response) => {
        this.list = response.data;
        for (let i = 0; i < this.list.length; i++) {
          this.list[i].img = "data:image/jpeg;base64," + this.list[i].img;
        }
      })
      .catch(() => {});
  },
};
</script>