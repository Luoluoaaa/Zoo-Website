import request from "@/utils/request";
// API: getRecipe：获取动物食谱
// PUT, 参数通过Params传递
export function getRecipe(params) {
  return request({
    url: "/api/recipe/getRecipe",
    method: "get",
    params,
  });
}
// API: createRecipe：创建动物食谱
// POST, 参数通过Data传递
export function createRecipe(data) {
  return request({
    url: "/api/recipe/createRecipe",
    method: "post",
    data,
  });
}
// API: updateRecipe:更新动物食谱
// PUT, 参数通过Data和URL传递
export function updateRecipe(data, id) {
  
  return request({
    url: "/api/recipe/updteRecipe/",
    method: "put",
    data,
  });
}
// API: deleteRecipe:删除动物食谱
// DELETE, 参数通过Data和URL传递
export function deleteRecipe(data, id) {
  return request({
    url: "/api/recipe/deleteRecipe/" + id,
    method: "delete",
    data,
  });
}
