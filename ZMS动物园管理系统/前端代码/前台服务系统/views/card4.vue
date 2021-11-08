<!---主页新闻推荐卡片--->
<template lang="pug">
    
- var n = 0;
.content
    a(href="#!").card
      .front(style="background-image: url(https://tse1-mm.cn.bing.net/th/id/R-C.dfa16589a2d632b3438609a51abedc42?rik=abulu5TXilf%2bOw&riu=http%3a%2f%2fp7.qhimg.com%2ft019b5553e334e81dbc.jpg&ehk=%2bBaVwl6vTiZV%2fOS0NEPytDDm4goudmTdusul8nrWQPI%3d&risl=&pid=ImgRaw)",)
        p 同济大学附属动物园新闻推荐
      .back
       div
          h1 新闻推荐
          p 2020年，同济集团荣获科技部、中宣部、中国科协授予的 “全国科普先进集体”称号。上海市科技厅、市科协在上海市科技馆于2021年1月25日同济集团等四家省内获奖单位举行了隆重的颁奖仪式。


    a(href="#!").card
      .front(style="background-image: url(https://tse1-mm.cn.bing.net/th/id/R-C.8a56e962a34c2fd2d0c9ef90187fd8f8?rik=%2f0H58AUlPsVwIg&riu=http%3a%2f%2fimg.ivsky.com%2fimg%2ftupian%2fpre%2f201611%2f09%2fpaxing_dongwu_she-001.jpg&ehk=SqNNg7EDfoWB0poP9HeAwUkjqK9x%2bc2aKh0uXaK8smM%3d&risl=&pid=ImgRaw)",)
        p 同济大学附属动物园新闻推荐
      .back
        div
          h1 新闻推荐
          p 腊月初十，牛年的年味越来越浓了，广州长隆野生动物世界刚刚满月的6只金毛羚牛宝宝，迫不及待与大家见面啦！

    a(href="#!").card
      .front(style="background-image: url(https://tse1-mm.cn.bing.net/th/id/R-C.999335835ba214eb1d014b07790af8d4?rik=pKRBBthu5emNww&riu=http%3a%2f%2fimg.ivsky.com%2fimg%2ftupian%2fpre%2f201611%2f09%2ffeizhou_yesheng_dongwu-004.jpg&ehk=h6gEgbN%2bVqi4RaMrtVZ%2fWNuSseFn9D3jddfH3rmA8ro%3d&risl=&pid=ImgRaw)",)
        p 同济大学附属动物园新闻推荐
      .back
        div
          h1 新闻推荐
          p 5月13日同济大学附属动物园成功繁育的世界首例珍稀黑叶猴龙凤胎正式跟广大游客见面。这是黑叶猴龙凤胎“奇奇”“美美”的首次展出。

    a(href="#!").card
      .front(style="background-image: url(https://tse1-mm.cn.bing.net/th/id/R-C.c713b1e4edde8887ce9c06b8d7be1012?rik=2RWgloaoBnbwXg&riu=http%3a%2f%2fwww.2019.com.cn%2fuploads%2f2020%2f0306%2fobbocuccozw20200306231622.jpg&ehk=u2veNdzJPljS7zoQsp%2bM22Gy4D1yxtkFqKDwfmOlAFU%3d&risl=&pid=ImgRaw)",)
        p 同济大学附属动物园新闻推荐
      .back
        div
          h1 新闻推荐
          p 由国家林业局批准、同济大学附属动物园建设的中国大熊猫保护研究中心上海基地公布喜讯，大熊猫“梅清”近日又诞下了一对大熊猫（学名：Ailuropoda melanoleuca）双胞胎！

    a(href="#!").card
      .front(style="background-image: url(https://tse1-mm.cn.bing.net/th/id/R-C.83360fde8355e64ab31ec64b9f596a11?rik=Nn%2fr7UT4%2bP9rjg&riu=http%3a%2f%2fpic364.nipic.com%2ffile%2f20210131%2f12342850_113317511458_2.jpg&ehk=ddhUBzrTpt1bH6MC0d4D0drB0QdOLH0YLxLbdvDh8Mo%3d&risl=&pid=ImgRaw)",)
        p 同济大学附属动物园新闻推荐
      .back
        div
          h1 新闻推荐
          p 今年初降生的7只新生金毛羚牛宝宝，于2019年3月11日在同济大学附属动物园首次与游客见面。

    a(href="#!").card
      .front(style="background-image: url(https://tse1-mm.cn.bing.net/th/id/R-C.57ed2b873ec33abe075ada477bddbfb5?rik=85ZJKpieMbKYgQ&riu=http%3a%2f%2fpic.sc.chinaz.com%2ffiles%2fpic%2fpic9%2f201804%2fwpic659.jpg&ehk=G3dUnx3rwYeQ5zJwqzQvzGa5V7jnLmFMEbe%2fkUfZg0c%3d&risl=&pid=ImgRaw)",)
        p 同济大学附属动物园新闻推荐
      .back
        div
          h1 新闻推荐
          p 第二届中华白海豚保护宣传日暨同济崇明岛分园中华白海豚科普宣传月主题活动，在崇明岛中华白海豚科普教育基地隆重举行。



          
        
