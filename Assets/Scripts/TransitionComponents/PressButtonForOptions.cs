using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PressButtonForOptions : MonoBehaviour
{
     public void ChangeToOptions()
    {
        if (GameManager.instance != null)
        {
            GameManager.instance.ActivateOptionsScreen();
        }
    }
}
