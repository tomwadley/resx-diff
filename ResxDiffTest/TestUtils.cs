using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Xml.Linq;

namespace ResxDiffTest {
    public static class TestUtils {

        private static string BasePath() {
            return Path.GetDirectoryName(typeof(TestUtils).Assembly.CodeBase);
        }

        private static XDocument LoadResx(string filename) {
            var test1Path = Path.Combine(BasePath(), "resx", filename);
            return XDocument.Load(test1Path);
        }

        public static XDocument LoadTest1() {
            return LoadResx("Test1.resx");
        }

        public static XDocument LoadTest2() {
            return LoadResx("Test2.resx");
        }
        
        public static XDocument LoadTest3() {
            return LoadResx("Test3.resx");
        }

        public static XDocument LoadTest4() {
            return LoadResx("Test4.resx");
        }

        public static XDocument LoadTest5() {
            return LoadResx("Test5.resx");
        }
    }
}
