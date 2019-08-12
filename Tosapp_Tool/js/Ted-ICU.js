//重要註記：
//跨域請求dataType："jsonp" 請求"已"不支援同步操作。
//故原本在ajax 的url屬性：AI_SEPSIS.asmx/AI_SEPSIS_ANTIBIOTICS_COUNT 不可再使用
//須改成 http://主機IP/AI_SEPSIS.asmx/AI_SEPSIS_ANTIBIOTICS_COUNT
//主機IP必須是本機的IP

//Login.aspx 初始化

function Login_Initialize() {
    sessionStorage.eICU_lang = navigator.language;
    sessionStorage.removeItem["eICU_UserLoginID"];
    sessionStorage.removeItem["eICU_UserLoginNAME"];
    sessionStorage.eICU_UserLoginID = "";
    sessionStorage.eICU_UserLoginNAME = "";
    sessionStorage.eICU_Status = "N";
    sessionStorage.eICU_ID = "8620";
    sessionStorage.ServiceLocation = "http://10.32.19.106";  //Web Services 位置
    
   // sessionStorage.ServiceLocation = "http://219.87.146.176/";
}

//Login.aspx 登入驗證
function Login() {
    //=================================================================================================
    var vUserAcc = document.getElementById('UserAcc').value;
    var vUserPWD = Encrypto(document.getElementById('UserPWD').value,196,64);
    console.log('vUserPWD=', vUserPWD);
    
    //alert(sessionStorage["ServiceLocation"].toString());

    if (vUserAcc == "" || vUserAcc == " " || vUserAcc.length == 0) {
        sessionStorage.eICU_Status = "N";
        $("#UserAcc").focus();
        alert("請輸入登入帳號");
    }
    else {
        if (vUserPWD == "" || vUserPWD == " " || vUserPWD.length == 0) {
            sessionStorage.eICU_Status = "N";
            $("#UserPWD").focus();
            alert("請輸入密碼");
        }
        else {

            $.showLoading({ name: 'circle-fade', allowHide: false });  //啟用效果          
            $.ajax({
                url: sessionStorage["ServiceLocation"] + "/Ted-ICU.asmx/System_CheckLogin",
                type: "POST",
                data: { UserID: vUserAcc, UserPWD: vUserPWD },
                contenttype: "applicatio/json charset=utf-8",
                success: function (data) {
                    //alert(data);
                    var AllData = $.parseJSON(data);
                    $.each(AllData, function (i, item) {
                        var vOPER_ID = item.OPER_ID;        //登入醫師帳號
                        var vOPER_NAME = item.OPER_NAME;    //登入醫師名稱
                        var vDEPT_CODE = item.DEPT_CODE;    //部門代碼
                        var vOPER_ROLE = item.OPER_ROLE;    //角色
                        if (jQuery.trim(vOPER_ID) != "" || jQuery.trim(vOPER_ID).length != 0) {
                            $("#UserAcc").empty();
                            $("#UserPWD").empty();
                            //預設用SICU
                            window.location.href = "eICU.aspx";
                            //使用local session 儲存登入者資訊
                            sessionStorage.eICU_UserLoginID = vOPER_ID;
                            sessionStorage.eICU_UserLoginNAME = vOPER_NAME;
                            sessionStorage.eICU_UserRole = vOPER_ROLE;
                            sessionStorage.eICU_Status = "Y";
                            sessionStorage.eICU_ID = "8620"
                            //寫入登入紀錄 ===============================================================================================
                            $.ajax({
                                url: sessionStorage["ServiceLocation"]  + "/Ted-ICU.asmx/System_InsertLoginLog",
                                type: "POST",
                                data: { UserID: vOPER_ID, UserName: vOPER_NAME, Action: "1" },
                                contenttype: "applicatio/json charset=utf-8",
                                success: function (data) { },
                                error: function () {
                                    SystemAlert("寫入登出入紀錄錯誤!");
                                }
                            });
                            //============================================================================================================
                        }
                        else
                            SystemAlert("使用者帳號或密碼錯誤，請重新輸入!" + vUserPWD);
                    });
                },
                error: function () {                   
                    SystemAlert("帳號密碼驗證失敗!");
                }
            });
        }     
    }
    //=================================================================================================  
}

