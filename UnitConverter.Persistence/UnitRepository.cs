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

        public static void ClearUnits()
        {
            var db = new UnitConverterDbEntities();
            foreach (var tblItem in db.tblUnits)
            {
                db.tblUnits.Remove(tblItem);
            }
            db.SaveChanges();
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

        public static double ConvertToMasterUnit(string inputUnit, double fromValue, out string masterUnit)
        {
            double conversion = getMaster(inputUnit, out masterUnit);
            return conversion * fromValue;
        }

        private static double getMaster(string fromUnit, out string masterUnit)
        {
            var db = new UnitConverterDbEntities();
            var unitsList = db.tblUnits.FirstOrDefault(p => p.UnitName == fromUnit);

            if (unitsList != null)
            {
                masterUnit = unitsList.MasterUnit;
                return unitsList.ConversionFactor;
            }
            masterUnit = "a";
            return 2;
        }

        public static double ConvertToToUnit(string fromUnit, double fromValue, string toUnit)
        {
            string masterFromUnit;
            double convertFrom = ConvertToMasterUnit(fromUnit, fromValue, out masterFromUnit);

            string masterToUnit;
            double convertTo = ConvertToMasterUnit(toUnit, 1, out masterToUnit);

            if(masterFromUnit == masterToUnit) {
                return convertFrom / convertTo;
            }
            else
            {
                return -1;
            }

        }

        public static List<string> GetUnitsForRadio()
        {
            var db = new UnitConverterDbEntities();
            var unitsList = db.tblUnits.OrderBy(p => p.MasterUnit).Select(p => p.UnitName).ToList();
            return unitsList;
        }

        public static List<string> GetUnitsForCustomRadio()
        {
            var db = new UnitConverterDbEntities();
            var unitList = new List<string>();
            foreach (var item in db.tblUnits)
            {
                if (!unitList.Contains(item.MasterUnit))
                    unitList.Add(item.MasterUnit);
            }
            return unitList;
        }

    }
}
