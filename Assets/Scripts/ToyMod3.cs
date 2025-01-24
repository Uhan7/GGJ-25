using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ToyMod3 : MonoBehaviour
{
    private GameObject gameManager;
    private GameMaster gameManagerScript;
    private char[] cColorID = { 'r', 'o', 'y', 'g', 'b', 'p' };
    private int[] nColorHash = { 0, 0, 0, 0, 0, 0 };
    private char[] cBubbleButtons = { 'x', 'x', 'x', 'x', 'x', 'x', 'x', 'x', 'x', 'x' };	// color value of bubble buttons
    private int nRandomNum = -1; // random number
    private int nChecker = -1; //Checks the value of the nBubble Button
    private int nTolerance = 1; // Checks if the number of collisions on the hash index is acceptable or can be hashed onto.
    private char cColorTarget = '?'; //Color that the player should clickity

    private Animator anim;

    [SerializeField] private float currentTimerMax;
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

    [SerializeField] private int minLitButtons;
    [SerializeField] private int maxLitButtons;

    private void Awake()
    {
        gameManager = GameObject.Find("Game Manager");
        gameManagerScript = gameManager.GetComponent<GameMaster>();

        anim = GetComponent<Animator>();
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
        nRandomNum = -1; // random number
        nChecker = -1; //Checks the value of the nBubble Button
        nTolerance = 1; // Checks if the number of collisions on the hash index is acceptable or can be hashed onto.
        cColorTarget = cColorID[Random.Range(0,5+1)];

        Debug.Log(cColorTarget);
        for (int nBubButton = 0; nBubButton < 10; nBubButton++)
        {
            nRandomNum = Random.Range(0, 5+1);
            if (nColorHash[nRandomNum] < nTolerance)
            {
                nColorHash[nRandomNum]++;
                cBubbleButtons[nBubButton] = cColorID[nRandomNum];
                
            }
            else
            {
                cBubbleButtons[nBubButton] = cColorTarget;
            }
            
            if (nBubButton % 6 == (6 - 1))
            {
                nTolerance++;
            }
            Debug.Log(cBubbleButtons[nBubButton].ToString() + nBubButton.ToString()+buttonsToClick[nBubButton].ToString());
        }

        //int litNum = Random.Range(minLitButtons, maxLitButtons + 1);

        for (int i = 0; i < 10; i++)
        {
            if (cBubbleButtons[i] == cColorTarget)
            {
                buttonsToClick[i] = true;
                bubbles[i].GetComponent<Image>().sprite = bubbles[i].GetComponent<Bubble>().litSprite;
            }
            else
            {
                bubbles[i].GetComponent<Image>().sprite = bubbles[i].GetComponent<Bubble>().normalSprite;
            }

        
        }

    }

    private IEnumerator slideIn()
    {
        gameObject.transform.SetParent(GameObject.Find("Canvas").transform, false);
        anim.Play("toy_in");
        yield return new WaitForSeconds(1);

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
