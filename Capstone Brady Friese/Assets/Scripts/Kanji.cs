using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
[Serializable]
public class Kanji
{
    public string kanji;

    public string[] kun_reading;

    public string[] on_reading;

    public int timesCorrect;

    public int timesEncountered;

    public int id;
    public override string ToString()
    {
        return string.Format("Kanji: {0} Kun reading: {1} On Reading: {2} Times Encountered: {3} Times Correct: {4}. ",
              kanji,kun_reading[0],on_reading[0], timesEncountered, timesCorrect);
    }
}