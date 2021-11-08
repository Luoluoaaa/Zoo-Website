import request from "@/utils/request";
// API: getvenueItemInfo:更新场馆项目信息
// GET, 参数通过Params传递
export function getVenueItemInfo(params) {
  return request({
    url: "/api/venueRequest/getvenueItemInfo",
    method: "get",
    params,
  });
}
// API: updatevenueItemInfo:修改场馆项目信息
// PUT, 参数通过Params传递
export function updateVenueItemInfo(params) {
  return request({
    url: "/api/venueRequest/updatevenueItemInfo",
    method: "put",
    params,
  });
}
// API: createvenueItemInfo:创建场馆项目信息
// POST, 参数通过Params传递
export function createVenueItemInfo(params) {
  return request({
    url: "/api/venueRequest/creatsvenueItemInfo",
    method: "post",
    params,
  });
}
// API: deleteVenueItemInfo:删除场馆项目信息
// DELETE, 参数通过Params传递
export function deleteVenueItemInfo(params) {
  return request({
    url: "/api/venueRequest/deletevenueItemInfo",
    method: "delete",
    params,
  });
}
