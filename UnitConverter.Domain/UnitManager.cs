﻿using System;
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

        public static void CreateUnit(string unitName, string masterUnit, double conversionFactor)
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

        public static double ConvertToToUnit(string fromUnit, double fromValue, string toUnit)
        {
            return Persistence.UnitRepository.ConvertToToUnit(fromUnit, fromValue, toUnit);
        }

        public static List<string> GetUnitsForRadio()
        {
            return Persistence.UnitRepository.GetUnitsForRadio();
        }

        public static List<string> GetUnitsForCustomRadio()
        {
            return Persistence.UnitRepository.GetUnitsForCustomRadio();
        }
    }
}
