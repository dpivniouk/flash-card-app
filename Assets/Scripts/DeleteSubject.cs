using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DeleteSubject : MonoBehaviour
{
    private SubjectSelectButton subjectSelectButton;

    void Start()
    {
        subjectSelectButton = gameObject.GetComponentInParent<SubjectSelectButton>();

    }

    public void RemoveSubject()
    {
        int subjectIndex = subjectSelectButton.subjectIndex;

        DataManager.instance.RemoveSubject(subjectIndex);

        SubjectSelectionBuilder subjectSelectionBuilder = subjectSelectButton.gameObject.GetComponentInParent<SubjectSelectionBuilder>();

        subjectSelectionBuilder.BuildButtonCollection();


    }
}
