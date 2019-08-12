using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Tosapp_Tool{
    public enum SoulSkillType
    {
        // SoulSkillType
        Buff_Atk = 5,

        // SoulSkillType
        Buff_Atk_HP_Recover = 28,

        // SoulSkillType
        Buff_Atk_HP_Recover_Percent = 27,

        // SoulSkillType
        Buff_Atk_Percent = 2,

        // SoulSkillType
        Buff_ElementWithAnotherElement = 24,

        // SoulSkillType
        Buff_HP = 4,

        // SoulSkillType
        Buff_HP_Percent = 1,

        // SoulSkillType
        Buff_Recover = 6,

        // SoulSkillType
        Buff_Recover_Percent = 3,

        // SoulSkillType
        Change_CoolDown = 8,

        // SoulSkillType
        Change_TeamSize = 7,

        // SoulSkillType
        ChangeAwakeningPassiveSkill10001 = 10001,

        // SoulSkillType
        ChangeAwakeningPassiveSkill10002 = 10002,

        // SoulSkillType
        ChangeAwakeningPassiveSkill10003 = 10003,

        // SoulSkillType
        ChangeAwakeningPassiveSkill10004 = 10004,

        // SoulSkillType
        ChangeAwakeningPassiveSkill10005 = 10005,

        // SoulSkillType
        ChangeAwakeningPassiveSkill10006 = 10006,

        // SoulSkillType
        ChangeAwakeningPassiveSkill10007 = 10007,

        // SoulSkillType
        ChangeAwakeningPassiveSkill10008 = 10008,

        // SoulSkillType
        ChangeAwakeningPassiveSkill10009 = 10009,

        // SoulSkillType
        ChangeAwakeningPassiveSkill10010 = 10010,

        // SoulSkillType
        ChangeAwakeningPassiveSkill10011 = 10011,

        // SoulSkillType
        ChangeAwakeningPassiveSkill10012 = 10012,

        // SoulSkillType
        ChangeAwakeningPassiveSkill10013 = 10013,

        // SoulSkillType
        ChangeAwakeningPassiveSkill10014 = 10014,

        // SoulSkillType
        COUNT = 10015,

        // SoulSkillType
        Init_CoolDown = 9,

        // SoulSkillType
        None = 0,

        // SoulSkillType
        OnActiveSkill_ColumnSkill = 22,

        // SoulSkillType
        OnColumn_Add_Blood_By_Recover_Percent = 29,

        // SoulSkillType
        OnColumn_Buff_Atk_Percent = 17,

        // SoulSkillType
        OnColumn_Buff_Element_Atk_Percent = 32,

        // SoulSkillType
        OnColumn_Buff_Element_Recover_Percent = 33,

        // SoulSkillType
        OnColumn_Buff_Race_Atk_Percent = 34,

        // SoulSkillType
        OnColumn_Buff_Race_Recover_Percent = 31,

        // SoulSkillType
        OnColumn_Buff_Recover_Percent = 18,

        // SoulSkillType
        OnColumn_Buff_SpecifiIds_Atk_Percent = 38,

        // SoulSkillType
        OnColumn_Buff_SpecifiIds_Recover_Percent = 39,

        // SoulSkillType
        OnColumn_Buff_Team_Atk_Percent = 14,

        // SoulSkillType
        OnColumn_Buff_Team_Recover_Percent = 15,

        // SoulSkillType
        OnColumn_Change_CoolDown = 19,

        // SoulSkillType
        OnColumn_Change_Team_CoolDown = 16,

        // SoulSkillType
        OnColumn_GemDropCount = 20,

        // SoulSkillType
        OnColumn_GemDropRate = 21,

        // SoulSkillType
        OnColumn_GemDropRate2 = 36,

        // SoulSkillType
        OnColumn_ReduceDamage = 25,

        // SoulSkillType
        OnLeader_Change_ComboBonus = 23,

        // SoulSkillType
        OnLeaderOrHelper_Change_ComboBonus = 37,

        // SoulSkillType
        SkillChange_Active = 11,

        // SoulSkillType
        SkillChange_ActiveSkills = 35,

        // SoulSkillType
        SkillChange_Passive = 10,

        // SoulSkillType
        Special_Skill = 30,

        // SoulSkillType
        Sub_Element = 12,

        // SoulSkillType
        Sub_RacialType = 13,

        // SoulSkillType
        TeamInit_CoolDown = 26
    }
}
