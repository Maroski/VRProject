using UnityEngine;
using System.Collections;

public class NoopRangedInteraction : RangedInteraction
{
    // Destroy the target of the projectile when hit
    override public void InteractWithProjectile(ProjectileController pc)
    {
        Destroy(pc.gameObject);
    }
}
