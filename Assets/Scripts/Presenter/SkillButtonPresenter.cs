using System;
using View;

namespace Presenter
{
    public class SkillButtonPresenter : ISkillButtonPresenter
    {
        private readonly ISkillButtonView _view;
        private const int SkillButtonChangeColorActionCode = 0;

        public SkillButtonPresenter(ISkillButtonView view)
        {
            _view = view;
        }

        public void Initialize()
        {
            _view.Clicked += OnSkillButtonClicked;
        }

        public void Uninitialize()
        {
            _view.Clicked -= OnSkillButtonClicked;
        }

        private void OnSkillButtonClicked(object sender, EventArgs eventArgs)
        {
            _view.ChangeColor(Constants.LearnedSkillColor);
        }
    }
}