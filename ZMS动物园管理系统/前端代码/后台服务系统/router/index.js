import Vue from "vue";
import VueRouter from "vue-router";
import Home from "../views/Home.vue";
import AnimalCareManagement from "../views/AnimalCareManagement.vue";
import FundManagement from "../views/FundManagement.vue";
import ProcurementManagement from "../views/ProcurementManagement.vue";
import WarehouseManagement from "../views/WarehouseManagement.vue";
import WarehouseItemManagement from "../views/WarehouseItemManagement.vue";
import WarehouseInfoManagement from "../views/WarehouseInfoManagement.vue";
import WarehouseFlowManagement from "../views/WarehouseFlowManagement.vue";
import AnimalInfoManagement from "../views/AnimalInfoManagement.vue";
import EmployeeManagement from "../views/EmployeeManagement.vue";
import EmployeeFlowManagement from "../views/EmployeeFlowManagement.vue";
import EmployeeInfoManagement from "../views/EmployeeInfoManagement.vue";
import EmployeeItemManagement from "../views/EmployeeItemManagement.vue";
import EmployeeCheck from "../views/EmployeeCheck";
import ShowInformationManagement from "../views/ShowInformationManagement.vue";
import TrainingManagement from "../views/TrainingManagement.vue";
import ShowTicketManagement from "../views/ShowTicketManagement.vue";
import VehicleManagement from "../views/VehicleManagement.vue";
import GettingAroundZoo from "../views/GettingAroundZoo.vue";
import ConvenienceService from "../views/ConvenienceService.vue";
import StaffInfo from "../views/StaffInfo.vue";
import AdmissionTicket from "../views/TicketsAdmmisManagement.vue";
import AnimalExhibition from "../views/VenueExhiManagement.vue";
import VenueItemManagement from "../views/VenueItemManagement.vue";
import GuiderManagement from "../views/GuiderItemManagement.vue";
import AnimalReproductionManagement from "../views/AnimalReproductionManagement.vue";
import AnimalFeedManagement from "../views/AnimalFeedManagement.vue";
import Login from "../views/Login.vue";
Vue.use(VueRouter);
const routes = [
  {
    path: "/",
    name: "Home",
    component: Home,
  },
  {
    path: "/Login",
    name: "Login",
    component: Login,
  },
  {
    path: "/animalReproductionManagement",
    name: "AnimalReproductionManagement",
    component: AnimalReproductionManagement,
  },
  {
    path: "/animalFeedManagement",
    name: "AnimalFeedManagement",
    component: AnimalFeedManagement,
  },
  {
    path: "/ticketsManagement/Admissiontickets",
    name: "AdmissionTicket",
    component: AdmissionTicket,
  },
  {
    path: "/venue/AnimalExhibitionManagement",
    name: "AnimalExhibition",
    component: AnimalExhibition,
  },
  {
    path: "/venue/itemManagement",
    name: "VenueItemManagement",
    component: VenueItemManagement,
  },
  {
    path: "/guiderManagement",
    name: "GuiderManagement",
    component: GuiderManagement,
  },
  {
    path: "/animalCareManagement",
    name: "AnimalCareManagement",
    component: AnimalCareManagement,
  },
  {
    path: "/fundManagement",
    name: "FundManagement",
    component: FundManagement,
  },
  {
    path: "/procurementManagement",
    name: "ProcurementManagement",
    component: ProcurementManagement,
  },
  {
    path: "/warehouseManagement",
    name: "WarehouseManagement",
    component: WarehouseManagement,
  },
  {
    path: "/warehouseManagement/itemManagement",
    name: "WarehouseItemManagement",
    component: WarehouseItemManagement,
  },
  {
    path: "/warehouseManagement/infoManagement",
    name: "WarehouseInfoManagement",
    component: WarehouseInfoManagement,
  },
  {
    path: "/warehouseManagement/flowManagement",
    name: "WarehouseFlowManagement",
    component: WarehouseFlowManagement,
  },
  {
    path: "/animalInfoManagement",
    name: "AnimalInfoManagement",
    component: AnimalInfoManagement,
  },
  {
    path: "/employeeManagement",
    name: "Adddssx",
    component: EmployeeManagement,
  },
  {
    path: "/employeeManagement",
    name: "employeeManagement",
    component: EmployeeManagement,
  },
  {
    path: "/employeeManagement/flowManagement",
    name: "employeeFlowManagement",
    component: EmployeeFlowManagement,
  },
  {
    path: "/employeeManagement/infoManagement",
    name: "employeeInfoManagement",
    component: EmployeeInfoManagement,
  },
  {
    path: "/employeeManagement/itemManagement",
    name: "EmployeeItemManagement",
    component: EmployeeItemManagement,
  },
  {
    path: "/employeeManagement/check",
    name: "EmployeeCheck",
    component: EmployeeCheck,
  },
  {
    path: "/showInformationManagement",
    name: "ShowInformationManagement",
    component: ShowInformationManagement,
  },
  {
    path: "/trainingManagement",
    name: "TrainingManagement",
    component: TrainingManagement,
  },
  {
    path: "/showTicketManagement",
    name: "ShowTicketManagement",
    component: ShowTicketManagement,
  },
  {
    path: "/vehicleManagement",
    name: "VehicleManagement",
    component: VehicleManagement,
  },
  {
    path: "/gettingAroundZoo",
    name: "GettingAroundZoo",
    component: GettingAroundZoo,
  },
  {
    path: "/convenienceService",
    name: "ConvenienceService",
    component: ConvenienceService,
  },
  {
    path: "/account",
    name: "StaffAccount",
    component: StaffInfo,
  },
];
let router = new VueRouter({
  //mode: 'history',
  //base: process.env.BASE_URL,
  base: "zmsoffice",
  routes,
});
router.beforeEach((to, from, next) => {
  let isAuthenticated = localStorage.getItem("zmsToken");
  if (isAuthenticated == "" || isAuthenticated == undefined) {
    isAuthenticated = false;
  } else {
    isAuthenticated = true;
  }
  if (to.name !== "Login" && !isAuthenticated) next({ name: "Login" });
  else if (to.name === "Login" && isAuthenticated) next({ name: "Home" });
  else next();
});
export default router;
