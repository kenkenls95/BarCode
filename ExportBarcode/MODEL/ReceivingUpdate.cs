using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;

namespace ExportBarcode.MODEL
{
    public class ReceivingUpdate
    {
        public String seq { get; set; }
        public String palletNo { get; set; }
        public String listPart { get; set; }
        public String packingMonth { get; set; }
        public String packingDate { get; set; }
        public String receivingDate { get; set; }
        public String palletQty { get; set; }
        public String maxPalletQty { get; set; }
        public String supplierCode { get; set; }
        public String check { get; set; }
    }
}
