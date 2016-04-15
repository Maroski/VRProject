using UnityEngine;
using System.Collections;
using Pilgrim.EnumTypes;

// Extend this class to generalize ranged interaction behaviours
abstract public class RangedInteraction : MonoBehaviour
{
    abstract public void InteractWithProjectile(RangedInteraction ptc, ProjectileController pc);

    public ProjectileType m_targeted;

    public void OnCollisionEnter(Collision col)
    {
        gameObject.GetComponent<RangedInteraction>()
                .InteractWithProjectile(
                    this,
                    col.gameObject.GetComponent<ProjectileController>()
        );
        
    }
}
