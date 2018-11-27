<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AddImagePage.aspx.cs" Inherits="DPHAlgorithmProject.AddImagePage" %>

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
            <span class="TitleHeader">Panel dodawania fotografii</span>
             <div class="LogoutPanel">
            <asp:HyperLink ID="LogOut" runat="server" NavigateUrl="~/LoginPage.aspx">Wyloguj</asp:HyperLink>
                </div>
            </div>
        <asp:Label ID="Label1" runat="server" Text="Witaj"></asp:Label>
        <div class="panel-group">
  <div class="panel panel-primary">
      <div class="panel-heading">Dodaj Plik</div>
   <div class="panel-body" runat="server">
        <div class="PhotoUploadPanel">
            <asp:FileUpload ID="FileUpload1" CssClass="form-control-file" runat="server" />
        </div>
        <asp:Button ID="Button1" runat="server" CssClass="btn btn-primary savePhotoButton" OnClick="Button1_Click" Text="Zapisz Plik" />
       </div>
      </div>
            </div>
        <div>
        </div>
         <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:DPHConnectionString %>" SelectCommand="SELECT * FROM [UserData]"></asp:SqlDataSource>
    </form>
</body>
</html>
