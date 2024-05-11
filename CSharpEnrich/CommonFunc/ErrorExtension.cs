using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace CSharpEnrich.CommonFunc
{
    public class ErrorExtension
    {
        static void ThrowArgumentErr<T, T1>(T t, T1 t1)
        {
            throw new ArgumentException($"参数 '{nameof(t)}' 的值 ‘{t}’ 无法转换为 {t1.GetType()} 类型");
        }
    }
}
