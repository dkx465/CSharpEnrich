using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace System
{
    public class DataValidator
    {
        /// <summary>
        /// 传入一个值，校验其是否是当前类型的默认值
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="t"></param>
        /// <returns></returns>
        public static bool IsDefault<T>(T t)
        {
            if (EqualityComparer<T>.Default.Equals(t, default(T))) return true;
            return false;
        }
    }
}
