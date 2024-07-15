using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    public Transform playerSpawnTransform;

    public Transform playerSpawnPoint;

    // Prefabs
    public GameObject playerControllerPrefab;
    public GameObject playerPawnPrefab;

    // PatrolAI Tank
    public GameObject patrolAIControllerPrefab;

    public List<AIController> aiControllers;

    public List<PlayerController> players;

    private PawnSpawnPoint[] foundPawnSpawnPoints;

    public MapGenerator MapGenerator;

    // Game States
    public GameObject TitleScreenStateObject;
    public GameObject MainMenuStateObject;
    public GameObject OptionsScreenStateObject;
    public GameObject CreditsScreenStateObject;
    public GameObject GameplayStateObject;
    public GameObject GameOverScreenStateObject;


        // Awake is called when the object is first created - before even Start can run!
    private void Awake()
    {
        // If the instance doesnt exist yet...
        if (instance == null)
        {
            // This is the instance
            instance = this;
            // Don't destroy it if we load a new scene
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            // Otherwise, there is already an instance, so destroy this gameObject
            Destroy(gameObject);
        }
    }

    private void Start()
    {
       players = new List<PlayerController>();
       aiControllers = new List<AIController>();

       DeactivateAllStates();

       SpawnPlayer();

       ActivateTitleScreen();


    }

    public void SpawnPlayer()
    {
        SpawnPlayer(playerSpawnPoint);
    }

    public void SpawnPlayer(Transform spawnPosition)
    {
        // Spawn the Player Controller at (0, 0, 0) with no rotation
        GameObject playerController = Instantiate(playerControllerPrefab, Vector3.zero, Quaternion.identity) as GameObject;

        // Spawn the Pawn and connect it to the Controller
        GameObject playerPawn = Instantiate(playerPawnPrefab, spawnPosition.position, Quaternion.identity) as GameObject;

       playerPawn.AddComponent<NoiseMaker>();

       playerController.GetComponent<Controller>().pawn = playerPawn.GetComponent<Pawn>();

       playerPawn.GetComponent<Pawn>().controller = playerController.GetComponent<Controller>();
    }

    public void SpawnPatrolAI(PawnSpawnPoint spawnPoint)
    {
        // Spawn the AI Controller (0, 0, 0) with no rotation
        GameObject newAIObj = Instantiate(patrolAIControllerPrefab, Vector3.zero, Quaternion.identity) as GameObject;

        // Spawn the Pawn and connect it to the Controller
        GameObject newPawnObj = Instantiate(playerPawnPrefab, spawnPoint.transform.position, spawnPoint.transform.rotation) as GameObject;

        // Attach appropriate components and hook AIController to Pawn.
        Controller newController = newAIObj.GetComponent<Controller>();
        Pawn newPawn = newPawnObj.GetComponent<Pawn>();

        newPawnObj.AddComponent<PowerupManager>();

        newController.pawn = newPawn;

        newAIObj.GetComponent<AIController>().waypoints[0] = spawnPoint.transform;
        newAIObj.GetComponent<AIController>().waypoints[1] = spawnPoint.nextWaypoint.transform;
        newAIObj.GetComponent<AIController>().waypoints[2] = spawnPoint.nextWaypoint.nextWaypoint.transform;
        newAIObj.GetComponent<AIController>().waypoints[3] = spawnPoint.nextWaypoint.nextWaypoint.nextWaypoint.transform;
    }

      private void DeactivateAllStates()
    {
        // Deactivate all Game States
        TitleScreenStateObject.SetActive(false);
        MainMenuStateObject.SetActive(false);
        OptionsScreenStateObject.SetActive(false);
        CreditsScreenStateObject.SetActive(false);
        GameplayStateObject.SetActive(false);
        GameOverScreenStateObject.SetActive(false);
    }

      public void ActivateTitleScreen()
    {
        // Deactivate all states
        DeactivateAllStates();
        // Activate the title screen
        TitleScreenStateObject.SetActive(true);
    }

       public void ActivateMainMenu()
    {
        // Deactivate all states
        DeactivateAllStates();
        // Activate the title screen
        MainMenuStateObject.SetActive(true);
    }

       public void ActivateOptionsScreen()
    {
        // Deactivate all states
        DeactivateAllStates();
        // Activate the title screen
        OptionsScreenStateObject.SetActive(true);
    }

       public void ActivateCreditsScreen()
    {
        // Deactivate all states
        DeactivateAllStates();
        // Activate the title screen
        CreditsScreenStateObject.SetActive(true);
    }

       public void ActivateGameplay()
    {
        // Deactivate all states
        DeactivateAllStates();
        // Activate the title screen
        GameplayStateObject.SetActive(true);
    }

    public void ActivateGameOver()
    {
        // Deactivate all states
        DeactivateAllStates();
        // Activate the title screen
        GameOverScreenStateObject.SetActive(true);
    }

}
