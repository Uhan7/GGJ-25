using UnityEngine;
using UnityEngine.UI;

public class Bubble : MonoBehaviour
{
    [SerializeField] private AudioSource aSource;

    private int ID;
    [SerializeField] private GameObject toy;
    [SerializeField] private int toyMod;

    [SerializeField] private AudioClip popSFX;

    private Toy toyScript;
    private ToyMod2 toyScript2;

    private ToyMod4 toyScript4;

    public Sprite normalSprite;
    public Sprite litSprite;
    public Sprite clickedSprite;

    private void Awake()
    {
        toyScript = toy.GetComponent<Toy>();
        toyScript2 = toy.GetComponent<ToyMod2>();

        toyScript4 = toy.GetComponent<ToyMod4>();
    }

    void Start()
    {
        int.TryParse(gameObject.name[gameObject.name.Length - 1].ToString(), out ID); // To set their ID as Bubble #
    }

    void Update()
    {
        
    }

    public void Clicked()
    {

        gameObject.GetComponent<Image>().sprite = clickedSprite;

        if (toyScript != null) toyScript.buttonsClicked[ID] = true;
        if (toyScript2 != null) toyScript2.buttonsClicked[ID] = true;

        if (toyScript4 != null) toyScript4.buttonsClicked[ID] = true;
    }
}
