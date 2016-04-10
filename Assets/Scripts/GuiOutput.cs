using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public class GuiOutput : MonoBehaviour {

    static private Text m_infoMessage;
    static private Text m_contextMessage;
    static private Text m_debugDistanceMessage;

    public readonly float MAX_DELTA = 5.0F;
    static private float elapsed;

    static private Queue<string> m_messages;

    private void Start()
    {
        m_debugDistanceMessage = transform
            .Find("DistanceDebug")
            .gameObject
            .GetComponent<Text>() as Text;
        
        m_infoMessage = transform
            .Find("InfoText")
            .gameObject
            .GetComponent<Text>() as Text;
        
        m_contextMessage = transform
            .Find("ContextText")
            .gameObject
            .GetComponent<Text>() as Text;
        
        m_messages = new Queue<string>();
        elapsed = 0.0F;
    }

    private void Update()
    {

        if (m_infoMessage == null) { return; }

        if (m_infoMessage.text != "")
        {
            elapsed += Time.deltaTime;
        }
        else
        {
            DisplayNextInfoMessage();
        }

        if (elapsed > MAX_DELTA)
        {
            DisplayNextInfoMessage();
            elapsed = 0.0F;
        }
    }

    void DisplayNextInfoMessage()
    {

        if (m_infoMessage == null) { return; }        

        if (m_messages.Count == 0)
        {
            m_infoMessage.text = "";
        }
        else
        {
            m_infoMessage.text = m_messages.Dequeue();
        }
    }

    static public void EnqueueInfoMessage(string msg)
    {
        if (m_infoMessage == null) { return; }
        
        m_messages.Enqueue(msg);
        Debug.Log("Queued: " + msg);
    }

    static public void DisplayContextMessage(string msg)
    {
        if (m_contextMessage == null) { return; }         
        m_contextMessage.text = msg;
    }

    static public void ClearContextMessage()
    {
        DisplayContextMessage("");
    }

    static public void DisplayDebugDistanceMessage(string msg)
    {
        if (m_debugDistanceMessage == null) { return; }

        m_debugDistanceMessage.text = msg;
    }

    static public void ClearDebugDistanceMessage()
    {
        DisplayDebugDistanceMessage("");
    }
}
