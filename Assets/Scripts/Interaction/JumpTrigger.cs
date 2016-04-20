using UnityEngine;
using System.Collections;
using Pilgrim.Player;

public class JumpTrigger : MonoBehaviour {

    public float m_height = 3.0F;

    void OnTriggerEnter(Collider col)
    {
        PlayerManager pm = col.gameObject.GetComponent<PlayerManager>();
        if (pm != null)
        {
            pm.SetJumpPossible(true);
        }
    }

    void OnTriggerExit(Collider col)
    {
        PlayerManager pm = col.gameObject.GetComponent<PlayerManager>();
        if (pm != null)
        {
            pm.SetJumpPossible(false);
        }
    }
}
