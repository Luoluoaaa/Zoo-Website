<!---主页信息推荐卡片--->
<template >
<div class="block">

<div class="flip">
    <div class="front" style="background-image: url(https://cdn.chimelong.com/upload/e49b29e8e85760ef/35bbb964b88c7573.jpg)">
       <h1 class="text-shadow">亚洲黑熊</h1>
    </div>
    <div class="back">
       <br><h2>亚洲黑熊</h2><br>
       <p> 亚洲黑熊浑身黑色毛发，吻部淡褐色，并在胸前有一个白色弯月或V型斑纹。亚洲黑熊在外观上比棕熊要小一些，并具有更修长的四肢和吻部。亚洲黑熊灵活的四肢和弯爪有利于其攀爬树木。亚洲黑熊是最常两足行走的熊，甚至可以两足行走达500米。</p>
    </div>
</div>
<div class="flip">
    <div class="front" style="background-image: url(https://i.3kr.com/d/file/hua/20181016/0ac69b972f4245be99596952c74fa9fd.jpg)">
       <h1 class="text-shadow">大熊猫</h1>
    </div>
    <div class="back">
       <br><h2>大熊猫</h2><br>
       <p>大熊猫体型肥硕似熊、头部和身体毛色黑白相间分明，但黑非纯黑，白也不是纯白，而是黑中透褐，白中带黄。黑白相间的外表，有利于隐蔽在密林的树上和积雪的地面而不易被天敌发现。相对锋利的爪和发达有力的前后肢，有利于大熊猫能快速爬上高大的乔木。</p>
    </div>
</div>
<div class="flip">
    <div class="front" style="background-image: url(https://cdn.chimelong.com/upload/8a8125c5ed0d9c33/f32ad1f2238551ba.jpg)">
       <h1 class="text-shadow">长颈鹿</h1>
    </div>
    <div class="back">
       <br><h2>长颈鹿</h2><br>
       <p>雄性长颈鹿通常比雌性长颈鹿高。不同亚种个体间的颜色各不相同。它们身上的多边形的斑块有橙色、红色、巧克力色、棕色等不同颜色；北方的长颈鹿比南方的长颈鹿更高、更大。雄性的努比亚长颈鹿头部有三个圆柱形的骨锥，其中第三个圆柱形的骨锥长在头部中央。</p>
    </div>
</div>
<div class="flip">
    <div class="front" style="background-image: url(https://tse1-mm.cn.bing.net/th/id/R-C.c5b7d7a270c1c2df469b08f07aa0dedd?rik=kBAgU0dkG4LaGw&riu=http%3a%2f%2fhimg2.huanqiu.com%2fattachment2010%2f2014%2f0416%2f20140416012254358.jpg&ehk=ff20UhkZhFiDVtir9rPNx6LIyyQQmkA1vTWP2KwFgpM%3d&risl=&pid=ImgRaw)">
       <h1 class="text-shadow">考拉</h1>
    </div>
    <div class="back">
       <br><h2>考拉</h2><br>
       <p>最大的树栖的有袋类动物。雄性比雌性大50％。树袋熊具有最有效的隔热毛发，而腹部毛皮可以反射太阳辐射。树袋熊的弯曲锋利的爪子很适合爬树。大前爪有两个相对的手指，允许他们抓住小分支。在后爪上，第二和第三位手指融合，这是双门齿目动物的典型特征。</p>
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
.block{
position: relative;
left:90px;
}
</style>
<style scoped  lang="less">

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
</style>