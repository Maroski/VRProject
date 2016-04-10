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
        int c = 0;
        EAbility e = m_Skill.GetPrereq(c++);
        while( e != EAbility.None)
        {
            if (!manager.HasSkill(e))
            {
                Debug.Log("Does not meet Prereqs!");
                return;
            }
            e = m_Skill.GetPrereq(c++);
        }

        c = 0;
        e = m_Skill.GetAntireq(c++);
        while (e != EAbility.None)
        {
            if (manager.HasSkill(e))
            {
                Debug.Log("Cannot learn due to Antireqs!");
                return;

            }
            e = m_Skill.GetAntireq(c++);
        }
        manager.LearnSkill(m_Skill.GetSkillType());
    }
}
