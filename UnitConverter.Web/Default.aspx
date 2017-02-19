<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="UnitConverter.Web.Default" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link href="Content/bootstrap.min.css" rel="stylesheet" />
</head>
<body>
    <form id="form1" runat="server">
        <div class="container">
            <div class="row">
                <div class="col-xs-6">

                    <h3>Unit Converter</h3>

                    <div class="form-group">
                        <label>Convert:</label>
                        <asp:TextBox ID="inputValueTextBox" runat="server" CssClass="form-control" Width="100px"></asp:TextBox>
                    </div>

                    <div class="form-group">
                        <label>Convert From:</label>
                    </div>

                    <div class="radio">
                        <label><asp:RadioButtonList ID="fromUnitsRadioList" runat="server"></asp:RadioButtonList></label>
                    </div>
        
                    <br />

                    <div class="form-group">
                        <label>Convert To:</label>
                    </div>

    
                    <div class="radio">
                        <label><asp:RadioButtonList ID="toUnitsRadioList" runat="server"></asp:RadioButtonList></label>
                    </div>

                    <br />
                    <br />
    
                    <asp:Button ID="convertButton" runat="server" OnClick="convertButton_Click" Text="Convert" CssClass="btn btn-default" />
    
                    <br />
                    <br />
                    <asp:Label ID="convertedLabel" runat="server"></asp:Label>
                </div>

                <div class="col-xs-6">
                    <h3>Custom Conversion</h3>
                    <div class="form-group">
                        <label>Conversion Unit:</label>
                        <asp:TextBox ID="customFromUnitTextBox" runat="server" CssClass="form-control" Width="100px"></asp:TextBox>
                    </div>
                    <div class="form-group">
                        <label>Conversion Factor:</label>
                        <asp:TextBox ID="customFromFactorTextBox" runat="server" CssClass="form-control" Width="100px"></asp:TextBox>
                    </div>

                    <div class="form-group">
                        <label>Units:</label>
                    </div>

                    <div class="radio">
                        <label><asp:RadioButtonList ID="customToRadioList" runat="server"></asp:RadioButtonList></label>
                    </div>

                    <br />
                    <br />

                    <asp:Button ID="addConversion" runat="server" OnClick="addConversionButton_Click" Text="Add" CssClass="btn btn-default" />
                    
                    <br />
                    <br />
                    
                    <asp:Label ID="customConversionLabel" runat="server"></asp:Label>

                </div>
            </div>
        </div>
    </form>
    <script src="Scripts/bootstrap.min.js"></script>
    <script src="Scripts/jquery-3.1.1.min.js"></script>
</body>
</html>
