import request from "@/utils/request";
// API: getNotice:获取园内通知信息
// GET, 参数通过Params传递
export function getNotice(params) {
  return request({
    url: "/api/homepageRequests/getNotice",
    method: "get",
    params,
  });
}
// API: getCurrentTourists：获取园内当前游客数量
// GET, 参数通过Params传递
export function getCurrentTourists(params) {
  return request({
    url: "/api/commonModule/getCurrentTourists",
    method: "get",
    params,
  });
}
// API: getRegisteredTouristCnt：获取注册游客数量
// GET, 参数通过Params传递
export function getRegisteredTouristCnt(params) {
  return request({
    url: "/api/commonModule/getRegisterTouristCnt",
    method: "get",
    params,
  });
}
// API: getAnimalCount：获取动物数量
// GET, 参数通过Params传递
export function getAnimalCount(params) {
  return request({
    url: "/api/commonModule/getAnimalCount",
    method: "get",
    params,
  });
}
// API: getStaffCount：获取员工数量
// GET, 参数通过Params传递
export function getStaffCount(params) {
  return request({
    url: "/api/commonModule/getStaffCount",
    method: "get",
    params,
  });
}
