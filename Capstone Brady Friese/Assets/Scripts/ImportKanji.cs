using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.Networking;


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
        string json = "";
        if (Application.isEditor)
        {
            filePath = string.Format("{0}/StreamingAssets/CapstoneKanji.JSON", Application.dataPath);
            using (StreamReader stream = new StreamReader(filePath))
            {
                json = stream.ReadToEnd();
                everyKanji = JsonUtility.FromJson<KanjiCollection>(json);

            }
        }
        else
        {
            filePath = Path.Combine(Application.streamingAssetsPath,"CapstoneKanji.json");

            UnityWebRequest www = UnityWebRequest.Get(filePath);
            www.SendWebRequest();
            while (!www.isDone) ;
            json = www.downloadHandler.text;

        }
        everyKanji = JsonUtility.FromJson<KanjiCollection>(json);
        return everyKanji;
    }

    private void writeToFile()
    {
        if (Application.isEditor)
        {
            filePath = string.Format("{0}/StreamingAssets/CapstoneKanji.JSON", Application.dataPath);
        }
        else
        {
           
            filePath = Path.Combine("jar:file://" + Application.dataPath + "!assets/", "StreamingAssets/CapstoneKanji.json");
        }
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
