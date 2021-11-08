<!---信息介绍 场馆信息--->
<template>
  <div class="venue">
    <div class="test">
      <vue-particles
        color="#7d60aa"
        :particleOpacity="0.7"
        :particlesNumber="80"
        shapeType="edge"
        :particleSize="3"
        linesColor="#d39ec2"
        :linesWidth="1"
        :lineLinked="true"
        :lineOpacity="0.4"
        :linesDistance="150"
        :moveSpeed="3"
        :hoverEffect="true"
        hoverMode="grab"
        :clickEffect="true"
        clickMode="push"
      >
      </vue-particles>
    </div>
    <el-container>
      <!---图片轮转--->
      <el-header>
        <el-carousel :interval="4000" type="card" height="388px">
          <el-carousel-item v-for="(img, index) in pics" :key="index">
            <img :src="img" />
          </el-carousel-item>
        </el-carousel>
      </el-header>
    </el-container>
    <div style="height: 380px"></div>
    <!---左侧场馆信息查找--->
    <el-container>
      <el-aside>
        <el-col class="sider">
          <h5 style="font-size: 24px; text-align: center; color: gray">
            场馆信息
          </h5>
          <el-menu default-active="2" class="el-menu-vertical-demo">
            <el-submenu index="1">
              <template slot="title">
                <i class="el-icon-location"></i>
                <span>大体情况</span>
              </template>
              <el-menu-item-group>
                <template slot="title">场馆分类</template>
                <el-menu-item
                  index="1-1"
                  @click="
                    area = true;
                    clickHandler2();
                  "
                  >园区</el-menu-item
                >
                <el-menu-item
                  index="1-2"
                  @click="
                    telephone = true;
                    clickHandler2();
                  "
                  >场地管理电话</el-menu-item
                >
              </el-menu-item-group>
              <el-menu-item-group title="状态速览">
                <el-menu-item
                  index="1-3"
                  @click="
                    state = true;
                    clickHandler2();
                  "
                  >暂未开放场馆</el-menu-item
                >
                <el-menu-item
                  index="1-4"
                  @click="
                    price = true;
                    clickHandler2();
                  "
                  >额外票价</el-menu-item
                >
              </el-menu-item-group>
            </el-submenu>
            <el-submenu index="2">
              <template slot="title">
                <i class="el-icon-location"></i>
                <span>详细查找</span>
              </template>
              <el-menu-item-group>
                <template slot="title">步行区</template>
                <el-menu-item
                  index="2-1"
                  @click="
                    dialogTableVisible = true;
                    clickHandler('bird');
                  "
                  >火烈鸟展区</el-menu-item
                >
                <el-menu-item
                  index="2-2"
                  @click="
                    dialogTableVisible = true;
                    clickHandler('大象馆');
                  "
                  >袋鼠坡</el-menu-item
                >
                <el-menu-item
                  index="2-3"
                  @click="
                    dialogTableVisible = true;
                    clickHandler('长颈鹿馆');
                  "
                  >长颈鹿馆</el-menu-item
                >
              </el-menu-item-group>
              <el-menu-item-group title="车入区">
                <el-menu-item
                  index="2-4"
                  @click="
                    dialogTableVisible = true;
                    clickHandler('grass');
                  "
                  >食草动物展区</el-menu-item
                >
                <el-menu-item
                  index="2-5"
                  @click="
                    dialogTableVisible = true;
                    clickHandler('meat');
                  "
                  >猎豹动物展区</el-menu-item
                >
              </el-menu-item-group>
            </el-submenu>
          </el-menu>
        </el-col>
      </el-aside>
      <!---右侧场馆信息介绍--->
      <el-main>
        <el-card style="65%">
          <h1 class="head1">空中缆车</h1>
          <el-row >
            <el-col :span="12">
              <el-card style="width: 400px" shadow="hover" class="cards">
                <div><img src="spot_1.jpg" alt="" width="350px" /></div>
                <h4 class="head4">空中缆车</h4>
                <p>
                  这是在步行观赏、小火车观赏体，长隆打破打传统观赏动物模式，为游客带来全新的观赏体验。
                </p>
              </el-card>
            </el-col>
          </el-row>
          <h1 class="head1">特色小火车</h1>
          <el-row >
            <el-col :span="12">
              <el-card style="width: 400px" shadow="hover" class="cards">
                <div><img src="spot_2.jpg" alt="" width="350px" /></div>
                <h4 class="head4">澳洲森林</h4>
                <p>
                  澳洲是世界最小的大陆，但同时也是世界面积第六大的国家。在充满澳洲特色的桉树林里，居住着世界罕见的珍稀单孔类动物——大赤袋鼠；世界第二大鸟类——鸸鹋，还有远洋而来，优雅的澳洲珍稀——黑天鹅。
                </p>
              </el-card>
            </el-col>

            <el-col :span="12">
              <el-card style="width: 400px" shadow="hover" class="cards">
                <div><img src="spot_3.jpg" alt="" width="350px" /></div>
                <h4 class="head4">美洲丛林</h4>
                <p>
                  穿过带着美洲自由奔放特色的印第安大门，迎接我们的是美洲大地上最大的鸟类——鶆鴁。驾车穿越在盘旋的丛林道路上面，“网络神兽”驼羊就隐藏在这丛林大地之中。不知不觉转个弯，邂逅我们高雅而圣洁的“世界十大爱情鸟”之一——黑颈天鹅。
                </p>
              </el-card>
            </el-col>
          </el-row>
          <br />
          <el-row >
            <el-col :span="12">
              <el-card style="width: 400px" shadow="hover" class="cards">
                <div><img src="spot_4.jpg" alt="" width="350px" /></div>
                <h4 class="head4">南非高原</h4>
                <p>
                  带着放松的心情，重量级的中国三大国宝之一——金牛马上带给你第七站的高原风貌。高原天池里或边上，藏着珍贵的白犀牛，笨重可爱的河马们。在这个广阔的大地上，四处有着剑羚活跃的身影。同是身穿白色大衣的鹈鹕与白天鹅在同一个湖里和谐共处。
                </p>
              </el-card>
            </el-col>

            <el-col :span="12">
              <el-card style="width: 400px" shadow="hover" class="cards">
                <div><img src="spot_5.jpg" alt="" width="350px" /></div>
                <h4 class="head4">东非草原</h4>
                <p>
                  穿越蜿蜒的高原大道，有着世界上独一无二条纹斑马将带给你最后一站的独特见面礼。热情奔放的还有喜爱奔跑却又胆小的非洲鸵鸟，公认有着动物界婀娜身段，优雅姿态的模特——长颈鹿。步履悠闲却又不失优雅的姿态，给你穿越世界五大洲的欢送礼。
                </p>
              </el-card>
            </el-col>
          </el-row>
          <h1 class="head1">步行区</h1>
          <el-row >
            <el-col :span="12">
              <el-card style="width: 400px" shadow="hover" class="cards">
                <div><img src="spot_6.jpg" alt="" width="350px" /></div>
                <h4 class="head4">百虎山</h4>
                <p>
                  白虎是长隆野生动物世界的镇园之宝，也是长隆集团的吉祥物。目前长隆野生动物世界已经拥有超过150多只白虎，被称为世界白虎王国也当之无愧。
                </p>
              </el-card>
            </el-col>

            <el-col :span="12">
              <el-card style="width: 400px" shadow="hover" class="cards">
                <div><img src="spot_7.jpg" alt="" width="350px" /></div>
                <h4 class="head4">长颈鹿广场</h4>
                <p>
                  考拉园对面的长颈鹿广场，这里生活着长颈鹿，他们拥有长长的睫毛，水灵灵的大眼睛以及细长的脖子，修长的大腿，不愧为动物界的顶级模特。考拉园对面的长颈鹿广场，这里生活着长颈鹿，他们拥有长长的睫毛，水灵灵的大眼睛以及细长的脖子，修长的大腿，不愧为动物界的顶级模特。
                </p>
              </el-card>
            </el-col>
          </el-row>
          <br />
          <el-row >
            <el-col :span="12">
              <el-card style="width: 400px" shadow="hover" class="cards">
                <div><img src="spot_8.jpg" alt="" width="350px" /></div>
                <h4 class="head4">金牛岭</h4>
                <p>
                  全新的金牛岭在升级改造后，让游客看金牛的观感更加好了，可以近距离的看到金毛羚牛的阳光照射下，一群金毛羚牛毛色在悠然享受阳光，健康状况良好。
                </p>
              </el-card>
            </el-col>
            <el-col :span="12">
              <el-card style="width: 400px" shadow="hover" class="cards">
                <div><img src="spot_9.jpg" alt="" width="350px" /></div>
                <h4 class="head4">熊猫乐园</h4>
                <p>
                  熊猫村住着全球唯一熊猫三胞胎“萌帅酷”，每天都在嬉嬉闹闹地玩耍。
                </p>
              </el-card>
            </el-col>
            <el-dialog title="具体信息" :visible.sync="dialogTableVisible">
              <el-table :data="list">
                <el-table-column
                  property="introduction"
                  label="场馆简介"
                  width="150"
                ></el-table-column>
                <el-table-column
                  property="location"
                  label="场馆位置"
                  width="150"
                ></el-table-column>
                <el-table-column
                  property="additionalFee"
                  label="额外票价"
                ></el-table-column>
                <el-table-column
                  property="telephone"
                  label="场馆电话"
                ></el-table-column>
                <el-table-column
                  property="touristCapacity"
                  label="最大容量"
                ></el-table-column>
                <el-table-column label="场馆开发状态">{{
                  venuestatus
                }}</el-table-column>
              </el-table>
            </el-dialog>
            <el-dialog title="园区信息" :visible.sync="area">
              <el-table :data="listAll">
                <el-table-column
                  property="name"
                  label="场馆名称"
                ></el-table-column>
                <el-table-column
                  property="zone"
                  label="所属园区"
                ></el-table-column>
              </el-table>
            </el-dialog>
            <el-dialog title="额外票价信息" :visible.sync="price">
              <el-table :data="listAll">
                <el-table-column
                  property="name"
                  label="场馆名称"
                ></el-table-column>
                <el-table-column
                  property="additionalFee"
                  label="额外票价"
                ></el-table-column>
              </el-table>
            </el-dialog>
            <el-dialog title="场馆电话信息" :visible.sync="telephone">
              <el-table :data="listAll">
                <el-table-column
                  property="name"
                  label="场馆名称"
                ></el-table-column>
                <el-table-column
                  property="telephone"
                  label="场地管理电话"
                ></el-table-column>
              </el-table>
            </el-dialog>
            <el-dialog title="开发状态信息" :visible.sync="state">
              <el-table :data="listAll">
                <el-table-column
                  property="name"
                  label="场馆名称"
                ></el-table-column>
                <el-table-column
                  property="status"
                  label="场馆开放状态"
                ></el-table-column>
              </el-table>
            </el-dialog>
          </el-row>
        </el-card>
      </el-main>
    </el-container>
  </div>
