using System.Linq;
using NUnit.Framework;
using ResxDiffLib;

namespace ResxDiffTest {
    
    [TestFixture]
    class OperationsTest {

        private ResxDocument _test1;
        private ResxDocument _test2;
        private ResxDocument _test3;
        private ResxDocument _test4;
        private ResxDocument _test5;

        [SetUp]
        public void SetUp() {
            _test1 = new ResxDocument(TestUtils.LoadTest1());
            _test2 = new ResxDocument(TestUtils.LoadTest2());
            _test3 = new ResxDocument(TestUtils.LoadTest3());
            _test4 = new ResxDocument(TestUtils.LoadTest4());
            _test5 = new ResxDocument(TestUtils.LoadTest5());
        }

        [Test]
        public void AlphabetiseTest() {
            Assert.That(_test5.Data.Select(data => data.Name), Is.EquivalentTo(new[] { "Foo", "Bar", "Baz" }));
            Operations.Alphabetise(_test5);
            Assert.That(_test5.Data.Select(data => data.Name), Is.EquivalentTo(new[] { "Bar", "Baz", "Foo" }));
        }

        [Test]
        public void CopyKeysTest() {
            Assert.That(_test1.Data.Select(data => data.Name), Is.EquivalentTo(new[] { "Test_key_1", "Test_key_2", "Test_key_3" }));
            Operations.CopyKeys(new[] {"Test_key_4"}, _test2, _test1);
            Assert.That(_test1.Data.Select(data => data.Name), Is.EquivalentTo(new[] { "Test_key_1", "Test_key_2", "Test_key_3", "Test_key_4" }));
        }

        [Test]
        public void CopyValuesTest() {
            Assert.That(_test2.Data.Select(data => data.Value), Is.EquivalentTo(new[] { "Test value 1", "Test value 2", "Test value 3", "Test value 4" }));
            Operations.CopyValues(new[] {"Test_key_3", "Test_key_4"}, _test3, _test2);
            Assert.That(_test2.Data.Select(data => data.Value), Is.EquivalentTo(new[] { "Test value 1", "Test value 2", "Test value 3", "A different value 4" }));
        }

        [Test]
        public void AddMissingSpacePreserveTest() {
            Assert.AreEqual(1, _test3.Data.Where(data => data.Space != "preserve").Count());
            Operations.AddMissingSpacePreserve(_test3);
            Assert.AreEqual(0, _test3.Data.Where(data => data.Space != "preserve").Count());
        }
    }
}
