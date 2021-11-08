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

//演出票服务（前台）
//3个功能

//1 查询演出票票价信息列表
//请求方式：GET
//功能描述：查询所需票种的票务信息
//备注：全价票、优惠票、学生票、VIP票

//2 查询演出票票务信息列表
//请求方式：GET
//功能描述：查询当前的演出信息
//查询流水记录

//3 生成演出票订单信息
//请求方式：POST
//功能描述：插入一条订单信息请求



namespace BackEnd.Controllers
{
    [Route("api/showT/")]
    [ApiController]
    public class showT : ControllerBase
    {
        private readonly ModelContext _context;
        private readonly IJwtAuthenticationHandler _jwtAuthenticationHandler;
        //构造函数注入生成token的类

        public showT(ModelContext context, IJwtAuthenticationHandler jwtAuthenticationHandler)
        {
            _context = context;
            _jwtAuthenticationHandler = jwtAuthenticationHandler;
        }



        // GET: api/ShowTickets2/5
        [Authorize(Policy = "TouristPolicy")]
        [HttpPost("createShowT/")]
        public async Task<ActionResult<backdata>> PostShowTicket(
            string ID,
            string show_id,
            string Ticket_type)
        {

            ShowTicket showTicket = new ShowTicket();
            backdata result = new backdata();
                        

            var Id = await _context.ShowTickets.MaxAsync(t => Convert.ToInt32(t.Id));
            showTicket.Id = Convert.ToString(Id + 1);
            showTicket.TicketType = Ticket_type;
            showTicket.ShowId = show_id;
            showTicket.Tourid = ID;

            _context.ShowTickets.Add(showTicket);
            if (showTicket == null
               )
            {
                result.code = 400;
                result.message = "缺少必要信息";
            }

            try
            {
                await _context.SaveChangesAsync();
                result.data = showTicket;
            }
            catch (DbUpdateException)
            {
                if (ShowTicketExists(showTicket.Id))
                {
                    result.code = 401;
                    result.message = "'填入的演出票已有";
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



        // GET: api/ShowTickets2/5
        //[Authorize(Policy = "TouristPolicy")]
        [AllowAnonymous]
        [HttpGet("getShowTData/")]
        public async Task<ActionResult<backdata>> getShowTData(
            string? Ticket_type)
        {

            backdata result = new backdata();
            var query = await (from s in _context.TicketTtyes                         
                               where ( 
                (Ticket_type == null || s.Type == Ticket_type))
                               select new
                               {
                                   s.Type,
                                   s.Price
                               }
                                    ).ToListAsync();

            result.data = query.Distinct();
            if (query == null)
            {
                result.code = 400;
                result.message = "查询结果为空";
            }

            return result;
        }
        // GET: api/ShowTickets2/5
        [AllowAnonymous]
        [HttpGet("getShowData/")]
        public async Task<ActionResult<backdata>> getShowData(
            string? show_name,
            string start_time)
        {

            backdata result = new backdata();
            DateTime date = Convert.ToDateTime(start_time);
            var query = await (from s in _context.ShowInformations
                               where (
                (show_name == null || s.ShowName == show_name)&&(date==null||date.Hour==s.StartTime.Hour))
                               select new
                               {
                                   s.ShowId,
                                   s.ShowName,
                                   s.ShowDate,
                                   s.StartTime,
                                   s.EndTime
                               }
                                    ).ToListAsync();

            result.data = query;
            if (query == null)
            {
                result.code = 400;
                result.message = "查询结果为空";
            }

            return result;
        }
       

        private bool ShowTicketExists(string id)
        {
            return _context.ShowTickets.Any(e => e.Id == id);
        }
    }
}
