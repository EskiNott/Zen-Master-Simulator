using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class StartMenu : MonoBehaviour
{
    public void StartButtonClicked()
    {
        UIManager.Instance.MenuEnabled = false;
        UIManager.Instance.StartClick();
    }

    public void ExitButtonClicked()
    {
        Application.Quit();
    }
}
