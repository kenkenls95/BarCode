using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;
using ExportBarcode.Common;

namespace ExportBarcode.MODEL
{
    public class PartDetail
    {
        public String moduleNo { get; set; }
        public String partId { get; set; }
        public String partNo { get; set; }
        public String box { get; set; }
        public String qtyPerBox { get; set; }
        public Int32 actual { get; set; }
        public Int32 actualTmv { get; set; }
    }
}
