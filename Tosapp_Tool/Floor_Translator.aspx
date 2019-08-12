<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Floor_Translator.aspx.cs" Inherits="Tosapp_Tool.Floor_Translator"%>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        關卡名稱(Optional)：
        <br />
        <asp:TextBox ID="txt_floor_name" runat="server" Height="16px" Width="364px" TextMode="SingleLine"></asp:TextBox>
        <br /><br />
        標題背景顏色(Optional)(格式：00FFFF)：
        <br />
        <asp:TextBox ID="txt_title_color" runat="server" Height="16px" Width="364px" TextMode="SingleLine"></asp:TextBox>
        <br /><br />
        標題文字顏色(Optional)(格式：00FFFF)：
        <br />
        <asp:TextBox ID="txt_title_word_color" runat="server" Height="16px" Width="364px" TextMode="SingleLine"></asp:TextBox>
        <br /><br />
        JSON字串：
        <br />
        <asp:TextBox ID="txt_floor_json" runat="server" Height="404px" Width="364px" TextMode="MultiLine"></asp:TextBox>
        <br /><br /><br /><br />

    </div>
        <asp:Button ID="Button1" runat="server" OnClick="Button1_Click" Text="轉換" />
    </form>
</body>
</html>