//敗血症判斷開始
function SEPSIS(ICU_NO) {
    $.ajax({
        url: 'iRobot.asmx/SEPSIS',
        type: 'POST',
        data: { ICUNO: ICU_NO },
        async: false,
        contenttype: 'applicatio/json charset=utf-8',
        success: function (data) {
            var AllData = $.parseJSON(data);
            $.each(AllData, function (i, item) {
                var vICU_NO = item.ICU_NO;
                var vBED_NO = item.BED_NO;
                var vFEE_NO = item.FEE_NO;
                var vANTIBIOTICS_COUNT = item.ANTIBIOTICS_COUNT;
                var LastBP = parseFloat(item.VITALSIGN_NBPM);
                var LastBT = parseFloat(item.VITALSIGN_BT);
                var LastRR = parseFloat(item.VITALSIGN_RR);
                var LabWBC = parseFloat(item.LAB_WBC.replace("10^3/uL","").trim()) * 1000;
                var SOFAScore = item.SOFA_SCORE;
                var ShowString = "";

                if ((LastBT >= 38.0 || LastBT <= 36.0))
                {
                    LastBT = "<font color='blue'>" + LastBT + "</font>";
                }
                if (LastRR > 20)
                {
                    LastRR = "<font color='blue'>" + LastRR + "</font>";
                }
                if (LabWBC > 12000 || LabWBC < 4000)
                {
                    LabWBC = "<font color='blue'>" + LabWBC + "</font>";
                }
                if (LastBP < 90) {
                    LastBP = "<font color='blue'>" + LastBP + "</font>";
                }
                if (SOFAScore <= 12 ) {
                    SOFAScore = "<font color='blue'>" + SOFAScore + "</font>";
                }
                SystemAlert("AI SEPSIS:<br/>" + "ICU ID:" + vICU_NO + "<br/>批序:" + vFEE_NO + "<br/>床號:" + vBED_NO + "<br/>抗生素:" + vANTIBIOTICS_COUNT + "<br/>即時平均動脈壓:" + LastBP + "<br/>即時體溫:" + LastBT + "<br/>即時呼吸:" + LastRR + "<br/>檢驗項目WBC:" + LabWBC + "<br/>即時SOFA:" + SOFAScore, "info");
            });
        },
        error: function (data) {
    
        }
    });

    //SystemAlert(ICU_NO);

	//var ANTIBIOTICS = isANTIBIOTICS(FEE_NO);                 //抗生素檢核
	//if (parseInt(ANTIBIOTICS) > 0 )                          //有使用抗生素
	//{
	//    var ICUDateTime = inICUDateTime(FEE_NO,BED_NO);      //入住ICU時間
	//    var averageNBPm = avgNBPm(ICUID,BED_NO,ICUDateTime); //入住期間平均動脈壓
    //        var LastBP = avgBP(ICUID,BED_NO);                //即時平均動脈壓
    //        var LastTP = TP(ICUID,BED_NO);                   //即時體溫
	//    var LastRR = RR(ICUID,BED_NO);                       //即時呼吸資料
	//    var LabWBC = Lab_WBC(CHR_NO);                        //檢驗項目(WBC)
	//    var R_SOFAScore = rSOFAScore(FEE_NO,CHR_NO);         //即時SOFA SCORE
	//    SystemAlert("AI SEPSIS:<br/>" + "ICU ID:" + ICUID + "<br/>批序:" + FEE_NO + "<br/>床號:" + BED_NO + "<br/>抗生素:" + ANTIBIOTICS + "<br/>入住時間:" + ICUDateTime + "<br/>入住期間平均動脈壓:" + averageNBPm + "<br/>即時平均動脈壓:" + LastBP + "<br/>即時體溫:" + LastTP + "<br/>即時呼吸:" + LastRR + "<br/>檢驗項目WBC:" + LabWBC + "<br/>即時SOFA:" + R_SOFAScore,"info");		
	//}
}

//是否使用抗生素
//function isANTIBIOTICS(vFEE_NO){
//    var ANTIBIOTICS_COUNT = "";
//    $.ajax({
//    	url:'AI_SEPSIS.asmx/AI_SEPSIS_ANTIBIOTICS_COUNT',
//        type: 'POST',
//        data: { FEE_NO: vFEE_NO },
//    	async:false,
//        contenttype: 'applicatio/json charset=utf-8',
//        success: function (data) {
//    		var AllData = $.parseJSON(data);
//    		$.each(AllData, function (i, item) {
//                   ANTIBIOTICS_COUNT = item.ANTIBIOTICS_COUNT;
//    	    });
//    	},
//    	error:function (data) {
//    		ANTIBIOTICS_COUNT = "0";
//    	}
//    });
//    return ANTIBIOTICS_COUNT;
//}

