import request from '../utils/request'
export function getVenueInfo(params) {
    return request({
        url: '/venue',
        method: 'get',
        params
    })
}