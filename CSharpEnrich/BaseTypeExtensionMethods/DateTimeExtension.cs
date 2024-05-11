using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.DataValidator;

namespace CSharpEnrich.BaseTypeExtensionMethods
{
    public static class DateTimeExtension
    {
        /// <summary>
        /// 将日期转换成时间戳，从1970-1-1 到 参数 datetime 的总秒数
        /// </summary>
        /// <param name="dateTime"></param>
        /// <returns>成功返回时间戳，失败返回0</returns>
        public static long ToTimeStamp(this DateTime dateTime)
        {
            if (IsDefault(dateTime))
            {
                return 0; 
            }
            long timestamp = ConvertToTimestamp(dateTime);
            return timestamp;
        }
        private static long ConvertToTimestamp(DateTime dateTime)
        {
            DateTime startTime = TimeZone.CurrentTimeZone.ToLocalTime(new DateTime(1970, 1, 1));
            return (long)(dateTime - startTime).TotalSeconds;
        }
    }
}
