using System;
using GeometricFigures;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace UnitTest
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            var source = new int[5, 5];
            var mp = new MyEnumerator<int>(source);

            bool result;
            for (int i = 0; i < 25; i++)
            {
                result = mp.MoveNext();
                Assert.IsTrue(result);
            }

            result = mp.MoveNext();
            Assert.IsFalse(result);

            mp.Reset();
            result = mp.MoveNext();
            Assert.IsTrue(result);

        }
    }
}
