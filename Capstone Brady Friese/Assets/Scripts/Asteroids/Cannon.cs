using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cannon : MonoBehaviour
{
    public GameObject posTracker;

    private Vector2 fingerDown;
    private Vector2 fingerUp;
    public double swipe_thresh= .015;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        if (Input.touchCount > 0)
        {

            Touch touch = Input.GetTouch(0);
          //  posTracker.transform.position = Camera.main.ScreenToWorldPoint(touch.position);
            //startTrigger();
        }
   
    }

    void startTrigger()
    {
        posTracker.GetComponent<BoxCollider2D>().isTrigger = true;
        new WaitForEndOfFrame();
        posTracker.GetComponent<BoxCollider2D>().isTrigger = false ;

    }
    
}
