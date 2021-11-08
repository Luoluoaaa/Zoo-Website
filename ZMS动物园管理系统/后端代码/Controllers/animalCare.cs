using System;
using BackEnd.Data;
using BackEnd.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;

//用于后台动物医疗管理的相关功能
namespace BackEnd.Controllers
{
    [Route("api/animalCare/")]
    [ApiController]
    public class animalCare : ControllerBase
    {
        private readonly ModelContext _context;
        private readonly IJwtAuthenticationHandler _jwtAuthenticationHandler;
        //构造函数注入生成token的类

        public animalCare(ModelContext context, IJwtAuthenticationHandler jwtAuthenticationHandler)
        {
            _context = context;
            _jwtAuthenticationHandler = jwtAuthenticationHandler;
        }
        [Authorize(Policy = "EmployeePolicy")]
        [HttpGet("getCareData/")]
        public async Task<ActionResult<backdata>> getinformation(string? diseaseName, string? veterinaryId, string? drug, string? dateIll, string? dateCure, string? animalId)
        { 
            var back = await _context.CureInformations.Where(t =>
            (diseaseName == null || t.DiseaseName == diseaseName) &&
            (veterinaryId == null || t.VeterinaryId == veterinaryId) &&
            (drug == null || t.Drug == drug) &&
            (dateIll == null || t.DateIll == Convert.ToDateTime(dateIll)) &&
            (dateCure == null || t.DateCure == Convert.ToDateTime(dateCure)) &&
            (animalId == null || t.AnimalId == animalId)).ToListAsync();

            backdata result = new backdata();
            result.data = back;

            if (back == null)
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
        [HttpPost("createCareInfo/{isCured}")]
        public async Task<ActionResult<backdata>> createinformation(string diseaseName, string veterinaryId, string drug, decimal isCured, string dateIll, string dateCure, string animalId)
        {
            backdata result = new backdata();
            if (diseaseName == null || veterinaryId == null || dateIll == null || animalId == null)
            {
                result.code = 401;
                result.message = "缺少必要信息";
                return result;
            }
            if (isCured != 0 && isCured != 1 && isCured != 2)
            {
                result.code = 402;
                result.message = "当前治愈状态错误";
                return result;
            }
            else
            {
                if (dateCure != null && isCured == 2)
                {
                    result.code = 403;
                    result.message = "填入治愈时间时需要保证当前治愈状态为真";
                    return result;
                }
                if (dateCure == null && (isCured == 1 || isCured == 0))
                {
                    result.code = 404;
                    result.message = "未填入治愈时间时需要保证当前治愈状态为假";
                    return result;
                }
                if (dateCure != null && Convert.ToDateTime(dateIll) >= Convert.ToDateTime(dateCure))
                {
                    result.code = 405;
                    result.message = "日期不合法";
                    return result;
                }
                CureInformation back = new CureInformation();
                var cureId = await _context.CureInformations.MaxAsync(t => Convert.ToInt32(t.CureId));
                back.CureId = Convert.ToString(cureId + 1);
                back.DiseaseName = diseaseName;
                back.VeterinaryId = veterinaryId;
                if (drug != null) back.Drug = drug; else back.Drug = null;
                back.IsCured = isCured;
                back.DateIll = Convert.ToDateTime(dateIll);
                if (dateCure != null) back.DateCure = Convert.ToDateTime(dateCure); else back.DateCure = null;
                back.AnimalId = animalId;


                _context.CureInformations.Add(back);
                try
                {
                    await _context.SaveChangesAsync();
                    result.code = 200;
                    result.data = back;
                }

                catch (DbUpdateException)
                {
                    throw;
                }
                return result;
            }
        }
        [Authorize(Policy = "EmployeePolicy")]
        [HttpPut("modifyCareInfo/")]
        public async Task<ActionResult<backdata>> updateinformation(string cureid, string diseaseName, string veterinaryId, string drug, decimal isCured, string dateIll, string? dateCure, string animalId)
        {
            backdata result = new backdata();
            if (cureid == null)
            {
                result.code = 406;
                result.message = "缺少必要信息";
                return result;
            }
            if (isCured != 0 && isCured != 1 && isCured != 2)
            {
                result.code = 408;
                result.message = "当前治愈状态错误";
                return result;
            }
            if (dateCure != null && isCured == 2)
            {
                result.code = 409;
                result.message = "填入治愈时间时需要保证当前治愈状态为真";
                return result;
            }
            if (dateCure == null && (isCured == 1 || isCured == 0))
            {
                result.code = 410;
                result.message = "未填入治愈时间时需要保证当前治愈状态为假";
                return result;
            }
            if (dateCure != null && Convert.ToDateTime(dateIll) >= Convert.ToDateTime(dateCure))
            {
                result.code = 411;
                result.message = "日期不合法";
                return result;
            }

            CureInformation back = await _context.CureInformations.FindAsync(cureid);
            if (back == null)
            {
                result.code = 407;
                result.message = "未找到改动目标";
                return result;
            }

            back.CureId = cureid;
            back.DiseaseName = diseaseName;
            back.VeterinaryId = veterinaryId;
            if (drug != null) back.Drug = drug; else back.Drug = null;
            back.IsCured = isCured;
            back.DateIll = Convert.ToDateTime(dateIll);
            if (dateCure != null) back.DateCure = Convert.ToDateTime(dateCure); else back.DateCure = null;
            back.AnimalId = animalId;

            _context.Entry(back).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            result.code = 200;
            result.data = back;

            return result;
        }
        [Authorize(Policy = "EmployeePolicy")]
        [HttpDelete("removeCareInfo/")]
        public async Task<ActionResult<backdata>> deleteinformation(string cureid)
        {
            backdata result = new backdata();
            var back = await _context.CureInformations.FindAsync(cureid);
            if (back == null)
            {
                result.code = 412;
                result.message = "没有该ID";
                return result;
            }

            _context.CureInformations.Remove(back);
            await _context.SaveChangesAsync();
            result.code = 200;
            result.data = back;
            return result;
        }

        [Authorize(Policy = "EmployeePolicy")]
        [HttpGet("getAniStatByMonth/")]
        public async Task<ActionResult<backdata>> getAniStatByMonth()
        {
            backdata result = new backdata();
            var query = from t in _context.CureInformations
                        group t by new { t.DateIll.Year, t.DateIll.Month }
                        into monthGroup
                        select new
                        {
                            month = Convert.ToString(monthGroup.Key.Year) + "-" + Convert.ToString(monthGroup.Key.Month),
                            cnt = monthGroup.Count()
                        };                       
            var q = await query.ToListAsync();
            result.data = q;
            result.code = 200;
            result.message = "";
            return result;
        }
        [Authorize(Policy = "EmployeePolicy")]
        [HttpGet("getVetStatByMonth/")]
        public async Task<ActionResult<backdata>> getVetStatByMonth()
        {
            backdata result = new backdata();
            var query = from t in _context.CureInformations
                        group t by new { t.VeterinaryId }
                        into IdGroup
                        select new
                        {
                            id = IdGroup.Key.VeterinaryId,
                            cnt = IdGroup.Count()
                        };
            var q = await query.OrderBy(proup => proup.cnt).ToListAsync();
            result.data = q;
            result.code = 200;
            result.message = "";
            return result;
        }
        private bool CureInformationExists(string id)
        {
            return _context.CureInformations.Any(e => e.CureId == id);
        }
    }
}
