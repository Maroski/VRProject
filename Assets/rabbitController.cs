using UnityEngine;
using System.Collections;

public class rabbitController : MonoBehaviour {

    Animator anim;
    int eat = Animator.StringToHash("eat");

    public int jumpRadius = 3;
    public float JumpForce = 1.0F;

    private Vector3 startPos;
    private Vector3 postJumpPos, preJumpPos;
    private float preJumpRotation, postJumpRotation;
    private float journeyLength;
    private float startTime;
    public float speed = 1.0F;
    public float rotationTime = 2.0F;

    private Rigidbody body;
    private bool isJumping = false;
	// Use this for initialization
	void Start () {
        anim = GetComponent<Animator>();
        startPos = transform.position;
        body = GetComponent<Rigidbody>();

        Invoke("makeDecision", 1);//this will happen after 2 seconds

    }

    // Update is called once per frame
    void Update () {
	    if (isJumping == true)
        {
            float distCovered = (Time.time - startTime) * speed;
            float fracJourney = distCovered / journeyLength;
            preJumpPos.y = transform.position.y;
            postJumpPos.y = transform.position.y;
            transform.position = Vector3.Lerp(preJumpPos, postJumpPos, fracJourney);

            //rotation
            float newRotationY = (postJumpRotation - preJumpRotation) / rotationTime;
            transform.Rotate(new Vector3(0.0f, newRotationY*Time.deltaTime, 0.0f));


            if (Mathf.Abs(body.velocity.y) < 0.5)
            {
                isJumping = false;
            }

        }
	}

   

    public void makeDecision()
    {

        //Debug.Log("MAKE DECISION END!");

        // Code to execute after the delay
        float rand = Random.value;
        if (rand <= 0.5f)
        {
            Jump();
            Invoke("makeDecision", 2);

        }
        else
        {
            EatGrass();
            Invoke("makeDecision", 6);

        }

        //CAll self after 6 seconds
    }

    void Jump()
    {
       // Debug.Log("JUMP!");
        Vector2 rand2 = Random.insideUnitCircle * jumpRadius;
        preJumpPos = transform.position;
        postJumpPos = new Vector3(rand2.x + startPos.x, startPos.y, rand2.y + startPos.z);
        isJumping = true;
        body.AddForce(new Vector3(0f, JumpForce, 0f), ForceMode.Impulse);

        preJumpRotation = transform.rotation.eulerAngles.y;
        postJumpRotation = Random.rotation.eulerAngles.y;

        journeyLength = Vector3.Distance(preJumpPos, postJumpPos);
        startTime = Time.time;
    }

    void EatGrass()
    {
        anim.SetTrigger(eat);
       // Debug.Log("GRASS EATING YO!");
    }
}
