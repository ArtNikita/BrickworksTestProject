using System.Collections.Generic;
using UnityEngine;
using View;

namespace Managers
{
    public class SkillButtonsManager : MonoBehaviour
    {
        [SerializeField] private LineRenderer skillsConnection;
        private List<SkillButtonView> _skillButtons;

        private void Awake()
        {
            _skillButtons = new List<SkillButtonView>(FindObjectsOfType<SkillButtonView>());
            NormalizeConnectedSkillsCollections();
        }

        private void Start()
        {
            ConnectToOtherSkillButtonsWithLines();
            InitSkillButtonsStartParams();
        }

        private void NormalizeConnectedSkillsCollections()
        {
            foreach (var skillButton in _skillButtons)
            {
                foreach (var connectedSkill in skillButton.connectedSkills)
                {
                    if (!connectedSkill.connectedSkills.Contains(skillButton))
                        connectedSkill.connectedSkills.Add(skillButton);
                }
            }
        }

        private void ConnectToOtherSkillButtonsWithLines()
        {
            foreach (var skillButton in _skillButtons)
            {
                skillButton.isConnected = true;
                foreach (var connectedSkill in skillButton.connectedSkills)
                {
                    if (connectedSkill.isConnected) continue;
                    var lineRenderer = Instantiate(skillsConnection);
                    lineRenderer.positionCount = 2;
                    lineRenderer.SetPosition(0, skillButton.transform.position);
                    lineRenderer.SetPosition(1, connectedSkill.transform.position);
                }
            }
        }

        private void InitSkillButtonsStartParams()
        {
            foreach (var skillButton in _skillButtons)
            {
                if (skillButton.isBase)
                {
                    skillButton.isLearned = true;
                    transform.localScale *= Constants.BaseSkillScaleRatio;
                }

                var startColor = skillButton.isLearned ? Constants.LearnedSkillColor : Constants.UnlearnedSkillColor;
                skillButton.ChangeColor(startColor);
            }
        }
    }
}