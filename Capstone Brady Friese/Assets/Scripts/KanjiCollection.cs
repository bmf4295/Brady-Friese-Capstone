using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
[Serializable]
public class KanjiCollection 
{
    public Kanji[] allKanji;
    private Kanji [] lessonKanji;
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
    public string printLessonKanji()
    {
        string result = "Lesson\n";
        foreach (Kanji kanji in lessonKanji)
        {
            result += string.Format("Kanji: {0} Kun reading: {1} On Reading: {2} Times Encountered: {3} Times Correct: {4}. ",
                kanji.kanji, kanji.kun_reading[0], kanji.on_reading[0], kanji.timesEncountered, kanji.timesCorrect);
        }
        return result;
    }
    private Kanji[] slice(int startIndex, int endIndex)
    {
        int length = (endIndex - startIndex) + 1;
        lessonKanji = new Kanji[length];
        int slicedindex=0;
        for(int i = 0; i <=allKanji.Length; i++)
        {
            if(i >= startIndex && i <= endIndex)
            {
                lessonKanji[slicedindex] = allKanji[i];
                slicedindex++;
            }
        }
        return lessonKanji;
    }

    public Kanji[] getLessonKanji()
    {
        int currentLesson = PlayerPrefs.GetInt("Current Lesson");

        switch (currentLesson)
        {
            case 1:
                lessonKanji = slice(0, 4);
                break;
            case 2:
                lessonKanji = slice(5, 9);
                break;
            case 3:
                lessonKanji = slice(10, 14);
                break;
            case 4:
                lessonKanji = slice(14, 19);
                break;
        }
        return lessonKanji;
    }


}
