import axios from "axios";
// create an axios instance
const service = axios.create({
  baseURL: "http://47.118.78.110:8088/",
  withCredentials: true,
  timeout: 20000,
});
// request interceptor
service.interceptors.request.use(
  (config) => {
    let lsToken = localStorage.getItem("zmsToken");
    if (lsToken != "" && lsToken != null) {
      config.headers["Authorization"] = lsToken;
    }
    return config;
  },
  (error) => {
    return Promise.reject(error);
  }
);
// response interceptor
service.interceptors.response.use(
  (response) => {
    const res = response.data;

    if (response.status == 204) {
      return res;
    }
    if (res.code != 200) {
      return Promise.reject(new Error(res.message || "Error"));
    } else {
      return res;
    }
  },
  (error) => {
    if (error.response) {
      if (error.response.status === 401) {
        localStorage.setItem("zmsToken", "");
        window.location.href = "/zmsoffice/";
      }
      if (error.response.status === 500) {
        return Promise.reject(
          new Error("输入的数据存在非法部分，请重新检查输入后再进行重试。")
        );
      }
      if (error.response.status === 400) {
        return Promise.reject(
          new Error("输入的数据存在非法部分，请重新检查输入后再进行重试。")
        );
      }
      if (error.response.status === 403) {
        return Promise.reject(new Error("您暂无权限查看当前页面。"));
      }
      if (error.response.status === 404) {
        return Promise.reject(
          new Error("您所访问的服务当前正在维护，或已经迁移。")
        );
      }
    }

    return Promise.reject(error);
  }
);
export default service;
