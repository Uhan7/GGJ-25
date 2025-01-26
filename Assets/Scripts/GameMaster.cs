using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class GameMaster : MonoBehaviour
{
    [SerializeField] private GameObject[] toyPrefabs;

    [HideInInspector] public bool gameLost;
    [SerializeField] private GameObject loseScreen;
    [SerializeField] private Animator loseScreenAnim;

    [SerializeField] private TextMeshProUGUI loseText;

    [SerializeField] private GameObject toy;
    [SerializeField] private Toy toyScript;

    public TextMeshProUGUI scoreText;
    public int score;

    public int highScore;
    private const string HighScoreKey = "Highscore";

    [SerializeField] private GameObject[] dialogues;

    private void Awake()
    {
        loseScreenAnim = loseScreen.GetComponent<Animator>();
    }

    void Start()
    {
        highScore = PlayerPrefs.GetInt(HighScoreKey, 0);

        score = 0;
        gameLost = false;
    }

    void Update()
    {
        loseText.text = "Score: " + score + "\nHigh Score: " + highScore;
    }

    public void UIUpdate()
    {
        scoreText.text = "Round " + score.ToString();

        if (score >= 5) dialogues[0].SetActive(true);
        if (score >= 10) dialogues[1].SetActive(true);
        if (score >= 15) dialogues[2].SetActive(true);
        if (score >= 20) dialogues[3].SetActive(true);
        if (score >= 25) dialogues[4].SetActive(true);
        if (score >= 30) dialogues[5].SetActive(true);
        if (score >= 35) dialogues[6].SetActive(true);
        if (score >= 40) dialogues[7].SetActive(true);
        if (score >= 45) dialogues[8].SetActive(true);
        if (score >= 49) dialogues[9].SetActive(true);
        if (score >= 50) dialogues[10].SetActive(true);
    }

    public void LoseGame()
    {
        if (gameLost) return;

        gameLost = true;

        if (score > highScore)
        {
            highScore = score;
            PlayerPrefs.SetInt(HighScoreKey, highScore);
            PlayerPrefs.Save();
        }

        loseScreen.SetActive(true);
        loseScreenAnim.Play("losescreen_fade_in");
    }

    public void ReloadScene()
    {
        if (!gameLost) return;

        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void MainMenu()
    {
        SceneManager.LoadScene("Main Menu");
    }

    public void SpawnNewToy()
    {
        Instantiate(toyPrefabs[Random.Range(0, toyPrefabs.Length)]);
    }
}

//toy = GameObject.Find("Toy");
//if (toy == null) return;
////if (toy.GetComponent<Toy>().currentTimer <= -1) SceneManager.LoadScene(SceneManager.GetActiveScene().name);