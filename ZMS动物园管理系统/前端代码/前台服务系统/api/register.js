import request from '@/utils/request'

export function postInformation(params) {
    return request({
      url: '/api/register/information',
      method: 'get',
      params
    })
  }

export function getVerification(params) {
    return request({
      url: '/api/register/Verification',
      method: 'get',
      params
    })
  }

