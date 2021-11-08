import request from "@/utils/request";
// API: getAdmissData:获取门票信息
// GET, 参数通过Params传递
export function getAdmissData(params) {
  return request({
    url: "/api/TicketsAdmiss/getAdmissData",
    method: "get",
    params,
  });
}
// API: createAdmissInfo:创建门票信息
// POST, 参数通过Params传递
export function createAdmissInfo(params) {
  return request({
    url: "/api/admissionT/createAdmissInfo",
    method: "post",
    params,
  });
}
// API: updateAdmissInfo:更新门票信息
// PUT, 参数通过Params传递
export function updateAdmissInfo(params) {
  return request({
    url: "/api/TicketsAdmiss/updateAdmissInfo",
    method: "put",
    params,
  });
}
// API: deleteAdmissInfo:删除门票信息
// DELETE, 参数通过Params传递
export function deleteAdmissInfo(params) {
  return request({
    url: "/api/TicketsAdmiss/deleteAdmissInfo",
    method: "delete",
    params,
  });
}
