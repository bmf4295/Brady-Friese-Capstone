using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ship : MonoBehaviour
{
    // Start is called before the first frame update
    Rigidbody2D shipRigidBody;
    public float thrust = 3;
    public float horizontalMoveSpeed;
    public bool isFlat = true;

    void Start()
    {
        shipRigidBody = GetComponent<Rigidbody2D>();

    }

    // Update is called once per frame
    void Update()
    {
        Vector3 tilt = Input.acceleration;
        
         if (isFlat)
            {
            float x = Input.acceleration.x * horizontalMoveSpeed;
                Vector3 force = new Vector3(x, 0,0);
                shipRigidBody.AddForce(force);
         }
        if(Input.touchCount > 0){

            shipRigidBody.AddForce(Vector3.up * thrust);
        }
    }
}
