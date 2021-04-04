using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class deletePrefs : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void deletePlayerPrefs()
    {
        PlayerPrefs.SetInt("Current Lesson",1);
        PlayerPrefs.SetInt("Lesson2Unlocked", 0);
        PlayerPrefs.SetInt("Lesson3Unlocked", 0);
        PlayerPrefs.SetInt("Lesson4Unlocked", 0);
        PlayerPrefs.SetInt("Lesson1XP",0);
        PlayerPrefs.SetInt("Lesson2XP", 0);
        PlayerPrefs.SetInt("Lesson3XP", 0);
        PlayerPrefs.SetInt("Lesson4XP", 0);
        PlayerPrefs.SetInt("Lesson1IntroComplete",0);
        PlayerPrefs.SetInt("Lesson2IntroComplete", 0);
        PlayerPrefs.SetInt("Lesson3IntroComplete", 0);
        PlayerPrefs.SetInt("Lesson4IntroComplete", 0);
    }
}
