using System;
using BackEnd.Data;
using BackEnd.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;

//用于后台员工关于门票管理的相关功能
namespace BackEnd.Controllers
{
    [Route("api/TicketsAdmiss/")]
    [ApiController]
    public class TicketsAdmiss : ControllerBase
    {
        private readonly ModelContext _context;
        private readonly IJwtAuthenticationHandler _jwtAuthenticationHandler;
        //构造函数注入生成token的类

        public TicketsAdmiss(ModelContext context, IJwtAuthenticationHandler jwtAuthenticationHandler)
        {
            _context = context;
            _jwtAuthenticationHandler = jwtAuthenticationHandler;
        }
        [Authorize(Policy = "EmployeePolicy")]
        [HttpGet("getAdmissData/")]
        public async Task<ActionResult<backdata>> getinformation(string? type, int? price, string? starttime, string? endtime, string? date)
        {

            var tickets = await _context.AdmissionTickets.Where(t =>
            (type == null || t.TicketType == type) && (price == null || t.Price == price) &&
            (starttime == null || t.StartTime == Convert.ToDateTime(date + " " + starttime)) &&
            (endtime == null || t.EndTime == Convert.ToDateTime(date + " " + endtime)) &&
            (date == null || t.EnteringDate == Convert.ToDateTime(date))).ToListAsync();
            backdata result = new backdata();
            result.data = tickets;


            if (tickets == null)
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
        [HttpDelete("deleteAdmissInfo/")]
        public async Task<ActionResult<backdata>> deleteinformation(string id)
        {
            backdata result = new backdata();
            var ticket = await _context.AdmissionTickets.FindAsync(id);
            if (ticket == null)
            {
                result.code = 407;
                result.message = "没有该ID";
                return result;
            }

            _context.AdmissionTickets.Remove(ticket);
            await _context.SaveChangesAsync();
            result.code = 200;
            result.data = ticket;
            return result;
        }

        private bool Admission_TicketExists(string id)
        {
            return _context.AdmissionTickets.Any(e => e.Id == id);
        }
    }
}



