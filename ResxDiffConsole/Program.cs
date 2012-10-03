using System;
using System.Linq;
using System.Text;
using CommandLine;
using ResxDiff;

namespace ResxDiffConsole {
    class Program {
        static void Main(string[] args) {
            var options = new Options();

            if (!CommandLineParser.Default.ParseArguments(args, options)) {
                Environment.Exit(1);
            }

            var manager = new ResxDocumentManager(options);

            if (options.MissingKeys) {
                var docs = manager.RequireTwoFiles();
                var keys = Helpers.MissingKeys(docs.Item1, docs.Item2);
                var data = keys.Select(k => docs.Item1.Data.First(d => d.Name == k));
                Console.Out.Write(string.Join(Environment.NewLine, data.Select(SingleDataString)));
            }

            if (options.PresentKeys) {
                var docs = manager.RequireTwoFiles();
                var keys = Helpers.PresentKeys(docs.Item1, docs.Item2);
                var leftData = keys.Select(k => docs.Item1.Data.First(d => d.Name == k));
                var rightData = keys.Select(k => docs.Item2.Data.First(d => d.Name == k));
                Console.Out.Write(string.Join(Environment.NewLine, leftData.Zip(rightData, DoubleDataString)));
            }

            if (options.DifferentValues) {
                var docs = manager.RequireTwoFiles();
                var keys = Helpers.DifferentValues(docs.Item1, docs.Item2);
                var leftData = keys.Select(k => docs.Item1.Data.First(d => d.Name == k));
                var rightData = keys.Select(k => docs.Item2.Data.First(d => d.Name == k));
                Console.Out.Write(string.Join(Environment.NewLine, leftData.Zip(rightData, DoubleDataString)));
            }

            if (options.IdenticleValues) {
                var docs = manager.RequireTwoFiles();
                var keys = Helpers.IdenticleValues(docs.Item1, docs.Item2);
                var data = keys.Select(k => docs.Item1.Data.First(d => d.Name == k));
                Console.Out.Write(string.Join(Environment.NewLine, data.Select(SingleDataString)));
            }

            if (options.MismatchedMetadata) {
                var docs = manager.RequireTwoFiles();
                var keys = Helpers.MismatchedMetadata(docs.Item1, docs.Item2);
                var leftData = keys.Select(k => docs.Item1.Data.First(d => d.Name == k));
                var rightData = keys.Select(k => docs.Item2.Data.First(d => d.Name == k));
                Console.Out.Write(string.Join(Environment.NewLine, leftData.Zip(rightData, DoubleDataString)));
            }

            if (options.DuplicateKeys) {
                var doc = manager.RequireOneFile();
                var keys = Helpers.DuplicateKeys(doc);
                var data = keys.Select(k => doc.Data.First(d => d.Name == k));
                Console.Out.Write(string.Join(Environment.NewLine, data.Select(SingleDataString)));
            }

            if (options.MissingSpacePreserve) {
                var doc = manager.RequireOneFile();
                var keys = Helpers.MissingSpacePreserve(doc);
                var data = keys.Select(k => doc.Data.First(d => d.Name == k));
                Console.Out.Write(string.Join(Environment.NewLine, data.Select(SingleDataString)));
            }

            // Operations

            if (options.CopyMissingKeys) {
                var docs = manager.RequireTwoFiles();
                var keys = Helpers.MissingKeys(docs.Item1, docs.Item2);
                Operations.CopyKeys(keys, docs.Item1, docs.Item2);
                manager.MarkForSaving(docs.Item2);
            }

            if (options.CopyDifferentValues) {
                var docs = manager.RequireTwoFiles();
                var keys = Helpers.DifferentValues(docs.Item1, docs.Item2);
                Operations.CopyValues(keys, docs.Item1, docs.Item2);
                manager.MarkForSaving(docs.Item2);
            }

            if (options.Alphabetise) {
                var docs = manager.RequireFiles();
                docs.ToList().ForEach(Operations.Alphabetise);
                manager.MarkForSaving(docs);
            }

            if (options.AddMissingSpacePreserve) {
                var docs = manager.RequireFiles();
                docs.ToList().ForEach(Operations.AddMissingSpacePreserve);
                manager.MarkForSaving(docs);
            }

            manager.SaveMarkedDocuments();
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
