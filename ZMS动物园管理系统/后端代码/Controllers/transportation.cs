using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using BackEnd.Data;
using BackEnd.Model;
using Microsoft.AspNetCore.Authorization;

//园外交通工具模块
//请求方式：get
//功能描述：获取园外交通工具信息

namespace BackEnd.Controllers
{
    [Route("api/")]
    [ApiController]
    public class transportation : ControllerBase
    {
        private readonly ModelContext _context;
        private readonly IJwtAuthenticationHandler _jwtAuthenticationHandler;
        //构造函数注入生成token的类

        public transportation(ModelContext context, IJwtAuthenticationHandler jwtAuthenticationHandler)
        {
            _context = context;
            _jwtAuthenticationHandler = jwtAuthenticationHandler;
        }



        // GET: api/GettingHeres2/5
        [AllowAnonymous]
        [HttpGet("transportation/")]
        public async Task<ActionResult<backdata>> GetGettingHere(
            
            string? type
            
            )
        {
            var gettingHere = await _context.GettingHeres.Where(a =>
            (type == null || type == a.VehicleCategory)).ToListAsync();
            backdata result = new backdata();
            //var gettingHere = await _context.GettingHeres.FindAsync(type);
            result.data = gettingHere;

            if (gettingHere == null)
            {
                result.code = 400;
                result.message = "查询结果为空";
            }

            return result;
        }
        
        private bool GettingHereExists(string id)
        {
            return _context.GettingHeres.Any(e => e.Id == id);
        }
    }
}
