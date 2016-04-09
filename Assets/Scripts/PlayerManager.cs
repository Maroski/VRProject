using System;
using UnityEngine;
using Pilgrim.Controller;
using UnityStandardAssets.Characters.FirstPerson;

[RequireComponent(typeof (CharacterController))]
public class PlayerManager : MonoBehaviour
{
    private Camera m_Camera;
    private bool m_MouseDown;
    private float m_HoldTime;
    private CharacterController m_CharacterController;
    [SerializeField] private PlayerControllerBase m_controller;
    [SerializeField] private MouseLook m_MouseLook;

    public float m_ClickSensitivity = 0.2f;
    private void Start()
    {
        m_controller = new DefaultController(this);
        m_CharacterController = GetComponent<CharacterController>();
        m_Camera = Camera.main;
        Debug.Log(transform);
        Debug.Log(m_Camera.transform);

        m_MouseLook.Init(transform, m_Camera.transform);
    }

    private void Update()
    {
        RotateView();
        if (!m_MouseDown)
        {
            m_MouseDown = Input.GetMouseButtonDown(0);
            m_HoldTime = 0.0f;
        }
        else if (Input.GetMouseButtonUp(0))
        {
            m_MouseDown = false;
            if (m_HoldTime < m_ClickSensitivity)
            {
                Debug.Log("Calling onclick");
                m_controller.OnClick();
            } 
            else
            {
                m_controller.OnRelease(m_HoldTime);
            }
        }
        else
        {
            m_HoldTime += Time.deltaTime;
            if (m_HoldTime > m_ClickSensitivity)
            {
                Debug.Log("Calling onhold");
                m_controller.OnHold(m_HoldTime);
            }
        }
    }

    private void RotateView()
    {
        m_MouseLook.LookRotation(transform, m_Camera.transform);
    }

    public Quaternion GetLookDir()
    {
        return m_Camera.transform.rotation;
    }

    public Vector3 GetLookDir2()
    {
        return transform.forward;
    }

    public void Move(Vector3 motion)
    {
        m_CharacterController.Move(motion);
    }
}
