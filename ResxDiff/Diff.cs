using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ResxDiff {
    public static class Diff {
        
        /// <summary>
        /// Finds data name keys present in 'a' that are missing in 'b'
        /// </summary>
        /// <param name="a">The base document</param>
        /// <param name="b">The document to look for missing keys</param>
        /// <returns>The list of ResxData objects present in 'a' that don't have corresponding ResxData objects in 'b'</returns>
        public static IEnumerable<string> MissingKeys(ResxDocument a, ResxDocument b) {
            var aKeys = a.Data.Select(data => data.Name);
            var bKeys = b.Data.Select(data => data.Name);
            return aKeys.Except(bKeys);
        }

        public static IEnumerable<string> PresentKeys(ResxDocument a, ResxDocument b) {
            var aKeys = a.Data.Select(data => data.Name);
            var bKeys = b.Data.Select(data => data.Name);
            return aKeys.Intersect(bKeys);
        }

        public static IEnumerable<string> DifferentValues(ResxDocument a, ResxDocument b) {
            return PresentKeys(a, b).Where(name =>
                                           a.Data.First(aData => aData.Name == name).Value !=
                                           b.Data.First(bData => bData.Name == name).Value);
        }

        public static IEnumerable<string> IdenticleValues(ResxDocument a, ResxDocument b) {
            return PresentKeys(a, b).Where(name =>
                                           a.Data.First(aData => aData.Name == name).Value ==
                                           b.Data.First(bData => bData.Name == name).Value);
        }
    }
}
