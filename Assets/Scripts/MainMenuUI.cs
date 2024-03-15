using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class MainMenuUI : MonoBehaviour
{
    private string currentAnimalType;

    [SerializeField] private TMP_InputField animalNameField;
    [SerializeField] private GameObject nameError;
    
    // ENCAPSULATION
    private string m_currentAnimalName;
    private string currentAnimalName
    {
        get => m_currentAnimalName;
        set
        {
            if (value.Length > 20)
            {
                nameError.SetActive(true);
            }
            else
            {
                nameError.SetActive(false);
                m_currentAnimalName = value;
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        currentAnimalName = animalNameField.text;
    }

    public void SelectAnimal(string animal)
    {
        currentAnimalType = animal;
    }

    public void ChangeColorButton(Button button)
    {
        // Change color of button to light gray
        button.image.color = new Color(0.8f, 0.8f, 0.8f);
        
        // Set color of other buttons back to white
        foreach (var otherButton in FindObjectsOfType<Button>())
        {
            if (otherButton != button)
            {
                otherButton.image.color = Color.white;
            }
        }
    }

    public void StartGame()
    { 
        PersistentObject persistentObject = GameObject.Find("PersistentObject").GetComponent<PersistentObject>();
        
        persistentObject.animalType = currentAnimalType;
        persistentObject.animalName = currentAnimalName;
        
        // Load animal scene
        UnityEngine.SceneManagement.SceneManager.LoadScene(1);
    }
}
