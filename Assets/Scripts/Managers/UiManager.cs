using TMPro;
using UnityEngine;
using View;

namespace Managers
{
    public class UiManager : MonoBehaviour
    {
        [SerializeField] private TMP_Text currentPrice;
        [SerializeField] private TMP_Text currentPoints;
        public ISkillButtonView SelectedButton;

        public void UpdateCurrentPrice(int price)
        {
            currentPrice.text = $"Current Price: {price}";
        }

        public void UpdateCurrentPoints(int points)
        {
            currentPoints.text = $"{points} Points";
        }
    }
}