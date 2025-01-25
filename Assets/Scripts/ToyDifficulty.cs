using UnityEngine;

public class ToyDifficulty : MonoBehaviour
{
    private Toy toyScript;
    private ToyMod2 toyScript2;
    private ToyMod3 toyScript3;
    //private ToyMod4 toyScript4;
    private ToyMod5 toyScript5;

    private void Awake()
    {
        toyScript = GetComponent<Toy>();
        toyScript2 = GetComponent<ToyMod2>();
        toyScript3 = GetComponent<ToyMod3>();
        //toyScript4 = GetComponent<ToyMod4>();
        toyScript5 = GetComponent<ToyMod5>();
    }

    void Start()
    {
        
    }


    void Update()
    {

    }

    public void Mod3Progression()
    {
        if (toyScript != null && toyScript3.gameManagerScript.score >= 0 && toyScript3.gameManagerScript.score <= 10)
        {
            toyScript3.currentTimerMax = 2.5f;
            toyScript3.nMaxColor = 2;

        }
        if (toyScript3 != null && toyScript3.gameManagerScript.score >= 11 && toyScript3.gameManagerScript.score <= 20)
        {
            toyScript3.currentTimerMax = 2.25f;
            toyScript3.nMaxColor = 3;
        }
        if (toyScript3 != null && toyScript3.gameManagerScript.score >= 21 && toyScript3.gameManagerScript.score <= 30)
        {
            toyScript3.currentTimerMax = 2f;
            toyScript3.nMaxColor = 4;
        }
        if (toyScript3 != null && toyScript3.gameManagerScript.score >= 31 && toyScript3.gameManagerScript.score <= 40)
        {
            toyScript3.currentTimerMax = 1.75f;
            toyScript3.nMaxColor = 5;
        }
        if (toyScript3 != null && toyScript3.gameManagerScript.score >= 41 && toyScript3.gameManagerScript.score <= 49)
        {
            toyScript3.currentTimerMax = 1.5f;
            toyScript3.nMaxColor = 6;
        }
        if (toyScript3 != null && toyScript3.gameManagerScript.score >= 50)
        {
            toyScript3.currentTimerMax = 1.2f;
            toyScript3.nMaxColor = 6;
        }
    }
}
