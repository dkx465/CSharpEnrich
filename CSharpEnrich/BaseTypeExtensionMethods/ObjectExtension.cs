using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
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

        /// <summary>
        /// 将 JSON 字符串转换成 T 类型的实例
        /// </summary>
        /// <typeparam name="T">对象类型</typeparam>
        /// <param name="json">json字符串</param>
        /// <returns>转换失败返回 空串，成功返回对象实体</returns>
        public static T ToObject<T>(this string json) where T : class
        {
            if (IsDefault(json))
            {
                return null;
            }
            var serializer = new JsonSerializer();
            var sr = new StringReader(json);
            var o = serializer.Deserialize(new JsonTextReader(sr), typeof(T));
            var t = o as T;
            return t;
        }

        /// <summary>
        /// 将 JSON 字符串转换成 T 类型的实体集合
        /// </summary>
        /// <typeparam name="T">对象类型</typeparam>
        /// <param name="json">json数组字符串</param>
        /// <returns>转换失败返回 空串，成功返回对象实体集合</returns>
        public static List<T> ToObjectList<T>(this string json) where T : class
        {
            if (IsDefault(json))
            {
                return null;
            }
            var serializer = new JsonSerializer();
            var sr = new StringReader(json);
            var o = serializer.Deserialize(new JsonTextReader(sr), typeof(List<T>));
            var list = o as List<T>;
            return list;
        }
    }
}
