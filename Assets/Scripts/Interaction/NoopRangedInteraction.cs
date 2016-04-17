using UnityEngine;
using System.Collections;
using Pilgrim.Controller;

namespace Pilgrim.Interaction
{
    public class NoopRangedInteraction : RangedInteraction
    {
        // Destroy the target of the projectile when hit
        override public void InteractWithProjectile(ProjectileController pc)
        {
            Destroy(pc.gameObject);
        }
    }
}
