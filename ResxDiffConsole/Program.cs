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

            if (options.MissingKeys) {
                var docs = RequireTwoFiles(options);
                var keys = Helpers.MissingKeys(docs.Item1, docs.Item2);
                var data = keys.Select(k => docs.Item1.Data.First(d => d.Name == k));
                Console.Out.Write(string.Join(Environment.NewLine, data.Select(SingleDataString)));
            }

            if (options.PresentKeys) {
                var docs = RequireTwoFiles(options);
                var keys = Helpers.PresentKeys(docs.Item1, docs.Item2);
                var leftData = keys.Select(k => docs.Item1.Data.First(d => d.Name == k));
                var rightData = keys.Select(k => docs.Item2.Data.First(d => d.Name == k));
                Console.Out.Write(string.Join(Environment.NewLine, leftData.Zip(rightData, DoubleDataString)));
            }

            if (options.DifferentValues) {
                var docs = RequireTwoFiles(options);
                var keys = Helpers.DifferentValues(docs.Item1, docs.Item2);
                var leftData = keys.Select(k => docs.Item1.Data.First(d => d.Name == k));
                var rightData = keys.Select(k => docs.Item2.Data.First(d => d.Name == k));
                Console.Out.Write(string.Join(Environment.NewLine, leftData.Zip(rightData, DoubleDataString)));
            }

            if (options.IdenticleValues) {
                var docs = RequireTwoFiles(options);
                var keys = Helpers.IdenticleValues(docs.Item1, docs.Item2);
                var data = keys.Select(k => docs.Item1.Data.First(d => d.Name == k));
                Console.Out.Write(string.Join(Environment.NewLine, data.Select(SingleDataString)));
            }

            if (options.MismatchedMetadata) {
                var docs = RequireTwoFiles(options);
                var keys = Helpers.MismatchedMetadata(docs.Item1, docs.Item2);
                var leftData = keys.Select(k => docs.Item1.Data.First(d => d.Name == k));
                var rightData = keys.Select(k => docs.Item2.Data.First(d => d.Name == k));
                Console.Out.Write(string.Join(Environment.NewLine, leftData.Zip(rightData, DoubleDataString)));
            }

            if (options.DuplicateKeys) {
                var doc = RequireOneFile(options);
                var keys = Helpers.DuplicateKeys(doc);
                var data = keys.Select(k => doc.Data.First(d => d.Name == k));
                Console.Out.Write(string.Join(Environment.NewLine, data.Select(SingleDataString)));
            }

            if (options.MissingSpacePreserve) {
                var doc = RequireOneFile(options);
                var keys = Helpers.MissingSpacePreserve(doc);
                var data = keys.Select(k => doc.Data.First(d => d.Name == k));
                Console.Out.Write(string.Join(Environment.NewLine, data.Select(SingleDataString)));
            }

            // Operations

            if (options.CopyMissingKeys) {
                var docs = RequireTwoFiles(options);
                var keys = Helpers.MissingKeys(docs.Item1, docs.Item2);
                Operations.CopyKeys(keys, docs.Item1, docs.Item2);
                // @todo indicate that the file is to be saved after any other operations are applied
            }

            if (options.Alphabetise) {
                var docs = RequireFiles(options);
                docs.ForEach(Operations.Alphabetise);
                // @todo indicate that the files are to be saved after any other operations are applied
            }

            if (options.AddMissingSpacePreserve) {
                var docs = RequireFiles(options);
                docs.ForEach(Operations.AddMissingSpacePreserve);
                // @todo indicate that the files are to be saved after any other operations are applied
            }
        }

        static ResxDocument RequireOneFile(Options options) {
            if (options.Files.Count != 1) {
                Console.Error.Write("An option you have specified requires exactly one file");
                Environment.Exit(1);
            }
            return new ResxDocument(XDocument.Load(options.Files.First()));
        }

        static Tuple<ResxDocument, ResxDocument> RequireTwoFiles(Options options) {
            if (options.Files.Count != 2) {
                Console.Error.Write("An option you have specified requires exactly two files");
                Environment.Exit(1);
            }
            return new Tuple<ResxDocument, ResxDocument>(
                new ResxDocument(XDocument.Load(options.Files[0])), 
                new ResxDocument(XDocument.Load(options.Files[1])));
            
        }

        static List<ResxDocument> RequireFiles(Options options) {
            if (!options.Files.Any()) {
                Console.Error.Write(options.GetUsage());
                Environment.Exit(1);
            }
            return options.Files.Select(str => new ResxDocument(XDocument.Load(str))).ToList();
        }

        static string SingleDataString(ResxData data) {
            var sb = new StringBuilder();
            sb.Append("key = ");
            sb.AppendLine(data.Name);
            sb.Append("val = ");
            sb.AppendLine(data.Value);
            return sb.ToString();
        }

        static string DoubleDataString(ResxData leftData, ResxData rightData) {
            var sb = new StringBuilder();
            sb.Append("key = ");
            sb.AppendLine(leftData.Name);
            sb.Append("lval = ");
            sb.AppendLine(leftData.Value);
            sb.Append("rval = ");
            sb.AppendLine(rightData.Value);
            return sb.ToString();
        }
    }
}
