using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpEnrich.BaseTypeExtensionMethods
{
    internal class Utils
    {
        /// <summary>
        /// 抛出一个 数据转换 异常，对错误消息格式进行统一处理
        /// </summary>
        /// <typeparam name="T">源类型</typeparam>
        /// <typeparam name="T1">目标类型</typeparam>
        /// <param name="t">源数据值</param>
        /// <param name="t1">目标数据值示例，int 传1，string 传 ""</param>
        /// <returns></returns>
        /// <exception cref="ArgumentException"></exception>
        public static T1 ThrowConvertErr<T, T1>(T t, T1 t1)
        {
            throw new ArgumentException($"参数 '{nameof(t)}' 的值 ‘{t}’ 无法转换为 {t1.GetType()} 类型");
        }
    }
}
