using System;
using UnityEngine;

namespace View
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
    }
}