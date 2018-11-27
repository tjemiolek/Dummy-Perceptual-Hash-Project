<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ChoosenPhoto.aspx.cs" Inherits="DPHAlgorithmProject.ChoosenPhoto" %>

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
            <span class="TitleHeader">Podobne fotografie</span>
                </div>

            <div class="LogoutPanel">
            <asp:HyperLink ID="LogOut" runat="server" NavigateUrl="~/LoginPage.aspx">Wyloguj</asp:HyperLink>
                </div>

            </div>   

            <div runat="server" id="MainPhoto">
                </div>





                <div class="panel-group">
  <div class="panel panel-primary">
      <div class="panel-heading">Galeria podobnych fotografii</div>
   <div class="panel-body" runat="server" id="SimilarPhoto">


      </div>
            </div>
        </div>


          <%--  <div runat="server" id="SimilarPhoto">

                </div>--%>

    </form>
</body>
</html>
