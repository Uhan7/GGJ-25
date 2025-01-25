using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ToyMod5 : MonoBehaviour
{
    [HideInInspector] public GameObject gameManager;
    [HideInInspector] public GameMaster gameManagerScript;

    private Animator anim;

    public float currentTimerMax;
    public float currentTimer;
    [SerializeField] private Image timerSprite;
    [SerializeField] private TextMeshProUGUI timerText;

    private bool started;
    private bool compared;
    private bool ended;

    [SerializeField] private TextMeshProUGUI resultText;

    [SerializeField] private GameObject[] bubbles;
    [SerializeField] private bool[] buttonsToClick;
    public bool[] buttonsClicked;

    public float blinkTime;

    public int minLitButtons;
    public int maxLitButtons;

    private void Awake()
    {
        gameManager = GameObject.Find("Game Manager");
        gameManagerScript = gameManager.GetComponent<GameMaster>();

        anim = GetComponent<Animator>();
    }

    private void Start()
    {
        currentTimerMax += 0.4f;
    }

    private void OnEnable()
    {
        StartCoroutine(slideIn());
    }

    private void Update()
    {
        if (!started) return;

        RunTimer();
        for (int i = 0; i < 10; i++)
        {
            if (buttonsClicked[i] == true && buttonsToClick[i] == false) if (!compared) Compare();
        }
        if (AreEqualArrays(buttonsToClick, buttonsClicked)) if (!compared) Compare();
        if (currentTimer <= 0)
        {
            if (!compared) Compare();
        }
        if (currentTimer <= -0.5f)
        {
            if (ended) return;

            if (!gameManagerScript.gameLost) gameManagerScript.SpawnNewToy();
            StartCoroutine(slideOut());
            ended = true;
        }
    }

    void RunTimer()
    {
        currentTimer -= Time.deltaTime;

        if (timerSprite != null) timerSprite.fillAmount = currentTimer / currentTimerMax;
        if (timerText != null) timerText.text = (Mathf.Round(currentTimer * 100.0f) * 0.01f).ToString();
    }

    void ResetToy()
    {
        started = true;
        compared = false;
        ended = false;
        resultText.text = "";
        currentTimer = currentTimerMax;

        for (int i = 0; i < 10; i++)
        {
            buttonsToClick[i] = false;
            buttonsClicked[i] = false;
            bubbles[i].GetComponent<Image>().sprite = bubbles[i].GetComponent<Bubble>().normalSprite;
        }
    }

    void SetButtonsToClick()
    {
        int litNum = Random.Range(minLitButtons, maxLitButtons + 1);
        int lit = 0;
        bool newLight;

        for (int i = 0; i < 10 && lit < litNum; i++)
        {

            if (lit < litNum && buttonsToClick[i] == false)
            {
                newLight = Random.value >= 0.5f;
                buttonsToClick[i] = newLight;

                if (newLight == true) lit++;
            }

            if (i == 9 && lit != litNum) i = 0;
        }

    }

    private IEnumerator slideIn()
    {
        gameObject.transform.SetParent(GameObject.Find("Canvas").transform, false);
        anim.Play("toy_in");
        yield return new WaitForSeconds(1);

        ResetToy();
        SetButtonsToClick();

        yield return new WaitForSeconds(Random.Range(0f, 0.5f));

        for (int i = 0; i < 10; i++)
        {
            if (buttonsToClick[i] == true) bubbles[i].GetComponent<Image>().sprite = bubbles[i].GetComponent<Bubble>().litSprite;
        }
        yield return new WaitForSeconds(blinkTime);
        for (int i = 0; i < 10; i++) bubbles[i].GetComponent<Image>().sprite = bubbles[i].GetComponent<Bubble>().normalSprite;
    }

    private IEnumerator slideOut()
    {
        anim.Play("toy_out");
        yield return new WaitForSeconds(1);

        Destroy(gameObject);
    }

    bool Compare()
    {
        compared = true;

        currentTimer = 0;

        for (int i = 0; i < 10; i++)
        {
            if (buttonsToClick[i] != buttonsClicked[i])
            {
                resultText.text = "Wrong!";
                gameManagerScript.LoseGame();
                return false;
            }
        }
        resultText.text = "Coract!";
        gameManagerScript.score++;
        gameManagerScript.UIUpdate();
        return true;
    }

    bool AreEqualArrays(bool[] array1, bool[] array2)
    {
        for (int i = 0; i < array1.Length; i++)
        {
            if (array1[i] != array2[i])
            {
                return false;
            }
        }

        return true;
    }
}
