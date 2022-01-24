using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AddCard : MonoBehaviour
{
    public Button saveCardButton;
    public Button nextCardButton;
    public Button deleteCardButton;

    public InputField cardFrontInput;
    public InputField cardBackInput;

    [HideInInspector]
    public bool newCard = true;

    [HideInInspector]
    public GameObject previousPanel;

    public int cardIndex = -1;

    void OnDisable()
    {
        cardIndex = -1;
        ClearInputs();
    }

    public void DeleteCard()
    {
        DataManager.instance.RemoveCard(cardIndex);
    }

    public void SaveCard()
    {
        DataManager.instance.EditCard(DataManager.instance.subjectIndex, DataManager.instance.lessonIndex, cardFrontInput, cardBackInput, cardIndex, newCard);
    }

    public void ClearInputs()
    {
        cardFrontInput.text = "";
        cardBackInput.text = "";
    }

    public void Back()
    {
        previousPanel.SetActive(true);
    }
}
