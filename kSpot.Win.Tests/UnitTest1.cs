using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace kSpot.Win.Tests
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            Additions ad = new Additions();
            ad.A = 5;
            ad.B = 2;

            int result = ad.Sum();

            Assert.AreEqual(7, result);
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