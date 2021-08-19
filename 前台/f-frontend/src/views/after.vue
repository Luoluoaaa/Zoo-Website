<template>
  <div class="menu" style=" margin: auto;  width: 90%; color:grey;overflow:hidden;">

    
        <div class="profile block" >
      <!-- PROFILE (MIDDLE-CONTAINER) -->
      <br>
      <div class="profile-picture big-profile-picture clear" style="position: relative;">
        <img
          width="150px"
          height="150px"
          src="https://i.3kr.com/d/file/hua/20181016/0ac69b972f4245be99596952c74fa9fd.jpg"
        />
      </div>
      <h1 class="user-name" style="position: relative  ; ">{{userName}}</h1>
      <p style=" font-size: 15px; position: relative;left:6%;top:-3%; color:#8BAD68;line-height:1.8;text-align:justify;letter-spacing:5px;"> 
        I  D:<br>姓名:</p>
        <p style=" font-size: 15px; position: relative;left:51%;top:-19%; color:#8BAD68;line-height:1.8;text-align:justify;letter-spacing:5px;"> 
        年龄:</br>手机:</p>
      <p style=" font-size: 15px; position: relative;left:21%;top:-36.5%; color:grey;line-height:1.8;text-align:justify;letter-spacing:1px;">
        {{ID}}<br>{{realName}}</p>
         <p style=" font-size: 15px; position: relative;left:66%;top:-53%; color:grey;line-height:1.8;text-align:justify;letter-spacing:1px;">
        {{age}}</br>{{tel}}</p>
    </div>
    <el-button style="font-size: 17px; position :relative;left:40%;top:-40px;text-align:center" type="text" @click="ifout" >退出登录</el-button>
    
        <div class="menu-box block" style="text-align:left;">
      <!-- MENU BOX (LEFT-CONTAINER) -->
      <h1 style="color:white" class="titular" >MENU BOX</h1>
      <ul class="menu-box-menu">
        <li>
          <aa class="menu-box-tab" href="#6"
            ><span1 class="icon fontawesome-envelope scnd-font-color"></span1
            >消息
            <div class="menu-box-number">4</div></aa
          >
        </li>
        <li>
          <aa class="menu-box-tab" href="#8"
            ><span1 class="icon entypo-paper-plane scnd-font-color"></span1
            >订单
            <div class="menu-box-number">3</div></aa
          >
        </li>
        <li>
          <aa class="menu-box-tab" href="#10"
            ><span1 class="icon entypo-calendar scnd-font-color"></span1>活动
            <div class="menu-box-number">5</div></aa
          >
        </li>
        <li>
          <aa class="menu-box-tab" href="#12"
            ><span1 class="icon entypo-cog scnd-font-color"></span1>设置</aa
          >
        </li>
        <li>
          <aa class="menu-box-tab" href="#13"
            ><span1 class="icon entypo-chart-line scnd-font-color"></span1
            >数据</aa
          >
        </li>
      </ul>
    </div>


    <div class="calendar-day block">
      <!-- CALENDAR DAY (RIGHT-CONTAINER) -->
      <div class="arrow-btn-container">
        <h1 style="color:white" class="titular">{{weekDay}}</h1>
      </div>
      <br />
      <p class="the-day" style="color:#8BAD68">{{datetody}}</p>
      </div>
    <div class="calendar-month block">
      <!-- CALENDAR MONTH (RIGHT-CONTAINER) -->
      <div class="arrow-btn-container">
        <h1 style="color:white" class="titular">{{Month}} {{Year}}</h1>
      </div>
      <table class="calendar">
        <thead class="days-week">
          <tr>
            <th>S</th>
            <th>M</th>
            <th>T</th>
            <th>W</th>
            <th>R</th>
            <th>F</th>
            <th>S</th>
          </tr>
        </thead>
        <tbody>
          <tr>
            <td></td>
            <td></td>
            <td></td>
            <td></td>

            <td><aa class="scnd-font-color" href="#100">1</aa></td>

            <td><aa class="scnd-font-color" href="#101">2</aa></td>
            <td><aa class="scnd-font-color" href="#102">3</aa></td>
                      </tr>
          <tr>
            <td><aa class="scnd-font-color" href="#103">4</aa></td>
            <td><aa class="scnd-font-color" href="#104">5</aa></td>
            <td><aa class="scnd-font-color" href="#105">6</aa></td>
            <td><aa class="scnd-font-color" href="#106">7</aa></td>
            <td><aa class="scnd-font-color" href="#107">8</aa></td>

            <td><aa class="scnd-font-color" href="#108">9</aa></td>
            <td><aa class="scnd-font-color" href="#109">10</aa></td>
                      </tr>
          <tr>
            <td><aa class="scnd-font-color" href="#110">11</aa></td>
            <td><aa class="scnd-font-color" href="#111">12</aa></td>
            <td><aa class="scnd-font-color" href="#112">13</aa></td>
            <td><aa class="scnd-font-color" href="#113">14</aa></td>
            <td><aa class="scnd-font-color" href="#114">15</aa></td>

            <td><aa class="today" href="#115"> 16</aa></td>
            <td><aa href="#116">17</aa></td>
                      </tr>
          <tr>
            <td><aa href="#117">18</aa></td>
            <td><aa href="#118">19</aa></td>
            <td><aa href="#119">20</aa></td>
            <td><aa href="#120">21</aa></td>
            <td><aa href="#121">22</aa></td>

            <td><aa href="#122">23</aa></td>
            <td><aa href="#123">24</aa></td>
                                  </tr>
          <tr>
            <td><aa href="#124">25</aa></td>
            <td><aa href="#125">26</aa></td>
            <td><aa href="#126">27</aa></td>
            <td><aa href="#127">28</aa></td>
            <td><aa href="#128">29</aa></td>
            <td><aa href="#129">30</aa></td>
            <td><aa href="#129">31</aa></td>
          </tr>
        </tbody>
      </table>
    </div>
  </div>
