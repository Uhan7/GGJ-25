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

    [SerializeField] private GameObject toy;
    [SerializeField] private Toy toyScript;

    public TextMeshProUGUI scoreText;
    public int score;

    private void Awake()
    {
        loseScreenAnim = loseScreen.GetComponent<Animator>();
    }

    void Start()
    {
        score = 0;
        gameLost = false;
    }

    void Update()
    {
        //if (Input.GetMouseButtonDown(0) && gameLost)
        //{
        //    SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        //}

        if (Input.GetKeyDown(KeyCode.R) && gameLost)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
    }

    public void UIUpdate()
    {
        scoreText.text = "Round " + score.ToString();
    }

    public void LoseGame()
    {
        if (gameLost) return;

        gameLost = true;
        loseScreen.SetActive(true);
        loseScreenAnim.Play("losescreen_fade_in");
    }

    public void SpawnNewToy()
    {
        Instantiate(toyPrefabs[Random.Range(0, toyPrefabs.Length)]);
    }
}

//toy = GameObject.Find("Toy");
//if (toy == null) return;
////if (toy.GetComponent<Toy>().currentTimer <= -1) SceneManager.LoadScene(SceneManager.GetActiveScene().name);