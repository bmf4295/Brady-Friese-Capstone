using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ManageGame : MonoBehaviour
{
    public InputField AnswerDisplay;
    public GameObject KanjiDisplay;
    public GameObject scoreCount;
    public GameObject readingIndicator;
    private TextMesh scoreText;
    private ImportKanji kanjiImporter;
    private Kanji[] lesson;
    private List<string> answers;
    private int score;
    

    // Start is called before the first frame update
    void Start()
    {
        kanjiImporter = this.gameObject.GetComponent<ImportKanji>();
        lesson = kanjiImporter.getLesson();
        answers = new List<string>();
        scoreText = scoreCount.GetComponent<TextMesh>();

        changeKanji();
    }

    // Update is called once per frame
    void Update()
    {
        
    
    }


    public void changeKanji()
    {
        answers.Clear();
        Kanji randomKanji = lesson[Random.Range(0, lesson.Length)];
        int rand = Random.Range(0, 1000) % 2;
        if(rand == 0)
        {
            foreach (string k in randomKanji.kun_reading)
            {
                answers.Add(k);
            }
            readingIndicator.GetComponent<TextMesh>().text = "Reading: Kun-reading";
        }
        else
        {
            foreach (string o in randomKanji.on_reading)
            {
                answers.Add(o);

            }
            readingIndicator.GetComponent<TextMesh>().text = "Reading: On-reading";
        }
      
       
        KanjiDisplay.GetComponent<TextMesh>().text = randomKanji.kanji;
    }

   public void openKeyboard()
    {
        Debug.Log(AnswerDisplay.text);
        //ouchScreenKeyboard.Open(AnswerDisplay.get, TouchScreenKeyboardType.ASCIICapable, false, false, false, false);
    }

    public void submitAnswer()
    {
        Debug.Log("hello");
        string guess = AnswerDisplay.text;
        if (answers.Contains(guess))
        {
            updateScore();
            resetText();
            changeKanji();

        }
        else
        {
            resetText();
            changeKanji();
        }
    }
    private void updateScore()
    {
        score += 1;
        scoreText.text = string.Format("Score {0}", score);
    }

    private void resetText()
    {
        AnswerDisplay.text = "";
    }
}
