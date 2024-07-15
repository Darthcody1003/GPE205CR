using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Controller : MonoBehaviour
{
    // variable to hold our Pawn
    public Pawn pawn;

    // Start is called before the first frame update
   void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    // Our child classes MUST override the way they process inputs

    public abstract void ProcessInputs();

    public abstract void AddToScore(int scoreToAdd);
}
