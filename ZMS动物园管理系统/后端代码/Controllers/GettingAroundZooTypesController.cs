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

//园内交通信息管理模块（后台）

//1 查找园内交通信息
//请求方式：GET
//功能描述：查询所有符合条件的园内交通信息列表

//2 修改园内交通信息
//请求方式：PUT
//功能描述：修改一条园内交通信息

namespace BackEnd.Controllers
{
    [Route("api/gettingAroundZoo/")]
    [ApiController]
    public class GettingAroundZooTypesController : ControllerBase
    {
        private readonly ModelContext _context;
        private readonly IJwtAuthenticationHandler _jwtAuthenticationHandler;
        //构造函数注入生成token的类

        public GettingAroundZooTypesController(ModelContext context, IJwtAuthenticationHandler jwtAuthenticationHandler)
        {
            _context = context;
            _jwtAuthenticationHandler = jwtAuthenticationHandler;
        }

        // GET: api/GettingAroundZoos/5 查类型
        [Authorize(Policy = "EmployeePolicy")]
        [HttpGet("getGettingAroundZooData/")]
        public async Task<ActionResult<backdata>> GetGettingAroundZoo2(

            string? vehicle_category,
            decimal price,
            string? ticket_type,
            decimal deposit,
            decimal age_limit,
            decimal weight_limit,
            decimal rental_duration)
        {

            backdata result = new backdata();
            var getting_Around_Zoo = await _context.GettingAroundZooType.Where(a =>

             (vehicle_category == null || a.VehicleCategory == vehicle_category)
            && (price == 0 || a.Price == price)
            && (ticket_type == null || a.TicketType == ticket_type)
            && (deposit == 0 || a.Deposit == deposit)
            && (age_limit == 0 || a.AgeLimit == age_limit)
            && (weight_limit == 0 || a.WeightLimit == weight_limit)
            && (rental_duration == 0 || a.RentalDuration == rental_duration)).ToListAsync();


            result.data = getting_Around_Zoo;
            if (getting_Around_Zoo == null)
            {
                result.code = 400;
                result.message = "查询结果为空";
            }

            return result;
        }

        [Authorize(Policy = "EmployeePolicy")]
        [HttpPut("updateGettingAroundZooInfo/")]
        public async Task<ActionResult<backdata>> PutGettingAroundZoo(
            string? vehicle_category,
            decimal price,
            string? ticket_type,
            decimal deposit,
            decimal age_limit,
            decimal weight_limit,
            decimal rental_duration)
        {
            backdata result = new backdata();
            GettingAroundZooType getting_Around_Zoo = new GettingAroundZooType();
            getting_Around_Zoo.VehicleCategory = vehicle_category;
            getting_Around_Zoo.Price = price;
            getting_Around_Zoo.TicketType = ticket_type;
            getting_Around_Zoo.Deposit = deposit;
            getting_Around_Zoo.AgeLimit = age_limit;
            getting_Around_Zoo.WeightLimit = weight_limit;
            getting_Around_Zoo.RentalDuration = rental_duration;
            if (getting_Around_Zoo.VehicleCategory == null || getting_Around_Zoo.TicketType == null)
            {
                result.code = 400;
                result.message = "查询结果为空:需要填写交通工具类别和票种";
                return result;
            }
            GettingAroundZooType tmp = await _context.GettingAroundZooType.FindAsync(ticket_type, vehicle_category);
            if (tmp == null)
            {
                result.code = 402;
                result.message = "未找到改动目标";
                return result;
            }
            if (getting_Around_Zoo.Price != 0) tmp.Price = getting_Around_Zoo.Price;
            if (getting_Around_Zoo.VehicleCategory != null) tmp.VehicleCategory = getting_Around_Zoo.VehicleCategory;
            if (getting_Around_Zoo.TicketType != null) tmp.TicketType = getting_Around_Zoo.TicketType;
            if (getting_Around_Zoo.Deposit != 0) tmp.Deposit = getting_Around_Zoo.Deposit;
            if (getting_Around_Zoo.AgeLimit != 0) tmp.AgeLimit = getting_Around_Zoo.AgeLimit;
            if (getting_Around_Zoo.WeightLimit != 0) tmp.WeightLimit = getting_Around_Zoo.WeightLimit;
            if (getting_Around_Zoo.RentalDuration != 0) tmp.RentalDuration = getting_Around_Zoo.RentalDuration;
            _context.Entry(tmp).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
                result.data = tmp;
            }
            catch (DbUpdateConcurrencyException)
            {
                if (GettingAroundZooTypeExists(getting_Around_Zoo.TicketType, getting_Around_Zoo.VehicleCategory))
                {
                    result.code = 401;
                    result.message = "填入的园内交通票要为已有交通票";
                    Conflict();
                    result.data = null;
                }
                else
                {
                    throw;
                }
            }

            return result;
        }

        
        
        private bool GettingAroundZooTypeExists(string tickettype, string vechicle)
        {
            return _context.GettingAroundZooType.Any(e => (e.TicketType == tickettype) && (e.VehicleCategory == vechicle));
        }
    }
}
