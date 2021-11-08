using System;
using BackEnd.Data;
using BackEnd.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;

//用于后台导游管理的相关功能
namespace BackEnd.Controllers
{
    [Route("api/guideRequest/")]
    [ApiController]
    public class guideRequest : ControllerBase
    {
        private readonly ModelContext _context;
        private readonly IJwtAuthenticationHandler _jwtAuthenticationHandler;
        //构造函数注入生成token的类

        public guideRequest(ModelContext context, IJwtAuthenticationHandler jwtAuthenticationHandler)
        {
            _context = context;
            _jwtAuthenticationHandler = jwtAuthenticationHandler;
        }
        [Authorize(Policy = "EmployeePolicy")]
        [HttpGet("getGuideInfo/")]
        public async Task<ActionResult<backdata>> getinformation(string? guideId, string? name, decimal? price, string? type)
        {
            var guides = await _context.TouristGuides.Where(t =>
            (guideId == null || t.GuideId == guideId) &&
            (name == null || t.Name == name) &&
            (price == null || t.Price == price) &&
            (type == null || t.Type == type)).ToListAsync();
            backdata result = new backdata();

            result.data = guides;

            if (guides == null)
            {
                result.code = 400;
                result.message = "查询结果为空";
            }
            else
            {
                result.code = 200;
                result.message = "";
            }
            return result;
        }
        
        private bool TouristGuideExists(string id)
        {
            return _context.TouristGuides.Any(e => e.Id == id);
        }
    }
}
