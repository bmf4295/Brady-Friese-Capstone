using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class Ship : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject gameManager;
    Rigidbody2D shipRigidBody;
    public float thrust = 3;
    public float horizontalMoveSpeed;
    public bool isFlat = true;
    public bool isPaused = true;
    void Start()
    {
        shipRigidBody = GetComponent<Rigidbody2D>();

    }

    // Update is called once per frame
    void Update()
    {
        if (!isPaused)
        {
            Time.timeScale = 1;
            Vector3 tilt = Input.acceleration;

            if (isFlat)
            {
                float x = Input.acceleration.x * horizontalMoveSpeed;
                Vector3 force = new Vector3(x, 0, 0);
                shipRigidBody.AddForce(force);
            }
            if (Input.touchCount > 0)
            {

                shipRigidBody.AddForce(Vector3.up * thrust);
            }
        }
        else
        {
            Time.timeScale = 0;
        }
    }
    public void resetPos()
    {
        this.transform.position = GameObject.FindGameObjectWithTag("startPosLunarLander").transform.position;
    }
    void OnTriggerEnter2D(Collider2D col)
    {
      
        if (col.gameObject.tag == "LunarStation")
        {
            string guess = col.gameObject.GetComponentInChildren<TMPro.TextMeshPro>().text;
            gameManager.GetComponent<Score>().checkAnswer(guess);
        }
    }

    public void startGame()
    {
        Destroy(GameObject.FindGameObjectWithTag("Start"));
        isPaused = false;
    }
    public void stopGame()
    {
        isPaused = true;
    }
}
