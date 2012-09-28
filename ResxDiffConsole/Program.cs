using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Linq;
using CommandLine;
using ResxDiff;

namespace ResxDiffConsole {
    class Program {
        static void Main(string[] args) {
            var options = new Options();

            if (!CommandLineParser.Default.ParseArguments(args, options)) {
                Environment.Exit(1);
            }

            var docs = options.Files.Select(str => new ResxDocument(XDocument.Load(str))).ToList();

            if (options.MissingKeys) {
                var val = Helpers.MissingKeys(docs[0], docs[1]);
                val.ToList().ForEach(Console.Out.WriteLine);
            }

            if (options.Alphabetise) {
                Operations.Alphabetise(docs[0]);
                docs[0].ToXml().Save(args[0]);
            }

//            Operations.Alphabetise(doc1);
//            doc1.ToXml().Save(args[0]);
//
//            Operations.Alphabetise(doc2);
//            doc2.ToXml().Save(args[1]);

            

        }
    }
}
