using UnityEngine;
using UnityEngine.SceneManagement;

public class TitleScreen : MonoBehaviour
{
    public GameObject tutorial;
    public GameObject[] credits;

    private void Start()
    {

    }

    public void LoadTutorial()
    {
        if (tutorial.activeInHierarchy) tutorial.SetActive(false);
        else tutorial.SetActive(true);
    }

    public void StartGame()
    {
        SceneManager.LoadScene("Bubble Toy");
    }

    public void LoadCredits()
    {
        credits[0].SetActive(true);
        credits[1].SetActive(false);
    }

    public void NextCredits()
    {
        credits[0].SetActive(false);
        credits[1].SetActive(true);
    }

    public void CloseCredits()
    {
        credits[0].SetActive(false);
        credits[1].SetActive(false);
    }
}
