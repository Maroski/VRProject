using UnityEngine;
using System.Collections;
using Pilgrim.Player;

namespace Pilgrim.Trigger
{
    public class KillTrigger : MonoBehaviour
    {
        public void OnTriggerEnter(Collider other)
        {
            PlayerManager manager = other.GetComponent<PlayerManager>() as PlayerManager;
            if (manager)
            {
                manager.Reset();
            }
        }
    }
}
