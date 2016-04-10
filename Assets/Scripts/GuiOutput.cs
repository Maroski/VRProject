using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class GuiOutput : MonoBehaviour {

    static private Text m_infoMessage;
    static private Text m_contextMessage;

    public readonly float MAX_DELTA = 5.0F;
    static private float elapsed;

    static private Queue m_messages;

    private void Start()
    {
        m_infoMessage = GameObject.FindGameObjectWithTag("InfoMessage").GetComponent<Text>() as Text;
        m_contextMessage = GameObject.FindGameObjectWithTag("ContextMessage").GetComponent<Text>() as Text;
        m_messages = new Queue();
        elapsed = 0.0F;
    }

    private void Update()
    {
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
        if (m_messages.Count == 0)
        {
            m_infoMessage.text = "";
        }
        else
        {
            m_infoMessage.text = (string) m_messages.Dequeue();
        }
    }

    static public void EnqueueInfoMessage(string msg)
    {
        m_messages.Enqueue(msg);
        Debug.Log("Queued: " + msg);
    }

    static public void DisplayContextMessage(string msg)
    {
        m_contextMessage.text = msg;
    }

    static public void ClearContextMessage()
    {
        DisplayContextMessage("");
    }
}
