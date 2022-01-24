using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SubjectSelectionBuilder : MonoBehaviour
{
    public Button baseButton;
    public GameObject buttonContainer;
    public InputField subjectNameInput;

    [HideInInspector]
    public List<Subject> subjectCollection = new List<Subject>();

    void OnEnable()
    {
        DataManager.instance.subjectIndex = -1;
        BuildButtonCollection();
    }

    public void BuildButtonCollection(bool searched=false)
    {
        subjectCollection.Clear();
        ClearButtons();

        foreach(Subject subject in DataManager.instance.savedSubjects.subjects)
        {
            if (searched)
            {
                if (!subject.subjectName.ToUpper().Contains(subjectNameInput.text.ToUpper()))
                {
                    continue;
                }
            }
            subjectCollection.Add(subject);
        }

        if(subjectCollection == null)
        {
            return;
        }

        for (int i = 0; i < subjectCollection.Count; i++)
        {
            Button newButton = Instantiate(baseButton);
            newButton.transform.SetParent(buttonContainer.transform, false);
            newButton.GetComponentInChildren<Text>().text = subjectCollection[i].subjectName;
            newButton.GetComponentInChildren<SubjectSelectButton>().subjectIndex = i;

        }

    }

    public void ClearButtons()
    {
        Button[] buttons = buttonContainer.GetComponentsInChildren<Button>();

        foreach(Button button in buttons)
        {
            Destroy(button.gameObject);
        }
    }
}
