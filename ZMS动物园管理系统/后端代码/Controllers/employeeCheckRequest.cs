using System;
using BackEnd.Data;
using BackEnd.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;

//用于后台员工考核管理的相关功能
namespace BackEnd.Controllers
{
    [Route("api/employeeCheckRequest/")]
    [ApiController]
    public class employeeCheckRequest : ControllerBase
    {
        private readonly ModelContext _context;
        private readonly IJwtAuthenticationHandler _jwtAuthenticationHandler;
        //构造函数注入生成token的类

        public employeeCheckRequest(ModelContext context, IJwtAuthenticationHandler jwtAuthenticationHandler)
        {
            _context = context;
            _jwtAuthenticationHandler = jwtAuthenticationHandler;
        }
        [Authorize(Policy = "EmployeePolicy")]
        [HttpGet("getEmployeeCheckInfo/")]
        public async Task<ActionResult<backdata>> getinformation(string? employeeid, string? managerid, string? assessmenttime, string? assessmentgrade)
        {
            //return await _context.AdmissionTickets.ToListAsync();
            var assessments = await _context.Assessments.Where(t =>
            (employeeid == null || t.EmployeeId == employeeid) &&
            (managerid == null || t.ManagerId == managerid) &&
            (assessmenttime == null || t.AssessmentTime == Convert.ToDateTime(assessmenttime)) &&
            (assessmentgrade == null || t.AssessmentGrade == assessmentgrade)).ToListAsync();
            
            backdata result = new backdata();
            result.data = assessments;
            if (assessments == null)
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
        
        [Authorize(Policy = "AdminPolicy")]
        [HttpPost("createEmployeeCheckInfo/")]
        public async Task<ActionResult<backdata>> createinformation(string employeeid, string managerid, string assessmenttime, string assessmentgrade, string remarks)
        {
            backdata result = new backdata();
            if (employeeid == null || managerid == null || assessmenttime == null || assessmentgrade == null || remarks == null)
            {
                result.code = 403;
                result.message = "缺少必要信息";
                return result;
            }
            if (employeeid == managerid)
            {
                result.code = 406;
                result.message = "员工id与考核人员id不得相同";
                return result;
            }
            var query1 = from t1 in _context.Employees
                         where t1.Id == employeeid
                         select new
                         {
                             t1.Id
                         };
            var q1 = await query1.ToListAsync();
            if (q1.Count == 0)
            {
                result.code = 404;
                result.message = "不存在该员工id";
                return result;
            }
            var query2 = from t2 in _context.Employees
                         where t2.Id == managerid
                         select new
                         {
                             t2.Id
                         };
            var q2 = await query2.ToListAsync();
            if (q2.Count == 0)
            {
                result.code = 405;
                result.message = "不存在该考核人员id";
                return result;
            }

            Assessment assessments = new Assessment();
            assessments.EmployeeId = employeeid;
            assessments.ManagerId = managerid;
            assessments.AssessmentTime = Convert.ToDateTime(assessmenttime);
            assessments.AssessmentGrade = assessmentgrade;
            assessments.Remarks = remarks;

            _context.Assessments.Add(assessments);
            try
            {
                await _context.SaveChangesAsync();
                result.code = 200;
                result.data = assessments;
            }
            catch (DbUpdateException)
            {
                if (AssessmentExists(assessments.EmployeeId, assessments.ManagerId, assessments.AssessmentTime))
                {
                    result.code = 401;
                    result.message = "工作人员工号、管理人员工号工号、考核时间三者均重复";
                    Conflict();
                }
                else
                {
                    throw;
                }
            }
            
            return result;


        }
        [Authorize(Policy = "AdminPolicy")]
        [HttpPut("updateEmployeeCheckInfo/")]
        public async Task<ActionResult<backdata>> updateinformation(string employeeid, string managerid, string assessmenttime, string assessmentgrade, string remarks)
        {
            backdata result = new backdata();
            if (employeeid == null || managerid == null || assessmenttime == null)
            {
                result.code = 403;
                result.message = "缺少必要信息";
                return result;
            }

            Assessment assessments = await _context.Assessments.FindAsync(employeeid, managerid, Convert.ToDateTime(assessmenttime));
            if (assessments == null)
            {
                result.code = 404;
                result.message = "未找到改动目标";
                return result;
            }

            if (assessmentgrade != null) assessments.AssessmentGrade = assessmentgrade;
            if (remarks != null) assessments.Remarks = remarks;

            _context.Entry(assessments).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            result.code = 200;
            result.data = assessments;

            return result;
        }
        [Authorize(Policy = "AdminPolicy")]
        [HttpDelete("deleteEmployeeCheckInfo/")]
        public async Task<ActionResult<backdata>> deleteinformation(string employeeid, string managerid, string assessmenttime)
        {
            backdata result = new backdata();
            var assessments = await _context.Assessments.FindAsync(employeeid, managerid, Convert.ToDateTime(assessmenttime));
            if (assessments == null)
            {
                result.code = 408;
                result.message = "未找到删除目标";
                return result;
            }

            _context.Assessments.Remove(assessments);
            await _context.SaveChangesAsync();
            result.code = 200;
            result.data = assessments;
            return result;
        }
        
        private bool AssessmentExists(string employeeid, string managerid, DateTime assessmenttime)
        {
            return _context.Assessments.Any(e => e.EmployeeId == employeeid && e.ManagerId == managerid && e.AssessmentTime == assessmenttime);
        }
    }
}




