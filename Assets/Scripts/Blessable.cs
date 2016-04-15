using UnityEngine;
using System.Collections;
using Pilgrim.Controller;
using Pilgrim.EnumTypes;

public class Blessable : Interactable {

    public Rigidbody m_projectile;
    public ProjectileType m_blessing;

    public readonly float SHRINE_EFFECTIVE_RANGE = 15.0F;

    private PlayerManager m_Manager;

    override public void Respond(PlayerManager m)
    {
        BlessingController controller = m.Controller() as BlessingController;

        // If interacting with a shrin of the same ability as you already have,
        // deactivate the ability, otherwise get the new ability
        if (controller != null && (controller.m_blessing == m_blessing))
        {
            Debug.Log("Deavctivated mah powerzzz");
            m_Manager = null;
            m.ChangeContext(new DefaultController(m));
        }
        else
        {
            m_Manager = m;
            m.ChangeContext(new BlessingController(m, m_blessing, m_projectile));
        }
    }

    public void Update()
    {
        if (m_Manager != null)
        {
            if (Vector3.Distance(m_Manager.GetPosition(), gameObject.transform.position) > SHRINE_EFFECTIVE_RANGE)
            {
                m_Manager.ChangeContext(new DefaultController(m_Manager));
                m_Manager = null;
            }
        }
    }
}
