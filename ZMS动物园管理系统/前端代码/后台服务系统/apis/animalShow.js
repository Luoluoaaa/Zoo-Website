import request from "@/utils/request";
// API: getinformation：获取演出信息
// GET, 参数通过Params(URL)传递
export function getShowData(params) {
  return request({
    url: "/api/animalShow/getShowData",
    method: "get",
    params,
  });
}
// API: createShowInfo：创建演出信息
// POST, 参数通过Params(URL)传递
export function createShowInfo(params) {
  return request({
    url: "/api/animalShow/createShowInfo",
    method: "post",
    params,
  });
}
// API: updateShowInfo：更新演出信息
// PUT, 参数通过Params(URL)传递
export function updateShowInfo(params) {
  return request({
    url: "/api/animalShow/updateShowInfo",
    method: "put",
    params,
  });
}
// API: deleteShowInfo：删除演出信息
// POST, 参数通过Params(URL)传递
export function deleteShowInfo(params) {
  return request({
    url: "/api/animalShow/deleteShowInfo",
    method: "delete",
    params,
  });
}
