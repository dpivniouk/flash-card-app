using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DeleteLesson : MonoBehaviour
{
    private LessonSelectButton lessonSelectButton;

    void Start()
    {
        lessonSelectButton = gameObject.GetComponentInParent<LessonSelectButton>();
    }

    public void RemoveLesson()
    {
        int lessonIndex = lessonSelectButton.lessonIndex;

        DataManager.instance.RemoveLesson(lessonIndex);

        LessonSelectionBuilder lessonSelectionBuilder = lessonSelectButton.gameObject.GetComponentInParent<LessonSelectionBuilder>();

        lessonSelectionBuilder.BuildButtonCollection();
    }
}
