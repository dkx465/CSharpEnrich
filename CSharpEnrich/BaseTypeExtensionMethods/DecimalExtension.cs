using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace System
{
    public static class DecimalExtension
    {
        /// <summary>
        /// 将 decimal 格式的金额转换成中文大写金额
        /// </summary>
        /// <param name="amount">decimal 金额，要求 [0 - 999999999999.9999] 之间</param>
        /// <returns>中文大写金额</returns>
        /// <exception cref="Exception">超出金额要求的范围时抛出异常</exception>
        public static string ToChineseAmount(this decimal amount)
        {
            decimal max = 999999999999.9999M;
            decimal min = 0;
            if (amount <= max && amount >= min)
            {
                string[] strNum = new string[] { "零", "壹", "贰", "叁", "肆", "伍", "陆", "柒", "捌", "玖" };
                string[] strIntUnit = new string[] { "元", "拾", "佰", "仟", "万", "拾", "佰", "仟", "亿", "拾", "佰", "仟" };
                string[] strDecimalUnit = new string[] { "角", "分", "厘", "毫" };

                string strAmount = amount.ToString();
                bool hasDot = strAmount.Contains(".");

                string intStr = hasDot ? strAmount.Split('.')[0] : strAmount;
                string decimalStr = hasDot ? strAmount.Split('.')[1] : "";
                string res = "";

                string lastChineseNum = string.Empty;

                for (int i = 0; i < intStr.Length; i++)
                {
                    int intUnitIndex = intStr[i].ToString().ToInt();
                    string chineseNum = strNum[intUnitIndex];
                    string chineseUnit = strIntUnit[intStr.Length - i - 1];

                    if (chineseNum == "零")
                    {
                        chineseUnit = string.Empty;
                        if (res.Length > 0 && chineseNum == res[res.Length - 1].ToString())
                        {
                            chineseNum = string.Empty;
                        }
                    }
                    res += chineseNum + chineseUnit;
                }

                if (res != "零" && res[res.Length - 1].ToString() == "零")
                {
                    res = res.Substring(0, res.Length - 1);
                }

                if (res[res.Length - 1].ToString() != "元") res += "元";

                if (hasDot)
                {
                    for (int i = 0; i < decimalStr.Length; i++)
                    {
                        int decimalUnitIndex = decimalStr[i].ToString().ToInt();
                        string chineseNum = strNum[decimalUnitIndex];
                        string chineseUnit = strDecimalUnit[i];

                        if (chineseNum == "零")
                        {
                            chineseUnit = string.Empty;
                            if (chineseNum == res[res.Length - 1].ToString())
                            {
                                chineseNum = string.Empty;
                            }
                        }

                        res += chineseNum + chineseUnit;
                    }
                }

                return res;
            }
            throw new Exception($"只能处理 [0 - 999999999999.9999] 之间的金额转换，amount 的值 '{amount}' 超出了此范围");
        }

    }
}
