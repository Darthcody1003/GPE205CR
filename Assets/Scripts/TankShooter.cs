using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TankShooter : Shooter

{
    //public AudioClip TankShot;
    //AudioSource source1;
    public Transform firepointTransform;

    // Start is called before the first frame update
    public override void Start()
    {
        
    }

    // Update is called once per frame
   public override void Update()
    {
        
    }

    public override void Shoot(GameObject shellPrefab, float fireForce, float damageDone, float lifespan)
    {
        // Instantiate bullet
        GameObject newShell = Instantiate(shellPrefab, firepointTransform.position, firepointTransform.rotation) as GameObject;

        //Get the DamageOnHit component
        DamageOnHit doh = newShell.GetComponent<DamageOnHit>();

         // Play noise 
       // source1.PlayOneShot(TankShot);

        // If it exists
        if (doh != null)
        {
            // apply doh values
            doh.damageDone = damageDone;
            doh.owner = GetComponent<Pawn>();
        }

        // Get the rigidbody component
        Rigidbody rb = newShell.GetComponent<Rigidbody>();

        // If the rigidbody already exists
        if (rb != null)
        {
            // Add force to the spawned rigidbody
            rb.AddForce(firepointTransform.forward * fireForce);
        }

        // Destroy after a set time
        Destroy(newShell, lifespan);
    }
}