//入住ICU時間
////function inICUDateTime(vFEE_NO,vBED_NO){
//	var INICUDateTime = "";
//	$.ajax({
//        url: "ICU_BED_LIST.asmx/Get_Patient_ICUDatetime",
//        type: "POST",
//        async:false,
//        data: { FEE_NO: vFEE_NO, BED_NO: vBED_NO },
//        contenttype: "applicatio/json charset=utf-8",
//        success: function (data) {
//            var AllData = $.parseJSON(data);
//            $.each(AllData, function (i, item) {
//                var vICU_Date = item.BNG_DATE;    
//                var vICU_Time = item.BNG_TIME;
//                vICU_Date = (parseInt(vICU_Date.substr(0, 3)) + 1911).toString() + "-" + vICU_Date.substr(3, 2) + "-" + vICU_Date.substr(5, 2);
//                vICU_Time = vICU_Time.substr(0, 2) + ":" + vICU_Time.substr(2, 2) + ":00";
//                INICUDateTime = vICU_Date + " " + vICU_Time;
//			});
//		},
//        error:function(){
			
//		}
//	});	
//	return INICUDateTime;
//}
////
//////住院期間平均動脈壓
////function avgNBPm(vICUID, vBED_NO, SDateTime){
//    var avg_NBPm = "";
//    $.ajax({
//        url: "AI_SEPSIS.asmx/AI_SEPSIS_NBPm_Average",
//        type: "POST",
//        async:false,
//        data: { ICU_Code: vICUNO, BED_NO: vBED_NO, StartDate: SDateTime },
//        contenttype: "applicatio/json charset=utf-8",
//        success: function (data) {
//            var AllData = $.parseJSON(data);
//            $.each(AllData, function (i, item) {
//                avg_NBPm = item.TagValue;                 
//            });
//        },
//		error:function(){
//			avg_NBPm="0";
//		}
//    });	
//	return avg_NBPm;
//}
////
//////即時平均動脈壓值
////function avgBP(vICUNO,vBED_NO){
//	var NBPM="";
//    $.ajax({
//        url: "VitalSignData.asmx/VitalSign_BP",
//        type: "POST",
//		async:false,
//        data: { ICU_Code: vICUNO, Bed_NO: vBED_NO },
//        contenttype: "applicatio/json charset=utf-8",
//        success: function (data) {
//            var AllData = $.parseJSON(data);
//            $.each(AllData, function (i, item) {	
//			    if (item.Tagid == "0002-4a07") {
//                    NBPM = item.TagValue;             //即時平均動脈壓值
//                }
//			});
//		},
//		error:function(){
//			NBPM="0";
//		}
//    });
//	return NBPM;
//}
////
//////即時體溫
////function TP(vICUID,vBED_NO){
//	var TP = "";
//    $.ajax({
//        url: "VitalSignData.asmx/VitalSign_Temperature",
//        type: "POST",
//		async:false,
//        data: { ICU_Code: vICUID, Bed_NO: vBED_NO, StartDateTime: '', EndDateTime: '' },
//        contenttype: "applicatio/json charset=utf-8",
//        success: function (data) {
//            var AllData = $.parseJSON(data);
//            $("#VitalSign_BT").empty();
//            $.each(AllData, function (i, item) {
//                TP = item.TagValue;             //量測值0002-4b48
//            });
//        },
//		error:function(){
//			TP= "0";
//		}
//    });	
//	return TP;
//}
////
//////即時呼吸資料
////function RR(vICUID,vBED_NO){
//	var RR = "";
//    $.ajax({
//        url: "VitalSignData.asmx/VitalSign_RR",
//        type: "POST",
//		async:false,
//        data: { ICU_Code: vICUID, Bed_NO: vBED_NO, StartDateTime: '', EndDateTime: '' },
//        contenttype: "applicatio/json charset=utf-8",
//        success: function (data) {
//            var AllData = $.parseJSON(data);
//            $.each(AllData, function (i, item) {
//                RR = item.TagValue;             //呼吸量測值
//            });
//        },
//		error:function(){
//			RR="0";
//		}
//    });	
//	return RR;
//}
////
//////檢驗值(WBC)
////function Lab_WBC(vCHR_NO){
//    //取得檢驗資料
//	var WBC = "";
//    $.ajax({
//        url: "Labresult_Data.asmx/Get_Labresult_Data",
//        type: "POST",
//		async:false,
//        data: { CHR_NO: vCHR_NO },
//        contenttype: "applicatio/json charset=utf-8",
//        success: function (data) {
//            var AllData = $.parseJSON(data);
//            $.each(AllData, function (i, item) {
//                var vR_ITEM = item.R_ITEM;      //檢驗項目
//				var vVALUE = item.VALUE;        //檢驗值
//                if (jQuery.trim(vR_ITEM) =="050101")
//				{
//				  WBC = vVALUE.replace("10^3/uL","").trim();
//                  WBC = (parseFloat(WBC) * 1000).toString();	//10^3/uL==>mm==>uL * 1000		  
//				}     			    
//            });
//        },
//		error:function(){
//			WBC ="0";
//		}
//    });	
//	return WBC;
//}
////
//////取得即時SOFA Score
////function rSOFAScore(vFEE_NO,vCHR_NO){
//	var rSofa = "";
//    //取得SOFAScore 
//    $.ajax({
//        type: "POST",
//        data: { FEE_NO: vFEE_NO, CHR_NO: vCHR_NO },
//        contenttype: "applicatio/json charset=utf-8",
//        async: false,
//        url: "VitalSignData.asmx/Get_SOFAScore",
//        success: function (data) {
//           var AllData = $.parseJSON(data);
//            $.each(AllData, function (i, item) {
//                 rSofa = item.SOFASCORE;
//            });
//        },
//	    error:function(){
//		   rSofa = "0";
//	    }
//    });
//    return rSofa;
//}
////前1小時SOFA Score
//function LSOFAScore(vFEE_NO,vCHR_NO){
//
//}

