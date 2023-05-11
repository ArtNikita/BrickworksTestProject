using System;
using System.Collections.Generic;
using UnityEngine;

namespace SkillButtonComponents.View
{
    public interface ISkillButtonView
    {
        public event EventHandler Clicked;
        void ChangeColor(Color color);
        void Select();
        void Unselect();
        int GetPrice();
        bool IsBase();
        bool IsLearned();
        void OnLearnCurrentClicked();
        void SetLearned(bool isLearnedNewValue);
        List<ISkillButtonView> GetConnectedSkills();
    }
}