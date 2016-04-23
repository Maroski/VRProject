using UnityEngine;
using System.Collections;

namespace Pilgrim.Trigger
{ 
    public class NarrationTriggerHandler : MonoBehaviour {

        private bool m_played;
        public bool m_playOnce;
        public AudioClip m_clip;

        // Use this for initialization
        void Start () {
            m_played = false;
        }

        // Play the sound when you reach the trigger
        // Then disable to never play it again
        public void OnTriggerEnter(Collider col)
        {
            if (!m_played)
            {
                if (m_playOnce)
                {
                    m_played = true;
                }
                Narrator.PlaySound(m_clip);
            }
        
        }
    }
}
