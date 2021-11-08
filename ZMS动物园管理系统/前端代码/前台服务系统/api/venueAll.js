import request from '../utils/request'
export function getAllVenueInfo(params) {
    return request({
        url: '/venueAll',
        method: 'get',
        params
    })
}