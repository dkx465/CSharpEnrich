using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;

namespace UnitTestProject
{
    [TestClass]
    public class UnitTestStringExtendsion
    {
        string[] strs = new string[10]
            {
                "5", "123", "-123", "123.1", "abc", "", "  ", "2024年5月11日", "2024-5-11 13:00", "2024/5/11 24:10:00"
            };
        [TestMethod]
        public void TestToInt()
        {
            int errCount = 0;
            foreach (var item in strs)
            {
                try
                {
                    Console.WriteLine(item.ToInt());
                }
                catch (Exception ex)
                {
                    errCount++;
                    Console.WriteLine(ex.Message);
                }

            }
            Console.WriteLine($"执行{strs.Length}个用例，成功{strs.Length - errCount}个, 失败 {errCount} 个");
        }

        [TestMethod]
        public void TestToBool()
        {
            foreach (var item in strs)
            {
                Console.WriteLine($"item value: '{item}' is {item.ToBool(true)}");
            }
        }

        [TestMethod]
        public void TestToDateTime()
        {
            foreach (var item in strs)
            {
                try
                {
                    Console.WriteLine($"item value: '{item}' is {item.ToDateTime()}");
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
        }

        [TestMethod]
        public void TestToInstance()
        {
            var a = new { a = "a", b = "b" };
            List<object> list = new List<object>() { a,a,a};
            var type = a.GetType();
            string json = list.ToJson();
            var b = json.ToInstance<List<object>>();
         Console.WriteLine(b.ToJson());
        }
    }
}
