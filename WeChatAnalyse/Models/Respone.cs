using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WeChatAnalyse.Models
{
    public class Respone
    {
        public BaseResponse respoen { get; set; }
        public int MemberCount { get; set; }
        public List<Friend> MemberList { get; set; }
    }
}