using TMPro;
using UnityEngine;

public class AnimalSceneUI : MonoBehaviour
{
    [SerializeField] private TMP_Text animalName;
    
    private void Start()
    {
        animalName.text = "Name: " + GameObject.Find("PersistentObject").GetComponent<PersistentObject>().animalName;
    }

    // Go back to main menu
    public void LoadMainMenu()
    {
        // Load main menu scene
        UnityEngine.SceneManagement.SceneManager.LoadScene(0);
    }
}
