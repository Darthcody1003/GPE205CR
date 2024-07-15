using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonPressForCredits : MonoBehaviour
{
    public void ChangeToCredits()
    {
        if (GameManager.instance != null)
        {
            GameManager.instance.ActivateCreditsScreen();
        }
    }
}
