using UnityEngine;
using System.Collections;
using Pilgrim.EnumTypes;

public class Rangeable : Interactable {

    public Rigidbody m_projectile;
    public Transform m_shootingPosition;

    override public void Respond(PlayerManager manager)
    {
        // Arbitrary spawn distance
        float spawnDistance = 1.5F;

        // Generate the projectile
        Rigidbody projectile = Instantiate(
            m_projectile,
            m_shootingPosition.position + spawnDistance * m_shootingPosition.forward,
            m_shootingPosition.localRotation) as Rigidbody;

        // Send the projectile in the direction that the camera is facing
        projectile.AddForce(
            manager.gameObject.GetComponentInChildren<Camera>().transform.forward * 
            projectile.GetComponent<ProjectileController>().Force()
        );
    }

    public ProjectileType m_targeted;

    public void OnCollisionEnter(Collision col)
    {
        
        // If the object is hit by the projectile,
        // it is weak against, then destroy the object
        /*if (col.gameObject.GetComponent<ProjectileController>().type == m_targeted)
        {
            Debug.Log(this);
            Debug.Log(col.gameObject);
            Debug.Log(gameObject.GetComponent<RangedInteraction>());
            gameObject.GetComponent<RangedInteraction>()
                .InteractWithProjectile(
                    this,
                    col.gameObject.GetComponent<ProjectileController>()
                );
        }*/

        // Always destroy the projectile
        Destroy(col.gameObject);
    }

}
