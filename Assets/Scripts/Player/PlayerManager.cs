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
        private bool m_MouseDown;
        private float m_HoldTime;
        private float m_HoverTime;
        private bool m_WasHovering;
        private GameObject m_PreviousTarget;
        private RaycastHit? m_PreviousHit;
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
        [SerializeField] private float m_WalkSpeed = 2.0f;
        [SerializeField] private float m_JumpPower = 5f;

        public Vector3 m_FallVelocity;
        private Vector3 m_DesiredDisplacement = Vector3.zero;

        public float m_ClickSensitivity = 0.2f;
        private bool m_IsJumping;
        private Transform m_Head;

        public void Reset()
        {
            m_controller = new DefaultController(this);
            m_ActivePlatform = null;
            m_MouseDown = false;
            m_HoverTime = 0f;
            m_HoldTime = 0f;
            m_WasHovering = false;
            m_PreviousTarget = null;
            m_ActivePlatform = null;
            m_FallVelocity = Vector3.zero;
            m_PreviousHit = null;
            m_IsJumping = false;
            Respawn();
        }

        private void Start()
        {
            m_CharacterController = GetComponent<CharacterController>();
            m_Camera = Camera.main;
            m_Head = transform.Find("Head");
            m_SkillTree = new SkillTree();
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

            RaycastHit HitInfo;
            int NotPlayerMask = ~(1 << LayerMask.NameToLayer("PlayerCharacter"));
            if (Physics.Raycast(m_Camera.transform.position, m_Camera.transform.forward, out HitInfo, 10.0f, NotPlayerMask))
            {
                m_WasHovering = true;
                m_PreviousHit = HitInfo;
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
                m_PreviousHit = null;
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

            // TODO: clean this up. I do not think we need to check isGrounded
            // Handle gravity
            if (m_CharacterController.isGrounded)
            {
                m_IsJumping = false;
                m_FallVelocity = Vector3.zero;
            }

            // Don't apply gravity if we are climbing
            if (!IsClimbing())
            {
                m_FallVelocity += m_Gravity * Time.fixedDeltaTime;
            }

            // Include player input
            Vector3 totalVelocity = m_FallVelocity + m_DesiredDisplacement.normalized * m_WalkSpeed;
            displacement += totalVelocity * Time.fixedDeltaTime;

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

        public void Jump(float launchAngle)
        {
            if (!HasSkill(EAbility.Jump)) return;
            m_IsJumping = true;
            m_FallVelocity = GetMoveDir();
            m_FallVelocity.y = 0;
            m_FallVelocity = Vector3.RotateTowards(m_FallVelocity, Vector3.up, launchAngle * (float) Math.PI / 180f, 0f);
            m_FallVelocity = m_FallVelocity.normalized * m_JumpPower;
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

        public void Move(Vector3 displacement)
        {
            if (!m_IsJumping && HasSkill(EAbility.Walk))
            {
                m_DesiredDisplacement += displacement.normalized;
            }
        }

        public void ChangeContext(PlayerControllerBase newController)
        {
            Debug.Log(String.Format("Switched to {0}", newController.GetType()));
            m_NewController = newController;
        }

        public void SetCheckpoint(Transform checkpoint)
        {
            m_Checkpoint = checkpoint;
        }

        private void Respawn()
        {
            transform.position = m_Checkpoint.position;
        }

        public void AcquireSkill(EAbility skill)
        {
            m_SkillTree.AcquireSkill(skill);
        }

        public bool HasSkill(EAbility skill)
        {
            return m_SkillTree.HasSkill(skill);
        }

        public Vector3 GetLookDir()
        {
            return m_Camera.transform.forward;
        }

        public Vector3 GetMoveDir()
        {
            return m_Head.forward - Vector3.Project(m_Head.forward, Vector3.up);
        }

        public RaycastHit? GetLastTargetHitInfo()
        {
            return m_PreviousHit;
        }

        public GameObject GetLastTarget()
        {
            return m_PreviousTarget;
        }

        public bool IsClimbing()
        {
            return m_controller is ClimbingController;
        }

    }
}
