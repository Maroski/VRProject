using UnityEngine;
using System.Collections;

public class RotateObject : MonoBehaviour {

    public float m_DegreesPerSec = 10;
    public Vector3 m_Axis = new Vector3(0f,0f,1f);
            
    // Update is called once per frame
    void Update () {
        transform.Rotate(m_Axis, m_DegreesPerSec * Time.deltaTime);
    }
}
