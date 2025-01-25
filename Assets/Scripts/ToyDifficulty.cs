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

    public void Mod1Progression()
    {
        if (toyScript != null && toyScript.gameManagerScript.score >= 0 && toyScript.gameManagerScript.score <= 10)
        {
            toyScript.currentTimerMax = 2.5f;
            toyScript.minLitButtons = 2;
            toyScript.maxLitButtons = 4;
        }
        if (toyScript != null && toyScript.gameManagerScript.score >= 11 && toyScript.gameManagerScript.score <= 20)
        {
            toyScript.currentTimerMax = 2.25f;
            toyScript.minLitButtons = 2;
            toyScript.maxLitButtons = 5;
        }
        if (toyScript != null && toyScript.gameManagerScript.score >= 21 && toyScript.gameManagerScript.score <= 30)
        {
            toyScript.currentTimerMax = 2f;
            toyScript.minLitButtons = 3;
            toyScript.maxLitButtons = 5;
        }
        if (toyScript != null && toyScript.gameManagerScript.score >= 31 && toyScript.gameManagerScript.score <= 40)
        {
            toyScript.currentTimerMax = 1.75f;
            toyScript.minLitButtons = 3;
            toyScript.maxLitButtons = 6;
        }
        if (toyScript != null && toyScript.gameManagerScript.score >= 41 && toyScript.gameManagerScript.score <= 49)
        {
            toyScript.currentTimerMax = 1.5f;
            toyScript.minLitButtons = 4;
            toyScript.maxLitButtons = 6;
        }
        if (toyScript != null && toyScript.gameManagerScript.score >= 50)
        {
            toyScript.currentTimerMax = 1.2f;
            toyScript.minLitButtons = 4;
            toyScript.maxLitButtons = 6;
        }
    }
}
