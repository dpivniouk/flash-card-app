using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SubjectSelectButton : MonoBehaviour
{
    public Text buttonText;

    private Canvas mainCanvas;
    private GameObject selectLessonPanel;
    private GameObject selectSubjectPanel;

    [HideInInspector]
    public int subjectIndex;

    void Start()
    {
        gameObject.GetComponent<Button>().onClick.AddListener(() => OpenLessons());
    }

    void OpenLessons()
    {
        DataManager.instance.subjectIndex = subjectIndex;

        mainCanvas = GetComponentInParent<Canvas>();

        selectSubjectPanel = mainCanvas.transform.Find("OpenSubjectPanel").gameObject;
        selectLessonPanel = mainCanvas.transform.Find("OpenLessonPanel").gameObject;

        selectLessonPanel.SetActive(true);
        selectSubjectPanel.SetActive(false);
    }
}
