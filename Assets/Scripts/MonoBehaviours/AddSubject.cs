using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AddSubject : MonoBehaviour
{
    public Button saveSubjectButton;
    public Button addLessonsButton;

    public GameObject addSubjectPanel;
    public GameObject addLessonPanel;

    public InputField subjectNameInput;

    private bool newSubject = true;

    void OnEnable()
    {
        if(DataManager.instance.subjectIndex != -1)
        {
            subjectNameInput.text = DataManager.instance.savedSubjects.subjects[DataManager.instance.subjectIndex].subjectName;

        }
    }

    void OnDisable()
    {
        ClearInputs();
    }

    public void SaveSubject()
    {
        int existingSubjectIndex = CheckIfSubjectExists();
        if (existingSubjectIndex < 0)
        {
            DataManager.instance.EditSubject(subjectNameInput, newSubject);
            DataManager.instance.subjectIndex = DataManager.instance.savedSubjects.subjects.Count - 1;
        }
        else
        {
            DataManager.instance.subjectIndex = existingSubjectIndex;

        }
    }
    
    public void AddLessons()
    {
        addLessonPanel.SetActive(true);
        addSubjectPanel.SetActive(false);
        addLessonPanel.GetComponent<AddLesson>().previousPanel = addSubjectPanel;
    }

    public void ClearInputs()
    {
        subjectNameInput.text = "";
    }

    int CheckIfSubjectExists()
    {
        for(int i = 0; i < DataManager.instance.savedSubjects.subjects.Count;i++)
        {
            if(DataManager.instance.savedSubjects.subjects[i].subjectName == subjectNameInput.text)
            {
                return i;
            }
        }

        return -1;
    }

}
