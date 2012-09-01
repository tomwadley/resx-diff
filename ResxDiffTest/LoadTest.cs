using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Xml.Linq;
using NUnit.Framework;
using ResxDiff;

namespace ResxDiffTest {

    [TestFixture]
    public class LoadTest {

        private XDocument _test1;

        [SetUp]
        public void SetUp() {
            var path = Path.Combine(Path.GetDirectoryName(GetType().Assembly.CodeBase), "resx", "Test1.resx");
            _test1 = XDocument.Load(path);
        }

        [Test]
        public void Load() {
            var test1 = new ResxDocument(_test1);

            Assert.AreEqual(3, test1.Data.Count);
            Assert.AreEqual("Test_key_1", test1.Data[0].Name);
            Assert.AreEqual(null, test1.Data[0].Type);
            Assert.AreEqual(null, test1.Data[0].Mimetype);
            Assert.AreEqual("preserve", test1.Data[0].Space);

            Assert.AreEqual("Test value 1", test1.Data[0].Value);
            Assert.AreEqual("A comment", test1.Data[0].Comment);
        }

        [Test]
        public void ToXml() {
            var data = new ResxData {
                                        Name = "A_key",
                                        Value = "A key",
                                        Space = "preserve"
                                    };
            var elem = data.ToElement();
            
            Assert.AreEqual("data", elem.Name.ToString());
            Assert.AreEqual("A_key", elem.Attribute("name").Value);
            Assert.AreEqual("preserve", elem.Attribute(XNamespace.Xml + "space").Value);
            Assert.AreEqual("A key", elem.Element("value").Value);
        }
    }
}
