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
    public float speed = 10.0F;

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
           if (fracJourney > 0.8)
            {
                //bear dissapears
                Destroy(gameObject);

            }
        }

    }

    public void startRunning()
    {
        anim.SetBool(run, true);
        Invoke("runNow", 1.0f);
    }

    private void runNow()
    {
        startTime = Time.time;

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
