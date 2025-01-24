using UnityEngine;

public class Bubble : MonoBehaviour
{

    private int ID;
    private GameObject Toy;
    private Toy toyScript;

    private void Awake()
    {
        Toy = GameObject.Find("Toy");
        toyScript = Toy.GetComponent<Toy>();
    }

    void Start()
    {
        int.TryParse(gameObject.name[gameObject.name.Length - 1].ToString(), out ID); // To set their ID as Bubble #
    }

    void Update()
    {
        
    }

    void Clicked()
    {
        toyScript.buttonsClicked[ID] = true;
    }
}
