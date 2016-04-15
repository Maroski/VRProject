using UnityEngine;
using System.Collections;
using Pilgrim.Controller;
using Pilgrim.EnumTypes;

public class BlessingController : DefaultController {

    public ProjectileType m_blessing;
    private Rigidbody m_projectile;

    private GameObject m_currentProjectile;

    public BlessingController(PlayerManager manager, ProjectileType type, Rigidbody projectile) : base (manager)
    {
        m_blessing = type;
        m_projectile = projectile;
        m_currentProjectile = null;
    }

    public override void OnClick()
    {
        if (m_currentProjectile == null)
        {
            FireProjectile();
        }
    }

    public void FireProjectile()
    {
        float spawnDistance = 1.5F;
        Rigidbody projectile = GameObject.Instantiate(
            m_projectile,
            m_Manager.transform.position + spawnDistance * m_Manager.GetMoveDir(),
            m_Manager.transform.rotation
        ) as Rigidbody;

        m_currentProjectile = projectile.gameObject;

        projectile.AddForce(
            m_Manager.GetLookDir() * projectile.GetComponent<ProjectileController>().Force()
        );
    }
}
