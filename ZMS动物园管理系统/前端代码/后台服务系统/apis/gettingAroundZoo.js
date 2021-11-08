import request from "@/utils/request";
// API: getGettingAroundZooFlowInfo:获取游园记录信息
// GET, 参数通过Params传递
export function getGettingAroundZooFlowInfo(params) {
  return request({
    url: "/api/gettingAroundZoo/getGettingAroundZooFlowInfo",
    method: "get",
    params,
  });
}
// API: getGettingAroundZooFlowInfo:删除游园记录信息
// DELETE, 参数通过Params传递
export function deleteGettingAroundZooFlowInfo(params) {
  return request({
    url: "/api/gettingAroundZoo/deleteGettingAroundZooFlowInfo",
    method: "delete",
    params,
  });
}
// API: getGettingAroundZooData:获取园内交通工具
// GET, 参数通过Params传递
export function getGettingAroundZooData(params) {
  return request({
    url: "/api/gettingAroundZoo/getGettingAroundZooData",
    method: "get",
    params,
  });
}
// API: updateGettingAroundZooInfo:修改园内交通工具
// PUT, 参数通过Params传递
export function updateGettingAroundZooInfo(params) {
  return request({
    url: "/api/gettingAroundZoo/updateGettingAroundZooInfo",
    method: "put",
    params,
  });
}
// API: createGettingAroundZooInfo:创建交通工具
// POST, 参数通过Params传递
export function createGettingAroundZooInfo(params) {
  return request({
    url: "/api/gettingAroundZoo/createGettingAroundZooInfo",
    method: "post",
    params,
  });
}
