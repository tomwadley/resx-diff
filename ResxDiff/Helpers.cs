using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ResxDiff {
    public static class Helpers {
        
        /// <summary>
        /// Finds keys present in 'a' that are missing in 'b'
        /// </summary>
        /// <param name="a">The base document</param>
        /// <param name="b">The document to check for missing keys</param>
        /// <returns>The keys present in 'a' that are missing in 'b'</returns>
        public static IEnumerable<string> MissingKeys(ResxDocument a, ResxDocument b) {
            var aKeys = a.Data.Select(data => data.Name);
            var bKeys = b.Data.Select(data => data.Name);
            return aKeys.Except(bKeys);
        }

        /// <summary>
        /// Finds keys that are present in both 'a' and 'b'
        /// </summary>
        /// <param name="a">The first document</param>
        /// <param name="b">The second document</param>
        /// <returns>The keys that are present in both 'a' and 'b'</returns>
        public static IEnumerable<string> PresentKeys(ResxDocument a, ResxDocument b) {
            var aKeys = a.Data.Select(data => data.Name);
            var bKeys = b.Data.Select(data => data.Name);
            return aKeys.Intersect(bKeys);
        }

        /// <summary>
        /// Finds keys present in 'a' and 'b' which have differing values
        /// </summary>
        /// <param name="a">The first document</param>
        /// <param name="b">The second document</param>
        /// <returns>The keys present in 'a' and 'b' which have differing values</returns>
        public static IEnumerable<string> DifferentValues(ResxDocument a, ResxDocument b) {
            return PresentKeys(a, b).Where(name =>
                                           a.Data.First(aData => aData.Name == name).Value !=
                                           b.Data.First(bData => bData.Name == name).Value);
        }

        /// <summary>
        /// Finds keys present in 'a' and 'b' which have the same values
        /// </summary>
        /// <param name="a">The first document</param>
        /// <param name="b">The second document</param>
        /// <returns>The keys present in 'a' and 'b' which have the same values</returns>
        public static IEnumerable<string> IdenticleValues(ResxDocument a, ResxDocument b) {
            return PresentKeys(a, b).Where(name =>
                                           a.Data.First(aData => aData.Name == name).Value ==
                                           b.Data.First(bData => bData.Name == name).Value);
        }

        /// <summary>
        /// Finds keys present in 'a' and 'b' which have differing metadata (type, mimetype, space or comment)
        /// </summary>
        /// <param name="a">The first document</param>
        /// <param name="b">The second document</param>
        /// <returns>The keys present in 'a' and 'b' which have differing metadata</returns>
        public static IEnumerable<string> MismatchedMetadata(ResxDocument a, ResxDocument b) {
            return PresentKeys(a, b).Where(name => {
                                               var aData = a.Data.First(data => data.Name == name);
                                               var bData = b.Data.First(data => data.Name == name);
                                               return (aData.Type != bData.Type) ||
                                                      (aData.Mimetype != bData.Mimetype) ||
                                                      (aData.Space != bData.Space) ||
                                                      (aData.Comment != bData.Comment);
                                           });
        }

        /// <summary>
        /// Finds keys that appear more than once in 'd'
        /// </summary>
        /// <param name="d">The document to check for duplicate keys</param>
        /// <returns>The keys that appear more than once in 'd'</returns>
        public static IEnumerable<string> DuplicateKeys(ResxDocument d) {
            return d.Data.GroupBy(data => data.Name).Where(group => group.Count() > 1).Select(group => group.Key);
        }

        // @todo Probably only text keys should have space="preserve". If that's the case, this should ignore non-text keys. Also applies to AddMissingSpacePreserve
        /// <summary>
        /// Finds keys that are missing the xml:space="preserve" attribute in 'd'
        /// </summary>
        /// <param name="d">The document to check for duplicate keys</param>
        /// <returns>The keys that appear more than once in 'd'</returns>
        public static IEnumerable<string> MissingSpacePreserve(ResxDocument d) {
            return d.Data.Where(data => data.Space != "preserve").Select(data => data.Name);
        }
    }
}
