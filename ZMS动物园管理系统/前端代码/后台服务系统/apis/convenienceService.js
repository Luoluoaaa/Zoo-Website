import request from "@/utils/request";
// API: getConvenienceServiceData：获取便民服务信息
// GET, 参数通过Params(URL)传递
export function getConvenienceServiceData(params) {
  return request({
    url: "/api/convenienceService/getConvenienceServiceData",
    method: "get",
    params,
  });
}
// API: createConvenienceServiceInfo：创建便民服务信息
// POST, 参数通过Params(URL)传递
export function createConvenienceServiceInfo(params) {
  return request({
    url: "/api/convenienceService/createConvenienceServiceInfo",
    method: "post",
    params,
  });
}
// API: updateConvenienceServiceInfo：更新便民服务信息
// PUT, 参数通过Params(URL)传递
export function updateConvenienceServiceInfo(params) {
  return request({
    url: "/api/convenienceService/updateConvenienceServiceInfo",
    method: "put",
    params,
  });
}
// API: updateConvenienceServiceInfo：更新便民服务信息
// DELETE, 参数通过Params(URL)传递
export function deleteConvenienceServiceInfo(params) {
  return request({
    url: "/api/convenienceService/deleteConvenienceServiceInfo",
    method: "delete",
    params,
  });
}
