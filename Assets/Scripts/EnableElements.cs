using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnableElements : MonoBehaviour
{
    public Button[] buttons;

    public void CheckInput()
    {
        if (gameObject.GetComponentInChildren<InputField>().text == "")
        {
            DisableButtons();
        }

        else
        {
            EnableButtons();
        }
    }

    public void EnableButtons()
    {
        foreach(Button buttonToEnable in buttons)
        {
            buttonToEnable.interactable = true;
        }
    }

    public void DisableButtons()
    {
        foreach (Button buttonToDisable in buttons)
        {
            buttonToDisable.interactable = false;
        }
    }
}
