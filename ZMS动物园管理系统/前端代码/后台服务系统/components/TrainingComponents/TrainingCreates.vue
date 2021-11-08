<template>
  <div class="zms-aniShow" :class="nmNightClass">
    <div class="zms-query-filter">
      <!-- 提交进度条 -->
      <v-dialog v-model="submitStat" persistent width="300">
        <v-card>
          <v-card-title> {{ $t("training.Submitting") }}</v-card-title>
          <v-divider />
          <br />
          <v-card-text>
            {{ $t("training.PleaseWait") }}<br />
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
      <!-- 不写备注 -->
      <v-dialog v-model="noNoteWarning" persistent width="500">
        <v-card color="" :ripple="{ class: null }">
          <v-card-title
            class="zms-strip-bg text-h5 text--white orange darken-3"
            color="warning"
          >
            <v-icon color="white"> mdi-alert </v-icon>&nbsp;<span
              class="text--white"
              style="color: #ffffff !important"
            >
              {{ $t("training.NoNoteTitle") }}</span
            >
          </v-card-title>
          <v-divider />
          <br />
          <v-card-text>
            <span class="zms-poptip-body" :class="txNightClass">
              {{ $t("training.NoNoteInfo") }}</span
            >
            <br />
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
              @click="
                noNoteWarning = false;
                submitTrainingInfo();
              "
            >
              <v-icon>mdi-exclamation</v-icon> {{ $t("common.confirm") }}
            </v-btn>
            <v-btn
              class="zms-fullwidth"
              v-bind="attrs"
              light
              color="error"
              v-on="on"
              @click="noNoteWarning = false"
            >
              <v-icon>mdi-arrow-left</v-icon> {{ $t("common.cancel") }}
            </v-btn>
          </v-card-actions>
        </v-card>
      </v-dialog>
      <!-- 提交错误 -->
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
            <span class="zms-poptip-body" :class="txNightClass">
              {{ errorInfo }}</span
            >
            <br />
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
      <v-icon color="primary"> mdi-filter-plus </v-icon>
      <span class="zms-query-title"> {{ $t("training.title") }}</span>

      <div>
        <v-container>
          <v-row>
            <!-- <v-col cols="12" sm="6" md="3">
                            <v-text-field :label="$t('training.ID')" v-model="submit_ID " :placeholder="$t('common.pleaseInput')+$t('training.ID')" prepend-icon="mdi-music-accID ental-sharp"  />
                        </v-col> -->
            <v-col cols="12" sm="6" md="3">
              <v-text-field
                v-model="submit_animal_id"
                :label="$t('training.animal_id')"
                :placeholder="
                  $t('common.pleaseInput') + $t('training.animal_id')
                "
                prepend-icon="el-icon-view"
              />
            </v-col>
            <v-col cols="12" sm="6" md="3">
              <v-text-field
                v-model="submit_trainer_id"
                :label="$t('training.trainer_id')"
                :placeholder="
                  $t('common.pleaseInput') + $t('training.trainer_id')
                "
                prepend-icon="el-icon-s-custom"
              />
            </v-col>
            <v-col cols="12" sm="6" md="3">
              <v-text-field
                v-model="submit_train_site"
                :label="$t('training.train_site')"
                :placeholder="
                  $t('common.pleaseInput') + $t('training.train_site')
                "
                prepend-icon="el-icon-position"
              />
            </v-col>
            <v-col cols="12" sm="6" md="3">
              <v-menu
                v-model="menu2"
                :close-on-content-click="false"
                :nudge-right="40"
                transition="scale-transition"
                offset-y
                min-width="290px"
              >
                <template v-slot:activator="{ on, attrs }">
                  <v-text-field
                    v-model="submit_training_date"
                    :label="$t('training.training_date')"
                    prepend-icon="mdi-calendar"
                    readonly
                    v-bind="attrs"
                    v-on="on"
                  />
                </template>
                <v-date-picker
                  v-model="submit_training_date"
                  color="primary"
                  width="400"
                  @input="menu2 = false"
                />
              </v-menu>
            </v-col>
            <v-col cols="12" sm="6" md="3">
              <v-menu
                v-model="menu3"
                :close-on-content-click="false"
                :nudge-right="40"
                transition="scale-transition"
                offset-y
                min-width="290px"
              >
                <template v-slot:activator="{ on, attrs }">
                  <v-text-field
                    v-model="submit_start_time"
                    :label="$t('training.start_time')"
                    prepend-icon="el-icon-sort-up"
                    readonly
                    v-bind="attrs"
                    v-on="on"
                  />
                </template>
                <v-time-picker
                  v-model="submit_start_time"
                  format="24hr"
                  color="primary"
                  width="400"
                  @input="menu3 = false"
                />
              </v-menu>
            </v-col>
            <v-col cols="12" sm="6" md="3">
              <v-menu
                v-model="menu4"
                :close-on-content-click="false"
                :nudge-right="40"
                transition="scale-transition"
                offset-y
                min-width="290px"
              >
                <template v-slot:activator="{ on, attrs }">
                  <v-text-field
                    v-model="submit_end_time"
                    :label="$t('training.end_time')"
                    prepend-icon="el-icon-sort-up"
                    readonly
                    v-bind="attrs"
                    v-on="on"
                  />
                </template>
                <v-time-picker
                  v-model="submit_end_time"
                  format="24hr"
                  color="primary"
                  width="400"
                  @input="menu4 = false"
                />
              </v-menu>
            </v-col>

            <v-col cols="12" sm="6" md="3">
              <v-text-field
                v-model="submit_skill"
                :label="$t('training.skill')"
                :placeholder="$t('common.pleaseInput') + $t('training.skill')"
                prepend-icon="el-icon-unlock"
              />
            </v-col>
            <v-col cols="12" sm="6" md="3">
              <v-text-field
                v-model="submit_props"
                :label="$t('training.props')"
                :placeholder="$t('common.pleaseInput') + $t('training.props')"
                prepend-icon="el-icon-baseball"
              />
            </v-col>
          </v-row>
        </v-container>
        <v-textarea
          v-model="submit_remarks"
          outlined
          counter
          prepend-inner-icon="mdi-information"
          name="input-7-4"
          :label="$t('training.remarks')"
          :placeholder="$t('common.pleaseInput') + $t('training.remarks')"
        />
        <v-container>
          <v-row>
            <v-col cols="12" sm="6" md="3" />
            <v-col cols="12" sm="6" md="3" />
            <v-col cols="12" sm="6" md="3" />
            <v-col cols="12" sm="6" md="3">
              <v-btn
                :disabled="submitStat"
                block
                class="zms-width"
                color="primary"
                @click="submitPrejudge()"
              >
                <v-icon>mdi-arrow-collapse-up</v-icon>&nbsp;&nbsp;{{
                  $t("common.report")
                }}
              </v-btn>
            </v-col>
          </v-row>
        </v-container>
      </div>
    </div>
  </div>
