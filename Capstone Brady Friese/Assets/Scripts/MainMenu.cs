using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class MainMenu : MonoBehaviour
{

    public Button lesson1Button;
    public Button lesson2Button;
    public Button lesson3Button;
    public Button lesson4Button;
    // Start is called before the first frame update
    void Start()
    {
        if (PlayerPrefs.GetInt("Lesson2Complete")== 0)
        {
            lesson2Button.interactable = false;
        }
        if (PlayerPrefs.GetInt("Lesson3Complete") == 0)
        {
            lesson3Button.interactable = false;
        }
        if (PlayerPrefs.GetInt("Lesson4Complete") == 0)
        {
            lesson4Button.interactable = false;
        }



        lesson1Button.onClick.AddListener(goToLesson);
        lesson2Button.onClick.AddListener(goToLesson);
        lesson3Button.onClick.AddListener(goToLesson);
        lesson4Button.onClick.AddListener(goToLesson);
    }

    // Update is called once per frame
    void Update()
    {
   
    }

    void goToLesson()
    {
        string buttonName = EventSystem.current.currentSelectedGameObject.name;
        switch(buttonName){
            case "Lesson 1 Button":
                PlayerPrefs.SetInt("Current Lesson", 1);
                
                break;
            case "Lesson 2 Button":
                PlayerPrefs.SetInt("Current Lesson", 2);
                
                break;
            case "Lesson 3 Button":
                PlayerPrefs.SetInt("Current Lesson", 3);
                
                break;
            case "Lesson 4 Button":
                PlayerPrefs.SetInt("Current Lesson", 4);
                
                break;

        }
        SceneManager.LoadScene("Lesson Screen");
    }
}
