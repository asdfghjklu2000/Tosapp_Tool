<%@ Page Title="" Language="C#" MasterPageFile="~/Layout/MasterPage.Master" AutoEventWireup="true" CodeBehind="StageDetail.aspx.cs" Inherits="Tosapp_Tool.StageDetail" %>
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
    <script type='text/javascript'>
      function isHidden(oDiv) {
        var vDiv = document.getElementById(oDiv);//div id用于折疊主體
        vDiv.style.display = (vDiv.style.display == 'none')?'block':'none';//反轉
        var oDiv1 = oDiv + '_1';
        var vDiv1 = document.getElementById(oDiv1);//div id1用于折疊狀态顯示展開的+号
        vDiv1.style.display = (vDiv1.style.display == 'none')?'block':'none';//反轉
        var oDiv2 = oDiv + '_2';
        var vDiv2 = document.getElementById(oDiv2);//div id2用于展開狀态顯示折疊的-号
        vDiv2.style.display = (vDiv2.style.display == 'none')?'block':'none';//反轉
      }
    </script>

    <style>
        #gotop {
            display: none;
            position: fixed;
            right: 40px;
            bottom: 100px;
            padding: 10px 15px;
            font-size: 20px;
            background: #F64359;
            color: white;
            cursor: pointer;
        }
        #godown {
            display: none;
            position: fixed;
            right: 40px;
            bottom: 60px;
            padding: 10px 15px;
            font-size: 20px;
            background: #F64359;
            color: white;
            cursor: pointer;
        }
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
    <div id="div_tip"></div>
    <div class="Scontainer">
        <span>※ 此頁面資訊將於每日0點更新</span><br>
        <span>※ 此頁面讀取大約會花10~20秒，請耐心等候</span>
        <section class="signin_box">
            <div class="left-content" id="div_stage_detail" width="50%">
                
            </div>
        </section>
    </div>
    <div id='gotop' ><center>∧</center></div>
    <div id='godown' ><center>∨</center></div>
    <%--<div id="div_stage_detail"></div>--%>
    <script type='text/javascript'>
        $('#li_StageDetail').addClass("active");
        $.ajax({
            url: "tosapphou_ws.asmx/genStageDetailHtml",
            type: "POST",
            data: { },
            contenttype: "application/xml; charset=utf-8",
            dataType: "xml",
            asyn: true,
            error: function (xml) {
                alert('Error loading XML document：' + xml);

            },
            success: function (data) {
                $("#div_stage_detail").html($(data).find("string").text());
            }
        });
        $(function () {
            $("#gotop").click(function () {
                jQuery("html,body").animate({
                    scrollTop: 0
                }, 1000);
            });
            $("#godown").click(function () {
                jQuery("html,body").animate({
                    scrollTop: $(document).height()
                }, 1000);
            });
            $(window).scroll(function () {
                if ($(this).scrollTop() < 300) {
                    $('#gotop').stop().fadeOut("fast");
                }
                else if ($(this).scrollTop() > ($(document).height()-300)) {
                    $('#godown').stop().fadeOut("fast"); 
                }
                else {
                    $('#gotop').fadeIn("fast");
                    $('#godown').fadeIn("fast");
                }
            });
        });
        //$("#div_stage_detail").html("test");
    </script>
</asp:Content>
