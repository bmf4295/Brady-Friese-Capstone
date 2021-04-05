using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class AsteroidManager : MonoBehaviour
{

    public GameObject asteroid;
    public GameObject kanjiDisplay;
    public List<GameObject> asteroidList;
    public GameObject EndModal;
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
    public int score;
    public GameObject scoreTracker;
    private bool paused = true;
    private int xpEarned;
    void Start()
    {
        score = 0;
        kanjiImporter = this.gameObject.GetComponent<ImportKanji>();
        lesson = kanjiImporter.getLesson();
        answerOnscreen = false;
        mainCamera = Camera.main;
        answers = new List<string>();
        fakeAnswers = new List<string>();
        cameraHeight = mainCamera.orthographicSize;
        cameraWidth = cameraWidth * mainCamera.aspect;
        asteroidList = new List<GameObject>();
    }

    // Update is called once per frame
    void Update()
    {
        if (!paused)
        {
            if(score == 5)
            {
                stopGame();
            }
            if (asteroidList.Count == 0)
            {
                generateAnswer();
            }
            asteroidList.Clear();
            asteroidList.AddRange(GameObject.FindGameObjectsWithTag("Asteroid"));
            moveAsteroids();
        }
    }

    void moveAsteroids()
    {
        for (int i = 0; i < asteroidList.Count; i++)
        {
            Vector3 acceleration = 1.2f * asteroidList[i].transform.up;
            velocity += acceleration;
            velocity = Vector3.ClampMagnitude(velocity, .15f);
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
        foreach(GameObject ast in asteroidList)
        {
            Destroy(ast);
        }
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
        kanjiDisplay.GetComponent<TextMesh>().text = "";
        answerOnscreen = false;
        int rand = Random.Range(0,lesson.Length);
       Kanji rightKanji = lesson[rand];
        kanjiDisplay.GetComponent<TextMesh>().text = rightKanji.kanji;

        foreach(string o in rightKanji.on_reading)
        {
            answers.Add(o);
        }
        foreach (string k in rightKanji.kun_reading)
        {
            answers.Add(k);
        }
        generateFakeAnswers();
        spawnAsteroids(numAsteroidsOnScreen);
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
    public void changeScore() 
    {
        score++;
        scoreTracker.GetComponent<TextMesh>().text = string.Format("Score : {0}", score);
        generateAnswer();
    
    }

    public void startGame()
    {
        Destroy(GameObject.FindGameObjectWithTag("Start"));
        paused = false;

    }

    public void stopGame()
    {
        GameObject[] temp = GameObject.FindGameObjectsWithTag("Asteroid");
        foreach (GameObject a in temp)
        {
            Destroy(a);
        }
        paused = true;
        Instantiate(EndModal);
        xpEarned = score * 5;
        GameObject xpText = GameObject.FindGameObjectWithTag("XP");
        xpText.GetComponent<TMPro.TextMeshPro>().text = string.Format("{0} XP", xpEarned);
        int currentLesson = PlayerPrefs.GetInt("Current Lesson");
        int currentXP = PlayerPrefs.GetInt(string.Format("Lesson{0}XP", currentLesson));
        currentXP += xpEarned;
        PlayerPrefs.SetInt(string.Format("Lesson{0}XP", currentLesson), currentXP);
    }
}
