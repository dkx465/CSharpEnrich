using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using static System.DataValidator;

namespace System
{
    public static class ObjectExtension
    {
        /// <summary>
        /// 将 Object 类型的实例转换成 JSON 字符串，Object 的派生类也可以转换
        /// </summary>
        /// <param name="o"></param>
        /// <returns>转换失败返回 空串，成功返回 JSON 字符串</returns>
        public static string ToJson(this object o)
        {
            if (IsDefault(o))
            {
                return "";
            }
            return JsonConvert.SerializeObject(o);
        }
    }
}
