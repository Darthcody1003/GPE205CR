using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : Controller
{
    public KeyCode MoveForward;
    public KeyCode MoveBackward;
    public KeyCode TurnClockwise;
    public KeyCode TurnCounterClockwise;
    public KeyCode ShootKey;

    public float volumeDistance;
    private NoiseMaker noiseMaker;

    public int score = 0;

   

    // Start is called before the first frame update
   void Start()
    {
        // If we have a GameManager
        if (GameManager.instance != null)
        {
            // And it tracks the player(s)
            if (GameManager.instance.players != null)
            {
                //Register with the GameManager
                GameManager.instance.players.Add(this);
            }     
        }
        
    }

    // Update is called once per frame
    void Update()
    {
        // Process our Keyboard Inputs
        ProcessInputs();
    }

    public override void ProcessInputs()
    {
        if (Input.GetKey(MoveForward))
        {
            pawn.MoveForward();
            pawn.MakeNoise();
        }

        if (Input.GetKey(MoveBackward)) 
        {
            pawn.MoveBackward();
            pawn.MakeNoise();
        }

        if (Input.GetKey(TurnClockwise))
        {
            pawn.TurnClockwise();
            pawn.MakeNoise();
        }

        if (Input.GetKey(TurnCounterClockwise))
        {
            pawn.TurnCounterClockwise();
            pawn.MakeNoise();
        }

        if (Input.GetKeyDown(ShootKey))
        {
            pawn.Shoot();
            pawn.MakeNoise();
        }

        if (!Input.GetKey(MoveForward) && !Input.GetKey(MoveBackward) && !Input.GetKey(TurnClockwise) && !Input.GetKey(TurnCounterClockwise))
        {
           pawn.StopNoise();
        }
       
    }

    public override void AddToScore(int scoreToAdd)
    {
        score += scoreToAdd;
    }
    
    public void OnDestroy()
    {
        {
             // If the GameManager exists
             if(GameManager.instance != null)
             {
                // If it's tracking players
                if (GameManager.instance.players != null)
                {
                    // Deregister with the GameManager
                    GameManager.instance.players.Remove(this);
                }
             }
        }
    }
}
