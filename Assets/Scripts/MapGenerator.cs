using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class MapGenerator : MonoBehaviour
{
    
 public GameObject[] gridPrefabs;
 public int rows;
 public int cols;
 public float roomWidth = 50.0f;
 public float roomHeight = 50.0f;
 public int mapSeed;
 public bool usingCurrentTime;
 public bool isMapOfTheDay;
 private Room[,] grid; 

 // Start is called before the first frame update
 void Start()
 {
    if (isMapOfTheDay)
    {
        mapSeed = DateToInt(DateTime.Now.Date);
    }
 }

 // Update is called once per frame
 void Update()
 {
    if (Input.GetKeyDown(KeyCode.Tab))
    {
        GenerateMap();
    }
 }

  // Returns a random room
 public GameObject RandomRoomPrefab()
 {
     return gridPrefabs[UnityEngine.Random.Range(0, gridPrefabs.Length)];
 }

  public void GenerateMap()
   {
    // Set our seed
    UnityEngine.Random.InitState(mapSeed);
    if (usingCurrentTime)
    {
        UnityEngine.Random.InitState(DateToInt(DateTime.Now));
    }
    else if (isMapOfTheDay)
    {
        UnityEngine.Random.InitState(DateToInt(DateTime.Now));
    }
    grid = new Room[cols, rows];

    

     // For each grid row...
     for (int currentRow = 0; currentRow < rows; currentRow++) 
	 {
        // for each column in that row
        for (int currentCol = 0; currentCol < cols ; currentCol++) 
		{
           // Figure out the location. 
           float xPosition = roomWidth * currentCol;
           float zPosition = roomHeight * currentRow;
           Vector3 newPosition =  new Vector3 (xPosition, 0.0f, zPosition);
                            
           // Create a new grid at the appropriate location
           GameObject tempRoomObj = Instantiate (RandomRoomPrefab(),  newPosition, Quaternion.identity) as GameObject;

           // Set its parent
           tempRoomObj.transform.parent = this.transform;

           // Give it a meaningful name
           tempRoomObj.name = "Room_" + currentCol+ "," +currentRow;

           // Get the room object
           Room tempRoom = tempRoomObj.GetComponent<Room>();


		       // Open the doors
     // If we are on the bottom row, open the North door
     if (currentRow == 0) 
	 {
		tempRoom.doorNorth.SetActive(false);
	 }
	 else if (currentRow == rows - 1)
	 {
		 //Otherwise, if we are on the top row, open the south door
		 Destroy(tempRoom.doorSouth);
	 }
	 else
	 {
		 //Otherwise we are in the middle, so open both doors
         Destroy(tempRoom.doorNorth);
         Destroy(tempRoom.doorSouth);
	 }


	  // If we are on the westmost column, open the East door
     if (currentCol == 0) 
	 {
		tempRoom.doorEast.SetActive(false);
	 }
	 else if (currentCol == cols - 1)
	 {
		 //Otherwise, if we are on the Eastmost, open the West door
		 Destroy(tempRoom.doorWest);
	 }
	 else
	 {
		 //Otherwise we are in the middle, so open both doors
		Destroy(tempRoom.doorEast);
        Destroy(tempRoom.doorWest);
	 }


           // Save it to the grid array
           grid[currentCol,currentRow] = tempRoom;
        }
     }
   }

   public int DateToInt ( DateTime dateToUse ) {
     // Add our date up and return it
     return dateToUse.Year + dateToUse.Month + dateToUse.Day + dateToUse.Hour + dateToUse.Minute + dateToUse.Second + dateToUse.Millisecond;
 }
}
