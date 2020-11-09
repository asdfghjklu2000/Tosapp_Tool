using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Tosapp_Tool
{
    public class TosMonsterRefine
    {
        public string Effect { get; set; }
        public string CostNum { get; set; }
    }
    public class TosMonsterInfo
    {
        public string Name { get; set; }
        public string Series { get; set; }
        public string Size { get; set; }
        public string CardType { get; set; } //進化卡 進化素材卡 強化素材卡
        public string Star { get; set; }
        public string Race { get; set; }
        public string Attribute { get; set; }
        public string MinLevel { get; set; }
        public string MaxLevel { get; set; }
        public string MinHp { get; set; }
        public string IniHp { get; set; }
        public string MaxHp { get; set; }
        public string MinAttack { get; set; }
        public string IniAttack { get; set; }
        public string MaxAttack { get; set; }
        public string MinRecovery { get; set; }
        public string IniRecovery { get; set; }
        public string MaxRecovery { get; set; }
        public string DualMaxHp { get; set; }
        public string DualMaxAttack { get; set; }
        public string DualMaxRecovery { get; set; }
        public string ExpCurve { get; set; }
        public string MaxLevelExp { get; set; }
        public string MergeExp { get; set; }
        public string IncMergeExp { get; set; }
        public string SellCoin { get; set; }
        public string IncSellCoin { get; set; }
        public string Story { get; set; }
        public string Comment { get; set; }
        public List<TosMonsterRefine> RefineData { get; set; }
        //public string Refine1 { get; set; }
        //public string Refine1Num { get; set; }
        //public string Refine2 { get; set; }
        //public string Refine2Num { get; set; }
        //public string Refine3 { get; set; }
        //public string Refine3Num { get; set; }
        //public string Refine4 { get; set; }
        //public string Refine4Num { get; set; }
        public string LeaderSkill { get; set; }
        public string NormalSkill1 { get; set; }
        public string NormalSkill2 { get; set; }
    }
}