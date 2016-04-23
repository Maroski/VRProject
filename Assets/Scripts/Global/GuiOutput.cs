using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public class GuiOutput : MonoBehaviour {

    static private Text m_infoMessage;
    static private Text m_contextMessage;
    static private GameObject m_fullMessage;

    public readonly float MAX_DELTA = 2.0F;
    static private float elapsed;

    static private Queue<string> m_messages;

    private void Start()
    {
        m_infoMessage = transform
            .Find("InfoText")
            .gameObject
            .GetComponent<Text>() as Text;
        
        m_contextMessage = transform
            .Find("ContextText")
            .gameObject
            .GetComponent<Text>() as Text;

        m_fullMessage = transform
            .Find("Message")
            .gameObject;
        Debug.Log(m_fullMessage);
        m_messages = new Queue<string>();
        elapsed = 0.0F;

        HideFullText();
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

    static public void Log(string msg)
    {
        if (m_infoMessage == null) { return; }
        
        m_messages.Enqueue(msg);
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

    static public void DisplayFullText(string msg)
    {
        Text t = m_fullMessage.GetComponentInChildren<Text>();
        Image i = m_fullMessage.GetComponentInChildren<Image>();
        t.text = msg;
        i.gameObject.GetComponent<CanvasRenderer>().SetAlpha(1f);
    }

    static public void HideFullText()
    {
        Text t = m_fullMessage.GetComponentInChildren<Text>();
        Image i = m_fullMessage.GetComponentInChildren<Image>();
        t.text = "";
        i.gameObject.GetComponent<CanvasRenderer>().SetAlpha(0f);
    }
}
