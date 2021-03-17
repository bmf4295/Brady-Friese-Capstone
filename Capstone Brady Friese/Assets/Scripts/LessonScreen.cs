using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class LessonScreen : MonoBehaviour
{
    public Button quizButton;
    // Start is called before the first frame update
    void Start()
    {
        if (PlayerPrefs.GetInt("Lesson1XP") > 100)
        {
            quizButton.interactable = false;
        }


    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
