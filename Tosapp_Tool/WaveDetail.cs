using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Tosapp_Tool
{
    public class WaveDetail
    {
        //public int WaveId { get; set; }
        public int WaveDetailId { get; set; }
        public string MonsterId { get; set; }
        public string AckNum { get; set; }
        public string Duration { get; set; }
        public string IniDuration { get; set; }
        public string HpNum { get; set; }
        public string DefNum { get; set; }
        public string DropType { get; set; }
        public string DropId { get; set; }
        public string DropLevel { get; set; }
        public string DropCoin { get; set; }
        public string PVEScore { get; set; }
        public string MultiBloodFlag { get; set; }
        public string MultiBloodLevel { get; set; }
        public string EnemySkill { get; set; }
        public string EscapeRound { get; set; }
    }
}