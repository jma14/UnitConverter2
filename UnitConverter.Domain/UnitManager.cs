using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnitConverter.Domain
{
    public class UnitManager
    {
        public static void CreateUnits()
        {
            CreateUnit("mm", "m", .001);
            CreateUnit("in", "m", .0003937);
            CreateUnit("m", "m", 1);
            CreateUnit("sec", "hr", .000277777);
            CreateUnit("min", "hr", .0166666);
            CreateUnit("hr", "hr", 1);
        }

        private static void CreateUnit(string unitName, string masterUnit, double conversionFactor)
        {
            DTO.UnitDTO newUnit = new DTO.UnitDTO();
            newUnit.UnitId = Guid.NewGuid();
            newUnit.UnitName = unitName;
            newUnit.MasterUnit = masterUnit;
            newUnit.ConversionFactor = conversionFactor;
            Persistence.UnitRepository.CreateUnit(newUnit);
        }

        public static void ClearUnits()
        {
            Persistence.UnitRepository.ClearUnits();
        }

        public static double ConvertToMasterUnit(string inputUnit, double inputValue, out string masterUnit)
        {
            return Persistence.UnitRepository.ConvertToMasterUnit(inputUnit, inputValue, out masterUnit);
        }

        public static double ConvertToToUnit(string masterUnit, double convertedMasterValue, string outputUnit)
        {
            return Persistence.UnitRepository.ConvertToOutputUnit(masterUnit, convertedMasterValue, outputUnit);
        }

        public static List<string> GetUnitsForRadio()
        {
            return Persistence.UnitRepository.GetUnitsForRadio();
        }
    }
}
