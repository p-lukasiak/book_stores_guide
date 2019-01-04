using System;
using System.Collections.Generic;
using System.Text;

namespace TeltIt.BSG.DataModel
{
    public enum ShipmentType
    {
        NOT_AVAILABLE,
        TODAY,
        FUTURE
    }
    public class Shipment
    {
        public ShipmentType ShipmentType { get; set; }
        public int Min { get; set; }
        public int Max { get; set; }
    }
}
