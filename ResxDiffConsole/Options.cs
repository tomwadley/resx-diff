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

        [Option("m", "missing-keys", HelpText = "Finds keys present in the first file which are missing in the second")]
        public bool MissingKeys { get; set; }

        [Option("a", "alphabetise", HelpText = "Alphabetise")]
        public bool Alphabetise { get; set; }

        [HelpOption]
        public string GetUsage() {
            var help = new HelpText {
                Heading = new HeadingInfo("ResxDiff", "0.1"),
                Copyright = new CopyrightInfo("Tom Wadley", 2012),
                AdditionalNewLineAfterOption = true,
                AddDashesToOption = true
            };
            help.AddPreOptionsLine("Usage: ResxDiff [OPTION]... [FILE]...");
            help.AddPreOptionsLine("Lists information about a single .resx file, differences between two .resx files or performs operations on multiple .resx files");
            help.AddOptions(this);
            return help;
        }
    }
}
