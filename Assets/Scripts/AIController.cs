using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIController : Controller
{
    public enum AIState{Guard, Chase, Flee}

    public AIState currentState;

    public GameObject target;

    public float targetDistance;

    public float fleeDistance;

    private float lastStateChangeTime;

    // Start is called before the first frame update
    void Start()
    {
        currentState = AIState.Chase;
    }

    // Update is called once per frame
    void Update()
    {
        // Fall-through is what break eliminates
        switch  (currentState)
        {
            case AIState.Guard:
            // Instructions for our Guard State
            DoGuard();
            if (IsDistanceLessThan(target, targetDistance))
            {
                ChangeState(AIState.Flee);
            }
            break;
            case AIState.Chase:
            // Instructions for our Chase State
            DoChase();
            if (!IsDistanceLessThan(target, targetDistance))
            {
                ChangeState(AIState.Guard);
            }
            break;
            case AIState.Flee:
            // Instructions for our Flee State
            DoFlee();
             if (!IsDistanceLessThan(target, targetDistance))
            {
                ChangeState(AIState.Guard);
            }
            break;
        }
        
    }

    public override void ProcessInputs()
    {
        Debug.Log("Process Inputs");
    }

    public void DoGuard()
    {
        // Whatever Guard Does
    }

    public void DoChase()
    {
        // Whatever happens in Chase
        Seek(target.transform.position);
    }

    public void Seek(GameObject target)
    {
        Seek(target.transform.position);
    }

    public void Seek(Vector3 targetPosition)
    {
            // Rotate Towards the Target
        pawn.RotateTowards(targetPosition);
        // Move Towards our Target
        pawn.MoveForward();
    }

    public void DoFlee()
    {
        // Whatever happens in Flee
        // Find the Vector to our Target
        Vector3 vectorToTarget = target.transform.position - pawn.transform.position;
        // Find the Vector away from our Target
        Vector3 vectorAwayFromTarget = -vectorToTarget;

        Vector3 fleeVector = vectorAwayFromTarget.normalized * fleeDistance;

        Seek(pawn.transform.position + fleeVector);
    }

    // A setup for a transition out of a state
    protected bool IsDistanceLessThan(GameObject target, float distance)
    {
          if (Vector3.Distance(pawn.transform.position, target.transform.position) < distance ) 
        {
            return true;
        }
        else 
        {
            return false;
        }
    }

    public virtual void ChangeState(AIState state)
    {
        currentState = state;

        lastStateChangeTime = Time.time;
    }
}
