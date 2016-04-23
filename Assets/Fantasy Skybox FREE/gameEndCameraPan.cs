using UnityEngine;
using System.Collections;

public class gameEndCameraPan : MonoBehaviour {

    public Vector3 endingCameraLocation;
    public Vector3 startingCameraLocation;
    public GameObject endingText;

    public float speed = 20.0F;
    private float startTime;
    private float journeyLength;

    private bool gameEnd = false;

    void Start()
    {
        startTime = Time.time;
        journeyLength = Vector3.Distance(startingCameraLocation, endingCameraLocation);
    }


    void Update()
    {
        if (gameEnd)
        {
            float distCovered = (Time.time - startTime) * speed;
            float fracJourney = distCovered / journeyLength;
            transform.position = Vector3.Lerp(startingCameraLocation, endingCameraLocation, fracJourney);
            if (fracJourney > 0.95)
            {
                //show end game message
                MeshRenderer m = endingText.GetComponent<MeshRenderer>();
                m.enabled = true;
                AudioSource audio = GetComponent<AudioSource>();
                audio.Play();
            }
        }

    }

    public void finishGame()
    {
        gameEnd = true;
    }
}
