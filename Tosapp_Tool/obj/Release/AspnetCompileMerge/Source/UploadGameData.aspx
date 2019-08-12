﻿<%@ Page Title="" Language="C#" MasterPageFile="~/Layout/MasterPage.Master" AutoEventWireup="true" CodeBehind="UploadGameData.aspx.cs" Inherits="Tosapp_Tool.UploadGameData" %>
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
                    <label id="lbl_floor_name">關卡名稱(Optional)：</label>
                    <br />
                    <input id="txt_floor_name" type="text" placeholder="輸入文字" />
                    <br />
                    <label id="lbl_title_color">標題背景顏色(Optional)(格式：00FFFF)：</label>
                    <br />
                    <input id="txt_title_color" type="text" placeholder="輸入文字" />
                    <br />
                    <label id="lbl_title_word_color">標題文字顏色(Optional)(格式：00FFFF)：</label>
                    <br />
                    <input id="txt_title_word_color" type="text" placeholder="輸入文字" />
                    <br />
                    <label id="lbl_floor_json">JSON字串：</label>
                    <br />
                    <textarea id="txt_floor_json" cols="40" rows="5" placeholder="輸入文字"></textarea>
                    <br />
                    <br />
                    <br />

                    <input type="button" id="submitHtmlButton" name="submitHtmlButton" value="轉換Html" onclick="showtype(1)"/>&nbsp&nbsp
                    <input type="button" id="submitWikiButton" name="submitWikiButton" value="轉換Wikia語法" onclick="showtype(2)"/>
                    
                    <br /><br />
                    <label id="lbl_remind_str">※Color Picker在行動裝置上可能無法直接點選顏色，請直接輸入顏色代碼，Color Picker會即時顯示對應顏色，確定後點按Color Picker右下角彩虹圓點即可關閉Color Picker</label>
                    <br />                    
                    <script type='text/javascript'>
                        //javascript 顏色選擇器
                        $('#txt_title_color, #txt_title_word_color').ColorPicker({
                                                    onSubmit: function (hsb, hex, rgb, el) {
                                                        $(el).val(hex);
                                                        $(el).ColorPickerHide();
                                                    },
                                                    onBeforeShow: function () {
                                                        $(this).ColorPickerSetColor(this.value);
                                                    }
                                                })
                        .bind('keyup', function () {
                            $(this).ColorPickerSetColor(this.value);
                        });

                        //呼叫webservice function
                        function showtype (type) {
                            //alert('success');                            
                            var vfloorName = $("#txt_floor_name").val();
                            var varg_title_color = $("#txt_title_color").val();
                            var varg_title_word_color = $("#txt_title_word_color").val();
                            var varg_floor_json = $("#txt_floor_json").val();
                            var winRef = window.open("", "熾天使Seraphim-"+type+" -【"+vfloorName+"】");

                            $.ajax({
                                url: "tosapphou_ws.asmx/GetHtml",
                                type: "POST",
                                data: { floorName: vfloorName, arg_title_color: varg_title_color, arg_title_word_color: varg_title_word_color, arg_floor_json: varg_floor_json, arg_showtype: type },
                                contenttype: "application/xml; charset=utf-8",
                                dataType: "xml",
                                asyn: true,
                                error: function (xml) {
                                    winRef.close();
                                    alert('Error loading XML document：' + xml);
                                    
                                },
                                success: function (data) {
                                    //$("#TheForm input[name=htmlstring]").val($(data).find("string").text());

                                    //將webservice回傳的html語法存到localStorage
                                    localStorage.htmlstring = $(data).find("string").text();
                                    //打開Floor_result，讓它pageload時讀進html
                                    winRef.location = "Floor_result.aspx";
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
