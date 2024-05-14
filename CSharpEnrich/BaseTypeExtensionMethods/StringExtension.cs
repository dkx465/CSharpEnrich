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
using System.Security.Cryptography;

namespace System
{
    public static class StringExtension
    {
        public static SaltType SignDefaultSaltType { get; set; } = SaltType.Both;
        public static string SignDefaultSalt { get; set; } = "dkx";
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

        /// <summary>
        /// 将字符串转换为 byte 数组，内部使用Encoding.UTF8.GetBytes，
        /// </summary>
        /// <param name="txt"></param>
        /// <returns>如果传入的参数是默认值则返回null</returns>
        public static byte[] ToBytes(this string txt)
        {
            if (IsDefault(txt)) return null;
            return Encoding.UTF8.GetBytes(txt);
        }

        /// <summary>
        /// 将字符串转换为base64编码
        /// </summary>
        /// <param name="txt"></param>
        /// <returns>如果传入的txt为默认值，则返回 string.Empty</returns>
        public static string ToBase64(this string txt)
        {
            if (IsDefault(txt)) return string.Empty;
            string base64String = Convert.ToBase64String(txt.ToBytes());
            return base64String;
        }

        /// <summary>
        /// 将字符串进行MD5加密,
        /// 配置 StringExtension.SignDefaultSaltType 属性决定加盐的方式，
        /// 配置 StringExtension.SignDefaultSalt 属性决定盐的默认值
        /// </summary>
        /// <param name="txt"></param>
        /// <param name="salt">对字符串加密时的盐值，不传则不加盐，盐值追加在字符串末尾</param>
        /// <returns>如果传入的txt为默认值，则返回 string.Empty</returns>
        public static string ToMD5(this string txt)
        {
            if (IsDefault(txt)) return string.Empty;
            using (MD5 md5 = MD5.Create())
            {
                // 对字符串进行加盐
                switch (StringExtension.SignDefaultSaltType)
                {
                    case SaltType.Append:
                        txt += StringExtension.SignDefaultSalt;
                        break;
                    case SaltType.Prepend:
                        txt = StringExtension.SignDefaultSalt + txt;
                        break;
                    case SaltType.Both:
                        txt = $"{StringExtension.SignDefaultSalt}{txt}{StringExtension.SignDefaultSalt}";
                        break;

                }
                var bytes = txt.ToBytes();
                byte[] data = md5.ComputeHash(bytes);
                StringBuilder sb = new StringBuilder();
                for (int i = 0; i < data.Length; i++)
                {
                    sb.Append(data[i].ToString("x2"));
                }
                return sb.ToString();
            }
        }
    }
}
