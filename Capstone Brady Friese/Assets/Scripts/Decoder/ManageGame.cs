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
    public Button submit;
    private TextMesh scoreText;
    private ImportKanji kanjiImporter;
    private Kanji[] lesson;
    private List<string> answers;
    public GameObject endModal;
    private int score;
    private int xpEarned;
    private bool paused = true;

    // Start is called before the first frame update
    void Start()
    {
        submit.interactable = false;
        kanjiImporter = this.gameObject.GetComponent<ImportKanji>();
        lesson = kanjiImporter.getLesson();
        answers = new List<string>();
        scoreText = scoreCount.GetComponent<TextMesh>();

        changeKanji();
    }

    // Update is called once per frame
    void Update()
    {
        
        if (paused)
        {
            
            AnswerDisplay.interactable = false;
            submit.interactable = false;
        }
        else
        {
            if (score == 5)
            {
                stopGame();
            }
            AnswerDisplay.interactable = true;
            submit.interactable = true;
        }
    
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

    public void startGame()
    {
        Debug.Log("HEllo");
        paused = false;
        Destroy(GameObject.FindGameObjectWithTag("Start"));
    }
    public void stopGame()
    {
        paused = true;
        Instantiate(endModal);
        xpEarned = score * 5;
        GameObject xpText = GameObject.FindGameObjectWithTag("XP");
        xpText.GetComponent<TMPro.TextMeshPro>().text = string.Format("{0} XP", xpEarned);
        int currentLesson = PlayerPrefs.GetInt("Current Lesson");
        int currentXP = PlayerPrefs.GetInt(string.Format("Lesson{0}XP", currentLesson));
        currentXP += xpEarned;
        PlayerPrefs.SetInt(string.Format("Lesson{0}XP", currentLesson), currentXP);
    }
}
