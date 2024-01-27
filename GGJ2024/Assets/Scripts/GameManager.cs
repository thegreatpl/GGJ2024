using System.Collections;
using System.Collections.Generic;
using UnityEditor.SearchService;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    public PrefabManager PrefabManager;

    public GameObject Player; 

    /// <summary>
    /// Main camera for the game, for easy access. 
    /// </summary>
    public Camera Camera;

    public WorldScript World; 

    // Start is called before the first frame update
    void Start()
    {
        if (Instance != null)
        {
            Destroy(gameObject);
            return;
        }
        Instance = this;
        DontDestroyOnLoad(gameObject);

        PrefabManager = GetComponent<PrefabManager>();

        if (SceneManager.GetActiveScene().name != "MainMenu")
            StartCoroutine(test()); 
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
    //test the level. 
    IEnumerator test()
    {
        yield return StartCoroutine(SpawnPlayer());
       // World = FindObjectOfType<WorldScript>();
        yield return StartCoroutine(LoadLevelCo(SceneManager.GetActiveScene().name));

    }
    
    public void StartNewGame(string firstLevel)
    {
        StartCoroutine(NewGame(firstLevel));
    }

    IEnumerator NewGame(string firstLevel)
    {
        yield return null; 

        yield return StartCoroutine(LoadLevelCo(firstLevel));  
    }

    IEnumerator SpawnPlayer()
    {
        if (Player != null)
        {
            Player.transform.DetachChildren();
            Destroy(Player);
            yield return null;
        }

        if (Camera == null)
        {
            Camera = Instantiate(PrefabManager.GetPrefab("Camera")).GetComponent<Camera>();
            DontDestroyOnLoad(Camera); 
        }
        //spawn in the player. 
        Player = Instantiate(PrefabManager.GetPrefab("Player")); 
        DontDestroyOnLoad (Player);
        Camera.transform.position = new Vector3(Player.transform.position.x, Player.transform.position.y, Camera.transform.position.z);
        Camera.transform.SetParent(Player.transform);
        yield return null;
    }

    public void LoadLevel(string levelName)
    {
        StartCoroutine(LoadLevelCo(levelName)); 
    }

    IEnumerator LoadLevelCo(string levelName)
    {       
        //drop any item carried first. 
        if (Player != null)
        {
            Player.GetComponent<PlayerController>().DropObject(); 
        }
        SceneManager.LoadScene(levelName, LoadSceneMode.Single); 
        
        yield return null;
        World = FindObjectOfType<WorldScript>(); 

        if (Player == null) 
        {
            yield return StartCoroutine(SpawnPlayer());
        }
        
        yield return StartCoroutine(World.LoadWorld());
    }
}
