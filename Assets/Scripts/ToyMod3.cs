using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ToyMod3 : MonoBehaviour
{
    [SerializeField] private bool isIntro;
    [SerializeField] private AudioClip scoreSFX;
    [SerializeField] private AudioClip buzzerSFX;

    [HideInInspector] public GameObject gameManager;
    [HideInInspector] public GameMaster gameManagerScript;

    private char[] cColorID = { 'r', 'o', 'y', 'g', 'b', 'p' };
    private int[] nColorHash = { 0, 0, 0, 0, 0, 0 };
    public char[] cBubbleButtons = { 'x', 'x', 'x', 'x', 'x', 'x', 'x', 'x', 'x', 'x' };	// color value of bubble buttons
    private int nTolerance = 1; // Checks if the number of collisions on the hash index is acceptable or can be hashed onto.
    private char cColorTarget = '?'; //Color that the player should clickity

    private Animator anim;

    [SerializeField] public float currentTimerMax;
    public float currentTimer;
    [SerializeField] private Image timerSprite;
    [SerializeField] private TextMeshProUGUI timerText;

    private bool started;
    private bool compared;
    private bool ended;

    private int nRandomNum = -1; // random number
    private int nChecker = -1; //Checks the value of the nBubble Button
    private bool found = false;
    [SerializeField] private TextMeshProUGUI resultText;

    [SerializeField] private GameObject[] bubbles;
    [SerializeField] private bool[] buttonsToClick;
    public bool[] buttonsClicked;


    public GameObject[] indicators;

    //[SerializeField] private int minLitButtons;
    //[SerializeField] private int maxLitButtons;

    private void Awake()
    {
        anim = GetComponent<Animator>();

        if (isIntro) return;

        gameManager = GameObject.Find("Game Manager");
        gameManagerScript = gameManager.GetComponent<GameMaster>();
    }

    private void Start()
    {
        if (isIntro) return;
        gameObject.GetComponent<ToyDifficulty>().Mod3Progression();
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

        char[] cColorID = { 'r', 'o', 'y', 'g', 'b', 'p' };
        int[] nColorHash = { 0, 0, 0, 0, 0, 0 };
        char[] cBubbleButtons = { 'x', 'x', 'x', 'x', 'x', 'x', 'x', 'x', 'x', 'x' };	// color value of bubble buttons
        int nRandomNum = -1; // random number
        int nChecker = -1; //Checks the value of the nBubble Button
        int nTolerance = 1; // Checks if the number of collisions on the hash index is acceptable or can be hashed onto.
        char cColorTarget = '?'; //Color that the player should clickity
        bool found = false;
        
        started = true;
        compared = false;
        ended = false;
        //resultText.text = "";
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
        nRandomNum = -1; // random number
        nChecker = -1; //Checks the value of the nBubble Button
        nTolerance = 1; // Checks if the number of collisions on the hash index is acceptable or can be hashed onto.
        cColorTarget = cColorID[Random.Range(0,5+1)];

        switch (cColorTarget)
        {
            case 'r':
                indicators[0].SetActive(true);
                break;
            case 'o':
                indicators[1].SetActive(true);
                break;
            case 'y':
                indicators[2].SetActive(true);
                break;
            case 'g':
                indicators[3].SetActive(true);
                break;
            case 'b':
                indicators[4].SetActive(true);
                break;
            case 'p':
                indicators[5].SetActive(true);
                break;
        }

        for (int nBubButton = 0; nBubButton < 10; nBubButton++)
        {
            nRandomNum = Random.Range(0, 5+1);
            found = false;

            while (found == false)
            {
                if (nColorHash[nRandomNum] < nTolerance)
                {
                    found = true;
                    nColorHash[nRandomNum]++;
                    cBubbleButtons[nBubButton] = cColorID[nRandomNum];
                    bubbles[nBubButton].GetComponent<Bubble>().setColor(cBubbleButtons[nBubButton]);
                }
                else
                {
                    nRandomNum = ((nRandomNum + 1) % 6);
                }
            }

            if (nBubButton % 6 == (6 - 1))
            {
                nTolerance++;
            }

        }

        //int litNum = Random.Range(minLitButtons, maxLitButtons + 1);

        for (int i = 0; i < 10; i++)
        {
            if (cBubbleButtons[i] == cColorTarget)
            {
                buttonsToClick[i] = true;
            }

        
        }

    }

    private IEnumerator slideIn()
    {
        gameObject.transform.SetParent(GameObject.Find("Canvas").transform, false);
        anim.Play("toy_in");
        gameObject.GetComponent<ToyDifficulty>().Mod3Progression();
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

    bool Compare()
    {
        compared = true;

        for (int i = 0; i < 10; i++) bubbles[i].GetComponent<Bubble>().clicked = true;

        currentTimer = 0;

        for (int i = 0; i < 10; i++)
        {
            if (buttonsToClick[i] != buttonsClicked[i])
            {
                //resultText.text = "Wrong!";
                GameObject.Find("SFX Source").GetComponent<AudioSource>().pitch = 1;
                GameObject.Find("SFX Source").GetComponent<AudioSource>().volume = 0.7f;
                GameObject.Find("SFX Source").GetComponent<AudioSource>().PlayOneShot(buzzerSFX);
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
