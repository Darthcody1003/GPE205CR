using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonPressForBack : MonoBehaviour
{
    public void ChangeToMainMenu()
    {
        if (GameManager.instance != null)
        {
            GameManager.instance.ActivateMainMenu();
        }
    }
}
