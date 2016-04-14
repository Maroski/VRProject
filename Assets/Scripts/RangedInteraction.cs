using UnityEngine;
using System.Collections;

// Extend this class to generalize ranged interaction behaviours
abstract public class RangedInteraction : MonoBehaviour
{
    abstract public void InteractWithProjectile(ProjectileTargetController ptc, ProjectileController pc);
}
