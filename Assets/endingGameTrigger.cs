using UnityEngine;
using System.Collections;

public class endingGameTrigger : MonoBehaviour {

    public GameObject endingCamera;
	// Use this for initialization


    void OnTriggerEnter(Collider c)
    {
        AudioClip clip = Resources.Load<AudioClip>("ending");
        Narrator.PlaySound(clip);
        //endingCamera.GetComponent<Camera>().enabled = true;
        gameEndCameraPan cameraPanScript = (gameEndCameraPan)endingCamera.GetComponent(typeof(gameEndCameraPan));
        cameraPanScript.finishGame();

    }
}
