import request from "@/utils/request";
// API: userAuth：登陆验证
// GET, 参数通过Params传递
export function userAuth(params) {
  return request({
    url: "/api/register/login",
    method: "get",
    params,
  });
}
// API: userAuth：登陆验证有效性判断
// GET, 参数通过Params传递
export function userAuthTest(params) {
  return request({
    url: "/api/register/getlist",
    method: "get",
    params,
  });
}
