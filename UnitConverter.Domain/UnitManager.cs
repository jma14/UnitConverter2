using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnitConverter.Domain
{
    public class UnitManager
    {
        public static void CreateUnit()
        {   
            DTO.UnitDTO newUnit = new DTO.UnitDTO();
            newUnit.UnitId = Guid.NewGuid();
            newUnit.UnitName = "mm";
            newUnit.MasterUnit = "m";
            newUnit.ConversionFactor = .001;
            Persistence.UnitRepository.CreateUnit(newUnit);
        }

        public static double ConvertToMasterUnit(string inputUnit, double inputValue, out string masterUnit)
        {
            return Persistence.UnitRepository.ConvertToMasterUnit(inputUnit, inputValue, out masterUnit);
        }
    }
}
