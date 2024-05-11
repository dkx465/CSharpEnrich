using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using static System.DataValidator;

namespace System
{
    public static class ListExtension
    {
        /// <summary>
        /// 将List集合转换成Json字符串
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="t"></param>
        /// <returns>转换失败返回空串，成功返回JSON</returns>
        public static string ToJson<T>(this List<T> t)
        {
            if (IsDefault(t))
            {
                return "";
            }
            return JsonConvert.SerializeObject(t);
        }
    }
}
