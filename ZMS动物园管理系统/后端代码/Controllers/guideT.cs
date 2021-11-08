using System;
using BackEnd.Data;
using BackEnd.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;

//用于前台游客了解导游的相关功能
namespace BackEnd.Controllers
{
    [Route("api/guideT/")]
    [ApiController]
    public class guideT : ControllerBase
    {
        private readonly ModelContext _context;
        private readonly IJwtAuthenticationHandler _jwtAuthenticationHandler;
        //构造函数注入生成token的类

        public guideT(ModelContext context, IJwtAuthenticationHandler jwtAuthenticationHandler)
        {
            _context = context;
            _jwtAuthenticationHandler = jwtAuthenticationHandler;
        }
        [Authorize(Policy = "TouristPolicy")]
        [HttpPost("createGuideT/")]
        public async Task<ActionResult<backdata>> createinformation(string tourid, string guideid)
        {
            backdata result = new backdata();
            if (tourid == null || guideid == null)
            {
                result.code = 403;
                result.message = "缺少必要信息";
                return result;
            }
            else
            {
                TouristGuide touristguide = new TouristGuide();
                touristguide.TourId = tourid;
                touristguide.GuideId = guideid;
                var id = await _context.TouristGuides.MaxAsync(t => Convert.ToInt32(t.Id));
                touristguide.Id = Convert.ToString(id + 1);
                if (guideid == "1")
                {
                    touristguide.Name = "Alma";
                    touristguide.Type = "德语";
                    touristguide.Price = 120;
                }

                if (guideid == "2")
                {
                    touristguide.Name = "Irma";
                    touristguide.Type = "英语";
                    touristguide.Price = 150;
                }

                if (guideid == "3")
                {
                    touristguide.Name = "Anton";
                    touristguide.Type = "西班牙语";
                    touristguide.Price = 200;
                }

                _context.TouristGuides.Add(touristguide);
                try
                {
                    await _context.SaveChangesAsync();
                    result.code = 200;
                    result.data = touristguide;
                }

                catch (DbUpdateException)
                {
                    throw;
                }
                return result;
            }
        }
        private bool TouristGuideExists(string id)
        {
            return _context.TouristGuides.Any(e => e.Id == id);
        }
    }
}
