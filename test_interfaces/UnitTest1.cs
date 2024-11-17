using static lab_interfaces.Program;

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

            var res = ((IMyNumber<MyFrac>)d1).Add(d2);
            Assert.AreEqual(31, res.nom);
            Assert.AreEqual(40, res.denom);

            res = ((IMyNumber<MyFrac>)d1).Subtract(d2);
            Assert.AreEqual(1, res.nom);
            Assert.AreEqual(40, res.denom);

            res = ((IMyNumber<MyFrac>)d1).Multiply(d2);
            Assert.AreEqual(3, res.nom);
            Assert.AreEqual(20, res.denom);

            res = ((IMyNumber<MyFrac>)d1).Divide(d2);
            Assert.AreEqual(16, res.nom);
            Assert.AreEqual(15, res.denom);
        }

        [Test]
        public void Test2()
        {
            var d1 = new MyFrac(6, 1245);
            var d2 = new MyFrac(822, 5);

            var res = ((IMyNumber<MyFrac>)d1).Add(d2);
            Assert.AreEqual(68228, res.nom);
            Assert.AreEqual(415, res.denom);

            res = ((IMyNumber<MyFrac>)d1).Subtract(d2);
            Assert.AreEqual(-68224, res.nom);
            Assert.AreEqual(415, res.denom);

            res = ((IMyNumber<MyFrac>)d1).Multiply(d2);
            Assert.AreEqual(1644, res.nom);
            Assert.AreEqual(2075, res.denom);

            res = ((IMyNumber<MyFrac>)d1).Divide(d2);
            Assert.AreEqual(1, res.nom);
            Assert.AreEqual(34113, res.denom);
        }

        [Test]
        public void Test3()
        {
            var d1 = new MyFrac(6152, 62132);
            var d2 = new MyFrac(1, 8);

            var res = ((IMyNumber<MyFrac>)d1).Add(d2);
            Assert.AreEqual(27837, res.nom);
            Assert.AreEqual(124264, res.denom);

            res = ((IMyNumber<MyFrac>)d1).Subtract(d2);
            Assert.AreEqual(-3229, res.nom);
            Assert.AreEqual(124264, res.denom);

            res = ((IMyNumber<MyFrac>)d1).Multiply(d2);
            Assert.AreEqual(769, res.nom);
            Assert.AreEqual(62132, res.denom);

            res = ((IMyNumber<MyFrac>)d1).Divide(d2);
            Assert.AreEqual(12304, res.nom);
            Assert.AreEqual(15533, res.denom);
        }

        [Test]
        public void Test4()
        {
            var d1 = new MyFrac(-14, 3);
            var d2 = new MyFrac(-3, 10);

            var res = ((IMyNumber<MyFrac>)d1).Add(d2);
            Assert.AreEqual(-149, res.nom);
            Assert.AreEqual(30, res.denom);

            res = ((IMyNumber<MyFrac>)d1).Subtract(d2);
            Assert.AreEqual(-131, res.nom);
            Assert.AreEqual(30, res.denom);

            res = ((IMyNumber<MyFrac>)d1).Multiply(d2);
            Assert.AreEqual(7, res.nom);
            Assert.AreEqual(5, res.denom);

            res = ((IMyNumber<MyFrac>)d1).Divide(d2);
            Assert.AreEqual(140, res.nom);
            Assert.AreEqual(9, res.denom);
        }
    }
}
