using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class scene_manager : MonoBehaviour
{

    [SerializeField] private GameObject sceneTransitioner;

    [SerializeField] private string transitionOutName;
    [SerializeField] private string transitionInName;

    // At the start of every scene, these is a transition into the scene
    public void Start()
    {
        sceneTransitioner.SetActive(true);
        sceneTransitioner.GetComponent<Animator>().Play(transitionOutName);
    }

    public void Wrapper(string sceneName)
    {
        StartCoroutine(ChangeScene(sceneName));
    }

    public IEnumerator ChangeScene(string sceneName)
    {
        sceneTransitioner.SetActive(true);
        sceneTransitioner.GetComponent<Animator>().Play(transitionInName);

        yield return new WaitForSeconds(1.5f);
        SceneManager.LoadScene(sceneName);
    }

}
