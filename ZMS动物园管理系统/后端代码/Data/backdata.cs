using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BackEnd.Controllers
{
    public class backdata
    {
        public backdata()
        {
            code = 200;
            data = null;
            message = "";
        }
        public int code { set; get; }
        public object data { set; get; }
        public string message { set; get; }
    }
}
