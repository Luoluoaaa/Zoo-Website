import Vue from "vue";
import Vuex from "vuex";
Vue.use(Vuex);
let store = new Vuex.Store({
  state: {
    //资源路径
    sAsset_HamburgerImg: "assets/top-navigation-bar-hamburger.png",
    sAsset_SlidebarHeadIcon: "assets/slide-bar-head-icon.png",
    sAsset_WelcomeIcon: "assets/welcome-icon.png",
    sAsset_PageBackground: "assets/background-trial.jpg",
    sAsset_PageBackground2: "assets/background-trial-2.jpg",
    //项目常量
    sProjectName: "ZMS 管理系统",
    sTopBarTitle: "topbar.default",
    sPageName: {
      login: "topbar.login",
      mainPage: "topbar.mainPage",
      animalCare: "topbar.animalCare",
      animalFeed: "topbar.animalFeed",
      animalInfo: "topbar.animalInfo",
      animalRecipe: "topbar.animalRecipe",
      animalReproduction: "topbar.animalReproduction",
      warehouseManagement: "topbar.warehouseManagement",
      warehouseManagement_item: "topbar.warehouseManagement_item",
      warehouseManagement_info: "topbar.warehouseManagement_info",
      warehouseManagement_flowRecord: "topbar.warehouseManagement_flowRecord",
      fundManagement: "topbar.fundManagement",
      procurement: "topbar.procurement",
      animalShowInfoManagement: "topbar.animalShowInfoManagement",
      trainingManagement: "topbar.trainingManagement",
      showTicketManagement: "topbar.showTicketManagement",
      vehicleManagement: "topbar.vehicleManagement",
      gettingAroundZoo: "topbar.gettingAroundZoo",
      convenienceService: "topbar.convenienceService",
      account: "topbar2.account",
      employeeManagement: "员工管理",
      employeeManagement_flowRecord: "新增员工信息",
      employeeManagement_info: "员工信息管理",
      EmployeeItemManagement_item: "员工部门信息管理",
      EmployeeManagement_check: "员工考核",
      venueManagement: "场馆管理",
      admissionTicketManagement: "门票管理",
      GuideItemManagement_item: "导游信息管理",
      VenueExhiManagement_info: "场馆管理",
      EmployeeOutItem: "离职员工管理",
    },
    sProjectFunctions: [
      //{name:'组件示例',route:'',icon:'mdi-puzzle',child:[
      //  {name:'组件示例',route:'/componentView',icon:'mdi-puzzle',child:[]}
      //]},
      {
        name: "navbar.animalManage",
        route: "",
        icon: "mdi-cat",
        child: [
          {
            name: "navbar.anicareManage",
            route: "/animalCareManagement",
            icon: "mdi-needle",
            child: [],
          },
          {
            name: "navbar.aniinfoManage",
            route: "/animalInfoManagement",
            icon: "mdi-information-outline",
            child: [],
          },
          //{name:'navbar.anirecpManage',route:'/animalRecipeManagement',icon:'mdi-food',child:[]},
          {
            name: "navbar.anifeedManage",
            route: "/animalFeedManagement",
            icon: "mdi-food-variant",
            child: [],
          },
          {
            name: "navbar.anibreedManage",
            route: "/animalReproductionManagement",
            icon: "mdi-baby-bottle-outline",
            child: [],
          },
        ],
      },
      {
        name: "navbar.anishowManage",
        route: "",
        icon: "mdi-radio",
        child: [
          {
            name: "navbar.anishowinfManage",
            route: "/showInformationManagement",
            icon: "mdi-information-outline",
            child: [],
          },
          {
            name: "navbar.anitrainManage",
            route: "/trainingManagement",
            icon: "el-icon-document",
            child: [],
          },
        ],
      },
      {
        name: "navbar.ticketManage",
        route: "",
        icon: "mdi-ticket",
        child: [
          {
            name: "navbar.shwtckMan",
            route: "/showTicketManagement",
            icon: "el-icon-s-ticket",
            child: [],
          },
          {
            name: "navbar.admtckMan",
            route: "/ticketsManagement/Admissiontickets",
            icon: "el-icon-tickets",
            child: [],
          },
        ],
      },
      {
        name: "navbar.faclMan",
        route: "",
        icon: "el-icon-school",
        child: [
          {
            name: "navbar.ExhibitionfaclMan",
            route: "/venue/AnimalExhibitionManagement",
            icon: "el-icon-office-building",
            child: [],
          },
        ],
      },
      {
        name: "navbar.fundMan",
        route: "",
        icon: "mdi-sack",
        child: [
          {
            name: "navbar.assetMan",
            route: "/fundManagement",
            icon: "mdi-sack",
            child: [],
          },
          {
            name: "navbar.procMan",
            route: "/procurementManagement",
            icon: "mdi-cart",
            child: [],
          },
        ],
      },
      {
        name: "navbar.wareMan",
        route: "",
        icon: "mdi-database",
        child: [
          {
            name: "navbar.wareMan",
            route: "/warehouseManagement",
            icon: "mdi-database",
            child: [],
          },
        ],
      },
      {
        name: "navbar.perMan",
        route: "",
        icon: "mdi-account-cog",
        child: [
          {
            name: "navbar.perinfMan",
            route: "/employeeManagement",
            icon: "el-icon-user-solid",
            child: [],
          },
          {
            name: "navbar.perChkMan",
            route: "/employeeManagement/check",
            icon: "el-icon-s-check",
            child: [],
          },
        ],
      },
      {
        name: "navbar.guidMan",
        route: "",
        icon: "mdi-account-voice",
        child: [
          {
            name: "navbar.guidMan",
            route: "/guiderManagement",
            icon: "mdi-account-voice",
            child: [],
          },
        ],
      },
      {
        name: "navbar.trafMan",
        route: "",
        icon: "mdi-car-hatchback",
        child: [
          {
            name: "navbar.vehicleMan",
            route: "/vehicleManagement",
            icon: "el-icon-discover",
            child: [],
          },
          {
            name: "navbar.gettingAroundZoo",
            route: "/gettingAroundZoo",
            icon: "el-icon-map-location",
            child: [],
          },
        ],
      },
      {
        name: "navbar.servMan",
        route: "",
        icon: "mdi-bus-stop-covered",
        child: [
          {
            name: "navbar.convenienceService",
            route: "/convenienceService",
            icon: "el-icon-s-grid",
            child: [],
          },
        ],
      },
    ],
    //CSS相关定义
    scSlideBarLeft: 300,
    scSlideBarLeftInitial: 0,
    scSlideBarCalloutStat: 0,
    //CSS相关变量
    sSlideBarLeft: 0,
    bUseL2D: false,
    langOpts: [
      { sw: "简体中文(zh-CN)", cd: "zh-CN", id: 0 },
      { sw: "English(en-US)", cd: "en-US", id: 1 },
    ],
    defaultLang: 0,
  },
  mutations: {
    calloutSlideBar() {
      this.state.scSlideBarCalloutStat = 1 - this.state.scSlideBarCalloutStat;
      if (this.state.scSlideBarCalloutStat === 1) {
        this.state.sSlideBarLeft =
          this.state.scSlideBarLeftInitial + this.state.scSlideBarLeft;
      } else {
        this.state.sSlideBarLeft = this.state.scSlideBarLeftInitial;
      }
    },
    alterTopNavTitle(state, param) {
      state.sTopBarTitle = param.title;
    },
    showToastNotify(state, param) {
      let toastConfig = {
        position: "top-center",
        timeout: 1400,
        closeOnClick: true,
        pauseOnFocusLoss: true,
        pauseOnHover: true,
        draggable: true,
        draggablePercent: 0.6,
        showCloseButtonOnHover: true,
        hideProgressBar: false,
        closeButton: true,
        icon: true,
        rtl: false,
      };
      if (param.type == "error") {
        this._vm.$toast.error(param.info, toastConfig);
      }
      if (param.type == "success") {
        this._vm.$toast.success(param.info, toastConfig);
      }
      if (param.type == "warning") {
        this._vm.$toast.warning(param.info, toastConfig);
      }
      if (param.type == "default") {
        this._vm.$toast(param.info, toastConfig);
      }
    },
  },
  actions: {
    alterTopNavTitle({ commit }, param) {
      commit("alterTopNavTitle", param);
    },
    showToastNotify({ commit }, param) {
      commit("showToastNotify", param);
    },
  },
  modules: {},
});
export default store;
