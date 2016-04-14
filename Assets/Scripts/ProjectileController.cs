using UnityEngine;
using System.Collections;

// Models a projectile, handlies lifetime, and force
public class ProjectileController : MonoBehaviour {

    // Enum of all possible creatable projectile types
    public enum ProjectileType
    {
        None,
        Fireball
    }

    // Maximum time for a projectile to live
    private readonly float TIME_TO_LIVE = 5.0F;
    private float m_hasLived; // Time spent living
    public float m_force; // Force of the projectile

    public ProjectileType type;

    // Start the lifetime counter
    void Start () {
        m_hasLived = 0.0F;
    }
    
    // Update is called once per frame to check
    // whether the projectile has exceeded its lifespan
    // (flown too long without colliding with something)
    void Update () {
        m_hasLived += Time.deltaTime;

        if (m_hasLived >= TIME_TO_LIVE)
        {
            Destroy(gameObject);
        }
    }

    // Return the force of the projectile
    public float Force()
    {
        return m_force;
    }
}
