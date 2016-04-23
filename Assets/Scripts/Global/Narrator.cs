using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using Pilgrim.EnumTypes;

public class Narrator : MonoBehaviour {

    private AudioSource m_source;
    static private Queue<AudioClip> m_audioQueue = new Queue<AudioClip>();

    public static AudioClip m_jumpClip = Resources.Load<AudioClip>("jump_ability");
    public static AudioClip m_digClip = Resources.Load<AudioClip>("dig_ability");
    public static AudioClip m_climbClip = Resources.Load<AudioClip>("climb_ability");
    public static AudioClip m_fireballClip = Resources.Load<AudioClip>("generic_ability");
    public static AudioClip m_readClip = Resources.Load<AudioClip>("generic_ability");
    public static AudioClip m_walkClip = Resources.Load<AudioClip>("walk_ability");

    // Use this for initialization
    void Start () {
        m_source = GetComponent<AudioSource>();
	}
	
	// Update is called once per frame
	void Update () {
	    
        if (!m_source.isPlaying && m_audioQueue.Count > 0)
        {
            m_source.clip = m_audioQueue.Dequeue();
            m_source.Play();
        }

	}

    public static void OnSkillLearned(EAbility skill)
    {
        Debug.Log("PLAYING SOUND ON SKILL LEARNED");
        switch (skill)
        {
            case EAbility.Jump:
                Narrator.PlaySound(m_jumpClip);
                break;
            case EAbility.Climb:
                Narrator.PlaySound(m_climbClip);
                break;
            case EAbility.Walk:
                Narrator.PlaySound(m_walkClip);
                break;
            case EAbility.Read:
                Narrator.PlaySound(m_readClip);
                break;
            case EAbility.Fireball:
                Narrator.PlaySound(m_fireballClip);
                break;
            case EAbility.Dig:
                Narrator.PlaySound(m_digClip);
                break;
            default:
                Debug.Log("Using unsupported skill to play audio");
                break;
        }
    }

    public static void PlaySound(AudioClip clip)
    {
        Debug.Log("PLAYING SOUND");
        m_audioQueue.Enqueue(clip);
    }
}
