using UnityEngine;
using System.Collections;
using Pilgrim.Player;

namespace Pilgrim.Trigger
{
    public class KillTrigger : MonoBehaviour
    {

        public AudioClip m_clip = null;
        public bool m_playOnce = true;
        private bool m_isPlayed = false;

        public void OnTriggerEnter(Collider other)
        {
            PlayerManager manager = other.GetComponent<PlayerManager>() as PlayerManager;
            if (manager)
            {
                if (m_clip != null)
                {
                    if (!m_isPlayed || !m_playOnce)
                    {
                        Narrator.PlaySound(m_clip);
                        m_isPlayed = true;
                    }
                }
                manager.Reset();
            }
        }
    }
}
