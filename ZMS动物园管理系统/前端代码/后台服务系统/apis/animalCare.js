import request from "@/utils/request";
// API: getCareData：获取医疗信息
// GET, 参数通过Params(URL)传递
export function getCareData(params) {
  return request({
    url: "/api/animalCare/getCareData",
    method: "get",
    params,
  });
}
// API: createCareInfo：创建医疗信息
// POST, 参数通过Params(URL)传递
export function createCareInfo(params, id) {
  return request({
    url: "/api/animalCare/createCareInfo/" + id,
    method: "post",
    params,
  });
}
// API: getCareData：获取医疗信息
// GET, 参数通过Params(URL)传递
export function updateCareInfo(params) {
  return request({
    url: "/api/animalCare/modifyCareInfo",
    method: "put",
    params,
  });
}
