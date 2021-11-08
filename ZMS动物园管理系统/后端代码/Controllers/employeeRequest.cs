using System;
using BackEnd.Data;
using BackEnd.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;

//用于后台员工管理的相关功能
namespace BackEnd.Controllers
{
    [Route("api/employeeRequest/")]
    [ApiController]
    public class employeeRequest : ControllerBase
    {
        private readonly ModelContext _context;
        private readonly IJwtAuthenticationHandler _jwtAuthenticationHandler;
        //构造函数注入生成token的类

        public employeeRequest(ModelContext context, IJwtAuthenticationHandler jwtAuthenticationHandler)
        {
            _context = context;
            _jwtAuthenticationHandler = jwtAuthenticationHandler;
        }
        [Authorize(Policy = "EmployeePolicy")]
        [HttpGet("getEmployeeInfo/")]
        public async Task<ActionResult<backdata>> getinformation(string? id, string? name, string? park, string? position)
        {
            //return await _context.AdmissionTickets.ToListAsync();
            var employees = await _context.Employees.Where(t =>
            (id == null || t.Id == id) && 
            (name == null || t.Name == name) &&
            (park == null || t.Park == park) &&
            (position == null || t.Position == position)).ToListAsync();
            backdata result = new backdata();
            result.data = employees;

            if (employees == null)
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
        [HttpPost("createEmployeeInfo/")]
        public async Task<ActionResult<backdata>> createinformation(string id, string name, string gender, decimal age, int wage, string position, string park, string employmentYear,string password)
        {
            backdata result = new backdata();
            if (id == null || name == null || gender == null || age < 0 || wage < 0 || position == null || park == null || employmentYear == null)
            {
                result.code = 403;
                result.message = "缺少必要信息";
                return result;
            }
            else
            {
                Employee employees = new Employee();
                employees.Id = id;
                employees.Name = name;
                employees.Gender = gender;
                employees.Age = age;
                employees.Wage = wage;
                employees.Position = position;
                employees.Park = park;
                employees.EmploymentYear = Convert.ToDateTime(employmentYear + ".1.1");
                employees.Password = password;

                _context.Employees.Add(employees);
                try
                {
                    await _context.SaveChangesAsync();
                    result.code = 200;
                    result.data = employees;
                }

                catch (DbUpdateException)
                {
                    if (EmployeeExists(employees.Id))
                    {
                        result.code = 401;
                        result.message = "新增员工ID重复";
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
        [Authorize(Policy = "AdminPolicy")]
        [HttpPut("updateEmployeeInfo/")]
        public async Task<ActionResult<backdata>> updateinformation(string? id, string? name, string? gender, decimal age, int wage, string? position, string? park, string? employmentYear, string? password)
        {
            backdata result = new backdata();
            if (id == null)
            {
                result.code = 403;
                result.message = "缺少必要信息";
                return result;
            }
            if (age < 0)
            {
                result.code = 405;
                result.message = "年龄不合法";
                return result;
            }
            if (wage < 0)
            {
                result.code = 406;
                result.message = "工资不合法";
                return result;
            }
            Employee tmp = await _context.Employees.FindAsync(id);
            if (tmp == null)
            {
                result.code = 404;
                result.message = "未找到改动目标";
                return result;
            }
            Employee employees = new Employee();
            if (id != null) employees.Id = id;
            if (name != null) employees.Name = name;
            if (gender != null) employees.Gender = gender;
            employees.Age = age;
            employees.Wage = wage;
            if (position != null) employees.Position = position;
            if (park != null) employees.Park = park;
            if (employmentYear != null) employees.EmploymentYear = Convert.ToDateTime(employmentYear + ".1.1");
            if (password != null) employees.Password = password;
            _context.Employees.Remove(tmp);


            _context.Entry(employees).State = EntityState.Modified;
            try
            {
                _context.Employees.Add(employees);
                await _context.SaveChangesAsync();
                result.data = employees;
            }
            catch (DbUpdateConcurrencyException)
            {
                throw;
            }
            return result;
        }
        [Authorize(Policy = "AdminPolicy")]
        [HttpDelete("deleteEmployeeInfo/")]
        public async Task<ActionResult<backdata>> deleteinformation(string id)
        {
            backdata result = new backdata();
            var employees = await _context.Employees.FindAsync(id);
            if (employees == null)
            {
                result.code = 408;
                result.message = "没有该ID";
                return result;
            }

            _context.Employees.Remove(employees);
            await _context.SaveChangesAsync();
            result.code = 200;
            result.data = employees;
            return result;
        }

        private bool EmployeeExists(string id)
        {
            return _context.Employees.Any(e => e.Id == id);
        }
    }
}




