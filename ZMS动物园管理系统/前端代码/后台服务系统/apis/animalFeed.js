import request from "@/utils/request";
// API: getFeedRecord：获取喂养信息
// GET, 参数通过Params(URL)传递
export function getFeedRecord(params) {
  return request({
    url: "/api/animalFeed/getFeedRecord",
    method: "get",
    params,
  });
}
// API: createFeedRecord：创建喂养记录
// POST, 参数通过Data传递
export function createFeedRecord(data) {
  return request({
    url: "/api/animalFeed/createFeedRecord",
    method: "post",
    data,
  });
}
// API: updateFeedRecord：更新喂养记录
// POST, 参数通过Params(URL)传递
export function updateFeedRecord(params) {
  return request({
    url: "/api/animalFeed/updeteFeedRecord",
    method: "post",
    params,
  });
}
// API: deleteFeedRecord：删除喂养记录
// DELETE, 参数通过Params(URL)传递
export function deleteFeedRecord(params) {
  return request({
    url: "/api/animalFeed/deleteFeedRecord",
    method: "delete",
    params,
  });
}
