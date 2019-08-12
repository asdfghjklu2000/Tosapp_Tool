using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

using System.Data.SqlClient;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.IO;
using System.Runtime.InteropServices;
using System.Data.OleDb;
using MH;
namespace Tosapp_Tool

{

    public partial class Floor_Translator : System.Web.UI.Page

    {

        public string[,] dict_boss_skill;

        public Dictionary<string, string> dic_boss_skill = new Dictionary<string, string>();

        public Dictionary<string, string> dict_locale_csv = new Dictionary<string, string>();

        public Dictionary<string, string> dict_locale_csv_eng = new Dictionary<string, string>();

        public Dictionary<string, Monster> dic_monster_data = new Dictionary<string, Monster>();

        string html_str;

        private string connectionstr;



        protected void Page_Load(object sender, EventArgs e)

        {
            Response.Redirect("Floor_Data.aspx");
            //html_str = "";
            //connectionstr = "Data Source=.;Initial Catalog=TOS;Persist Security Info=True;User ID=sa;Password=Hui78520";

            //loadLocaleCsv2();            
            //loadBossSkill2();
            //loadMonsterData2();
        }



        protected void loadMonsterData()
        {

            string SQLStr = "";

            SqlCommand DBID_SQLCommand;

            SqlConnection HISConn = new SqlConnection(connectionstr);

            SqlDataReader DBID_DataReader;

            HISConn.Open();

            Monster M_temp;

            SQLStr = " select * ";

            SQLStr += " from dbo.API_DATA_MONSTER_JSON ";



            DBID_SQLCommand = new SqlCommand(SQLStr, HISConn);

            DBID_DataReader = DBID_SQLCommand.ExecuteReader();



            if (DBID_DataReader.HasRows)

            {

                while (DBID_DataReader.Read())

                {

                    M_temp = new Monster();

                    M_temp.MONSTER_ID = DBID_DataReader["COL_1"].ToString();

                    M_temp.RACIAL_TYPE = DBID_DataReader["COL_4"].ToString();

                    M_temp.ATTRIBUTE = DBID_DataReader["COL_5"].ToString();

                    M_temp.STAR = DBID_DataReader["COL_6"].ToString();

                    M_temp.SIZE = DBID_DataReader["COL_8"].ToString();

                    M_temp.MAX_LEVEL = DBID_DataReader["COL_11"].ToString();

                    M_temp.EXP_TYPE = DBID_DataReader["COL_12"].ToString();

                    M_temp.ATTACK_DURATION = DBID_DataReader["COL_13"].ToString();

                    M_temp.LEADER_SKILL = DBID_DataReader["COL_14"].ToString();

                    M_temp.NORMAL_SKILL = DBID_DataReader["COL_15"].ToString();

                    M_temp.BASE_MERGE_EXP = DBID_DataReader["COL_16"].ToString();

                    M_temp.INC_MERGE_EXP = DBID_DataReader["COL_17"].ToString();

                    M_temp.BASE_SELL_COIN = DBID_DataReader["COL_18"].ToString();

                    M_temp.INC_SELL_COIN = DBID_DataReader["COL_19"].ToString();

                    M_temp.MIN_LOOT_COIN = DBID_DataReader["COL_20"].ToString();

                    M_temp.INC_LOOT_COIN = DBID_DataReader["COL_21"].ToString();

                    M_temp.MIN_CARD_HP = DBID_DataReader["COL_23"].ToString();

                    M_temp.MAX_CARD_HP = DBID_DataReader["COL_24"].ToString();

                    M_temp.MIN_CARD_ATTACK = DBID_DataReader["COL_25"].ToString();

                    M_temp.MAX_CARD_ATTACK = DBID_DataReader["COL_26"].ToString();

                    M_temp.MIN_CARD_RECOVER = DBID_DataReader["COL_27"].ToString();

                    M_temp.MAX_CARD_RECOVER = DBID_DataReader["COL_28"].ToString();

                    M_temp.MIN_ENEMY_HP = DBID_DataReader["COL_29"].ToString();

                    M_temp.INC_ENEMY_HP = DBID_DataReader["COL_30"].ToString();

                    M_temp.MIN_ENEMY_ATTACK = DBID_DataReader["COL_31"].ToString();

                    M_temp.INC_ENEMY_ATTACK = DBID_DataReader["COL_32"].ToString();

                    M_temp.MIN_ENEMY_DEFENSE = DBID_DataReader["COL_33"].ToString();

                    M_temp.INC_ENEMY_DEFENSE = DBID_DataReader["COL_34"].ToString();

                    M_temp.EVOLVE_MONSTER_ID = DBID_DataReader["COL_35"].ToString();

                    M_temp.EVOLVE_MATERIAL_MONSTER_ID0 = DBID_DataReader["COL_36"].ToString();

                    M_temp.EVOLVE_MATERIAL_MONSTER_ID1 = DBID_DataReader["COL_37"].ToString();

                    M_temp.EVOLVE_MATERIAL_MONSTER_ID2 = DBID_DataReader["COL_38"].ToString();

                    M_temp.EVOLVE_MATERIAL_MONSTER_ID3 = DBID_DataReader["COL_39"].ToString();

                    M_temp.EVOLVE_MATERIAL_MONSTER_ID4 = DBID_DataReader["COL_40"].ToString();

                    M_temp.IS_ULTIMATE_EVOLVABLE = DBID_DataReader["COL_46"].ToString();

                    M_temp.NORMAL_SKILL_ID2 = DBID_DataReader["COL_48"].ToString();

                    M_temp.FAKE_DOUBLE_SKILL = DBID_DataReader["COL_50"].ToString();

                    M_temp.SUPREME_EVOLVE_ID = DBID_DataReader["COL_51"].ToString();

                    M_temp.SUPREME_EVOLVE_SWITCH = DBID_DataReader["COL_52"].ToString();

                    M_temp.SUPREME_EVOLVE_MATERIALS = DBID_DataReader["COL_53"].ToString();

                    M_temp.SUPREME_EVOLVE_RATE = DBID_DataReader["COL_54"].ToString();

                    M_temp.HP_BONUS = DBID_DataReader["COL_55"].ToString();

                    M_temp.ATK_BONUS = DBID_DataReader["COL_56"].ToString();

                    M_temp.RECOVER_BONUS = DBID_DataReader["COL_57"].ToString();

                    M_temp.DEVOLVE_MONSTER_ID = DBID_DataReader["COL_58"].ToString();

                    M_temp.MP = DBID_DataReader["COL_59"].ToString();

                    M_temp.MP_CHARGE_TYPE = DBID_DataReader["COL_60"].ToString();



                    dic_monster_data.Add(DBID_DataReader["COL_1"].ToString(), M_temp);

                }

            }

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



        public DataTable TxtConvertToDataTable(string File, string TableName, string delimiter)

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

                string[] items = r.Split(delimiter.ToCharArray());

                ds.Tables[TableName].Rows.Add(items);

            }



