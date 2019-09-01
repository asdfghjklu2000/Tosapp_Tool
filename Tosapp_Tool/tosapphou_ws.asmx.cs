using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Services;
using System.Data;
using Newtonsoft.Json.Linq;
using System.IO;
using System.Web.Script.Services;
using System.Web;
using Newtonsoft.Json;
using NPOI.SS.UserModel;
using NPOI.XSSF.UserModel;
using NPOI.HSSF.UserModel;
using MH;

using System.Text;
using System.Web.Script.Serialization;
using System.Text.RegularExpressions;

namespace Tosapp_Tool
{
    /// <summary>
    ///tosapphou_ws 的摘要描述
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // 若要允許使用 ASP.NET AJAX 從指令碼呼叫此 Web 服務，請取消註解下列一行。
    [System.Web.Script.Services.ScriptService]
    public class tosapphou_ws : System.Web.Services.WebService
    {
        public string[,] dict_boss_skill;
        public Dictionary<string, string> dic_boss_skill = new Dictionary<string, string>();
        public Dictionary<string, string> dict_locale_csv = new Dictionary<string, string>();
        public Dictionary<string, string> dict_locale_csv_eng = new Dictionary<string, string>();
        public Dictionary<string, Monster> dic_monster_data = new Dictionary<string, Monster>();
        JavaScriptSerializer serializer = new JavaScriptSerializer();
        public static byte[] ReadFile(string filePath)
        {
            byte[] buffer;
            FileStream fileStream = new FileStream(filePath, FileMode.Open, FileAccess.Read);
            try
            {
                int length = (int)fileStream.Length;  // get file length
                buffer = new byte[length];            // create buffer
                int count;                            // actual number of bytes read
                int sum = 0;                          // total number of bytes read

                // read until Read method returns 0 (end of the stream has been reached)
                while ((count = fileStream.Read(buffer, sum, length - sum)) > 0)
                    sum += count;  // sum is a buffer offset for next reading
            }
            finally
            {
                fileStream.Close();
            }
            return buffer;
        }
        protected void loadMonsterData2()
        {
            DataTable dt_monster;
            Monster M_temp;
            dt_monster = TxtConvertToDataTable("~/Monster.txt", "Monster", "|");

            for (int i = 0; i < dt_monster.Rows.Count; i++)
            {
                M_temp = new Monster();
                M_temp.MONSTER_ID = dt_monster.Rows[i][0].ToString();
                M_temp.RACIAL_TYPE = dt_monster.Rows[i][3].ToString();
                M_temp.ATTRIBUTE = dt_monster.Rows[i][4].ToString();
                M_temp.STAR = dt_monster.Rows[i][5].ToString();
                M_temp.SIZE = dt_monster.Rows[i][7].ToString();
                M_temp.MAX_LEVEL = dt_monster.Rows[i][10].ToString();
                M_temp.EXP_TYPE = dt_monster.Rows[i][11].ToString();
                M_temp.ATTACK_DURATION = dt_monster.Rows[i][12].ToString();
                M_temp.LEADER_SKILL = dt_monster.Rows[i][13].ToString();
                M_temp.NORMAL_SKILL = dt_monster.Rows[i][14].ToString();
                M_temp.BASE_MERGE_EXP = dt_monster.Rows[i][15].ToString();
                M_temp.INC_MERGE_EXP = dt_monster.Rows[i][16].ToString();
                M_temp.BASE_SELL_COIN = dt_monster.Rows[i][17].ToString();
                M_temp.INC_SELL_COIN = dt_monster.Rows[i][18].ToString();
                M_temp.MIN_LOOT_COIN = dt_monster.Rows[i][19].ToString();
                M_temp.INC_LOOT_COIN = dt_monster.Rows[i][20].ToString();
                M_temp.MIN_CARD_HP = dt_monster.Rows[i][22].ToString();
                M_temp.MAX_CARD_HP = dt_monster.Rows[i][23].ToString();
                M_temp.MIN_CARD_ATTACK = dt_monster.Rows[i][24].ToString();
                M_temp.MAX_CARD_ATTACK = dt_monster.Rows[i][25].ToString();
                M_temp.MIN_CARD_RECOVER = dt_monster.Rows[i][26].ToString();
                M_temp.MAX_CARD_RECOVER = dt_monster.Rows[i][27].ToString();
                M_temp.MIN_ENEMY_HP = dt_monster.Rows[i][28].ToString();
                M_temp.INC_ENEMY_HP = dt_monster.Rows[i][29].ToString();
                M_temp.MIN_ENEMY_ATTACK = dt_monster.Rows[i][30].ToString();
                M_temp.INC_ENEMY_ATTACK = dt_monster.Rows[i][31].ToString();
                M_temp.MIN_ENEMY_DEFENSE = dt_monster.Rows[i][32].ToString();
                M_temp.INC_ENEMY_DEFENSE = dt_monster.Rows[i][33].ToString();
                M_temp.EVOLVE_MONSTER_ID = dt_monster.Rows[i][34].ToString();
                M_temp.EVOLVE_MATERIAL_MONSTER_ID0 = dt_monster.Rows[i][35].ToString();
                M_temp.EVOLVE_MATERIAL_MONSTER_ID1 = dt_monster.Rows[i][36].ToString();
                M_temp.EVOLVE_MATERIAL_MONSTER_ID2 = dt_monster.Rows[i][37].ToString();
                M_temp.EVOLVE_MATERIAL_MONSTER_ID3 = dt_monster.Rows[i][38].ToString();
                M_temp.EVOLVE_MATERIAL_MONSTER_ID4 = dt_monster.Rows[i][39].ToString();
                M_temp.IS_ULTIMATE_EVOLVABLE = dt_monster.Rows[i][45].ToString();
                M_temp.NORMAL_SKILL_ID2 = dt_monster.Rows[i][47].ToString();
                M_temp.FAKE_DOUBLE_SKILL = dt_monster.Rows[i][49].ToString();
                M_temp.SUPREME_EVOLVE_ID = dt_monster.Rows[i][50].ToString();
                M_temp.SUPREME_EVOLVE_SWITCH = dt_monster.Rows[i][51].ToString();
                M_temp.SUPREME_EVOLVE_MATERIALS = dt_monster.Rows[i][52].ToString();
                M_temp.SUPREME_EVOLVE_RATE = dt_monster.Rows[i][53].ToString();
                M_temp.HP_BONUS = dt_monster.Rows[i][54].ToString();
                M_temp.ATK_BONUS = dt_monster.Rows[i][55].ToString();
                M_temp.RECOVER_BONUS = dt_monster.Rows[i][56].ToString();
                M_temp.DEVOLVE_MONSTER_ID = dt_monster.Rows[i][57].ToString();
                M_temp.MP = dt_monster.Rows[i][58].ToString();
                M_temp.MP_CHARGE_TYPE = dt_monster.Rows[i][59].ToString();

                dic_monster_data.Add(dt_monster.Rows[i][0].ToString(), M_temp);
            }
        }

        protected DataTable TxtConvertToDataTable(string File, string TableName, string delimiter)
        {
            DataTable dt = new DataTable();
            DataSet ds = new DataSet();
            StreamReader s = new StreamReader(Server.MapPath(File), System.Text.Encoding.UTF8);
            //string ss = s.ReadLine();//skip the first line
            string[] columns = s.ReadLine().Split(delimiter.ToCharArray());
            ds.Tables.Add(TableName);
            foreach (string col in columns)
            {
                bool added = false;
                string next = "";
                int i = 0;
                while (!added)
                {
                    string columnname = col + next;
                    columnname = columnname.Replace("#", "");
                    columnname = columnname.Replace("'", "");
                    columnname = columnname.Replace("&", "");

                    if (!ds.Tables[TableName].Columns.Contains(columnname))
                    {
                        ds.Tables[TableName].Columns.Add(columnname.ToUpper());
                        added = true;
                    }
                    else
                    {
                        i++;
                        next = "_" + i.ToString();
                    }
                }
            }

            string AllData = s.ReadToEnd();
            string[] rows = AllData.Split("\n".ToCharArray());

            foreach (string r in rows)
            {
                if (r.Trim() != "")
                {
                    string[] items = r.Split(delimiter.ToCharArray());
                    ds.Tables[TableName].Rows.Add(items);
                }
            }

            s.Close();
            s.Dispose();

            dt = ds.Tables[0];

            return dt;
        }

        protected void loadLocaleCsv2()
        {
            MCSVFile m = new MCSVFile();
            m.LoadBinaryAsset(ReadFile(Server.MapPath("~/LOCALE.csv.txt")));

            Dictionary<string, string> TipsManager = new Dictionary<string, string>();

            //m.NumRow()為所有字串的總數
            int num = m.NumRow();
            //宣告一個陣列用來接MCSVFile破解出來的字串
            string[,] dict = new string[num, 3];

            //用來接
            string text = string.Empty;
            string text1 = string.Empty;
            string text2 = string.Empty;

            int num2 = 0;
            for (int i = 0; i < num - 1; i++)
            {
                text = string.Empty;
                text1 = string.Empty;
                text2 = string.Empty;
                if (!string.IsNullOrEmpty(m.GetString(i, 0, string.Empty)))
                {
                    //m.GetString(i, 0, string.Empty)是字串的KEY值
                    text = m.GetString(i, 0, string.Empty);
                    //m.GetString(i, 0, string.Empty)是字串的英文描述
                    text1 = m.GetString(i, 1, string.Empty);
                    //m.GetString(i, 0, string.Empty)是字串的中文描述
                    text2 = m.GetString(i, 2, string.Empty);
                    try
                    {
                        //寫到陣列去
                        dict[i, 0] = text;
                        dict[i, 1] = text1;
                        dict[i, 2] = text2;

                        dict_locale_csv.Add(text, text2);
                        dict_locale_csv_eng.Add(text, text1);
                    }
                    catch (Exception var_8_9E)
                    {
                        //Watchdog.LogError("[SimpleLocale] (Duplicated Translation Label) Key: " + text + " Msg: " + text2);
                    }
                    string[] array = text.Split(new char[] { '_' });
                    if (array.Length == 2 && text.StartsWith("TIP_") && int.TryParse(array[1], out num2))
                    {
                        TipsManager.Add(text, text2);
                    }
                }
            }
        }

        protected string readLocaleValue(string key, bool isZh)
        {
            try
            {
                if (isZh)
                {
                    return dict_locale_csv[key];
                }
                else
                {
                    return dict_locale_csv_eng[key];
                }
            }
            catch (Exception e)
            {
                if (isZh)
                    return "無此字串";
                else
                    return "Can't Find Value";
            }
        }

        protected void loadBossSkill2()
        {
            DataTable dt_bossskill;
            dt_bossskill = TxtConvertToDataTable("~/BossSkill.txt", "BossSkill", "|");

            dict_boss_skill = new string[4000, 2];
            dict_boss_skill[0, 0] = "沒有技能"; //名稱
            dict_boss_skill[0, 1] = ""; //圖片


            string text = string.Empty;
            string text1 = string.Empty;
            string text2 = string.Empty;

            string[] skill_pic;

            for (int i = 0; i < dt_bossskill.Rows.Count; i++)
            {
                text = dt_bossskill.Rows[i][0].ToString();
                text1 = dt_bossskill.Rows[i][1].ToString();
                text2 = dt_bossskill.Rows[i][2].ToString();


                skill_pic = text2.Split(new string[] { "SI" }, StringSplitOptions.None);
                text2 = "";

                for (int j = 1; j < skill_pic.Count(); j++)
                {
                    text2 += "<img width=\"20\" height=\"20\" src=\"http://www.tosapp.tw/static/image/common/tos/mskill" + skill_pic[j] + ".png\"\\> ";
                }

                dict_boss_skill[Int32.Parse(text), 0] = text1;
                dict_boss_skill[Int32.Parse(text), 1] = text2;
            }
        }

        [WebMethod]
        public string getZone()
        {
            string HtmlStr = "";
            try
            {
                loadLocaleCsv2();
                var qry_locale = from dr in dict_locale_csv
                                 where dr.Key.StartsWith("ZONE_") && dr.Value.Trim() != ""
                                 select dr;
                foreach (KeyValuePair<string, string> kp in qry_locale)
                {
                    HtmlStr += "<fieldset>";
                    HtmlStr += "<legend style=\"cursor: pointer\" onclick=\"isHidden('div_zone_" + kp.Key.Replace("ZONE_", "") + "')\">";
                    HtmlStr += "<font color=\"4CAF50\" size=\"5\"><b>" + kp.Value + "</b></font>";
                    HtmlStr += "<span style='float:right; display:block;' id='div_zone_" + kp.Key.Replace("ZONE_", "") + "_1'>∨&nbsp</span>";
                    HtmlStr += "<span style='float:right; display:none;' id='div_zone_" + kp.Key.Replace("ZONE_", "") + "_2'>∧&nbsp</span>";
                    HtmlStr += "</legend>";
                    HtmlStr += "<div style='display:none;' id='div_zone_" + kp.Key.Replace("ZONE_", "") + "'>";
                    HtmlStr += "</div></fieldset>";
                }
            }
            catch (Exception e)
            {
                HtmlStr = "Exception: " + e.Message.ToString();
            }
            Encoding enc = Encoding.UTF8;

            return Convert.ToBase64String(enc.GetBytes(HtmlStr));
        }

