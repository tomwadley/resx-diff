using NUnit.Framework;
using ResxDiffLib;

namespace ResxDiffTest {

    [TestFixture]
    class HelpersTest {
        private ResxDocument _test1;
        private ResxDocument _test2;
        private ResxDocument _test3;
        private ResxDocument _test4;

        [SetUp]
        public void SetUp() {
            _test1 = new ResxDocument(TestUtils.LoadTest1());
            _test2 = new ResxDocument(TestUtils.LoadTest2());
            _test3 = new ResxDocument(TestUtils.LoadTest3());
            _test4 = new ResxDocument(TestUtils.LoadTest4());
        }

        [Test]
        public void MissingKeysTest() {
            Assert.That(Helpers.MissingKeys(_test1, _test2), Is.EquivalentTo(new string[] { }));
            Assert.That(Helpers.MissingKeys(_test2, _test1), Is.EquivalentTo(new[] { "Test_key_4" }));
        }

        [Test]
        public void PresentKeysTest() {
            Assert.That(Helpers.PresentKeys(_test1, _test2), Is.EquivalentTo(new[] { "Test_key_1", "Test_key_2", "Test_key_3" }));
            Assert.That(Helpers.PresentKeys(_test2, _test1), Is.EquivalentTo(new[] { "Test_key_1", "Test_key_2", "Test_key_3" }));
        }

        [Test]
        public void DifferentValuesTest() {
            Assert.That(Helpers.DifferentValues(_test1, _test2), Is.EquivalentTo(new string[] { }));
            Assert.That(Helpers.DifferentValues(_test1, _test3), Is.EquivalentTo(new[] { "Test_key_2" }));
            Assert.That(Helpers.DifferentValues(_test2, _test3), Is.EquivalentTo(new[] { "Test_key_2", "Test_key_4" }));
        }

        [Test]
        public void IdenticalValuesTest() {
            Assert.That(Helpers.IdenticalValues(_test1, _test2), Is.EquivalentTo(new[] { "Test_key_1", "Test_key_2", "Test_key_3" }));
            Assert.That(Helpers.IdenticalValues(_test1, _test3), Is.EquivalentTo(new[] { "Test_key_1", "Test_key_3" }));
            Assert.That(Helpers.IdenticalValues(_test2, _test3), Is.EquivalentTo(new[] { "Test_key_1", "Test_key_3" }));
        }

        [Test]
        public void MismatchedMetadataTest() {
            Assert.That(Helpers.MismatchedMetadata(_test1, _test2), Is.EquivalentTo(new string[] { }));
            Assert.That(Helpers.MismatchedMetadata(_test1, _test3), Is.EquivalentTo(new[] { "Test_key_1", "Test_key_3" }));
        }

        [Test]
        public void DuplicateKeysTest() {
            Assert.That(Helpers.DuplicateKeys(_test1), Is.EquivalentTo(new string[] { }));
            Assert.That(Helpers.DuplicateKeys(_test4), Is.EquivalentTo(new[] { "Test_key_2" }));
        }

        [Test]
        public void MissingSpacePreserveTest() {
            Assert.That(Helpers.MissingSpacePreserve(_test1), Is.EquivalentTo(new string[] { }));
            Assert.That(Helpers.MissingSpacePreserve(_test3), Is.EquivalentTo(new[] { "Test_key_3" }));
        }
    }
}
