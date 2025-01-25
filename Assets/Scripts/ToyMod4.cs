using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ToyMod4 : MonoBehaviour
{
    [SerializeField] private bool isIntro;
    [SerializeField] private AudioClip scoreSFX;

    [HideInInspector] public GameObject gameManager;
    [HideInInspector] public GameMaster gameManagerScript;

    private Animator anim;

    public float currentTimerMax;
    public float currentTimer;
    [SerializeField] private Image timerSprite;
    [SerializeField] private TextMeshProUGUI timerText;

    private bool started;
    public bool compared;
    private bool ended;

    [SerializeField] private TextMeshProUGUI resultText;

    [SerializeField] private GameObject[] bubbles;
    [SerializeField] private bool[] buttonsToClick;
    public bool[] buttonsClicked;

    public int minLitButtons;
    public int maxLitButtons;

    public int minBlockedButtons;
    public int maxBlockedButtons;
    [SerializeField] private bool[] blockedButtons;

    private void Awake()
    {
        anim = GetComponent<Animator>();

        if (isIntro) return;

        gameManager = GameObject.Find("Game Manager");
        gameManagerScript = gameManager.GetComponent<GameMaster>();
    }

    private void Start()
    {

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
        //resultText.text = "";
        currentTimer = currentTimerMax;

        for (int i = 0; i < 10; i++)
        {
            buttonsToClick[i] = false;
            buttonsClicked[i] = false;
            blockedButtons[i] = false;
            bubbles[i].GetComponent<Image>().sprite = bubbles[i].GetComponent<Bubble>().normalSprite;
        }
    }

    void SetButtonsToClick()
    {
        int nBlockedNum = Random.Range(minBlockedButtons, maxBlockedButtons + 1);
        int nRandomNumber = Random.Range(1,5);
        for (int nBlocked = 0; nBlocked < nBlockedNum; nBlocked++)
        {
            blockedButtons[(nBlocked + nRandomNumber) % 10] = true;
            bubbles[(nBlocked + nRandomNumber) % 10].GetComponent<Bubble>().isBomb = true;
        }

        int litNum = Random.Range(minLitButtons, maxLitButtons + 1);
        int lit = 0;
        bool newLight;

        for (int i = 0; i < 10 && lit < litNum; i++)
        {
            if (lit < litNum && buttonsToClick[i] == false && blockedButtons[i] == false)
            {
                newLight = Random.value >= 0.5f;
                buttonsToClick[i] = newLight;

                if (newLight == true)
                {
                    bubbles[i].GetComponent<Image>().sprite = bubbles[i].GetComponent<Bubble>().litSprite;
                    lit++;
                }
                else
                {
                    bubbles[i].GetComponent<Image>().sprite = bubbles[i].GetComponent<Bubble>().normalSprite;
                }
            }
        }

    }

    private IEnumerator slideIn()
    {
        gameObject.transform.SetParent(GameObject.Find("Canvas").transform, false);
        anim.Play("toy_in");
        //gameObject.GetComponent<ToyDifficulty>().Mod4Progression();
        for (int i = 0; i < 10; i++) bubbles[i].GetComponent<Bubble>().clicked = true;
        yield return new WaitForSeconds(1);
        for (int i = 0; i < 10; i++) bubbles[i].GetComponent<Bubble>().clicked = false;

        ResetToy();
        SetButtonsToClick();
    }

    private IEnumerator slideOut()
    {
        anim.Play("toy_out");
        yield return new WaitForSeconds(1);

        Destroy(gameObject);
    }

    public bool Compare()
    {
        compared = true;

        for (int i = 0; i < 10; i++) bubbles[i].GetComponent<Bubble>().clicked = true;

        currentTimer = 0;

        for (int i = 0; i < 10; i++)
        {
            if (buttonsToClick[i] != buttonsClicked[i])
            {
                //resultText.text = "Wrong!";
                gameManagerScript.LoseGame();
                return false;
            }
        }
        //resultText.text = "Coract!";
        gameManagerScript.score++;
        GameObject.Find("SFX Source").GetComponent<AudioSource>().pitch = 1;
        GameObject.Find("SFX Source").GetComponent<AudioSource>().PlayOneShot(scoreSFX);
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

