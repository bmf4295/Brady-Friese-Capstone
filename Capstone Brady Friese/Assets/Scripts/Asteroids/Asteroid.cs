using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AsteroidManager : MonoBehaviour
{
    // Start is called before the first frame update


    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        this.gameObject.transform.Translate(new Vector3(-1, 0, 0) * Time.deltaTime);
        if(this.gameObject.transform.position.x < -4)
        {
            this.gameObject.transform.position = new Vector3(4, this.gameObject.transform.position.y, this.gameObject.transform.position.z);
        }
    }
}
