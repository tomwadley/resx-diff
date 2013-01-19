using System.Text;
using ResxDiffLib;

namespace ResxDiffConsole {
    class ResxDataPrinter {

        private bool FullData { get; set; }

        public ResxDataPrinter(bool fullData) {
            FullData = fullData;
        }

        public string SingleDataString(ResxData data) {
            var sb = new StringBuilder();
            sb.Append("key = ");
            sb.AppendLine(data.Name);
            sb.Append("val = ");
            sb.AppendLine(data.Value);
            if (FullData) {
                sb.Append("com = ");
                sb.AppendLine(data.Comment);
                sb.Append("typ = ");
                sb.AppendLine(data.Type);
                sb.Append("spc = ");
                sb.AppendLine(data.Space);
            }
            return sb.ToString();
        }

        public string DoubleDataString(ResxData leftData, ResxData rightData) {
            var sb = new StringBuilder();
            sb.Append("keys = ");
            sb.AppendLine(leftData.Name);
            sb.Append("lval = ");
            sb.AppendLine(leftData.Value);
            sb.Append("rval = ");
            sb.AppendLine(rightData.Value);
            if (FullData) {
                sb.Append("lcom = ");
                sb.AppendLine(leftData.Comment);
                sb.Append("rcom = ");
                sb.AppendLine(rightData.Comment);
                sb.Append("ltyp = ");
                sb.AppendLine(leftData.Type);
                sb.Append("rtyp = ");
                sb.AppendLine(rightData.Type);
                sb.Append("lspc = ");
                sb.AppendLine(leftData.Space);
                sb.Append("rspc = ");
                sb.AppendLine(rightData.Space);
            }
            return sb.ToString();
        }
    }
}
