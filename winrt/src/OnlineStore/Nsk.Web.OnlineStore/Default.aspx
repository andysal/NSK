<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="System.Web.UI.Page" %>

<html>
<head>
    <title>Fake home page</title>
</head>
<body>
    <script runat="server">
        void Page_Load()
        {
            Response.Redirect("~/Home");
        }
    </script>
</body>
</html>