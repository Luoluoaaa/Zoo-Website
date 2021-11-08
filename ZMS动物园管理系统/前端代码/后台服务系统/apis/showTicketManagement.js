import request from "@/utils/request";
// API: getShowTicketData:获取演出票信息
// GET, 参数通过Params传递
export function getShowTicketData(params) {
  return request({
    url: "/api/showTicketManagement/getShowTicketData",
    method: "get",
    params,
  });
}
// API: updateShowTicketInfo:更新演出票信息
// PUT, 参数通过Params传递
export function updateShowTicketInfo(params) {
  return request({
    url: "/api/showTicketManagement/updateShowTicketInfo",
    method: "put",
    params,
  });
}
// API: updateShowTicketInfo:获取演出票流信息
// GET, 参数通过Params传递
export function getShowTicketFlowInfo(params) {
  return request({
    url: "/api/showTicketManagement/getShowTicketFlowInfo",
    method: "get",
    params,
  });
}
// API: deleteShowTicketFlowInfo:删除演出票流信息
// DELETE, 参数通过Params传递
export function deleteShowTicketFlowInfo(params) {
  return request({
    url: "/api/showTicketManagement/deleteShowTicketFlowInfo",
    method: "delete",
    params,
  });
}
// API: createShowTicketInfo:创建演出票信息
// POST, 参数通过Params传递
export function createShowTicketInfo(params) {
  return request({
    url: "/api/showTicketManagement/createShowTicketInfo",
    method: "post",
    params,
  });
}