            s.Close();



            dt = ds.Tables[0];



            return dt;

        }



        protected void loadLocaleCsv2()

        {

            MCSVFile m = MCSVFile.LoadBinary(Server.MapPath("~/locale.csv.txt"));

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

        protected void loadLocaleCsv()

        {

            string SQLStr = "";

            SqlCommand DBID_SQLCommand;

            SqlConnection HISConn = new SqlConnection(connectionstr);

            SqlDataReader DBID_DataReader;

            HISConn.Open();



            SQLStr = " select dict_key,dict_value,dict_value_eng ";

            SQLStr += " from dbo.locale_new ";



            DBID_SQLCommand = new SqlCommand(SQLStr, HISConn);

            DBID_DataReader = DBID_SQLCommand.ExecuteReader();



            //沒有需要更新的檔案

            if (!DBID_DataReader.HasRows)

            { }//txt_status.Text += "Nothing have to patch. At: " + DateTime.Now.ToString("HH:mm:ss.fff") + "\r\n";

            //需要更新，開始下載

            else

            {

                //用來接

                string text = string.Empty;

                string text1 = string.Empty;

                string text2 = string.Empty;



                while (DBID_DataReader.Read())

                {

                    text = DBID_DataReader["dict_key"].ToString();

                    text1 = DBID_DataReader["dict_value"].ToString();

                    text2 = DBID_DataReader["dict_value_eng"].ToString();



                    dict_locale_csv.Add(text, text1);

                    dict_locale_csv_eng.Add(text, text2);

                }

                //txt_status.Text += "Load Locale Csv Done. At: " + DateTime.Now.ToString("HH:mm:ss.fff") + "\r\n";

            }

            DBID_DataReader.Close();

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



        protected void loadBossSkill()

        {

            string SQLStr = "";

            SqlCommand DBID_SQLCommand;

            SqlConnection HISConn = new SqlConnection(connectionstr);

            SqlDataReader DBID_DataReader;

            HISConn.Open();

            int rowcount = 0;



            SQLStr = " select max(cast(boss_skill_no as decimal(10))) as cnt ";

            SQLStr += " from dbo.tosapp_boss_skill l,dbo.locale_new n ";

            SQLStr += " where 'BOSS_DESC_'+l.boss_skill_no=n.dict_key";

            DBID_SQLCommand = new SqlCommand(SQLStr, HISConn);

            DBID_DataReader = DBID_SQLCommand.ExecuteReader();

            DBID_DataReader.Read();

            rowcount = Int32.Parse(DBID_DataReader["CNT"].ToString());

            DBID_DataReader.Close();



            SQLStr = " select l.boss_skill_no as skill_no,l.boss_skill_name as skill_name,n.dict_value,l.boss_skill_desc as skill_pic ";

            SQLStr += " from dbo.tosapp_boss_skill l,dbo.locale_new n ";

            SQLStr += " where 'BOSS_DESC_'+l.boss_skill_no=n.dict_key order by cast(l.boss_skill_no as decimal(10))";

            DBID_SQLCommand.CommandText = SQLStr;

            DBID_DataReader = DBID_SQLCommand.ExecuteReader();



            //沒有需要更新的檔案

            if (!DBID_DataReader.HasRows)

            { }//txt_status.Text += "Nothing have to patch. At: " + DateTime.Now.ToString("HH:mm:ss.fff") + "\r\n";

            //需要更新，開始下載

            else

            {

                dict_boss_skill = new string[rowcount + 1, 3];

                dict_boss_skill[0, 0] = "沒有技能";

                dict_boss_skill[0, 1] = "沒有技能";

                dict_boss_skill[0, 2] = ""; //圖片

                //用來接

                string text = string.Empty;

                string text1 = string.Empty;

                string text2 = string.Empty;

                string text3 = string.Empty;

                string[] skill_pic;



                while (DBID_DataReader.Read())

                {

                    text = DBID_DataReader["SKILL_NO"].ToString();

                    text1 = DBID_DataReader["SKILL_NAME"].ToString();

                    text2 = DBID_DataReader["DICT_VALUE"].ToString();

                    text3 = DBID_DataReader["SKILL_PIC"].ToString();



                    skill_pic = text3.Split(new string[] { "SI" }, StringSplitOptions.None);

                    text3 = "";



                    for (int i = 1; i < skill_pic.Count(); i++)

                    {

                        text3 += "<img width=\"20\" height=\"20\" src=\"http://www.tosapp.tw/static/image/common/tos/mskill" + skill_pic[i] + ".png\"\\> ";

                    }



                    dict_boss_skill[Int32.Parse(text), 0] = text1;

                    dict_boss_skill[Int32.Parse(text), 1] = text2;

                    dict_boss_skill[Int32.Parse(text), 2] = text3;

                }

                //txt_status.Text += "Load Boss Skill Done. At: " + DateTime.Now.ToString("HH:mm:ss.fff") + "\r\n";

            }

            DBID_DataReader.Close();



            SQLStr = " select cast(l.boss_skill_no as decimal(10)) as skill_no,l.boss_skill_name as skill_name";

            SQLStr += " from dbo.tosapp_boss_skill l order by cast(l.boss_skill_no as decimal(10))";

            DBID_SQLCommand.CommandText = SQLStr;

            DBID_DataReader = DBID_SQLCommand.ExecuteReader();



            dic_boss_skill.Add("0", "沒有技能");





            if (!DBID_DataReader.HasRows)

            { }

            else

            {

                //用來接

                string text = string.Empty;

                string text1 = string.Empty;



                while (DBID_DataReader.Read())

                {

                    text = DBID_DataReader["SKILL_NO"].ToString();

                    text1 = DBID_DataReader["SKILL_NAME"].ToString();



                    dic_boss_skill.Add(text, text1);

                }

                //txt_status.Text += "Load Boss Skill(2) Done. At: " + DateTime.Now.ToString("HH:mm:ss.fff") + "\r\n";

            }

            DBID_DataReader.Close();

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



        protected void generateHtmlStr(string floorName)

        {

            string html_text = "";

            string title_color = "39393A";

            string title_word_color = "FFD973";

            if (txt_title_color.Text != "")

            {

                title_color = txt_title_color.Text;

            }

            if (txt_title_word_color.Text != "")

            {

                title_word_color = txt_title_word_color.Text;

            }



            html_text += "<html>";

            html_text += "<title></title>";

            html_text += "<head>";

            html_text += "<meta http-equiv=\"Content-Type\" content=\"text/html; charset=utf-8\">";



            html_text += "</head>";

            html_text += "<body>";

            html_text += "<p>※熾天使關卡資訊產生器 Design by Alex Hou</p>";

            html_text += "<table cellpadding=\"1\" cellspacing=\"1\" frame=\"border\" border=\"5\" style=\"font-family:微軟正黑體;\">";

            html_text += "<tr bgcolor=\"#" + title_color + "\"><td colspan=\"9\" align=\"center\"><font color=\"#" + title_word_color + "\"><b>" + floorName + "</b></font></td></tr>";

            //html_text += "<tr><td width=\"33\">層數</td><td width=\"179\">敵人</td><td width=\"66\">攻擊</td><td width=\"43\">CD </td><td width=\"59\">HP</td><td width=\"46\">防禦</td><td width=\"75\">掉落</td><td width=\"158\">備註</td></tr>";

            html_text += "<tr bgcolor=\"#EEEEEE\"><td align=\"center\">層數</td><td align=\"center\">敵人</td><td align=\"center\">攻擊</td><td align=\"center\">CD </td><td align=\"center\">HP</td><td align=\"center\">防禦</td><td align=\"center\">掉落</td><td align=\"center\">金幣</td><td align=\"center\" width=\"200\">備註</td></tr>";



            JObject jo_all = JObject.Parse(txt_floor_json.Text);

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

            for (int i = 0; i < ja_waves.Count; i++)

            {

                jo_waves = JObject.Parse(ja_waves[i].ToString());

                ja_enemies = JArray.Parse(jo_waves.GetValue("enemies").ToString());

                waveSkillId = "";

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

                        enemyHtml = showEnemyHtml(jo_enemies, ref checkNextEnemy, ref used_skill_html, ref wikia_text);

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



                                if (new_char != "0")

                                    enemyHtml = showEnemyHtml(jo_enemies, ref checkNextEnemy, ref used_skill_html, ref wikia_text);

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



            html_text += "<br><br>";

            html_text += "<table cellpadding=\"3\" cellspacing=\"3\" frame=\"border\" border=\"3\" style=\"font-family:微軟正黑體;\">";

            html_text += "<tr bgcolor=\"#39393A\"><td colspan=\"1\" align=\"center\"><font color=\"#FFD973\"><b>維基語法</b></font></td></tr>";

            html_text += "<tr>" + wikia_text + "</tr>";

            html_text += "</table>";

            html_text += "<br>";



            html_text += "<p>※熾天使關卡資訊產生器 Design by Alex Hou<br>Copyright © 2013-2015 Seraphim Raiders All rights reserved.</p>";



            html_text += "</body>";

            html_text += "</html>";



            html_str = html_text;

        }



        protected void saveHtmlToFile()

        {



            //generateHtmlStr("關卡資訊");

        }



        protected string showEnemyHtml(JObject jo_enemies, ref int times, ref string used_skill, ref string wikia_text)

        {

            JObject jo_extras;

            JObject jo_lootItem;

            JObject jo_nextEnemy;



            string html_text = "";



            //{{關卡數據|522|stage=|damage=16182|turn=3{{初始CD|3}}|hp=1826870|def=2020|coin=626|es=896}}

            wikia_text += "<tr><td>{{關卡數據|stage=|" + jo_enemies.GetValue("monsterId").ToString().PadLeft(3, '0');



            times++;



            html_text += "<td align=\"center\" >";//卡片id及名稱

            html_text += "<img width=\"40\" height=\"40\" src=\"/px100/" + jo_enemies.GetValue("monsterId").ToString() + ".png\">";

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

                }

                else

                {

                    int temp_atk = 0;

                    temp_atk += Int32.Parse(((Monster)dic_monster_data[jo_enemies.GetValue("monsterId").ToString()]).MIN_ENEMY_ATTACK.ToString());

                    temp_atk += (Int32.Parse(jo_enemies.GetValue("level").ToString()) - 1) * Int32.Parse(((Monster)dic_monster_data[jo_enemies.GetValue("monsterId").ToString()]).INC_ENEMY_ATTACK.ToString());

                    html_text += temp_atk.ToString();

                    wikia_text += "|damage=" + temp_atk.ToString();

                }

                html_text += "</td>"; //攻擊力



                html_text += "<td align=\"center\" >"; //cd

                if (jo_extras.GetValue("attackDuration") != null)

                {

                    html_text += jo_extras.GetValue("attackDuration").ToString();

                    wikia_text += "|turn=" + jo_extras.GetValue("attackDuration").ToString();

                }

                else

                {

                    int temp_cd = Int32.Parse(((Monster)dic_monster_data[jo_enemies.GetValue("monsterId").ToString()]).ATTACK_DURATION.ToString());

                    html_text += temp_cd.ToString();

                    wikia_text += "|turn=" + temp_cd.ToString();

                }



                if (jo_extras.GetValue("initAttackDuration") != null)

                {

                    html_text += "(" + jo_extras.GetValue("initAttackDuration").ToString() + ")"; //初始cd

                    wikia_text += "{{初始CD|" + jo_extras.GetValue("initAttackDuration").ToString() + "}}";

                }

                else if (jo_extras.GetValue("cdLock") != null)

                    if ((bool)jo_extras.GetValue("cdLock") == true)

                    {

                        if (jo_extras.GetValue("attackDuration") != null)

                        {

                            html_text += "(" + jo_extras.GetValue("attackDuration").ToString() + ")";

                            wikia_text += "{{初始CD|" + jo_extras.GetValue("attackDuration").ToString() + "}}";

                        }

                        else

                        {

                            int temp_cd = Int32.Parse(((Monster)dic_monster_data[jo_enemies.GetValue("monsterId").ToString()]).ATTACK_DURATION.ToString());

                            html_text += "(" + temp_cd.ToString() + ")";

                            wikia_text += "{{初始CD|" + temp_cd + "}}";

                        }

                    }//沒初始cd就看cdLock

                html_text += "</td>"; //cd



                html_text += "<td align=\"center\" >"; //血量

                if (jo_extras.GetValue("HP") != null)

                {

                    html_text += jo_extras.GetValue("HP").ToString();

                    wikia_text += "|hp=" + jo_extras.GetValue("HP").ToString();

                }



                else

                {

                    int temp_hp = 0;

                    temp_hp += Int32.Parse(((Monster)dic_monster_data[jo_enemies.GetValue("monsterId").ToString()]).MIN_ENEMY_HP.ToString());

                    temp_hp += (Int32.Parse(jo_enemies.GetValue("level").ToString()) - 1) * Int32.Parse(((Monster)dic_monster_data[jo_enemies.GetValue("monsterId").ToString()]).INC_ENEMY_HP.ToString());

                    html_text += temp_hp.ToString();

                    wikia_text += "|hp=" + temp_hp.ToString();

                }

                html_text += "</td>"; //血量



                html_text += "<td align=\"center\" >"; //防禦力

                if (jo_extras.GetValue("defense") != null)

                {

                    html_text += jo_extras.GetValue("defense").ToString();

                    wikia_text += "|def=" + jo_extras.GetValue("defense").ToString();

                }

                else

                {

                    int temp_def = 0;

                    temp_def += Int32.Parse(((Monster)dic_monster_data[jo_enemies.GetValue("monsterId").ToString()]).MIN_ENEMY_DEFENSE.ToString());

                    temp_def += (Int32.Parse(jo_enemies.GetValue("level").ToString()) - 1) * Int32.Parse(((Monster)dic_monster_data[jo_enemies.GetValue("monsterId").ToString()]).INC_ENEMY_DEFENSE.ToString());

                    html_text += temp_def.ToString();

                    wikia_text += "|def=" + temp_def.ToString();

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

                    }

                    else if (jo_lootItem.GetValue("type").ToString() == "monster")

                    {

                        html_text += JObject.Parse(jo_lootItem.GetValue("card").ToString()).GetValue("monsterId").ToString();

                        html_text += "<br><img width=\"40\" height=\"40\" src=\"/px100/" + JObject.Parse(jo_lootItem.GetValue("card").ToString()).GetValue("monsterId").ToString() + ".png\">";

                        html_text += "<br>LV " + JObject.Parse(jo_lootItem.GetValue("card").ToString()).GetValue("level").ToString(); //掉落卡片

                        wikia_text += "|drop=" + JObject.Parse(jo_lootItem.GetValue("card").ToString()).GetValue("monsterId").ToString().PadLeft(3, '0');

                        wikia_text += "|lv=" + JObject.Parse(jo_lootItem.GetValue("card").ToString()).GetValue("level").ToString();

                    }

                    else

                        html_text += "無";

                }

                else

                    html_text += "無";



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

                html_text += "</td>"; //攻擊力



                html_text += "<td align=\"center\" >"; //cd

                int temp_cd = Int32.Parse(((Monster)dic_monster_data[jo_enemies.GetValue("monsterId").ToString()]).ATTACK_DURATION.ToString());

                html_text += temp_cd.ToString() + "(" + temp_cd.ToString() + ")";

                wikia_text += "|turn=" + temp_atk.ToString() + "{{初始CD|" + temp_atk.ToString() + "}}";

                html_text += "</td>"; //cd



                html_text += "<td align=\"center\" >"; //血量

                int temp_hp = 0;

                temp_hp += Int32.Parse(((Monster)dic_monster_data[jo_enemies.GetValue("monsterId").ToString()]).MIN_ENEMY_HP.ToString());

                temp_hp += (Int32.Parse(jo_enemies.GetValue("level").ToString()) - 1) * Int32.Parse(((Monster)dic_monster_data[jo_enemies.GetValue("monsterId").ToString()]).INC_ENEMY_HP.ToString());

                html_text += temp_hp.ToString();

                wikia_text += "|hp=" + temp_hp.ToString();

                html_text += "</td>"; //血量



                html_text += "<td align=\"center\" >"; //防禦力

                int temp_def = 0;

                temp_def += Int32.Parse(((Monster)dic_monster_data[jo_enemies.GetValue("monsterId").ToString()]).MIN_ENEMY_DEFENSE.ToString());

                temp_def += (Int32.Parse(jo_enemies.GetValue("level").ToString()) - 1) * Int32.Parse(((Monster)dic_monster_data[jo_enemies.GetValue("monsterId").ToString()]).INC_ENEMY_DEFENSE.ToString());

                html_text += temp_def.ToString();

                wikia_text += "|def=" + temp_def.ToString();

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

                    }

                    else if (jo_lootItem.GetValue("type").ToString() == "monster")

                    {

                        html_text += JObject.Parse(jo_lootItem.GetValue("card").ToString()).GetValue("monsterId").ToString();

                        html_text += "<br><img width=\"40\" height=\"40\" src=\"/px100/" + JObject.Parse(jo_lootItem.GetValue("card").ToString()).GetValue("monsterId").ToString() + ".png\">";

                        html_text += "<br>LV " + JObject.Parse(jo_lootItem.GetValue("card").ToString()).GetValue("level").ToString(); //掉落卡片

                        wikia_text += "|drop=" + JObject.Parse(jo_lootItem.GetValue("card").ToString()).GetValue("monsterId").ToString().PadLeft(3, '0');

                        wikia_text += "|lv=" + JObject.Parse(jo_lootItem.GetValue("card").ToString()).GetValue("level").ToString();

                    }

                    else

                        html_text += "無";

                }

                else

                    html_text += "無";



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

            html_text += "</td>"; //金幣



            html_text += "<td align=\"center\">"; //備註

            if (jo_enemies.GetValue("escapeTurn") != null)

                if (jo_enemies.GetValue("escapeTurn").ToString() != "0")

                    html_text += "<font color=\"#E7A400\"><b>※敵人會在 " + jo_enemies.GetValue("escapeTurn").ToString() + " 回合後離開</b></font><br>";



            if ((jo_enemies.GetValue("nextEnemy") != null) || (times > 1))

            {

                html_text += "<font color=\"#FFBBBB\"><b>【多血第 " + times + " 血條】</b></font><br>";

            }

            if (jo_enemies.GetValue("characteristic").ToString() != "0")

            {

                html_text += "【" + "<font color=\"#3366FF\"><b>" + jo_enemies.GetValue("characteristic").ToString() + "</b></font>." + dict_boss_skill[Int32.Parse(jo_enemies.GetValue("characteristic").ToString()), 1] + dict_boss_skill[Int32.Parse(jo_enemies.GetValue("characteristic").ToString()), 0] + "】"; ; //維基技能名稱



                used_skill += "<tr><td>" + jo_enemies.GetValue("characteristic").ToString() + "</td><td>" + dict_boss_skill[Int32.Parse(jo_enemies.GetValue("characteristic").ToString()), 0] + "</td><td>";

                used_skill += readLocaleValue("BOSS_DESC_" + jo_enemies.GetValue("characteristic").ToString(), true).Replace("\n", "<br>") + "</td></tr>";



                wikia_text += "|es=" + jo_enemies.GetValue("characteristic").ToString();

                //html_text += "<br>";

                //html_text += readLocaleValue("BOSS_DESC_" + jo_enemies.GetValue("characteristic").ToString(), true);

            }



            html_text += "</td>"; //備註

            wikia_text += "}}</td></tr>"; //結束



            if (jo_enemies.GetValue("nextEnemy") != null)

            {

                jo_nextEnemy = JObject.Parse(jo_enemies.GetValue("nextEnemy").ToString());

                html_text += "</tr><tr>";

                html_text += showEnemyHtml(jo_nextEnemy, ref times, ref used_skill, ref wikia_text);

            }



            return html_text;

        }



        protected void Button1_Click(object sender, EventArgs e)

        {

            if (txt_floor_name.Text != "")

                generateHtmlStr(txt_floor_name.Text);

            else

                generateHtmlStr("關卡資訊");

            Response.Write(html_str);

        }

    }

}