        [WebMethod]
        public string getStageDetail(string zone)
        {
            string HtmlStr = "";
            try
            {
                DataTable dt_stageList, dt_floorList, dt_floorStars, dt_floorStarRewards;
                dt_stageList = TxtConvertToDataTable("~/stageList.txt", "stageList", "|");
                dt_floorList = TxtConvertToDataTable("~/floorList.txt", "stageList", "|");
                dt_floorStars = TxtConvertToDataTable("~/floorStars.txt", "stageList", "|");
                dt_floorStarRewards = TxtConvertToDataTable("~/floorStarRewards.txt", "stageList", "|");
                System.DateTime startTime = TimeZone.CurrentTimeZone.ToUniversalTime(new System.DateTime(1970, 1, 1)); // 当地时区
                var qry_stage = from dr in dt_stageList.AsEnumerable()
                                where dr.Field<string>("col_4") == zone && dr.Field<string>("col_21") == "0"
                                select dr;


                foreach (DataRow dr_stage in qry_stage)
                {
                    //Context.Response.Output.Write(dr["col_1"].ToString());
                    HtmlStr += "<fieldset>";
                    HtmlStr += "<legend style=\"cursor: pointer\" onclick=\"isHidden('div_part_" + dr_stage["col_1"].ToString() + "')\">";
                    HtmlStr += "<font color=\"3366FF\" size=\"4\"><b>" + dr_stage["col_10"].ToString() + "</b></font>";

                    HtmlStr += dr_stage["col_8"].ToString() == "" ? "" : ("&nbsp(開放時間： " + startTime.AddSeconds(Int32.Parse(dr_stage["col_8"].ToString())).ToString("yyyy/MM/dd HH:mm:ss") + " ~ " + startTime.AddSeconds(Int32.Parse(dr_stage["col_9"].ToString()) - 1).ToString("yyyy/MM/dd HH:mm:ss") + " )");
                    HtmlStr += "<span style='float:right; display:none;' id='div_part_" + dr_stage["col_1"].ToString() + "_1'>✚&nbsp</span>";
                    HtmlStr += "<span style='float:right; display:block;' id='div_part_" + dr_stage["col_1"].ToString() + "_2'>━&nbsp</span>";
                    HtmlStr += "</legend>";
                    HtmlStr += "<div style='display:block;' id='div_part_" + dr_stage["col_1"].ToString() + "'>";
                    HtmlStr += "→<a href=\"https://tos.fandom.com/zh/wiki/" + dr_stage["col_10"].ToString().Replace(' ', '_') + "\" target=\"blank\">維基關卡資訊</a><br>";

                    var qry_floor = from c in dt_floorList.AsEnumerable()
                                    join o in dt_floorStars.AsEnumerable() on c.Field<string>("col_1") equals o.Field<string>("col_1") into ps
                                    from o in ps.DefaultIfEmpty()
                                    where c.Field<string>("col_2") == dr_stage["col_1"].ToString()
                                    select new
                                    {
                                        floorId = c.Field<string>("col_1"),
                                        floorIcon = c.Field<string>("col_4"),
                                        floorName = c.Field<string>("col_8"),
                                        floorStam = c.Field<string>("col_5"),
                                        floorSpirit = c.Field<string>("col_29"),
                                        floorRound = c.Field<string>("col_6"),
                                        floorStar1 = o == null ? "" : o.Field<string>("col_2"),
                                        floorStar2 = o == null ? "" : o.Field<string>("col_3"),
                                        floorStar3 = o == null ? "" : o.Field<string>("col_4")
                                    };

                    foreach (var dr_floor in qry_floor)
                    {
                        HtmlStr += "【<a href=\"http://www.tosapp.tw/tos/no." + dr_floor.floorIcon + ".html\" target=\"blank\">" + dr_floor.floorIcon + "</a>】";
                        HtmlStr += "<img width=\"40\" height=\"40\" src=\"https://asdfghjklu2000.github.io/Tosapp_Tool/px100/" + dr_floor.floorIcon + ".png\">";
                        HtmlStr += "&nbsp";
                        HtmlStr += dr_floor.floorName;
                        HtmlStr += "<br>";
                        HtmlStr += "　體力： " + (dr_floor.floorStam != "0" ? dr_floor.floorStam : (dr_floor.floorSpirit != "0" ? (dr_floor.floorSpirit + " 戰靈") : "0"));
                        HtmlStr += "；戰鬥： " + dr_floor.floorRound;
                        if (dr_floor.floorStar1 != "")
                        {
                            HtmlStr += "<br>★ 成就";
                            HtmlStr += "<br>☆ ";
                            HtmlStr += dr_floor.floorStar1;
                            HtmlStr += "<br>☆ ";
                            HtmlStr += dr_floor.floorStar2;
                            HtmlStr += "<br>☆ ";
                            HtmlStr += dr_floor.floorStar3;
                        }
                        HtmlStr += "<br>";
                    }

                    var qry_starReward = from dr in dt_floorStarRewards.AsEnumerable()
                                         where dr.Field<string>("col_2") == dr_stage["col_1"].ToString()
                                         select dr;
                    if (qry_starReward.Count() > 0)
                        HtmlStr += "<br>✪ 成就獎勵";
                    foreach (DataRow dr_star in qry_starReward)
                    {
                        HtmlStr += "<br>";
                        HtmlStr += dr_star["col_3"].ToString();
                    }
                    //HtmlStr += "</li>";
                    HtmlStr += "<br>";

                    //HtmlStr += "</ul>";
                    HtmlStr += "</div></fieldset>";
                }
            }
            catch (Exception e)
            {
                HtmlStr = "Exception: " + e.Message.ToString();
            }
            Encoding enc = Encoding.UTF8;

            return Convert.ToBase64String(enc.GetBytes(HtmlStr));
        }

        [WebMethod]
        public string getStageDetailEn(string zone)
        {
            string HtmlStr = "";
            try
            {
                DataTable dt_stageList, dt_floorList, dt_floorStars, dt_floorStarRewards;
                dt_stageList = TxtConvertToDataTable("~/stageList_en.txt", "stageList", "|");
                dt_floorList = TxtConvertToDataTable("~/floorList_en.txt", "stageList", "|");
                dt_floorStars = TxtConvertToDataTable("~/floorStars_en.txt", "stageList", "|");
                dt_floorStarRewards = TxtConvertToDataTable("~/floorStarRewards_en.txt", "stageList", "|");

                var qry_stage = from dr in dt_stageList.AsEnumerable()
                                where dr.Field<string>("col_4") == zone
                                select dr;
                foreach (DataRow dr_stage in qry_stage)
                {
                    //Context.Response.Output.Write(dr["col_1"].ToString());
                    HtmlStr += "<fieldset>";
                    HtmlStr += "<legend style=\"cursor: pointer\" onclick=\"isHidden('div_part_" + dr_stage["col_1"].ToString() + "')\">";
                    HtmlStr += "<font color=\"3366FF\" size=\"4\"><b>" + dr_stage["col_10"].ToString() + "</b></font>";

                    System.DateTime startTime = TimeZone.CurrentTimeZone.ToUniversalTime(new System.DateTime(1970, 1, 1)); // 当地时区

                    HtmlStr += dr_stage["col_8"].ToString() == "" ? "" : ("&nbsp(開放時間： " + startTime.AddSeconds(Int32.Parse(dr_stage["col_8"].ToString())).ToString("yyyy/MM/dd HH:mm:ss") + " ~ " + startTime.AddSeconds(Int32.Parse(dr_stage["col_9"].ToString()) - 1).ToString("yyyy/MM/dd HH:mm:ss") + " )");
                    HtmlStr += "<span style='float:right; display:none;' id='div_part_" + dr_stage["col_1"].ToString() + "_1'>✚&nbsp</span>";
                    HtmlStr += "<span style='float:right; display:block;' id='div_part_" + dr_stage["col_1"].ToString() + "_2'>━&nbsp</span>";
                    HtmlStr += "</legend>";
                    HtmlStr += "<div style='display:block;' id='div_part_" + dr_stage["col_1"].ToString() + "'>";
                    HtmlStr += "→<a href=\"https://towerofsaviors.fandom.com/wiki/" + dr_stage["col_10"].ToString().Replace(' ', '_') + "\" target=\"blank\">美版維基關卡資訊</a><br>";
                    //HtmlStr += "<ul>";

                    var qry_floor = from dr in dt_floorList.AsEnumerable()
                                    where dr.Field<string>("col_2") == dr_stage["col_1"].ToString()
                                    select dr;

                    foreach (DataRow dr_floor in qry_floor)
                    {
                        //HtmlStr += "<li>";
                        HtmlStr += "【<a href=\"http://www.tosapp.tw/tos/no." + dr_floor["col_4"].ToString() + ".html\" target=\"blank\">" + dr_floor["col_4"].ToString() + "</a>】";
                        HtmlStr += "<img width=\"40\" height=\"40\" src=\"https://asdfghjklu2000.github.io/Tosapp_Tool/px100/" + dr_floor["col_4"].ToString() + ".png\">";
                        HtmlStr += "&nbsp";
                        HtmlStr += dr_floor["col_8"].ToString();
                        HtmlStr += "<br>";
                        HtmlStr += "　體力： " + (dr_floor["col_5"].ToString() != "0" ? dr_floor["col_5"].ToString() : (dr_floor["col_29"].ToString() != "0" ? (dr_floor["col_29"].ToString() + " 戰靈") : "0"));
                        HtmlStr += "；戰鬥： " + dr_floor["col_6"].ToString();
                        var qry_star = from dr in dt_floorStars.AsEnumerable()
                                       where dr.Field<string>("col_1") == dr_floor["col_1"].ToString()
                                       select dr;
                        if (qry_star.Count() > 0)
                            HtmlStr += "<br>★ 成就";
                        foreach (DataRow dr_star in qry_star)
                        {
                            HtmlStr += "<br>☆ ";
                            HtmlStr += dr_star["col_2"].ToString();
                            HtmlStr += "<br>☆ ";
                            HtmlStr += dr_star["col_3"].ToString();
                            HtmlStr += "<br>☆ ";
                            HtmlStr += dr_star["col_4"].ToString();
                        }
                        //HtmlStr += "</li>";
                        HtmlStr += "<br>";
                    }

                    var qry_starReward = from dr in dt_floorStarRewards.AsEnumerable()
                                         where dr.Field<string>("col_2") == dr_stage["col_1"].ToString()
                                         select dr;
                    if (qry_starReward.Count() > 0)
                        HtmlStr += "<br>✪ 成就獎勵";
                    foreach (DataRow dr_star in qry_starReward)
                    {
                        HtmlStr += "<br>";
                        HtmlStr += dr_star["col_3"].ToString();
                    }
                    //HtmlStr += "</li>";
                    HtmlStr += "<br>";

                    //HtmlStr += "</ul>";
                    HtmlStr += "</div></fieldset>";
                }
            }
            catch (Exception e)
            {
                HtmlStr = "Exception: " + e.Message.ToString();
            }
            Encoding enc = Encoding.UTF8;

            return Convert.ToBase64String(enc.GetBytes(HtmlStr));
        }

        [WebMethod]
        public string getStageDetailAll()
        {
            string HtmlStr = "";
            DataTable dt_stageList, dt_floorList, dt_floorStars, dt_floorStarRewards;
            try
            {

                dt_stageList = TxtConvertToDataTable("~/stageList.txt", "stageList", "|");
                dt_floorList = TxtConvertToDataTable("~/floorList.txt", "stageList", "|");
                dt_floorStars = TxtConvertToDataTable("~/floorStars.txt", "stageList", "|");
                dt_floorStarRewards = TxtConvertToDataTable("~/floorStarRewards.txt", "stageList", "|");
                loadLocaleCsv2();
                var qry_locale = from dr in dict_locale_csv
                                 where dr.Key.StartsWith("ZONE_") && dr.Value.Trim() != ""
                                 select dr;
                foreach (KeyValuePair<string, string> kp in qry_locale)
                {
                    HtmlStr += "<fieldset>";
                    HtmlStr += "<legend style=\"cursor: pointer\" onclick=\"isHidden('div_zone_" + kp.Key.Replace("ZONE_", "") + "')\">";
                    HtmlStr += "<font color=\"4CAF50\" size=\"5\"><b>" + kp.Value + "</b></font>";
                    HtmlStr += "<span style='float:right; display:block;' id='div_zone_" + kp.Key.Replace("ZONE_", "") + "_1'>∨&nbsp</span>";
                    HtmlStr += "<span style='float:right; display:none;' id='div_zone_" + kp.Key.Replace("ZONE_", "") + "_2'>∧&nbsp</span>";
                    HtmlStr += "</legend>";
                    HtmlStr += "<div style='display:none;' id='div_zone_" + kp.Key.Replace("ZONE_", "") + "'>";

                    System.DateTime startTime = TimeZone.CurrentTimeZone.ToUniversalTime(new System.DateTime(1970, 1, 1)); // 当地时区
                    var qry_stage = from dr in dt_stageList.AsEnumerable()
                                    where dr.Field<string>("col_4") == kp.Key.Replace("ZONE_", "")
                                    select dr;


                    foreach (DataRow dr_stage in qry_stage)
                    {
                        //Context.Response.Output.Write(dr["col_1"].ToString());
                        HtmlStr += "<fieldset>";
                        HtmlStr += "<legend style=\"cursor: pointer\" onclick=\"isHidden('div_part_" + dr_stage["col_1"].ToString() + "')\">";
                        HtmlStr += "<font color=\"3366FF\" size=\"4\"><b>" + dr_stage["col_10"].ToString() + "</b></font>";

                        HtmlStr += dr_stage["col_8"].ToString() == "" ? "" : ("&nbsp(開放時間： " + startTime.AddSeconds(Int32.Parse(dr_stage["col_8"].ToString())).ToString("yyyy/MM/dd HH:mm:ss") + " ~ " + startTime.AddSeconds(Int32.Parse(dr_stage["col_9"].ToString()) - 1).ToString("yyyy/MM/dd HH:mm:ss") + " )");
                        HtmlStr += "<span style='float:right; display:none;' id='div_part_" + dr_stage["col_1"].ToString() + "_1'>✚&nbsp</span>";
                        HtmlStr += "<span style='float:right; display:block;' id='div_part_" + dr_stage["col_1"].ToString() + "_2'>━&nbsp</span>";
                        HtmlStr += "</legend>";
                        HtmlStr += "<div style='display:block;' id='div_part_" + dr_stage["col_1"].ToString() + "'>";
                        HtmlStr += "→<a href=\"https://tos.fandom.com/zh/wiki/" + dr_stage["col_10"].ToString().Replace(' ', '_') + "\" target=\"blank\">維基關卡資訊</a><br>";

                        var qry_floor = from c in dt_floorList.AsEnumerable()
                                        join o in dt_floorStars.AsEnumerable() on c.Field<string>("col_1") equals o.Field<string>("col_1") into ps
                                        from o in ps.DefaultIfEmpty()
                                        where c.Field<string>("col_2") == dr_stage["col_1"].ToString()
                                        select new
                                        {
                                            floorId = c.Field<string>("col_1"),
                                            floorIcon = c.Field<string>("col_4"),
                                            floorName = c.Field<string>("col_8"),
                                            floorStam = c.Field<string>("col_5"),
                                            floorSpirit = c.Field<string>("col_29"),
                                            floorRound = c.Field<string>("col_6"),
                                            floorStar1 = o == null ? "" : o.Field<string>("col_2"),
                                            floorStar2 = o == null ? "" : o.Field<string>("col_3"),
                                            floorStar3 = o == null ? "" : o.Field<string>("col_4")
                                        };

                        foreach (var dr_floor in qry_floor)
                        {
                            HtmlStr += "【<a href=\"http://www.tosapp.tw/tos/no." + dr_floor.floorIcon + ".html\" target=\"blank\">" + dr_floor.floorIcon + "</a>】";
                            HtmlStr += "<img width=\"40\" height=\"40\" src=\"https://asdfghjklu2000.github.io/Tosapp_Tool/px100/" + dr_floor.floorIcon + ".png\">";
                            HtmlStr += "&nbsp";
                            HtmlStr += dr_floor.floorName;
                            HtmlStr += "<br>";
                            HtmlStr += "　體力： " + (dr_floor.floorStam != "0" ? dr_floor.floorStam : (dr_floor.floorSpirit != "0" ? (dr_floor.floorSpirit + " 戰靈") : "0"));
                            HtmlStr += "；戰鬥： " + dr_floor.floorRound;
                            if (dr_floor.floorStar1 != "")
                            {
                                HtmlStr += "<br>★ 成就";
                                HtmlStr += "<br>☆ ";
                                HtmlStr += dr_floor.floorStar1;
                                HtmlStr += "<br>☆ ";
                                HtmlStr += dr_floor.floorStar2;
                                HtmlStr += "<br>☆ ";
                                HtmlStr += dr_floor.floorStar3;
                            }
                            HtmlStr += "<br>";
                        }

                        var qry_starReward = from dr in dt_floorStarRewards.AsEnumerable()
                                             where dr.Field<string>("col_2") == dr_stage["col_1"].ToString()
                                             select dr;
                        if (qry_starReward.Count() > 0)
                            HtmlStr += "<br>✪ 成就獎勵";
                        foreach (DataRow dr_star in qry_starReward)
                        {
                            HtmlStr += "<br>";
                            HtmlStr += dr_star["col_3"].ToString();
                        }
                        HtmlStr += "<br>";
                        HtmlStr += "</div></fieldset>";
                    }
                    HtmlStr += "</div></fieldset>";
                }
            }
            catch (Exception e)
            {
                HtmlStr = "Exception: " + e.Message.ToString();
            }

            return HtmlStr;
        }

