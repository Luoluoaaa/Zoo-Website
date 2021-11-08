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

//演出信息管理模块（后台）
//4个功能

//1 查询演出信息管理列表
//请求方式：GET
//功能描述：查询所有符合条件的表演信息

//2 新增表演信息
//请求方式：POST
//功能描述：插入一条表演信息

//3 修改演出信息
//请求方式：PUT
//功能描述：修改一条演出信息

//4 删除演出信息
//请求方式：POST
//功能描述：删除符合条件的所有演出信息


namespace BackEnd.Controllers
{
    [Route("api/animalShow/")]
    [ApiController]
    public class animalShow : ControllerBase
    {
        private readonly ModelContext _context;
        private readonly IJwtAuthenticationHandler _jwtAuthenticationHandler;

        public animalShow(ModelContext context, IJwtAuthenticationHandler jwtAuthenticationHandler)
        {
            _context = context;
            _jwtAuthenticationHandler = jwtAuthenticationHandler;

        }
        [Authorize(Policy = "EmployeePolicy")]
        // GET: api/ShowInformations
        [HttpGet("getShowData/")]
        public async Task<ActionResult<backdata>> GetShowInformations(
            string? show_id,
            string? show_name, 
            string? principal_id,
            string? show_date,
            string? start_time,
            string? end_time,
            string? show_site,
            string? show_props
            )
        {
            backdata result = new backdata();
            
            var s = await _context.ShowInformations.Where(a =>
             (show_id == null || a.ShowId == show_id) && (show_name == null || a.ShowName == show_name) &&
             (principal_id == null || a.PrincipalName == principal_id)
             && (show_date == null || a.ShowDate ==Convert.ToDateTime( show_date)) && (start_time == null || a.StartTime ==Convert.ToDateTime( start_time))
             && (end_time == null || a.EndTime ==Convert.ToDateTime(end_time)) && (show_site == null || a.ShowSite == show_site)
             && (show_props == null || a.ShowProps == show_props)).ToListAsync();
            
            result.data = s;
            if (s == null)
            {
                result.code = 400;
                result.message = "查询结果为空";
            }

            return result;
        }

        // POST: api/ShowInformations

        [Authorize(Policy = "EmployeePolicy")]
        [HttpPost("createShowInfo/")]
        public async Task<ActionResult<backdata>> PostShowInformation(
            
            string show_name,
            string principal_id,
            string? show_date,
            string? start_time,
            string? end_time,
            string? show_site,
            string? show_props)
        {
            backdata result = new backdata();

            if (
                show_name == null|| 
                principal_id==null
                )
            
            {
                result.code = 400;
                result.message = "缺少必要信息:需填写负责人姓名和演出名称";
                return result;
            }



            else
            {
                ShowInformation Information = new ShowInformation();
                Information.ShowDate = Convert.ToDateTime(show_date);
                var showid = await (_context.ShowInformations.MaxAsync(t => Convert.ToInt32(t.ShowId)));
                Information.ShowId = Convert.ToString(showid + 1);
                Information.ShowName = show_name;
                Information.PrincipalName = principal_id;
                Information.ShowProps = show_props;
                Information.StartTime = Convert.ToDateTime(start_time);
                Information.EndTime = Convert.ToDateTime(end_time);
                Information.ShowSite = show_site;

                
                if (show_name == null) Information.ShowName = "xx表演";
                if (show_date == null) Information.ShowDate = Convert.ToDateTime("00:00:00");
                if (principal_id == null) Information.PrincipalName = "张xx";
                if (show_props == null) Information.ShowProps = "暂无";
                if (start_time == null) Information.StartTime = Convert.ToDateTime("00:00:00");
                if (end_time == null) Information.EndTime = Convert.ToDateTime("00:00:00");
                if (show_site == null) Information.ShowSite = "xx馆";

                _context.ShowInformations.Add(Information);
                try
                {
                    await _context.SaveChangesAsync();
                    result.data = Information;

                }
                catch (DbUpdateException)
                {
                    if (ShowInformationExists(Information.ShowId))
                    {
                        result.code = 401;
                        result.message = "填入的演出编号要为已有演出";
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

        // PUT: api/ShowInformations/5

        [Authorize(Policy = "EmployeePolicy")]
        [HttpPut("updateShowInfo/")]
        public async Task<ActionResult<backdata>> PutShowInformation(
            string show_id,
            string? show_name,
            string? principal_id,
            string? show_date,
            string? start_time,
            string? end_time,
            string? show_site,
            string? show_props)
        {
            backdata result = new backdata();
            ShowInformation Information = new ShowInformation();
            Information.ShowDate = Convert.ToDateTime(show_date);
            Information.ShowId = show_id;
            Information.ShowName = show_name;
            Information.PrincipalName = principal_id;
            Information.ShowProps = show_props;
            Information.StartTime = Convert.ToDateTime(start_time);
            Information.EndTime = Convert.ToDateTime(end_time);
            Information.ShowSite = show_site;
            if (Information.ShowId==null||
                show_name==null||
                principal_id == null)
            {
                result.code = 400;
                result.message = "缺少必要信息:需填写负责人姓名和演出名称";
            }
            
            ShowInformation tmp = await _context.ShowInformations.FindAsync(Information.ShowId);
            if (tmp == null)
            {
                result.code = 402;
                result.message = "未找到改动目标";
                return result;
            }
            _context.ShowInformations.Remove(tmp);
            if (show_name == null) Information.ShowName = "xx表演";
            if (show_date == null) Information.ShowDate = Convert.ToDateTime("00:00:00");
            if (principal_id == null) Information.PrincipalName = "张xx";
            if (show_props == null) Information.ShowProps = "暂无";
            if (start_time == null) Information.StartTime = Convert.ToDateTime("00:00:00");
            if (end_time == null) Information.EndTime = Convert.ToDateTime("00:00:00");
            if (show_site == null) Information.ShowSite = "xx馆";
            

            

                _context.Entry(Information).State = EntityState.Modified;

                try
                {
                    _context.ShowInformations.Add(Information);
                    await _context.SaveChangesAsync();
                    result.data = Information;
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (ShowInformationExists(Information.ShowId))
                    {
                        result.code = 401;
                        result.message = "填入的演出编号要为已有演出";
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



        // DELETE: api/ShowInformations/5
        [Authorize(Policy = "EmployeePolicy")]
        [HttpDelete("deleteShowInfo/")]
        public async Task<ActionResult<backdata>> DeleteShowInformation(
            string show_id)
        {
            backdata result = new backdata();
            var showInformation = await _context.ShowInformations.FindAsync(show_id);
            if (showInformation == null)
            {
                result.code = 405;
                result.message = "没有该ID";
                return result;
            }
            result.data = showInformation;

            _context.ShowInformations.Remove(showInformation);
            await _context.SaveChangesAsync();

            return result;
        }

        private bool ShowInformationExists(string id)
        {
            return _context.ShowInformations.Any(e => e.ShowId == id);
        }
    }
}
