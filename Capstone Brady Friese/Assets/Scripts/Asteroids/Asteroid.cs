using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
public class Asteroid : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject gameManager;
    public GameObject kanjiDisplay;
    public GameObject scoreObj;
    private List<string> answers;
    void Start()
    {
        answers = gameManager.GetComponent<AsteroidManager>().answers;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void checkAnswer(BaseEventData baseEvent)
    {
       
        if (baseEvent != null)
        {
            if (answers.Contains(this.gameObject.GetComponent<TextMesh>().text))
            {

            }
        }

    }
}
