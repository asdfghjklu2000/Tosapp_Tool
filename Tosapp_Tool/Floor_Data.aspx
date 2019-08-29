<%@ Page Title="" Language="C#" MasterPageFile="~/Layout/MasterPage.Master" AutoEventWireup="true" CodeBehind="Floor_Data.aspx.cs" Inherits="Tosapp_Tool.Floor_Data" %>

<asp:Content ID="MainContent" ContentPlaceHolderID="FloorDataContentPlaceHolder" runat="Server">
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
		.submitButton{
			border:0;
			background-color:#003C9D;
			color:#fff;
			border-radius:10px;
			border:2px #fff solid;
			cursor:pointer;
			width:150px;
			height:50px;
		}
		  
		.submitButton:hover{
			color:#003C9D;
			background-color:#fff;
			border:2px #003C9D solid;
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
                    <label id="lbl_title_color">標題背景顏色(Optional)(格式：00FFFF)(轉換Html使用)：</label>
                    <br />
                    <input id="txt_title_color" type="text" placeholder="輸入文字" />
                    <br />
                    <label id="lbl_title_word_color">標題文字顏色(Optional)(格式：00FFFF)(轉換Html使用)：</label>
                    <br />
                    <input id="txt_title_word_color" type="text" placeholder="輸入文字" />
                    <br />
                    <label id="lbl_floor_json">JSON字串：</label>
                    <br />
                    <textarea id="txt_floor_json" cols="40" rows="5" placeholder="輸入文字"></textarea>
                    <br />
                    <br />
                    <br />

                    <input class="submitButton" type="button" id="submitHtmlButton" name="submitHtmlButton" value="轉換Html" onclick="showtype(1)"/>&nbsp&nbsp
                    <input class="submitButton" type="button" id="submitWikiButton" name="submitWikiButton" value="轉換Wikia語法" onclick="showtype(2)"/>&nbsp&nbsp
                    <input class="submitButton" type="button" id="submitBahaButton" name="submitBahaButton" value="轉換巴哈語法" onclick="showtype(3)"/><br />
                    <input class="submitButton" type="button" id="submitWiki2BahaButton" name="submitWiki2BahaButton" value="維基轉巴哈" onclick="showtype(6)"/>&nbsp&nbsp
                    <input class="submitButton" type="button" id="submitJsonButton" name="submitJsonButton" value="自定義JSON" onclick="showtype(5)"/>&nbsp&nbsp
                    <input class="submitButton" type="button" id="submitWiki2JsonButton" name="submitWiki2JsonButton" value="維基轉JSON" onclick="showtype(7)"/>

                    <br /><br />
                    <label id="lbl_remind_str">※Color Picker在行動裝置上可能無法直接點選顏色，請直接輸入顏色代碼，Color Picker會即時顯示對應顏色，確定後點按Color Picker右下角彩虹圓點即可關閉Color Picker</label>
                    <br />
                    <%--<div id="result"></div>--%>
                    <%--<asp:TextBox ID="txt_floor_name" runat="server" Height="16px" Width="364px" TextMode="SingleLine"></asp:TextBox>
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
                    <br /><br /><br /><br />--%>

                    <%--<form id="TheForm" method="post" action="tosapphou_ws.asmx/GetHtml" target="_blank">
                    <input type="hidden" name="floorName" value="" />
                    <input type="hidden" name="arg_title_color" value="" />
                    <input type="hidden" name="arg_title_word_color" value="" />
                    <input type="hidden" name="arg_floor_json" value="" />
                    </form>--%>
                    <script type='text/javascript'>
                        $('#li_Floor_Data').addClass("active");
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
                        //$("#submitButton").click(showtype(1));
                        //$("#submitWikiButton").click(showtype(2));

                    </script>
                </div>
            </div>
            <div id="result" class="right-content"></div>
        </section>
    </div>
</asp:Content>
