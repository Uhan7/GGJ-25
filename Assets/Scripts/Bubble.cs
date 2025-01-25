using UnityEngine;
using UnityEngine.UI;

public class Bubble : MonoBehaviour
{
    [SerializeField] private AudioSource aSource;
    public Sprite bubble;
    private int ID;
    [SerializeField] private GameObject toy;
    [SerializeField] private int toyMod;

    [SerializeField] private AudioClip[] popSFXs;

    private Toy toyScript;
    private ToyMod2 toyScript2;
    private ToyMod3 toyScript3;
    private ToyMod4 toyScript4;
    private ToyMod5 toyScript5;

    public Sprite normalSprite;
    public Sprite litSprite;
    public Sprite clickedSprite;

    public bool isBomb;
    public Sprite bombSprite;

    private void Awake()
    {
        toyScript = toy.GetComponent<Toy>();
        toyScript2 = toy.GetComponent<ToyMod2>();
        toyScript3 = toy.GetComponent<ToyMod3>();
        toyScript4 = toy.GetComponent<ToyMod4>();
        toyScript5 = toy.GetComponent<ToyMod5>();

        aSource = GameObject.Find("SFX Source").GetComponent<AudioSource>();
    }

    void Start()
    {
        int.TryParse(gameObject.name[gameObject.name.Length - 1].ToString(), out ID); // To set their ID as Bubble #
    }

    void Update()
    {
        if (isBomb) GetComponent<Image>().sprite = bombSprite;
    }

    public void Clicked()
    {
        aSource.pitch = 1 + Random.Range(-0.3f, 0.3f);
        gameObject.GetComponent<Image>().sprite = clickedSprite;
        aSource.PlayOneShot(popSFXs[Random.Range(0, popSFXs.Length)]);

        if (toyScript != null) toyScript.buttonsClicked[ID] = true;
        if (toyScript2 != null) toyScript2.buttonsClicked[ID] = true;
        if (toyScript3 != null) toyScript3.buttonsClicked[ID] = true;
        if (toyScript4 != null) toyScript4.buttonsClicked[ID] = true;
        if (toyScript5 != null) toyScript5.buttonsClicked[ID] = true;
    }

    public void Explode()
    {
        if (toyScript4 != null && isBomb) toyScript4.Compare();
    }
}
