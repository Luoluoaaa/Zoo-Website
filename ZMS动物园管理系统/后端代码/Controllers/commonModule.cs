/*-----------------------------------------
 * 作者：杨泽华
 * 最后修改：2021.7.15
 * 功能：后台基础响应统计模块
 ----------------------------------------*/
using BackEnd.Data;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace BackEnd.Controllers
{
    [Route("api/commonModule/")]
    [ApiController]
    public class commonModule
    {
        private readonly ModelContext _context;
        private readonly IJwtAuthenticationHandler _jwtAuthenticationHandler;
        //构造函数注入生成token的类

        public commonModule(ModelContext context, IJwtAuthenticationHandler jwtAuthenticationHandler)
        {
            _context = context;
            _jwtAuthenticationHandler = jwtAuthenticationHandler;
        }

        /*--------------------------------------------
         * 函数名：getStaffCount
         * API：47.118.78.110:8088/api/commonModule/getStaffCount
         * 参数：null
         * 功能：获取员工总数
         * 权限：无需权限
         --------------------------------------------*/
        [AllowAnonymous]
        [HttpGet("getStaffCount")]
        public backdata getStaffCount()
        {
            backdata result = new backdata();

            result.data = _context.Employees.Count();

            return result;
        }

        /*--------------------------------------------
         * 函数名：getRegisterTouristCnt
         * API：47.118.78.110:8088/api/commonModule/getRegisterTouristCnt
         * 参数：null
         * 功能：获取游客总数
         * 权限：无需权限
         --------------------------------------------*/
        [AllowAnonymous]
        [HttpGet("getRegisterTouristCnt")]
        public backdata getRegisterTouristCnt()
        {
            backdata result = new backdata();

            result.data = _context.Tourists.Count();

            return result;
        }

        /*--------------------------------------------
         * 函数名：getAnimalCount
         * API：47.118.78.110:8088/api/commonModule/getAnimalCount
         * 参数：null
         * 功能：获取动物总数
         * 权限：无需权限
         --------------------------------------------*/
        [AllowAnonymous]
        [HttpGet("getAnimalCount")]
        public backdata getAnimalCount()
        {
            backdata result = new backdata();

            result.data = _context.Animals.Count();

            return result;
        }

    }
}
