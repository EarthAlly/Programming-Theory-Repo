using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] private List<GameObject> animalPrefabs;
    
    private PersistentObject persistentObject;
    private void Start()
    {
        persistentObject = GameObject.Find("PersistentObject").GetComponent<PersistentObject>();
        var animalType = persistentObject.animalType;

        // go through animalPrefabs list and find the animal that matches the animalType
        foreach (var animalPrefab in animalPrefabs)
        {
            if (animalPrefab.name == animalType)
            {
                Instantiate(animalPrefab, new Vector3(0, 0, 0), Quaternion.identity);
            }
        }
    }
}