</template>
<script>
import { getVenueInfo } from "../api/venue";
import { getAllVenueInfo } from "../api/venueAll";
export default {
  data() {
    return {
      pics: [
       "/venue_1.jpg",
       "venue_2.jpg",
       "venue_3.jpg",
       "venue_4.jpg",
       "venue_5.jpg",
       "venue_6.jpg",
      ],
      list: [],
      listAll: [],
      dialogTableVisible: false,
      area: false,
      price: false,
      telephone: false,
      state: false,
      venuestatus: "",
    };
  },
  methods: {
    clickHandler(x) {
      getVenueInfo({
        name: x,
      })
        .then((response) => {
          this.list = response.data;
          if (response.data[0].status === 1) {
            this.venuestatus = "开放";
          } else {
            this.venuestatus = "关闭";
          }
        })
        .catch(() => {
        });
    },
    clickHandler2() {
      getAllVenueInfo()
        .then((response) => {
          this.listAll = response.data;
        })
        .catch(() => {
        });
    },
  },
};
</script>
<style scoped>
.test {
  position: fixed;
  top: 0px;
  bottom: 0px;
  left: 0px;
  right: 0px;
  z-index: -1;
  background-image: linear-gradient(#f6faeb, #c7effd);
}
.head1 {
  font-size: 30px;
  text-align: center;
  margin-bottom: 20px;
  margin-bottom: 20px;
}
.head4 {
  font-size: 20px;
}
.cards {
  box-shadow: 0 2px 12px 0 rgb(0, 0, 0, 0.1);
}
.sider {
  margin-left: 10px;
  width: 100%;
}
</style>