import request from "@/utils/request";
// API: getWarehouseInfo:获取仓库信息
// GET, 参数通过Params传递
export function getWarehouseInfo(params) {
  return request({
    url: "/api/warehouseRequest/getWarehouseInfo",
    method: "get",
    params,
  });
}
// API: updateWarehouseInfo:更新仓库信息
// GET, 参数通过Params传递
export function updateWarehouseInfo(params) {
  return request({
    url: "/api/warehouseRequest/updateWarehouseInfo",
    method: "get",
    params,
  });
}
// API: updateWarehouseInfo:获取仓库物品信息
// GET, 参数通过Params传递
export function getwareItemInfo(params) {
  return request({
    url: "/api/warehouseRequest/getwareItemInfo",
    method: "get",
    params,
  });
}
// API: updateWarehouseInfo:更新仓库物品信息
// GET, 参数通过Params传递
export function updatewareItemInfo(params) {
  return request({
    url: "/api/warehouseRequest/modifyItem",
    method: "put",
    params,
  });
}
// API: createWarehouse:创建仓库
// POST, 参数通过Params传递
export function createWarehouse(params) {
  return request({
    url: "/api/warehouseRequest/createWarehouse",
    method: "post",
    params,
  });
}
// API: modifyItem:增删物品（按照增量修改）
// PUT, 参数通过Params传递
export function modifyItem(params) {
  return request({
    url: "/api/warehouseRequest/modifyItem",
    method: "put",
    params,
  });
}
