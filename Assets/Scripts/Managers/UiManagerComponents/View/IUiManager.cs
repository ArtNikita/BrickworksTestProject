using System;
using SkillButtonComponents.View;

namespace Managers.UiManagerComponents.View
{
    public interface IUiManager
    {
        public event EventHandler EarnPoints;
        public event EventHandler LearnCurrent;
        public event EventHandler ForgetCurrent;
        public event EventHandler ForgetAll;

        void UpdateCurrentPoints(int points);
        void UpdateCurrentPrice(int price);
        void OnSkillButtonSelected(ISkillButtonView view);
    }
}