        [WebMethod]
        public string getStageDetailAllEn()
        {
            string HtmlStr = "";
            DataTable dt_stageList, dt_floorList, dt_floorStars, dt_floorStarRewards;
            try
            {

                dt_stageList = TxtConvertToDataTable("~/stageList_en.txt", "stageList", "|");
                dt_floorList = TxtConvertToDataTable("~/floorList_en.txt", "stageList", "|");
                dt_floorStars = TxtConvertToDataTable("~/floorStars_en.txt", "stageList", "|");
                dt_floorStarRewards = TxtConvertToDataTable("~/floorStarRewards_en.txt", "stageList", "|");
                loadLocaleCsv2();
                var qry_locale = from dr in dict_locale_csv
                                 where dr.Key.StartsWith("ZONE_") && dr.Value.Trim() != ""
                                 select dr;
                foreach (KeyValuePair<string, string> kp in qry_locale)
                {
                    HtmlStr += "<fieldset>";
                    HtmlStr += "<legend style=\"cursor: pointer\" onclick=\"isHidden('div_zone_" + kp.Key.Replace("ZONE_", "") + "')\">";
                    HtmlStr += "<font color=\"4CAF50\" size=\"5\"><b>" + kp.Value + "</b></font>";
                    HtmlStr += "<span style='float:right; display:block;' id='div_zone_" + kp.Key.Replace("ZONE_", "") + "_1'>∨&nbsp</span>";
                    HtmlStr += "<span style='float:right; display:none;' id='div_zone_" + kp.Key.Replace("ZONE_", "") + "_2'>∧&nbsp</span>";
                    HtmlStr += "</legend>";
                    HtmlStr += "<div style='display:none;' id='div_zone_" + kp.Key.Replace("ZONE_", "") + "'>";

                    System.DateTime startTime = TimeZone.CurrentTimeZone.ToUniversalTime(new System.DateTime(1970, 1, 1)); // 当地时区
                    var qry_stage = from dr in dt_stageList.AsEnumerable()
                                    where dr.Field<string>("col_4") == kp.Key.Replace("ZONE_", "")
                                    select dr;


                    foreach (DataRow dr_stage in qry_stage)
                    {
                        //Context.Response.Output.Write(dr["col_1"].ToString());
                        HtmlStr += "<fieldset>";
                        HtmlStr += "<legend style=\"cursor: pointer\" onclick=\"isHidden('div_part_" + dr_stage["col_1"].ToString() + "')\">";
                        HtmlStr += "<font color=\"3366FF\" size=\"4\"><b>" + dr_stage["col_10"].ToString() + "</b></font>";

                        HtmlStr += dr_stage["col_8"].ToString() == "" ? "" : ("&nbsp(開放時間： " + startTime.AddSeconds(Int32.Parse(dr_stage["col_8"].ToString())).ToString("yyyy/MM/dd HH:mm:ss") + " ~ " + startTime.AddSeconds(Int32.Parse(dr_stage["col_9"].ToString()) - 1).ToString("yyyy/MM/dd HH:mm:ss") + " )");
                        HtmlStr += "<span style='float:right; display:none;' id='div_part_" + dr_stage["col_1"].ToString() + "_1'>✚&nbsp</span>";
                        HtmlStr += "<span style='float:right; display:block;' id='div_part_" + dr_stage["col_1"].ToString() + "_2'>━&nbsp</span>";
                        HtmlStr += "</legend>";
                        HtmlStr += "<div style='display:block;' id='div_part_" + dr_stage["col_1"].ToString() + "'>";
                        HtmlStr += "→<a href=\"https://tos.fandom.com/zh/wiki/" + dr_stage["col_10"].ToString().Replace(' ', '_') + "\" target=\"blank\">維基關卡資訊</a><br>";

                        var qry_floor = from c in dt_floorList.AsEnumerable()
                                        join o in dt_floorStars.AsEnumerable() on c.Field<string>("col_1") equals o.Field<string>("col_1") into ps
                                        from o in ps.DefaultIfEmpty()
                                        where c.Field<string>("col_2") == dr_stage["col_1"].ToString()
                                        select new
                                        {
                                            floorId = c.Field<string>("col_1"),
                                            floorIcon = c.Field<string>("col_4"),
                                            floorName = c.Field<string>("col_8"),
                                            floorStam = c.Field<string>("col_5"),
                                            floorSpirit = c.Field<string>("col_29"),
                                            floorRound = c.Field<string>("col_6"),
                                            floorStar1 = o == null ? "" : o.Field<string>("col_2"),
                                            floorStar2 = o == null ? "" : o.Field<string>("col_3"),
                                            floorStar3 = o == null ? "" : o.Field<string>("col_4")
                                        };

                        foreach (var dr_floor in qry_floor)
                        {
                            HtmlStr += "【<a href=\"http://www.tosapp.tw/tos/no." + dr_floor.floorIcon + ".html\" target=\"blank\">" + dr_floor.floorIcon + "</a>】";
                            HtmlStr += "<img width=\"40\" height=\"40\" src=\"https://asdfghjklu2000.github.io/Tosapp_Tool/px100/" + dr_floor.floorIcon + ".png\">";
                            HtmlStr += "&nbsp";
                            HtmlStr += dr_floor.floorName;
                            HtmlStr += "<br>";
                            HtmlStr += "　體力： " + (dr_floor.floorStam != "0" ? dr_floor.floorStam : (dr_floor.floorSpirit != "0" ? (dr_floor.floorSpirit + " 戰靈") : "0"));
                            HtmlStr += "；戰鬥： " + dr_floor.floorRound;
                            if (dr_floor.floorStar1 != "")
                            {
                                HtmlStr += "<br>★ 成就";
                                HtmlStr += "<br>☆ ";
                                HtmlStr += dr_floor.floorStar1;
                                HtmlStr += "<br>☆ ";
                                HtmlStr += dr_floor.floorStar2;
                                HtmlStr += "<br>☆ ";
                                HtmlStr += dr_floor.floorStar3;
                            }
                            HtmlStr += "<br>";
                        }

                        var qry_starReward = from dr in dt_floorStarRewards.AsEnumerable()
                                             where dr.Field<string>("col_2") == dr_stage["col_1"].ToString()
                                             select dr;
                        if (qry_starReward.Count() > 0)
                            HtmlStr += "<br>✪ 成就獎勵";
                        foreach (DataRow dr_star in qry_starReward)
                        {
                            HtmlStr += "<br>";
                            HtmlStr += dr_star["col_3"].ToString();
                        }
                        HtmlStr += "<br>";
                        HtmlStr += "</div></fieldset>";
                    }
                    HtmlStr += "</div></fieldset>";
                }
            }
            catch (Exception e)
            {
                HtmlStr = "Exception: " + e.Message.ToString();
            }

            return HtmlStr;
        }

        protected List<WaveBasic> getFloorData(string floor_json)
        {
            JObject jo_all, jo_data, jo_waves, jo_enemies;
            JArray ja_waves, ja_enemies;
            jo_all = JObject.Parse(floor_json);
            jo_data = JObject.Parse(jo_all.GetValue("data").ToString());
            ja_waves = JArray.Parse(jo_data.GetValue("waves").ToString());

            //JObject jo_waves;
            //JArray ja_enemies;
            //JObject jo_enemies;

            int wavedetialid = 0;
            int checkNextEnemy = 0;
            string multiblood_flag = "";
            string enemyHtml = "";

            //WaveBasic包含一個wave所有資訊；以List來串接所有wave
            List<WaveBasic> wbl = new List<WaveBasic>();
            WaveBasic temp_wb;

            //最外層：wave的陣列，分離出每一wave
            for (int i = 0; i < ja_waves.Count; i++)
            {
                //temp_wb為當前wave的物件，temp_wb.WaveDetailList為這個層所出現的每位敵人資訊集合
                temp_wb = new WaveBasic();
                temp_wb.WaveId = (i + 1).ToString();
                List<WaveDetail> temp_wdl = new List<WaveDetail>();
                wavedetialid = 0;

                jo_waves = JObject.Parse(ja_waves[i].ToString());
                ja_enemies = JArray.Parse(jo_waves.GetValue("enemies").ToString());

                //記錄當層的虛影特性/場景特性
                temp_wb.WaveSkill = jo_waves.GetValue("waveSkillId") != null ? jo_waves.GetValue("waveSkillId").ToString() : "0";

                //skillList為空時，代表不為多階段魔王(爆衣魔王)，for 一般敵人(含多血怪處理方式)
                if ((JObject.Parse(ja_enemies[0].ToString())).GetValue("skillList").ToString() == "[]")
                {
                    //內層：敵人的陣列，對於每一層wave內的所有敵人進行提取資訊
                    for (int j = 0; j < ja_enemies.Count; j++)
                    {
                        jo_enemies = JObject.Parse(ja_enemies[j].ToString());

                        //用來判斷是否有多血/變身怪
                        checkNextEnemy = 0;
                        multiblood_flag = "X";
                        //getEnemyObj
                        getEnemyObj(jo_enemies, ref wavedetialid, ref checkNextEnemy, ref multiblood_flag, ref temp_wdl);
                    }
                    temp_wb.WaveDetailList = temp_wdl;
                    wbl.Add(temp_wb);
                }
                //多階段魔王(像是吉爾伽美什)
                else
                {
                    int skillListCnt = JArray.Parse((JObject.Parse(ja_enemies[0].ToString())).GetValue("skillList").ToString()).Count();
                    for (int s = 0; s < skillListCnt; s++)
                    {
                        temp_wb = new WaveBasic();
                        temp_wb.WaveId = (i + 1).ToString() + "-" + (s + 1).ToString();
                        temp_wb.WaveSkill = jo_waves.GetValue("waveSkillId") != null ? jo_waves.GetValue("waveSkillId").ToString() : "0";
                        temp_wdl = new List<WaveDetail>();
                        wavedetialid = 0;

                        //for 本體+左右怪處理方式
                        for (int j = 0; j < ja_enemies.Count; j++)
                        {
                            string new_char = "";
                            //int no_show_cnt = 0;

                            jo_enemies = JObject.Parse(ja_enemies[j].ToString());
                            new_char = JArray.Parse(jo_enemies.GetValue("skillList").ToString())[skillListCnt - 1 - s].ToString();

                            jo_enemies.Remove("characteristic");
                            jo_enemies.Add("characteristic", new_char);

                            checkNextEnemy = 0;
                            multiblood_flag = "X";

                            if (new_char != "0")
                            {
                                getEnemyObj(jo_enemies, ref wavedetialid, ref checkNextEnemy, ref multiblood_flag, ref temp_wdl);
                            }
                        }
                        temp_wb.WaveDetailList = temp_wdl;
                        wbl.Add(temp_wb);
                    }
                }
            }
            return wbl;
        }

        protected List<WaveBasic> getFloorDataByWikiaCode(string wikia_code)
        {
            string[] wikialine = wikia_code.Split('\n');
            //WaveBasic包含一個wave所有資訊；以List來串接所有wave
            List<WaveBasic> wbl = new List<WaveBasic>();
            WaveBasic temp_wb = new WaveBasic();
            List<WaveDetail> temp_wdl = new List<WaveDetail>();
            WaveDetail temp_wd = new WaveDetail();

            Match match;
            string templine = "";
            string stage = "";
            temp_wb.WaveId = "";
            int wavecount = 0;
            string multiBlookFlag = "X";
            foreach (string line in wikialine)
            {
                if (line.Contains("{{關卡數據|"))
                {
                    //前置作業，先把參數中的小模版替換成一般參數型態
                    templine = line;
                    templine = Regex.Replace(templine, @"\{\{[雙三]血\}\}", "|MultiB=N");
                    templine = Regex.Replace(templine, @"\{\{前置\}\}", "|MultiB=C");
                    templine = Regex.Replace(templine, @"\{\{初始CD\|(\d*)\}\}", delegate (Match tmpMatch)
                    {
                        string v = tmpMatch.Groups[1].Value;
                        return "|IniCD=" + v;
                    });

                    //1.設定層數
                    match = Regex.Match(templine, @"stage\=([^\|\{\}]*)");
                    if ((match.Success))
                    {
                        if ((match.Groups[1].Value != "") && (match.Groups[1].Value != stage))
                        {
                            //如果上一組WaveBasic是有成員的，就塞入wbl
                            if (temp_wdl.Count > 0)
                            {
                                temp_wb.WaveDetailList = temp_wdl;
                                wbl.Add(temp_wb);
                            }

                            temp_wb = new WaveBasic();
                            temp_wb.WaveId = match.Groups[1].Value;
                            temp_wdl = new List<WaveDetail>();
                            wavecount = 0;
                            multiBlookFlag = "X";
                            stage = temp_wb.WaveId;
                        }
                    }
                    //無層數就自成一層
                    else
                    {
                        //如果上一組WaveBasic是有成員的，就塞入wbl
                        if (temp_wdl.Count > 0)
                        {
                            temp_wb.WaveDetailList = temp_wdl;
                            wbl.Add(temp_wb);
                        }

                        temp_wb = new WaveBasic();
                        temp_wb.WaveId = "";
                        temp_wdl = new List<WaveDetail>();
                        wavecount = 0;
                        multiBlookFlag = "X";
                    }
                    //2.虛影技能
                    match = Regex.Match(templine, @"ws\=([^\|\{\}]*)");
                    temp_wb.WaveSkill = ((match.Success) && (match.Groups[1].Value != "")) ? match.Groups[1].Value : "0";

                    temp_wd = new WaveDetail();
                    wavecount++;
                    temp_wd.WaveDetailId = wavecount;

                    //實做

                    //3.敵人
                    match = Regex.Match(templine, @"\|(\d+)\|");
                    //先轉數字再轉回字串(因為維基會 lpad 0 )
                    temp_wd.MonsterId = ((match.Success) && (match.Groups[1].Value != "")) ? (Int32.Parse(match.Groups[1].Value)).ToString() : "0";

                    //4.攻擊
                    match = Regex.Match(templine, @"damage\=([^\|\{\}]*)");
                    temp_wd.AckNum = ((match.Success)&&(match.Groups[1].Value!="")) ? match.Groups[1].Value : "0";

                    //5.防禦
                    match = Regex.Match(templine, @"def\=([^\|\{\}]*)");
                    temp_wd.DefNum = ((match.Success) && (match.Groups[1].Value != "")) ? match.Groups[1].Value : "0";

                    //6.血量
                    match = Regex.Match(templine, @"hp\=([^\|\{\}]*)");
                    temp_wd.HpNum = ((match.Success) && (match.Groups[1].Value != "")) ? match.Groups[1].Value : "0";

                    //7.CD
                    match = Regex.Match(templine, @"turn\=([^\|\{\}]*)");
                    temp_wd.Duration = ((match.Success) && (match.Groups[1].Value != "")) ? match.Groups[1].Value : "0";

                    //8.初始CD
                    match = Regex.Match(templine, @"IniCD\=([^\|\{\}]*)");
                    temp_wd.IniDuration = ((match.Success) && (match.Groups[1].Value != "")) ? match.Groups[1].Value : "0";

                    //9.掉落金幣
                    match = Regex.Match(templine, @"coin\=([^\|\{\}]*)");
                    temp_wd.DropCoin = ((match.Success) && (match.Groups[1].Value != "")) ? match.Groups[1].Value : "0";

                    //10.掉落寶箱
                    match = Regex.Match(templine, @"chest\=([^\|\{\}]*)");
                    if ((match.Success) && (match.Groups[1].Value != ""))
                    {
                        temp_wd.DropType = "money";
                        temp_wd.DropLevel = match.Groups[1].Value;
                        temp_wd.DropId = "";
                    }
                    else
                    {
                        temp_wd.DropType = "無";
                        temp_wd.DropLevel = "";
                        temp_wd.DropId = "";
                    }

                    //11.掉落卡片&等級(目前只支援覆蓋掉掉落寶箱，無法同時顯示)
                    match = Regex.Match(templine, @"lv\=([^\|\{\}]*)");
                    if ((match.Success) && (match.Groups[1].Value != ""))
                    {
                        temp_wd.DropType = "monster";
                        temp_wd.DropLevel = match.Groups[1].Value;
                        match = Regex.Match(templine, @"drop\=([^\|\{\}]*)");
                        temp_wd.DropId = match.Success ? (Int32.Parse(match.Groups[1].Value)).ToString() : temp_wd.MonsterId;
                    }

                    //12.敵人技能
                    match = Regex.Match(templine, @"es\=([^\|\{\}]*)");
                    temp_wd.EnemySkill = ((match.Success) && (match.Groups[1].Value != "")) ? match.Groups[1].Value : "0";

                    //13.修羅場點數(未完成)
                    temp_wd.PVEScore = "0";

                    //14.敵人逃跑回合(未完成)
                    temp_wd.EscapeRound = "0";

                    //15.多血/前置判斷
                    match = Regex.Match(templine, @"MultiB\=([^\|\{\}]*)");
                    if ((match.Success) && (match.Groups[1].Value != ""))
                        multiBlookFlag = match.Groups[1].Value;
                    else
                        multiBlookFlag = "X";
                    temp_wd.MultiBloodFlag = multiBlookFlag;
                    temp_wd.MultiBloodLevel = wavecount.ToString();

                    temp_wdl.Add(temp_wd);                    
                }
            }
            //最後一組WaveBasic，手動塞入wbl            
            if (temp_wdl.Count > 0)
            {
                temp_wb.WaveDetailList = temp_wdl;
                wbl.Add(temp_wb);
            }

                return wbl;
        }

