using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LessonSelectButton : MonoBehaviour
{
    public Text buttonText;

    private Canvas mainCanvas;
    private GameObject selectLessonPanel;
    private GameObject flashCardPanel;

    [HideInInspector]
    public int lessonIndex;

    void Start()
    {
        gameObject.GetComponent<Button>().onClick.AddListener(() => OpenFlashCards());
    }

    void OpenFlashCards()
    {
        DataManager.instance.lessonIndex = lessonIndex;

        mainCanvas = GetComponentInParent<Canvas>();
        selectLessonPanel = mainCanvas.transform.Find("OpenLessonPanel").gameObject;

        if(DataManager.instance.savedSubjects.subjects[DataManager.instance.subjectIndex].lessons[DataManager.instance.lessonIndex].cardList.Count == 0)
        {
            flashCardPanel = mainCanvas.transform.Find("AddCardPanel").gameObject;
            flashCardPanel.GetComponentInChildren<AddCard>().previousPanel = selectLessonPanel;
            flashCardPanel.GetComponentInChildren<AddCard>().newCard = true;


        }
        else
        {
            flashCardPanel = mainCanvas.transform.Find("FlashCardPanel").gameObject;

        }


        flashCardPanel.SetActive(true);
        selectLessonPanel.SetActive(false);
    }
}
