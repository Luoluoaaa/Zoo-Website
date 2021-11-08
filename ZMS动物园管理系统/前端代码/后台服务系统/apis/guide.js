import request from "@/utils/request";
// API: getguideItemInfo:获取导游信息
// GET, 参数通过Params传递
export function getguideItemInfo(params) {
  return request({
    url: "/api/guideRequest/getGuideInfo",
    method: "get",
    params,
  });
}
// API: updateguideItemInfo:更新导游信息
// PUT, 参数通过Params传递
export function updateguideItemInfo(params) {
  return request({
    url: "/api/guideRequest/updateGuideInfo",
    method: "put",
    params,
  });
}
