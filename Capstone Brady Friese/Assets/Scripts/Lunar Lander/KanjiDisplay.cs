using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class KanjiDisplay : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject gameManagerObj;
    public GameObject kanjiDisplay;
    private GameObject[] stations;
    private string currentKanjiOrReading;
    private bool answerIsKanji;
    public List<string> answers;
    private List<string> usedFakeAnswers;
    private Kanji[] lessonKanji;
    private void Awake()
    {
        lessonKanji = new Kanji[5];
        answers = new List<string>();
        usedFakeAnswers = new List<string>();
        stations = GameObject.FindGameObjectsWithTag("LunarStation");
        ImportKanji temp = gameManagerObj.GetComponent<ImportKanji>();
        lessonKanji = temp.lessonKanji;

        generateNewKanjiOrReading();
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
   
    }
    public void changeKanjiDisplay()
    {
        kanjiDisplay.GetComponent<TMPro.TextMeshPro>().text = currentKanjiOrReading;
    }

    public void generateNewKanjiOrReading()
    {
        answers.Clear();
        usedFakeAnswers.Clear();
        int num = Random.Range(1, 1000) % 2;
        int rand;
        Kanji temp;
        switch (num)
        {
            //if even
            case 0:
               rand = Random.Range(0, lessonKanji.Length - 1);
                temp = lessonKanji[rand];
                currentKanjiOrReading = temp.kanji;
                foreach(string reading in lessonKanji[rand].on_reading)
                {
                    answers.Add(reading);
                }
                foreach (string reading in lessonKanji[rand].kun_reading)
                {
                    answers.Add(reading);
                }
                answerIsKanji = false;
                changeKanjiDisplay();
                changeStationDisplay();
                break;
                //if odd
            case 1:
                rand = Random.Range(0, lessonKanji.Length - 1);
                num = Random.Range(1, 1000) % 2;
                 temp = lessonKanji[rand];
                answers.Add(temp.kanji);
                if (num == 0){
                    currentKanjiOrReading = temp.kun_reading[Random.Range(0, temp.kun_reading.Length - 1)];
                }
                else
                {
                    currentKanjiOrReading = temp.on_reading[Random.Range(0, temp.on_reading.Length - 1)];
                }
                answerIsKanji = true;
                changeKanjiDisplay();
                changeStationDisplay();
                break;

        }
    }
    public void changeStationDisplay()
    {
        int cStationIndex = Random.Range(0, stations.Length);
        int randIndex;
        //set 1 random station to the answer
        GameObject correctStation = stations[cStationIndex];

        
        if (answerIsKanji)
        {
            correctStation.GetComponentInChildren<TMPro.TextMeshPro>().text = answers[0];
        }
        else
        {
            correctStation.GetComponentInChildren<TMPro.TextMeshPro>().text = answers[Random.Range(0, answers.Count)];
        }
        for (int i = 0; i< stations.Length; i++)
        {
            if (i == cStationIndex) { continue; }
            if (answerIsKanji)
            {
                if (usedFakeAnswers.Count == 0)
                {
                    foreach (Kanji k in lessonKanji)
                    {
                        if (answers.Contains(k.kanji))
                        {
                            continue;
                        }
                        else
                        {
                            usedFakeAnswers.Add(k.kanji);
                        }

                    }
                }
                randIndex = Random.Range(0, usedFakeAnswers.Count - 1);
          
                TMP_Text stationMesh = stations[i].GetComponentInChildren<TMPro.TextMeshPro>();
                stationMesh.text = usedFakeAnswers[randIndex];
                usedFakeAnswers.RemoveAt(randIndex);
            }
            else
            {
                if (usedFakeAnswers.Count == 0)
                {
                    foreach (Kanji k in lessonKanji)
                    {

                        foreach (string s in k.kun_reading)
                        {
                            if (answers.Contains(s))
                            {
                                continue;
                            }
                            else
                            {
                                usedFakeAnswers.Add(s);
                            }

                        }
                    }
                    foreach (Kanji k in lessonKanji)
                    {
                        foreach (string s in k.on_reading)
                        {
                            if (answers.Contains(s))
                            {
                                continue;
                            }
                            else
                            {
                                usedFakeAnswers.Add(s);
                            }

                        }
                    }
                }
                randIndex = Random.Range(0, usedFakeAnswers.Count - 1);
                TMP_Text stationMesh = stations[i].GetComponentInChildren<TMPro.TextMeshPro>();
                stationMesh.text = usedFakeAnswers[randIndex];
                    usedFakeAnswers.RemoveAt(randIndex);
                
            }

        }
        
       
    }
}
