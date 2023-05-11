using System;
using Managers.UiManagerComponents.View;
using SkillButtonComponents.View;

namespace SkillButtonComponents.Presenter
{
    public class SkillButtonPresenter : ISkillButtonPresenter
    {
        private readonly ISkillButtonView _view;
        private readonly IUiManager _uiManager;

        public SkillButtonPresenter(ISkillButtonView view, IUiManager uiManager)
        {
            _view = view;
            _uiManager = uiManager;
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
            SelectButton();
        }

        private void SelectButton()
        {
            _view.Select();
            _uiManager.OnSkillButtonSelected(_view);
        }
    }
}