import request from "@/utils/request";
// API: getEmployeeItemInfo:获取员工信息
// GET, 参数通过Params(URL)传递
export function getEmployeeItemInfo(params) {
  return request({
    url: "/api/employeeRequest/getEmployeeInfo",
    method: "get",
    params,
  });
}
// API: updateEmployeeItemInfo:更新员工信息
// PUT, 参数通过Params(URL)传递
export function updateEmployeeItemInfo(params) {
  return request({
    url: "/api/employeeRequest/updateEmployeeInfo",
    method: "put",
    params,
  });
}
// API: createEmployeeInfo:创建员工信息
// POST, 参数通过Params(URL)传递
export function createEmployeeInfo(params) {
  return request({
    url: "/api/employeeRequest/createEmployeeInfo",
    method: "post",
    params,
  });
}
// API: deleteEmployeeInfo:删除员工信息
// DELETE, 参数通过Params(URL)传递
export function deleteEmployeeInfo(params) {
  return request({
    url: "/api/employeeRequest/deleteEmployeeInfo",
    method: "delete",
    params,
  });
}
