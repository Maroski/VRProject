using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class ChangeLevel : MonoBehaviour {
    public int m_LevelID = -1;

    void Start()
    {
        if (m_LevelID == -1)
            m_LevelID = SceneManager.GetActiveScene().buildIndex + 1;
    }

    void OnTriggerEnter(Collider col)
    {
        SceneManager.LoadScene(m_LevelID);
    }
}
