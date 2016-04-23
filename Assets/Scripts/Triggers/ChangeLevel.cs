using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using Pilgrim.Player;

public class ChangeLevel : MonoBehaviour {
    [SerializeField] private int m_LevelID = -1;
    [SerializeField] private string m_SpawnerName = "";

    void Start()
    {
        if (m_LevelID == -1)
            m_LevelID = SceneManager.GetActiveScene().buildIndex + 1;
    }

    void OnTriggerEnter(Collider col)
    {
        SceneManager.LoadScene(m_LevelID);

        // Request the player manager loads a different spawn point than default
        if (m_SpawnerName != "")
        {
            PlayerManager.StartPointName = m_SpawnerName;
        }
    }
}
