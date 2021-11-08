import request from "@/utils/request";
// API: getTrainingData:新增训练信息
// GET, 参数通过Params传递
export function getTrainingData(params) {
  return request({
    url: "/api/Training/getTrainingData",
    method: "get",
    params,
  });
}
// API: createTrainingInfo:创建训练信息
// POST, 参数通过Params传递
export function createTrainingInfo(params) {
  return request({
    url: "/api/Training/createTrainingInfo",
    method: "post",
    params,
  });
}
// API: updateTrainingInfo:更新训练信息
// PUT, 参数通过Params传递
export function updateTrainingInfo(params) {
  return request({
    url: "/api/Training/updateTrainingInfo",
    method: "put",
    params,
  });
}
// API: deleteTrainingInfo:删除训练信息
// DELETE, 参数通过Params传递
export function deleteTrainingInfo(params) {
  return request({
    url: "/api/Training/deleteTrainingInfo",
    method: "delete",
    params,
  });
}
