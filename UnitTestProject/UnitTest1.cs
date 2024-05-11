using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace UnitTestProject
{
    [TestClass]
    public class UnitTestStringExtendsion
    {
        [TestMethod]
        public void TestToInt()
        {
            string str = "123";
            str.ToInt();
        }
    }
}
