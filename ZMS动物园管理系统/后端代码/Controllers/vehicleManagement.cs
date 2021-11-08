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


// 园外交通信息管理模块（后台）

//1 查询园外交通信息管理列表
//请求方式：GET
//功能描述：查询所有符合条件的园外交通信息列表

//2 新增园外交通信息
//请求方式：POST
//功能描述：插入一条园外交通

//3 修改园外交通信息
//请求方式：PUT
//功能描述：修改一条园外交通信息

//4 删除园外交通信息
//请求方式：DELETE
//功能描述：删除符合条件的园外交通信息



namespace BackEnd.Controllers
{
    [Route("api/vehicleManagement/")]
    [ApiController]
    public class vehicleManagement : ControllerBase
    {
        private readonly ModelContext _context;
        private readonly IJwtAuthenticationHandler _jwtAuthenticationHandler;
        //构造函数注入生成token的类

        public vehicleManagement(ModelContext context, IJwtAuthenticationHandler jwtAuthenticationHandler)
        {
            _context = context;
            _jwtAuthenticationHandler = jwtAuthenticationHandler;
        }

        // GET: api/Getting_Here

        // GET: api/Getting_Here/5
        [HttpGet("getVehicleManagementData/")]
        public async Task<ActionResult<backdata>> GetGetting_Here(
            string? ID,
            string? vehicle_category, 
            decimal? departure_interval, 
            decimal? trans_duration, 
            decimal? price, 
            string? boarding_location)
        {
            var getting_Here = await _context.GettingHeres.Where(a =>
                (ID == null || a.Id == ID) && 
                (vehicle_category == null || a.VehicleCategory == vehicle_category) 
                && (departure_interval == 0 || a.DepartureInterval == departure_interval)
                && (trans_duration == 0 || a.TransDuration == trans_duration) 
                && (price == 0 || a.Price == price) 
                && (boarding_location == null || a.BoardingLocation == boarding_location)).ToListAsync();
            backdata result = new backdata();
            result.data = getting_Here;
            if (getting_Here == null)
            {
                result.code = 400;
                result.message = "查询结果为空";
            }

            return result;
        }

        // POST: api/Getting_Here
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost("createVehicleManagementInfo/")]
        public async Task<ActionResult<backdata>> PostGetting_Here(
            
            string? vehicle_category, 
            decimal departure_interval, 
            decimal trans_duration, 
            decimal price, 
            string? boarding_location)
        {
            GettingHere getting_Here = new GettingHere();
            backdata result = new backdata();
            var Id = await _context.GettingHeres.MaxAsync(t => Convert.ToInt32(t.Id));
            getting_Here.Id = Convert.ToString(Id + 1);
            getting_Here.VehicleCategory = vehicle_category;
            getting_Here.DepartureInterval = departure_interval;
            getting_Here.TransDuration = trans_duration;
            getting_Here.Price = price;
            getting_Here.BoardingLocation = boarding_location;

            if (
                vehicle_category==null
                )
            {
                result.code = 400;
                result.message = "缺少必要信息:需填写交通工具类别";
                return result;
            }
            if (departure_interval == 0) getting_Here.DepartureInterval = 0;
            if (trans_duration == 0) getting_Here.TransDuration = 0;
            if (price == 0) getting_Here.Price = 0;
            if (boarding_location == null) getting_Here.BoardingLocation = "暂无";



            _context.GettingHeres.Add(getting_Here);
                try
                {
                    await _context.SaveChangesAsync();
                    result.data = getting_Here;
                }
                catch (DbUpdateException)
                {
                    if (Getting_HereExists(getting_Here.Id))
                    {
                        result.code = 401;
                        result.message = "'填入的交通工具id为已有交通工具id";
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

        // PUT: api/Getting_Here/5

        [HttpPut("updateVehicleManagementInfo/")]
        public async Task<ActionResult<backdata>> PutGetting_Here(
            string? ID, 
            string? vehicle_category, 
            decimal departure_interval, 
            decimal trans_duration, 
            decimal price, 
            string? boarding_location)
        {
            GettingHere getting_Here = new GettingHere();
            backdata result = new backdata();
            getting_Here.Id = ID;
            getting_Here.VehicleCategory = vehicle_category;
            getting_Here.DepartureInterval = departure_interval;
            getting_Here.TransDuration = trans_duration;
            getting_Here.Price = price;
            getting_Here.BoardingLocation = boarding_location;
            if (getting_Here.Id == null||
                vehicle_category==null)
            {
                result.code = 400;
                result.message = "缺少必要信息";
                return result;
            }

            GettingHere tmp = await _context.GettingHeres.FindAsync(getting_Here.Id);
            if (tmp == null)
            {
                result.code = 402;
                result.message = "未找到改动目标";
                return result;
            }

            _context.GettingHeres.Remove(tmp);

            if (departure_interval == 0) getting_Here.DepartureInterval = 0;
            if (trans_duration == 0) getting_Here.TransDuration = 0;
            if (price == 0) getting_Here.Price = 0;
            if (boarding_location == null) getting_Here.BoardingLocation = "暂无";
            
            _context.Entry(getting_Here).State = EntityState.Modified;

            try
            {
                _context.GettingHeres.Add(getting_Here);
                await _context.SaveChangesAsync();
                result.data = tmp;
            }
            catch (DbUpdateException)
            {
                if (Getting_HereExists(getting_Here.Id))
                {
                    result.code = 400;
                    result.message = "'填入的交通工具id要为已有交通工具id";
                    Conflict();
                    result = null;
                }
                else
                {

                    throw;
                }
            }

            
            return result;

        }

        // DELETE: api/Getting_Here/5
        [HttpDelete("deleteVehicleManagementInfo/")]
        public async Task<ActionResult<backdata>> DeleteGetting_Here(string ID)
        {
            backdata result = new backdata();
            var getting_Here = await _context.GettingHeres.FindAsync(ID);
            if (getting_Here == null)
            {
                result.code = 405;
                result.message = "没有该ID";
                return result;
            }
            result.data = getting_Here;
            _context.GettingHeres.Remove(getting_Here);
            await _context.SaveChangesAsync();

            return result;
        }

        private bool Getting_HereExists(string id)
        {
            return _context.GettingHeres.Any(e => e.Id == id);
        }
    }
}
