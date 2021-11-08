<template >
  <div class="block">
    <div class="flip">
      <div class="front" style="background-image: url(fish_1.jpg)">
        <h1 class="text-shadow" style="margin-top: 150px">路氏双髻鲨</h1>
      </div>
      <div class="back">
        <br />
        <h2>路氏双髻鲨</h2>
        <br />
        <p>
          路氏双髻鲨，学名：Sphyrna
          lewin，体延长，侧扁而粗壮。头前部平扁，两侧特别扩展，形成很宽的鎚状突出，状似广阔之丫髻状。...
        </p>
      </div>
    </div>
    <div class="flip">
      <div class="front" style="background-image: url(fish_2.jpg)">
        <h1 class="text-shadow" style="margin-top: 150px">蝠鲼</h1>
      </div>
      <div class="back">
        <br />
        <h2>蝠鲼</h2>
        <br />
        <p>
          阿氏前口蝠鲼属鳐鱼的一种，是世界上最大的鳐鱼之一（体型第二大的鳐鱼，仅次于双吻前口蝠鲼）...
        </p>
      </div>
    </div>
    <div class="flip">
      <div class="front" style="background-image: url(fish_3.jpg)">
        <h1 class="text-shadow" style="margin-top: 150px">鲸鲨</h1>
      </div>
      <div class="back">
        <br />
        <h2>鲸鲨</h2>
        <br />
        <p>
          鲸鲨是世界上最大的鱼，因其体型巨大似鲸而得名鲸鲨。尽管体型巨大，鲸鲨性情却很温和....
        </p>
      </div>
    </div>
    <div class="flip">
      <div class="front" style="background-image: url(fish_4.jpg)">
        <h1 class="text-shadow" style="margin-top: 150px">康吉鳗</h1>
      </div>
      <div class="back">
        <br />
        <h2>康吉鳗</h2>
        <br />
        <p>哈氏异康吉鳗的整个身躯呈白色，并长有密密麻麻的黑色斑点......</p>
      </div>
    </div>
    <div class="flip">
      <div class="front" style="background-image: url(fish_5.jpg)">
        <h1 class="text-shadow" style="margin-top: 150px">鳄雀鳝</h1>
      </div>
      <div class="back">
        <br />
        <h2>鳄雀鳝</h2>
        <br />
        <p>
          鳄雀鳝是北美7种雀鳝鱼中最大的一种，能长到3米。体延长，上下颌亦长。口裂深，具锐齿......
        </p>
      </div>
    </div>
    <div class="flip">
      <div class="front" style="background-image: url(fish_6.jpg)">
        <h1 class="text-shadow" style="margin-top: 150px">海象鱼</h1>
      </div>
      <div class="back">
        <br />
        <h2>海象鱼</h2>
        <br />
        <p>海象鱼是世界最大淡水鱼之一，体长可达2.75m，体重可达200kg......</p>
      </div>
    </div>
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
.head1 {
  margin-top: 150px;
  text-align: center;
}
h1 {
  text-align: center !important;
}
</style>
<script>
import { getAnimalInfo } from "../api/animalInfo";
//import axios from 'axios'
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
      species: "鱼类",
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