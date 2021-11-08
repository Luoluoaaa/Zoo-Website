<template>
  <div class="zms-home-notice">
    <span>下方列出了园区内所有员工信息</span>
    <v-btn color="primary" text @click="goto()"> 编辑和查看员工信息列表 </v-btn>
    <v-container>
      <v-row>
        <v-col
          v-for="item in employeeInfoDetail"
          :key="item.id"
          cols="12"
          md="4"
          class="align-self-stretch"
        >
          <v-card
            :class="cardNightClass"
            :ripple="{ class: null }"
            class="mx-auto"
            max-width="400"
          >
            <v-img
              class="white--text align-end"
              height="200px"
              src="data:image/jpeg;base64,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"
            >
              <v-card-title> {{ item.name }}</v-card-title>
              <v-card-subtitle class="pb-0">
                <b>编号:</b> {{ item.id }}
              </v-card-subtitle>
            </v-img>
            <v-card-subtitle class="text--primary pb-0">
              <b>年龄:</b>
              {{ item.age }}
            </v-card-subtitle>
            <v-card-subtitle class="text--primary pb-0">
              <b>职务:</b>
              {{ item.position }}
            </v-card-subtitle>
            <v-card-subtitle class="text--primary pb-0">
              <b>性别:</b>
              {{ item.gender }}
            </v-card-subtitle>
            <v-card-subtitle class="text--primary pb-0">
              <b>工资:</b>
              {{ item.wage }}
            </v-card-subtitle>
            <v-card-subtitle class="text--primary pb-0">
              <b>所属园区:</b>
              {{ item.park }}
            </v-card-subtitle>
            <v-card-actions> </v-card-actions>
          </v-card>
        </v-col>
      </v-row>
    </v-container>
    <v-dialog v-model="newDialog" persistent max-width="600px">
      <v-card :ripple="{ class: null }">
        <v-card-title
          class="zms-strip-bg text-h5 text--white primary"
          color="warning"
        >
          <v-icon color="white"> mdi-plus-thick </v-icon>&nbsp;<span
            class="text--white"
            style="color: #ffffff !important"
          >
            {{ $t("employee.Info.new") }}</span
          >
        </v-card-title>
        <v-card-text>
          <v-container>
            <v-row>
              <v-col cols="12" lg="12">
                <v-text-field
                  v-model="alterItem.id"
                  :label="$t('employee.Info.wareid')"
                />
              </v-col>
              <v-col cols="12" lg="12">
                <v-text-field
                  v-model="alterItem.storage_name"
                  :label="$t('employee.Info.wareName')"
                />
              </v-col>
              <v-col cols="12" lg="12">
                <v-text-field
                  v-model="alterItem.storage_location"
                  :label="$t('employee.Info.wareLocation')"
                />
              </v-col>
            </v-row>
          </v-container>
        </v-card-text>
        <v-card-actions>
          <v-spacer />
          <v-btn
            class="zms-fullwidth"
            v-bind="attrs"
            light
            color="primary"
            v-on="on"
            @click="newDialog = false"
          >
            <v-icon>mdi-close</v-icon> {{ $t("common.cancel") }}
          </v-btn>
          <v-btn
            class="zms-fullwidth"
            v-bind="attrs"
            light
            color="success"
            v-on="on"
            @click="updateInfo()"
          >
            <v-icon>mdi-check</v-icon> {{ $t("common.confirm") }}
          </v-btn>
        </v-card-actions>
      </v-card>
    </v-dialog>
    <v-dialog v-model="alterDialog" persistent max-width="600px">
      <v-card :ripple="{ class: null }">
        <v-card-title
          class="zms-strip-bg text-h5 text--white primary"
          color="warning"
        >
          <v-icon color="white"> mdi-pen </v-icon>&nbsp;<span
            class="text--white"
            style="color: #ffffff !important"
          >
            {{ $t("employee.Info.alter") }}</span
          >
        </v-card-title>
        <v-card-text>
          <v-container>
            <v-row>
              <v-col cols="12" lg="12">
                <v-text-field
                  v-model="alterItem.id"
                  disabled
                  :label="$t('employee.Info.wareid')"
                />
              </v-col>
              <v-col cols="12" lg="12">
                <v-text-field
                  v-model="alterItem.storage_name"
                  :label="$t('employee.Info.wareName')"
                />
              </v-col>
              <v-col cols="12" lg="12">
                <v-text-field
                  v-model="alterItem.storage_location"
                  :label="$t('employee.Info.wareLocation')"
                />
              </v-col>
            </v-row>
          </v-container>
        </v-card-text>
        <v-card-actions>
          <v-spacer />
          <v-btn
            class="zms-fullwidth"
            v-bind="attrs"
            light
            color="primary"
            v-on="on"
            @click="alterDialog = false"
          >
            <v-icon>mdi-close</v-icon> {{ $t("common.cancel") }}
          </v-btn>
          <v-btn
            class="zms-fullwidth"
            v-bind="attrs"
            light
            color="success"
            v-on="on"
            @click="updateInfo()"
          >
            <v-icon>mdi-check</v-icon> {{ $t("common.confirm") }}
          </v-btn>
        </v-card-actions>
      </v-card>
    </v-dialog>
    <v-dialog v-model="queryLoaderDialog" persistent width="300">
      <v-card color="">
        <v-card-title>正在查找</v-card-title>
        <v-divider />
        <br />
        <v-card-text>
          请稍后<br />
          <br />
          <v-progress-linear
            indeterminate
            striped
            color="primary"
            class="mb-0"
          />
        </v-card-text>
      </v-card>
    </v-dialog>
    <v-dialog v-model="submitStat" persistent width="300">
      <v-card>
        <v-card-title> {{ $t("animalCare.Submitting") }}</v-card-title>
        <v-divider />
        <br />
        <v-card-text>
          {{ $t("animalCare.PleaseWait") }}<br />
          <br />
          <v-progress-linear
            indeterminate
            striped
            color="primary"
            class="mb-0"
          />
        </v-card-text>
      </v-card>
    </v-dialog>
    <v-dialog v-model="errorReturn" persistent width="500">
      <v-card color="" :ripple="{ class: null }">
        <v-card-title
          class="zms-strip-bg text-h5 text--white red"
          color="warning"
        >
          <v-icon color="white"> mdi-close-thick </v-icon>&nbsp;<span
            class="text--white"
            style="color: #ffffff !important"
          >
            {{ errorTitle }}</span
          >
        </v-card-title>
        <v-divider />
        <br />
        <v-card-text>
          <span class="zms-poptip-body"> {{ errorInfo }}</span> <br />
          <br />
        </v-card-text>
        <v-divider />
        <v-card-actions>
          <v-spacer />
          <v-btn
            class="zms-fullwidth"
            v-bind="attrs"
            light
            color="primary"
            v-on="on"
            @click="errorReturn = false"
          >
            <v-icon>mdi-exclamation</v-icon> {{ $t("common.confirm") }}
          </v-btn>
        </v-card-actions>
      </v-card>
    </v-dialog>
  </div>