        protected string genHtml(string floorName, string arg_title_color, string arg_title_word_color, string arg_floor_json, int showtype)
        {
            string html_head = "";
            string html_text = "";
            string title_color = "39393A";
            string title_word_color = "FFD973";
            string floor_json = "";
            floor_json = arg_floor_json;

            List<WaveBasic> wbl;
            if ((showtype == 6)|| (showtype == 7))
                wbl = getFloorDataByWikiaCode(floor_json); //測試
            else
                wbl = getFloorData(floor_json); //測試
            

            //JObject jo_all = JObject.Parse(floor_json);
            //JObject jo_data = JObject.Parse(jo_all.GetValue("data").ToString());
            //JArray ja_waves = JArray.Parse(jo_data.GetValue("waves").ToString());

            string used_skill_html = "";

            if (arg_title_color != "")
            {
                title_color = arg_title_color;
            }
            if (arg_title_word_color != "")
            {
                title_word_color = arg_title_word_color;
            }

            html_head += "<html>";
            html_head += "<title></title>";
            html_head += "<head>";
            html_head += "<meta http-equiv=\"Content-Type\" content=\"text/html; charset=utf-8\">";
            html_head += "</head>";
            html_head += "<body>";
            html_head += "<p>※熾天使關卡資訊產生器 Design by Alex Hou</p>";

            html_text += html_head;

            #region 1.Html模式
            if (showtype == 1)
            {
                html_text += "<table cellpadding=\"1\" cellspacing=\"1\" frame=\"border\" border=\"5\" style=\"font-family:微軟正黑體;background-image:url('/Seraphim.png');\">";
                html_text += "<tr bgcolor=\"#" + title_color + "\"><td colspan=\"9\" align=\"center\"><font color=\"#" + title_word_color + "\"><b>" + floorName + "</b></font></td></tr>";
                html_text += "<tr bgcolor=\"#EEEEEE\"><td align=\"center\">層數</td><td align=\"center\">敵人</td><td align=\"center\">攻擊</td><td align=\"center\">CD </td><td align=\"center\">HP</td><td align=\"center\">防禦</td><td align=\"center\">掉落</td><td align=\"center\">金幣</td><td align=\"center\" width=\"200\">備註</td></tr>";

                foreach (WaveBasic wb in wbl)
                {
                    html_text += wb.WaveSkill != "0" ? ("<tr><td align=\"center\" rowspan=\"1\" colspan=\"9\"><font color=\"#787678\"><b>【R" + wb.WaveId + "虛影特性<font color=\"#3366FF\"><b>" + wb.WaveSkill + "</b></font>】</b></font><br/>" + readLocaleValue("WAVESKILL_DESC_" + wb.WaveSkill, true).Replace("\n", "<br>") + "</td></tr>") : "";
                    foreach (WaveDetail wd in wb.WaveDetailList)
                    {
                        //行頭
                        html_text += "<tr>";

                        //第一行必須給欄寬
                        if (wd.WaveDetailId == 1)
                            html_text += "<td align=\"center\" rowspan=\"" + wb.WaveDetailList.Count().ToString() + "\">" + wb.WaveId + "</td>";

                        //卡片id及名稱
                        html_text += "<td align=\"center\" >";
                        html_text += "<img width=\"40\" height=\"40\" src=\"https://asdfghjklu2000.github.io/Tosapp_Tool/px100/" + wd.MonsterId + ".png\">";
                        html_text += "<br>";
                        html_text += "<font color=\"3366FF\"><b>" + wd.MonsterId + "</b></font> .";
                        html_text += "<a href=\"http://www.tosapp.tw/tos/no." + wd.MonsterId + ".html\">" + readLocaleValue("MONSTER_" + wd.MonsterId, true) + "</a>";
                        html_text += "</td>";
                        //卡片id及名稱

                        //攻擊力
                        html_text += "<td align=\"center\" >";
                        html_text += wd.AckNum;
                        html_text += "</td>";
                        //攻擊力

                        //CD
                        html_text += "<td align=\"center\" >";
                        html_text += wd.Duration + ((wd.IniDuration != "0") ? "(" + wd.IniDuration + ")" : "");
                        html_text += "</td>";
                        //CD

                        //血量
                        html_text += "<td align=\"center\" >";
                        html_text += wd.HpNum;
                        html_text += "</td>";
                        //血量

                        //防禦力
                        html_text += "<td align=\"center\" >";
                        html_text += wd.DefNum;
                        html_text += "</td>";
                        //防禦力

                        //掉落
                        html_text += "<td align=\"center\" >";
                        if (wd.DropType == "money")
                        {
                            html_text += "<img width=\"40\" height=\"40\" src=\"http://www.tosapp.tw/static/image/common/tos/icon-all-016.png\">";
                            html_text += "<br>×" + wd.DropLevel; //掉落寶箱
                        }
                        else if (wd.DropType == "monster")
                        {
                            html_text += wd.DropId;
                            html_text += "<br><img width=\"40\" height=\"40\" src=\"https://asdfghjklu2000.github.io/Tosapp_Tool/px100/" + wd.DropId + ".png\">";
                            html_text += "<br>Lv " + wd.DropLevel; //掉落卡片
                        }
                        else
                        {
                            html_text += "無";
                        }
                        html_text += wd.PVEScore != "0" ? ("<br>寶藏券：" + wd.PVEScore) : "";
                        html_text += "</td>";
                        //掉落

                        //金幣
                        html_text += "<td align=\"center\">";
                        html_text += wd.DropCoin;
                        html_text += "</td>";
                        //金幣

                        //備註
                        html_text += "<td align=\"center\">";
                        html_text += wd.EscapeRound != "0" ? ("<font color=\"#E7A400\"><b>※敵人會在 " + wd.EscapeRound + " 回合後離開</b></font><br>") : "";

                        if (wd.MultiBloodFlag != "X")
                        {
                            html_text += "<font color=\"#FFBBBB\"><b>【";
                            if (wd.MultiBloodFlag == "N")
                                html_text += "多血第 ";
                            else if (wd.MultiBloodFlag == "C")
                                html_text += "變身第 ";
                            html_text += wd.MultiBloodLevel + " 血條】</b></font><br>";
                        }

                        if (wd.EnemySkill != "0")
                        {
                            html_text += "【" + "<font color=\"#3366FF\"><b>" + wd.EnemySkill + "</b></font>." + dict_boss_skill[Int32.Parse(wd.EnemySkill), 1] + dict_boss_skill[Int32.Parse(wd.EnemySkill), 0] + "】"; ; //技能名稱
                            used_skill_html += "<tr><td>" + wd.EnemySkill + "</td><td>" + dict_boss_skill[Int32.Parse(wd.EnemySkill), 0] + "</td><td>";
                            used_skill_html += readLocaleValue("BOSS_DESC_" + wd.EnemySkill, true).Replace("\n", "<br>") + "</td></tr>";
                        }
                        html_text += "</td>";
                        //備註

                        //行尾
                        html_text += "</tr>";
                    }
                }

                html_text += "</table>";
                html_text += "<br><br>";

                html_text += "<table cellpadding=\"3\" cellspacing=\"3\" frame=\"border\" border=\"3\" style=\"font-family:微軟正黑體;\">";
                html_text += "<tr bgcolor=\"#39393A\"><td colspan=\"3\" align=\"center\"><font color=\"#FFD973\"><b>技能說明</b></font></td></tr>";
                html_text += "<tr bgcolor=\"#EEEEEE\"><td align=\"center\">編號</td><td align=\"center\">名字</td><td align=\"center\" width=\"300\">技能</td></tr>" + used_skill_html;
                html_text += "</table>";
                html_text += "<br>";
            }
            #endregion
            #region 2.Wiki模式
            if (showtype == 2)
            {
                html_text += "<br><br>";
                html_text += "<table cellpadding=\"3\" cellspacing=\"3\" frame=\"border\" border=\"3\" style=\"font-family:微軟正黑體;\">";
                html_text += "<tr bgcolor=\"#39393A\"><td colspan=\"1\" align=\"center\"><font color=\"#FFD973\"><b>維基語法</b></font></td></tr>";

                foreach (WaveBasic wb in wbl)
                {
                    //html_text += wb.WaveSkill != "0" ? ("<tr><td align=\"center\" rowspan=\"1\" colspan=\"9\"><font color=\"#787678\"><b>【R" + wb.WaveId + "虛影特性<font color=\"#3366FF\"><b>" + wb.WaveSkill + "</b></font>】</b></font><br/>" + readLocaleValue("WAVESKILL_DESC_" + wb.WaveSkill, true).Replace("\n", "<br>") + "</td></tr>") : "";
                    foreach (WaveDetail wd in wb.WaveDetailList)
                    {
                        html_text += "<tr><td>{{關卡數據";

                        html_text += "|" + wd.MonsterId.PadLeft(3, '0');
                        html_text += "|stage=" + (wd.WaveDetailId == 1 ? (wb.WaveId + (wd.MultiBloodFlag == "N" ? "{{" + num2chinese(wb.WaveDetailList.Count) + "血}}" : "") + (wd.MultiBloodFlag == "C" ? "{{前置}}" : "")) : "");
                        html_text += "|damage=" + wd.AckNum;
                        html_text += "|turn=" + wd.Duration + (wd.IniDuration != "0" ? ("{{初始CD|" + wd.IniDuration + "}}") : "");
                        html_text += "|hp=" + wd.HpNum;
                        html_text += "|def=" + wd.DefNum;
                        html_text += "|coin=" + wd.DropCoin;
                        html_text += (wd.DropType == "monster" ? ("|drop=" + wd.DropId.PadLeft(3, '0') + "|lv=" + wd.DropLevel) : "");
                        html_text += (wd.DropType == "money" ? ("|chest=" + wd.DropLevel) : "");
                        html_text += (wd.EnemySkill != "0" ? ("|es=" + wd.EnemySkill) : "");
                        if (wd.WaveDetailId == 1)
                            html_text += (wb.WaveSkill != "0" ? ("|ws=" + wb.WaveSkill) : "");

                        html_text += "}}</td></tr>";
                    }
                }

                //html_text += wikia_text;
                html_text += "</table>";
                html_text += "<br>";
            }
            #endregion
            #region 3.巴哈模式
            if (showtype == 3)
            {
                html_text += "<br><br>";
                html_text += "<font color=\"#F03434\"><b>※使用說明：</b></font>此轉換功能產生之表格樣式為巴哈版友 路人∩(ゝω●)(<a href=\"https://home.gamer.com.tw/homeindex.php?owner=a37601416\" target=blank>a37601416</a>)所開發，如欲使用發文於巴哈姆特者，請先向 路人 詢問商借事宜再行使用※";
                html_text += "<hr>";
                html_text += "<table cellpadding=\"3\" cellspacing=\"3\" frame=\"border\" border=\"3\" style=\"font-family:微軟正黑體;\">";
                html_text += "<tr bgcolor=\"#39393A\"><td colspan=\"1\" align=\"center\"><font color=\"#FFD973\"><b>巴哈語法</b></font></td></tr>";
                html_text += "<tr><td colspan=\"1\" >";
                html_text += "[table width=100% cellspacing=1 cellpadding=1 border=5 align=center]";
                html_text += "<br>";
                html_text += "[tr][td colspan=3 bgcolor=#333333 align=center][font=微軟正黑體][size=4][b][color=#ffffff]《"
                    + floorName + "》[/color][/b][/size][/font][/td][/tr]";
                html_text += "<br>";
                html_text += "[tr bgcolor=#333333]";
                html_text += "[td width=8% align=center][font=微軟正黑體][size=3][b][color=#ffffff]Battle[/color][/b][/size][/font][/td]";
                html_text += "[td width=8% align=center][font=微軟正黑體][size=3][b][color=#ffffff]敵人[/color][/b][/size][/font][/td]";
                html_text += "[td align=center][font=微軟正黑體][size=3][b][color=#ffffff]敵人資訊[/color][/b][/size][/font][/td]";
                html_text += "[/tr]";
                foreach (WaveBasic wb in wbl)
                {
                    //html_text += wb.WaveSkill != "0" ? ("<tr><td align=\"center\" rowspan=\"1\" colspan=\"9\"><font color=\"#787678\"><b>【R" + wb.WaveId + "虛影特性<font color=\"#3366FF\"><b>" + wb.WaveSkill + "</b></font>】</b></font><br/>" + readLocaleValue("WAVESKILL_DESC_" + wb.WaveSkill, true).Replace("\n", "<br>") + "</td></tr>") : "";
                    foreach (WaveDetail wd in wb.WaveDetailList)
                    {
                        html_text += "<br>";
                        html_text += "[tr]";
                        if (wd.WaveDetailId == 1)
                            html_text += "<br>[td rowspan=" + wb.WaveDetailList.Count + " width=8% bgcolor=#333333 align=center][font=微軟正黑體][size=3][b][color=#ffffff]"
                                + wb.WaveId + (wd.MultiBloodFlag == "N" ? "<br>" + num2chinese(wb.WaveDetailList.Count) + "血" : "")
                                + (wd.MultiBloodFlag == "C" ? "<br>前置" : "")
                                + "[/color][/b][/size][/font][/td]";
                        html_text += "<br>";
                        html_text += "[td width=8%][img=https://asdfghjklu2000.github.io/Tosapp_Tool/px100/" + wd.MonsterId + ".png][/td]";
                        html_text += "<br>";

                        html_text += "[td align=left]";
                        //html_text += "[b][font=微軟正黑體][size=3]HP " + wd.HpNum.PadRight(10,' ').Replace(" ", "&nbsp")
                        //    + "傷害 " + wd.AckNum.PadRight(6, ' ').Replace(" ", "&nbsp")
                        //    + "CD " + (wd.Duration + ((wd.IniDuration != "0") ? "(" + wd.IniDuration + ")" : "")).PadRight(6, ' ').Replace(" ", "&nbsp") 
                        //    + "防 " + wd.DefNum + "[/size][/font][/b]";
                        html_text += "[b][font=微軟正黑體][size=3]HP " + wd.HpNum + "&nbsp&nbsp&nbsp"
                            + "傷害 " + wd.AckNum + "&nbsp&nbsp&nbsp"
                            + "CD " + wd.Duration + ((wd.IniDuration != "0") ? "(" + wd.IniDuration + ")" : "") + "&nbsp&nbsp&nbsp"
                            + "防 " + wd.DefNum + "[/size][/font][/b]";
                        html_text += "[hr]";
                        html_text += "[div align=center][font=微軟正黑體][size=2][b]";
                        html_text += readLocaleValue("BOSS_DESC_" + wd.EnemySkill, true).Replace("\n", "<br>");
                        html_text += "[/b][/size][/font][/div]";
                        html_text += "<br>";
                        html_text += "[/td]";
                        html_text += "<br>";
                        html_text += "[/tr]";
                    }
                }
                //html_text += wikia_text;
                html_text += "[/table]";
                html_text += "</td></tr>";
                html_text += "</table>";
                html_text += "<br>";
            }
            #endregion
            #region 4.表格數值模式
            if (showtype == 4)
            {
                html_text += "<table cellpadding=\"1\" cellspacing=\"1\" frame=\"border\" border=\"5\" style=\"font-family:微軟正黑體;background-image:url('/Seraphim.png');\">";
                html_text += "<tr bgcolor=\"#" + title_color + "\"><td colspan=\"9\" align=\"center\"><font color=\"#" + title_word_color + "\"><b>" + floorName + "</b></font></td></tr>";
                html_text += "<tr bgcolor=\"#EEEEEE\"><td align=\"center\">層數</td><td align=\"center\">敵人</td><td align=\"center\">攻擊</td><td align=\"center\">CD </td><td align=\"center\">HP</td><td align=\"center\">防禦</td><td align=\"center\">掉落</td><td align=\"center\">金幣</td><td align=\"center\" width=\"200\">備註</td></tr>";

                foreach (WaveBasic wb in wbl)
                {
                    html_text += wb.WaveSkill != "0" ? ("<tr><td align=\"center\" rowspan=\"1\" colspan=\"9\"><font color=\"#787678\"><b>【R" + wb.WaveId + "虛影特性<font color=\"#3366FF\"><b>" + wb.WaveSkill + "</b></font>】</b></font><br/>" + readLocaleValue("WAVESKILL_DESC_" + wb.WaveSkill, true).Replace("\n", "<br>") + "</td></tr>") : "";
                    foreach (WaveDetail wd in wb.WaveDetailList)
                    {
                        //行頭
                        html_text += "<tr>";

                        //第一行必須給欄寬
                        if (wd.WaveDetailId == 1)
                            html_text += "<td align=\"center\" rowspan=\"" + wb.WaveDetailList.Count().ToString() + "\">" + wb.WaveId + "</td>";

                        //卡片id及名稱
                        html_text += "<td align=\"center\" >";
                        html_text += "<img width=\"40\" height=\"40\" src=\"https://asdfghjklu2000.github.io/Tosapp_Tool/px100/" + wd.MonsterId + ".png\">";
                        html_text += "<br>";
                        html_text += "<font color=\"3366FF\"><b>" + wd.MonsterId + "</b></font> .";
                        html_text += "<a href=\"http://www.tosapp.tw/tos/no." + wd.MonsterId + ".html\">" + readLocaleValue("MONSTER_" + wd.MonsterId, true) + "</a>";
                        html_text += "</td>";
                        //卡片id及名稱

                        //攻擊力
                        html_text += "<td align=\"center\" >";
                        html_text += wd.AckNum;
                        html_text += "</td>";
                        //攻擊力

                        //CD
                        html_text += "<td align=\"center\" >";
                        html_text += wd.Duration + ((wd.IniDuration != "0") ? "(" + wd.IniDuration + ")" : "");
                        html_text += "</td>";
                        //CD

                        //血量
                        html_text += "<td align=\"center\" >";
                        html_text += wd.HpNum;
                        html_text += "</td>";
                        //血量

                        //防禦力
                        html_text += "<td align=\"center\" >";
                        html_text += wd.DefNum;
                        html_text += "</td>";
                        //防禦力

                        //掉落
                        html_text += "<td align=\"center\" >";
                        if (wd.DropType == "money")
                        {
                            html_text += "<img width=\"40\" height=\"40\" src=\"http://www.tosapp.tw/static/image/common/tos/icon-all-016.png\">";
                            html_text += "<br>×" + wd.DropLevel; //掉落寶箱
                        }
                        else if (wd.DropType == "monster")
                        {
                            html_text += wd.DropId;
                            html_text += "<br><img width=\"40\" height=\"40\" src=\"https://asdfghjklu2000.github.io/Tosapp_Tool/px100/" + wd.DropId + ".png\">";
                            html_text += "<br>Lv " + wd.DropLevel; //掉落卡片
                        }
                        else
                        {
                            html_text += "無";
                        }
                        html_text += wd.PVEScore != "0" ? ("<br>寶藏券：" + wd.PVEScore) : "";
                        html_text += "</td>";
                        //掉落

                        //金幣
                        html_text += "<td align=\"center\">";
                        html_text += wd.DropCoin;
                        html_text += "</td>";
                        //金幣

                        //備註
                        html_text += "<td align=\"center\">";
                        html_text += wd.EscapeRound != "0" ? ("<font color=\"#E7A400\"><b>※敵人會在 " + wd.EscapeRound + " 回合後離開</b></font><br>") : "";

                        if (wd.MultiBloodFlag != "X")
                        {
                            html_text += "<font color=\"#FFBBBB\"><b>【";
                            if (wd.MultiBloodFlag == "N")
                                html_text += "多血第 ";
                            else if (wd.MultiBloodFlag == "C")
                                html_text += "變身第 ";
                            html_text += wd.MultiBloodLevel + " 血條】</b></font><br>";
                        }

                        if (wd.EnemySkill != "0")
                        {
                            html_text += "【" + "<font color=\"#3366FF\"><b>" + wd.EnemySkill + "</b></font>." + dict_boss_skill[Int32.Parse(wd.EnemySkill), 1] + dict_boss_skill[Int32.Parse(wd.EnemySkill), 0] + "】"; ; //技能名稱
                        }
                        html_text += "</td>";
                        //備註

                        //行尾
                        html_text += "</tr>";
                    }
                }

                html_text += "</table>";
                html_text += "<br><br>";
            }
            #endregion
            #region 5.自定義json
            if (showtype == 5)
            {
                html_text += "<br><br>";
                html_text += "<table cellpadding=\"3\" cellspacing=\"3\" frame=\"border\" border=\"3\" style=\"font-family:微軟正黑體;\">";
                html_text += "<tr bgcolor=\"#39393A\"><td colspan=\"1\" align=\"center\"><font color=\"#FFD973\"><b>自定義json</b></font></td></tr>";
                html_text += "<tr><td>";
                html_text += serializer.Serialize(wbl);
                html_text += "</td></tr>";
                html_text += "</table>";
                html_text += "<br><br>";
            }
            #endregion
            #region 6.wikia2巴哈模式
            if (showtype == 6)
            {
                html_text += "<br><br>";
                html_text += "<font color=\"#F03434\"><b>※使用說明：</b></font>此轉換功能產生之表格樣式為巴哈版友 路人∩(ゝω●)(<a href=\"https://home.gamer.com.tw/homeindex.php?owner=a37601416\" target=blank>a37601416</a>)所開發，如欲使用發文於巴哈姆特者，請先向 路人 詢問商借事宜再行使用※";
                html_text += "<hr>";
                html_text += "<table cellpadding=\"3\" cellspacing=\"3\" frame=\"border\" border=\"3\" style=\"font-family:微軟正黑體;\">";
                html_text += "<tr bgcolor=\"#39393A\"><td colspan=\"1\" align=\"center\"><font color=\"#FFD973\"><b>巴哈語法</b></font></td></tr>";
                html_text += "<tr><td colspan=\"1\" >";
                html_text += "[table width=100% cellspacing=1 cellpadding=1 border=5 align=center]";
                html_text += "<br>";
                html_text += "[tr][td colspan=3 bgcolor=#333333 align=center][font=微軟正黑體][size=4][b][color=#ffffff]《"
                    + floorName + "》[/color][/b][/size][/font][/td][/tr]";
                html_text += "<br>";
                html_text += "[tr bgcolor=#333333]";
                html_text += "[td width=8% align=center][font=微軟正黑體][size=3][b][color=#ffffff]Battle[/color][/b][/size][/font][/td]";
                html_text += "[td width=8% align=center][font=微軟正黑體][size=3][b][color=#ffffff]敵人[/color][/b][/size][/font][/td]";
                html_text += "[td align=center][font=微軟正黑體][size=3][b][color=#ffffff]敵人資訊[/color][/b][/size][/font][/td]";
                html_text += "[/tr]";
                foreach (WaveBasic wb in wbl)
                {
                    //html_text += wb.WaveSkill != "0" ? ("<tr><td align=\"center\" rowspan=\"1\" colspan=\"9\"><font color=\"#787678\"><b>【R" + wb.WaveId + "虛影特性<font color=\"#3366FF\"><b>" + wb.WaveSkill + "</b></font>】</b></font><br/>" + readLocaleValue("WAVESKILL_DESC_" + wb.WaveSkill, true).Replace("\n", "<br>") + "</td></tr>") : "";
                    foreach (WaveDetail wd in wb.WaveDetailList)
                    {
                        html_text += "<br>";
                        html_text += "[tr]";
                        if (wd.WaveDetailId == 1)
                            html_text += "<br>[td rowspan=" + wb.WaveDetailList.Count + " width=8% bgcolor=#333333 align=center][font=微軟正黑體][size=3][b][color=#ffffff]"
                                + wb.WaveId + (wd.MultiBloodFlag == "N" ? "<br>" + num2chinese(wb.WaveDetailList.Count) + "血" : "")
                                + (wd.MultiBloodFlag == "C" ? "<br>前置" : "")
                                + "[/color][/b][/size][/font][/td]";
                        html_text += "<br>";
                        html_text += "[td width=8%][img=https://asdfghjklu2000.github.io/Tosapp_Tool/px100/" + wd.MonsterId + ".png][/td]";
                        html_text += "<br>";

                        html_text += "[td align=left]";
                        //html_text += "[b][font=微軟正黑體][size=3]HP " + wd.HpNum.PadRight(10,' ').Replace(" ", "&nbsp")
                        //    + "傷害 " + wd.AckNum.PadRight(6, ' ').Replace(" ", "&nbsp")
                        //    + "CD " + (wd.Duration + ((wd.IniDuration != "0") ? "(" + wd.IniDuration + ")" : "")).PadRight(6, ' ').Replace(" ", "&nbsp") 
                        //    + "防 " + wd.DefNum + "[/size][/font][/b]";
                        html_text += "[b][font=微軟正黑體][size=3]HP " + wd.HpNum + "&nbsp&nbsp&nbsp"
                            + "傷害 " + wd.AckNum + "&nbsp&nbsp&nbsp"
                            + "CD " + wd.Duration + ((wd.IniDuration != "0") ? "(" + wd.IniDuration + ")" : "") + "&nbsp&nbsp&nbsp"
                            + "防 " + wd.DefNum + "[/size][/font][/b]";
                        html_text += "[hr]";
                        html_text += "[div align=center][font=微軟正黑體][size=2][b]";
                        html_text += readLocaleValue("BOSS_DESC_" + wd.EnemySkill, true).Replace("\n", "<br>");
                        html_text += "[/b][/size][/font][/div]";
                        html_text += "<br>";
                        html_text += "[/td]";
                        html_text += "<br>";
                        html_text += "[/tr]";
                    }
                }
                //html_text += wikia_text;
                html_text += "[/table]";
                html_text += "</td></tr>";
                html_text += "</table>";
                html_text += "<br>";
            }
            #endregion
            #region 7.wikia2自定義json
            if (showtype == 7)
            {
                html_text += "<br><br>";
                html_text += "<table cellpadding=\"3\" cellspacing=\"3\" frame=\"border\" border=\"3\" style=\"font-family:微軟正黑體;\">";
                html_text += "<tr bgcolor=\"#39393A\"><td colspan=\"1\" align=\"center\"><font color=\"#FFD973\"><b>自定義json</b></font></td></tr>";
                html_text += "<tr><td>";
                html_text += serializer.Serialize(wbl);
                html_text += "</td></tr>";
                html_text += "</table>";
                html_text += "<br><br>";
            }
            #endregion
            html_text += "<p>※熾天使關卡資訊產生器 Design by Alex Hou<br>Copyright © 2013-2015 Seraphim Raiders All rights reserved.</p>";

            html_text += "</body>";
            html_text += "</html>";

            if ((showtype != 1) && (showtype != 2) && (showtype != 3) && (showtype != 5) && (showtype != 6) && (showtype != 7))
                html_text = "";

            return html_text;
        }

