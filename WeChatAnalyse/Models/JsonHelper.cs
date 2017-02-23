using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Web;
using System.Runtime.Serialization.Json;
using Newtonsoft.Json;

namespace WeChatAnalyse.Models
{
    public class JsonHelper
    {
        /// <summary>
        /// 对数据进行序列化
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static string SerializeToString(object value)
        {
            return JsonConvert.SerializeObject(value);
        }
        /// <summary>
        /// 反序列化操作
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="str"></param>
        /// <returns></returns>
        public static T DeserializeToObject<T>(string str)
        {
            return JsonConvert.DeserializeObject<T>(str);
        }
    }
}