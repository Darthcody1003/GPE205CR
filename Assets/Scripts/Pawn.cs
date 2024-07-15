using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Pawn : MonoBehaviour
{
    // Variable for move speed
    public float moveSpeed;
    // Variable for turn speed
    public float turnSpeed;
    // Variable for Rate of Fire
    public float fireRate;
    // Variable for our ShellPrefab
    public GameObject shellPrefab;
    // Variable for our firing force
    public float fireForce;
    // Variable for our damage done
    public float damageDone;
    // Variable for how long out bullets survive if they dont collide
    public float shellLifespan;
    public float noiseMakerVolume;

    // Variable to hold our Mover
    public Mover mover;
    public Shooter shooter;
    public NoiseMaker noiseMaker;

    public Controller controller;


    // Start is called before the first frame update
    public virtual void Start()
    {
        mover = GetComponent<Mover>();
        shooter = GetComponent<Shooter>();
        noiseMaker = GetComponent<NoiseMaker>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public abstract void MoveForward();
    public abstract void MoveBackward();
    public abstract void TurnClockwise();
    public abstract void TurnCounterClockwise();
    public abstract void Shoot();
    public abstract void RotateTowards(Vector3 targetPosition);
    public abstract void MakeNoise();
    public abstract void StopNoise();
}
