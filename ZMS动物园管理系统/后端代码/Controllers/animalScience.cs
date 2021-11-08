using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using BackEnd.Data;
using BackEnd.Model;

namespace BackEnd.Controllers
{
    [Route("api/")]
    [ApiController]
    public class animalScience : ControllerBase
    {
        private readonly ModelContext _context;

        public animalScience(ModelContext context)
        {
            _context = context;
        }

        // GET: api/SciencePopularizations
        [HttpGet("animalScience/")]
        public async Task<ActionResult<backdata>> getinformation(string species)
        {
            /*var back = await _context.SciencePopularizations.Where(t =>
            (species == null || t.Species == species)).ToListAsync();
            backdata result = new backdata();
            result.data = back;*/
            backdata result = new backdata();
            if (species == null)
            {
                result.code = 401;
                result.message = "缺少必要信息";
                return result;
            }
            var query = from t in _context.SciencePopularizations
                        where (t.Species == species)
                        select new
                        {
                            name = t.Name,
                            content = t.Content,
                            img = t.Img
                        };
            var q = await query.ToListAsync();
            if (q.Count == 0)
            {
                result.code = 400;
                result.message = "查询结果为空";
                return result;
            }
            result.data = q;
            result.code = 200;
            result.message = "";
            return result;
        }
        private bool SciencePopularizationExists(string id)
        {
            return _context.SciencePopularizations.Any(e => e.Name == id);
        }
    }
}


