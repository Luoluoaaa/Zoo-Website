import request from '@/utils/request'


export function postAT(params){
    return request({
        url:'/api/admissionT/createAdmissInfo',
        method:'post',
        params
    })
}
