import request from "@/utils/request";
// API: getStaffList:获取员工列表（该API用于ItemSelector组件)
// GET, 参数通过Params传递
export function getStaffList(params) {
  return request({
    url: "/api/employeeRequest/getEmployeeInfo",
    method: "get",
    params,
  });
}