</template>
<script>
import { getEmployeeItemInfo } from "../../apis/employee.js";
export default {
  name: "EmployeeInfo",
  components: {},
  props: {
    drawer: Boolean,
  },
  data: () => {
    return {
      queryLoaderDialog: true,
      employeeInfoDetail: [],
      alterDialog: false,
      alterId: -1,
      alterItem: {},
      submitStat: false,
      errorReturn: false,
      newDialog: false,
      errorTitle: "",
      errorInfo: "",
    };
  },
  computed: {
    cardNightClass() {
      return {
        "zms-cardcolor-light": !this.$vuetify.theme.dark,
        "zms-cardcolor-dark": this.$vuetify.theme.dark,
      };
    },
    nmNightClass() {
      return {
        "zms-background-nm-dark": this.$vuetify.theme.dark,
      };
    },
  },
  created() {
    this.fetchWarehouseInfo();
  },
  methods: {
    openDialog(id) {
      this.alterDialog = true;
      this.alterId = id;
      this.alterItem = this.employeeInfoDetail[id];
    },
    fetchWarehouseInfo() {
      this.queryLoaderDialog = true;
      setTimeout(() => {
        getEmployeeItemInfo()
          .then((response) => {
            this.employeeInfoDetail = response.data;
            this.queryLoaderDialog = false;
            this.$store.dispatch("showToastNotify", {
              type: "success",
              info: this.$t("employee.Info.queryDone"),
            });
            let i = 0;
            for (; i < this.employeeInfoDetail.length; i++) {
              this.employeeInfoDetail[i].dialogOpen = false;
              this.employeeInfoDetail[i].sid = i;
            }
          })
          .catch(() => {
            this.queryLoaderDialog = false;
          });
      }, 1000);
    },
    gotoItem() {
      this.$store.dispatch("showToastNotify", {
        type: "default",
        info: this.$t("employee.Info.search"),
      });
      this.$router.push({
        name: "EmployeeItemManagement",
        params: { id: "11" },
      });
    },
    goto() {
      this.$store.dispatch("showToastNotify", {
        type: "default",
        info: this.$t("employee.Info.search"),
      });
      this.$router.push({ path: "/employeeManagement/itemManagement" });
    },
  },
};
</script>
<style scoped lang="scss">
.zms-stat {
  font-family: "benderregular";
  font-size: 25px;
}
.zms-home-notice {
  margin: 0px 20px 0px 20px;
  padding-top: 10px;
  padding-bottom: 10px;
}
.zms-home-center {
  text-align: center;
}
.zms-card-noborder {
  border-width: 0px;
}
.zms-home-title2 {
  font-size: 18px;
  font-weight: bold;
  display: block;
}
.zms-home-body {
  margin-left: 7%;
  margin-right: 7%;
  padding-top: 10px;
  padding-bottom: 10px;
}
.zms-home-body2 {
  margin-left: 5%;
  margin-right: 5%;
  padding-top: 20px;
  padding-bottom: 10px;
}
</style>
