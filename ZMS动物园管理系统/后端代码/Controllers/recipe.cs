using BackEnd.Data;
using BackEnd.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;

namespace BackEnd.Controllers
{
    [Route("api/recipe/")]
    [ApiController]
    public class recipe : ControllerBase
    {
        private readonly ModelContext _context;
        private readonly IJwtAuthenticationHandler _jwtAuthenticationHandler;
        //构造函数注入生成token的类

        public recipe(ModelContext context, IJwtAuthenticationHandler jwtAuthenticationHandler)
        {
            _context = context;
            _jwtAuthenticationHandler = jwtAuthenticationHandler;
        }

        [Authorize(Policy = "EmployeePolicy")]
        [HttpGet("getRecipe/")]
        public async Task<ActionResult<backdata>> getRecipe(string? recipe_id,string? species)
        {
            backdata result = new backdata();
            var recipe = await _context.Recipes.Where(a=>
               (recipe_id==null || a.Id==recipe_id) && (species==null || a.Species==species)).ToListAsync();
            result.data = recipe;
            if (recipe == null)
            {
                result.code = 400;
                result.message = "查询结果为空";
            }

            return result;
        }

        [Authorize(Policy = "EmployeePolicy")]
        [HttpPut("updteRecipe/")]
        public async Task<ActionResult<backdata>> updteRecipe(Recipe recipe)
        {
            backdata result = new backdata();
            if (recipe.Id == null)
            {
                result.code = 400;
                result.message = "缺少必要信息";
                return result;
            }

            Recipe tmp = await _context.Recipes.FindAsync(recipe.Id);
            if (tmp == null)
            {
                result.code = 400;
                result.message = "未找到改动目标";
                return result;
            }

            if (recipe.Species != null) tmp.Species = recipe.Species;
            if (recipe.FoodList1 != null) tmp.FoodList1 = recipe.FoodList1;
            if (recipe.FoodList2 != null) tmp.FoodList2 = recipe.FoodList2;
            if (recipe.FoodList3 != null) tmp.FoodList3 = recipe.FoodList3;
            if (recipe.FoodList4 != null) tmp.FoodList4 = recipe.FoodList4;
            if (recipe.FoodWeight1 != 0) tmp.FoodWeight1 = recipe.FoodWeight1;
            if (recipe.FoodWeight2 != 0) tmp.FoodWeight2 = recipe.FoodWeight2;
            if (recipe.FoodWeight3 != 0) tmp.FoodWeight3 = recipe.FoodWeight3;
            if (recipe.FoodWeight4 != 0) tmp.FoodWeight4 = recipe.FoodWeight4;

            _context.Entry(tmp).State = EntityState.Modified;
            await _context.SaveChangesAsync();

            return NoContent();
        }

        [Authorize(Policy = "EmployeePolicy")]
        [HttpPost("createRecipe/")]
        public async Task<ActionResult<backdata>> createRecipe(Recipe recipe)
        {
            backdata result = new backdata();
            if (recipe.Id == null || recipe.Species == null || recipe.FoodList1 == null || recipe.FoodWeight1 == 0)
            {
                result.code = 400;
                result.message = "缺少必要信息";
                return result;
            }

            _context.Recipes.Add(recipe);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (RecipeExists(recipe.Id))
                {
                    result.code = 400;
                    result.message = "新增食谱ID重复";
                    Conflict();
                }
                else
                {
                    throw;
                }
            }

            result.data = recipe;
            return result;
        }

        [Authorize(Policy = "EmployeePolicy")]
        [HttpDelete("deleteRecipe/{id}")]
        public async Task<ActionResult<backdata>> DeleteRecipe(string? id)
        {
            backdata result = new backdata();
            var recipe = await _context.Recipes.FindAsync(id);
            if (recipe == null)
            {
                result.code = 400;
                result.message = "没有该ID";
                return result;
            }
            result.data = recipe;

            _context.Recipes.Remove(recipe);
            await _context.SaveChangesAsync();

            return result;
        }

        private bool RecipeExists(string id)
        {
            return _context.Recipes.Any(e => e.Id == id);
        }
    }
}
