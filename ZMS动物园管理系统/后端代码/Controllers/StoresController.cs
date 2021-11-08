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

//仓库管理模块
//3个功能

//1 获取所有仓库信息
//请求方式：GET
//功能描述：查询所有仓库信息

//2 新建仓库
//请求方式：POST
//功能描述：新建一个仓库

//3 删除仓库
//请求方式：DELETE
//功能描述：删除一个已有仓库

namespace BackEnd.Controllers
{
    [Route("api/warehouseRequest/")]
    [ApiController]
    public class StoresController : ControllerBase
    {
        private readonly ModelContext _context;
        private readonly IJwtAuthenticationHandler _jwtAuthenticationHandler;
        //构造函数注入生成token的类

        public StoresController(ModelContext context, IJwtAuthenticationHandler jwtAuthenticationHandler)
        {
            _context = context;
            _jwtAuthenticationHandler = jwtAuthenticationHandler;
        }



        // GET: api/Stores/5
        [Authorize(Policy = "EmployeePolicy")]
        [HttpGet("getWarehouseInfo/")]
        public async Task<ActionResult<backdata>> GetStore(
            string? id,
            string? name,
            string? location)
        {
            backdata result = new backdata();
            var store = await _context.Stores.Where(a =>
            (id == null || id == a.StoreId)
            && (name == null || name == a.Name)
            && (location == null || location == a.Location)).ToListAsync();
            result.data = store;

            if (store == null)
            {
                result.code = 400;
                result.message = "查询结果为空";
            }

            return result;
        }

        // POST: api/Stores

        [Authorize(Policy = "EmployeePolicy")]
        [HttpPost("createWarehouse/")]
        public async Task<ActionResult<backdata>> PostStore(
            string id,
            string? name,
            string? location)
        {
            backdata result = new backdata();
            Store store = new Store();
            store.Name = name;
            store.Location = location;
            store.StoreId = id;
            if(id==null)
            {
                result.code = 400;
                result.message = "缺少必要信息";
                return result;
            }

            _context.Stores.Add(store);
            try
            {
                await _context.SaveChangesAsync();
                result.data = store;
            }
            catch (DbUpdateException)
            {
                if (StoreExists(store.StoreId))
                {
                    result.code = 401;
                    result.message = "填入的仓库编号要为已有仓库";
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

        // DELETE: api/Stores/5
        [Authorize(Policy = "EmployeePolicy")]
        [HttpDelete("deleteWarehouse/")]
        public async Task<ActionResult<backdata>> DeleteStore(
            string id)
        {
            var store = await _context.Stores.FindAsync(id);
            backdata result = new backdata();
            if (store == null)
            {
                result.code = 405;
                result.message = "没有该ID";
                return result;
            }
            result.data = store;

            _context.Stores.Remove(store);
            await _context.SaveChangesAsync();

            return result;
            
        }
       
        private bool StoreExists(string id)
        {
            return _context.Stores.Any(e => e.StoreId == id);
        }
    }
}
