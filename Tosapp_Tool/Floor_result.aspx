<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Floor_result.aspx.cs" Inherits="Tosapp_Tool.Floor_result" %>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title></title>
    <%--<script src="Assets/js/bootstrap.min.js"></script>--%>
    <%--    <script src="js/jquery.loading.min.js"></script>
    <script src="js/Ted-ICU.js"></script>--%>
    <script src="Assets/js/jquery-2.1.4.min.js"></script>
    <script>
        $(document).ready(function () {
            //alert("test");
            var vData = (localStorage["htmlstring"]);
            //alert(vData);
            if (vData != "" && vData != null)
                document.write(localStorage["htmlstring"]);
            else
                document.write("資訊傳遞錯誤！請回到輸入頁面重新輸入：<a href='Floor_Data.aspx'>關卡資訊產生器</a>");
            return false;
        });
    </script>
</head>
<body>
    <form id="TheForm" method="post">
        <div>
        </div>
    </form>
</body>
</html>
