import request from '@/utils/request'

export function getVT(params){
    return request({
        url:'/api/vehicleT/getvehicleTData',
        method:'get',
        params
    })
}

export function postVT(params){
    return request({
        url:'/api/vehicleT/createVehicleT',
        method:'post',
        params
    })
}

