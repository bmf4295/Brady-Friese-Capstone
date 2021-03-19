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
    void Start()
    {
        readKanji();
        lessonKanji= everyKanji.getLessonKanji();
    }

    // Update is called once per frame
    void Update()
    {
        
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

    
    public void updateKanjiStats(Kanji kanjiToUpdate, bool correct)
    {
        everyKanji.allKanji[kanjiToUpdate.id].timesEncountered++;
        if (correct)
        {
            everyKanji.allKanji[kanjiToUpdate.id].timesCorrect++;
        }
    }
}

