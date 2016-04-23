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

        if (m_SpawnerName != "")
        {
            // There should only be one player
            GameObject[] players;
            players = GameObject.FindGameObjectsWithTag("Player");
            GameObject player = players[0];
            PlayerManager pm = player.GetComponent<PlayerManager>();
            if (pm == nul)
            {
                Debug.Log("No player in scene");
                return;
            }

            GameObject startingLocation = GameObject.Find(m_SpawnerName);
            if (startingLocation == null)
            {
                Debug.Log("Specified location not found");
                return;
            }
            pm.SetCheckpoint(startingLocation.transform);

        }
    }
}
