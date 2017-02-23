using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WeChatAnalyse.Models
{
    public class BaseResponse
    {
        //"Ret": 0, "ErrMsg": "" 
        public int Ret { get; set; }
        public string ErrMsg { get; set; }
    }
}