<template>
<div class="cards">
  <a class="card" href="#">
    <span class="card-header" style="background-image: url(https://tse1-mm.cn.bing.net/th/id/R-C.e7dc95aa7bd289befc2ff1d2cd5c4150?rik=ntamyK1%2fuW7IcA&riu=http%3a%2f%2fimg.oocct.com%2fxianyou%2fuploads%2fallimg%2f160712%2f2-160G21A332E1.jpg&ehk=yJCCqrd4ehZuopb8vBXvq8gfAgrJ3LFezbh%2fI4uhT%2bs%3d&risl=&pid=ImgRaw);">
      <span class="card-title">
        <h3>世界鲸鲨日科普宣传活动</h3>
      </span>
    </span>
    <span class="card-summary">
      2021年3月3日是第八个“世界野生动植物日”，主题为“推动绿色发展,促进人与自然和谐共生”，同济大学附属动物园举办宣传活动。
    </span>
  </a>

  <a class="card" href="#">
    <span class="card-header" style="background-image: url(https://tse1-mm.cn.bing.net/th/id/R-C.f4112b5716b692e1c5bac9bb8741c820?rik=aT%2fegfLdgzKkjw&riu=http%3a%2f%2fwww.cshdsj.com.cn%2frepository%2fimage%2f6A-jvQygREaQ4QpJFFImEg.jpg%3fk%3d1593512032000&ehk=BrQjKnPP0tZsNGodUi3fWBG5b8aD5INOmX%2bFohJcQ7g%3d&risl=&pid=ImgRaw);">
      <span class="card-title">
        <h3>世界鲸鲨日科普宣传活动</h3>
      </span>
    </span>
    <span class="card-summary">
      8月30日是世界鲸鲨日，崇明岛分园举行以“保护鲸鲨，从了解开始”的大型科普宣传日活动，并首次对外公开精密鲸鲨保育系统。
    </span>
  </a>

  <a class="card" href="#">
    <span class="card-header" style="background-image: url(https://www.huanbao-world.com/uploads/allimg/20181222/1545441582802.jpg)">
      <span class="card-title">
        <h3>上海首只大熊猫宝宝</h3>
      </span>
    </span>
    <span class="card-summary">
      上海首只熊猫宝宝在同济大学与游客见面。作为第一批游客，来自上海市社会福利院的小朋友与熊猫宝宝拍下集体黑白萌照，乐翻全场。
    </span>
  </a>

  <a class="card" href="#">
    <span class="card-header" style="background-image: url(https://uploadfile.bizhizu.cn/up/a1/46/1b/a1461b60e0ac0e2d33f033e287cbfe83.jpg);">
      <span class="card-title">
        <h3>同济动物儿童节</h3>
      </span>
    </span>
    <span class="card-summary">
      不同肤色的多国儿童齐聚上海同济大学附属动物园，与百种小动物过六一国际儿童节。
    </span>
  </a>

  <a class="card" href="#">
    <span class="card-header" style="background-image: url(https://tse1-mm.cn.bing.net/th/id/R-C.be7be96d8ab0d8683d6e8b725afcbe7f?rik=hE2estdILHfjig&riu=http%3a%2f%2fpicture.ik123.com%2fuploads%2fallimg%2f131125%2f3-131125133941.jpg&ehk=9K8xSpVNh7W2W1%2b4ONreEdgDRx8ms4uZUH0L9FAupSo%3d&risl=&pid=ImgRaw);">
      <span class="card-title">
        <h3>狐猴三胞胎首展</h3>
      </span>
    </span>
    <span class="card-summary">
      5月8日在同济诞下世界罕见的斑狐猴三胞胎！6月16日，在父亲节来临之际，幸福生活在一起的斑狐猴三胞胎正式跟广大游客见面。
    </span>
  </a>

  <a class="card" href="#">
    <span class="card-header" style="background-image: url(https://www.wse.me/wp-content/uploads/2017/08/20-151212155939.jpg);">
      <span class="card-title">
        <h3>东北虎豹保护资助项目启动</h3>
      </span>
    </span>
    <span class="card-summary">
      同济大学附属动物园宣布东北虎豹保护资助项目的启动。同济基金会主动联系中国野生动物保护协会和东北虎豹国家公园管理局，为东北虎豹的巡山清套活动捐款捐设备共25万人民币。
    </span>
  </a>

  <!-- filler cards prevent the last row of cards from appearing centered: -->
  <span class="filler-card"></span>
  <span class="filler-card"></span>
  <span class="filler-card"></span>
  <span class="filler-card"></span>
  <span class="filler-card"></span>
  <span class="filler-card"></span>
</div>

</template>

<style scoped lang="scss" >
@import url("https://fonts.googleapis.com/css?family=Jaldi|Roboto+Condensed");

body {
	background :#f0f0f0;
	font-size: 15px; 
	line-height: 1;
	font-family: 'Jaldi', sans-serif;
}

.cards {
	display: flex;
	justify-content: center;
	flex-wrap: wrap;
	margin-top: 15px;
	padding: 1.5%;
	box-sizing: border-box;
}

.card, .card * {
	transition: all .2s linear;
}

.card,
.filler-card {
	@media (max-width: 600px) {
		width: 80%;
	}
	position: relative;
	width: 25%;
	margin: 10px;
}

.card {
	background: #fefff9;
	color: #363636; //the whole content of the card becomes linked, so this will give the text a "normal" appearance
	text-decoration: none;
	box-shadow: rgba(black, 0.19) 0 0 8px 0;
	border-radius: 4px;
	padding-bottom: 30px; 
	
	span {
		display: block;
	}
    
	&:hover, &:focus {
		background: white;
	  box-shadow: rgba(0, 0, 0, 0.45) 0px 0px 20px 0px;
		.card-title {
			background: rgba(157, 187, 63, .95);
		}
		.card-meta {
			max-height: 1em;
		}
	}

  img {
    max-width: 100%; // prevent images from breaking out of bounding box
  }
}

.card-summary {
  padding: 5% 5% 3% 5%;
  color: rgb(129, 129, 129);
}

.card-header {
  position: relative;
  padding-bottom: 50%;
  overflow: hidden;
  background-repeat: no-repeat;
  background-size: cover;
  background-position: center;
  background-color: rgba(white,.15);
  background-blend-mode: overlay;
  border-radius: 4px 4px 0 0;
  &:hover, &:focus {
    background-color: rgba(255, 255, 255, 0);
  }
}

.card-title {
  background: rgba(188, 216, 104, 0.85);
  padding: 3.5% 0 2.5% 0;
  color: white;
  font-family: 'Roboto Condensed', sans-serif;
  text-transform: uppercase;
  position: absolute;
  bottom: 0;
  width: 100%;
  h3 {
    font-size: 1.2em;
    line-height: 1.2;
    padding: 0 3.5%;
    margin: 0;
  }
}

.card-meta {
  max-height: 0;
  overflow: hidden;
  color: #666;
  font-size: .78em;
  text-transform: uppercase;
  position: absolute;
  bottom: 2%;
  padding: 0%;
  transition: max-height .4s ease-in-out;
}


</style>