using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using static System.DataValidator;

namespace System
{
    public static class StringExtension
    {
        /// <summary>
        /// 将 string 尝试转换为 int 类型
        /// </summary>
        /// <returns></returns>
        public static int ToInt(this string txt)
        {
            if (int.TryParse(txt, out var val)) return val;

            throw new ArgumentException($"参数 '{nameof(txt)}' 的值 ‘{txt}’ 无法转换为 int 类型");
            
        }
    }
}
