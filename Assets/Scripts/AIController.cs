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

    public float hearingDistance;

    public float fieldOfView;

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

    protected bool IsCanHear(GameObject target)
    {
        // Get the targets NoiseMaker
        NoiseMaker noiseMaker = target.GetComponent<NoiseMaker>();
        // If they dont have one, they cant make noise, so return false
        if(noiseMaker == null)
        {
            return false;
        }
        // If they are making 0 noise, they also cant be heard
        if(noiseMaker.volumeDistance <= 0)
        {
            return false;
        }
        // If they are making noise, add the volumeDistance in the NoiseMaker to the hearingDistance of this AI
        float totalDistance = noiseMaker.volumeDistance + hearingDistance;
        // If the distance between our pawn and target is closer than this. . .
        if(Vector3.Distance(pawn.transform.position, target.transform.position) <= totalDistance)
        {
            // . . . then we can hear the target
            return true;
        }
        else{
            // Otherwise we are too far away to hear them
            return false;
        }
    }

    protected bool IsCanSee(GameObject target)
    {
        // Find the vector from the agent to the target
        Vector3 agentToTargetVector = target.transform.position - pawn.transform.position;
        // Find the angle between the direction our agent is facing (forward in local space) and the vector to the target
        float angleToTarget = Vector3.Angle(agentToTargetVector, pawn.transform.forward);
        Debug.Log(angleToTarget);
        // If that angle is less than our field of view
        if(angleToTarget < fieldOfView)
        {
            Debug.Log("In field of view");
            return true;
        }
        else{
            return false;
        }
       
    }
}
