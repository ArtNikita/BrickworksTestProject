using System;
using Managers.UiManagerComponents.Presenter;
using SkillButtonComponents.View;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Managers.UiManagerComponents.View
{
    public sealed class UiManager : MonoBehaviour, IUiManager
    {
        [SerializeField] private TMP_Text currentPrice;
        [SerializeField] private TMP_Text currentPoints;
        [SerializeField] private Button earnPointsButton;
        [SerializeField] private Button learnCurrentButton;
        [SerializeField] private Button forgetCurrentButton;
        [SerializeField] private Button forgetAllButton;
        public event EventHandler EarnPoints;
        public event EventHandler LearnCurrent;
        public event EventHandler ForgetCurrent;
        public event EventHandler ForgetAll;

        private IUiManagerPresenter _presenter;

        private void Awake()
        {
            InitButtons();
            _presenter = new UiManagerPresenter(this, FindObjectOfType<SkillButtonsManager>());
            _presenter.Initialize();
        }

        private void OnDestroy()
        {
            _presenter.Uninitialize();
        }

        private void InitButtons()
        {
            earnPointsButton.onClick.AddListener(OnEarnPoints);
            learnCurrentButton.onClick.AddListener(OnLearnCurrent);
            forgetCurrentButton.onClick.AddListener(OnForgetCurrent);
            forgetAllButton.onClick.AddListener(OnForgetAll);
        }

        public void UpdateCurrentPrice(int price)
        {
            currentPrice.text = $"Current Price: {price}";
        }

        public void UpdateCurrentPoints(int points)
        {
            currentPoints.text = $"{points} Points";
        }

        public void OnSkillButtonSelected(ISkillButtonView skillButton)
        {
            _presenter.SkillButtonClicked(skillButton);
        }

        public void SetLearnCurrentButtonInteractable(bool isInteractable)
        {
            learnCurrentButton.interactable = isInteractable;
        }

        public void SetForgetCurrentButtonInteractable(bool isInteractable)
        {
            forgetCurrentButton.interactable = isInteractable;
        }

        private void OnEarnPoints()
        {
            EarnPoints?.Invoke(this, EventArgs.Empty);
        }

        private void OnLearnCurrent()
        {
            LearnCurrent?.Invoke(this, EventArgs.Empty);
        }

        private void OnForgetCurrent()
        {
            ForgetCurrent?.Invoke(this, EventArgs.Empty);
        }

        private void OnForgetAll()
        {
            ForgetAll?.Invoke(this, EventArgs.Empty);
        }
    }
}