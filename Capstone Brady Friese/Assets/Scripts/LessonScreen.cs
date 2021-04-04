using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class LessonScreen : MonoBehaviour
{
    public Button introButton;
    public Button landerButton;
    public Button decoderButton;
    public Button asteroidButton;
    public Button unlockButton;
    public Text xpText;
    private int currentLesson;
    private int currentXP;
    private int lessonIntroComplete;


    // Start is called before the first frame update
    void Start()
    {
        
       
       currentLesson = PlayerPrefs.GetInt("Current Lesson");
       lessonIntroComplete = PlayerPrefs.GetInt(string.Format("Lesson{0}IntroComplete", currentLesson));
        Debug.Log(lessonIntroComplete);
       currentXP = PlayerPrefs.GetInt("Lesson" + currentLesson + "XP");
        xpText.text = "Experience: " + currentXP;
        if(lessonIntroComplete == 0)
        {
            landerButton.interactable = false;
            decoderButton.interactable = false;
            asteroidButton.interactable = false;
        }
        else
        {
            landerButton.interactable = true;
            decoderButton.interactable = true;
            asteroidButton.interactable = true;
        }
        if (currentXP < 100)
        {
            unlockButton.interactable = false;
        }
        else {
            unlockButton.interactable = true;
        }

        

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void openLander()
    {
        SceneManager.LoadScene("Lunar Lander Game");
    }

    public void openDecoder()
    {
        SceneManager.LoadScene("Decoder Game");
    }

    public void openAsteroids()
    {
        SceneManager.LoadScene("Asteroids Game");
    }

    public void openIntro()
    {
        SceneManager.LoadScene("Lesson Intro");
    }
    public void unlockNextLesson()
    {
        string temp = string.Format("Lesson{0}Unlocked", currentLesson+1);
        PlayerPrefs.SetInt(temp, 1);
    }
}
