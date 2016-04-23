using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pilgrim.EnumTypes;

namespace Pilgrim.Player
{
    public class SkillTree
    {
        static SkillTree instance = null;

        static public SkillTree getInstance()
        {
            if (instance == null)
            {
                instance = new SkillTree();
            }
            return instance;
        }

        private enum ESkillStatus
        {
            Learnable,
            MissingPrereq,
            Unlearnable,
            Acquired
        }

        private class SkillNode
        {
            private EAbility type;
            private ESkillStatus status;
            private List<SkillNode> prereqs;    // All of these must be acquired to learn the skill  
            private List<SkillNode> antireqs;   // Any of these would make this skill unlearnable
            private List<SkillNode> dependents; // All of these require this skill to learn
            private int remainingPrereqs;       // Count of unlearnt 

            public SkillNode(EAbility skillType)
            {
                type = skillType;
                status = ESkillStatus.Learnable;
                prereqs = new List<SkillNode>();
                antireqs = new List<SkillNode>();
                dependents = new List<SkillNode>();
                remainingPrereqs = 0;
            }

            public void AddPrereq(SkillNode prereq)
            {
                prereqs.Add(prereq);
                remainingPrereqs++;
                status = ESkillStatus.MissingPrereq;
            }

            public void AddAntireq(SkillNode antireq)
            {
                antireqs.Add(antireq);
            }

            public void AddDependent(SkillNode dependent)
            {
                dependents.Add(dependent);
            }

            private void PropagateUnlearnable()
            {
                Debug.Assert(status != ESkillStatus.Acquired);
                if (status == ESkillStatus.Unlearnable) return;
                status = ESkillStatus.Unlearnable;
                GuiOutput.Log(String.Format("{0} is unlearnable now!", type));

                // All skills that depend on this skill are now unlearnable
                foreach (SkillNode n in dependents)
                {
                    n.PropagateUnlearnable();
                }
            }

            public void Acquire()
            {
                Debug.Assert(status == ESkillStatus.Learnable);
                status = ESkillStatus.Acquired;

                // All contradictory skills are now unlearnable
                foreach (SkillNode n in antireqs)
                {
                    n.PropagateUnlearnable();
                }

                // All dependents are one skill closer to being learnable
                foreach (SkillNode n in dependents)
                {
                    if (n.status == ESkillStatus.Unlearnable) continue;
                    n.remainingPrereqs--;
                    // When all prereqs are met the skill is learnable
                    if (n.remainingPrereqs == 0)
                    {
                        GuiOutput.Log(String.Format("{0} is learnable now!", n.type));
                        n.status = ESkillStatus.Learnable;
                    }
                }

            }

            public ESkillStatus GetStatus()
            {
                return status;
            }

        }

        private SkillNode[] m_SkillTree;
        private SkillTree()
        {
            m_SkillTree = new SkillNode[Enum.GetNames(typeof(EAbility)).Length];
            for (int i = 0; i < m_SkillTree.Length; i++)
            {
                m_SkillTree[i] = new SkillNode((EAbility)i);
            }

            AddPrereq(EAbility.Fireball, EAbility.Read);
            AddPrereq(EAbility.Icestorm, EAbility.Read);
            AddAntireq(EAbility.Icestorm, EAbility.Fireball);
        }

        private void AddPrereq(EAbility dependent, EAbility prereq)
        {
            SkillNode dependentNode = m_SkillTree[(int)dependent];
            SkillNode prereqNode = m_SkillTree[(int)prereq];
            prereqNode.AddDependent(dependentNode);
            dependentNode.AddPrereq(prereqNode);
        }

        private void AddAntireq(EAbility antireq1, EAbility antireq2)
        {
            SkillNode antireqNode1 = m_SkillTree[(int)antireq1];
            SkillNode antireqNode2 = m_SkillTree[(int)antireq2];
            antireqNode1.AddAntireq(antireqNode2);
            antireqNode2.AddAntireq(antireqNode1);
        }

        public void AcquireSkill(EAbility skill)
        {
            SkillNode newSkill = m_SkillTree[(int)skill];
            switch (newSkill.GetStatus())
            {
                case ESkillStatus.Learnable:
                    GuiOutput.Log(String.Format("{0} Acquired!", skill));
                    newSkill.Acquire();
                    Narrator.OnSkillLearned(skill);
                    break;
                case ESkillStatus.MissingPrereq:
                    GuiOutput.Log("MISSING PREREQ");
                    break;
                case ESkillStatus.Unlearnable:
                    GuiOutput.Log("UNLEARNABLE");
                    break;
                case ESkillStatus.Acquired:
                    GuiOutput.Log("ALREADY LEARNT");
                    break;

            }
        }

        public bool HasSkill(EAbility skill)
        {
            return m_SkillTree[(int)skill].GetStatus() == ESkillStatus.Acquired;
        }
    }
}
