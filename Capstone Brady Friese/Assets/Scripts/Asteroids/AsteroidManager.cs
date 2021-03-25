using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AsteroidManager : MonoBehaviour
{

    public GameObject asteroid;
    public GameObject kanjiDisplay;
    public List<GameObject> asteroidList;
    
    public int numAsteroidsOnScreen;
    public Vector3 asteroidPos;
    public Vector3 velocity;
    public Camera mainCamera;
    float cameraHeight;
    float cameraWidth;
    private ImportKanji kanjiImporter;
    private Kanji[] lesson;
    public List<string> answers;
    public List<string> fakeAnswers;
    public bool answerOnscreen;
    void Start()
    {
        kanjiImporter = this.gameObject.GetComponent<ImportKanji>();
        lesson = kanjiImporter.getLesson();
        answerOnscreen = false;
        mainCamera = Camera.main;
        answers = new List<string>();
        fakeAnswers = new List<string>();
        cameraHeight = mainCamera.orthographicSize;
        cameraWidth = cameraWidth * mainCamera.aspect;
        asteroidList = new List<GameObject>();
        generateAnswer();
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
        for (int i = 0; i < asteroidList.Count; i++)
        {
            Vector3 acceleration = 1.2f * asteroidList[i].transform.up;
            velocity += acceleration;
            velocity = Vector3.ClampMagnitude(velocity, .015f);
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

    void addKanjiToAsteroid(GameObject ast)
    {
        int rand;
        if (answerOnscreen== false)
        {
            rand = Random.Range(0, answers.Count);
            ast.GetComponentInChildren<TextMesh>().text = answers[rand];
            answerOnscreen = true;
        }
        else
        {
            rand = Random.Range(0, fakeAnswers.Count);
            ast.GetComponentInChildren<TextMesh>().text = fakeAnswers[rand];
            fakeAnswers.RemoveAt(rand);
        }
    }

    void spawnAsteroids(int count)
    {
        for (int i = 0; i < count; i++)
        {
            asteroidPos = new Vector3(Random.Range(cameraWidth, -cameraWidth), Random.Range(cameraHeight, -cameraHeight), 0);
            GameObject temp = Instantiate(asteroid, asteroidPos, Quaternion.Euler(0, 0, Random.Range(0f, 359f)));
            addKanjiToAsteroid(temp);
            asteroidList.Add(temp);
        }
    }

   void generateAnswer()
    {
        answers.Clear();
        fakeAnswers.Clear();
        answerOnscreen = false;
        int rand = Random.Range(0, lesson.Length);
        kanjiDisplay.GetComponent<TextMesh>().text = lesson[rand].kanji;

        foreach(string o in lesson[rand].on_reading)
        {
            answers.Add(o);
        }
        foreach (string k in lesson[rand].kun_reading)
        {
            answers.Add(k);
        }
        generateFakeAnswers();
    }

    void generateFakeAnswers()
    {
        foreach(Kanji k in lesson)
        {
            foreach(string o in k.on_reading)
            {
                if (!answers.Contains(o))
                {
                    fakeAnswers.Add(o);
                }
            }
            foreach (string kun in k.kun_reading)
            {
                if (!answers.Contains(kun))
                {
                    fakeAnswers.Add(kun);
                }

            }
        }
    }
   

}
