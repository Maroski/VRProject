using UnityEngine;
using System.Collections;
using Pilgrim.Controller;

public class Blessable : Interactable {

    public Rigidbody m_projectile;

    override public void Respond(PlayerManager m)
    {
        BlessingController controller = m.Controller() as BlessingController;
        Shrine shrine = gameObject.GetComponent<Shrine>();

        // If interacting with a shrin of the same ability as you already have,
        // deactivate the ability, otherwise get the new ability
        if (controller != null && (controller.m_blessing == shrine.m_blessing))
        {
            Debug.Log("Deavctivated mah powerzzz");
            m.ChangeContext(new DefaultController(m));
        }
        else
        {
            m.ChangeContext(new BlessingController(m, shrine.m_blessing, m_projectile/*, shrine.transform.position*/));
        }
    }
}
