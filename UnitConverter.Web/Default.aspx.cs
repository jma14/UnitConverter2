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

        }

        protected void convertButton_Click(object sender, EventArgs e)
        {
            Domain.UnitManager.CreateUnits();
            double inputValue = 0;
            if(!double.TryParse(inputValueTextBox.Text, out inputValue))
            {
                resultLabel.Text = "Invalid input";
                return;
            }

            string inputUnit = getInputUnit();

            string masterUnit;
            double convertedMasterValue = Domain.UnitManager.ConvertToMasterUnit(inputUnit, inputValue, out masterUnit);

            string outputUnit = getOutputUnit();

            double convertedOutputValue = Domain.UnitManager.ConvertToOutputUnit(masterUnit, convertedMasterValue, outputUnit);
            resultLabel.Text = String.Format("{0:0.000} {1}", convertedOutputValue, outputUnit);
        }

        private string getInputUnit()
        {
            if (inInputRadioButton.Checked == true)
            {
                return "in";
            }
            else if (mmInputRadioButton.Checked == true)
            {
                return "mm";
            }
            else
            {
                return "m";
            }
        }

        private string getOutputUnit()
        {
            if (inOutputRadioButton.Checked == true)
            {
                return "in";
            }
            else if (mmOutputRadioButton.Checked == true)
            {
                return "mm";
            }
            else
            {
                return "m";
            }
        }
    }
}