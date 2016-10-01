using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace kSpot.Win.Tests
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            Mock<IAdd> mock = new Mock<IAdd>();
            mock.Setup(x => x.Sum())
                .Returns<int>(sum => sum);

            var ob = mock.Object;
            ob.A = 5;
            ob.B = 4;

            int result = ob.Sum();

            Assert.AreEqual(9, result);
        }
    }

    public interface IAdd
    {
        int A { get; set; }
        int B { get; set; }
        int Sum();
    }


    public class Additions : IAdd
    {
        public int A { get; set; }
        public int B { get; set; }

        public int Sum()
        {
            return A + B;
        }
    }
}
