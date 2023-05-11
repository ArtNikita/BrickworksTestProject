using System;
using Managers.UiManagerComponents.View;
using SkillButtonComponents.View;

namespace Managers.UiManagerComponents.Presenter
{
    public class UiManagerPresenter : IUiManagerPresenter
    {
        private const int PointsToEarnPerClick = 1;

        private readonly SkillButtonsManager _skillButtonsManager;
        private readonly IUiManager _view;
        private ISkillButtonView _selectedButton;
        private int _earnedPoints;

        public UiManagerPresenter(IUiManager view, SkillButtonsManager skillButtonsManager)
        {
            _view = view;
            _skillButtonsManager = skillButtonsManager;
        }

        public void Initialize()
        {
            _view.EarnPoints += OnEarnPointsButtonClicked;
            _view.LearnCurrent += OnLearnCurrentButtonClicked;
            _view.ForgetCurrent += OnForgetCurrentButtonClicked;
            _view.ForgetAll += OnForgetAllButtonClicked;
        }

        public void Uninitialize()
        {
            _view.EarnPoints -= OnEarnPointsButtonClicked;
            _view.LearnCurrent -= OnLearnCurrentButtonClicked;
            _view.ForgetCurrent -= OnForgetCurrentButtonClicked;
            _view.ForgetAll -= OnForgetAllButtonClicked;
        }

        public void SkillButtonClicked(ISkillButtonView skillButton)
        {
            _view.UpdateCurrentPrice(skillButton.GetPrice());
            if (_selectedButton != null && _selectedButton != skillButton) _selectedButton.Unselect();
            _selectedButton = skillButton;
            SetupButtonsEnabling();
        }

        private void SetupButtonsEnabling()
        {
            SetupLearnCurrentButtonEnabling();
            SetupForgetCurrentButtonEnabling();
        }

        private void SetupLearnCurrentButtonEnabling()
        {
            _view.SetLearnCurrentButtonInteractable(
                _skillButtonsManager.SkillButtonCanBeLearned(_selectedButton, _earnedPoints)
            );
        }

        private void SetupForgetCurrentButtonEnabling()
        {
            _view.SetForgetCurrentButtonInteractable(_skillButtonsManager.SkillButtonCanBeForgotten(_selectedButton));
        }

        private void OnEarnPointsButtonClicked(object sender, EventArgs eventArgs)
        {
            _earnedPoints += PointsToEarnPerClick;
            _view.UpdateCurrentPoints(_earnedPoints);
            SetupLearnCurrentButtonEnabling();
        }

        private void OnLearnCurrentButtonClicked(object sender, EventArgs e)
        {
            //todo
        }

        private void OnForgetCurrentButtonClicked(object sender, EventArgs e)
        {
            // todo
        }

        private void OnForgetAllButtonClicked(object sender, EventArgs e)
        {
            // todo
        }
    }
}