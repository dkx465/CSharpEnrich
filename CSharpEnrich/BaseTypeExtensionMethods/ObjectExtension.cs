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
        public static string SignKeyDefaultValue { get; set; } = "signature";
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
        /// 该方法的功能是将对象转换成JSON格式，并对该JSON数据进行签名，
        /// 配置 ObjectExtension.SignKeyDefaultValue 属性决定存放签名值的Json中的 key 值
        /// </summary>
        /// <param name="o"></param>
        /// <param name="salt">加密时要混淆的盐值</param>
        /// <returns>如果 o 是默认值则返回 default(string)</returns>
        public static string ToJsonAndSign(this object o, string salt = "")
        {
            if (IsDefault(o)) return default;
            string json = o.ToJson();
            string signature = json.ToMD5();
            JObject jsonObj = JObject.Parse(json);
            jsonObj[ObjectExtension.SignKeyDefaultValue] = signature;
            string signedJson = jsonObj.ToString();
            return signedJson;
        }

    }
}
