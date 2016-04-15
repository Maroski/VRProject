using System;

namespace Pilgrim.EnumTypes
{
    public enum EAbility {
        None, // used as a non-value
        Push,
        Climb,
        Talk,
        Jump,
        Mount,
        Fireball,
        Icestorm

    }

    // Enum of all possible creatable projectile types
    public enum ProjectileType
    {
        None,
        Fireball
    }
}
