using System;
using BackEnd.Data;
using BackEnd.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;

//用于后台场馆管理的相关功能
namespace BackEnd.Controllers
{
    [Route("api/venueRequest/")]
    [ApiController]
    public class venueRequest : ControllerBase
    {
        private readonly ModelContext _context;
        private readonly IJwtAuthenticationHandler _jwtAuthenticationHandler;
        //构造函数注入生成token的类

        public venueRequest(ModelContext context, IJwtAuthenticationHandler jwtAuthenticationHandler)
        {
            _context = context;
            _jwtAuthenticationHandler = jwtAuthenticationHandler;
        }
        [Authorize(Policy = "EmployeePolicy")]
        [HttpGet("getvenueItemInfo/")]
        public async Task<ActionResult<backdata>> getinformation(string? areaid, string? name, string? location, string? status)
        {
            var areas = await _context.DisplayAreas.Where(t =>
            (areaid == null || t.AreaId == areaid) && (name == null || t.Name == name) &&
            (location == null || t.Location == location) &&
            (status == null || t.Status == status)).ToListAsync();
            backdata result = new backdata();
            result.data = areas;

            if (areas == null)
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
        [Authorize(Policy = "EmployeePolicy")]
        [HttpPost("creatsvenueItemInfo/")]
        public async Task<ActionResult<backdata>> createinformation(string areaid, string name, string zone, string location, decimal additionalFee, string telephone, decimal touristCapacity, string status, string introduction)
        {
            backdata result = new backdata();
            if (areaid == null || name == null || zone == null || location == null || additionalFee < 0 || telephone == null || touristCapacity < 0 || status == null || introduction == null)
            {
                result.code = 403;
                result.message = "缺少必要信息";
                return result;
            }
            else
            {
                DisplayArea areas = new DisplayArea();
                areas.AreaId = areaid;
                areas.Name = name;
                areas.Introduction = introduction;
                areas.Zone = zone;
                areas.Location = location;
                areas.AdditionalFee = additionalFee;
                areas.Telephone = telephone;
                areas.TouristCapacity = touristCapacity;
                areas.Status = status;
                _context.DisplayAreas.Add(areas);
                try
                {
                    await _context.SaveChangesAsync();
                    result.code = 200;
                    result.data = areas;
                }

                catch (DbUpdateException)
                {
                    if (Display_AreaExists(areas.AreaId))
                    {
                        result.code = 401;
                        result.message = "新增场馆ID重复";
                        Conflict();
                    }
                    else
                    {
                        throw;
                    }
                }
                return result;
            }
        }
        [Authorize(Policy = "EmployeePolicy")]
        [HttpPut("updatevenueItemInfo/")]
        public async Task<ActionResult<backdata>> updateinformation(string areaid, string name, string zone, string location, decimal additionalFee, string telephone, decimal touristCapacity, string status)
        {
            backdata result = new backdata();
            if (areaid == null)
            {
                result.code = 403;
                result.message = "缺少必要信息";
                return result;
            }

            if (additionalFee < 0)
            {
                result.code = 405;
                result.message = "额外费用不合法";
                return result;
            }
            if (touristCapacity < 0)
            {
                result.code = 407;
                result.message = "人数容量不合法";
                return result;
            }
            DisplayArea tmp = await _context.DisplayAreas.FindAsync(areaid);
            if (tmp == null)
            {
                result.code = 404;
                result.message = "未找到改动目标";
                return result;
            }
            DisplayArea areas = new DisplayArea();
            if (areaid != null) areas.AreaId = areaid;
            if (name != null) areas.Name = name;
            areas.Introduction = tmp.Introduction;
            if (zone != null) areas.Zone = zone;
            if (location != null) areas.Location = location;
            areas.AdditionalFee = additionalFee;
            if (telephone != null) areas.Telephone = telephone;
            areas.TouristCapacity = touristCapacity;
            if (status != null) areas.Status = status;
            _context.DisplayAreas.Remove(tmp);

            _context.Entry(areas).State = EntityState.Modified;
            try
            {
                _context.DisplayAreas.Add(areas);
                await _context.SaveChangesAsync();
                result.data = areas;
            }
            catch (DbUpdateConcurrencyException)
            {
                throw;
            }
            return result;
        }
        [Authorize(Policy = "EmployeePolicy")]
        [HttpDelete("deletevenueItemInfo/")]
        public async Task<ActionResult<backdata>> deleteinformation(string areaid)
        {
            backdata result = new backdata();
            var areas = await _context.DisplayAreas.FindAsync(areaid);
            if (areas == null)
            {
                result.code = 408;
                result.message = "没有该ID";
                return result;
            }

            _context.DisplayAreas.Remove(areas);
            await _context.SaveChangesAsync();
            result.code = 200;
            result.data = areas;
            return result;
        }

        private bool Display_AreaExists(string id)
        {
            return _context.DisplayAreas.Any(e => e.AreaId == id);
        }
    }
}




