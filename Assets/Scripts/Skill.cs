using System;
using UnityEngine;
using Pilgrim.EnumTypes;

public class Skill
{
    private EAbility m_Type;
    private EAbility[] m_Prereqs;
    private EAbility[] m_Antireqs;

    private Skill(EAbility type, EAbility[] prereqs, EAbility[] antireqs) {
        m_Type = type;
        m_Prereqs = new EAbility[prereqs.Length];
        m_Antireqs = new EAbility[antireqs.Length];

        prereqs.CopyTo(m_Prereqs, 0);
        antireqs.CopyTo(m_Antireqs, 0);
    }

    public EAbility GetSkillType() { return m_Type; }

    public bool IsPrereq(EAbility ability)
    {
        for (int i = 0; i < m_Prereqs.Length; i++)
        {
            if (m_Prereqs[i] == ability) return true;
        }
        return false;
    }

    public bool IsAntireq(EAbility ability)
    {
        for (int i = 0; i < m_Antireqs.Length; i++)
        {
            if (m_Antireqs[i] == ability) return true;
        }
        return false;
    }

    public static Skill GetSkill(EAbility ability)
    {
        for (int i = 0; i < Skill.skills.Length; i++)
        {
            if(Skill.skills[i].GetSkillType() == ability)
            {
                return Skill.skills[i];
            }
        }
        // Skill does not exist. Force error to alert developer.
        Debug.Assert(false);
        return null;
    }

    private static Skill[] skills = { new Skill(EAbility.Climb, new EAbility[] { }, new EAbility[] { }),
                                      new Skill(EAbility.Mount, new EAbility[] { }, new EAbility[] { }),
                                      new Skill(EAbility.Push,  new EAbility[] { }, new EAbility[] { }),
                                      new Skill(EAbility.Talk,  new EAbility[] { }, new EAbility[] { }) };
}
