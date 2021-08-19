import axios from 'axios'
import store from '@/store'
import { getToken } from '@/utils/auth'

// create an axios instance
const service = axios.create({
  baseURL: 'http://47.118.78.110/',
  withCredentials: true, 
  timeout: 5000 
})

// request interceptor
service.interceptors.request.use(
  config => {
    if (store.getters.token) {
      config.headers['X-Token'] = getToken()
    }
    return config
  },
  error => {
    console.log(error) // for debug
    return Promise.reject(error)
  }
)

// response interceptor
service.interceptors.response.use(
  response => {
    console.log ("请求已经响应")
    const res = response.data
    console.log(response.data)
    
    if (res.code === 20000) {
      console.log("ERROR 1")
      if (res.code === 50008 || res.code === 50012 || res.code === 50014) {
        console.log("ERROR 2")
      }
      return Promise.reject(new Error(res.message || 'Error'))
    }
    else {
      console.log("返回")
      console.log(res)
      return res
    }
  },
  error => {
    console.log('err' + error) // for debug
    return Promise.reject(error)
  }
)

export default service
