/*-----------------------------------------
 * 作者：杨泽华
 * 最后修改：2021.7.15
 * 功能：登录和注册、查询个人信息、前台信息反馈功能
 ----------------------------------------*/
using BackEnd.Data;
using BackEnd.Model;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MimeKit;
using MimeKit.Text;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BackEnd.Controllers
{
    [Route("api/register")]
    [ApiController]
    public class register : ControllerBase
    {
        private readonly ModelContext _context;
        private readonly IJwtAuthenticationHandler _jwtAuthenticationHandler;
        //构造函数注入生成token的类

        public register(ModelContext context, IJwtAuthenticationHandler jwtAuthenticationHandler)
        {
            _context = context;
            _jwtAuthenticationHandler = jwtAuthenticationHandler;
        }

        /*--------------------------------------------
         * 函数名：information
         * API：47.118.78.110:8088/api/register/information
         * 参数：string name, string? mail, string realname, string sex, string IDcard, string Tel, string password
         * 功能：注册游客账户
         * 权限：无需权限
         --------------------------------------------*/
        [AllowAnonymous]
        [HttpGet("information")]
        public async Task<ActionResult<backdata>> information(string name, string? mail, string realname, string sex, string IDcard, string Tel, string password)
        {
            backdata result = new backdata();
            Tourist tuorist = new Tourist();
            tuorist.Id = String.Format("{0:D9}", _context.Tourists.Count());
            tuorist.NickName = name;
            if (mail != null) tuorist.Mailbox = mail;
            tuorist.RealName = realname;
            tuorist.Age = DateTime.Now.Year - ((IDcard[6] - '0') * 1000 + (IDcard[7] - '0') * 100 + (IDcard[8] - '0') * 10 + (IDcard[9] - '0'));
            tuorist.Gender = sex;
            tuorist.IDcard = IDcard;
            tuorist.PhoneNumber = Tel;
            tuorist.Password = password;
            _context.Tourists.Add(tuorist);
            await _context.SaveChangesAsync();
            result.data = tuorist;
            result.message = "1";
            return result;
        }

        /*--------------------------------------------
         * 函数名：Verification
         * API：47.118.78.110:8088/api/register/Verification
         * 参数：string Mail
         * 功能：发送邮箱验证码
         * 权限：无需权限
         --------------------------------------------*/
        [AllowAnonymous]
        [HttpGet("Verification")]
        public async Task<ActionResult<backdata>> Verification(string Mail)
        {
            backdata result = new backdata();
            if (TuoristsExists(Mail))
            {
                result.code = 400;
                result.message = "该邮箱已被注册";
                Conflict();
                return result;
            }
            byte[] b = new byte[4];
            new System.Security.Cryptography.RNGCryptoServiceProvider().GetBytes(b);
            Random r = new Random(BitConverter.ToInt32(b, 0));
            string s = null, str = "0123456789";
            for (int i = 0; i < 6; i++)
            {
                s += str.Substring(r.Next(0, str.Length - 1), 1);
            }
            await _context.SaveChangesAsync();

            MimeMessage message = new MimeMessage();
            message.From.Add(new MailboxAddress("TongjiZoo", "1914426213@qq.com"));
            message.To.Add(new MailboxAddress("registor", Mail));
            message.Subject = "TongjiZoo注册验证码";
            var multipart = new Multipart("mixed");
            var plain = new TextPart(TextFormat.Plain)
            {
                Text = "你的验证码是" + s + "，请注意查收。若非本人操作，请忽略此邮件。"
            };
            multipart.Add(plain);
            //            message.Body = new TextPart("你的验证码是" + s + "，请注意查收。若非本人操作，请忽略此邮件。");
            message.Body = multipart;
            var client = new MailKit.Net.Smtp.SmtpClient();
            client.Connect("smtp.qq.com", 465, true);
            client.Authenticate("1914426213@qq.com", "empqhpsofhltebac");
            client.Send(message);
            client.Disconnect(true);
            /*
                        MailMessage mailMessage = new MailMessage();           
                        mailMessage.From = new MailAddress("1914426213@qq.com");//发件人地址            
                        mailMessage.To.Add(new MailAddress(Mail));//收件人邮箱地址。            
                        mailMessage.Subject = "TongjiZoo注册验证码";//邮件标题。
                        string verificationcode = s;//验证码          
                        mailMessage.Body = "你的验证码是" + verificationcode + "，请注意查收。若非本人操作，请忽略此邮件。";//邮件内容。                              
                        SmtpClient client = new SmtpClient();//实例化一个SmtpClient类。      
                        client.Host = "smtp.qq.com";//在这里我使用的是qq邮箱，所以是smtp.qq.com，如果你使用的是126邮箱，那么就是smtp.126.com。           
                        client.EnableSsl = true;//使用安全加密连接。            
                        client.UseDefaultCredentials = false;//不和请求一块发送。            
                        client.Credentials = new NetworkCredential("1914426213@qq.com", "empqhpsofhltebac");//验证发件人身份(发件人的邮箱，邮箱里的生成授权码);
                        client.Send(mailMessage);//发送
            */
            result.data = s;
            return result;
        }

        /*--------------------------------------------
         * 函数名：login
         * API：47.118.78.110:8088/api/register/login
         * 参数：string id, string password
         * 功能：登录游客或员工账户
         * 权限：无需权限
         --------------------------------------------*/
        [AllowAnonymous]
        [HttpGet("login")]
        public async Task<ActionResult<backdata>> login(string id, string password)
        {
            backdata result = new backdata();
            var data = new List<Object>();

            if (EmployeeCheck(id, password))
            {
                Employee employee = await _context.Employees.FindAsync(id);
                data.Add(new
                {
                    Employee = employee,
                    token = employee.Position == "Admin" ? _jwtAuthenticationHandler.Authenticate(id, password, "Admin") : _jwtAuthenticationHandler.Authenticate(id, password, "Employee"),
                    jurisdiction = "1"
                });
                result.data = data;
                result.message = "";
            }
            else if (TuoristsCheck(id, password))
            {
                Tourist tourist = (await _context.Tourists.Where(a => a.Mailbox == id).ToListAsync()).First();
                data.Add(new
                {
                    Tourist = tourist,
                    token = _jwtAuthenticationHandler.Authenticate(id, password, "Tourist"),
                    jurisdiction = "2"
                });
                result.data = data;
                result.message = "";
            }
            else
            {
                result.code = 400;
                result.message = "账号或密码错误";
            }
            return result;
        }

        /*--------------------------------------------
         * 函数名：feedback
         * API：47.118.78.110:8088/api/register/feedback
         * 参数：string name, string Tel, string type, string dese
         * 功能：前台游客信息反馈
         * 权限：仅游客
         --------------------------------------------*/
        [Authorize(Policy = "TouristPolicy")]
        [HttpGet("feedback")]
        public async Task<ActionResult<backdata>> feedback(string name, string Tel, string type, string dese)
        {
            backdata result = new backdata();
            SystemFeedback feedback = new SystemFeedback();

            feedback.Id = String.Format("{0:D9}", _context.SystemFeedbacks.Count());
            feedback.Name = name;
            feedback.TourId = Tel;
            feedback.Type = type;
            feedback.FeedbackContent = dese;

            _context.SystemFeedbacks.Add(feedback);
            await _context.SaveChangesAsync();

            result.data = feedback;
            return result;
        }

        private bool TuoristsExists(string id)
        {
            return _context.Tourists.Any(e => e.Mailbox == id);
        }

        private bool EmployeeCheck(string id, string password)
        {
            return _context.Employees.Any(e => e.Id == id && e.Password == password);
        }

        private bool TuoristsCheck(string id, string password)
        {
            return _context.Tourists.Any(e => e.Mailbox == id && e.Password == password);
        }
    }
}
