using System.Xml.Linq;

namespace ResxDiffLib {
    public static class XmlUtils {
        public static string ValueOrNull(XAttribute x) {
            return x != null ? x.Value : null;
        }

        public static string ValueOrNull(XElement x) {
            return x != null ? x.Value : null;
        }
    }
}