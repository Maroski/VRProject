using UnityEngine;
using System.Collections;
using Pilgrim.EnumTypes;

public class Teacher : MonoBehaviour {
    [SerializeField] private Skill m_Skill;
    public EAbility m_Type; // To be set in the IDE

    public void Start()
    {
        m_Skill = Skill.GetSkill(m_Type);
    }

    public void TeachAbility(PlayerManager manager)
    {
        // TODO: take skill prereqs/antireqs into account
        manager.LearnSkill(m_Skill.GetSkillType());
    }
}
