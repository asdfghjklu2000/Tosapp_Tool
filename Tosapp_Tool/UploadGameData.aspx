<%@ Page Title="" Language="C#" MasterPageFile="~/Layout/MasterPage.Master" AutoEventWireup="true" CodeBehind="UploadGameData.aspx.cs" Inherits="Tosapp_Tool.UploadGameData" %>
<asp:Content ID="MainContent" ContentPlaceHolderID="FloorDataContentPlaceHolder" runat="server">
    <%--<script src="Assets/js/jquery-2.1.4.min.js"></script>--%>
    <link rel="stylesheet" href="css/colorpicker.css" type="text/css" />
    <%--<link rel="stylesheet" media="screen" type="text/css" href="css/layout.css" />--%>
    <script src="Assets/js/bootstrap.min.js"></script>
    <script src="js/jquery.loading.min.js"></script>
    <%--<script src="js/Ted-ICU.js"></script>--%>
    <script type="text/javascript" src="js/jquery.js"></script>
	<script type="text/javascript" src="js/colorpicker.js"></script>
    <script type="text/javascript" src="js/eye.js"></script>
    <script type="text/javascript" src="js/utils.js"></script>
    <script type="text/javascript" src="js/layout.js?ver=1.0.2"></script>

    <style>
        .signin_box {
            /*width: 320px;*/
            /*max-width: 99%;
            min-width: 264px;*/
            width: 90%;
            /*background: #F7F6F2;*/
            padding: 5px;
            text-align: left;
            margin-right: auto;
            margin-left: auto;
            /*-webkit-box-shadow: 0 1px 2px rgba(0, 0, 0, 0.25);
            -moz-box-shadow: 0 1px 2px rgba(0, 0, 0, 0.25);
            box-shadow: 0 1px 2px rgba(0, 0, 0, 0.25);*/
            position: relative;
        }

        @media(min-width:99%) {
            .signin_box .left-content {
                position: relative;
                top: 0px;
                width: 90%;
            }

            .signin_box .left-content {
                padding-right: 0px;
                left: 0;
                padding-bottom: 0px;
            }

            /*.signin_box .left-content {
            padding-right: 340px;
            width:280px;
            left: 0;
            padding-bottom:50px;
        }*/

            .signin_box .right-content {
                position: absolute;
                z-index: 1;
                right: 10px;
                top: 20px;
            }
            /*.signin_box .right-content {
            background-color:#fff;
            padding:10px;
            width:320px;
            float:right;
            margin-top:-300px;
        }*/


            .signin_box .right-content {
                /*background-color: #fff;*/
                padding: 10px;
            }
        }
    </style>
    <%Session["tosfloorhtmlstring"] = "";%>
    <div class="Scontainer">
        <section class="signin_box">
            <%--left content--%>
            <div class="left-content">
                <div id="inputArea">
                    <label id="lbl_gamedata_json">JSON字串：</label>
                    <br />
                    <textarea id="txt_gamedata_json" cols="40" rows="5" placeholder="輸入文字"></textarea>
                    <br />
                    <br />
                    <br />

                    <input type="button" id="submitHtmlButton" name="submitHtmlButton" value="轉換Html" onclick="storeGameData()"/>&nbsp&nbsp&nbsp;
                    <br />                    
                    <script type='text/javascript'>
                        
                        //呼叫webservice function
                        function storeGameData () {
                            var vGamedata_json = $("#txt_gamedata_json").val();
                            
                            $.ajax({
                                url: "tosapphou_ws.asmx/StoreGameData",
                                type: "POST",
                                data: { arg_gamedata_json: vGamedata_json },
                                contenttype: "application/xml; charset=utf-8",
                                dataType: "xml",
                                asyn: true,
                                error: function (xml) {
                                    alert('Error loading XML document：' + xml);
                                },
                                success: function (data) {
                                    alert($(data).find("string").text());
                                }
                            });
                        }

                    </script>
                </div>
            </div>
            <div id="result" class="right-content"></div>
        </section>
    </div>
</asp:Content>
