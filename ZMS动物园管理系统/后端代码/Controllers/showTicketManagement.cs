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

//演出票务流水管理模块（后台）


//1 查询表演票务流水信息列表
//请求方式：GET
//功能描述：查询所有符合条件的表演票务信息

//2 删除票务流水信息
//请求方式：DELETE
//功能描述：删除一条表演票务信息




namespace BackEnd.Controllers
{
    [Route("api/showTicketManagement/")]
    [ApiController]
    public class showTicketManagement : ControllerBase
    {
        private readonly ModelContext _context;
        private readonly IJwtAuthenticationHandler _jwtAuthenticationHandler;
        //构造函数注入生成token的类

        public showTicketManagement(ModelContext context, IJwtAuthenticationHandler jwtAuthenticationHandler)
        {
            _context = context;
            _jwtAuthenticationHandler = jwtAuthenticationHandler;
        }


        // GET: api/ShowTickets/5
        [Authorize(Policy = "EmployeePolicy")]
        [HttpGet("getShowTicketFlowInfo/")]
        public async Task<ActionResult<backdata>> GetShowTicket(
            string? ID,
            string? show_id,
            string? tour_id,
            string? Ticket_type)
        {

            var showTicket = await _context.ShowTickets.Where(a =>
            (ID == null || a.Id == ID) &&
            (show_id == null || a.ShowId == show_id) &&
            (tour_id == null || a.Tourid == tour_id) &&
            (Ticket_type == null || a.TicketType == Ticket_type)).ToListAsync();
            backdata result = new backdata();
            result.data = showTicket;
            if (showTicket == null)
            {
                result.code = 400;
                result.message = "查询结果为空";
            }

            return result;
        }

        // DELETE: api/ShowTickets/5
        [Authorize(Policy = "EmployeePolicy")]
        [HttpDelete("deleteShowTicketFlowInfo/")]
        public async Task<ActionResult<backdata>> DeleteShowTicket(
            string ID
            )
        {
            var showTicket = await _context.ShowTickets.FindAsync(ID);
            backdata result = new backdata();
     
            if (showTicket == null)
            {
                result.code = 405;
                result.message = "没有该ID";
                return result;
            }
            result.data = showTicket;

            _context.ShowTickets.Remove(showTicket);
            await _context.SaveChangesAsync();

            return result;
        }

       
        private bool ShowTicketExists(string id)
        {
            return _context.ShowTickets.Any(e => e.Id == id);
        }
    }
}
