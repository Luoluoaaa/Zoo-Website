import request from '@/utils/request'


export function postGT(params){
    return request({
        url:'/api/guideT/createGuideT',
        method:'post',
        params
    })
}
