using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartGameplay : MonoBehaviour
{
    public void ActivateGameplay()
    {
         if (GameManager.instance != null)
        {
            GameManager.instance.ActivateGameplay();
        }
    }
}
