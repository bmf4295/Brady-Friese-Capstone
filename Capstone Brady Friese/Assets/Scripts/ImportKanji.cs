using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;


public class ImportKanji : MonoBehaviour
{
   [SerializeField]
    private KanjiCollection everyKanji;
    // Start is called before the first frame update
    void Start()
    {
        using(StreamReader stream = new StreamReader(Application.dataPath + "/JSON/CapstoneKanji.JSON"))
        {
            string json = stream.ReadToEnd();
            Debug.Log(json);
            everyKanji = JsonUtility.FromJson<KanjiCollection>(json);
           
        }
        Debug.Log(everyKanji.ToString());
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