/**
 * Encrypto 加密程序
 * @param {Strng} str 待加密字符串
 * @param {Number} xor 異或值
 * @param {Number} hex 加密後的進制數
 * @return {Strng} 加密後的字串
 */
function Encrypto(str, xor, hex) {
    if (typeof str !== 'string' || typeof xor !== 'number' || typeof hex !== 'number') {
        return;
    }

    let resultList = [];
    hex = hex <= 25 ? hex : hex % 25;

    for (let i = 0; i < str.length; i++) {
        // 提取字串每個字符的ascll碼
        let charCode = str.charCodeAt(i);
        // 進行加密
        charCode = (charCode * 1) ^ xor;
        // 加密後的字符轉成 hex 位數的字串
        charCode = charCode.toString(hex);
        resultList.push(charCode);
    }

    let splitStr = String.fromCharCode(hex + 97);
    let resultStr = resultList.join(splitStr);
    return resultStr;
}

/**
 * Decrypto 解密程序
 * @param {Strng} str 待加密字符串
 * @param {Number} xor 異或值
 * @param {Number} hex 加密後的進制數
 * @return {Strng} 加密後的字串
 */
function Decrypto(str, xor, hex) {
    if (typeof str !== 'string' || typeof xor !== 'number' || typeof hex !== 'number') {
        return;
    }
    let strCharList = [];
    let resultList = [];
    hex = hex <= 25 ? hex : hex % 25;
    // 解析出分割字串
    let splitStr = String.fromCharCode(hex + 97);
    // 分割出加密字串的加密後的每個字
    strCharList = str.split(splitStr);

    for (let i = 0; i < strCharList.length; i++) {
        // 將加密後的每個字符轉成加密後的ascll碼
        let charCode = parseInt(strCharList[i], hex);
        // 解密出原字串的ascll碼
        charCode = (charCode * 1) ^ xor;
        let strChar = String.fromCharCode(charCode);
        resultList.push(strChar);
    }
    let resultStr = resultList.join('');
    return resultStr;
}

function SystemAlert(messange) {
    alert(messange);
    //$("#SystemInfoMessangeContent").empty();
    //$("#SystemInfoMessangeContent").append(messange);
    //$("#SystemInfoMessange").modal("show");
    $.hideLoading();  //停用 Loading 效果
}


