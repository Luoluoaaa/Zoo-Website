/*-----------------------------------------
 * 作者：杨泽华
 * 最后修改：2021.7.15
 * 功能：后台基本信息查询
 ----------------------------------------*/
using BackEnd.Data;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;

namespace BackEnd.Controllers
{
    [Route("api/homepageRequests/")]
    [ApiController]
    public class homepageRequests
    {
        private readonly ModelContext _context;
        private readonly IJwtAuthenticationHandler _jwtAuthenticationHandler;
        //构造函数注入生成token的类

        public homepageRequests(ModelContext context, IJwtAuthenticationHandler jwtAuthenticationHandler)
        {
            _context = context;
            _jwtAuthenticationHandler = jwtAuthenticationHandler;
        }

        /*--------------------------------------------
         * 函数名：getNotice
         * API：47.118.78.110:8088/api/homepageRequests/etNotice
         * 参数：null
         * 功能：获取新闻信息
         * 权限：任何人
         --------------------------------------------*/
        [AllowAnonymous]
        [HttpGet("getNotice")]
        public backdata getNotice()
        {
            backdata result = new backdata();
            var data = new List<Object>();

            data.Add(new { id = "100", level = "top", title = "园区员工课设答辩将在2021年7月16日展开", content = "课设答辩将在2021年7月16日展开" });
            data.Add(new { id = "101", level = "notice", title = "动物园即将迎来新的成员Panpan", content = "动物园即将迎来新的成员Panpan" });
            data.Add(new { id = "102", level = "activity", title = "园区员工团建活动即将展开", content = "答辩完成后拟约定日期集体干饭" });
            data.Add(new { id = "103", level = "important", title = "课设答辩安排确认已经发布", content = "不要睡过了" });
            data.Add(new { id = "104", level = "notice", title = "青年大学习优秀表彰", content = "很抱歉，表彰名单里没有您" });
            data.Add(new { id = "105", level = "notice", title = "2021届毕业生上学信网最后一次核对学籍信息和毕业照片的通知", content = "应该没有人被退学" });
            data.Add(new { id = "106", level = "notice", title = "这是一条新的通知", content = "没错只是新的通知，没别的意思" });

            result.data = data;
            return result;
        }
    }
}
