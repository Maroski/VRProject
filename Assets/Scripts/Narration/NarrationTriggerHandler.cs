using UnityEngine;
using System.Collections;

public class NarrationTriggerHandler : MonoBehaviour {

    private bool m_played;

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
            m_played = true;
            GetComponent<AudioSource>().Play();
        }
        
    }
}
