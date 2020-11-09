using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Tosapp_Tool
{
    public class MySoulSkillProperty
    {
        private int _index;
        private int _type;
        private int[] _values;
        private int _isAwakenSkill;
        private float _awakenBonus;
        private int _floorId;

        public MySoulSkillProperty(int index, int type, int arg0, int arg1, int arg2, int arg3, int isAwakenSkill, float awakenBonus, int floorId)
        {
            this._index = index;
            this._type = type;
            this._values = new int[4];
            this._values[0] = arg0;
            this._values[1] = arg1;
            this._values[2] = arg2;
            this._values[3] = arg3;
            this._isAwakenSkill = isAwakenSkill;
            this._awakenBonus = awakenBonus;
            this._floorId = floorId;
        }

        public string Description()
        {
            string text = string.Empty;
            int type = this._type;
            switch (type)
            {
                case 0:
                    {
                        string arg_139_0 = "SOUL_DESC_";
                        int type2 = (int)this._type;
                        string str = arg_139_0 + type2.ToString();
                        text = Locale.t(str);
                        return text;
                    }
                case 1:
                case 2:
                case 3:
                case 4:
                case 5:
                case 6:
                case 7:
                case 8:
                case 9:
                    {
                        string arg_165_0 = "SOUL_DESC_";
                        int type3 = (int)this._type;
                        string str2 = arg_165_0 + type3.ToString();
                        text = Locale.t(str2, new object[]{"@num",this._values[0]});
                        return text;
                    }
                case 10:
                    {
                        string arg_36D_0 = "SOUL_DESC_";
                        int type4 = (int)this._type;
                        string str3 = arg_36D_0 + type4.ToString();
                        string text2 = Locale.t("LEADER_" + this._values[0].ToString());
                        text = Locale.t(str3, new object[]{"@leaderskill",text2});
                        return text;
                    }
                case 11:
                    {
                        string arg_30E_0 = "SOUL_DESC_";
                        int type5 = (int)this._type;
                        string str4 = arg_30E_0 + type5.ToString();
                        string text3 = Locale.t("NORMAL_" + this._values[0].ToString());
                        text = Locale.t(str4, new object[]{"@normalskill",text3});
                        return text;
                    }
                case 12:
                    {
                        string arg_3CC_0 = "SOUL_DESC_";
                        int type6 = (int)this._type;
                        string str5 = arg_3CC_0 + type6.ToString();
                        text = Locale.t(str5, new object[]{"@attr","e" + this._values[0].ToString()});
                        return text;
                    }
                case 13:
                    {
                        string arg_422_0 = "SOUL_DESC_";
                        int type7 = (int)this._type;
                        string str6 = arg_422_0 + type7.ToString();
                        text = Locale.t(str6, new object[]{"@race","r" + this._values[0].ToString()});
                        return text;
                    }
                case 14:
                case 15:
                case 16:
                case 17:
                case 18:
                case 19:
                case 25:
                case 29:
                    {
                        string arg_478_0 = "SOUL_DESC_";
                        int type8 = (int)this._type;
                        string str7 = arg_478_0 + type8.ToString();
                        text = Locale.t(str7, new object[]{"@num",this._values[0].ToString(),"@value",this._values[1].ToString()});
                        return text;
                    }
                case 20:
                    {
                        string arg_4DC_0 = "SOUL_DESC_";
                        int type9 = (int)this._type;
                        string str8 = arg_4DC_0 + type9.ToString();
                        string text4 = Element.ToLocaleString(this._values[1]);
                        text = Locale.t(str8, new object[]{"@num",this._values[0].ToString(),"@element",text4,"@value",this._values[2].ToString()});
                        return text;
                    }
                case 21:
                    {
                        string arg_561_0 = "SOUL_DESC_";
                        int type10 = (int)this._type;
                        string str9 = arg_561_0 + type10.ToString();
                        string text5 = Element.ToLocaleString(this._values[0]);
                        text = Locale.t(str9, new object[]{"@element",text5,"@value",this._values[1].ToString()});
                        return text;
                    }
                case 22:
                    {
                        string arg_5CE_0 = "SOUL_DESC_";
                        int type11 = (int)this._type;
                        string str10 = arg_5CE_0 + type11.ToString();
                        string text6 = Locale.t("NORMAL_" + this._values[0].ToString());
                        text = Locale.t(str10, new object[]{"@normalskill",text6});
                        return text;
                    }
                case 23:
                case 37:
                    {
                        string arg_62D_0 = "SOUL_DESC_";
                        int type12 = (int)this._type;
                        string str11 = arg_62D_0 + type12.ToString();
                        text = Locale.t(str11, new object[]{"@value",this._values[0].ToString()});
                        return text;
                    }
                case 24:
                    {
                        string text7 = Element.ToLocaleString(this._values[0]);
                        string text8 = Element.ToLocaleString(this._values[1]);
                        string arg_6A1_0 = "SOUL_DESC_";
                        int type13 = (int)this._type;
                        string str12 = arg_6A1_0 + type13.ToString();
                        text = Locale.t(str12, new object[]{"@value",this._values[2].ToString(),"@element1",text7,"@element2",text8});
                        return text;
                    }
                case 26:
                case 27:
                    {
                        int[] array = new int[]{1,2,3};
                        for (int i = 0; i < 3; i++)
                        {
                            if (this._values[i] > 0)
                            {
                                string arg_290_0 = "SOUL_DESC_";
                                int num = array[i];
                                string str14 = arg_290_0 + num.ToString();
                                if (text.Length > 0)
                                {
                                    text += "\n";
                                }
                                text += Locale.t(str14, new object[]{"@num",this._values[i]});
                            }
                        }
                        return text;
                    }
                case 28:
                    {
                        int[] array2 = new int[]{5,4,6};
                        for (int j = 0; j < 3; j++)
                        {
                            if (this._values[j] > 0)
                            {
                                string arg_1E4_0 = "SOUL_DESC_";
                                int num2 = array2[j];
                                string str15 = arg_1E4_0 + num2.ToString();
                                if (text.Length > 0)
                                {
                                    text += "\n";
                                }
                                text += Locale.t(str15, new object[]{"@num",this._values[j]});
                            }
                        }
                        return text;
                    }
                case 30:
                    {
                        string str16 = "MONSTER_" + this._values[0].ToString() + "_SOUL_" + this._values[1].ToString();
                        text = Locale.t(str16);
                        return text;
                    }
                case 31:
                case 34:
                    {
                        string arg_73F_0 = "SOUL_DESC_";
                        int type15 = this._type;
                        string str17 = arg_73F_0 + type15.ToString();
                        text = Locale.t(str17, new object[]{"@num",this._values[0].ToString(),"@race",Common.Race2Name((global::Monster.RacialType)this._values[1], true),"@value",this._values[2].ToString()});
                        return text;
                    }
                case 32:
                    {
                        string arg_837_0 = "SOUL_DESC_";
                        int type16 = this._type;
                        string str18 = arg_837_0 + type16.ToString();
                        text = Locale.t(str18, new object[]{"@num",this._values[0].ToString(),"@element",Element.ToLocaleString(this._values[1]),"@value",this._values[2].ToString()});
                        return text;
                    }
                case 33:
                    {
                        string arg_8B8_0 = "SOUL_DESC_";
                        int type17 = (int)this._type;
                        string str19 = arg_8B8_0 + type17.ToString();
                        text = Locale.t(str19, new object[]{"@num",this._values[0].ToString(),"@element",Element.ToLocaleString(this._values[1]),"@value",this._values[2].ToString()});
                        return text;
                    }
                case 35:
                    {
                        string arg_939_0 = "SOUL_DESC_";
                        int type18 = (int)this._type;
                        string str20 = arg_939_0 + type18.ToString();
                        string text9 = Locale.t("NORMAL_" + this._values[0].ToString());
                        text = Locale.t(str20, new object[]{"@normalskill",text9});
                        return text;
                    }
                case 36:
                    {
                        string arg_998_0 = "SOUL_DESC_";
                        int type19 = (int)this._type;
                        string str21 = arg_998_0 + type19.ToString();
                        string text10 = Element.ToLocaleString(this._values[0]);
                        string text11 = Element.ToLocaleString(this._values[2]);
                        text = Locale.t(str21, new object[]{"@element1",text10,"@value",this._values[1].ToString(),"@element2",text11});
                        return text;
                    }
                case 38:
                case 39:
                    {
                        string arg_7D3_0 = "SOUL_DESC_";
                        int type20 = (int)this._type;
                        string str22 = arg_7D3_0 + type20.ToString() + "_" + this._values[1].ToString();
                        text = Locale.t(str22, new object[]{"@num",this._values[0].ToString(),"@value",this._values[2].ToString()});
                        return text;
                    }
                case 40:
                case 41:
                case 42:
                    {
                        string arg_A26_0 = "SOUL_DESC_";
                        int type21 = (int)this._type;
                        string str23 = arg_A26_0 + type21.ToString();
                        text = Locale.t(str23, new object[]{"@num",this._values[0].ToString(),"@value",this._values[2].ToString()});
                        return text;
                    }
                case 43:
                    {
                        string str24 = "SOUL_DESC_" + this._values[0].ToString();
                        text = Locale.t(str24);
                        return text;
                    }
                case 10001:
                case 10002:
                case 10003:
                case 10004:
                case 10005:
                case 10006:
                case 10007:
                case 10008:
                case 10009:
                case 10010:
                case 10011:
                case 10012:
                case 10013:
                case 10014:
                case 10015:
                case 10016:
                case 10017:
                case 10018:
                case 10019:
                    {
                        string arg_A8A_0 = "SOUL_DESC_";
                        int type14 = (int)this._type;
                        string str13 = arg_A8A_0 + type14.ToString();
                        text = Locale.t(str13);
                        return text;
                    }
                default:
                    text = string.Empty;
                    return text;
            }
        }
    }
}