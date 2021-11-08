import request from '@/utils/request'
export function getTransportInfo(params) {
    return request({
        url: '/api/transportation',
        method: 'get',
        params
    })
}