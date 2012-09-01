using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Linq;

namespace ResxDiff {
    public class ResxDocument {
        public IList<ResxData> Data { get; set; }

        public ResxDocument() {
            Data = new List<ResxData>();
        }

        public ResxDocument(XDocument xml) {
            if (xml.Root == null || xml.Root.Name != "root") {
                throw new ArgumentException("No <root> element found");
            }

            Data = xml.Root.Elements("data").Select(elem => new ResxData(elem)).ToList();
        }
    }
}
