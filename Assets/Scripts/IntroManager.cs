using UnityEngine;

public class IntroManager : MonoBehaviour
{
    [SerializeField] private GameObject[] toyPrefabs;
    private int toyNumber;

    public GameObject[] dialogueCues;
   
    void Start()
    {
        
    }
    
    void Update()
    {
        
    }

    public void SpawnNewToy()
    {
        Instantiate(toyPrefabs[toyNumber]);
    }
}
