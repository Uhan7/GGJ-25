using UnityEngine;
using UnityEngine.UI;

public class Background : MonoBehaviour
{

    [SerializeField] private Sprite[] phases;

    [SerializeField] private GameObject character;
    [SerializeField] private Sprite[] characterPhases;

    private GameMaster gameMasterScript;

    private void Awake()
    {
        gameMasterScript = GameObject.Find("Game Manager").GetComponent<GameMaster>();
    }

    void Start()
    {
        
    }

    void Update()
    {
        if (gameMasterScript.score < 10) GetComponent<Image>().sprite = phases[0];
        else if (gameMasterScript.score < 25) GetComponent<Image>().sprite = phases[1];
        else if (gameMasterScript.score < 49) GetComponent<Image>().sprite = phases[2];
        else if (gameMasterScript.score >= 50) GetComponent<Image>().sprite = phases[3];

        if (gameMasterScript.score < 10) character.GetComponent<Image>().sprite = characterPhases[0];
        else if (gameMasterScript.score < 20) character.GetComponent<Image>().sprite = characterPhases[1];
        else if (gameMasterScript.score < 30) character.GetComponent<Image>().sprite = characterPhases[2];
        else if (gameMasterScript.score < 40) character.GetComponent<Image>().sprite = characterPhases[3];
        else if (gameMasterScript.score < 50) character.GetComponent<Image>().sprite = characterPhases[4];
        else if (gameMasterScript.score >= 50) character.GetComponent<Image>().sprite = characterPhases[5];
    }
}
