﻿using System;
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
    private float m_HoverTime;
    private bool m_WasHovering;
    private GameObject m_PreviousTarget;
    private PlayerControllerBase m_NewController;
    private PlayerControllerBase m_controller;
    private CharacterController m_CharacterController;
    private SkillTree m_SkillTree;
    [SerializeField] private MouseLook m_MouseLook;
    [SerializeField] private float m_WalkSpeed = 2.0f;

    public float m_ClickSensitivity = 0.2f;
    private void Start()
    {
        m_controller = new DefaultController(this);
        m_CharacterController = GetComponent<CharacterController>();
        m_Camera = Camera.main;
        m_SkillTree = new SkillTree();
        m_MouseLook.Init(transform, m_Camera.transform);
    }

    private void Update()
    {
        // Context switch was requested
        // To ensure we do not switch controllers in the middle of the frame we only update the
        // controller at the beginning of the frame. Controller change requests made in the middle
        // of the frame will only affect the m_NewController.
        if (m_NewController != null)
        {
            m_controller = m_NewController;
            m_NewController = null;
        }
        RotateView();

        // TODO: Determine a better way to do gravity
        m_CharacterController.SimpleMove(new Vector3(0f,0f,0f)); // hack to apply gravity

        RaycastHit HitInfo;
        int NotPlayerMask = ~(1 << LayerMask.NameToLayer("PlayerCharacter"));
        if (Physics.Raycast(m_Camera.transform.position, m_Camera.transform.forward, out HitInfo, 10.0f, NotPlayerMask))
        {
            GuiOutput.DisplayDebugDistanceMessage("" + ((RaycastHit)HitInfo).distance);
            m_WasHovering = true;
            GameObject NewTarget = HitInfo.collider.gameObject;
            if (NewTarget == m_PreviousTarget)
            {
                m_HoverTime += Time.deltaTime;
                m_controller.OnHover(m_HoverTime);
            }
            else
            {
                m_HoverTime = 0.0f;
                m_controller.OnTargetChange(HitInfo);
            }
            m_PreviousTarget = NewTarget;
        }
        else if (m_WasHovering)
        {
            m_WasHovering = false;
            m_PreviousTarget = null;
            m_controller.OnTargetChange(null);
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

    public void AcquireSkill(EAbility skill)
    {
        m_SkillTree.AcquireSkill(skill);
    }

    public bool HasSkill(EAbility skill)
    {
        return m_SkillTree.HasSkill(skill);
    }

    public void ChangeContext(PlayerControllerBase newController)
    {
        m_NewController = newController;
    }
}
