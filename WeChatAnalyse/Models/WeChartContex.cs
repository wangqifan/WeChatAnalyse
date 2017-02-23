using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace WeChatAnalyse.Models
{
    public class WeChartContex:DbContext
    {
        public    DbSet<Friend> Fridens { get; set; }
    }
}