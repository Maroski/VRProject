using UnityEngine;
using System.Collections;
using Pilgrim.EnumTypes;

// Extend this class to generalize ranged interaction behaviours
abstract public class RangedInteraction : MonoBehaviour
{
    abstract public void InteractWithProjectile(ProjectileController pc);

    public ProjectileType m_targeted;

    public void OnCollisionEnter(Collision col)
    {
        
        ProjectileController ptc = col.gameObject.GetComponent<ProjectileController>();

        if (ptc != null)
        {
            InteractWithProjectile(ptc);
        }
        
    }
}
