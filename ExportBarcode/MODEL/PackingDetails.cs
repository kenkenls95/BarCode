using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;
using ExportBarcode.Common;

namespace ExportBarcode.MODEL
{
    public class PackingDetails
    {
        public String packingDetailsId { get; set; }
        public String moduleNo { get; set; }
        public String importerSeriesName { get; set; }
        public String partId { get; set; }
        public String box { get; set; }
        public String packingDate { get; set; }
        public String shippingDetailsId { get; set; }
        public String partNo { get; set; }
        public String minorCode { get; set; }
        public String carFamilyId { get; set; }
        public String containerRenBan { get; set; }
        public String andOnPackingDate { get; set; }
        public String line { get; set; }
        public String qtyPerBox { get; set; }
    }
}
