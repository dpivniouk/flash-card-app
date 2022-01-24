using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlipFlashCard : MonoBehaviour
{
    public GameObject cardFrontPanel;
    public GameObject cardBackPanel;

    public void RotateCard()
    {
        cardFrontPanel.SetActive(!cardFrontPanel.activeSelf);
        cardBackPanel.SetActive(!cardBackPanel.activeSelf);
    }

}