</template>


<style lang="scss" scoped>

$primary: hsl(222,80%,50%);
$primary-light: hsl(222,50%,95%);

$secondary: hsl(350,80%,50%);

$red: hsl(10,80%,50%);
$orange: hsl(50,80%,50%);

*, *:before, *:after {
  box-sizing: border-box;
}

@mixin mobile ($size: 640px) {
  @media screen and (max-width: $size) {
    @content;
  }
}

html {
  font-size: 18px;
  line-height: 1.5;
  font-weight: 300;
  color: #333;
  font-family: "Nunito Sans", sans-serif;
}

body {
  margin: 0;
  padding: 0;
  height: 100vh;
  background-color: $primary-light;
  background-attachment: fixed;
}

.content {
  display: flex;
  margin: 0 auto;
  justify-content: center;
  align-items: center;
  flex-wrap: wrap;
  max-width: 1000px;
}

.heading {
  width: 100%;
  margin-left: 1rem;
  font-weight: 900;
  font-size: 1.618rem;
  text-transform: uppercase;
  letter-spacing: .1ch;
  line-height: 1;
  padding-bottom: .5em;
  margin-bottom: 1rem;
  position: relative;
  
  &:after {
    display: block;
    content: '';
    position: absolute;
    width: 60px;
    height: 4px;
    background: linear-gradient(135deg, adjust-hue($primary, -20deg), $primary);
    bottom: 0;
  }
}

.description {
  width: 100%;
  margin-top: 0;
  margin-left: 1rem;
  margin-bottom: 3rem;
}

.card {
  color: inherit;
  cursor: pointer;
  width: calc(33% - 2rem);
  min-width: calc(33% - 2rem);
  height: 320px;
  min-height: 320px;
  perspective: 1000px;
  margin: 1rem;
  position: relative;
  @include mobile (800px) {
    width: calc(50% - 2rem);
  }
  @include mobile (500px) {
    width: 100%;
  }
}

.front,
.back {
  display: flex;
  border-radius: 6px;
  background-position: center;
  background-size: cover;
  text-align: center;
  justify-content: center;
  align-items: center;
  position: absolute;
  height: 100%;
  width: 100%;
  -webkit-backface-visibility: hidden;
  backface-visibility: hidden;
  transform-style: preserve-3d;
  transition: ease-in-out 600ms;
  // overflow: hidden;
}

.front {
  background-size: cover;
  // background-blend-mode: overlay;
  padding: 2rem;
  font-size: 1.618rem;
  font-weight: 600;
  color: #fff;
  overflow: hidden;
  font-family: Poppins, sans-serif;
  &:before {
    position: absolute;
    display: block;
    content: '';
    top: 0;
    left: 0;
    right: 0;
    bottom: 0;
    background: linear-gradient(135deg, adjust-hue($primary, -20deg), $primary);
    opacity: .25;
    z-index: -1;
  }
  .card:hover & {
    transform: rotateY(180deg);
  }
  .card:nth-child(even):hover & {
    transform: rotateY(-180deg);
  }
}

.back {
  background: rgb(184, 183, 183);
  transform: rotateY(-180deg);
  padding: 0 2em;
  
  .button {
    background: linear-gradient(135deg, adjust-hue($primary, -20deg), $primary);
    
    &:before {
      box-shadow: 0 0 10px 10px rgba($primary, 0.25);
    background-color: rgba($primary, 0.25);
    }
  }
  
  .card:hover & {
    transform: rotateY(0deg);
  }
  
  .card:nth-child(even) & {
    transform: rotateY(180deg);
    
    .button {
    background: linear-gradient(135deg, adjust-hue($secondary, -20deg), $secondary);
    
    &:before {
      box-shadow: 0 0 10px 10px rgba($secondary, 0.25);
    background-color: rgba($secondary, 0.25);
    }
  }
  }
  
  .card:nth-child(even):hover & {
    transform: rotateY(0deg);
  }
}

.button {
  $height: 40px;
  transform: translateZ($height);
  cursor: pointer;
  -webkit-backface-visibility: hidden;
  backface-visibility: hidden;
  font-weight: bold;
  color: #fff;
  padding: .5em 1em;
  border-radius: 100px;
  font: inherit;
  border: none;
  position: relative;
    transform-style: preserve-3d;
  transition: 300ms ease;
  
  &:before {
  transition: 300ms ease;
    position: absolute;
    display: block;
    content: '';
    transform: translateZ(-$height);
    -webkit-backface-visibility: hidden;
    backface-visibility: hidden;
    height: calc(100% - 20px);
    width: calc(100% - 20px);
    border-radius: 100px;
    left: 10px;
    top: 16px;
  }
  
  &:hover {
    transform: translateZ($height + 15px);
    
    &:before {
      transform: translateZ(-($height + 15px));
    }
  }
  
  &:active {
    transform: translateZ($height/2);
    
    &:before {
      transform: translateZ(-($height/2));
        top: 12px;
    }
  }
}

</style>