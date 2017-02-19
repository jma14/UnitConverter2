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
                Domain.UnitManager.CreateUnits();
                getRadioList(fromUnitsRadioList);
                getRadioList(toUnitsRadioList);
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
                radioList.Items[0].Selected = true;
            radioList.DataBind();
        }


        protected void convertButton_Click(object sender, EventArgs e)
        {
            performConversion();
        }

        private void performConversion()
        {
            double fromValue;
            string fromUnit = getFromInfo(out fromValue);

            string masterUnit;
            double convertedMasterValue = Domain.UnitManager.ConvertToMasterUnit(fromUnit, fromValue, out masterUnit);

            string toUnit = toUnitsRadioList.SelectedItem.Text;

            double convertedToValue = Domain.UnitManager.ConvertToToUnit(masterUnit, convertedMasterValue, toUnit);
            if (convertedToValue == -1)
            {
                resultLabel.Text = "Invalid Conversion";
                return;
            }

            resultLabel.Text = String.Format("{0:0.0000} {1}", convertedToValue, toUnit);
        }

        private string getFromInfo(out double fromValue)
        {
            if (!double.TryParse(inputValueTextBox.Text, out fromValue))
            {
                resultLabel.Text = "Invalid input";
                return "";
            }
            else
            {
                return fromUnitsRadioList.SelectedItem.Text;
            }
            
        }
    }
}