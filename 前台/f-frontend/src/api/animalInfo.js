import request from '../utils/request'
export function getAnimalInfo(params) {
    return request({
        url: '/api/animalScience',
        method: 'get',
        params
    })
}