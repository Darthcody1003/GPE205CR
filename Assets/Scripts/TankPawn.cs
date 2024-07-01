using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TankPawn : Pawn
{
  private float nextEventTime;
    // Start is called before the first frame update
    public override void Start()
    {
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
        shooter.Shoot(shellPrefab, fireForce, shellLifespan, damageDone);
    }

    public override void RotateTowards(Vector3 targetPosition)
    {
        Vector3 vectorToTarget = targetPosition - transform.position;

        Quaternion targetRotation = Quaternion.LookRotation(vectorToTarget, Vector3.up);

        transform.rotation = Quaternion.RotateTowards(transform.rotation, targetRotation, turnSpeed * Time.deltaTime); 
    }

    


}
