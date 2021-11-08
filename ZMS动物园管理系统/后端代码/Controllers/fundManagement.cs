/*-----------------------------------------
 * 作者：杨泽华
 * 最后修改：2021.7.15
 * 功能：后台资金管理模块
 ----------------------------------------*/
using BackEnd.Data;
using BackEnd.Model;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace BackEnd.Controllers
{
    [Route("api/fundManagement")]
    [ApiController]
    public class fundManagement : ControllerBase
    {
        private readonly ModelContext _context;
        private readonly IJwtAuthenticationHandler _jwtAuthenticationHandler;
        //构造函数注入生成token的类

        public fundManagement(ModelContext context, IJwtAuthenticationHandler jwtAuthenticationHandler)
        {
            _context = context;
            _jwtAuthenticationHandler = jwtAuthenticationHandler;
        }

        /*--------------------------------------------
         * 函数名：getAccountIncomesOverview
         * API：47.118.78.110:8088/api/fundManagement/getAccountIncomesOverview
         * 参数：string? begin_date, string? end_date
         * 功能：显示指定日期时间段内各个银行账户的收入
         * 权限：仅管理员
         --------------------------------------------*/
        [Authorize(Policy = "AdminPolicy")]
        [HttpPost("getAccountIncomesOverview")]
        public async Task<ActionResult<backdata>> getAccountIncomesOverview(string? begin_date, string? end_date)
        {
            backdata result = new backdata();
            var ans = await _context.FundAccounts.Where(a =>
                  (begin_date == null || a.TransactionTime >= Convert.ToDateTime(begin_date))
                  && (end_date == null || a.TransactionTime <= Convert.ToDateTime(end_date))
                  && a.Amount > 0
                ).GroupBy(b => b.BankAccId).Select(x => new { value = x.Sum(p => p.Amount), id = x.Key }).Join(
                _context.BankAccounts, fund => fund.id, bank => bank.BankAccId, (fund, banks) => new { name = banks.Name, value = fund.value, id = fund.id }).ToListAsync();

            result.data = ans;

            return result;
        }

        /*--------------------------------------------
         * 函数名：getAccountExpenseOverview
         * API：47.118.78.110:8088/api/fundManagement/getAccountExpenseOverview
         * 参数：string? begin_date, string? end_date, string? card_array1, string? card_array2
         * 功能：显示指定日期时间段内各个银行账户的支出
         * 权限：仅管理员
         --------------------------------------------*/
        [Authorize(Policy = "AdminPolicy")]
        [HttpPost("getAccountExpenseOverview")]
        public async Task<ActionResult<backdata>> getAccountExpenseOverview(string? begin_date, string? end_date, string? card_array1, string? card_array2)
        {
            backdata result = new backdata();
            var ans = await _context.FundAccounts.Where(a =>
                  (begin_date == null || a.TransactionTime >= Convert.ToDateTime(begin_date))
                  && (end_date == null || a.TransactionTime <= Convert.ToDateTime(end_date))
                  && (card_array1 == null || a.BankAccId == card_array1)
                  && (card_array2 == null || a.BankAccId == card_array2)
                  && a.Amount < 0
                ).GroupBy(b => b.BankAccId).Select(x => new { value = x.Sum(p => p.Amount), id = x.Key }).Join(
                _context.BankAccounts, fund => fund.id, bank => bank.BankAccId, (fund, banks) => new { name = banks.Name, value = -fund.value, id = fund.id }).ToListAsync();

            result.data = ans;

            return result;
        }

        /*--------------------------------------------
         * 函数名：getCategoryExpenseOverview
         * API：47.118.78.110:8088/api/fundManagement/getCategoryExpenseOverview
         * 参数：string? begin_date, string? end_date, string? card_array1, string? card_array2
         * 功能：指定日期时间段内各个类别的支出（不要统计收入）
         * 权限：仅管理员
         --------------------------------------------*/
        [Authorize(Policy = "AdminPolicy")]
        [HttpPost("getCategoryExpenseOverview")]
        public async Task<ActionResult<backdata>> getCategoryExpenseOverview(string? begin_date, string? end_date, string? card_array1, string? card_array2)
        {
            backdata result = new backdata();
            var ans = await _context.FundAccounts.Where(a =>
                  (begin_date == null || a.TransactionTime >= Convert.ToDateTime(begin_date))
                  && (end_date == null || a.TransactionTime <= Convert.ToDateTime(end_date))
                  && (card_array1 == null || a.BankAccId == card_array1)
                  && (card_array2 == null || a.BankAccId == card_array2) && a.Amount < 0
                ).GroupBy(b => b.Type).Select(x => new { name = x.Key, value = -x.Sum(p => p.Amount) }).ToListAsync();
            result.data = ans;

            return result;
        }

        /*--------------------------------------------
         * 函数名：getCategoryIncomesOverview
         * API：47.118.78.110:8088/api/fundManagement/getCategoryIncomesOverview
         * 参数：string? begin_date, string? end_date, string? card_array1, string? card_array2
         * 功能：指定日期时间段内各个银行账户的收入（不要统计支出）
         * 权限：仅管理员
         --------------------------------------------*/
        [Authorize(Policy = "AdminPolicy")]
        [HttpPost("getCategoryIncomesOverview")]
        public async Task<ActionResult<backdata>> getCategoryIncomesOverview(string? begin_date, string? end_date, string? card_array1, string? card_array2)
        {
            backdata result = new backdata();
            var ans = await _context.FundAccounts.Where(a =>
                  (begin_date == null || a.TransactionTime >= Convert.ToDateTime(begin_date))
                  && (end_date == null || a.TransactionTime <= Convert.ToDateTime(end_date))
                  && (card_array1 == null || a.BankAccId == card_array1)
                  && (card_array2 == null || a.BankAccId == card_array2) && a.Amount > 0
                ).GroupBy(b => b.Type).Select(x => new { value = x.Sum(p => p.Amount), name = x.Key }).ToListAsync();
            result.data = ans;

            return result;
        }

        /*--------------------------------------------
         * 函数名：getOverallBalanceShift
         * API：47.118.78.110:8088/api/fundManagement/getOverallBalanceShift
         * 参数：string? begin_date, string? end_date, string? card_array1, string? card_array2
         * 功能：显示指定日期时间段内所有银行账户的结余变化
         * 权限：仅管理员
         --------------------------------------------*/
        [Authorize(Policy = "AdminPolicy")]
        [HttpPost("getOverallBalanceShift")]
        public async Task<ActionResult<backdata>> getOverallBalanceShift(string? begin_date, string? end_date, string? card_array1, string? card_array2)
        {
            backdata result = new backdata();
            var ans = await _context.FundAccounts.Where(a =>
                   (begin_date == null || a.TransactionTime >= Convert.ToDateTime(begin_date))
                   && (end_date == null || a.TransactionTime <= Convert.ToDateTime(end_date))
                   && (card_array1 == null || a.BankAccId == card_array1)
                  && (card_array2 == null || a.BankAccId == card_array2)
                ).GroupBy(x => new DateTime(x.TransactionTime.Year, x.TransactionTime.Month, 1)).Select(
                x => new { date = x.Key.ToString("yyyy-MM"), values = x.Sum(p => p.Amount) }).ToListAsync();
            result.data = ans;
            return result;
        }

        /*--------------------------------------------
         * 函数名：getAccountBalanceShift
         * API：47.118.78.110:8088/api/fundManagement/getAccountBalanceShift
         * 参数：string? begin_date, string? end_date, string? card_array1, string? card_array2
         * 功能：显示指定日期时间段内每一个银行账户的结余变化
         * 权限：仅管理员
         --------------------------------------------*/
        [Authorize(Policy = "AdminPolicy")]
        [HttpPost("getAccountBalanceShift")]
        public async Task<ActionResult<backdata>> getAccountBalanceShift(string? begin_date, string? end_date, string? card_array1, string? card_array2)
        {
            backdata result = new backdata();
            var ans = await _context.FundAccounts.Where(a =>
                   (begin_date == null || a.TransactionTime >= Convert.ToDateTime(begin_date))
                   && (end_date == null || a.TransactionTime <= Convert.ToDateTime(end_date))
                   && (card_array1 == null || a.BankAccId == card_array1)
                   && (card_array2 == null || a.BankAccId == card_array2)
                ).Join(_context.BankAccounts, fund => fund.BankAccId, bank => bank.BankAccId, (fund, banks) => new
                {
                    name = banks.Name,
                    id = banks.BankAccId,
                    date = fund.TransactionTime,
                    values = fund.Amount,
                    type = fund.Type
                }
                ).GroupBy(x => new
                {
                    x.name,
                    x.id,
                    time = new DateTime(x.date.Year, x.date.Month, 1),
                    x.type
                }
                ).Select(x => new
                {
                    x.Key.name,
                    x.Key.id,
                    date = x.Key.time.ToString("yyyy-MM"),
                    values = x.Sum(p => p.values),
                    x.Key.type
                }
                ).ToListAsync();
            result.data = ans;
            return result;
        }

        /*--------------------------------------------
         * 函数名：getAccountList
         * API：47.118.78.110:8088/api/fundManagement/getAccountList
         * 参数：string? id, string? name, string? pr
         * 功能：按要求显示账户信息
         * 权限：仅管理员
         --------------------------------------------*/
        [Authorize(Policy = "AdminPolicy")]
        [HttpPost("getAccountList")]
        public async Task<ActionResult<backdata>> getAccountList(string? id, string? name, string? pr)
        {
            backdata result = new backdata();
            var ans = await _context.FundAccounts.Join(
                _context.BankAccounts, fund => fund.BankAccId, bank => bank.BankAccId, (fund, banks) => new
                {
                    id = fund.BankAccId,
                    name = banks.Name,
                    owner = banks.StaffId,
                    balance = fund.Amount
                }).Where((a => id == null || Regex.IsMatch(id, a.id) && (name == null || Regex.IsMatch(name, a.name)) && (pr == null || a.owner == pr))
                ).GroupBy(a => new { a.id, a.name, a.owner }
                ).Select(a => new { id = a.Key.id, name = a.Key.name, balance = a.Sum(x => x.balance), owner = a.Key.owner }).ToListAsync();

            List<string> set = new List<string>();
            foreach (var item in ans)
            {
                set.Add(item.id);
            }

            var noneAns = _context.BankAccounts.Where(e => !set.Contains(e.BankAccId)).ToListAsync().Result;
            foreach (var item in noneAns)
            {
                ans.Add(new
                {
                    id = item.BankAccId,
                    name = item.Name,
                    balance = 0,
                    owner = item.StaffId
                });
            }

            result.data = ans;
            return result;
        }

        /*--------------------------------------------
         * 函数名：addBankAccoun
         * API：47.118.78.110:8088/api/fundManagement/addBankAccoun
         * 参数：string? id, string? name, string? type, string owner
         * 功能： 创建一个银行账户，**并把创建者设为该账户的所有者,并加入管理关系中
         * 权限：仅管理员
         --------------------------------------------*/
        [Authorize(Policy = "AdminPolicy")]
        [HttpPost("addBankAccount")]
        public async Task<ActionResult<backdata>> addBankAccount(string? id, string? name, string? type, string owner)
        {
            backdata result = new backdata();
            BankAccount bac = new BankAccount();
            bac.BankAccId = id;
            bac.Name = name;
            bac.Type = type;
            bac.StaffId = owner;
            _context.BankAccounts.Add(bac);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (BankExists(bac.BankAccId))
                {
                    result.code = 400;
                    result.message = "新增账户ID重复";
                    Conflict();
                }
                else
                {
                    throw;
                }
            }
            result.data = bac;
            return result;
        }

        /*--------------------------------------------
         * 函数名：removeBankAccount
         * API：47.118.78.110:8088/api/fundManagement/removeBankAccount
         * 参数：string? id
         * 功能：删除一个银行账户，**需要操作者为账户的所有者**
         * 权限：仅管理员
         --------------------------------------------*/
        [Authorize(Policy = "AdminPolicy")]
        [HttpPost("removeBankAccount")]
        public async Task<ActionResult<backdata>> removeBankAccount(string? id)
        {
            backdata result = new backdata();
            if (id == null)
            {
                result.code = 400;
                result.message = "ID不能为空";
                return result;
            }
            var bac = await _context.BankAccounts.FindAsync(id);
            if (bac == null)
            {
                result.code = 400;
                result.message = "没有该ID";
                return result;
            }
            result.data = bac;

            _context.BankAccounts.Remove(bac);
            await _context.SaveChangesAsync();

            return result;
        }

        /*--------------------------------------------
         * 函数名：getFlowEntries
         * API：47.118.78.110:8088/api/fundManagement/getFlowEntries
         * 参数：string? id, string? name, string? trans_time_begin, string? trans_time_end, string? type, int? amount_begin, int? amount_end, string? staff_id
         * 功能：获取流水记录
         * 权限：仅管理员
         --------------------------------------------*/
        [Authorize(Policy = "AdminPolicy")]
        [HttpPost("getFlowEntries")]
        public async Task<ActionResult<backdata>> getFlowEntries(string? id, string? name, string? trans_time_begin, string? trans_time_end, string? type, int? amount_begin, int? amount_end, string? staff_id)
        {
            backdata result = new backdata();
            var ans = await _context.FundAccounts.Join(
                _context.BankAccounts, fund => fund.BankAccId, bank => bank.BankAccId, (fund, banks) => new
                {
                    fund_acc_id = fund.FundAccId,
                    name = fund.Name,
                    transaction_time = fund.TransactionTime,
                    type = fund.Type,
                    amount = fund.Amount,
                    bank_acc_id = banks.BankAccId,
                    staff_id = fund.StaffId
                }
                ).Where(a =>
                  (id == null || id == a.fund_acc_id)
                  && (name == null || name == a.name)
                  && (trans_time_begin == null || a.transaction_time >= Convert.ToDateTime(trans_time_begin))
                  && (trans_time_end == null || a.transaction_time <= Convert.ToDateTime(trans_time_end))
                  && (type == null || type == a.type)
                  && (amount_begin == null || Math.Abs(a.amount) >= amount_begin)
                  && (amount_end == null || Math.Abs(a.amount) <= amount_end)
                ).ToListAsync();

            result.data = ans;

            return result;
        }

        /*--------------------------------------------
         * 函数名：updateFlowEntry
         * API：47.118.78.110:8088/api/fundManagement/updateFlowEntry
         * 参数：string? id, string flow_id, string? name, string? trans_time, string? type, short amount, string? staff_id
         * 功能：更新流水记录
         * 权限：仅管理员
         --------------------------------------------*/
        [Authorize(Policy = "AdminPolicy")]
        [HttpPost("updateFlowEntry")]
        public async Task<ActionResult<backdata>> updateFlowEntry(string? id, string flow_id, string? name, string? trans_time, string? type, short amount, string? staff_id)
        {
            backdata result = new backdata();
            if (flow_id == null)
            {
                result.code = 400;
                result.message = "缺少必要信息";
                return result;
            }

            FundAccount tmp = await _context.FundAccounts.FindAsync(flow_id);
            if (tmp == null)
            {
                result.code = 400;
                result.message = "未找到改动目标";
                return result;
            }

            if (id != null) tmp.BankAccId = id;
            if (name != null) tmp.Name = name;
            if (trans_time != null) tmp.TransactionTime = Convert.ToDateTime(trans_time);
            if (type != null) tmp.Type = type;
            if (amount != 0) tmp.Amount = amount;
            if (staff_id != null) tmp.StaffId = staff_id;

            _context.Entry(tmp).State = EntityState.Modified;
            await _context.SaveChangesAsync();

            result.data = tmp;
            return result;
        }

        /*--------------------------------------------
         * 函数名：deleteFlowEntry
         * API：47.118.78.110:8088/api/fundManagement/deleteFlowEntry
         * 参数：string flow_id
         * 功能：删除流水记录
         * 权限：仅管理员
         --------------------------------------------*/
        [Authorize(Policy = "AdminPolicy")]
        [HttpDelete("deleteFlowEntry/{flow_id}")]
        public async Task<ActionResult<backdata>> deleteFlowEntry(string flow_id)
        {
            backdata result = new backdata();
            var fund = await _context.FundAccounts.FindAsync(flow_id);
            if (fund == null)
            {
                result.code = 400;
                result.message = "没有该ID";
                return result;
            }
            result.data = fund;

            _context.FundAccounts.Remove(fund);
            await _context.SaveChangesAsync();

            return result;
        }

        /*--------------------------------------------
         * 函数名：AddFundAccount
         * API：47.118.78.110:8088/api/fundManagement/AddFundAccount
         * 参数：FundAccount fund
         * 功能：新增流水记录
         * 权限：仅管理员
         --------------------------------------------*/
        [Authorize(Policy = "AdminPolicy")]
        [HttpPost("AddFundAccount")]
        public async Task<ActionResult<backdata>> AddFundAccount(FundAccount fund)
        {
            backdata result = new backdata();

            fund.FundAccId = String.Format("{0:D9}", _context.FundAccounts.Count());
            _context.FundAccounts.Add(fund);
            await _context.SaveChangesAsync();
            result.data = fund;

            return result;
        }

        private bool BankExists(string id)
        {
            return _context.BankAccounts.Any(e => e.BankAccId == id);
        }

    }
}
