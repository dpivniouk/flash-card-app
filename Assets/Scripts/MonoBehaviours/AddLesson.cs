using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AddLesson : MonoBehaviour
{
    public Button saveLessonButton;
    public Button addCardsButton;

    public GameObject addLessonPanel;
    public GameObject addCardPanel;
    public GameObject previousPanel;

    public InputField lessonNameInput;
    public InputField keywordInput;


    private bool newLesson = true;
    
    void OnDisable()
    {
        ClearInputs();
    }

    public void SaveLesson()
    {
        DataManager.instance.EditLesson(DataManager.instance.subjectIndex, lessonNameInput, keywordInput, newLesson);
        DataManager.instance.lessonIndex = DataManager.instance.savedSubjects.subjects[DataManager.instance.subjectIndex].lessons.Count - 1;
    }

    public void AddCards()
    {
        addCardPanel.SetActive(true);
        addLessonPanel.SetActive(false);
        addCardPanel.GetComponentInChildren<AddCard>().previousPanel = addLessonPanel;
        addCardPanel.GetComponentInChildren<AddCard>().newCard = true;
    }

    public void ClearInputs()
    {
        lessonNameInput.text = "";
        keywordInput.text = "";
    }

    public void Back()
    {
        addLessonPanel.SetActive(false);
        previousPanel.SetActive(true);
    }
}
