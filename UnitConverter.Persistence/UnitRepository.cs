using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnitConverter.Persistence
{
    public class UnitRepository
    {
        public static void CreateUnit(DTO.UnitDTO unitDTO)
        {
            var db = new UnitConverterDbEntities();
            var newUnit = convertToEntity(unitDTO);
            if(!dbUnitExists(db, newUnit))
            {
                db.tblUnits.Add(newUnit);
                db.SaveChanges();
            }
        }

        private static tblUnit convertToEntity(DTO.UnitDTO unitDTO)
        {
            var dbUnit = new tblUnit();

            dbUnit.UnitId = unitDTO.UnitId;
            dbUnit.UnitName = unitDTO.UnitName;
            dbUnit.MasterUnit = unitDTO.MasterUnit;
            dbUnit.ConversionFactor = unitDTO.ConversionFactor;

            return dbUnit;
        }

        private static bool dbUnitExists(UnitConverterDbEntities db, tblUnit newUnit)
        {
            if(db.tblUnits.FirstOrDefault(p => p.UnitName == newUnit.UnitName) != null)
            {
                return true;
            }
            return false;
        }

        public static double ConvertToMasterUnit(string inputUnit, double inputValue, out string masterUnit)
        {
            double conversion = getMaster(inputUnit, out masterUnit);
            return conversion * inputValue;
        }

        private static double getMaster(string inputUnit, out string masterUnit)
        {
            var db = new UnitConverterDbEntities();
            var unitsList = db.tblUnits.FirstOrDefault(p => p.UnitName == inputUnit);

            if (unitsList != null)
            {
                masterUnit = unitsList.MasterUnit;
                return unitsList.ConversionFactor;
            }
            masterUnit = "a";
            return 2;
        }

        public static double ConvertToOutputUnit(string masterUnit, double convertedMasterValue, string outputUnit)
        {
            string checkMaster = "";
            double conversion = ConvertToMasterUnit(outputUnit, 1, out checkMaster);
            if(checkMaster == masterUnit) {
                return convertedMasterValue / conversion;
            }
            else
            {
                return 1;
            }

        }

    }
}
