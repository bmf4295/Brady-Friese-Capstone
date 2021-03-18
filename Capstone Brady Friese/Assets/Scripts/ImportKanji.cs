using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;


public class ImportKanji : MonoBehaviour
{
   [SerializeField]
   private string filePath;
    private KanjiCollection everyKanji;
    // Start is called before the first frame update
    void Start()
    {
        filePath = string.Format("{0}/JSON/CapstoneKanji.JSON", Application.dataPath);
        readKanji();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void readKanji()
    {
        using (StreamReader stream = new StreamReader(filePath))
        {
            string json = stream.ReadToEnd();
            everyKanji = JsonUtility.FromJson<KanjiCollection>(json);
           
        }
    }
    private void writeToFile()
    {
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
}

