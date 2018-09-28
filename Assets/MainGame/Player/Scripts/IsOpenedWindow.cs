using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class IsOpenedWindow : MonoBehaviour {

    public GameObject InterfaceWindow;

    public void clickOn()
    {
        if (InterfaceWindow.activeSelf)
            InterfaceWindow.SetActive(false);
        else
            InterfaceWindow.SetActive(true);
    }
}
