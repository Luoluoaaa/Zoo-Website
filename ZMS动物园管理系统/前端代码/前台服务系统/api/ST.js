import request from '@/utils/request'

export function getSTD(params){
    return request({
        url:'/api/showT/getShowTData',
        method:'get',
        params
    })
}
export function getSD(params){
    return request({
        url:'/api/showT/getShowData',
        method:'get',
        params
    })
}

export function postST(params){
    return request({
        url:'/api/showT/createShowT',
        method:'post',
        params
    })
}