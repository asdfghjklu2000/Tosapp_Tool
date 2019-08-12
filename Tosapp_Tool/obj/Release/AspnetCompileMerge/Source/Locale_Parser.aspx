<%@ Page Title="" Language="C#" MasterPageFile="~/Layout/MasterPage.Master" AutoEventWireup="true" CodeBehind="Locale_Parser.aspx.cs" Inherits="Tosapp_Tool.Locale_Parser" %>

<asp:Content ID="MainContent" ContentPlaceHolderID="FloorDataContentPlaceHolder" runat="server">    
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
    <br /><br />
    <div class="Scontainer">
        <section class="signin_box">
            <div class="left-content">
                <span>※考慮此空間流量問題，所以另外開發windows程式用來轉換Locale.csv.txt，連結在下面 ↓</span><br />
                <span><a href="https://drive.google.com/file/d/1ZzyKiVSg_NfWX11k6xJXTGiyvDN6Ws7j/view?usp=sharing">https://drive.google.com/file/d/1ZzyKiVSg_NfWX11k6xJXTGiyvDN6Ws7j/view?usp=sharing</a></span><br />
                <span>※應該不用操作說明吧……非常簡潔的介面……</span>
                <%--<span>※請把Locale.csv.txt上傳，我會送excel跟txt給你唷♥</span>
                <input id="fileUpload" type="file" />
                <br />
                <input id="btnUploadFile" type="button" value="下載excel檔(.xlsx)" disabled="disabled"/>&nbsp&nbsp
                <input id="btnDownTxt" type="button" value="下載text檔(.txt)" disabled="disabled"/>
                <br />
                <span>※因為此免費空間有流量上限問題，所以 ↑ 此功能先停用了，囧rz。</span>--%>
            </div>
        </section>
    </div>

