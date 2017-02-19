using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace UnitConverter.Web
{
    public partial class Default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if(!Page.IsPostBack)
            {
                Domain.UnitManager.ClearUnits();
                refreshLists();
            }
        }

        private void getCustomRadioList()
        {
            customToRadioList.Items.Clear();
            List<string> unitsList = Domain.UnitManager.GetUnitsForCustomRadio();
            foreach (var units in unitsList)
            {
                customToRadioList.Items.Add(new ListItem { Text = units, Value = units });
            }
            if (customToRadioList != null)
            {
                customToRadioList.Items[0].Selected = true;
                customToRadioList.DataBind();
            }
        }

        private void getRadioList(RadioButtonList radioList)
        {
            radioList.Items.Clear();
            List<string> unitsList = Domain.UnitManager.GetUnitsForRadio();
            foreach (var units in unitsList)
            {
                radioList.Items.Add(new ListItem { Text = units, Value = units });
            }
            if (radioList != null)
            {
                radioList.Items[0].Selected = true;
                radioList.DataBind();
            }
        }


        protected void convertButton_Click(object sender, EventArgs e)
        {
            performConversion();
        }

        private void performConversion()
        {
            double fromValue;
            string fromUnit = getFromInfo(out fromValue);

            string toUnit = toUnitsRadioList.SelectedItem.Text;

            double convertedToValue = Domain.UnitManager.ConvertToToUnit(fromUnit, fromValue, toUnit);
            if (convertedToValue == -1)
            {
                convertedLabel.Text = "Invalid Conversion";
                return;
            }

            convertedLabel.Text = String.Format("{0:0.0000} {1}", convertedToValue, toUnit);
        }

        private string getFromInfo(out double fromValue)
        {
            if (!double.TryParse(inputValueTextBox.Text, out fromValue))
            {
                convertedLabel.Text = "Invalid input";
                return "";
            }
            else
            {
                return fromUnitsRadioList.SelectedItem.Text;
            }
            
        }

        protected void addConversionButton_Click(object sender, EventArgs e)
        {

            addCustomConversion();
        }

        private void addCustomConversion()
        {
            string customUnit = getCustomUnit();
            if (customUnit == "-1")
                return;

            double customConversionFactor = getCustomFromValue();
            if (customConversionFactor == -1)
                return;
            

            string customMasterUnit = customToRadioList.SelectedItem.Text;

            Domain.UnitManager.CreateUnit(customUnit, customMasterUnit, customConversionFactor);

            refreshLists();
            customConversionLabel.Text = String.Format("{0} - {1} - {2}", customConversionFactor, customUnit, customMasterUnit);
        }

        private string getCustomUnit()
        {
            double dummy;
            if ((customFromUnitTextBox.Text.Trim().Length == 0)
                || (double.TryParse(customFromUnitTextBox.Text.Trim(), out dummy)))
            {
                customConversionLabel.Text = "Invalid Unit";
                return "-1";
            }
            else
            {
                return customFromUnitTextBox.Text.Trim();
            }
        }

        private double getCustomFromValue()
        {
            double customFromValue;
            if (!double.TryParse(customFromFactorTextBox.Text, out customFromValue))
            {
                customConversionLabel.Text = "Invalid Entry";
                return -1;
            }
            else
            {
                return customFromValue;
            }
        }

        private void refreshLists()
        {
            Domain.UnitManager.CreateUnits();
            getRadioList(fromUnitsRadioList);
            getRadioList(toUnitsRadioList);
            getCustomRadioList();
        }
    }
}