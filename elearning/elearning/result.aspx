<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="result.aspx.cs" Inherits="result" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html >
<head>
    <title>Untitled Page</title>
</head>
<body>
    <div>
        <asp:Label ID="Label1" runat="server" Font-Bold="True" Font-Names="Arial Black" Font-Size="XX-Large"
            Style="z-index: 100; left: 199px; position: absolute; top: 83px" Text="Your marks are"></asp:Label>
        &nbsp;
        <asp:Button ID="homebutton" runat="server" OnClick="homebutton_Click" Style="z-index: 102;
            left: 303px; position: absolute; top: 270px" Text="Home Page" />
        <asp:Label ID="Label2" runat="server" Font-Bold="True" Font-Italic="True" Font-Size="XX-Large"
            ForeColor="Red" Style="z-index: 103; left: 303px; position: absolute; top: 173px"
            Text="Label"></asp:Label>
        <asp:Button ID="viewAnswer" runat="server" Style="z-index: 101; left: 454px; position: absolute;
            top: 273px" Text="View Answers" OnClick="viewAnswer_Click" />
    
    </div>
</body>
</html>
</asp:Content>