<%--    <div id="plitTable">
        <table id="tbl" border="1">
            <thead>
          <tr >
           <th align="left" >Name</th>
           <th align="left" >Content</th>
          </tr>
            </thead>
         <tbody>
          <tr>
           <td>Name1</td>
           <td>Content1</td>
          <tr>
           <td>Name2</td>
           <td>Content2</td>
          <tr>
           <td>Name3</td>
           <td>Content3</td>
          <tr>
           <td>Name4</td>
           <td>Content4</td>
          <tr>
           <td>Name5</td>
           <td>Content5</td>
          <tr>
           <td>Name6</td>
           <td>Content6</td>
          </tbody>
        </table>
        <span id='table_page2'></span>
    </div>

    <div id="testTable" style="display:none">
        <table class="usertableborder" cellspacing="0" rules="all" border="1" id="gv_locale" style="border-collapse: collapse;" width="95%">
            <thead>
                <tr class="Freezing">
                    <th scope="col" style="white-space: nowrap; word-break: keep-all; word-wrap: keep-all">編號
                    </th>
                    <th scope="col" style="white-space: nowrap; word-break: keep-all; word-wrap: keep-all">中文
                    </th>
                    <th scope="col" style="white-space: nowrap; word-break: keep-all; word-wrap: keep-all">
                        <a href="javascript:__doPostBack(&#39;gvEquData&#39;,&#39;Sort$samid&#39;)">英文</a>
                    </th>
                    <th scope="col" style="white-space: nowrap; word-break: keep-all; word-wrap: keep-all">
                        <span class="farupdateflag">
                            <input id="gvEquData_ctl01_farupdateflag" type="checkbox" name="gvEquData$ctl01$farupdateflag" />
                        </span>FAR参数更新标识
                    </th>
                </tr>
            </thead>
            <tbody>
                <tr onmouseover="Color=this.style.backgroundColor;this.style.backgroundColor=&#39;RosyBrown&#39;"
                    onmouseout="this.style.backgroundColor=Color;" ondblclick="showDetailInfo(&#39;?id=&#39;);return false;"
                    style="background-color: Silver;">
                    <td style="white-space: nowrap; word-break: keep-all; word-wrap: keep-all">null
                    </td>
                    <td style="white-space: nowrap; word-break: keep-all; word-wrap: keep-all">null
                    </td>
                    <td align="center" style="white-space: nowrap; word-break: keep-all; word-wrap: keep-all">null
                    </td>
                    <td style="white-space: nowrap; word-break: keep-all; word-wrap: keep-all">
                        <span class="farupdateflag">
                            <input id="gvEquData_ctl02_cbx_-farupdateflag" type="checkbox" name="gvEquData$ctl02$cbx_-farupdateflag" checked="checked" />

                        </span>
                    </td>
                </tr>
            </tbody>
            <tfoot>
            </tfoot>
        </table>
        <span id='table_page'></span>
    </div>
    <div id="id01" style="width: 100%; height: 600px; overflow: scroll;"></div>   --%> 
    <script src="js/jquery-tablepage-1.0.js"></script>
    <script type='text/javascript'>
        $('#li_Locale_Parser').addClass("active");      
        function ArrayBufferToBase64(buffer) {
            //array轉base64
            var binary = '';
            var bytes = new Uint8Array(buffer);

            for (var xx = 0, len = bytes.byteLength; xx < len; ++xx) {
                binary += String.fromCharCode(bytes[xx]);
            }
            return window.btoa(binary);

            // return btoa(String.fromCharCode.apply(null, bytes)); // Note: tried this but always get an error "Maximum call stack size exceeded"
        }

        function BuildTable(jsonstr) {
            //json轉html table語法(沒用到)
            var AllData = $.parseJSON(jsonstr);
            var htmlstr = "";
            htmlstr = "<table cellpadding=\"1\" cellspacing=\"1\" frame=\"border\" border=\"5\" style=\"font-family:微軟正黑體;\"><tr><td><b>編號</b></td><td><b>中文</b></td><td><b>英文</b></td></tr>";
            //alert('success');
            //$('#id01').append('<table cellpadding="1" cellspacing="1" frame="border" border="5" style="font-family:微軟正黑體;">');
            //$('#id01').append('<tr>');
            //$('#id01').append('<td><b>編號</b></td><td><b>中文</b></td><td><b>英文</b></td>');
            //$('#id01').append('</tr>');

            $.each(AllData, function (i, item) {                      //讀取所有紀錄
                //var 變數一 = item.回傳欄位;                               //讀取數值
                //執行動作
                htmlstr += '<tr>';
                htmlstr += '<td>' + item.編號 + '</td>' + '<td>' + item.中文.replace(/\n/g, '<br/>') + '</td>' + '<td>' + item.英文.replace(/\n/g, '<br/>') + '</td>';
                htmlstr += '</tr>';
                //$('#id01').append('<tr>');
                //$('#id01').append('<td>' + item.編號 + '</td>' + '<td>' + item.中文.replace(/\n/g, '<br/>') + '</td>' + '<td>' + item.英文.replace(/\n/g, '<br/>') + '</td>');
                //$('#id01').append('</tr>');
            });
            htmlstr += '</table>';
            $('#id01').append(htmlstr);
            //$('#id01').append('</table>');
        }

        $('#btnUploadFile').on('click', function () {            
            $('#btnUploadFile').attr('disabled', 'disabled');
            
            var jsonstring = new ArrayBuffer();
            file = $('#fileUpload')[0].files['0'];
            var fReader = new FileReader();
            var winRef = window.open("", "熾天使Seraphim - excel");

            fReader.onload = function (event) {                
                var data = {
                    //傳入的arraybuffer呼叫function轉為base64格式並放到變數[filebase64]
                    filebase64: ArrayBufferToBase64(event.target.result)
                };
                $.ajax({
                    url: "tosapphou_ws.asmx/GetLocale",
                    type: "POST",
                    data: data,
                    contenttype: "application/json, charset=utf-8",
                    dataType: "xml",
                    asyn: true,
                    error: function (xml) {
                        alert('Error loading XML document：' + xml.error.toString());
                    },
                    success: function (data) {
                        //此webservice[GetLocale]接收base64字串後會回傳轉換好的excel檔案路徑
                        //window.open("Locale_Download.aspx?ext=xlsx&getFilePath=" + $(data).find("string").text(), "")
                        winRef.location = "Locale_Download.aspx?ext=xlsx&getFilePath=" + $(data).find("string").text();
                        //拿到檔案路徑後直接用get丟給locale_download會write檔案串流出來給client
                        $('#btnUploadFile').removeAttr('disabled');
                        //將按鈕回復

                        //$.ajax({
                        //    url: "Locale_Download",
                        //    type: "GET",
                        //    data: { getFilePath:data},
                        //    contenttype: "application/json, charset=utf-8",
                        //    dataType: "xml",
                        //    asyn: true,
                        //    error: function (xml2) {
                        //        //alert('Error loading XML document：' + xml.error.toString());
                        //    },
                        //    success: function (data2) {
                        //    }
                        //});
                        //alert('success');
                        //BuildTable($(data).find("string").text());
                        //$("#gv_locale").find("tr:gt(0)").remove();
                        ////$("#gv_locale").addrow();

                        ////$("#gv_locale").append("<tr><td>編號</td><td>中文</td><td>英文</td><td style=\"white-space: nowrap; word-break: keep-all; word-wrap: keep-all\"><span class=\"farupdateflag\"><input id=\"gvEquData_ctl02_cbx_-farupdateflag\" type=\"checkbox\" name=\"gvEquData$ctl02$cbx_-farupdateflag\" checked=\"checked\" /></span></td></tr>");
                        //var AllData = $.parseJSON($(data).find("string").text());
                        //$.each(AllData, function (i, item) {
                        //    //$("#gv_locale").append("<tr><td>" + item.編號 + "</td><td>" + item.中文 + "</td>" + "<td>" + item.英文 + "</td></tr>");
                        //    $("#gv_locale").append('            <tr onmouseover="Color=this.style.backgroundColor;this.style.backgroundColor=&#39;RosyBrown&#39;"'
                        //    + '                onmouseout="this.style.backgroundColor=Color;" ondblclick="showDetailInfo(&#39;?id=&#39;return false;"'
                        //    + '                style="background-color: Silver;">'
                        //    + '                <td style="white-space: nowrap; word-break: keep-all; word-wrap: keep-all">'
                        //    + item.編號
                        //    + '                </td>'
                        //    + '                <td style="white-space: nowrap; word-break: keep-all; word-wrap: keep-all">'
                        //    + item.中文.replace(/\n/g, '<br/>')
                        //    + '                </td>'
                        //    + '                <td align="center" style="white-space: nowrap; word-break: keep-all; word-wrap: keep-all">'
                        //    + item.英文.replace(/\n/g, '<br/>')
                        //    + '                </td>'
                        //    + '                <td style="white-space: nowrap; word-break: keep-all; word-wrap: keep-all">'
                        //    + '                    <span class="farupdateflag">'
                        //    + '                        <input id="gvEquData_ctl02_cbx_-farupdateflag" type="checkbox" name="gvEquData$ctl02$cbx_-farupdateflag" checked="checked" />'
                        //    + '                    </span>'
                        //    + '                </td>'
                        //    + '            </tr>');
                        //});

                        //$("#gv_locale").tablepage($("#table_page"), 100);
                        //$('#id01').append($(data).find("string").text());
                        //var mydt = data.Locale;
                        //$('#id01').html(BuildTable(mydt));
                        //alert('success');                        
                    }
                });
                //$('#id01').append(jsonstring[0]);
            };
            fReader.readAsArrayBuffer(file);            
        });

        $('#btnDownTxt').on('click', function () {
            $('#btnDownTxt').attr('disabled', 'disabled');
            var jsonstring = new ArrayBuffer();
            //var data = new FormData();
            //讀取json到字串jsonstring
            file = $('#fileUpload')[0].files['0'];
            //data.append("uploadfile", file);
            var fReader = new FileReader();
            var winRef = window.open("", "熾天使Seraphim - excel");

            fReader.onload = function (event) {
                var data = {
                    filebase64: ArrayBufferToBase64(event.target.result)
                };
                //jsonstring = event.target.result;
                $.ajax({
                    url: "tosapphou_ws.asmx/GetLocaleTxt",
                    type: "POST",
                    data: data,
                    contenttype: "application/json, charset=utf-8",
                    dataType: "xml",
                    asyn: true,
                    error: function (xml) {
                        alert('Error loading XML document：' + xml.error.toString());
                    },
                    success: function (data) {
                        //window.open("Locale_Download.aspx?ext=txt&getFilePath=" + $(data).find("string").text(), "")
                        winRef.location = "Locale_Download.aspx?ext=txt&getFilePath=" + $(data).find("string").text();
                        $('#btnDownTxt').removeAttr('disabled');
                    }
                });
            };
            fReader.readAsArrayBuffer(file);
        });

    </script>

</asp:Content>
