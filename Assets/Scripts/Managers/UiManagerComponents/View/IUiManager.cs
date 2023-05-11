using System;

namespace Managers.UiManagerComponents.View
{
    public interface IUiManager
    {
        public event EventHandler EarnPoints;
        public event EventHandler LearnCurrent;
        public event EventHandler ForgetCurrent;
        public event EventHandler ForgetAll;

        void UpdateCurrentPrice(int price);
        void UpdateCurrentPoints(int points);
    }
}
