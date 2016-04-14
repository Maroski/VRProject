using System;
using UnityEngine;

public class MovingObject : MonoBehaviour
{
    public float m_TravelDistance = 20f;
    public Vector3 m_MovementDir = new Vector3(0f,0f,1f);
    public float m_TravelTime = 10f;
    
    private Vector3 m_StartPos;
    private float m_TimePassed;

    private void Start()
    {
        m_StartPos = transform.position;
        m_TimePassed = 0f;
    }

    private void FixedUpdate()
    {
        m_TimePassed += Time.fixedDeltaTime;
        transform.position = m_StartPos + DistanceFromStart() * m_MovementDir.normalized;
    }

    private float DistanceFromStart()
    {
        return (float)(1 - Math.Cos(m_TimePassed * Math.PI / m_TravelTime)) * m_TravelDistance;

    }

}
