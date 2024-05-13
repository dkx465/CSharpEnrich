using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using static System.DataValidator;
using static System.Net.Mime.MediaTypeNames;
using static CSharpEnrich.BaseTypeExtensionMethods.Utils;
using Newtonsoft.Json;

namespace System
{
    public static class StringExtension
    {
        /// <summary>
        /// 将 string 尝试转换为 int 类型
        /// 内部调用 int.TryParse 实现
        /// </summary>
        /// <returns>正确情况返回一个 int 值，无法转换时抛出 ArgumentException 错误</returns>
        public static int ToInt(this string txt)
        {
            if (int.TryParse(txt, out var val)) return val;

            return ThrowConvertErr<string, int>(txt, val);
        }

        /// <summary>
        /// 将 string 尝试转换为 long 类型，内部调用 long.TryParse实现
        /// </summary>
        /// <param name="txt"></param>
        /// <returns></returns>
        public static long ToLong(this string txt)
        {
            if (long.TryParse(txt, out var val)) return val;

            return ThrowConvertErr<string, long>(txt, val);
        }

        /// <summary>
        /// 将 string 尝试转换为 decimal 类型，内部调用 decimal.TryParse实现
        /// </summary>
        /// <param name="txt"></param>
        /// <returns></returns>
        public static decimal ToDecimal(this string txt)
        {
            if (decimal.TryParse(txt, out var val)) return val;

            return ThrowConvertErr<string, decimal>(txt, val);
        }

        /// <summary>
        /// 将 string 尝试转换为 DateTime 类型，内部调用 DateTime.TryParse实现
        /// </summary>
        /// <param name="txt"></param>
        /// <returns></returns>
        public static DateTime ToDateTime(this string txt)
        {
            if (DateTime.TryParse(txt, out var val)) return val;
            return ThrowConvertErr<string, DateTime>(txt, val);
        }

        /// <summary>
        /// 将字符串转换为 Bool 值，当值为 null、empty、""空串 时，值为 False 反之为 True
        /// </summary>
        /// <param name="txt">要被转换的字符串</param>
        /// <param name="ignoreWhiteSpace">为 True:将空格值也视为 False，ignoreWhiteSpace 默认为 false</param>
        /// <returns></returns>
        public static bool ToBool(this string txt, bool ignoreWhiteSpace = false)
        {
            if (ignoreWhiteSpace) return !string.IsNullOrWhiteSpace(txt);
            else return !string.IsNullOrEmpty(txt);
        }

        /// <summary>
        /// 将 txt 文本序列化成 T 类型的实例，失败时将返回 T 的 default 值
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="txt"></param>
        /// <returns></returns>
        public static T ToInstance<T>(this string txt)
        {
            if (IsDefault(txt)) return default;

            T t = JsonConvert.DeserializeObject<T>(txt);

            return t;
        }
    }
}
