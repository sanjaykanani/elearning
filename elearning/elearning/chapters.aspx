<%@ Page Title="" Language="C#"  MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="chapters.aspx.cs" Inherits="_Default" %>
 
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server"> 
    
    <!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html >
<head>
    <title>C Chapters</title>
</head>
<body>
    
        <asp:Button ID="nxtbutton" runat="server" Style="z-index: 100; left: 655px; position: absolute;
            top: 547px" Text="Next Chapter" OnClick="nxtbutton_Click" />
        <asp:Button ID="testbutton" runat="server" Style="z-index: 101; left: 880px; position: absolute;
            top: 547px" Text="Test" OnClick="testbutton_Click" />
        <asp:Button ID="prevbutton" runat="server" OnClick="prevbutton_Click" Style="z-index: 102;
            left: 386px; position: absolute; top: 545px" Text="Previous Chapter" />
        <asp:Label ID="Label2" runat="server" BackColor="Red" Font-Bold="True" Font-Size="X-Large"
            ForeColor="White" Style="z-index: 103; left: 671px; position: absolute; top: 110px; height: 40px;"
            Text="Label"></asp:Label>
        <asp:Label ID="Label10" runat="server" BackColor="Red" Font-Bold="True" Font-Size="X-Large"
            ForeColor="White" Style="z-index: 103; left: 529px; position: absolute; top: 110px"
            Text="Chapter: "></asp:Label>
        
        <asp:TextBox ID="TextBox1" runat="server" Columns="80" Rows="20" Style="z-index: 108;
            left: 268px; position: absolute; top: 160px; height: 329px; width: 796px;" TextMode="MultiLine"></asp:TextBox>

        <asp:DropDownList ID="DropDownList1" runat="server" AutoPostBack="True" DataSourceID="SqlDataSource1"
            DataTextField="chapno" DataValueField="chapno" OnSelectedIndexChanged="DropDownList1_SelectedIndexChanged"
            Style="z-index: 106; left: 166px; position: absolute; top: 88px">
        </asp:DropDownList>
        <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="Data Source=DESKTOP-T30UDT3\SQLEXPRESS;Initial Catalog=elearning;Integrated Security=True" ProviderName="System.Data.SqlClient" SelectCommand="SELECT [chapno] FROM [cchapters]"></asp:SqlDataSource>
        &nbsp;
        <asp:Label ID="Label3" runat="server" Style="z-index: 107; left: 17px; position: absolute;
            top: 85px" Text="Select a Chapter"></asp:Label>
        
    </body>
    </html>

 </asp:Content>
            

