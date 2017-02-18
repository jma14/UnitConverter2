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
            <asp:TextBox ID="inputValueTextBox" runat="server" CssClass="form-control"></asp:TextBox>
        </div>

        <div class="radio"><label><asp:RadioButton ID="mInputRadioButton" runat="server" Checked="True" GroupName="ConvertFromRadioGroup"/>m</label></div>
        <div class="radio"><label><asp:RadioButton ID="mmInputRadioButton" runat="server" Checked="False" GroupName="ConvertFromRadioGroup"/>mm</label></div>
        <div class="radio"><label><asp:RadioButton ID="inInputRadioButton" runat="server" Checked="False" GroupName="ConvertFromRadioGroup"/>in</label></div>
        
        <br />

        <div class="form-group">
            <label>Convert To:</label>
        </div>

        <div class="radio"><label><asp:RadioButton ID="mOutputRadioButton" runat="server" Checked="True" GroupName="ConvertToRadioGroup"/>m</label></div>
        <div class="radio"><label><asp:RadioButton ID="mmOutputRadioButton" runat="server" Checked="False" GroupName="ConvertToRadioGroup"/>mm</label></div>
        <div class="radio"><label><asp:RadioButton ID="inOutputRadioButton" runat="server" Checked="False" GroupName="ConvertToRadioGroup"/>in</label></div>
    
        <asp:Button ID="okButton" runat="server" OnClick="convertButton_Click" Text="Convert" CssClass="btn btn-default" />
    
        <br />
        <asp:Label ID="resultLabel" runat="server"></asp:Label>
    
    </div>
    </form>
    <script src="Scripts/bootstrap.min.js"></script>
    <script src="Scripts/jquery-3.1.1.min.js"></script>
</body>
</html>
