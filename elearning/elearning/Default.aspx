<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="elearning._Default" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

    <div class="jumbotron">
        <h1><center><h1>Welcome to E-Learning</h1></center></h1>
        <center><p class="lead">E-learning is a learning package which will help you explore through various programming languages.</p></center>
    </div>

    <div class="row">
        <div class="col-md-4">
            <h2>Let us learn C Programming</h2>
            <p>
                This will help you gain basic programming skills and quiz is available at the end to boost your confidence. Good Luck!.
            </p>
            <p>
                <asp:Button ID="nxtbutton" class="btn btn-default" runat="server" Style="z-index: 100; left: 15px; position: absolute; top: 110px; width: 109px; height: 33px;" Text="Learn more »" OnClick="chapters_Click" />
            </p>
        </div>
        <div class="col-md-4">
            <h2>Get more libraries</h2>
            <p>
                NuGet is a free Visual Studio extension that makes it easy to add, remove, and update libraries and tools in Visual Studio projects.
            </p>
            <p>
                <a class="btn btn-default" href="http://go.microsoft.com/fwlink/?LinkId=301949">Learn more &raquo;</a>
            </p>
        </div>
        <div class="col-md-4">
            <h2>Web Hosting</h2>
            <p>
                You can easily find a web hosting company that offers the right mix of features and price for your applications.
            </p>
            <p>
                <a class="btn btn-default" href="http://go.microsoft.com/fwlink/?LinkId=301950">Learn more &raquo;</a>
            </p>
        </div>
    </div>

</asp:Content>
