using UnityEngine;
using System.Collections;

public class bearController : MonoBehaviour {

    Animator anim;
    int lookright = Animator.StringToHash("lookright");
    int lookleft = Animator.StringToHash("lookleft");
    int run = Animator.StringToHash("run");
    bool isRunning = false;

    //Draws straight path to travel point and runs there
    public GameObject travelPoint;
    public float speed = 1.0F;

    private Vector3 startPosition;
    private Vector3 dest;
    private float startTime;
    private float journeyLength;

    void Start()
    {
        startPosition = transform.position;
        anim = GetComponent<Animator>();
        dest = travelPoint.transform.position;
        startTime = Time.time;
        journeyLength = Vector3.Distance(startPosition, dest);
    }


    void Update()
    {
        if (isRunning && travelPoint != null)
        {
            float distCovered = (Time.time - startTime) * speed;
            float fracJourney = distCovered / journeyLength;
            transform.position = Vector3.Lerp(startPosition, dest, fracJourney);
        }

    }

    public void startRunning()
    {
        startTime = Time.time;
        anim.SetBool(run, true);
        isRunning = true;
    }
    public void startLookingRight()
    {
        anim.SetTrigger(lookright);
        anim.SetBool(run, false);
    }
    public void startLookingLeft()
    {
        anim.SetTrigger(lookleft);
        anim.SetBool(run, false);
    }
}
