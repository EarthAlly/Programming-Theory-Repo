using UnityEngine;

public class PersistentObject : MonoBehaviour
{
    public string animalType;
    public string animalName;

    private static PersistentObject instance { get; set;  }
    private void Awake()
    {
        if (instance != null)
        {
            Debug.Log("Found more than one Persistent Object in the scene. Destroying the newest one.");
            Destroy(this.gameObject);
            return;
        }

        instance = this;
        DontDestroyOnLoad(this.gameObject);
    }
}
