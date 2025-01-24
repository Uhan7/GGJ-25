using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Toy : MonoBehaviour
{
    [SerializeField] private float currentTimerMax;
    [SerializeField] private float currentTimer;
    [SerializeField] private Image timerSprite;
    [SerializeField] private TextMeshProUGUI timerText;

    [SerializeField] private bool[] buttonsToClick;
    public bool[] buttonsClicked;

    [SerializeField] private int minLitButtons;
    [SerializeField] private int maxLitButtons;

    private void Update()
    {
        RunTimer();
    }

    void RunTimer()
    {
        currentTimer -= Time.deltaTime;

        if (timerSprite != null) timerSprite.fillAmount -= Time.deltaTime / currentTimerMax;
        if (timerText != null) timerText.text = (Mathf.Round(currentTimer * 100.0f) * 0.01f).ToString();
    }

}
