using System;
using BackEnd.Data;
using BackEnd.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;

//用于前台游客购买门票的相关功能
namespace BackEnd.Controllers
{
    [Route("api/admissionT/")]
    [ApiController]
    public class admissionT : ControllerBase
    {
        
        private readonly ModelContext _context;
        private readonly IJwtAuthenticationHandler _jwtAuthenticationHandler;
        //构造函数注入生成token的类

        public admissionT(ModelContext context, IJwtAuthenticationHandler jwtAuthenticationHandler)
        {
            _context = context;
            _jwtAuthenticationHandler = jwtAuthenticationHandler;
        }
        
        [Authorize(Policy = "TouristPolicy")]
        [HttpPost("createAdmissInfo/")]
        public async Task<ActionResult<backdata>> createinformation(string type, string starttime, string date, string tourid)
        {
            backdata result = new backdata();
            if (type == null || starttime == null || date == null || tourid == null)
            {
                result.code = 403;
                result.message = "缺少必要信息";
                return result;
            }
            AdmissionTicket ticket = new AdmissionTicket();
            if (type == "全价票") ticket.Price = 250;
            else if (type == "儿童票") ticket.Price = 175;
            else if (type == "长者票") ticket.Price = 175;
            else if (type == "优待票") ticket.Price = 175;
            else if (type == "学生票") ticket.Price = 200;
            else if (type == "夜场票") ticket.Price = 100;
            else if (type == "畅享套票（全价）") ticket.Price = 520;
            else if (type == "畅享套票（优惠）") ticket.Price = 488;
            else if (type == "畅享套票（学生）") ticket.Price = 499;
            else
            {
                result.code = 402;
                result.message = "填入的票种不存在";
                return result;
            }

            var id = await _context.AdmissionTickets.MaxAsync(t => Convert.ToInt32(t.Id));
            ticket.Id = Convert.ToString(id + 1);
            ticket.EnteringDate = Convert.ToDateTime(date);
            ticket.StartTime = Convert.ToDateTime(date + " " + starttime);
            ticket.EndTime = ticket.StartTime.AddHours(4);
            ticket.TourId = tourid;
            ticket.TicketType = type;

            if (ticket.StartTime >= ticket.EndTime)
            {
                result.code = 401;
                result.message = "日期不合法";
                
            }

            else
            {
                _context.AdmissionTickets.Add(ticket);
                try
                {
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateException)
                {
                    throw;
                }
                result.code = 200;
                result.data = ticket;
            }
            return result;   
        }
       
        private bool Admission_TicketExists(string id)
        {
            return _context.AdmissionTickets.Any(e => e.Id == id);
        }
    }
}



