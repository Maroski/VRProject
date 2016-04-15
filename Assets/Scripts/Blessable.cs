using UnityEngine;
using System.Collections;
using Pilgrim.Controller;
using Pilgrim.EnumTypes;
using System.Collections.Generic;

public class Blessable : Interactable {

    public Rigidbody m_projectile;
    public ProjectileType m_blessing;

    public float SHRINE_EFFECTIVE_RANGE = 15.0F;

    private PlayerManager m_Manager;

    override public void Start()
    {
        m_Prereqs = new List<EAbility>();
        m_Prereqs.Add(EAbility.Fireball);
    }

    override protected void Respond(PlayerManager m)
    {
        m_Manager = m;
        m.ChangeContext(new BlessingController(m, m_blessing, m_projectile));
    }

    public void Update()
    {
        if (m_Manager != null)
        {
            if (Vector3.Distance(m_Manager.transform.position, gameObject.transform.position) > SHRINE_EFFECTIVE_RANGE)
            {
                m_Manager.ChangeContext(new DefaultController(m_Manager));
                m_Manager = null;
            }
        }
    }
}
