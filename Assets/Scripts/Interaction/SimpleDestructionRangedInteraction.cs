using UnityEngine;
using System.Collections;
using Pilgrim.EnumTypes;
using Pilgrim.Controller;
using Pilgrim.Player;


namespace Pilgrim.Interaction
{
    public class SimpleDestructionRangedInteraction : RangedInteraction
    {
        // Destroy the target of the projectile when hit
        override public void InteractWithProjectile(ProjectileController pc)
        {
            // If the object is hit by the projectile,
            // it is weak against, then destroy the object
            if (pc.type == m_targeted)
            {
                Destroy(pc.gameObject);
                Destroy(gameObject);
            }

        }
    }
}
