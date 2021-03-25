using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
public class Asteroid : MonoBehaviour
{
    // Start is called before the first frame update
    private List<string> answers;
    private GameObject manager;
    private AsteroidManager managerScript;
    void Start()
    {
       
        manager = GameObject.FindGameObjectWithTag("GameController");
        managerScript = manager.GetComponent<AsteroidManager>();
        answers = managerScript.answers;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void checkAnswer(BaseEventData baseEvent)
    {
       
        if (baseEvent != null)
        {
           // Debug.Log(this.gameObject.GetComponentInChildren<TextMesh>().text);
            if (answers.Contains(this.gameObject.GetComponentInChildren<TextMesh>().text))
            {
                
            }
        }

    }
}
