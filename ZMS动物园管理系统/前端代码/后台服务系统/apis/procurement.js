import request from "@/utils/request";
// API: getProcOverview：获取采购总览
// GET, 参数通过Params传递
export function getProcOverview(params) {
  return request({
    url: "/api/procManagement/getProcOverview",
    method: "get",
    params,
  });
}
// API: createNewProc：创建采购信息
// POST, 参数通过Params传递
export function createNewProc(params) {
  return request({
    url: "/api/procManagement/createNewProc",
    method: "post",
    params,
  });
}
// API: getPendingRequests：获取待处理采购
// GET, 参数通过Params传递
export function getPendingRequests(params) {
  return request({
    url: "/api/procManagement/getProcOverview",
    method: "get",
    params,
  });
}
// API: changeProcStatus：更改采购状态
// PUT, 参数通过Params传递
export function changeProcStatus(params) {
  return request({
    url: "/api/procManagement/changeProcStatus",
    method: "put",
    params,
  });
}
