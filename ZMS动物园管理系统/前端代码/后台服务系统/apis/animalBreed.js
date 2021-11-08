import request from "@/utils/request";
//API: getPregnent：获取动物繁育信息
//GET, 参数通过Params(URL)传递
export function getPregnent(params) {
  return request({
    url: "/api/animalBreedInfo/getpregnent",
    method: "get",
    params,
  });
}
//API: createBreedInfo：创建动物繁育信息
//POST, 参数通过Params(URL)传递
export function createBreedInfo(params) {
  return request({
    url: "/api/animalBreedInfo/createBirthInfo",
    method: "post",
    params,
  });
}
//API: updateBreedInfo：创建动物繁育信息
//POST, 参数通过Params(URL)传递
export function updateBreedInfo(params) {
  return request({
    url: "/api/animalBreed/updateBreedInfo",
    method: "post",
    params,
  });
}
//API: deleteBreedInfo：删除动物繁育信息
//DELETE, 参数通过Params(URL)传递
export function deleteBreedInfo(params) {
  return request({
    url: "/api/animalBreed/deleteBreedInfo",
    method: "delete",
    params,
  });
}
