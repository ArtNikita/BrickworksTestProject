using System;
using Managers.UiManagerComponents.View;

namespace Managers.UiManagerComponents.Presenter
{
    public class UiManagerPresenter : IUiManagerPresenter
    {
        private IUiManager _view;

        public UiManagerPresenter(IUiManager view)
        {
            _view = view;
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

        private void OnEarnPointsButtonClicked(object sender, EventArgs eventArgs)
        {
            // todo
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