using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;
using ExportBarcode.Common;

namespace ExportBarcode.MODEL
{
    public class PackingDetailsUpdate
    {
        public String moduleNo { get; set; }
        public String partNo { get; set; }
        public String boxActual { get; set; }
    }
}
