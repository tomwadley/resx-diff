using System;
using System.Xml.Linq;

namespace ResxDiff {
    public class ResxData {
        public string Name { get; set; }
        public string Type { get; set; }
        public string Mimetype { get; set; }
        public string Space { get; set; }

        public string Value { get; set; }
        public string Comment { get; set; }

        public ResxData() {}

        public ResxData(XElement data) {
            if (data.Name != "data") {
                throw new ArgumentException("Must be a <data> element");
            }
            
            Name = XmlUtils.ValueOrNull(data.Attribute("name"));
            Type = XmlUtils.ValueOrNull(data.Attribute("type"));
            Mimetype = XmlUtils.ValueOrNull(data.Attribute("mimetype"));
            Space = XmlUtils.ValueOrNull(data.Attribute(XNamespace.Xml + "space"));

            Value = XmlUtils.ValueOrNull(data.Element("value"));
            Comment = XmlUtils.ValueOrNull(data.Element("comment"));
        }

        public XElement ToElement() {
            var data = new XElement("data");
            
            if (Name != null) data.SetAttributeValue("name", Name);
            if (Type != null) data.SetAttributeValue("type", Type);
            if (Mimetype != null) data.SetAttributeValue("mimetype", Mimetype);
            if (Space != null) data.SetAttributeValue(XNamespace.Xml + "space", Space);

            if (Value != null) data.Add(new XElement("value", Value));
            if (Comment != null) data.Add(new XElement("comment", Comment));

            return data;
        }
    }
}
