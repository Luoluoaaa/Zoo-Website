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


//便民服务信息管理模块（后台）

//1 查询便民服务信息管理列表
//请求方式：GET
//功能描述：查询所有符合条件的训练信息

//2 新增便民服务信息
//请求方式：POST
//功能描述：插入一条便民服务信息

//3 修改便民服务信息
//请求方式：PUT
//功能描述：修改一条便民服务信息

//4 删除便民服务信息
//请求方式：DELETE
//功能描述：删除符合条件的便民服务信息

namespace BackEnd.Controllers
{
    [Route("api/convenienceService/")]
    [ApiController]
    public class convenienceService : ControllerBase
    {
        private readonly ModelContext _context;
        private readonly IJwtAuthenticationHandler _jwtAuthenticationHandler;
        //构造函数注入生成token的类

        public convenienceService(ModelContext context, IJwtAuthenticationHandler jwtAuthenticationHandler)
        {
            _context = context;
            _jwtAuthenticationHandler = jwtAuthenticationHandler;
        }



        // GET: api/PublicServices/5
        [Authorize(Policy = "EmployeePolicy")]
        [HttpGet("getConvenienceServiceData/")]
        public async Task<ActionResult<backdata>> GetPublicService(
            string? name,
            string? intro)
        {
            var publicService = await _context.PublicServices.Where(a =>
            (name == null || a.Name == name) && (intro == null || a.Intro == intro)).ToListAsync();
            backdata result = new backdata();
            result.data = publicService;
            if(publicService.Count==0)
            {
                result.code = 400;
                result.message = "查询结果为空";
            }

            return result;
        }

        // POST: api/PublicServices

        [Authorize(Policy = "EmployeePolicy")]
        [HttpPost("createConvenienceServiceInfo/")]
        public async Task<ActionResult<backdata>> PostPublicService(
            string name,
            string? intro)
        {
            PublicService publicService = new PublicService();
            backdata result = new backdata();
            publicService.Intro = intro;
            publicService.Name = name;
            
            if (publicService.Name == null 
               )
            {
                result.code = 400;
                result.message = "缺少必要信息:需填写便民服务名称";
                
            }

            if (intro == null) publicService.Intro = "暂无";
            
                _context.PublicServices.Add(publicService);
                try
                {
                    await _context.SaveChangesAsync();
                    result.data = publicService;
                }
                catch (DbUpdateException)
                {
                    if (PublicServiceExists(publicService.Name))
                    {
                        result.code = 401;
                        result.message = "'填入的便民服务已有";
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

        // PUT: api/PublicServices/5

        [Authorize(Policy = "EmployeePolicy")]
        [HttpPut("updateConvenienceServiceInfo/")]
        public async Task<ActionResult<backdata>> PutPublicService(
            string name, 
            string? intro)
        {
            PublicService publicService = new PublicService();
            backdata result = new backdata();
            publicService.Intro = intro;
            publicService.Name = name;
            
            if (publicService.Name == null )
            {
                result.code = 400;
                result.message = "缺少必要信息";
            }

            if (intro == null) publicService.Intro = "暂无";
            _context.Entry(publicService).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
                result.data = publicService;
            }
            catch (DbUpdateConcurrencyException)
            {
                if (PublicServiceExists(publicService.Name))
                {
                    result.code = 401;
                    result.message = "'填入的便民服务已有";
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



        // DELETE: api/PublicServices/5
        [Authorize(Policy = "EmployeePolicy")]
        [HttpDelete("deleteConvenienceServiceInfo/")]
        public async Task<ActionResult<backdata>> DeletePublicService(
            string name)
        {
            backdata result = new backdata();
            var publicService = await _context.PublicServices.FindAsync(name);
            if (publicService == null)
            {
                result.code = 405;
                result.message = "没有该服务";
                return result;
            }
            result.data = publicService;
            _context.PublicServices.Remove(publicService);
            await _context.SaveChangesAsync();

            return result;
        }
        
        private bool PublicServiceExists(string id)
        {
            return _context.PublicServices.Any(e => e.Name == id);
        }
    }
}
