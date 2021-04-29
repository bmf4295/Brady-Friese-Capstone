using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Score : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject scoreObj;
    public GameObject ship;
    public GameObject finalModal;
    public GameObject endModal;
    private TMP_Text scoreText;
    private int xpEarned;
    private bool paused= false;
 
    int score=0;
    private void Awake()
    {
        scoreText = scoreObj.GetComponent<TMPro.TextMeshPro>();
        scoreText.text = string.Format("Score:{0}", score);
        GameObject[] walls = GameObject.FindGameObjectsWithTag("Wall");

    }
    void Start()
    {

 
    }

    // Update is called once per frame
    void Update()
    {
        if (!paused)
        {
            if (score == 5)
            {
                paused = true;
                ship.GetComponent<Ship>().stopGame();
                spawnModal();
            }
        }
    }

    
   public void changeScore()
    {
        score += 1;
        scoreText.text = string.Format("Score:{0}", score);
    }

    public void checkAnswer(string guess)
    {
        KanjiDisplay dis = this.gameObject.GetComponent<KanjiDisplay>();
        List<string> answers = dis.answers;
        if (answers.Contains(guess))
        {
            changeScore();  
        }
        dis.generateNewKanjiOrReading();
        Ship s = ship.GetComponent<Ship>();
        s.resetPos();
    }

    void spawnModal()
    {
        Instantiate(endModal);
        xpEarned = score * 5;
        GameObject xpText = GameObject.FindGameObjectWithTag("XP");
        xpText.GetComponent<TMPro.TextMeshPro>().text = string.Format("{0} XP", xpEarned);
        int currentLesson = PlayerPrefs.GetInt("Current Lesson");
       
        int currentXP = PlayerPrefs.GetInt(string.Format("Lesson{0}XP", currentLesson));
        Debug.Log(currentXP);
        currentXP += xpEarned;
        Debug.Log(currentXP);
        PlayerPrefs.SetInt(string.Format("Lesson{0}XP", currentLesson), currentXP);
    }
}
