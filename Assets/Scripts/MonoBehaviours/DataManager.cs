using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DataManager : MonoBehaviour
{
    public static DataManager instance;

    public int subjectIndex;
    public int lessonIndex;

    //[HideInInspector]
    public SubjectCollection savedSubjects = new SubjectCollection();

    private const string SAVED_SUBJECT_KEY = "SavedSubjects";

    void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }

        else if (instance != this)
        {
            Destroy(gameObject);
        }

        subjectIndex = -1;
        lessonIndex = -1;

        LoadSubjects();
    }

    public void EditSubject(InputField inputField, bool newSubject = false )
    {
        if (newSubject)
        {
            Subject subjectToAdd = new Subject();
            subjectToAdd.subjectName = inputField.text;
            subjectToAdd.lessons = new List<Lesson>();
            savedSubjects.subjects.Add(subjectToAdd);
            SaveSubjects();           
        }
    }

    public void RemoveSubject(int index)
    {
        savedSubjects.subjects.RemoveAt(index);
        SaveSubjects();
    }

    public void EditLesson(int subjectIndex,InputField lessonNameInput, InputField keywordInput, bool newLesson = false)
    {
        if (newLesson)
        {
            Lesson lessonToAdd = new Lesson();
            lessonToAdd.lessonName = lessonNameInput.text;
            lessonToAdd.keywords = keywordInput.text;

            savedSubjects.subjects[subjectIndex].lessons.Add(lessonToAdd);
            SaveSubjects();
        }

    }

    public void RemoveLesson(int index)
    {
        savedSubjects.subjects[subjectIndex].lessons.RemoveAt(index);
        SaveSubjects();
    }



    public void EditCard(int subjectIndex, int lessonIndex, InputField cardfrontInput, InputField cardBackInput,int cardIndex, bool newCard = false)
    {
        if (newCard)
        {
            FlashCard cardToAdd = new FlashCard();
            cardToAdd.cardFrontText = cardfrontInput.text;
            cardToAdd.cardBackText = cardBackInput.text;

            char[] delimiters = new char[] { ' ', ',' };
            cardToAdd.cardLabel = cardToAdd.cardFrontText.Split(delimiters)[0];

            savedSubjects.subjects[subjectIndex].lessons[lessonIndex].cardList.Add(cardToAdd);
            SaveSubjects();
        }
        else if (cardIndex != -1)
        {
            FlashCard cardToEdit = savedSubjects.subjects[subjectIndex].lessons[lessonIndex].cardList[cardIndex];

            cardToEdit.cardFrontText = cardfrontInput.text;
            cardToEdit.cardBackText = cardBackInput.text;

            char[] delimiters = new char[] { ' ', ',' };
            cardToEdit.cardLabel = cardToEdit.cardFrontText.Split(delimiters)[0];

            SaveSubjects();

        }
    }

    public void RemoveCard(int index)
    {
        savedSubjects.subjects[subjectIndex].lessons[lessonIndex].cardList.RemoveAt(index);
        SaveSubjects();
    }

    void SaveSubjects()
    {
        string savedSubjectsJSON = JsonUtility.ToJson(savedSubjects);
        PlayerPrefs.SetString(SAVED_SUBJECT_KEY, savedSubjectsJSON);

    }

    void LoadSubjects()
    {
        if (!PlayerPrefs.HasKey(SAVED_SUBJECT_KEY))
        {
            return;
        }

        string savedSubjectsJSON = PlayerPrefs.GetString(SAVED_SUBJECT_KEY);
        savedSubjects = JsonUtility.FromJson<SubjectCollection>(savedSubjectsJSON);
    }


}
