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

    public void Mod2Progression()
    {
        if (toyScript2 != null && toyScript2.gameManagerScript.score >= 0 && toyScript2.gameManagerScript.score <= 10)
        {
            toyScript2.currentTimerMax = 2.5f;
            toyScript2.minLitButtons = 2;
            toyScript2.maxLitButtons = 4;
        }
        if (toyScript2 != null && toyScript2.gameManagerScript.score >= 11 && toyScript2.gameManagerScript.score <= 20)
        {
            toyScript2.currentTimerMax = 2.25f;
            toyScript2.minLitButtons = 2;
            toyScript2.maxLitButtons = 5;
        }
        if (toyScript2 != null && toyScript2.gameManagerScript.score >= 21 && toyScript2.gameManagerScript.score <= 30)
        {
            toyScript2.currentTimerMax = 2f;
            toyScript2.minLitButtons = 3;
            toyScript2.maxLitButtons = 5;
        }
        if (toyScript2 != null && toyScript2.gameManagerScript.score >= 31 && toyScript2.gameManagerScript.score <= 40)
        {
            toyScript2.currentTimerMax = 1.75f;
            toyScript2.minLitButtons = 3;
            toyScript2.maxLitButtons = 6;
        }
        if (toyScript2 != null && toyScript2.gameManagerScript.score >= 41 && toyScript2.gameManagerScript.score <= 49)
        {
            toyScript2.currentTimerMax = 1.5f;
            toyScript2.minLitButtons = 4;
            toyScript2.maxLitButtons = 6;
        }
        if (toyScript2 != null && toyScript2.gameManagerScript.score >= 50)
        {
            toyScript2.currentTimerMax = 1.2f;
            toyScript2.minLitButtons = 4;
            toyScript2.maxLitButtons = 6;
        }
    }
    public void Mod5Progression()
    {
        if (toyScript5 != null && toyScript5.gameManagerScript.score >= 0 && toyScript5.gameManagerScript.score <= 10)
        {
            toyScript5.currentTimerMax = 2.5f;
            toyScript5.minLitButtons = 2;
            toyScript5.maxLitButtons = 4;
        }
        if (toyScript5 != null && toyScript5.gameManagerScript.score >= 11 && toyScript5.gameManagerScript.score <= 20)
        {
            toyScript5.currentTimerMax = 2.25f;
            toyScript5.minLitButtons = 2;
            toyScript5.maxLitButtons = 5;
        }
        if (toyScript5 != null && toyScript5.gameManagerScript.score >= 21 && toyScript5.gameManagerScript.score <= 30)
        {
            toyScript5.currentTimerMax = 2f;
            toyScript5.minLitButtons = 3;
            toyScript5.maxLitButtons = 5;
        }
        if (toyScript5 != null && toyScript5.gameManagerScript.score >= 31 && toyScript5.gameManagerScript.score <= 40)
        {
            toyScript5.currentTimerMax = 1.75f;
            toyScript5.minLitButtons = 3;
            toyScript5.maxLitButtons = 6;
        }
        if (toyScript5 != null && toyScript5.gameManagerScript.score >= 41 && toyScript5.gameManagerScript.score <= 49)
        {
            toyScript5.currentTimerMax = 1.5f;
            toyScript5.minLitButtons = 4;
            toyScript5.maxLitButtons = 6;
        }
        if (toyScript5 != null && toyScript5.gameManagerScript.score >= 50)
        {
            toyScript5.currentTimerMax = 1.2f;
            toyScript5.minLitButtons = 4;
            toyScript5.maxLitButtons = 6;
        }
    }
    

}
