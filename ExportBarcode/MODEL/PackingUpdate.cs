using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;
using ExportBarcode.Common;

namespace ExportBarcode.MODEL
{
    public class PackingUpdate
    {
        public String beginActualPacking { get; set; }
        public String endActualPacking { get; set; }
        public String moduleNo { get; set; }
        public Int32 pending { get; set; }
        public Int32 packingId { get; set; }
        public String packingDate { get; set; }
    }
}
