using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class LessonIntro : MonoBehaviour
{
    // Start is called before the first frame update

    private ImportKanji kanjiImporter;
    public GameObject kanjiDisplay;
    public GameObject kunReadingDisplay1;
    public GameObject kunReadingDisplay2;
    public GameObject kunReadingDisplay3;
    public GameObject onReadingDisplay1;
    public GameObject onReadingDisplay2;
    public GameObject onReadingDisplay3;
    public Button finishButton;
    private Kanji[] lessonKanji;

    private int index;

    void Start()
    {
        GameObject.FindGameObjectWithTag("Prev").GetComponent<Button>().interactable = false;
        finishButton.interactable = false;
        index = 0;

        kanjiImporter = this.gameObject.GetComponent<ImportKanji>();
        lessonKanji = kanjiImporter.lessonKanji;

        UpdateDisplay(index);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void UpdateDisplay(int index)
    {
        kanjiDisplay.GetComponent<TMPro.TextMeshPro>().text = lessonKanji[index].kanji;
        kunReadingDisplay1.GetComponent<TMPro.TextMeshPro>().text = lessonKanji[index].kun_reading[0];
        kunReadingDisplay2.GetComponent<TMPro.TextMeshPro>().text = "";
        kunReadingDisplay3.GetComponent<TMPro.TextMeshPro>().text = "";

        if (lessonKanji[index].kun_reading.Length == 2)
        {
            kunReadingDisplay2.GetComponent<TMPro.TextMeshPro>().text = lessonKanji[index].kun_reading[1];
        }else if(lessonKanji[index].kun_reading.Length == 3)
        {
            kunReadingDisplay2.GetComponent<TMPro.TextMeshPro>().text = lessonKanji[index].kun_reading[1];
            kunReadingDisplay3.GetComponent<TMPro.TextMeshPro>().text = lessonKanji[index].kun_reading[2];
        }
        onReadingDisplay1.GetComponent<TMPro.TextMeshPro>().text = lessonKanji[index].on_reading[0];
        onReadingDisplay2.GetComponent<TMPro.TextMeshPro>().text = "";
        onReadingDisplay3.GetComponent<TMPro.TextMeshPro>().text = "";
        if (lessonKanji[index].on_reading.Length == 2)
        {
            onReadingDisplay2.GetComponent<TMPro.TextMeshPro>().text = lessonKanji[index].on_reading[1];
        }
        else if (lessonKanji[index].on_reading.Length == 3)
        {
            onReadingDisplay2.GetComponent<TMPro.TextMeshPro>().text = lessonKanji[index].on_reading[1];
            onReadingDisplay3.GetComponent<TMPro.TextMeshPro>().text = lessonKanji[index].on_reading[2];
        }
         

    }

    public void updateIndexPos()
    {
        GameObject.FindGameObjectWithTag("Prev").GetComponent<Button>().interactable = true;
        if ((index +1) == lessonKanji.Length-1)
        {
            GameObject.FindGameObjectWithTag("Next").GetComponent<Button>().interactable = false;
            finishButton.interactable = true;
            index++;
            UpdateDisplay(index);
        }
        else
        {
            index++;
            UpdateDisplay(index);
        }
        
    }
    public void updateIndexNeg()
    {
        GameObject.FindGameObjectWithTag("Next").GetComponent<Button>().interactable = true;

        if((index - 1) == 0)
        {
            GameObject.FindGameObjectWithTag("Prev").GetComponent<Button>().interactable = false;
            index--;
            UpdateDisplay(index);
        }
        else
        {
            index--;
            UpdateDisplay(index);
        }

    }

    public void finishLessonIntro()
    {
        string lessonComplete = string.Format("Lesson{0}IntroComplete", PlayerPrefs.GetInt("Current Lesson"));

        PlayerPrefs.SetInt(lessonComplete,1);
        SceneManager.LoadScene("Lesson Screen");
    }
}