</template>

<style scoped>
/************************************ FONTS ************************************/
@import url(https://fonts.googleapis.com/css?family=Ubuntu:400,700);
@import url(https://weloveiconfonts.com/api/?family=entypo|fontawesome|zocial);
/* entypo */
[class*="entypo-"]:before {
  font-family: "entypo", sans-serif;
}
/* fontawesome */
[class*="fontawesome-"]:before {
  font-family: "FontAwesome", sans-serif;
}
/* zocial */
[class*="zocial-"]:before {
  font-family: "zocial", sans-serif;
}
@font-face {
  font-family: "icomoon";
  src: url("https://jlalovi-cv.herokuapp.com/font/icomoon.eot");
  src: url("https://jlalovi-cv.herokuapp.com/font/icomoon.eot?#iefix")
      format("embedded-opentype"),
    url("https://jlalovi-cv.herokuapp.com/font/icomoon.ttf") format("truetype"),
    url("https://jlalovi-cv.herokuapp.com/font/icomoon.woff") format("woff"),
    url("https://jlalovi-cv.herokuapp.com/font/icomoon.svg#icomoon")
      format("svg");
  font-weight: normal;
  font-style: normal;
}

[class^="icon-"],
[class*=" icon-"] {
  font-family: "icomoon";
  font-style: normal;
  font-weight: normal;
  font-variant: normal;
  text-transform: none;
  line-height: 1;

  /* Better Font Rendering =========== */
  -webkit-font-smoothing: antialiased;
  -moz-osx-font-smoothing: grayscale;
}
.icon-cloudy:before {
  content: "\e60f";
}
.icon-sun:before {
  content: "\e610";
}
.icon-cloudy2:before {
  content: "\e611";
}
/************************************* END FONTS *************************************/

* {
  -webkit-box-sizing: border-box;
  -moz-box-sizing: border-box;
  box-sizing: border-box;
}

.body {
  background: #f9fdec;
}

.ul {
  list-style-type: none;
  margin: 0;
  padding-left: 0;
}

.h1 {
  font-size: 23px;
      color: rgb(255, 255, 255);
}

.h2 {
  font-size: 17px;
      color: rgb(255, 255, 255);
}

.p {
  font-size: 15px;
      color: rgb(255, 255, 255);
}

.a {
  text-decoration: none;
  font-size: 15px;
      color: rgb(255, 255, 255);
}
.a:hover {
  text-decoration: underline;
}


.h2,
.p,
aa{
  color: #8bad68;
}
span1 {
  color:  #8bad68;
}
.scnd-font-color {
  color: gery;
}

.input-container {
  position: relative;
}
input[type="text"] {
  width: 260px;
  height: 50px;
  margin-left: 20px;
  margin-bottom: 20px;
  padding-left: 45px;
  background: #747474;
  color: #fff;
  border: solid 1px #696969;
  border-radius: 5px;
}
input[type="text"]::-webkit-input-placeholder {
  /* WebKit browsers */
  color: #fff;
}
input[type="text"]:-moz-input-placeholder {
  /* Mozilla Firefox 4 to 18 */
  color: #fff;
}
input[type="text"]::-moz-input-placeholder {
  /* Mozilla Firefox 19+ */
  color: #fff;
}
input[type="text"]:-ms-input-placeholder {
  /* Internet Explorer 10+ */
  color: #fff;
}
input[type="text"]:focus {
  outline: none; /* removes the default orange border when focus */
  border: 1px solid #ddfeff;
}
.input-icon {
  font-size: 22px;
  position: absolute;
  left: 31px;
  top: 10px;
}
.input-icon.password-icon {
  left: 35px;
}

.horizontal-list {
  margin: 0;
  padding: 0;
  list-style-type: none;
}
.horizontal-list li {
  float: left;
}

.clear {
  clear: both;
}

.icon {
  font-size: 25px;
}

.titular {
  display: block;
  line-height: 60px;
  margin: 0;
  text-align: center;
  border-top-left-radius: 5px;
  border-top-right-radius: 5px;
}

.button {
  display: block;
  width: 175px;
  line-height: 50px;
  font-size: 16px;
  font-weight: 700;
  text-align: center;
  margin: 0 auto;
  border-radius: 5px;
  -webkit-transition: background 0.3s;
  transition: background 0.3s;
}
.button:hover {
  text-decoration: none;
}

.arrow-btn-container {
  position: relative;
}
.arrow-btn {
  position: absolute;
  display: block;
  width: 60px;
  height: 60px;
  -webkit-transition: background 0.3s;
  transition: background 0.3s;
}
.arrow-btn:hover {
  text-decoration: none;
}
.arrow-btn.left {
  border-top-left-radius: 5px;
}
.arrow-btn.right {
  border-top-right-radius: 5px;
  right: 0;
  top: 0;
}
.arrow-btn .icon {
  display: block;
  font-size: 18px;
  border: 2px solid #fff;
  border-radius: 100%;
  line-height: 17px;
  width: 21px;
  margin: 20px auto;
  text-align: center;
}
.arrow-btn.left .icon {
  padding-right: 2px;
}

.profile-picture {
  border-radius: 100%;
  overflow: hidden;
  -webkit-box-sizing: content-box;
  -moz-box-sizing: content-box;
  box-sizing: content-box;
}

.big-profile-picture {
  margin: 0 auto;
  border: 5px solid #e1fcc6;
  width: 150px;
  height: 150px;
}
.small-profile-picture {
  border: 2px solid #8bad68;
  width: 40px;
  height: 40px;
}

/** MAIN CONTAINER **/

.main-container {
  font-family: "Ubuntu", sans-serif;
  width: 950px;
  height: 1725px;
  margin: 6em auto;
}

/** CONTAINERS **/
.container {
  float: left;
  width: 300px;
}
.block {
  margin-bottom: 25px;
  background: rgb(255, 255, 255);
  border-radius: 5px;
  
}
/******************************************** LEFT CONTAINER *****************************************/
.menu-box {
  height: 360px;
  background: rgb(244, 255, 236);
}
.menu-box .titular {
  background: #8bad68;
}
.menu-box-menu .icon {
  display: inline-block;
  vertical-align: top;
  width: 28px;
  margin-left: 20px;
  margin-right: 15px;
}
.menu-box-number {
  width: 36px;
  line-height: 22px;
  background: #ffffff;
  text-align: center;
  border-radius: 15px;
  position: absolute;
  top: 15px;
  right: 15px;
  -webkit-transition: all 0.3s;
  transition: all 0.3s;
}
.menu-box-menu li {
  color:#fff;
  height: 60px;
  position: relative;
}
.menu-box-tab {
  line-height: 60px;
  display: block;
  border-bottom: 1px solid #aed386;
  -webkit-transition: background 0.2s;
  transition: background 0.2s;
}
.menu-box-tab:hover {
  background: #c2e59c;
  border-top: 1px solid #c2e59c;
  text-decoration: none;
}
.menu-box-tab:hover .icon {
  color: #fff;
}
.menu-box-tab:hover .menu-box-number {
  background: #9aad85;
  color: white;
}
/************************************************** MIDDLE CONTAINER **********************************/
.middle-container {
  margin: 0 0px;
  background: #aed386;
}
.middle-container.titular {
  background: #8bad68;
}
.profile {
  height: 320px;
}
.user-name {
  margin: 25px 0 16px;
  text-align: center;
  color: #8bad68;
}
.profile-description {
  width: 210px;
  margin: 0 auto;
  text-align: center;
}
.profile-options {
  padding-top: 23px;
}
.profile-options li {
  border-left: 1px solid #8bad68;
}
.profile-options p {
  margin: 0;
}
.profile-options a {
  display: block;
  width: 99px;
  line-height: 60px;
  text-align: center;
  -webkit-transition: background 0.3s;
  transition: background 0.3s;
}
/********************************************* RIGHT CONTAINER ****************************************/

.calendar-day {
  height: 280px;
  background: rgb(244, 255, 236);
}
.calendar-day .titular {
  background: #8bad68;
}

.calendar-day .the-day {
  margin: 0;
  text-align: center;
  font-size: 120px;
}
.add-event.button {
  background: #e0ffc2;
}
.add-event.button:hover {
  background: #395e1b;
}
.calendar-month {
  height: 340px;
  background: rgb(244, 255, 236);
}
.calendar-month .titular {
  background: #aed386;
}
.calendar-month .arrow-btn:hover {
  background: #8bad68;
}
.calendar {
  margin: 10px 10px;
  text-align: center;
}
.calendar a {
  font-size: 17px;
}
.calendar td,
.calendar th {
  width: 48px;
  height: 40px;
}
.calendar .days-week {
  color: #8bad68;
}
.calendar .today {
  display: block;
  margin-left: 5px;
  width: 34px;
  line-height: 34px;
  background: #8bad68;
  border-radius: 100%;
  color:#fff;
}
</style>

<script>
import Utils from "../utils/utils";

var d = new Date();

var weekday = new Array(7);
weekday[0] = "SUNDAY";
weekday[1] = "MONDAY";
weekday[2] = "TUESDAY";
weekday[3] = "WEDNESDAY";
weekday[4] = "THURSDAY";
weekday[5] = "FRIDAY";
weekday[6] = "SATURDAY";

var month = new Array(12);
month[0] = "JANRARY";
month[1] = "FEBRARY";
month[2] = "MARCH";
month[3] = "APRIL";
month[4] = "MAY";
month[5] = "JUNE";
month[6] = "JULY";
month[7] = "AUGEST";
month[8] = "SEPTEMBER";
month[9] = "OCTOBOR";
month[10] = "NOVEMBER";
month[11] = "DECEMBER";

export default {
  data() {
    return {
      userName: localStorage.getItem("name"),
      ID: localStorage.getItem("ID"),
      realName: localStorage.getItem("realname"),
      age: localStorage.getItem("age"),
      tel: localStorage.getItem("tel"),
      weekDay: weekday[d.getDay()],
      Month: month[d.getMonth()],
      Year: d.getFullYear(),
      datetody: d.getDate(),
    };
  },

  methods: {

    ifout(){
      localStorage.removeItem("zmsToken");
      this.closeA();
      console.log(this.drawer);
      this.gotoLogin();

    },
    closeA(){
      Utils.$emit('drawer','param'); 
    },
    gotoHome() {
      this.$router.push("/");
    },
    gotoLogin() {
      this.$router.push("/Login");
    },
  },
};
</script>