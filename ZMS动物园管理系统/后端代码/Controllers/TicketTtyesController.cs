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

//演出票务管理模块（后台）

//1 查找票务信息列表
//请求方式：GET
//功能描述：查询所有符合条件的表演票务信息（非流水）

//2 修改票务信息
//请求方式：PUT
//功能描述：修改一条表演票务信息

namespace BackEnd.Controllers
{
    [Route("api/showTicketManagement/")]
    [ApiController]
    public class TicketTtyesController : ControllerBase
    {
        private readonly ModelContext _context;
        private readonly IJwtAuthenticationHandler _jwtAuthenticationHandler;
        //构造函数注入生成token的类

        public TicketTtyesController(ModelContext context, IJwtAuthenticationHandler jwtAuthenticationHandler)
        {
            _context = context;
            _jwtAuthenticationHandler = jwtAuthenticationHandler;
        }

        // GET: api/TicketTtyes
        [Authorize(Policy = "EmployeePolicy")]
        [HttpGet]
        public async Task<ActionResult<IEnumerable<TicketTtye>>> GetTicketTtyes()
        {
            return await _context.TicketTtyes.ToListAsync();
        }

        // GET: api/TicketTtyes/5-----后台
        [Authorize(Policy = "EmployeePolicy")]
        [HttpGet("getShowTicketData/")]
        public async Task<ActionResult<backdata>> GetTicketTtye(
            string? show_id,
            string? price,
            string? Ticket_type,
            string? Amount)
        {
            var ticketTtye = await _context.TicketTtyes.Where(a =>
            (show_id == null || a.Id == show_id) &&
            (price == null || a.Price == price) &&
            (Ticket_type == null || a.Type == Ticket_type) &&
            (Amount == null || a.Amount == Amount)).ToListAsync();

            backdata result = new backdata();
            result.data = ticketTtye;
            if (ticketTtye == null)
            {
                result.code = 400;
                result.message = "查询结果为空";
            }

            return result;
        }



        // PUT: api/TicketTtyes/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [Authorize(Policy = "EmployeePolicy")]
        [HttpPut("updateShowTicketInfo/")]
        public async Task<ActionResult<backdata>> PutTicketTtye(
            string show_id,
            string? price,
            string? Ticket_type,
            string? Amount)
        {
            backdata result = new backdata();
            TicketTtye ticketTtye = new TicketTtye();
            ticketTtye.Id = show_id;
            ticketTtye.Price = price;
            ticketTtye.Type = Ticket_type;
            ticketTtye.Amount = Amount;
            if (show_id==null||
                Ticket_type==null)
            {
                result.code = 400;
                result.message = "缺少必要信息:需填写票价和票种";
            }
            TicketTtye tmp = await _context.TicketTtyes.FindAsync(ticketTtye.Id,Ticket_type);
            if (tmp == null)
            {
                result.code = 402;
                result.message = "未找到改动目标";
                return result;
            }
            _context.TicketTtyes.Remove(tmp);
            if (Amount == null) ticketTtye.Amount = " ";
                _context.Entry(ticketTtye).State = EntityState.Modified;
                try
                {
                    _context.TicketTtyes.Add(ticketTtye);
                    await _context.SaveChangesAsync();
                    result.data = ticketTtye;
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (TicketTtyeExists(ticketTtye.Id))
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


      
        private bool TicketTtyeExists(string id)
        {
            return _context.TicketTtyes.Any(e => e.Id == id);
        }
    }
}
