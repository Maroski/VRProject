using System;
using UnityEngine;
using Pilgrim.Controller;
using Pilgrim.EnumTypes;
using UnityStandardAssets.Characters.FirstPerson;

[RequireComponent(typeof (CharacterController))]
public class PlayerManager : MonoBehaviour
{
    private Camera m_Camera;
    private bool m_MouseDown;
    private float m_HoldTime;
    private bool m_WasHovering;
    private CharacterController m_CharacterController;
    [SerializeField] private PlayerControllerBase m_controller;
    [SerializeField] private MouseLook m_MouseLook;
    [SerializeField] private float m_WalkSpeed = 2.0f;

    bool[] m_SkillList;

    public float m_ClickSensitivity = 0.2f;
    private void Start()
    {
        m_controller = new DefaultController(this);
        m_CharacterController = GetComponent<CharacterController>();
        m_Camera = Camera.main;
        m_SkillList = new bool[Enum.GetNames(typeof(EAbility)).Length];
        for(int i = 0; i < m_SkillList.Length; i++)
        {
            m_SkillList[i] = false;
        }

        m_MouseLook.Init(transform, m_Camera.transform);
    }

    private void Update()
    {
        RotateView();

        // TODO: Determine a better way to do gravity
        m_CharacterController.SimpleMove(new Vector3(0f,0f,0f)); // hack to apply gravity

        RaycastHit HitInfo;
        int NotPlayerMask = ~(1 << LayerMask.NameToLayer("PlayerCharacter"));
        if (Physics.Raycast(m_Camera.transform.position, m_Camera.transform.forward, out HitInfo, 10.0f, NotPlayerMask))
        {
            m_WasHovering = true;
            m_controller.OnHover(HitInfo);
        }
        else if (m_WasHovering)
        {
            m_WasHovering = false;
            m_controller.OnHoverOff();
        }

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
                m_controller.OnHold(m_HoldTime);
            }
        }
    }

    private void RotateView()
    {
        m_MouseLook.LookRotation(transform, m_Camera.transform);
    }

    public Vector3 GetLookDir()
    {
        return m_Camera.transform.forward;
    }

    public Vector3 GetMoveDir()
    {
        return transform.forward;
    }
    
    public float getWalkSpeed()
    {
        return m_WalkSpeed;
    }

    public void Move(Vector3 displacement)
    {
        m_CharacterController.Move(displacement);
    }

    public void LearnSkill(EAbility skill)
    {
        int skillID = (int)skill;
        if (m_SkillList[skillID])
        {
            Debug.Log(String.Format("You have learnt {0} already", skill));
        }
        else
        {
            Debug.Log(String.Format("YOU LEARNT {0}", skill));
            m_SkillList[skillID] = true;
        }
    }
}
