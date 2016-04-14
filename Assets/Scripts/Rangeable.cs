using UnityEngine;
using System.Collections;

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

}
