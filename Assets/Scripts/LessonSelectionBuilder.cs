using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LessonSelectionBuilder : MonoBehaviour
{
    public Button baseButton;
    public GameObject buttonContainer;
    public Text subjectNameText;
    public InputField lessonNameInput;

    [HideInInspector]
    public List<Lesson> lessonCollection = new List<Lesson>();

    void OnEnable()
    {
        subjectNameText.text = DataManager.instance.savedSubjects.subjects[DataManager.instance.subjectIndex].subjectName;
        DataManager.instance.lessonIndex = -1;
        BuildButtonCollection();
    }

    public void BuildButtonCollection(bool searched = false)
    {
        lessonCollection.Clear();
        ClearButtons();

        foreach (Lesson lesson in DataManager.instance.savedSubjects.subjects[DataManager.instance.subjectIndex].lessons)
        {
            if (searched)
            {
                if (!lesson.lessonName.ToUpper().Contains(lessonNameInput.text.ToUpper()))
                {
                    continue;
                }
            }
            lessonCollection.Add(lesson);
        }

        if (lessonCollection == null)
        {
            return;
        }

        for (int i = 0; i < lessonCollection.Count; i++)
        {
            Button newButton = Instantiate(baseButton);
            newButton.transform.SetParent(buttonContainer.transform, false);
            newButton.GetComponentInChildren<Text>().text = lessonCollection[i].lessonName;
            newButton.GetComponentInChildren <LessonSelectButton>().lessonIndex = i;


        }

    }

    public void ClearButtons()
    {
        Button[] buttons = buttonContainer.GetComponentsInChildren<Button>();

        foreach (Button button in buttons)
        {
            Destroy(button.gameObject);
        }
    }
}
