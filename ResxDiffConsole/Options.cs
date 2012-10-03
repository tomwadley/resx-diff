using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CommandLine;
using CommandLine.Text;

namespace ResxDiffConsole {
    class Options {

        [ValueList(typeof(List<string>))]
        public List<string> Files { get; set; }

        // Two files

        [Option("m", "missing-keys", HelpText = "Finds keys present in the first file which are missing in the second")]
        public bool MissingKeys { get; set; }

        [Option("p", "present-keys", HelpText = "Finds keys that are present in both the first and the second file")]
        public bool PresentKeys { get; set; }

        [Option("d", "different-values", HelpText = "Finds keys present in both files whos values differ")]
        public bool DifferentValues { get; set; }

        [Option("i", "identicle-values", HelpText = "Finds keys present in both files with identicle values")]
        public bool IdenticleValues { get; set; }

        [Option("s", "mismatched-metadata", HelpText = "Finds keys present in both files which have differing metadata (type, mimetype, space or comment)")]
        public bool MismatchedMetadata { get; set; }

        // One file

        [Option("u", "duplicate-keys", HelpText = "Finds keys that appear more than once")]
        public bool DuplicateKeys { get; set; }

        [Option("e", "missing-spacepreserve", HelpText = "Finds keys that are missing the xml:space=\"preserve\" attribute")]
        public bool MissingSpacePreserve { get; set; }

        // Operations on two files

        [Option("c", "copy-missing-keys", HelpText = "Copies missing keys from the first file to the second")]
        public bool CopyMissingKeys { get; set; }

        [Option("v", "copy-different-values", HelpText = "Copies differing values from the first file to the second")]
        public bool CopyDifferentValues { get; set; }

        // Operations on any number of files

        [Option("a", "alphabetise", HelpText = "Sorts keys into alphabetical order")]
        public bool Alphabetise { get; set; }

        [Option("r", "add-missing-spacepreserve", HelpText = "Adds xml:space=\"preserve\" attributes to keys that don't have it")]
        public bool AddMissingSpacePreserve { get; set; }

        // Formating

        [Option("f", "full-data", HelpText = "Shows all fields from the data elements")]
        public bool FullData { get; set; }

        [HelpOption]
        public string GetUsage() {
            var help = new HelpText {
                Heading = new HeadingInfo("ResxDiff", "0.1"),
                Copyright = new CopyrightInfo("Tom Wadley", 2012),
                AdditionalNewLineAfterOption = true,
                AddDashesToOption = true
            };
            help.AddPreOptionsLine("Usage: ResxDiff [OPTION]... [FILE]");
            help.AddPreOptionsLine("Usage: ResxDiff [OPTION]... [FILE1] [FILE2]");
            help.AddPreOptionsLine("Usage: ResxDiff [OPTION]... [FILE]...");
            help.AddPreOptionsLine("Displays information about .resx files, shows differences between .resx files and performs operations on .resx files");
            help.AddOptions(this);
            return help;
        }
    }
}