//Dashboard2.aspx
//取得目前日期的前後N天(民國年)
function GetDateStr(AddDayCount) {
    var dd = new Date();
    dd.setDate(dd.getDate() + AddDayCount);      //取得AddDayCount天後的日期
    var y = ((dd.getYear() + 1900) - 1911).toString();
    var m = (dd.getMonth() + 1) < 10 ? "0" + (dd.getMonth() + 1) : (dd.getMonth() + 1).toString();;//取得目前月份的日期，不足10補0
    var d = dd.getDate() < 10 ? "0" + dd.getDate() : dd.getDate().toString();; //取得目前的日前幾日，不足10補0
    return y + m + d;
}
//取得目前日期的前後N天(西元年)
function GetDateStr1(AddDayCount) {
    var dd = new Date();
    dd.setDate(dd.getDate() + AddDayCount);      //取得AddDayCount天後的日期
    var y = (dd.getYear() + 1900).toString();
    var m = (dd.getMonth() + 1) < 10 ? "0" + (dd.getMonth() + 1) : (dd.getMonth() + 1).toString();;//取得目前月份的日期，不足10補0
    var d = dd.getDate() < 10 ? "0" + dd.getDate() : dd.getDate().toString();; //取得目前的日前幾日，不足10補0
    return y + "-" + m + "-" + d;
}
//取得目前日期的前後N天(西元年)
function GetDateStr2(AddDayCount) {
    var dd = new Date();
    dd.setDate(dd.getDate() + AddDayCount);      //取得AddDayCount天後的日期
    var y = (dd.getYear() + 1900).toString();
    var m = (dd.getMonth() + 1) < 10 ? "0" + (dd.getMonth() + 1) : (dd.getMonth() + 1).toString();;//取得目前月份的日期，不足10補0
    var d = dd.getDate() < 10 ? "0" + dd.getDate() : dd.getDate().toString();; //取得目前的日前幾日，不足10補0
    return y + m + d;
}
//去除文字中的跳脫字元
function htmlEscape(str) {
    return str
        .replace(/&/g, '&amp;')
        .replace(/"/g, '&quot;')
        .replace(/'/g, '&#39;')
        .replace(/</g, '&lt;')
        .replace(/>/g, '&gt;');
}
//還原文字的跳脫字元
function htmlUnescape(str) {
    return str
        .replace(/&quot;/g, '"')
        .replace(/&#39;/g, "'")
        .replace(/&lt;/g, '<')
        .replace(/&gt;/g, '>')
        .replace(/&amp;/g, '&');
}
//轉全型
function htmlEscapeToFull(str) {
    return str
        .replace(/&/g, '＆')
        .replace(/"/g, '”')
        .replace(/'/g, '’')
        .replace(/</g, '＜')
        .replace(/>/g, '＞')
      .replace(/\+/g, '＋')
       .replace(/,/g, '，');
}
//計算天數差的函數  
function DateDiff(sDate1, sDate2) {    //sDate1和sDate2是2002-12-18格式  
    var aDate, oDate1, oDate2, iDays
    aDate = sDate1.split("-")
    oDate1 = new Date(aDate[1] + '-' + aDate[2] + '-' + aDate[0])    //轉換為12-18-2002格式  
    aDate = sDate2.split("-")
    oDate2 = new Date(aDate[1] + '-' + aDate[2] + '-' + aDate[0])
    iDays = parseInt(Math.abs(oDate1 - oDate2) / 1000 / 60 / 60 / 24)    //把相差的毫秒數轉換為天數  
    return iDays
}

function getDateTime() {
    var date = new Date();
    var hour = date.getHours();
    hour = (hour < 10 ? "0" : "") + hour;
    var min = date.getMinutes();
    min = (min < 10 ? "0" : "") + min;
    var sec = date.getSeconds();
    sec = (sec < 10 ? "0" : "") + sec;
    var year = date.getFullYear();
    var month = date.getMonth() + 1;
    month = (month < 10 ? "0" : "") + month;
    var day = date.getDate();
    day = (day < 10 ? "0" : "") + day;
    return year + "-" + month + "-" + day + " " + hour + ":" + min + ":" + sec;
}

///**
// * encrypto 加密程序
// * @param {Strng} str 待加密字符串
// * @param {Number} xor 异或值
// * @param {Number} hex 加密后的进制数
// * @return {Strng} 加密后的字符串
// */
//function encrypto(str, xor, hex) {
//    if (typeof str !== 'string' || typeof xor !== 'number' || typeof hex !== 'number') {
//        return;
//    }

//    let resultList = [];
//    hex = hex <= 25 ? hex : hex % 25;

//    for (let i = 0; i < str.length; i++) {
//        // 提取字符串每个字符的ascll码
//        let charCode = str.charCodeAt(i);
//        // 进行异或加密
//        charCode = (charCode * 1) ^ xor;
//        // 异或加密后的字符转成 hex 位数的字符串
//        charCode = charCode.toString(hex);
//        resultList.push(charCode);
//    }

//    let splitStr = String.fromCharCode(hex + 97);
//    let resultStr = resultList.join(splitStr);
//    return resultStr;
//}

///**
// * decrypto 解密程序
// * @param {Strng} str 待加密字符串
// * @param {Number} xor 异或值
// * @param {Number} hex 加密后的进制数
// * @return {Strng} 加密后的字符串
// */
//function decrypto(str, xor, hex) {
//    if (typeof str !== 'string' || typeof xor !== 'number' || typeof hex !== 'number') {
//        return;
//    }
//    let strCharList = [];
//    let resultList = [];
//    hex = hex <= 25 ? hex : hex % 25;
//    // 解析出分割字符
//    let splitStr = String.fromCharCode(hex + 97);
//    // 分割出加密字符串的加密后的每个字符
//    strCharList = str.split(splitStr);

//    for (let i = 0; i < strCharList.length; i++) {
//        // 将加密后的每个字符转成加密后的ascll码
//        let charCode = parseInt(strCharList[i], hex);
//        // 异或解密出原字符的ascll码
//        charCode = (charCode * 1) ^ xor;
//        let strChar = String.fromCharCode(charCode);
//        resultList.push(strChar);
//    }
//    let resultStr = resultList.join('');
//    return resultStr;
//}

//呈現處理中的訊息
function SystemProcess(SMessanger) {
    $.blockUI({
        message: '<i class="fa fa-spinner fa-spin"></i>&nbsp;&nbsp;<font style="font-family:Microsoft JhengHei">' + SMessanger + '</font>',
        css: {
            border: 'none',
            padding: '15px',
            backgroundColor: '#000',
            '-webkit-border-radius': '10px',
            '-moz-border-radius': '10px',
            opacity: .5,
            color: '#fff',
        }
    });
}

//顯示各類系統回傳的訊息 
function AlertMessager(IType, SMessanger,Icolor) {
    //Type 為圖示
    //1:glyphicon glyphicon-info-sign ==> ?
    //2:glyphicon glyphicon-question-sign ==> ?
    //3:glyphicon glyphicon-ok-sign  ==> 打勾
    //4:glyphicon glyphicon-remove-sign  ==> X
    //5:glyphicon glyphicon-minus-sign  ==> -
    //6:glyphicon glyphicon-plus-sign   ==> +
    var ICON = "";
    switch (IType) {
        case 1:
            ICON = "glyphicon glyphicon-info-sign";
            break;
        case 2:
            ICON = "glyphicon glyphicon-question-sign";
            break;
        case 3:
            ICON = "glyphicon glyphicon-ok-sign";
            break;
        case 4:
            ICON = "glyphicon glyphicon-remove-sign";
            break;
        case 5:
            ICON = "glyphicon glyphicon-minus-sign";
            break;
        case 6:
            ICON = "glyphicon glyphicon-plus-sign";
            break;
        default:
            ICON = "glyphicon glyphicon-info-sign";
    }

    var vColor = "";
    var vNewCss = "";
  
    switch (Icolor)
    {
        case 1:
            vNewCss = 'backgroundColor :#fff;color:#009FCC; opacity: .8';
            vColor = "#009FCC;font-size: 1.5em;";
            break;
        case  2:
            vNewCss = 'backgroundColor :#fff;color:Red; opacity: .8';
            vColor = "Red;font-size: 1.5em;";
            break;
        default:
            vNewCss = 'backgroundColor :#000;color:#fff; opacity: .5';
            vColor = "White";
    }
    $.blockUI({
        message: '<i class="' + ICON + '" style="font-size:14pt;' + vNewCss + '"></i>&nbsp;&nbsp;<font style="font-family:Microsoft JhengHei;color:' + vColor + '">' + SMessanger + '</font>',
        css: {
            border: 'none',
            padding: '15px',
           // backgroundColor: '#000',
            '-webkit-border-radius': '10px',
            '-moz-border-radius': '10px',
            //opacity: .5,
            //color: '#fff',
        }
    });
    //點選後關閉BlockUI
    $('.blockOverlay').attr('title', '點選後關閉訊息').click($.unblockUI);
}