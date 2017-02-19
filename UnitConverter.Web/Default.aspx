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
            <br />
            <br />
    
            <asp:Button ID="okButton" runat="server" OnClick="convertButton_Click" Text="Convert" CssClass="btn btn-default" />
    
            <br />
            <asp:Label ID="resultLabel" runat="server"></asp:Label>
    
    </div>
    </form>
    <script src="Scripts/bootstrap.min.js"></script>
    <script src="Scripts/jquery-3.1.1.min.js"></script>
</body>
</html>
