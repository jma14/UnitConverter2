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

        protected void okButton_Click(object sender, EventArgs e)
        {
            Domain.UnitManager.CreateUnit();
            double inputValue = 0;
            if(!double.TryParse(inputValueTextBox.Text, out inputValue))
            {
                resultLabel.Text = "Invalid input";
                return;
            }

            string masterUnit;
            double convertedValue = Domain.UnitManager.ConvertToMasterUnit("mm", inputValue, out masterUnit);
            resultLabel.Text = String.Format("{0:2} {1}", convertedValue, masterUnit);
        }
    }
}