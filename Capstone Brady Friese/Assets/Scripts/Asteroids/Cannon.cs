using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cannon : MonoBehaviour
{
    public GameObject cannon;
    public GameObject posTracker;
    private Vector2 fingerDown;
    private Vector2 fingerUp;
    public float swipe_thresh= 0.05f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
        if(Input.touchCount > 0)
        {
           // Debug.Log("Touch Detected");
            Touch touch = Input.GetTouch(0);
            if(touch.phase == TouchPhase.Began)
            {
                //Debug.Log("Touch Begin");
                fingerDown = Camera.main.ScreenToWorldPoint(touch.position);
                fingerUp = Camera.main.ScreenToWorldPoint(touch.position);
            }else if (touch.phase == TouchPhase.Moved)
            {
              //  Debug.Log("Touch Moved");
                fingerDown = Camera.main.ScreenToWorldPoint(touch.position);
                checkSwipe();
            }else if (touch.phase == TouchPhase.Ended)
            {
             //   Debug.Log("Touch Release");
                fingerDown = Camera.main.ScreenToWorldPoint(touch.position);
                checkSwipe();
            }
          // Vector3 pos = Camera.main.ScreenToWorldPoint(touch.position);

            

        }
    }
    
    private void checkSwipe()
    {
       // Debug.Log(horizontalMove());
        if(horizontalMove() > 0.0005)
        {
           
            if(fingerDown.x - fingerUp.x > 0)
            {
                //Debug.Log(cannon.transform.rotation) ;
                Quaternion rotation = cannon.transform.rotation;
                Debug.Log("Neg X");
                Debug.Log(rotation.z);
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

                Debug.Log("Pos X");
                Debug.Log(rotation.z);

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
