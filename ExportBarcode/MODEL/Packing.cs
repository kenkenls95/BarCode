using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;
using ExportBarcode.Common;

namespace ExportBarcode.MODEL
{
    public class Packing
    {
        public String packingId { get; set; }
        public String moduleNo { get; set; }
        public String importerSeriesName { get; set; }
        public String box { get; set; }
        public String packingDate { get; set; }
        public String pending { get; set; }
        public String andOnPackingDate { get; set; }
        public String line { get; set; }
    }
}
