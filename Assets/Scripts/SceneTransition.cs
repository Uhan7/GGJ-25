using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneTransition : MonoBehaviour
{
    [SerializeField] private string toScene;
    [SerializeField] private float timer;

    private bool startCountdown;

    private void OnEnable()
    {
        startCountdown = true;
    }

    private void Update()
    {
        if (startCountdown)
        {
            timer -= Time.deltaTime;

            if (timer <= 0) SceneManager.LoadScene(toScene);
        }
    }
}