        protected string num2chinese(int num)
        {
            string retStr = "";
            switch (num)
            {
                case 2:
                    retStr = "雙";
                    break;
                case 3:
                    retStr = "三";
                    break;
                default:
                    retStr = "多";
                    break;
            }

            return retStr;
        }

        //處理整個關卡資訊表格
        protected string generateHtmlStr(string floorName, string arg_title_color, string arg_title_word_color, string arg_floor_json, int showtype)
        {
            string html_head = "";
            string html_text = "";
            string title_color = "39393A";
            string title_word_color = "FFD973";
            string floor_json = "";
            floor_json = arg_floor_json;

            JObject jo_all = JObject.Parse(floor_json);
            JObject jo_data = JObject.Parse(jo_all.GetValue("data").ToString());
            JArray ja_waves = JArray.Parse(jo_data.GetValue("waves").ToString());

            JObject jo_waves;
            JArray ja_enemies;

            JObject jo_enemies;

            int checkNextEnemy = 0;
            string enemyHtml = "";
            string used_skill_html = "";
            string wikia_text = "";
            string waveSkillId = "";
            string tosapp_sql = "";
            string sql_prefix = "";

            if (arg_title_color != "")
            {
                title_color = arg_title_color;
            }
            if (arg_title_word_color != "")
            {
                title_word_color = arg_title_word_color;
            }

            //html_head += "<html>";
            //html_head += "<title></title>";
            //html_head += "<head>";
            //html_head += "<meta http-equiv=\"Content-Type\" content=\"text/html; charset=utf-8\">";
            //html_head += "</head>";
            //html_head += "<body>";
            html_head += "<p>※熾天使關卡資訊產生器 Design by Alex Hou</p>";

            html_text += html_head;

            html_text += "<table cellpadding=\"1\" cellspacing=\"1\" frame=\"border\" border=\"5\" style=\"font-family:微軟正黑體;background-image:url('/Seraphim.png');\">";
            html_text += "<tr bgcolor=\"#" + title_color + "\"><td colspan=\"9\" align=\"center\"><font color=\"#" + title_word_color + "\"><b>" + floorName + "</b></font></td></tr>";
            //html_text += "<tr><td width=\"33\">層數</td><td width=\"179\">敵人</td><td width=\"66\">攻擊</td><td width=\"43\">CD </td><td width=\"59\">HP</td><td width=\"46\">防禦</td><td width=\"75\">掉落</td><td width=\"158\">備註</td></tr>";
            html_text += "<tr bgcolor=\"#EEEEEE\"><td align=\"center\">層數</td><td align=\"center\">敵人</td><td align=\"center\">攻擊</td><td align=\"center\">CD </td><td align=\"center\">HP</td><td align=\"center\">防禦</td><td align=\"center\">掉落</td><td align=\"center\">金幣</td><td align=\"center\" width=\"200\">備註</td></tr>";


            for (int i = 0; i < ja_waves.Count; i++)
            {
                jo_waves = JObject.Parse(ja_waves[i].ToString());
                ja_enemies = JArray.Parse(jo_waves.GetValue("enemies").ToString());
                waveSkillId = "0";
                if (jo_waves.GetValue("waveSkillId") != null)
                {
                    waveSkillId = jo_waves.GetValue("waveSkillId").ToString();
                    if (waveSkillId != "0")
                    {
                        html_text += "<tr>";
                        html_text += "<td align=\"center\" rowspan=\"1\" colspan=\"9\"><font color=\"#787678\"><b>【R" + (i + 1).ToString() + "虛影特性<font color=\"#3366FF\"><b>" + waveSkillId + "</b></font>】</b></font><br/>" + readLocaleValue("WAVESKILL_DESC_" + waveSkillId, true).Replace("\n", "<br>") + "</td>";
                        html_text += "</tr>";
                    }
                }

                if ((JObject.Parse(ja_enemies[0].ToString())).GetValue("skillList").ToString() == "[]")
                {
                    //for 一般敵人(含多血怪處理方式)
                    for (int j = 0; j < ja_enemies.Count; j++)
                    {
                        jo_enemies = JObject.Parse(ja_enemies[j].ToString());

                        html_text += "<tr>";

                        checkNextEnemy = 0;
                        if (j == 0)
                            wikia_text += "<tr><td>{{關卡數據|stage=" + (i + 1).ToString() + "|";
                        else
                            wikia_text += "<tr><td>{{關卡數據|stage=|";
                        sql_prefix = "insert into pre_plugin_webtech_tosys_missiondetails(missionid,level,enermyid,ap,cd,cd_init,hp,dp,dropcardid,dropcard_cardlv,comment,comment_mskillid,comment_mskillid2) values (" + floorName + "," + (i + 1).ToString() + ",";
                        tosapp_sql += sql_prefix;
                        if (waveSkillId != "0")
                        {
                            wikia_text += "ws=" + waveSkillId + "|";
                        }

                        enemyHtml = showEnemyHtml(jo_enemies, ref checkNextEnemy, ref used_skill_html, ref wikia_text, ref tosapp_sql, sql_prefix);
                        if (j == 0)
                        {
                            if (checkNextEnemy > 1)
                                html_text += "<td align=\"center\" rowspan=\"" + checkNextEnemy + "\">" + (i + 1).ToString() + "</td>";
                            else
                                html_text += "<td align=\"center\" rowspan=\"" + ja_enemies.Count + "\">" + (i + 1).ToString() + "</td>";
                        }

                        html_text += enemyHtml;
                        html_text += "</tr>";
                    }
                }
                else
                {
                    int skillListCnt = JArray.Parse((JObject.Parse(ja_enemies[0].ToString())).GetValue("skillList").ToString()).Count();
                    for (int s = 0; s < skillListCnt; s++)
                    {
                        //for 本體+左右怪處理方式                        
                        wikia_text += "<tr><td>{{關卡數據注釋|王關第 " + (s + 1).ToString() + " 階段}}</td></tr>";
                        for (int j = 0; j < ja_enemies.Count; j++)
                        {
                            string new_char = "";
                            //int no_show_cnt = 0;

                            jo_enemies = JObject.Parse(ja_enemies[j].ToString());
                            new_char = JArray.Parse(jo_enemies.GetValue("skillList").ToString())[skillListCnt - 1 - s].ToString();

                            jo_enemies.Remove("characteristic");
                            jo_enemies.Add("characteristic", new_char);
                            if (new_char != "0")
                            {
                                html_text += "<tr>";

                                checkNextEnemy = 0;
                                if (j == 0)
                                    wikia_text += "<tr><td>{{關卡數據|stage=" + (i + 1).ToString() + "-" + (s + 1).ToString() + "|";
                                else
                                    wikia_text += "<tr><td>{{關卡數據|stage=|";
                                sql_prefix = "insert into pre_plugin_webtech_tosys_missiondetails(missionid,level,enermyid,ap,cd,cd_init,hp,dp,dropcardid,dropcard_cardlv,comment,comment_mskillid,comment_mskillid2) values (" + floorName + "," + (i + 1).ToString() + ",";
                                tosapp_sql += sql_prefix;
                                if (new_char != "0")
                                    enemyHtml = showEnemyHtml(jo_enemies, ref checkNextEnemy, ref used_skill_html, ref wikia_text, ref tosapp_sql, sql_prefix);
                                //else
                                //no_show_cnt++;
                                if (j == 0)
                                    if (new_char != "0")
                                        html_text += "<td align=\"center\" rowspan=\"" + ja_enemies.Count + "\">" + (i + 1).ToString() + "-" + (s + 1).ToString() + "</td>";
                                if ((s == skillListCnt - 1) && (new_char != "0"))
                                    html_text += "<td align=\"center\" rowspan=\"1" + "\">" + (i + 1).ToString() + "-" + (s + 1).ToString() + "</td>";
                                html_text += enemyHtml;
                                html_text += "</tr>";
                            }
                        }
                    }
                }
            }

            html_text += "</table>";
            html_text += "<br><br>";
            html_text += "<table cellpadding=\"3\" cellspacing=\"3\" frame=\"border\" border=\"3\" style=\"font-family:微軟正黑體;\">";
            html_text += "<tr bgcolor=\"#39393A\"><td colspan=\"3\" align=\"center\"><font color=\"#FFD973\"><b>技能說明</b></font></td></tr>";
            html_text += "<tr bgcolor=\"#EEEEEE\"><td align=\"center\">編號</td><td align=\"center\">名字</td><td align=\"center\" width=\"300\">技能</td></tr>" + used_skill_html;
            html_text += "</table>";
            html_text += "<br>";

            if ((showtype == 2) || (showtype == 3))
            {
                if (showtype == 2)
                    html_text = html_head;

                html_text += "<br><br>";
                html_text += "<table cellpadding=\"3\" cellspacing=\"3\" frame=\"border\" border=\"3\" style=\"font-family:微軟正黑體;\">";
                html_text += "<tr bgcolor=\"#39393A\"><td colspan=\"1\" align=\"center\"><font color=\"#FFD973\"><b>維基語法</b></font></td></tr>";
                //html_text += "<tr>" + wikia_text + "</tr>";
                html_text += wikia_text;
                html_text += "</table>";
                html_text += "<br>";
            }
            html_text += tosapp_sql;

            html_text += "<p>※熾天使關卡資訊產生器 Design by Alex Hou<br>Copyright © 2013-2015 Seraphim Raiders All rights reserved.</p>";

            //html_text += "</body>";
            //html_text += "</html>";

            if ((showtype != 1) && (showtype != 2) && (showtype != 3))
                html_text = "";

            return html_text;
        }
        protected string showEnemyHtml(JObject jo_enemies, ref int times, ref string used_skill, ref string wikia_text, ref string tosapp_sql, string sql_prefix)
        {
            JObject jo_extras;
            JObject jo_lootItem;
            JObject jo_nextEnemy;

            string html_text = "";

            //{{關卡數據|522|stage=|damage=16182|turn=3{{初始CD|3}}|hp=1826870|def=2020|coin=626|es=896}}
            wikia_text += jo_enemies.GetValue("monsterId").ToString().PadLeft(3, '0');
            tosapp_sql += "(select id from pre_plugin_webtech_tosys_cards where displayorder=" + jo_enemies.GetValue("monsterId").ToString() + "),";

            times++;

            html_text += "<td align=\"center\" >";//卡片id及名稱
            html_text += "<img width=\"40\" height=\"40\" src=\"https://asdfghjklu2000.github.io/Tosapp_Tool/px100/" + jo_enemies.GetValue("monsterId").ToString() + ".png\">";
            html_text += "<br>";
            html_text += "<font color=\"3366FF\"><b>" + jo_enemies.GetValue("monsterId").ToString() + "</b></font> .";
            html_text += "<a href=\"http://www.tosapp.tw/tos/no." + jo_enemies.GetValue("monsterId").ToString() + ".html\">" + readLocaleValue("MONSTER_" + jo_enemies.GetValue("monsterId").ToString(), true) + "</a>";
            html_text += "</td>";//卡片id及名稱

            if (jo_enemies.GetValue("extras") != null)
            {
                jo_extras = JObject.Parse(jo_enemies.GetValue("extras").ToString());

                html_text += "<td align=\"center\" >"; //攻擊力
                if (jo_extras.GetValue("attack") != null)
                {
                    html_text += jo_extras.GetValue("attack").ToString();
                    wikia_text += "|damage=" + jo_extras.GetValue("attack").ToString();
                    tosapp_sql += "'" + jo_extras.GetValue("attack").ToString() + "',";
                }
                else
                {
                    int temp_atk = 0;
                    temp_atk += Int32.Parse(((Monster)dic_monster_data[jo_enemies.GetValue("monsterId").ToString()]).MIN_ENEMY_ATTACK.ToString());
                    temp_atk += (Int32.Parse(jo_enemies.GetValue("level").ToString()) - 1) * Int32.Parse(((Monster)dic_monster_data[jo_enemies.GetValue("monsterId").ToString()]).INC_ENEMY_ATTACK.ToString());
                    html_text += temp_atk.ToString();
                    wikia_text += "|damage=" + temp_atk.ToString();
                    tosapp_sql += "'" + temp_atk.ToString() + "',";
                }
                html_text += "</td>"; //攻擊力

                html_text += "<td align=\"center\" >"; //cd
                if (jo_extras.GetValue("attackDuration") != null)
                {
                    html_text += jo_extras.GetValue("attackDuration").ToString();
                    wikia_text += "|turn=" + jo_extras.GetValue("attackDuration").ToString();
                    tosapp_sql += jo_extras.GetValue("attackDuration").ToString() + ",";
                }
                else
                {
                    int temp_cd = Int32.Parse(((Monster)dic_monster_data[jo_enemies.GetValue("monsterId").ToString()]).ATTACK_DURATION.ToString());
                    html_text += temp_cd.ToString();
                    wikia_text += "|turn=" + temp_cd.ToString();
                    tosapp_sql += temp_cd.ToString() + ",";
                }

                if (jo_extras.GetValue("initAttackDuration") != null)
                {
                    html_text += "(" + jo_extras.GetValue("initAttackDuration").ToString() + ")"; //初始cd
                    wikia_text += "{{初始CD|" + jo_extras.GetValue("initAttackDuration").ToString() + "}}";
                    tosapp_sql += jo_extras.GetValue("initAttackDuration").ToString() + ",";
                }
                else if (jo_extras.GetValue("cdLock") != null)
                {
                    if ((bool)jo_extras.GetValue("cdLock") == true)
                    {
                        if (jo_extras.GetValue("attackDuration") != null)
                        {
                            html_text += "(" + jo_extras.GetValue("attackDuration").ToString() + ")";
                            wikia_text += "{{初始CD|" + jo_extras.GetValue("attackDuration").ToString() + "}}";
                            tosapp_sql += jo_extras.GetValue("attackDuration").ToString() + ",";
                        }
                        else
                        {
                            int temp_cd = Int32.Parse(((Monster)dic_monster_data[jo_enemies.GetValue("monsterId").ToString()]).ATTACK_DURATION.ToString());
                            html_text += "(" + temp_cd.ToString() + ")";
                            wikia_text += "{{初始CD|" + temp_cd.ToString() + "}}";
                            tosapp_sql += temp_cd.ToString() + ",";
                        }
                    }
                }//沒初始cd就看cdLock
                else
                    tosapp_sql += "0,";

                html_text += "</td>"; //cd

                html_text += "<td align=\"center\" >"; //血量
                if (jo_extras.GetValue("HP") != null)
                {
                    html_text += jo_extras.GetValue("HP").ToString();
                    wikia_text += "|hp=" + jo_extras.GetValue("HP").ToString();
                    tosapp_sql += "'" + jo_extras.GetValue("HP").ToString() + "',";
                }
                else
                {
                    int temp_hp = 0;
                    temp_hp += Int32.Parse(((Monster)dic_monster_data[jo_enemies.GetValue("monsterId").ToString()]).MIN_ENEMY_HP.ToString());
                    temp_hp += (Int32.Parse(jo_enemies.GetValue("level").ToString()) - 1) * Int32.Parse(((Monster)dic_monster_data[jo_enemies.GetValue("monsterId").ToString()]).INC_ENEMY_HP.ToString());
                    html_text += temp_hp.ToString();
                    wikia_text += "|hp=" + temp_hp.ToString();
                    tosapp_sql += "'" + temp_hp.ToString() + "',";
                }
                html_text += "</td>"; //血量

                html_text += "<td align=\"center\" >"; //防禦力
                if (jo_extras.GetValue("defense") != null)
                {
                    html_text += jo_extras.GetValue("defense").ToString();
                    wikia_text += "|def=" + jo_extras.GetValue("defense").ToString();
                    tosapp_sql += "'" + jo_extras.GetValue("defense").ToString() + "',";
                }
                else
                {
                    int temp_def = 0;
                    temp_def += Int32.Parse(((Monster)dic_monster_data[jo_enemies.GetValue("monsterId").ToString()]).MIN_ENEMY_DEFENSE.ToString());
                    temp_def += (Int32.Parse(jo_enemies.GetValue("level").ToString()) - 1) * Int32.Parse(((Monster)dic_monster_data[jo_enemies.GetValue("monsterId").ToString()]).INC_ENEMY_DEFENSE.ToString());
                    html_text += temp_def.ToString();
                    wikia_text += "|def=" + temp_def.ToString();
                    tosapp_sql += "'" + temp_def.ToString() + "',";
                }
                html_text += "</td>"; //防禦力

                html_text += "<td align=\"center\">"; //掉落
                if ((jo_enemies.GetValue("lootItem") != null) && (times == 1))
                {
                    jo_lootItem = JObject.Parse(jo_enemies.GetValue("lootItem").ToString());
                    if (jo_lootItem.GetValue("type").ToString() == "money")
                    {
                        html_text += "<img width=\"40\" height=\"40\" src=\"http://www.tosapp.tw/static/image/common/tos/icon-all-016.png\">";
                        html_text += "<br>×" + jo_lootItem.GetValue("amount").ToString(); //掉落寶箱
                        wikia_text += "|chest=" + jo_lootItem.GetValue("amount").ToString();
                        tosapp_sql += "0,0,";
                    }
                    else if (jo_lootItem.GetValue("type").ToString() == "monster")
                    {
                        html_text += JObject.Parse(jo_lootItem.GetValue("card").ToString()).GetValue("monsterId").ToString();
                        html_text += "<br><img width=\"40\" height=\"40\" src=\"https://asdfghjklu2000.github.io/Tosapp_Tool/px100/" + JObject.Parse(jo_lootItem.GetValue("card").ToString()).GetValue("monsterId").ToString() + ".png\">";
                        html_text += "<br>LV " + JObject.Parse(jo_lootItem.GetValue("card").ToString()).GetValue("level").ToString(); //掉落卡片
                        wikia_text += "|drop=" + JObject.Parse(jo_lootItem.GetValue("card").ToString()).GetValue("monsterId").ToString().PadLeft(3, '0');
                        wikia_text += "|lv=" + JObject.Parse(jo_lootItem.GetValue("card").ToString()).GetValue("level").ToString();
                        tosapp_sql += "(select id from pre_plugin_webtech_tosys_cards where displayorder=" + JObject.Parse(jo_lootItem.GetValue("card").ToString()).GetValue("monsterId").ToString() + "),";
                        tosapp_sql += JObject.Parse(jo_lootItem.GetValue("card").ToString()).GetValue("level").ToString() + ",";
                    }
                    else
                    {
                        html_text += "無";
                        tosapp_sql += "0,0,";
                    }
                }
                else
                {
                    html_text += "無";
                    tosapp_sql += "0,0,";
                }

                if (jo_enemies.GetValue("singlePlayerPVEScore") != null)
                    if (jo_enemies.GetValue("singlePlayerPVEScore").ToString() != "0")
                        html_text += "<br>寶藏券：" + jo_enemies.GetValue("singlePlayerPVEScore").ToString();

                html_text += "</td>"; //掉落
            }
            else
            {
                html_text += "<td align=\"center\" >"; //攻擊力
                int temp_atk = 0;
                temp_atk += Int32.Parse(((Monster)dic_monster_data[jo_enemies.GetValue("monsterId").ToString()]).MIN_ENEMY_ATTACK.ToString());
                temp_atk += (Int32.Parse(jo_enemies.GetValue("level").ToString()) - 1) * Int32.Parse(((Monster)dic_monster_data[jo_enemies.GetValue("monsterId").ToString()]).INC_ENEMY_ATTACK.ToString());
                html_text += temp_atk.ToString();
                wikia_text += "|damage=" + temp_atk.ToString();
                tosapp_sql += "'" + temp_atk.ToString() + "',";
                html_text += "</td>"; //攻擊力

                html_text += "<td align=\"center\" >"; //cd
                int temp_cd = Int32.Parse(((Monster)dic_monster_data[jo_enemies.GetValue("monsterId").ToString()]).ATTACK_DURATION.ToString());
                html_text += temp_cd.ToString() + "(" + temp_cd.ToString() + ")";
                wikia_text += "|turn=" + temp_cd.ToString() + "{{初始CD|" + temp_cd.ToString() + "}}";
                tosapp_sql += temp_cd.ToString() + ",0,";
                html_text += "</td>"; //cd

                html_text += "<td align=\"center\" >"; //血量
                int temp_hp = 0;
                temp_hp += Int32.Parse(((Monster)dic_monster_data[jo_enemies.GetValue("monsterId").ToString()]).MIN_ENEMY_HP.ToString());
                temp_hp += (Int32.Parse(jo_enemies.GetValue("level").ToString()) - 1) * Int32.Parse(((Monster)dic_monster_data[jo_enemies.GetValue("monsterId").ToString()]).INC_ENEMY_HP.ToString());
                html_text += temp_hp.ToString();
                wikia_text += "|hp=" + temp_hp.ToString();
                tosapp_sql += "'" + temp_hp.ToString() + "',";
                html_text += "</td>"; //血量

                html_text += "<td align=\"center\" >"; //防禦力
                int temp_def = 0;
                temp_def += Int32.Parse(((Monster)dic_monster_data[jo_enemies.GetValue("monsterId").ToString()]).MIN_ENEMY_DEFENSE.ToString());
                temp_def += (Int32.Parse(jo_enemies.GetValue("level").ToString()) - 1) * Int32.Parse(((Monster)dic_monster_data[jo_enemies.GetValue("monsterId").ToString()]).INC_ENEMY_DEFENSE.ToString());
                html_text += temp_def.ToString();
                wikia_text += "|def=" + temp_def.ToString();
                tosapp_sql += "'" + temp_def.ToString() + "',";
                html_text += "</td>"; //防禦力

                html_text += "<td align=\"center\">"; //掉落
                if ((jo_enemies.GetValue("lootItem") != null) && (times == 1))
                {
                    jo_lootItem = JObject.Parse(jo_enemies.GetValue("lootItem").ToString());
                    if (jo_lootItem.GetValue("type").ToString() == "money")
                    {
                        //html_text += "<img width=\"40\" height=\"40\" src=\"http://www.tosapp.tw/static/image/common/tos/icon-all-017.png\">";
                        html_text += "<img width=\"40\" height=\"40\" src=\"http://www.tosapp.tw/static/image/common/tos/icon-all-016.png\" > ";
                        html_text += "<br>×" + jo_lootItem.GetValue("amount").ToString(); //掉落寶箱
                        wikia_text += "|chest=" + jo_lootItem.GetValue("amount").ToString();
                        tosapp_sql += "0,0,";
                    }
                    else if (jo_lootItem.GetValue("type").ToString() == "monster")
                    {
                        html_text += JObject.Parse(jo_lootItem.GetValue("card").ToString()).GetValue("monsterId").ToString();
                        html_text += "<br><img width=\"40\" height=\"40\" src=\"https://asdfghjklu2000.github.io/Tosapp_Tool/px100/" + JObject.Parse(jo_lootItem.GetValue("card").ToString()).GetValue("monsterId").ToString() + ".png\">";
                        html_text += "<br>LV " + JObject.Parse(jo_lootItem.GetValue("card").ToString()).GetValue("level").ToString(); //掉落卡片
                        wikia_text += "|drop=" + JObject.Parse(jo_lootItem.GetValue("card").ToString()).GetValue("monsterId").ToString().PadLeft(3, '0');
                        wikia_text += "|lv=" + JObject.Parse(jo_lootItem.GetValue("card").ToString()).GetValue("level").ToString();
                        tosapp_sql += "(select id from pre_plugin_webtech_tosys_cards where displayorder=" + JObject.Parse(jo_lootItem.GetValue("card").ToString()).GetValue("monsterId").ToString() + "),";
                        tosapp_sql += JObject.Parse(jo_lootItem.GetValue("card").ToString()).GetValue("level").ToString() + ",";
                    }
                    else
                    {
                        html_text += "無";
                        tosapp_sql += "0,0,";
                    }
                }
                else
                {
                    html_text += "無";
                    tosapp_sql += "0,0,";
                }

                if (jo_enemies.GetValue("singlePlayerPVEScore") != null)
                    if (jo_enemies.GetValue("singlePlayerPVEScore").ToString() != "0")
                        html_text += "<br>寶藏券：" + jo_enemies.GetValue("singlePlayerPVEScore").ToString();

                html_text += "</td>"; //掉落
            }

            html_text += "<td align=\"center\">"; //金幣
            int temp_coin = 0;
            if (times == 1)
            {
                temp_coin += Int32.Parse(((Monster)dic_monster_data[jo_enemies.GetValue("monsterId").ToString()]).MIN_LOOT_COIN.ToString());
                temp_coin += (Int32.Parse(jo_enemies.GetValue("level").ToString()) - 1) * Int32.Parse(((Monster)dic_monster_data[jo_enemies.GetValue("monsterId").ToString()]).INC_LOOT_COIN.ToString());
            }
            html_text += temp_coin.ToString();
            wikia_text += "|coin=" + temp_coin.ToString();
            tosapp_sql += "'',";
            html_text += "</td>"; //金幣

            html_text += "<td align=\"center\">"; //備註
            if (jo_enemies.GetValue("escapeTurn") != null)
                if (jo_enemies.GetValue("escapeTurn").ToString() != "0")
                    html_text += "<font color=\"#E7A400\"><b>※敵人會在 " + jo_enemies.GetValue("escapeTurn").ToString() + " 回合後離開</b></font><br>";

            if ((jo_enemies.GetValue("nextEnemy") != null) && (times == 1))
            {
                html_text += "<font color=\"#FFBBBB\"><b>【多血第 " + times + " 血條】</b></font><br>";
            }
            if ((jo_enemies.GetValue("child") != null) && (times == 1))
            {
                html_text += "<font color=\"#FFBBBB\"><b>【變身第 " + times + " 血條】</b></font><br>";
            }
            if (times > 1)
            {
                html_text += "<font color=\"#FFBBBB\"><b>【第 " + times + " 血條】</b></font><br>";
            }

            if (jo_enemies.GetValue("characteristic").ToString() != "0")
            {
                html_text += "【" + "<font color=\"#3366FF\"><b>" + jo_enemies.GetValue("characteristic").ToString() + "</b></font>." + dict_boss_skill[Int32.Parse(jo_enemies.GetValue("characteristic").ToString()), 1] + dict_boss_skill[Int32.Parse(jo_enemies.GetValue("characteristic").ToString()), 0] + "】"; ; //維基技能名稱

                used_skill += "<tr><td>" + jo_enemies.GetValue("characteristic").ToString() + "</td><td>" + dict_boss_skill[Int32.Parse(jo_enemies.GetValue("characteristic").ToString()), 0] + "</td><td>";
                used_skill += readLocaleValue("BOSS_DESC_" + jo_enemies.GetValue("characteristic").ToString(), true).Replace("\n", "<br>") + "</td></tr>";

                wikia_text += "|es=" + jo_enemies.GetValue("characteristic").ToString();
                tosapp_sql += "(select id from pre_plugin_webtech_tosys_skills where type=3 and displayorder=" + jo_enemies.GetValue("characteristic").ToString() + "),";
                //html_text += "<br>";
                //html_text += readLocaleValue("BOSS_DESC_" + jo_enemies.GetValue("characteristic").ToString(), true);
            }
            else
                tosapp_sql += "0,";

            if ((jo_enemies.GetValue("nextEnemy") != null) || (times > 1))
            {
                tosapp_sql += "(select id from pre_plugin_webtech_tosys_skills where type=3 and displayorder=2000" + times + "));";
            }
            else if ((jo_enemies.GetValue("child") != null) || (times > 1))
            {
                tosapp_sql += "(select id from pre_plugin_webtech_tosys_skills where type=3 and displayorder=2000" + times + "));";
            }
            else
            {
                tosapp_sql += "0);";
            }

            html_text += "</td>"; //備註
            wikia_text += "}}</td></tr>"; //結束

            if (jo_enemies.GetValue("nextEnemy") != null)
            {
                jo_nextEnemy = JObject.Parse(jo_enemies.GetValue("nextEnemy").ToString());
                html_text += "</tr><tr>";
                wikia_text += "<tr><td>{{關卡數據|stage=|";
                tosapp_sql += "\n" + sql_prefix;
                html_text += showEnemyHtml(jo_nextEnemy, ref times, ref used_skill, ref wikia_text, ref tosapp_sql, sql_prefix);
            }
            if (jo_enemies.GetValue("child") != null)
            {
                jo_nextEnemy = JObject.Parse(jo_enemies.GetValue("child").ToString());
                html_text += "</tr><tr>";
                wikia_text += "<tr><td>{{關卡數據|stage=|";
                tosapp_sql += "\n" + sql_prefix;
                html_text += showEnemyHtml(jo_nextEnemy, ref times, ref used_skill, ref wikia_text, ref tosapp_sql, sql_prefix);
            }

            return html_text;
        }
        //處理單一enemy資訊
        protected string getEnemyObj(JObject jo_enemies, ref int wavedetialid, ref int times, ref string multiblood_flag, ref List<WaveDetail> temp_wdl)
        {
            JObject jo_extras;
            JObject jo_lootItem;
            JObject jo_nextEnemy;

            string html_text = "";
            WaveDetail temp_wd = new WaveDetail();
            temp_wd.MonsterId = jo_enemies.GetValue("monsterId").ToString();

            Monster monster_data = null;
            if (dic_monster_data.ContainsKey(temp_wd.MonsterId))
                monster_data = (Monster)dic_monster_data[temp_wd.MonsterId];

            times++;
            wavedetialid++;
            temp_wd.WaveDetailId = wavedetialid;

            //攻血防CD，先抓gamedata資訊，沒有的就給"?"
            temp_wd.AckNum = monster_data != null ? (Int32.Parse(monster_data.MIN_ENEMY_ATTACK) + (Int32.Parse(jo_enemies.GetValue("level").ToString()) - 1) * Int32.Parse(monster_data.INC_ENEMY_ATTACK)).ToString() : "?";
            temp_wd.HpNum = monster_data != null ? (Int32.Parse(monster_data.MIN_ENEMY_HP) + (Int32.Parse(jo_enemies.GetValue("level").ToString()) - 1) * Int32.Parse(monster_data.INC_ENEMY_HP)).ToString() : "?";
            temp_wd.DefNum = monster_data != null ? (Int32.Parse(monster_data.MIN_ENEMY_DEFENSE) + (Int32.Parse(jo_enemies.GetValue("level").ToString()) - 1) * Int32.Parse(monster_data.INC_ENEMY_DEFENSE)).ToString() : "?";
            temp_wd.Duration = monster_data != null ? monster_data.ATTACK_DURATION : "?";
            temp_wd.IniDuration = monster_data != null ? monster_data.ATTACK_DURATION : "?";
            //寶藏券跟逃跑回合直接看封包，沒有就沒有
            temp_wd.PVEScore = jo_enemies.GetValue("singlePlayerPVEScore") != null ? jo_enemies.GetValue("singlePlayerPVEScore").ToString() : "0";
            temp_wd.EscapeRound = jo_enemies.GetValue("escapeTurn") != null ? jo_enemies.GetValue("escapeTurn").ToString() : "0";
            //掉落金幣直接看gamedata資訊，沒有就沒有，若多血只看第一血
            temp_wd.DropCoin = (times == 1) ? (monster_data != null ? (Int32.Parse(monster_data.MIN_LOOT_COIN) + (Int32.Parse(jo_enemies.GetValue("level").ToString()) - 1) * Int32.Parse(monster_data.INC_LOOT_COIN)).ToString() : "?") : "0";

            //再來看有沒有extra，有的話從extra抓資訊覆蓋
            if (jo_enemies.GetValue("extras") != null)
            {
                if (jo_enemies.GetValue("extras").ToString() != "")
                {
                    jo_extras = JObject.Parse(jo_enemies.GetValue("extras").ToString());

                    temp_wd.AckNum = jo_extras.GetValue("attack") != null ? jo_extras.GetValue("attack").ToString() : temp_wd.AckNum;

                    temp_wd.HpNum = jo_extras.GetValue("HP") != null ? jo_extras.GetValue("HP").ToString() : temp_wd.HpNum;

                    temp_wd.DefNum = jo_extras.GetValue("defense") != null ? jo_extras.GetValue("defense").ToString() : temp_wd.DefNum;

                    temp_wd.Duration = jo_extras.GetValue("attackDuration") != null ? jo_extras.GetValue("attackDuration").ToString() : temp_wd.Duration;
                    //初始CD判斷：先抓initAttackDuration，沒有就看cdLock，true就給attackDuration；false就給0(代表無初始CD)
                    temp_wd.IniDuration = jo_extras.GetValue("initAttackDuration") != null ? jo_extras.GetValue("initAttackDuration").ToString() :
                        (jo_extras.GetValue("cdLock") != null ? ((bool)jo_extras.GetValue("cdLock") ? (jo_extras.GetValue("attackDuration") != null ? jo_extras.GetValue("attackDuration").ToString() : temp_wd.IniDuration) : "0") : "0");
                }
            }
            //戰利品，同一wave只看第一血
            if ((jo_enemies.GetValue("lootItem") != null) && (times == 1))
            {
                jo_lootItem = JObject.Parse(jo_enemies.GetValue("lootItem").ToString());
                temp_wd.DropType = jo_lootItem.GetValue("type").ToString();
                //寶箱
                if (temp_wd.DropType == "money")
                {
                    temp_wd.DropId = "";
                    temp_wd.DropLevel = jo_lootItem.GetValue("amount").ToString();
                }
                //掉卡
                else if (temp_wd.DropType == "monster")
                {
                    temp_wd.DropId = JObject.Parse(jo_lootItem.GetValue("card").ToString()).GetValue("monsterId").ToString();
                    temp_wd.DropLevel = JObject.Parse(jo_lootItem.GetValue("card").ToString()).GetValue("level").ToString();
                }
                //尚未分類的…如龍刻
                else
                {
                    temp_wd.DropType = "未知";
                    temp_wd.DropId = "";
                    temp_wd.DropLevel = "";
                }
            }
            else
            {
                temp_wd.DropType = "無";
                temp_wd.DropId = "";
                temp_wd.DropLevel = "";
            }

            if ((jo_enemies.GetValue("nextEnemy") != null) && (times == 1))
            {
                multiblood_flag = "N";
            }
            if ((jo_enemies.GetValue("child") != null) && (times == 1))
            {
                multiblood_flag = "C";
            }

            temp_wd.MultiBloodFlag = multiblood_flag;
            temp_wd.MultiBloodLevel = times.ToString();
            temp_wd.EnemySkill = jo_enemies.GetValue("characteristic") != null ? jo_enemies.GetValue("characteristic").ToString() : "0";

            temp_wdl.Add(temp_wd);

            if (jo_enemies.GetValue("nextEnemy") != null)
            {
                jo_nextEnemy = JObject.Parse(jo_enemies.GetValue("nextEnemy").ToString());
                getEnemyObj(jo_nextEnemy, ref wavedetialid, ref times, ref multiblood_flag, ref temp_wdl);
            }
            if (jo_enemies.GetValue("child") != null)
            {
                jo_nextEnemy = JObject.Parse(jo_enemies.GetValue("child").ToString());
                getEnemyObj(jo_nextEnemy, ref wavedetialid, ref times, ref multiblood_flag, ref temp_wdl);
            }

            return html_text;
        }

