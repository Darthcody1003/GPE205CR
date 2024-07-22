using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayShotOnKeyPress : MonoBehaviour
{
    public AudioSource keySound;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.G))
        {
            keySound.Play();
        }
        
    }
}
