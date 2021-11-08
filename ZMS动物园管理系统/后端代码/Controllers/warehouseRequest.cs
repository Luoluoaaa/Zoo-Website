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

//仓库物品管理模块
//4个功能

//1 获取物品
//请求方式：GET
//功能描述：查询所有物品或某一物品的所有信息

//2 新增物品
//请求方式：POST
//功能描述：新增一个物品信息

//3 删除物品
//请求方式：DELETE
//功能描述：删除某一物品信息

//4 增加/减少物品数目
//请求方式：PUT
//功能描述：修改某一仓库或所有仓库的某一物品数量

namespace BackEnd.Controllers
{
    [Route("api/warehouseRequest/")]
    [ApiController]
    public class warehouseRequest : ControllerBase
    {
        private readonly ModelContext _context;
        private readonly IJwtAuthenticationHandler _jwtAuthenticationHandler;
        //构造函数注入生成token的类

        public warehouseRequest(ModelContext context, IJwtAuthenticationHandler jwtAuthenticationHandler)
        {
            _context = context;
            _jwtAuthenticationHandler = jwtAuthenticationHandler;
        }



        // GET: api/Goods/5
        [HttpGet("getwareItemInfo")]
        public async Task<ActionResult<backdata>> GetGood(
            string? id,
            string? ware_id,
            string? staff_id,
            string? name
            )
        {
            backdata result = new backdata();
            var good = await (from g in _context.Goods
                              join
                               gs in _context.GoodStores
                              on g.ItemId equals gs.ItemId
                              join
                               s in _context.Stores
                               on gs.StoreId equals s.StoreId
                              where ((id == null || id == g.ItemId)
                              && (ware_id == null || ware_id == gs.StoreId)
                              && (staff_id == null || staff_id == g.StaffId)
                              && (name == null || name == g.Name))
                              select new
                              {
                                  g.ItemId,
                                  g.Type,
                                  g.Name,
                                  g.Channel,
                                  g.StaffId,
                                  gs.ItemCounts,
                                  gs.StoreId
                              }).ToListAsync();
            result.data = good;
             if (good == null)
             {
                result.code = 400;
                result.message = "缺少必要信息";
            }
            
            return result;
        }

        // POST: api/Goods

        [Authorize(Policy = "EmployeePolicy")]
        [HttpPost("createItem")]
        public async Task<ActionResult<backdata>> PostGood(
            string ItemId,
            string StoreId,
            decimal ItemCounts,
            string Type,
            string Name,
            decimal Price,
            string Target,
            string Channel,
            string StoreCondition,
            string UsageMethod,
            string StaffId,
            string Remark
            )
        {
            backdata result = new backdata();
            Good good = new Good();
            var tmp=await _context.Goods.FindAsync(ItemId);
            if (tmp == null)
            {              
                good.ItemId = ItemId;
                good.Type = Type;
                good.Name = Name;
                good.Price = Price;
                good.Target = Target;
                good.Channel = Channel;
                good.StoreCondition = StoreCondition;
                good.UsageMethod = UsageMethod;
                good.StaffId = StaffId;
                good.Remark = Remark;


                
                if (Type == null) good.Type = "暂无";
                if (Price == 0) good.Price = 0;
                if (Target == null) good.Target = "暂无";
                if (Channel == null) good.Channel = "暂无";
                if (StoreCondition == null) good.StoreCondition = "暂无";
                if (UsageMethod == null) good.UsageMethod = "暂无";
                if (StaffId == null) good.StaffId = "暂无";
                if (Remark == null) good.Remark = "暂无";

                _context.Goods.Add(good);

            }
            else
            {
                if(tmp.Name!=Name||
                  tmp.Type != Type ||
                  tmp.Price != Price ||
                  tmp.Target != Target ||
                  tmp.Channel != Channel ||
                  tmp.StoreCondition != StoreCondition ||
                  tmp.UsageMethod != UsageMethod ||
                  tmp.StaffId != StaffId ||

                  tmp.Remark != Remark )
                {
                    result.code = 406;
                    result.message = "该物品编号所对应的物品属性与数据库中的物品属性不一致，请检查输入";
                    return result;
                }
            }
            if (ItemId==null||
                StoreId==null||
                Name==null)
            {
                result.code = 400;
                result.message = "缺少必要信息：需填写物品编号或仓库编号或物品名称";
                return result;
            }

            GoodStore gs = new GoodStore();
            if (ItemCounts == 0) gs.ItemCounts = 0;
            gs.ItemId = ItemId;
            gs.StoreId = StoreId;

            _context.GoodStores.Add(gs);

            try
            {
                await _context.SaveChangesAsync();
                if(tmp==null)
                    result.data = good;
                if (tmp != null)
                    result.data = tmp;
            }
            catch (DbUpdateException)
            {
                
                    throw;
                
            }

            return result;
        }

        // DELETE: api/Goods/5
        [Authorize(Policy = "EmployeePolicy")]
        [HttpDelete("deleteItem/")]
        public async Task<ActionResult<backdata>> DeleteGood(
            string ItemId)
        {
            backdata result = new backdata();
            var good = await _context.Goods.FindAsync(ItemId);
            var gs = await _context.GoodStores.Where(a => a.ItemId == ItemId).ToListAsync();

            if (good == null)
            {
                result.code = 405;
                result.message = "没有该物品";
                return result;
            }
            result.data = good;
            _context.Goods.Remove(good);
            foreach(GoodStore i in gs)
            {
                _context.GoodStores.Remove(i);
            }
            
            await _context.SaveChangesAsync();
            return result ;
        }


        // PUT: api/Goods/5
 
        [Authorize(Policy = "EmployeePolicy")]
        [HttpPut("modifyItem/")]
        public async Task<ActionResult<backdata>> PutGood(
            string id, 
            string store_id,
            decimal cnt)
        {
            backdata result = new backdata();

            if (id ==null)
            {
                result.code = 400;
                result.message = "缺少必要信息";
                return result;
            }
            var query = await _context.GoodStores.Where(
                (a => (a.ItemId == id) && (a.StoreId == store_id||store_id==null))).ToListAsync();

            foreach(GoodStore i in query)
            {        
                if((i.ItemCounts + cnt)>=0)
                    i.ItemCounts = i.ItemCounts + cnt;
                else
                {
                    result.code = 407;
                    result.message = "修改后的物品数量不能为负数";
                    return result;
                }
                        
                _context.Entry(i).State = EntityState.Modified;
            }
  

            try
            {
                await _context.SaveChangesAsync();
                result.data = query;
            }
            catch (DbUpdateConcurrencyException)
            {
                
                    throw;
                
            }

            return result;
        }
        
        

       
        
        private bool GoodExists(string id)
        {
            return _context.Goods.Any(e => e.ItemId == id);
        }
    }
}
