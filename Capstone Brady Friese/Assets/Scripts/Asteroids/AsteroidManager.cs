using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Asteroid : MonoBehaviour
{

    public GameObject asteroid;
    public List<GameObject> asteroidList;
    public int numAsteroidsOnScreen;
    public Vector3 asteroidPos;
    public Vector3 velocity;
    public Camera mainCamera;
    float cameraHeight;
    float cameraWidth;
    private bool rightAnswerSpawned;
    
    void Start()
    {
        mainCamera = Camera.main;
      
        cameraHeight = mainCamera.orthographicSize;
        cameraWidth = cameraWidth * mainCamera.aspect;
      
        asteroidList = new List<GameObject>();
        spawnAsteroids(numAsteroidsOnScreen);
    }

    // Update is called once per frame
    void Update()
    {
        asteroidList.Clear();
        asteroidList.AddRange(GameObject.FindGameObjectsWithTag("Asteroid"));

        moveAsteroids();
    }

    void moveAsteroids()
    {
        for(int i = 0; i< asteroidList.Count; i++)
        {
            Vector3 acceleration = 1.2f * asteroidList[i].transform.up;
            velocity += acceleration;
            velocity = Vector3.ClampMagnitude(velocity, .0040f);
            asteroidList[i].transform.position += velocity;
           
        }
      
        
        for (int i = 0; i <= asteroidList.Count - 1; i++)
        {
            if (asteroidList[i].transform.position.x > 2.4f)
            {
                asteroidList[i].transform.position = new Vector3(-2.3f, transform.position.y, 0);
              
              
            }
            else if (asteroidList[i].transform.position.x < -2.4f)
            {
                asteroidList[i].transform.position = new Vector3(2.3f, transform.position.y, 0);
            }
            if (asteroidList[i].transform.position.y > 5.2f)
            {
                asteroidList[i].transform.position = new Vector3(asteroidList[i].transform.position.x, -5.0f, 0);
              
            }
            else if (asteroidList[i].transform.position.y < -5.2f)
            {
                asteroidList[i].transform.position = new Vector3(asteroidList[i].transform.position.x, 5.0f, 0);
                
            }

        }

    }

    void  addKanjiToAsteroid()
    {

    }

    void spawnAsteroids(int count)
    {
        for(int i = 0; i< count; i++)
        {
            asteroidPos = new Vector3(Random.Range(cameraWidth, -cameraWidth), Random.Range(cameraHeight, -cameraHeight), 0);
            GameObject temp = Instantiate(asteroid, asteroidPos, Quaternion.Euler(0, 0, Random.Range(0f, 359f)));
            addKanjiToAsteroid();
            asteroidList.Add(temp);
        }
    }
}
