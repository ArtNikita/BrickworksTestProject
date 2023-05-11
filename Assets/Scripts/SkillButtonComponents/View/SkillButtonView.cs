using System;
using System.Collections.Generic;
using Managers.UiManagerComponents.View;
using SkillButtonComponents.Presenter;
using UnityEngine;
using UnityEngine.UI;

namespace SkillButtonComponents.View
{
    public class SkillButtonView : MonoBehaviour, ISkillButtonView
    {
        public bool isBase;
        public List<SkillButtonView> connectedSkills;
        public bool isLearned;
        [SerializeField] private int price;
        public bool isConnected;
        [SerializeField] private GameObject selector;
        private Button _button;
        
        private ISkillButtonPresenter _presenter;

        public void Awake()
        {
            InitButton();
            _presenter = new SkillButtonPresenter(this, FindObjectOfType<UiManager>());
            _presenter.Initialize();
        }

        private void InitButton()
        {
            _button = gameObject.GetComponent<Button>();
            _button.onClick.RemoveAllListeners();
            _button.onClick.AddListener(OnButtonClicked);
        }

        public void OnDestroy()
        {
            _presenter.Uninitialize();
        }

        public event EventHandler Clicked;

        private void OnButtonClicked()
        {
            Clicked?.Invoke(this, EventArgs.Empty);
        }

        public void ChangeColor(Color color)
        {
            gameObject.GetComponent<Image>().color = color;
        }

        public void Select()
        {
            selector.SetActive(true);
        }

        public void Unselect()
        {
            selector.SetActive(false);
        }

        public int GetPrice()
        {
            return price;
        }

        public bool IsBase()
        {
            return isBase;
        }

        public bool IsLearned()
        {
            return isLearned;
        }

        public void OnLearnCurrentClicked()
        {
            _presenter.OnLearnCurrentClicked();
        }

        public void SetLearned(bool isLearnedNewValue)
        {
            isLearned = isLearnedNewValue;
        }

        public List<ISkillButtonView> GetConnectedSkills()
        {
            return new List<ISkillButtonView>(connectedSkills);
        }
    }
}