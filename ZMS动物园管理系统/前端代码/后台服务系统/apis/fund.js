import request from "@/utils/request";
// API: getAccountIncomesOverview:获取收入概览（按账户）
// POST, 参数通过Params(URL)传递
export function getAccountIncomesOverview(params) {
  return request({
    url: "/api/fundManagement/getAccountIncomesOverview",
    method: "post",
    params,
  });
}
// API: getAccountExpenseOverview:获取支出概览（按账户）
// POST, 参数通过Params(URL)传递
export function getAccountExpenseOverview(params) {
  return request({
    url: "/api/fundManagement/getAccountExpenseOverview",
    method: "post",
    params,
  });
}
// API: getCategoryIncomesOverview:获取收入概览（按分类）
// POST, 参数通过Params(URL)传递
export function getCategoryIncomesOverview(params) {
  return request({
    url: "/api/fundManagement/getCategoryIncomesOverview",
    method: "post",
    params,
  });
}
// API: getCategoryExpenseOverview:获取支出概览（按分类）
// POST, 参数通过Params(URL)传递
export function getCategoryExpenseOverview(params) {
  return request({
    url: "/api/fundManagement/getCategoryExpenseOverview",
    method: "post",
    params,
  });
}
// API: getOverallBalanceShift:获取结余概览
// POST, 参数通过Params(URL)传递
export function getOverallBalanceShift(params) {
  return request({
    url: "/api/fundManagement/getOverallBalanceShift",
    method: "post",
    params,
  });
}
// API: getAccountBalanceShift:获取结余概览（按账户）
// POST, 参数通过Params(URL)传递
export function getAccountBalanceShift(params) {
  return request({
    url: "/api/fundManagement/getAccountBalanceShift",
    method: "post",
    params,
  });
}
// API: getAccountList:获取账户列表
// POST, 参数通过Params(URL)传递
export function getAccountList(params) {
  return request({
    url: "/api/fundManagement/getAccountList",
    method: "post",
    params,
  });
}
// API: deleteFlowEntry:删除流水
// DELETE, 参数通过URL传递
export function deleteFlowEntry(id) {
  return request({
    url: "/api/fundManagement/deleteFlowEntry/" + id,
    method: "delete",
  });
}
// API: updateFlowEntry:更新流水信息
// POST, 参数通过Params(URL)传递
export function updateFlowEntry(params) {
  return request({
    url: "/api/fundManagement/updateFlowEntry",
    method: "post",
    params,
  });
}
// API: getFlowEntries:获取流水信息
// POST, 参数通过Params(URL)传递
export function getFlowEntries(params) {
  return request({
    url: "/api/fundManagement/getFlowEntries",
    method: "post",
    params,
  });
}
// API: addBankAccount:增加账户
// POST, 参数通过Params(URL)传递
export function addBankAccount(params) {
  return request({
    url: "/api/fundManagement/addBankAccount",
    method: "post",
    params,
  });
}
// API: addBankAccount:增加流水项目
// POST, 参数通过Data传递
export function AddFundAccount(data) {
  return request({
    url: "/api/fundManagement/AddFundAccount",
    method: "post",
    data,
  });
}
