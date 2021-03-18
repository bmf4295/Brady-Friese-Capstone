using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
[Serializable]
public class KanjiCollection 
{
    public Kanji[] allKanji;

    public override string ToString()
    {
        string result = "All Kanji\n";
        foreach(Kanji kanji in allKanji)
        {
            result += string.Format("Kanji: {0} Kun reading: {1} On Reading: {2} Times Encountered: {3} Times Correct: {4}. ", 
                kanji.kanji, kanji.kun_reading[0], kanji.on_reading[0], kanji.timesEncountered, kanji.timesCorrect);
        }
        return result;
    }


}
