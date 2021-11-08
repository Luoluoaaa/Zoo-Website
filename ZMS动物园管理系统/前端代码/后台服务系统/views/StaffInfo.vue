<template>
  <div>
    <v-container>
      <v-row>
        <v-col cols="12" lg="3" xl="3"> A </v-col>
        <v-col cols="12" lg="9" xl="9"> B </v-col>
      </v-row>
    </v-container>
  </div>
</template>
<script>
export default {
  name: "StaffInfo",
  created() {
    this.$store.dispatch("alterTopNavTitle", {
      title: this.$store.state.sPageName.account,
    });
  },
};
</script>
<style lang="scss" scoped> </style>
