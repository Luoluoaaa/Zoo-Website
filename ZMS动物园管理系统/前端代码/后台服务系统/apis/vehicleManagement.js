import request from "@/utils/request";
// API: getVehicleManagementData:获取交通信息
// DELETE, 参数通过Params传递
export function getVehicleManagementData(params) {
  return request({
    url: "/api/vehicleManagement/getVehicleManagementData",
    method: "get",
    params,
  });
}
// API: createVehicleManagementInfo:创建交通信息
// POST, 参数通过Params传递
export function createVehicleManagementInfo(params) {
  return request({
    url: "/api/vehicleManagement/createVehicleManagementInfo",
    method: "post",
    params,
  });
}
// API: updateVehicleManagementInfo:更新交通信息
// PUT, 参数通过Params传递
export function updateVehicleManagementInfo(params) {
  return request({
    url: "/api/vehicleManagement/updateVehicleManagementInfo",
    method: "put",
    params,
  });
}
// API: deleteVehicleManagementInfo:删除交通信息
// DELETE, 参数通过Params传递
export function deleteVehicleManagementInfo(params) {
  return request({
    url: "/api/vehicleManagement/deleteVehicleManagementInfo",
    method: "delete",
    params,
  });
}
