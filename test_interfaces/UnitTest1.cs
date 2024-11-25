using static lab_interfaces.Program;
using System.Numerics;
namespace test_interfaces
{
    public class Tests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void Test1()
        {
            var d1 = new MyFrac(2, 5);
            var d2 = new MyFrac(3, 8);

            var res = d1.Add(d2);
            Assert.AreEqual((BigInteger)31, res.nom);
            Assert.AreEqual((BigInteger)40, res.denom);

            res = d1.Subtract(d2);
            Assert.AreEqual((BigInteger)1, res.nom);
            Assert.AreEqual((BigInteger)40, res.denom);

            res = d1.Multiply(d2);
            Assert.AreEqual((BigInteger)3, res.nom);
            Assert.AreEqual((BigInteger)20, res.denom);

            res = d1.Divide(d2);
            Assert.AreEqual((BigInteger)16, res.nom);
            Assert.AreEqual((BigInteger)15, res.denom);
        }

        [Test]
        public void Test2()
        {
            var d1 = new MyFrac(6, 1245);
            var d2 = new MyFrac(822, 5);

            var res = d1.Add(d2);
            Assert.AreEqual((BigInteger)68228, res.nom);
            Assert.AreEqual((BigInteger)415, res.denom);

            res = d1.Subtract(d2);
            Assert.AreEqual((BigInteger)68224*(-1), res.nom);
            Assert.AreEqual((BigInteger)415, res.denom);

            res = d1.Multiply(d2);
            Assert.AreEqual((BigInteger)1644, res.nom);
            Assert.AreEqual((BigInteger)2075, res.denom);

            res = d1.Divide(d2);
            Assert.AreEqual((BigInteger)1, res.nom);
            Assert.AreEqual((BigInteger)34113, res.denom);
        }

        [Test]
        public void Test3()
        {
            var d1 = new MyFrac(6152, 62132);
            var d2 = new MyFrac(1, 8);

            var res = d1.Add(d2);
            Assert.AreEqual((BigInteger)27837, res.nom);
            Assert.AreEqual((BigInteger)124264, res.denom);

            res = d1.Subtract(d2);
            Assert.AreEqual((BigInteger)3229*(-1), res.nom);
            Assert.AreEqual((BigInteger)124264, res.denom);

            res = d1.Multiply(d2);
            Assert.AreEqual((BigInteger)769, res.nom);
            Assert.AreEqual((BigInteger)62132, res.denom);

            res = d1.Divide(d2);
            Assert.AreEqual((BigInteger)12304, res.nom);
            Assert.AreEqual((BigInteger)15533, res.denom);
        }

        [Test]
        public void Test4()
        {
            var d1 = new MyFrac(-14, 3);
            var d2 = new MyFrac(-3, 10);

            var res = d1.Add(d2);
            Assert.AreEqual((BigInteger)149*(-1), res.nom);
            Assert.AreEqual((BigInteger)30, res.denom);

            res = d1.Subtract(d2);
            Assert.AreEqual((BigInteger)131*(-1), res.nom);
            Assert.AreEqual((BigInteger)30, res.denom);

            res = d1.Multiply(d2);
            Assert.AreEqual((BigInteger)7, res.nom);
            Assert.AreEqual((BigInteger)5, res.denom);

            res = d1.Divide(d2);
            Assert.AreEqual((BigInteger)140, res.nom);
            Assert.AreEqual((BigInteger)9, res.denom);
        }

        [Test]
        public void Test5()
        {
            var d1 = new MyComplex(2, 5);
            var d2 = new MyComplex(3, 8);

            var res = d1.Add(d2);
            Assert.AreEqual(5, res.real);
            Assert.AreEqual(13, res.imaginary);

            res = d1.Subtract(d2);
            Assert.AreEqual(-1, res.real);
            Assert.AreEqual(-3, res.imaginary);

            res = d1.Multiply(d2);
            Assert.AreEqual(-34, res.real);
            Assert.AreEqual(31, res.imaginary);

            res = d1.Divide(d2);
            Assert.AreEqual(46/73.0, res.real);
            Assert.AreEqual(-1/73.0, res.imaginary);
        }

        [Test]
        public void Test6()
        {
            var d1 = new MyComplex(6, 1245);
            var d2 = new MyComplex(822, 5);

            var res = d1.Add(d2);
            Assert.AreEqual(828, res.real);
            Assert.AreEqual(1250, res.imaginary);

            res = d1.Subtract(d2);
            Assert.AreEqual(-816, res.real);
            Assert.AreEqual(1240, res.imaginary);

            res = d1.Multiply(d2);
            Assert.AreEqual(-1293, res.real);
            Assert.AreEqual(1023420, res.imaginary);

            res = d1.Divide(d2);
            Assert.AreEqual(11157 / 675709.0, res.real);
            Assert.AreEqual(1023360 / 675709.0, res.imaginary);
        }

        [Test]
        public void Test7()
        {
            var d1 = new MyComplex(6152, 62132);
            var d2 = new MyComplex(1, 8);

            var res = d1.Add(d2);
            Assert.AreEqual(6153, res.real);
            Assert.AreEqual(62140, res.imaginary);

            res = d1.Subtract(d2);
            Assert.AreEqual(6151, res.real);
            Assert.AreEqual(62124, res.imaginary);

            res = d1.Multiply(d2);
            Assert.AreEqual(-490904, res.real);
            Assert.AreEqual(111348, res.imaginary);

            res = d1.Divide(d2);
            Assert.AreEqual(503208 / 65.0, res.real);
            Assert.AreEqual(12916 / 65.0, res.imaginary);
        }

        [Test]
        public void Test8()
        {
            var d1 = new MyComplex(-14, 3);
            var d2 = new MyComplex(- 3, 10);

            var res = d1.Add(d2);
            Assert.AreEqual(-17, res.real);
            Assert.AreEqual(13, res.imaginary);

            res = d1.Subtract(d2);
            Assert.AreEqual(-11, res.real);
            Assert.AreEqual(-7, res.imaginary);

            res = d1.Multiply(d2);
            Assert.AreEqual(12, res.real);
            Assert.AreEqual(-149, res.imaginary);

            res = d1.Divide(d2);
            Assert.AreEqual(72 / 109.0, res.real);
            Assert.AreEqual(131 / 109.0, res.imaginary);
        }

        [Test]
        public void Test9()
        {
            var d1 = new MyFrac(0, 3);
            var d2 = new MyFrac(0, 1);

            Assert.Throws<DivideByZeroException>(() => d1.Divide(d2));
        }
    }
}
