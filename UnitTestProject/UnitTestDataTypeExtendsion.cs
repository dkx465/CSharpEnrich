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

        #region Json转实体测试
        class TestClass
        {
            public TestClass(int id, string code, string name)
            {
                this.id = id;
                this.code = code;
                this.name = name;
            }
            public int id { get; set; }
            public string code { get; set; }
            public string name { get; set; }

        }

        [TestMethod]
        public void TestJsonToObject()
        {
            string nullJson = null;

            string ObjectJson = "{\"id\":1,\"code\":2,\"name\":3}";
            string ListObjectJson = "[{\"id\":1,\"code\":2,\"name\":3},{\"id\":2,\"code\":2,\"name\":3},{\"id\":3,\"code\":2,\"name\":3}]";
            
            //空字符串测试
            Console.WriteLine("".ToObject<TestClass>().ToJson());
            Console.WriteLine("".ToObjectList<TestClass>().ToJson());
            Console.WriteLine(nullJson.ToObject<TestClass>().ToJson());
            Console.WriteLine(nullJson.ToObjectList<TestClass>().ToJson());

            //正常测试
            Console.WriteLine(ObjectJson.ToObject<TestClass>().ToJson());
            Console.WriteLine(ListObjectJson.ToObjectList<TestClass>().ToJson());

        }
        #endregion



    }
}
