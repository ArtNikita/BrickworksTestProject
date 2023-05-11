using TMPro;
using UnityEngine;
using View;

namespace Managers
{
    public class UiManager : MonoBehaviour
    {
        [SerializeField] private TMP_Text currentPrice;
        public ISkillButtonView SelectedButton;

        public void UpdateCurrentPrice(int price)
        {
            currentPrice.text = $"Current Price: {price}";
        }
    }
}