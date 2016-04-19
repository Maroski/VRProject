using System;
using UnityEngine;
using Pilgrim.Controller;
using Pilgrim.EnumTypes;
using UnityStandardAssets.Characters.FirstPerson;

namespace Pilgrim.Player
{
    [RequireComponent(typeof (CharacterController))]
    public class PlayerManager : MonoBehaviour
    {
        private Camera m_Camera;
        private bool m_WasGrounded;
        private bool m_MouseDown;
        private float m_HoldTime;
        private float m_HoverTime;
        private bool m_WasHovering;
        private GameObject m_PreviousTarget;
        public Transform m_Checkpoint;

        private Transform m_ActivePlatform;     // the platform we are standing on
        private Vector3 m_GlobalPlatformPoint;  // our position in the world
        private Vector3 m_LocalPlatformPoint;   // our position on the platform

        private Quaternion m_GlobalPlatformRotation; // our orientation in the world
        private Quaternion m_LocalPlatformRotation;  // our orientation relative to the platform

        private PlayerControllerBase m_NewController;
        private PlayerControllerBase m_controller;
        private CharacterController m_CharacterController;
        private SkillTree m_SkillTree;
        [SerializeField] private Vector3 m_Gravity = Physics.gravity;
        [SerializeField] private MouseLook m_MouseLook;
        [SerializeField] private float m_WalkSpeed = 2.0f;

        private Vector3 m_DownVelocity;
        private Vector3 m_DesiredDisplacement;

        public float m_ClickSensitivity = 0.2f;
        private void Start()
        {
            m_CharacterController = GetComponent<CharacterController>();
            m_Camera = Camera.main;
            m_SkillTree = new SkillTree();
            m_MouseLook.Init(transform, m_Camera.transform);
            Reset();
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

        private void FixedUpdate()
        {
            Vector3 displacement = Vector3.zero;

            // Handle gravity
            if (!m_CharacterController.isGrounded)
            {
                if (m_WasGrounded)
                {
                    m_DownVelocity = Vector3.zero;
                    m_WasGrounded = false;
                }
                m_DownVelocity += m_Gravity * Time.fixedDeltaTime;
                displacement = m_DownVelocity * Time.fixedDeltaTime;
            } 
            else
            {
                m_WasGrounded = true;
            }

            // Handle player input
            displacement += m_DesiredDisplacement.normalized * m_WalkSpeed * Time.fixedDeltaTime;

            // Handle platform movement
            if (m_ActivePlatform != null)
            {
                // Determine where we should be standing
                Vector3 newGlobalPoint = m_ActivePlatform.TransformPoint(m_LocalPlatformPoint);
                // Determine how much to move the character to get there
                Vector3 moveDistance = newGlobalPoint - m_GlobalPlatformPoint;
                displacement += moveDistance;

                // Determine where we should be standing
                Quaternion newGlobalRotation = m_ActivePlatform.rotation * m_LocalPlatformRotation;
                // Determine how much we should rotate to get there
                Quaternion angleToRotate = newGlobalRotation * Quaternion.Inverse(m_GlobalPlatformRotation);
                // Straighten the transform to point up
                angleToRotate = Quaternion.FromToRotation(angleToRotate * transform.up, transform.up) * angleToRotate;
                transform.rotation = angleToRotate * transform.rotation;
            }

            // Move the character
            m_CharacterController.Move(displacement);

            // Cleanup
            m_DesiredDisplacement = Vector3.zero;
            if (m_ActivePlatform != null)
            {
                m_GlobalPlatformPoint = transform.position;
                m_LocalPlatformPoint = m_ActivePlatform.InverseTransformPoint(transform.position);
                m_GlobalPlatformRotation = transform.rotation;
                m_LocalPlatformRotation = Quaternion.Inverse(m_ActivePlatform.transform.rotation) * transform.rotation;
            }
        }

        private void OnControllerColliderHit (ControllerColliderHit hit)
        {
            // ensure that the collision was down and beneath us
            // ie we are we fell on and above the platform 
            if (hit.moveDirection.y < -0.9 && hit.normal.y > 0.5)
            {
                m_ActivePlatform = hit.collider.transform;
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

        public void Move(Vector3 displacement)
        {
            m_DesiredDisplacement += displacement.normalized;
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

        public void SetCheckpoint(Transform checkpoint)
        {
            Debug.Log("SETCHECKPOINT");
            m_Checkpoint = checkpoint;
        }

        private void Respawn()
        {
            Debug.Log("RESPAWN");
            transform.position = m_Checkpoint.position;
        }

        public void Reset()
        {
            m_controller = new DefaultController(this);
            m_WasGrounded = true;
            m_WasHovering = false;
            m_PreviousTarget = null;
            m_ActivePlatform = null;
            m_DownVelocity = Vector3.zero;
            Respawn();
        }


    }
}
