using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml.Linq;

namespace ResxDiffLib {
    public class ResxDocument {
        public IList<ResxData> Data { get; set; }

        private readonly XDocument _xml;

        public ResxDocument(XDocument xml) {
            if (xml.Root == null || xml.Root.Name != "root") {
                throw new ArgumentException("No <root> element found");
            }

            Data = xml.Root.Elements("data").Select(elem => new ResxData(elem)).ToList();

            _xml = new XDocument(xml);
        }

        public XDocument ToXml() {
            if (_xml == null) return null;

            var xml = new XDocument(_xml);
            xml.Root.Elements("data").Remove();
            xml.Root.Add(Data.Select(data => data.ToXml()).ToArray());

            return xml;
        }
    }
}
