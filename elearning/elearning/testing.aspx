<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="testing.aspx.cs" Inherits="testing" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html >
<head>
    <title>Untitled Page</title>
</head>
<body>
    <div>
        &nbsp;
        <asp:Label ID="Label2" runat="server" BackColor="Red" Font-Bold="True" Font-Size="X-Large"
            ForeColor="White" Style="z-index: 100; left: 487px; position: absolute; top: 61px"
            Text="Label"></asp:Label>
        <asp:TextBox ID="TextBox1" runat="server" Columns="50" Rows="6" Style="z-index: 102;
            left: 315px; position: absolute; top: 105px" TextMode="MultiLine"></asp:TextBox>
        <asp:RadioButton ID="RadioButton1" runat="server" Style="z-index: 103; left: 356px;
            position: absolute; top: 236px" GroupName="answers" />
        <asp:RadioButton ID="RadioButton2" runat="server" Style="z-index: 104; left: 357px;
            position: absolute; top: 307px" GroupName="answers" />
        <asp:RadioButton ID="RadioButton3" runat="server" Style="z-index: 105; left: 359px;
            position: absolute; top: 379px" GroupName="answers" />
        <asp:RadioButton ID="RadioButton4" runat="server" Style="z-index: 106; left: 362px;
            position: absolute; top: 453px" GroupName="answers" />
        <asp:Button ID="prevquest" runat="server" OnClick="prevquest_Click" Style="z-index: 107;
            left: 357px; position: absolute; top: 505px" Text="Previous Question" />
        <asp:Button ID="nextquest" runat="server" OnClick="nextquest_Click" Style="z-index: 108;
            left: 536px; position: absolute; top: 506px" Text="Next Question" UseSubmitBehavior="False" />
        <asp:Button ID="cancelbutton" runat="server" Style="z-index: 110; left: 693px; position: absolute;
            top: 508px" Text="Cancel Test" OnClick="cancelbutton_Click" />
    
    </div>
</body>
</html>
</asp:Content>
