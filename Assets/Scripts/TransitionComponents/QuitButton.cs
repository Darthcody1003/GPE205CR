using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuitButton : MonoBehaviour
{
    void doExitGame()
    {
        Application.Quit();
        Debug.Log ("Quitting");
    }
}
