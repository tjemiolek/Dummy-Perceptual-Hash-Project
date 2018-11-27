<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="FotoPage.aspx.cs" Inherits="DPHAlgorithmProject.FotoPage" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
     <link href="Content/bootstrap.min.css" rel="stylesheet" />
    <link href="Content/StyleProject.css" rel="stylesheet" />
    <script src="Scripts/jquery-3.3.1.min.js"></script>
    <script src="Scripts/bootstrap.min.js"></script>
    <style type="text/css">
        




        

    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div class="appHeader">
                
            <div class="TitlePanel">
            <span class="TitleHeader">Galeria fotografii</span>
                </div>

            <div class="LogoutPanel">
            <asp:HyperLink ID="LogOut" runat="server" NavigateUrl="~/LoginPage.aspx">Wyloguj</asp:HyperLink>
                </div>

            </div>    
        <asp:Label ID="Label2" runat="server" Text="Witaj"></asp:Label>
        <p>
            <asp:HyperLink ID="HyperLink1" runat="server" NavigateUrl="~/AddImagePage.aspx">Dodaj obrazek</asp:HyperLink>
        </p>
        <div class="panel-group">
  <div class="panel panel-primary">
      <div class="panel-heading">Moja Galeria</div>
   <div class="panel-body" runat="server" id="GalleryBodyPanel">


        <div class="AddPhotoButtonDiv">
        &nbsp;<asp:Button ID="AddPhotoButton" CssClass="btn btn-primary" runat="server"  PostBackUrl="~/AddImagePage.aspx" Text="Dodaj fotografię" />
            </div>
      </div>
            </div>
        </div>
        <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:DPHConnectionString %>" SelectCommand="SELECT * FROM [UserData]"></asp:SqlDataSource>
    </form>
</body>
</html>
