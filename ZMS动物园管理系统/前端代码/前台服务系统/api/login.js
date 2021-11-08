import request from '@/utils/request'

export function userAuth(params) {
    return request({
      //url: '/user/authenticate',
      url:'/api/register/login',
      method: 'get',
      params
    })
  }

  export function userAuthTest(params) {
    return request({
      url: '/api/register/getlist',
      method: 'get',
      params
    })
}
