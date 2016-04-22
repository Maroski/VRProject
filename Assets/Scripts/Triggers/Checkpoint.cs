using UnityEngine;
using System.Collections;
using Pilgrim.Player;

namespace Pilgrim.Trigger
{
    public class Checkpoint : MonoBehaviour
    {
        public void OnTriggerEnter(Collider other)
        {
            if (other.gameObject.tag == "Player")
            {
                PlayerManager manager = other.GetComponent<PlayerManager>() as PlayerManager;
                if (manager)
                {
                    manager.SetCheckpoint(transform);
                }
            }
        }
    }
}
