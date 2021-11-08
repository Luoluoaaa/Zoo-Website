import request from "@/utils/request";
// API: getinformation：获取动物信息
// GET, 参数通过Params(URL)传递
export function getinformation(params) {
  return request({
    url: "/api/animalInfo/getinformation",
    method: "get",
    params,
  });
}
// API: createinformation:创建动物信息
// POST, 参数通过Data传递
export function createinformation(data) {
  return request({
    url: "/api/animalBreedInfo/createInfo",
    method: "post",
    data,
  });
}
// API: updateinformation:更新动物信息
// PUT, 参数通过Data传递
export function updateinformation(data) {
  return request({
    url: "/api/animalInfo/updateinformation",
    method: "put",
    data,
  });
}
// API: deleteinformation:删除动物信息
// DELETE, 参数通过URL传递
export function deleteinformation(id) {
  return request({
    url: "/api/animalInfo/deleteinformation/" + id,
    method: "delete",
  });
}
