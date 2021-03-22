using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cannon : MonoBehaviour
{
    public GameObject cannon;
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
            if (touch.phase == TouchPhase.Began)
            {

                fingerDown = Camera.main.ScreenToWorldPoint(touch.position);
                fingerUp = Camera.main.ScreenToWorldPoint(touch.position);
            }
            else if (touch.phase == TouchPhase.Moved)
            {

                fingerDown = Camera.main.ScreenToWorldPoint(touch.position);
                checkSwipe();
            }
            else if (touch.phase == TouchPhase.Ended)
            {

                fingerDown = Camera.main.ScreenToWorldPoint(touch.position);
                checkSwipe();
            }

        }
   
    }
    
    private void checkSwipe()
    {
      
        if(horizontalMove() > swipe_thresh)
        {
           
            if(fingerDown.x - fingerUp.x > 0)
            {
             
                Quaternion rotation = cannon.transform.rotation;

                if (rotation.w > 0.8f)
                {
                    rotation.z -= 0.01f;
                }
                else
                {
                    rotation.z += 0.01f;
                    rotation.w = 0.79f;
                }

                cannon.transform.rotation = rotation;
            }
            else if (fingerDown.x - fingerUp.x < 0)
            {
                Quaternion rotation = cannon.transform.rotation;

                if (rotation.w > 0.8f)
                {
                 
                    rotation.z += 0.01f;
                    
                }
                else
                {
                    rotation.z -= 0.01f;
                    rotation.w = 0.79f;
                }
                cannon.transform.rotation = rotation;
            }

        }
    }
    float horizontalMove()
    {
        return Mathf.Abs(fingerDown.x - fingerUp.y);
    }
}
