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

//训练信息管理模块（后台）

//1 查询训练信息管理列表
//请求方式：GET
//功能描述：查询所有符合条件的训练信息

//2 新增训练信息
//请求方式：POST
//功能描述：插入一条训练信息

//3 修改训练信息
//请求方式：PUT
//功能描述：修改一条训练信息

//3 删除训练信息
//请求方式：DELETE
//功能描述：删除符合条件的训练信息


namespace BackEnd.Controllers
{
    [Route("api/Training/")]
    [ApiController]
    public class Training : ControllerBase
    {
        private readonly ModelContext _context;
        private readonly IJwtAuthenticationHandler _jwtAuthenticationHandler;
        //构造函数注入生成token的类

        public Training(ModelContext context, IJwtAuthenticationHandler jwtAuthenticationHandler)
        {
            _context = context;
            _jwtAuthenticationHandler = jwtAuthenticationHandler;
        }



        // GET: api/TrainInformations/5
        [Authorize(Policy = "EmployeePolicy")]
        [HttpGet("getTrainingData/")]
        public async Task<ActionResult<backdata>> GetTrainInformation(
            string? ID,
            string? animal_id,
            string? training_date,
            string? skill,
            string? trainer_id,
            string? train_site,
            string? props,
            string? remarks)
        {
            backdata result = new backdata();

            var trainAll = await _context.TrainInformations.Where(a =>
             (ID == null || a.Id == ID) && (animal_id == null || a.Id == animal_id) &&
             (training_date == null || a.TrainDate == Convert.ToDateTime(training_date))
             && (skill == null || a.Skill == skill) && (trainer_id == null || a.TrainerId == trainer_id)
             && (train_site == null || a.TrainSite == train_site) && (props == null || a.Props == props)
             && (remarks == null || a.Remarks == remarks)).ToListAsync();
            result.data = trainAll;
            if (trainAll == null)
            {
                result.code = 400;
                result.message = "查询结果为空";
            }

            return result;
        }
        // POST: api/TrainInformations

        [Authorize(Policy = "EmployeePolicy")]
        [HttpPost("createTrainingInfo/")]
        public async Task<ActionResult<backdata>> PostTrainInformation(
            string animal_id, 
            string? skill,
            string trainer_id,          
            string? train_site, 
            string? props, 
            string? remarks,
            string? training_date)
        {
            backdata result = new backdata();

            if (
                animal_id == null ||
                trainer_id == null
                )

            {
                result.code = 400;
                result.message = "缺少必要信息:需填写动物编号和训练员工编号";
                return result;
            }
            else
            {
                TrainInformation trainInformation = new TrainInformation();
                var Id = await _context.TrainInformations.MaxAsync(t => Convert.ToInt32(t.Id));
                trainInformation.Id = Convert.ToString(Id + 1);
                trainInformation.AnimalId = animal_id;
                trainInformation.Skill = skill;
                trainInformation.TrainerId = trainer_id;
                trainInformation.TrainSite = train_site;
                trainInformation.Props = props;
                trainInformation.Remarks = remarks;

                trainInformation.TrainDate = Convert.ToDateTime(training_date);

                if (skill == null) trainInformation.Skill = "暂无";
                if (train_site == null) trainInformation.TrainSite = "暂无";
                if (props == null) trainInformation.Props = "暂无";
                if (remarks == null) trainInformation.Remarks = "暂无";
                
                if (training_date == null) trainInformation.TrainDate = Convert.ToDateTime("00:00:00");


                _context.TrainInformations.Add(trainInformation);
                try
                {
                    await _context.SaveChangesAsync();
                    result.data = trainInformation;

                }
                catch (DbUpdateException)
                {

                    throw;

                }


                return result;
            }
        }


        // PUT: api/TrainInformations/5

        [Authorize(Policy = "EmployeePolicy")]
        [HttpPut("updateTrainingInfo/")]
        public async Task<ActionResult<backdata>> PutTrainInformation(
            string id,
            string? animal_id, 
            string? training_date, 
            string? skill,
            string? trainer_id, 
            string? train_site, 
            string? props, 
            string? remarks)
        {
            backdata result = new backdata();
            TrainInformation trainInformation = new TrainInformation();
            trainInformation.TrainDate = Convert.ToDateTime(training_date);
            trainInformation.Id = id;
            trainInformation.AnimalId = animal_id;
            trainInformation.Skill = skill;
            trainInformation.TrainerId = trainer_id;
            trainInformation.TrainSite = train_site;
            trainInformation.Props = props;
            trainInformation.Remarks = remarks;
            trainInformation.StartTime = Convert.ToDateTime("00:00:00");
            trainInformation.EndTime = Convert.ToDateTime("00:00:00");

            if (trainInformation.Id == null||
                trainInformation.TrainerId == null||
                trainInformation.AnimalId ==null

                )
            {
                result.code = 400;
                result.message = "缺少必要信息：需填写动物编号和训练员工编号";
            }
            TrainInformation tmp = await _context.TrainInformations.FindAsync(trainInformation.Id);

            if (tmp == null)
            {
                result.code = 402;
                result.message = "未找到改动目标";
                return result;
            }
            _context.TrainInformations.Remove(tmp);
            if (training_date == null) trainInformation.TrainDate = Convert.ToDateTime("00:00:00");
            if (skill == null) trainInformation.Skill = "暂无";
            if (train_site == null) trainInformation.TrainSite = "暂无";
            if (props == null) trainInformation.Props = "暂无";
            if (remarks == null) trainInformation.Remarks = "暂无";            

            _context.Entry(trainInformation).State = EntityState.Modified;

            _context.TrainInformations.Add(trainInformation);

                try
                {
                    await _context.SaveChangesAsync();
                    result.data = trainInformation;
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (TrainInformationExists(trainInformation.Id))
                    {
                        result.code = 401;
                        result.message = "填入的训练编号要为已有训练";
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



        // DELETE: api/TrainInformations/5
        [Authorize(Policy = "EmployeePolicy")]
        [HttpDelete("deleteTrainingInfo/")]
        public async Task<ActionResult<backdata>> DeleteTrainInformation(
            string id)
        {
            backdata result = new backdata();
            var trainInformation = await _context.TrainInformations.FindAsync(id);
            if (trainInformation == null)
            {
                result.code = 405;
                result.message = "没有该ID";
                return result;
            }
            result.data = trainInformation;
            _context.TrainInformations.Remove(trainInformation);
            await _context.SaveChangesAsync();

            return result;
        }
        
        private bool TrainInformationExists(string id)
        {
            return _context.TrainInformations.Any(e => e.Id == id);
        }
    }
}
