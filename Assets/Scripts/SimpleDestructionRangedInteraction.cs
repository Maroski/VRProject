using UnityEngine;
using System.Collections;

public class SimpleDestructionRangedInteraction : RangedInteraction
{
    // Destroy the target of the projectile when hit
    override public void InteractWithProjectile(ProjectileTargetController ptc, ProjectileController pc)
    {
        Destroy(ptc.gameObject);
    }
}
