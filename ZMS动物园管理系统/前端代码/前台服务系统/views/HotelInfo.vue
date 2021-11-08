<!---信息介绍 周边酒店--->
<template>
  <div class="hotel">
    <div class="test">
      <vue-particles
        color="#dedede"
        :particleOpacity="0.7"
        :particlesNumber="80"
        shapeType="circle"
        :particleSize="4"
        linesColor="#dedede"
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
    <div class="block">
      <el-carousel :interval="4000" type="card" height="300px">
        <el-carousel-item v-for="(img,index) in pics" :key="index">
          <img :src="img" />
        </el-carousel-item>
      </el-carousel>
    </div>

    <notice />
    <card />
  </div>
</template>
<script>
import card from "@/components/Card.vue";
import notice from "@/components/Notice.vue";
export default {
  components: {
    card,
    notice,
  },

  methods: {
    //预定酒店接口
    open() {
      this.$confirm("此操作将预定该时间段酒店, 是否继续?", "提示", {
        confirmButtonText: "确定",
        cancelButtonText: "取消",
        type: "warning",
      })
        .then(() => {
          this.$message({
            type: "success",
            message: "预定成功!",
          });
        })
        .catch(() => {
          this.$message({
            type: "info",
            message: "已取消预定",
          });
        });
    },
  },

  data() {
    return {
      pics: [
        "hotel_1.jpg",
        "hotel_2.jpg",
        "hotel_3.jpg",
        "hotel_4.jpg",
      ],
      options: [
        {
          value: "选项1",
          label: "格林豪泰酒店",
        },
        {
          value: "选项2",
          label: "上海虹桥枢纽美居酒店",
        },
        {
          value: "选项3",
          label: "汉庭酒店",
        },
        {
          value: "选项4",
          label: "全季酒店",
        },
      ],
      value: "",
      value1: "",
      value2: "",
    };
  },
};
</script>
<style>
.test {
  position: fixed;
  top: 0px;
  bottom: 0px;
  left: 0px;
  right: 0px;
  z-index: -1;
  background-image: linear-gradient(#f6faeb, #c7effd);
}
.block {
  position: relative;
  left: 60px;
}
</style>