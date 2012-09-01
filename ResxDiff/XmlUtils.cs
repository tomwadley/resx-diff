using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Linq;

namespace ResxDiff
{
    class XmlUtils
    {
        public static string ValueOrNull(XAttribute x) {
            return x != null ? x.Value : null;
        }

        public static string ValueOrNull(XElement x) {
            return x != null ? x.Value : null;
        }
    }
}
