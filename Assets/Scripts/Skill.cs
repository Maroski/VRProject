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
    public EAbility GetPrereq(int index) { return (index < m_Prereqs.Length) ? m_Prereqs[index] : EAbility.None; }
    public EAbility GetAntireq(int index) { return (index < m_Antireqs.Length) ? m_Antireqs[index] : EAbility.None; }

    // TODO: we may want to make this a bit more robust by moving it out to a skill tree class
    public static Skill GetSkill(EAbility ability)
    {
        for (int i = 0; i < Skill.skills.Length; i++)
        {
            if (Skill.skills[i].GetSkillType() == ability)
            {
                return Skill.skills[i];
            }
        }
        // Skill does not exist. Force error to alert developer.
        Debug.Assert(false);
        return null;
    }
    
    // TODO: Once again, a skill tree class could make this cleaner.
    private static Skill[] skills = { new Skill(EAbility.Climb, new EAbility[] { }, new EAbility[] { }),
                                      new Skill(EAbility.Mount, new EAbility[] { EAbility.Jump }, new EAbility[] { }),
                                      new Skill(EAbility.Push,  new EAbility[] { }, new EAbility[] { }),
                                      new Skill(EAbility.Talk,  new EAbility[] { }, new EAbility[] { }),
                                      new Skill(EAbility.Fireball,  new EAbility[] { EAbility.Talk }, new EAbility[] { EAbility.Icestorm }),
                                      new Skill(EAbility.Icestorm,  new EAbility[] { EAbility.Talk }, new EAbility[] { EAbility.Fireball }) };
}
