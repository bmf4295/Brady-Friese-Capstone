using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Score : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject scoreObj;
    private TextMesh scoreText;
 
    int points=0;
    void Start()
    {
        scoreText= scoreObj.GetComponent<TextMesh>();
  
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
}
