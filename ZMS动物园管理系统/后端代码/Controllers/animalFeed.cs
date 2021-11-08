/*-----------------------------------------
 * 作者：杨泽华
 * 最后修改：2021.7.15
 * 功能：动物喂养管理
 ----------------------------------------*/
using BackEnd.Data;
using BackEnd.Model;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace BackEnd.Controllers
{
    [Route("api/animalFeed")]
    [ApiController]
    public class animalFeed : ControllerBase
    {
        private readonly ModelContext _context;
        private readonly IJwtAuthenticationHandler _jwtAuthenticationHandler;
        //构造函数注入生成token的类

        public animalFeed(ModelContext context, IJwtAuthenticationHandler jwtAuthenticationHandler)
        {
            _context = context;
            _jwtAuthenticationHandler = jwtAuthenticationHandler;
        }

        /*--------------------------------------------
         * 函数名：getFeedRecord
         * API：47.118.78.110:8088/api/animalFeed/getFeedRecord
         * 参数：string? animal_id, string? keeper_id, DateTime? time
         * 功能：获取喂养记录
         * 权限：仅员工
         --------------------------------------------*/
        [Authorize(Policy = "EmployeePolicy")]
        [HttpGet("getFeedRecord/")]
        public async Task<ActionResult<backdata>> getFeedRecord(string? animal_id, string? keeper_id, DateTime? time)
        {
            var feed = await _context.Feeds.Where(a =>
            (animal_id == null || a.AnimalId == animal_id) && (keeper_id == null || a.KeeperId == keeper_id) && (time == null || a.Day == time)).ToListAsync();
            backdata result = new backdata();
            result.data = feed;

            if (feed.Count == 0)
            {
                result.code = 400;
                result.message = "查询结果为空";
            }

            return result;
        }

        /*--------------------------------------------
         * 函数名：createFeedRecord
         * API：47.118.78.110:8088/api/animalFeed/createFeedRecord
         * 参数：Feed feed
         * 功能：添加喂养记录
         * 权限：仅员工
         --------------------------------------------*/
        [Authorize(Policy = "EmployeePolicy")]
        [HttpPost("createFeedRecord/")]
        public async Task<ActionResult<backdata>> createFeedRecord(Feed feed)
        {
            backdata result = new backdata();
            if (feed.AnimalId == null || feed.Day == null || feed.FoodId == null || feed.KeeperId == null)
            {
                result.code = 400;
                result.message = "缺少必要信息";
                return result;
            }

            _context.Feeds.Add(feed);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (!AnimalExists(feed.AnimalId))
                {
                    result.code = 400;
                    result.message = "不存在该动物的信息";
                    Conflict();
                }
                else if (!EmployeeExists(feed.KeeperId))
                {
                    result.code = 400;
                    result.message = "不存在该饲养员的信息";
                    Conflict();
                }
                else if (FeedExists(feed.AnimalId))
                {
                    result.code = 400;
                    result.message = "新增喂养关系重复";
                    Conflict();
                }
                else
                {
                    throw;
                }
            }

            result.data = feed;
            return result;
        }

        /*--------------------------------------------
         * 函数名：deleteFeedRecord
         * API：47.118.78.110:8088/api/animalFeed/deleteFeedRecord
         * 参数：string id
         * 功能：删除喂养记录
         * 权限：仅员工
         --------------------------------------------*/
        [Authorize(Policy = "EmployeePolicy")]
        [HttpDelete("deleteFeedRecord/{id}")]
        public async Task<ActionResult<backdata>> deleteFeedRecord(string id)
        {
            backdata result = new backdata();
            var feed = await _context.Feeds.FindAsync(id);
            if (feed == null)
            {
                result.code = 400;
                result.message = "没有该ID";
                return result;
            }
            result.data = feed;

            _context.Feeds.Remove(feed);
            await _context.SaveChangesAsync();

            return result;
        }

        private bool FeedExists(string id)
        {
            return _context.Feeds.Any(e => e.AnimalId == id);
        }

        private bool AnimalExists(string id)
        {
            return _context.Animals.Any(e => e.Id == id);
        }

        private bool EmployeeExists(string id)
        {
            return _context.Employees.Any(e => e.Id == id);
        }
    }
}
