using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerupManager : MonoBehaviour
{
    private List<Powerup> removePowerupQueue;
    public List<Powerup> powerups;

    // Start is called before the first frame update
   void Start()
    {
         powerups = new List<Powerup>();
         removePowerupQueue = new List<Powerup>();
    }


    // Update is called once per frame
    void Update()
    {
        DecrementPowerupTimers();
    }
    
    // The Add function will eventually add a powerup
    public void Add (Powerup powerupToAdd)
    {
           // Apply the powerup
        powerupToAdd.Apply(this);
         // Save it to the list
        powerups.Add(powerupToAdd);
      
    }

    // The Remove function will eventually remove a powerup
    public void Remove(Powerup powerupToRemove)
    {
        // Remove the powerup
        powerupToRemove.Remove(this);
        // Add it to the "to be removed queue"
        removePowerupQueue.Add(powerupToRemove);
    }

       private void ApplyRemovePowerupsQueue()
    {
        // Now that we are sure we are not iterating through "powerups", remove the powerups that are in our temporary list
        foreach (Powerup powerup in removePowerupQueue) 
        {
            powerups.Remove(powerup);
        }
        // And reset our temporary list
        removePowerupQueue.Clear();
    }
    

     public void DecrementPowerupTimers()
    {
        // One-at-a-time, put each object in "powerups" into the variable "powerup" and do the loop body on it
        foreach (Powerup powerup in powerups)
        {
            // Subtract the time it took to draw the frame from the duration
           powerup.duration -= Time.deltaTime;
           // If time is up, we want to remove this powerup
            if (powerup.duration <= 0) 
            {
                Remove(powerup);
            }
       }
   }

      private void LateUpdate()
    {
        ApplyRemovePowerupsQueue();
    }
    
}