        [WebMethod]
        [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
        public string GetHtml(string floorName, string arg_title_color, string arg_title_word_color, string arg_floor_json, int arg_showtype)
        {
            loadLocaleCsv2();
            loadBossSkill2();
            loadMonsterData2();
            string htmlstr = "";
            //htmlstr = generateHtmlStr(floorName, arg_title_color, arg_title_word_color, arg_floor_json, arg_showtype);
            htmlstr = genHtml(floorName, arg_title_color, arg_title_word_color, arg_floor_json, arg_showtype);
            //Context.Response.Output.Write(htmlstr);
            //HttpContext.Current.Response.Write(htmlstr);            
            //Context.Response.Output.Write("{\"reponse\":\"ok\"}");
            return htmlstr;
        }

        [WebMethod]
        [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
        public void GetTosappJson(string arg_floor_json)
        {
            string floor_json = "", JsonStr = "";
            floor_json = arg_floor_json;
            List<WaveBasic> wbl;
            wbl = getFloorData(floor_json); //測試
            JsonStr = serializer.Serialize(wbl);
            Context.Response.Output.Write(JsonStr);
        }

        [WebMethod]
        [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
        public string GetLocale(string filebase64)
        {
            byte[] newBytes = Convert.FromBase64String(filebase64);
            MCSVFile m = new MCSVFile();
            m.LoadBinaryAsset(newBytes);
            //Tosapp_Tool.MCSVFile m = MCSVFile.LoadStream(file);
            Dictionary<string, string> TipsManager = new Dictionary<string, string>();

            //m.NumRow()為所有字串的總數
            int num = m.NumRow();
            //return num.ToString();
            //宣告一個陣列用來接MCSVFile破解出來的字串
            string[,] dict = new string[num, 3];

            //用來接
            string text = string.Empty;
            string text1 = string.Empty;
            string text2 = string.Empty;

            //string ret = "";
            DataTable result = new DataTable("Locale");

            result.Columns.Add("編號");
            result.Columns.Add("中文");
            result.Columns.Add("英文");

            int num2 = 0;
            for (int i = 0; i < num - 1; i++)
            {
                text = string.Empty;
                text1 = string.Empty;
                text2 = string.Empty;
                if (!string.IsNullOrEmpty(m.GetString(i, 0, string.Empty)))
                {
                    //m.GetString(i, 0, string.Empty)是字串的KEY值
                    text = m.GetString(i, 0, string.Empty);
                    //m.GetString(i, 0, string.Empty)是字串的英文描述
                    text1 = m.GetString(i, 1, string.Empty);
                    //m.GetString(i, 0, string.Empty)是字串的中文描述
                    text2 = m.GetString(i, 2, string.Empty);
                    try
                    {
                        //寫到陣列去
                        dict[i, 0] = text;
                        dict[i, 1] = text1;
                        dict[i, 2] = text2;

                        var row = result.NewRow();
                        row["編號"] = text;
                        row["中文"] = text2;
                        row["英文"] = text1;
                        result.Rows.Add(row);
                        //dict_locale_csv.Add(text, text2);
                        //dict_locale_csv_eng.Add(text, text1);
                    }
                    catch (Exception var_8_9E)
                    {
                        //Watchdog.LogError("[SimpleLocale] (Duplicated Translation Label) Key: " + text + " Msg: " + text2);
                    }
                    string[] array = text.Split(new char[] { '_' });
                    if (array.Length == 2 && text.StartsWith("TIP_") && int.TryParse(array[1], out num2))
                    {
                        TipsManager.Add(text, text2);
                    }
                }
            }
            DataTableToExcel(result, "Locale", true);
            //flushxlsxfile();
            //ret = JsonConvert.SerializeObject(result, Newtonsoft.Json.Formatting.Indented);
            return fileName;
        }

        [WebMethod]
        [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
        public string GetLocaleTxt(string filebase64)
        {
            string tmpFilePName = Path.GetTempFileName();
            string path = tmpFilePName;
            FileStream fs2 = new FileStream(path, System.IO.FileMode.Create, FileAccess.ReadWrite, FileShare.ReadWrite);
            StreamWriter sw = new StreamWriter(fs2);

            byte[] newBytes = Convert.FromBase64String(filebase64);
            MCSVFile m = new MCSVFile();
            m.LoadBinaryAsset(newBytes);
            //Tosapp_Tool.MCSVFile m = MCSVFile.LoadStream(file);
            Dictionary<string, string> TipsManager = new Dictionary<string, string>();

            //m.NumRow()為所有字串的總數
            int num = m.NumRow();
            //return num.ToString();
            //宣告一個陣列用來接MCSVFile破解出來的字串
            string[,] dict = new string[num, 3];

            //用來接
            string text = string.Empty;
            string text1 = string.Empty;
            string text2 = string.Empty;

            int num2 = 0;
            for (int i = 0; i < num - 1; i++)
            {
                text = string.Empty;
                text1 = string.Empty;
                text2 = string.Empty;
                if (!string.IsNullOrEmpty(m.GetString(i, 0, string.Empty)))
                {
                    //m.GetString(i, 0, string.Empty)是字串的KEY值
                    text = m.GetString(i, 0, string.Empty);
                    //m.GetString(i, 0, string.Empty)是字串的英文描述
                    text1 = m.GetString(i, 1, string.Empty);
                    //m.GetString(i, 0, string.Empty)是字串的中文描述
                    text2 = m.GetString(i, 2, string.Empty);
                    try
                    {
                        //寫到陣列去
                        dict[i, 0] = text;
                        dict[i, 1] = text1;
                        dict[i, 2] = text2;

                        //輸出html字串
                        sw.WriteLine("<<<<" + text + ">>>>");
                        sw.WriteLine(text2);
                        sw.WriteLine(text1);

                        //dict_locale_csv.Add(text, text2);
                        //dict_locale_csv_eng.Add(text, text1);
                    }
                    catch (Exception var_8_9E)
                    {
                        //Watchdog.LogError("[SimpleLocale] (Duplicated Translation Label) Key: " + text + " Msg: " + text2);
                    }
                    string[] array = text.Split(new char[] { '_' });
                    if (array.Length == 2 && text.StartsWith("TIP_") && int.TryParse(array[1], out num2))
                    {
                        TipsManager.Add(text, text2);
                    }
                }
            }
            sw.Close();
            fs2.Close();

            return path;

            //flushxlsxfile();
            //ret = JsonConvert.SerializeObject(result, Newtonsoft.Json.Formatting.Indented);



            // This text is added only once to the file.

            // Create a file to write to.
            //string createText = "Hello and Welcome" + Environment.NewLine;
            //File.WriteAllText(path, createText, Encoding.UTF8);
            //File.WriteAllText(path, "1234456dfghdfgsdf\n245asdsdf", Encoding.UTF8);

            return fileName;
        }

        //[WebMethod]
        public string Test(string file)
        {
            string ret = "";
            DataTable result = new DataTable("Locale");

            loadLocaleCsv2();
            result.Columns.Add("編號");
            result.Columns.Add("中文");
            result.Columns.Add("英文");

            foreach (KeyValuePair<string, string> item in dict_locale_csv)
            {
                var row = result.NewRow();
                row["編號"] = item.Key;
                row["中文"] = item.Value;
                row["英文"] = dict_locale_csv_eng[item.Key];
                result.Rows.Add(row);
            }

            //ret += "<table>" + "<tr><td>編號</td><td>中文</td><td>英文</td></tr>";

            //foreach (KeyValuePair<string, string> kvp in dict_locale_csv)
            //{
            //    ret += "<tr>";
            //    ret += "<td>" + kvp.Key + "</td>" + "<td>" + kvp.Value + "</td>" + "<td>" + dict_locale_csv_eng[kvp.Key] + "</td>";
            //    ret += "</tr>";                
            //}
            //ret += "</table>";
            DataTableToExcel(result, "Locale", true);
            flushxlsxfile();
            //ret = JsonConvert.SerializeObject(result, Newtonsoft.Json.Formatting.Indented); 
            return fileName;
        }

        private string fileName = null; //文檔名
        private IWorkbook workbook = null;

        /// <summary>
        /// 將DataTable數據導入到excel中
        /// </summary>
        /// <param name="data">要導入的數據</param>
        /// <param name="isColumnWritten">DataTable的列名是否要導入</param>
        /// <param name="sheetName">要導入的excel的sheet的名稱</param>
        /// <returns>導入數據行數(包含列名那一行)</returns>
        public int DataTableToExcel(DataTable data, string sheetName, bool isColumnWritten)
        {
            //fileName = @"E:\11.xlsx";
            fileName = Path.GetTempFileName();
            int i = 0;
            int j = 0;
            int count = 0;
            ISheet sheet = null;

            FileStream fs = new FileStream(fileName, FileMode.OpenOrCreate, FileAccess.ReadWrite);
            //if (fileName.IndexOf(".xlsx") > 0) // 2007版本
            workbook = new XSSFWorkbook();
            //else if (fileName.IndexOf(".xls") > 0) // 2003版本
            //    workbook = new HSSFWorkbook();

            try
            {
                if (workbook != null)
                {
                    sheet = workbook.CreateSheet(sheetName);
                }
                else
                {
                    return -1;
                }

                if (isColumnWritten == true) //寫入DataTable的列名
                {
                    IRow row = sheet.CreateRow(0);
                    for (j = 0; j < data.Columns.Count; ++j)
                    {
                        row.CreateCell(j).SetCellValue(data.Columns[j].ColumnName);
                    }
                    count = 1;
                }
                else
                {
                    count = 0;
                }

                for (i = 0; i < data.Rows.Count; ++i)
                {
                    IRow row = sheet.CreateRow(count);
                    for (j = 0; j < data.Columns.Count; ++j)
                    {
                        row.CreateCell(j).SetCellValue(data.Rows[i][j].ToString());
                    }
                    ++count;
                }
                workbook.Write(fs); //寫入到excel
                return count;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Exception: " + ex.Message);
                return -1;
            }
        }

        protected void flushxlsxfile()
        {
            var bufferSize = 102400;
            var buffer = new byte[bufferSize];
            var fs = new FileStream(fileName,
                FileMode.Open, FileAccess.Read);
            //輸出檔案的位元組總長度
            var outputLength = fs.Length;
            //每次讀取的位元組長度
            var readLength = 0;

            Context.Response.Clear();
            Context.Response.AddHeader(
                "Content-Length", outputLength.ToString());
            Context.Response.ContentType = "application/vnd.ms-excel";
            Context.Response.AddHeader(
                "content-disposition",
                "attachment; filename=" + Path.GetFileNameWithoutExtension(fileName) + ".xlsx");

            //剩餘位元組長度大於零，且與瀏覽器連接著，就繼續執行
            while (outputLength > 0 && Context.Response.IsClientConnected)
            {
                readLength = fs.Read(buffer, 0, bufferSize);
                Context.Response.OutputStream.Write(buffer, 0, readLength);
                Context.Response.Flush();
                outputLength = outputLength - readLength;
            }

            fs.Close();
            Context.Response.End();
        }

        [WebMethod]
        public string StoreGameData(string arg_gamedata_json)
        {
            JObject jo_gamedata = JObject.Parse(arg_gamedata_json);
            string timeStamp = ((int)(DateTime.UtcNow - new DateTime(1970, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc)).TotalSeconds).ToString();

            StreamWriter monster = new StreamWriter(Server.MapPath("~/json/") + "/Monster_" + timeStamp + ".txt");

            string tbl_title;

            tbl_title = "";
            if (jo_gamedata["data"]["monsters"] != null)
            {
                if (jo_gamedata["data"]["monsters"].Count() > 0)
                {
                    int tbl_col_cnt = (jo_gamedata["data"]["monsters"][0].ToString().Split('|')).Count();
                    for (int i = 0; i < tbl_col_cnt; i++)
                        tbl_title += "col_" + (i + 1).ToString() + "|";
                    tbl_title = tbl_title.Substring(0, tbl_title.Length - 1);

                    monster.Write(tbl_title);
                    foreach (string ln in jo_gamedata["data"]["monsters"])
                        monster.Write("\r\n" + ln.Replace("\r\n", "char(10)"));
                }
            }
            monster.Close();

            if (File.Exists(Server.MapPath("~/") + "/Monster.txt"))
                File.Delete(Server.MapPath("~/") + "/Monster.txt");
            File.Copy(Server.MapPath("~/json/") + "/Monster_" + timeStamp + ".txt", Server.MapPath("~/") + "/Monster.txt");

            return "success";
        }

        [WebMethod]
        public string GetAttribute(string MonsterID)
        {
            string attr = "", attr_type = "", realMonsterID = "";

            MonsterID = MonsterID.Trim();
            realMonsterID = MonsterID;
            DataTable dt_monsters, dt_monsterSkins;
            dt_monsters = TxtConvertToDataTable("~/Monster.txt", "Monster", "|");
            dt_monsterSkins = TxtConvertToDataTable("~/monsterSkins.txt", "monsterSkins", "|");
            if ((MonsterID.Substring(0, 1) == "6") && (MonsterID.Length == 4))
            {
                var query_skin = from c in dt_monsterSkins.AsEnumerable()
                                 where c.Field<string>("col_1") == MonsterID.Substring(1, 3)
                                 select c;
                foreach (DataRow dr in query_skin)
                {
                    realMonsterID = dr[1].ToString();
                }
            }
            var query_mons = from c in dt_monsters.AsEnumerable()
                             where c.Field<string>("col_1") == realMonsterID
                             select c;
            foreach (DataRow dr in query_mons)
            {
                attr = dr[4].ToString();
                attr_type = dr[67].ToString();
            }
            return attr_type + "_" + attr;
        }

        [WebMethod]
        [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
        public string HelloWorld()
        {
            string mes = "success";
            try
            {
                Context.Response.Output.Write("testtesttesttest");
            }
            catch (Exception e)
            {
                mes = e.Message.ToString();
            }
            return "test";
        }
    }
}
