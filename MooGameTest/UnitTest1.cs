using Microsoft.VisualStudio.TestTools.UnitTesting;
using MooGame;

namespace MooGameTest
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            var res =GoalManager.checkBC("1234", "1234");
            Assert.AreEqual(res, "BBBB,",true);
        }
        [TestMethod]
        public void TestMethod2()
        {
            var res = GoalManager.checkBC("1934", "1234");
            Assert.AreNotEqual(res, "BBBB,", true);
        }
        [TestMethod]
        public void TestMethod3()
        {
            var res = GoalManager.checkBC("1934", "1234");
            Assert.AreEqual(res, "BBB,C", true);
        }

        [TestMethod]
        public void MyTest()
        {
            var res = GoalManager.checkBC("1987", "2345");
            Assert.AreEqual(res, ",", true);
        }


    }


}