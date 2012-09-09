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

        [Test]
        public void Load() {
            var test1 = new ResxDocument(TestUtils.LoadTest1());

            Assert.AreEqual(3, test1.Data.Count);
            Assert.AreEqual("Test_key_1", test1.Data[0].Name);
            Assert.AreEqual(null, test1.Data[0].Type);
            Assert.AreEqual(null, test1.Data[0].Mimetype);
            Assert.AreEqual("preserve", test1.Data[0].Space);

            Assert.AreEqual("Test value 1", test1.Data[0].Value);
            Assert.AreEqual("A comment", test1.Data[0].Comment);
        }

        [Test]
        public void ResxDataToXml() {
            var data = new ResxData {
                                        Name = "A_key",
                                        Value = "A key",
                                        Space = "preserve"
                                    };
            var elem = data.ToXml();
            
            Assert.AreEqual("data", elem.Name.ToString());
            Assert.AreEqual("A_key", elem.Attribute("name").Value);
            Assert.AreEqual("preserve", elem.Attribute(XNamespace.Xml + "space").Value);
            Assert.AreEqual("A key", elem.Element("value").Value);
        }

        [Test]
        public void ResxDocumentToXml() {
            var test1 = new ResxDocument(TestUtils.LoadTest1());
            Assert.AreEqual(TestUtils.LoadTest1().ToString(), test1.ToXml().ToString());
        }

        [Test]
        public void ResxDocumentToXmlWithChanges() {
            var test1 = new ResxDocument(TestUtils.LoadTest1());
            test1.Data.Add(new ResxData {
                                            Name = "Test_key_4",
                                            Value = "Test value 4",
                                            Space = "preserve"
                                        });
            Assert.AreEqual(TestUtils.LoadTest2().ToString(), test1.ToXml().ToString());
        }
    }
}
