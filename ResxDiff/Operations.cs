using System.Collections.Generic;
using System.Linq;

namespace ResxDiffLib {
    public static class Operations {
        
        /// <summary>
        /// Sorts keys in alphabetical order
        /// </summary>
        /// <param name="d">The document whose keys are to be sorted</param>
        public static void Alphabetise(ResxDocument d) {
            d.Data = d.Data.OrderBy(data => data.Name).ToList();
        }

        /// <summary>
        /// Copies keys from one document to another (complete Data objects)
        /// </summary>
        /// <param name="keys">The names of the keys to copy</param>
        /// <param name="from">The document to copy from</param>
        /// <param name="to">The document to copy to</param>
        public static void CopyKeys(IEnumerable<string> keys, ResxDocument from, ResxDocument to) {
            from.Data.Where(data => keys.Contains(data.Name)).ToList().ForEach(to.Data.Add);
        }

        /// <summary>
        /// Copies values from one document to another
        /// </summary>
        /// <param name="keys">The names of the keys whose values should be copied</param>
        /// <param name="from">The document to copy from</param>
        /// <param name="to">The document to copy to</param>
        public static void CopyValues(IEnumerable<string> keys, ResxDocument from, ResxDocument to) {
            to.Data.Where(data => keys.Contains(data.Name)).ToList()
                .ForEach(aData => aData.Value = from.Data.First(bData => bData.Name == aData.Name).Value);
        }

        /// <summary>
        /// Adds space="preserve" attributes to data elements which are missing it
        /// </summary>
        /// <param name="d">The document to add missing space="preserve" attributes to</param>
        public static void AddMissingSpacePreserve(ResxDocument d) {
            d.Data.Where(data => Helpers.MissingSpacePreserve(d).Contains(data.Name)).ToList().ForEach(data => data.Space = "preserve");
        }
    }
}
