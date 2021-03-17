using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class LessonScreen : MonoBehaviour
{
    public Button quizButton;
    private int currentLesson;
    private int currentXP;
    // Start is called before the first frame update
    void Start()
    {
       currentLesson = PlayerPrefs.GetInt("Current Lesson");
       currentXP = PlayerPrefs.GetInt("Lesson" + currentLesson + "XP");
           
       if(currentXP < 100)
       {
           quizButton.interactable = false;
       }

    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void unlockQuiz()
    {
        quizButton.interactable = true;
    }
}
