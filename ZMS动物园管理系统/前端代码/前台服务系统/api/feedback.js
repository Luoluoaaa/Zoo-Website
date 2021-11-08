import request from '@/utils/request'

export function feedback(params) {
    return request({
      url: '/api/register/feedback',
      method: 'get',
      params
    })
  }