</template>

<script>
import { createTrainingInfo } from "../../apis/training";

export default {
  name: "TrainingCreates",
  data: () => {
    return {
      submit_ID: null,
      submit_animal_id: null,
      submit_trainer_id: null,
      submit_train_site: null,
      submit_training_date: null,
      submit_start_time: null,
      submit_end_time: null,
      submit_skill: null,
      submit_props: null,
      submit_remarks: null,

      submitNote: null,

      submitStat: false,
      noNoteWarning: false,
      errorReturn: false,
      errorTitle: "",
      errorInfo: "",
      menu2: false,
    };
  },
  computed: {
    nmNightClass() {
      return {
        "zms-background-nm-dark": this.$vuetify.theme.dark,
      };
    },
    txNightClass() {
      return {
        "zms-text-dark": this.$vuetify.theme.dark,
      };
    },
  },
  created() {},
  methods: {
    submitTrainingInfo() {
      this.submitStat = true;
      setTimeout(() => {
        createTrainingInfo({
          training_date: this.submit_training_date,
          skill: this.submit_skill,
          trainer_id: this.submit_trainer_id,
          train_site: this.submit_train_site,
          props: this.submit_props,
          remarks: this.submit_remarks,
          animal_id: this.submit_animal_id,
        })
          .then(() => {
            console.log(this.submitDate);
            this.submitStat = false;
            this.submitSuccTip(this.$t("信息填报成功"));
          })
          .catch((err) => {
            this.queryLoaderDialog = false;
            this.submitStat = false;
            this.$store.dispatch("showToastNotify", {
              type: "error",
              info: this.$t("信息填报失败") + err,
            });
            console.log(err);
          });
      }, 2000);
    },
    submitSuccTip(x) {
      this.$store.dispatch("showToastNotify", { type: "success", info: x });
    },
    submitFailTip(x) {
      this.$store.dispatch("showToastNotify", { type: "error", info: x });
    },
    submitPrejudge() {
      this.submitTrainingInfo();
    },
  },
};
</script>
<style scoped lang="scss">
.zms-query-pagination {
  margin-top: 10px;
  transition: all 0.5s;
}
.zms-query-result {
  margin-top: 20px;
}
.zms-aniShow {
  padding-left: 50px;
  padding-right: 50px;
  padding-top: 20px;
  padding-bottom: 20px;
  background-color: #fafafa;
}
.zms-query-title {
  font-weight: bold;
  letter-spacing: 1px;
  position: relative;
  top: 3px;
}
.zms-query-result-table {
  margin-top: 10px;
}
</style>
