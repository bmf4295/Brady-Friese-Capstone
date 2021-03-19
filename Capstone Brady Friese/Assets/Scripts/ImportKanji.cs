using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;


public class ImportKanji : MonoBehaviour
{
   [SerializeField]
    
    
    [HideInInspector]
    string filePath;
    public KanjiCollection everyKanji;
    public Kanji[] lessonKanji;
    // Start is called before the first frame update
    private void Awake()
    {
        readKanji();
        lessonKanji = everyKanji.getLessonKanji();
    }
    void Start()
    {
       

    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public Kanji[] getLesson()
    {
        return lessonKanji;
    }
    public KanjiCollection readKanji()
    {
        filePath = string.Format("{0}/JSON/CapstoneKanji.JSON", Application.dataPath);
        using (StreamReader stream = new StreamReader(filePath))
        {
            string json = stream.ReadToEnd();
            everyKanji = JsonUtility.FromJson<KanjiCollection>(json);
           
        }
        return everyKanji;
    }
    private void writeToFile()
    {
        filePath = string.Format("{0}/JSON/CapstoneKanji.JSON", Application.dataPath);
        using (StreamWriter stream = new StreamWriter(filePath))
        {
            string json = JsonUtility.ToJson(everyKanji);
            stream.Write(json);
        }

    }

    private void wipeData()
    {
        foreach(Kanji kanji in everyKanji.allKanji)
        {
            kanji.timesCorrect = 0;
            kanji.timesEncountered = 0;
        }
        writeToFile();
    }

    
    public void updateKanjiStats(string kanjiToUpdate, bool correct)
    {
        everyKanji.findKanji(kanjiToUpdate).timesEncountered++;
        if (correct)
        {
            everyKanji.findKanji(kanjiToUpdate).timesCorrect++;
        }
        writeToFile();
    }
}

