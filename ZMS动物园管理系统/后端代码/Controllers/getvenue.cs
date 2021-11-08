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

//用于前台游客了解场馆的相关功能
namespace BackEnd.Controllers
{
    [Route("api/")]
    [ApiController]
    public class getvenue : ControllerBase
    {
        private readonly ModelContext _context;
        private readonly IJwtAuthenticationHandler _jwtAuthenticationHandler;
        //构造函数注入生成token的类

        public getvenue(ModelContext context, IJwtAuthenticationHandler jwtAuthenticationHandler)
        {
            _context = context;
            _jwtAuthenticationHandler = jwtAuthenticationHandler;
        }

        [AllowAnonymous]
        [HttpGet("/venue/")]
        public async Task<ActionResult<backdata>> getinformation(string name)
        {
            backdata result = new backdata();
            if (name == null)
            {
                result.code = 401;
                result.message = "缺少必要信息";
                return result;
            }
            var query = from t in _context.DisplayAreas
                        where (t.Name == name)
                        select new
                        {
                            introduction = t.Introduction,
                            location = t.Location,
                            additionalFee = t.AdditionalFee,
                            telephone = t.Telephone,
                            touristCapacity = t.TouristCapacity,
                            status = t.Status
                        };
            var q = await query.ToListAsync();
            if (q.Count == 0)
            {
                result.code = 400;
                result.message = "查询结果为空";
                return result;
            }
            result.data = q;
            result.code = 200;
            result.message = "";
            return result;
        }
        [AllowAnonymous]
        [HttpGet("/venueAll/")]
        public async Task<ActionResult<backdata>> getinformation2()
        {
            backdata result = new backdata();
            var query = from t in _context.DisplayAreas
                        select new
                        {
                            name = t.Name,
                            zone = t.Zone,
                            additionalFee = t.AdditionalFee,
                            telephone = t.Telephone,
                            status = t.Status
                        };
            var q = await query.ToListAsync();
            if (q.Count == 0)
            {
                result.code = 402;
                result.message = "查询结果为空";
                return result;
            }
            result.data = q;
            result.code = 200;
            result.message = "";
            return result;
        }

        private bool DisplayAreaExists(string id)
        {
            return _context.DisplayAreas.Any(e => e.AreaId == id);
        }
    }
}
