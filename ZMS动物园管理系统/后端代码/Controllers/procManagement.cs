using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using BackEnd.Data;
using BackEnd.Model;
using System.Text.RegularExpressions;
using Microsoft.AspNetCore.Authorization;

//用于后台资金管理的相关功能
namespace BackEnd.Controllers
{
    [Route("api/procManagement/")]
    [ApiController]
    public class procManagement : ControllerBase
    {
        private readonly ModelContext _context;
        private readonly IJwtAuthenticationHandler _jwtAuthenticationHandler;
        //构造函数注入生成token的类

        public procManagement(ModelContext context, IJwtAuthenticationHandler jwtAuthenticationHandler)
        {
            _context = context;
            _jwtAuthenticationHandler = jwtAuthenticationHandler;
        }

        [Authorize(Policy = "EmployeePolicy")]
        [HttpGet("getProcOverview/")]
        public async Task<ActionResult<backdata>> GetProcurementGood()
        {
            backdata result = new backdata();
            var back = await (from pg in _context.ProcurementGoods
                              join
                              p in _context.Procurements
                              on pg.ProcureId equals p.ProcureId
                              select new
                              {
                                  id = p.ProcureId,
                                  name = p.Name,
                                  stat = p.Status,
                                  initiator = p.StaffId,
                                  inittime = p.ProcureDate,
                                  budget = p.Budget,
                                  remarks = p.Remarks,
                                  itemId = pg.ItemId,
                                  itemCount = pg.ItemCount
                              }).ToListAsync();

            result.data = back;
            if (back == null)
            {
                result.code = 400;
                result.message = "缺少必要信息";
            }
            else
            {
                result.code = 200;
                result.message = "";
            }
            return result;
        }
        [Authorize(Policy = "EmployeePolicy")]
        [HttpPut("changeProcStatus/")]
        public async Task<ActionResult<backdata>> PutProcurementGood(string id, string status)
        {
            backdata result = new backdata();
            if (id == null || status == null)
            {
                result.code = 403;
                result.message = "缺少必要信息";
                return result;
            }

            Procurement procurement = await _context.Procurements.FindAsync(id);
            procurement.Status = status;
            if (procurement == null)
            {
                result.code = 404;
                result.message = "未找到改动目标";
                return result;
            }
            else
            {
                _context.Entry(procurement).State = EntityState.Modified;
                await _context.SaveChangesAsync();
                result.code = 200;
                result.data = procurement;
            }
            return result;
        }
        [Authorize(Policy = "EmployeePolicy")]
        [HttpPost("createNewProc/")]
        public async Task<ActionResult<backdata>> PostProcurementGood(string name, string itemid, string qty, string status, string staffId, string procureDate, decimal budget, string remarks)
        {
            backdata result = new backdata();
            if (name == null || itemid == null || qty == null || status == null || staffId == null || procureDate == null)
            {
                result.code = 405;
                result.message = "缺少必要信息";
                return result;
            }
            if (budget <= 0)
            {
                result.code = 407;
                result.message = "预算错误";
                return result;
            }
            string[] _itemid = Regex.Split(itemid, ",", RegexOptions.IgnoreCase);
            string[] _qty = Regex.Split(qty, ",", RegexOptions.IgnoreCase);
            if (_qty.Length != _itemid.Length)
            {
                result.code = 408;
                result.message = "数量不一致";
                return result;
            }
            decimal[] __qty = new decimal[_itemid.Length];
            for (int i = 0; i < _itemid.Length; i++)
            {
                __qty[i] = Convert.ToDecimal(_qty[i]);
            }

            foreach (decimal i in __qty)
            {
                if (i <= 0)
                {
                    result.code = 406;
                    result.message = "数量错误";
                    return result;
                }
            }
            
            
            var max = await _context.Procurements.MaxAsync(t => Convert.ToInt32(t.ProcureId));
            Procurement back1 = new Procurement();
            back1.ProcureId = Convert.ToString(max + 1);
            back1.Name = name;
            back1.ProcureDate = Convert.ToDateTime(procureDate);
            back1.Status = status;
            back1.StaffId = staffId;
            back1.Budget = budget;
            back1.Remarks = remarks;
            _context.Procurements.Add(back1);

            for (int i = 0; i < _qty.Length; i++)
            {
                ProcurementGood back2 = new ProcurementGood();
                back2.ProcureId = back1.ProcureId;
                back2.ItemId = _itemid[i];
                back2.ItemCount = __qty[i];
                _context.ProcurementGoods.Add(back2);
            }
            try
            {
                await _context.SaveChangesAsync();
                result.code = 200;
                result.data = back1;
            }

            catch (DbUpdateException)
            {
                throw;
            }
            return result;
        }
        private bool ProcurementGoodExists(string id)
        {
            return _context.ProcurementGoods.Any(e => e.ProcureId == id);
        }
    }
}
