import request from "@/utils/request";
export function getemployeecheckInfo(params) {
  return request({
    url: "/api/employeeCheckRequest/getEmployeeCheckInfo",
    method: "get",
    params,
  });
}
export function createEmployeecheckInfo(params) {
  return request({
    url: "/api/employeeCheckRequest/createEmployeeCheckInfo",
    method: "post",
    params,
  });
}
export function updateemployeecheckInfo(params) {
  return request({
    url: "/api/employeeCheckRequest/updateEmployeeCheckInfo",
    method: "put",
    params,
  });
}
export function deleteemployeecheckInfo(params) {
  return request({
    url: "/api/employeeCheckRequest/deleteEmployeeCheckInfo",
    method: "delete",
    params,
  });
}
