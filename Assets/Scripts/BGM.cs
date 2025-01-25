using System.Collections;
using UnityEngine;

public class BGM : MonoBehaviour
{
    private AudioSource aSource;
    private GameMaster gameManagerScript;
    private float normalVolume;

    [SerializeField] private AudioClip BGM2;
    [SerializeField] private AudioClip BGM3;

    private bool switchedToBGM2;
    private bool switchedToBGM3;

    private void Awake()
    {
        aSource = GetComponent<AudioSource>();
        gameManagerScript = GameObject.Find("Game Manager").GetComponent<GameMaster>();
    }

    void Start()
    {
        normalVolume = aSource.volume;
    }

    void Update()
    {
        if (gameManagerScript.score >= 25 && !switchedToBGM2)
        {
            switchedToBGM2 = true;
            StartCoroutine(FadeOut(BGM2));
        }

        if (gameManagerScript.score >= 50 && !switchedToBGM3)
        {
            switchedToBGM3 = true;
            StartCoroutine(FadeOut(BGM3));
        }
    }

    private IEnumerator FadeOut(AudioClip clipToPlay)
    {
        while (aSource.volume > 0)
        {
            aSource.volume -= normalVolume / 3 * Time.deltaTime;
            yield return null;
        }

        aSource.volume = 0;
        aSource.Stop();

        aSource.volume = normalVolume;
        aSource.clip = clipToPlay;
        aSource.Play();
    }
}
