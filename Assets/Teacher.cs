using UnityEngine;
using System.Collections;
using Pilgrim.EnumTypes;

public class Teacher : MonoBehaviour {
    public EAbility m_Type; // To be set in the IDE

    public void TeachAbility(PlayerManager manager)
    {
        manager.AcquireSkill(m_Type);
    }
}
