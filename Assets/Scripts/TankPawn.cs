using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TankPawn : Pawn
{
  private float nextEventTime;
  private float timerDelay;
    // Start is called before the first frame update
    public override void Start()
    {
      float secondsPerShot;
      if(fireRate <= 0)
      {
        secondsPerShot = Mathf.Infinity;
      }
      else
      {
        secondsPerShot = 1 / fireRate;
      }
      timerDelay = secondsPerShot;
      nextEventTime = Time.time + timerDelay;
        base.Start();
    }

    // Update is called once per frame
     void Update()
    {
    
    }


    public override void MoveForward()
    {
        if (mover != null)
       {
         mover.Move(transform.forward, moveSpeed);
       }
       else
       {
        Debug.LogWarning("Warning: No Mover component is attached to the Pawn");
       }
    }

    public override void MoveBackward()
    {
         if (mover != null)
       {
         mover.Move(transform.forward, -moveSpeed);
       }
       else
       {
        Debug.LogWarning("Warning: No Mover component is attached to the Pawn");
       }
    }

    public override void TurnClockwise()
    {
         if (mover != null)
       {
         mover.Rotate(turnSpeed);
       }
       else
       {
        Debug.LogWarning("Warning: No Mover component is attached to the Pawn");
       }
    }

    public override void TurnCounterClockwise()
    {
       if (mover != null)
       {
         mover.Rotate(-turnSpeed);
       }
       else
       {
        Debug.LogWarning("Warning: No Mover component is attached to the Pawn");
       }
    }

    public override void Shoot()
    {
      if(Time.time >= nextEventTime)
      {
        if (shooter != null)
        {
           shooter.Shoot(shellPrefab, fireForce, damageDone, shellLifespan);
           nextEventTime = Time.time + timerDelay;
        }
        else
        {
          Debug.Log("Warning: No shooter in TankPawn.Shoot()!");
        }
      }
    }

    public override void RotateTowards(Vector3 targetPosition)
    {
        Vector3 vectorToTarget = targetPosition - transform.position;

        Quaternion targetRotation = Quaternion.LookRotation(vectorToTarget, Vector3.up);

        transform.rotation = Quaternion.RotateTowards(transform.rotation, targetRotation, turnSpeed * Time.deltaTime); 
    }

    public override void MakeNoise()
    {
      if (noiseMaker != null)
      {
        noiseMaker.volumeDistance = noiseMakerVolume;
      }
    }

    public override void StopNoise()
    {
      if (noiseMaker != null)
      {
        noiseMaker.volumeDistance = 0;
      }
    }
}
