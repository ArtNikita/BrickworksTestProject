using System.Collections.Generic;
using System.Linq;
using Managers.UiManagerComponents.View;
using SkillButtonComponents.View;
using UnityEngine;

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
            SelectBaseButton();
        }

        private void SelectBaseButton()
        {
            foreach (var skillButton in _skillButtons.Where(skillButton => skillButton.isBase))
            {
                skillButton.Select();
                FindObjectOfType<UiManager>().OnSkillButtonSelected(skillButton);
                return;
            }
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
                    skillButton.transform.localScale *= Constants.BaseSkillScaleRatio;
                }

                var startColor = skillButton.isLearned ? Constants.LearnedSkillColor : Constants.UnlearnedSkillColor;
                skillButton.ChangeColor(startColor);
            }
        }

        public bool SkillButtonCanBeLearned(ISkillButtonView skillButton, int earnedPoints)
        {
            if (skillButton.IsLearned() || skillButton.GetPrice() > earnedPoints) return false;
            return skillButton.GetConnectedSkills().Any(connectedSkill => connectedSkill.IsLearned());
        }

        public bool SkillButtonCanBeForgotten(ISkillButtonView skillButton)
        {
            if (skillButton.IsBase()) return false;
            if (!skillButton.IsLearned()) return false;
            var visitedButtons = new HashSet<ISkillButtonView> { skillButton };
            return !CheckIfNeighborSkillButtonsConnectedToBase(skillButton, visitedButtons);
        }

        private bool CheckIfNeighborSkillButtonsConnectedToBase(
            ISkillButtonView skillButton, HashSet<ISkillButtonView> visitedButtons
        )
        {
            visitedButtons.Add(skillButton);
            foreach (var neighborSkillButton in skillButton.GetConnectedSkills())
            {
                if (visitedButtons.Contains(neighborSkillButton)) continue;
                if (neighborSkillButton.IsBase()) return true;
                var a = CheckIfNeighborSkillButtonsConnectedToBase(neighborSkillButton, visitedButtons);
            }

            return false;
        }
    }
}