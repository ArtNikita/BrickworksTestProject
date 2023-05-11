using UnityEngine;
using UnityEngine.UI;

public class IgnoreAlphaRaycaster : MonoBehaviour
{
    [SerializeField] private float alphaHitTestMinimumThreshold = 0.9f;

    private void Start()
    {
        gameObject.GetComponent<Image>().alphaHitTestMinimumThreshold = alphaHitTestMinimumThreshold;
    }
}