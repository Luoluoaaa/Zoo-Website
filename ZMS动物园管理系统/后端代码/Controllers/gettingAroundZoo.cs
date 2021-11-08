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


//园内交通流水信息管理模块（后台）

//1 园内交通流水查询
//请求方式：GET
//功能描述：查询所有符合条件的园内交通流水查询

//2 删除园内交通流水信息
//请求方式：DELETE
//功能描述：删除一条园内交通流水信息




namespace BackEnd.Controllers
{
    [Route("api/gettingAroundZoo/")]
    [ApiController]
    public class gettingAroundZoo : ControllerBase
    {
        private readonly ModelContext _context;
        private readonly IJwtAuthenticationHandler _jwtAuthenticationHandler;
        //构造函数注入生成token的类

        public gettingAroundZoo(ModelContext context, IJwtAuthenticationHandler jwtAuthenticationHandler)
        {
            _context = context;
            _jwtAuthenticationHandler = jwtAuthenticationHandler;
        }



        // GET: api/GettingAroundZoos/5 查流水
        [Authorize(Policy = "EmployeePolicy")]
        [HttpGet("getGettingAroundZooFlowInfo/")]
        public async Task<ActionResult<backdata>> GetGettingAroundZoo(
            string? ID, 
            string? tour_id,
            string? vehicle_category, 
            decimal price, 
            string? ticket_type, 
            string?  date
            )
        {
            backdata result = new backdata();
            var getting_Around_Zoo = await _context.GettingAroundZoos.Where(a =>
            (ID == null || a.Id == ID)
            && (tour_id == null || a.TourId == tour_id)
            && (vehicle_category == null || a.VehicleCategory == vehicle_category) 
            && (price == 0 || a.Price == price)
            && (ticket_type == null || a.TicketType == ticket_type)
            && (date == null || a.date == Convert.ToDateTime(date)) 
           ).ToListAsync();
            
            result.data = getting_Around_Zoo;
            if (getting_Around_Zoo == null)
            {
                result.code = 400;
                result.message = "查询结果为空";
            }

            return result;
        }


       

        // DELETE: api/GettingAroundZoos/5
        [Authorize(Policy = "EmployeePolicy")]
        [HttpDelete("deleteGettingAroundZooFlowInfo/")]
        public async Task<ActionResult<backdata>> DeleteGettingAroundZoo(
            string ID
            

            )
        {                 
          
            var gettingAroundZoo = await _context.GettingAroundZoos.FindAsync(ID);
            backdata result = new backdata();
            if (gettingAroundZoo == null)
            {
                result.code = 405;
                result.message = "没有该ID";
                return result;
            }
            result.data = gettingAroundZoo;

            _context.GettingAroundZoos.Remove(gettingAroundZoo);
            await _context.SaveChangesAsync();

            return result;
        }
        
        private bool GettingAroundZooExists(string id)
        {
            return _context.GettingAroundZoos.Any(e => e.Id == id);
        }
    }
}
