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

//游园交通服务（前台）
//2个功能

//1 查询游园票务信息列表
//请求方式：GET
//功能描述：查询所需票种的票务信息

//2 生成游园交通订单信息
//请求方式：POST
//功能描述：插入一条订单信息



namespace BackEnd.Controllers
{
    [Route("api/vehicleT/")]
    [ApiController]
    public class vehicleT : ControllerBase
    {
        private readonly ModelContext _context;
        private readonly IJwtAuthenticationHandler _jwtAuthenticationHandler;
        //构造函数注入生成token的类

        public vehicleT(ModelContext context, IJwtAuthenticationHandler jwtAuthenticationHandler)
        {
            _context = context;
            _jwtAuthenticationHandler = jwtAuthenticationHandler;
        }

        // GET: api/GettingAroundZoos2/5
        //[Authorize(Policy = "TouristPolicy")]
        //[Authorize]
        [AllowAnonymous]
        [HttpGet("getvehicleTData/")]
        public async Task<ActionResult<backdata>> GetGettingAroundZoo(
            string? ticket_type,
            string? vehicle_category)
        {

            backdata result = new backdata();
            var getting_Around_Zoo = await _context.GettingAroundZooType.Where(a =>

             (vehicle_category == null || a.VehicleCategory == vehicle_category)
            
            && (ticket_type == null || a.TicketType == ticket_type)
           ).ToListAsync();


            result.data = getting_Around_Zoo;
            if (getting_Around_Zoo == null)
            {
                result.code = 400;
                result.message = "查询结果为空";
            }

            return result;

        }

        // POST: api/GettingAroundZoos2

        [Authorize(Policy = "TouristPolicy")]
        [HttpPost("createVehicleT/")]
        public async Task<ActionResult<backdata>> PostGettingAroundZoo(
            string tour_id,
            string vehicle_category,
            decimal price,
            string ticket_type,
            string date)
        {
            backdata result = new backdata();
            GettingAroundZoo getting_Around_Zoo = new GettingAroundZoo();
            getting_Around_Zoo.date = Convert.ToDateTime(date);
            getting_Around_Zoo.VehicleCategory = vehicle_category;
            getting_Around_Zoo.Price = price;
            getting_Around_Zoo.TicketType = ticket_type;
            getting_Around_Zoo.TourId = tour_id;
            var Id = await _context.GettingAroundZoos.MaxAsync(t => Convert.ToInt32(t.Id));
            getting_Around_Zoo.Id = Convert.ToString(Id + 1);

            

            _context.GettingAroundZoos.Add(getting_Around_Zoo);
            if (
                tour_id == null
                )
            {
                result.code = 400;
                result.message = "缺少必要信息";
            }
           // else
            {
                _context.GettingAroundZoos.Add(getting_Around_Zoo);
                try
                {
                    await _context.SaveChangesAsync();
                    result.data = getting_Around_Zoo;
                }
                catch (DbUpdateException)
                {
                    if (GettingAroundZooExists(getting_Around_Zoo.Id))
                    {
                        result.code = 401;
                        result.message = "'填入的园内交通编号为已有交通";
                        Conflict();
                        result.data = null;
                    }
                    else
                    {
                        throw;
                    }
                }
            }
            return result;
        }
       
        private bool GettingAroundZooExists(string id)
        {
            return _context.GettingAroundZoos.Any(e => e.Id == id);
        }
    }
}
