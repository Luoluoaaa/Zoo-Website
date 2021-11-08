<template>
  <div class="zms-widget">
    <iframe
      :src="path"
      scrolling="no"
      allowtransparency="true"
      style="background-color: transparent"
    />
  </div>
</template>
<script>
export default {
  name: "EmbeddedFrame",
  components: {},
  props: {
    path: String,
  },
  methods: {},
};
</script>
<style scoped lang="scss">
.zms-widget {
  z-index: 999999999;
  position: absolute;
  right: 0px;
  bottom: 0px;
  width: 300px;
  height: 300px;
  iframe {
    border: none;
    width: 300px;
    height: 300px;
    //background: cyan;
    height: 100%;
    width: 100%;
    overflow: hidden;
  }
}
</style>
