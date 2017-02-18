using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnitConverter.DTO
{
    public class UnitDTO
    {
        public Guid UnitId { get; set; }
        public string UnitName { get; set; }
        public string MasterUnit { get; set; }
        public double ConversionFactor { get; set; }
    }
}
