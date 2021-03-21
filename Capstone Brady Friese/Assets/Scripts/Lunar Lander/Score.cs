using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Score : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject scoreObj;
    public GameObject ship;
    public GameObject finalModal;
    private TextMesh scoreText;
   
 
    int points=0;
    private void Awake()
    {
        scoreText = scoreObj.GetComponent<TextMesh>();
        scoreText.text = string.Format("Score:{0}", points);
    }
    void Start()
    {

 
    }

    // Update is called once per frame
    void Update()
    {
    }

    
   public void changeScore()
    {
        points += 1;
        scoreText.text = string.Format("Score:{0}", points);
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
}
