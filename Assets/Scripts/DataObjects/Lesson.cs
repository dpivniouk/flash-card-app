using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Lesson
{
    public string lessonName;

    public string keywords;

    public List<FlashCard> cardList = new List<FlashCard>();


}
