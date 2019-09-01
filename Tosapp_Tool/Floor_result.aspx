<%@ Page Language="C#" MasterPageFile="~/Layout/MasterPage.Master" AutoEventWireup="true" CodeBehind="Floor_result.aspx.cs" Inherits="Tosapp_Tool.Floor_result" %>

<asp:Content ID="MainContent" ContentPlaceHolderID="FloorDataContentPlaceHolder" runat="Server">
    <div id="htmlStrData"></div>
    <script>
        var vData = (localStorage["htmlstring"]);
        //alert(vData);
        //var innerHtml = $(vData).html();
        //alert(innerHtml);
        //alert(vData);
        if (vData != "" && vData != null)
            $("#htmlStrData").html(vData);
        else
            $("#htmlStrData").html("資訊傳遞錯誤！請回到輸入頁面重新輸入：<a href='Floor_Data.aspx'>關卡資訊產生器</a>");
    </script>
</asp:Content>