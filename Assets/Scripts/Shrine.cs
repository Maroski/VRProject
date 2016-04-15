using UnityEngine;
using System.Collections;
using Pilgrim.EnumTypes;
using Pilgrim.Controller;

public class Shrine : MonoBehaviour {

    public ProjectileType m_blessing;

    public void OnTriggerEnter(Collider col)
    {
        Debug.Log("IN DA ZONE");
        Debug.Log(col.name);
    }

    public void onTriggerStay(Collider col)
    {
        Debug.Log("STILL IN DA ZONE!");
    }

    public void onTriggerExit(Collider col)
    {
        PlayerManager player = col.gameObject.GetComponent<PlayerManager>();
        Debug.Log("LOST MAH POWERZZZZ");
        player.ChangeContext(new DefaultController(player));
       
    }
}
