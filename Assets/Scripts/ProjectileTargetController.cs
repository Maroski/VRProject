using UnityEngine;
using System.Collections;

// Models the OnCollision of an object capable of being hit by a projectile
public class ProjectileTargetController : MonoBehaviour {

    // Move the burden of detecting and handling collisions to the object being targeted

    public ProjectileController.ProjectileType m_targeted;

    public void OnCollisionEnter(Collision col)
    {
        
        // If the object is hit by the projectile,
        // it is weak against, then destroy the object
        if (col.gameObject.GetComponent<ProjectileController>().type == m_targeted)
        {
            Debug.Log(this);
            Debug.Log(col.gameObject);
            Debug.Log(gameObject.GetComponent<RangedInteraction>());
            gameObject.GetComponent<RangedInteraction>()
                .InteractWithProjectile(
                    this,
                    col.gameObject.GetComponent<ProjectileController>()
                );
        }

        // Always destroy the projectile
        Destroy(col.gameObject);
    }
}
