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

    }
}
