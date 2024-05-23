using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnitTestProject
{
    [TestClass]
    public class UnitTestDataTypeExtendsion
    {
        [TestMethod]
        public void TestToJson()
        {
            object o = null;
            Console.WriteLine(o.ToJson());
        }

        [TestMethod]
        public void TestListToJson()
        {
            var o = new { a = 1, b = 2, c = 3 };
            var list = new List<object>() { o, o, o };
            Console.WriteLine(list.ToJson());
        }

        [TestMethod]
        public void TestToJsonAndSign()
        {
            var o = new { a = 1, b = 2, c = 3 };
            Console.WriteLine(o.ToJsonAndSign("dkx"));
        }

        [TestMethod]
        public void TestDecimalToChineseAmount()
        {
            List<decimal> decimals = new List<decimal>()
            {
                100M,
                101M,
                110M,
                1100M,
                1001M,
                0.999M,
                0.0001M,
                999999999999.9999M,
                9.9999M,
                0M,
                900000009.9009M,
                900090009.9009M,
                16409.02M,
                1.9009M,
                0, 123456789, 12345.6789M, -12345.6789M, 1000000000000M
            };
            decimals.ForEach(d =>
            {
            Console.WriteLine($"{d} transform : {d.ToChineseAmount()}");
            });
        }
    }
}
