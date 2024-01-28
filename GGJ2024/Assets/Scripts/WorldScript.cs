using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class WorldScript : MonoBehaviour
{
    bool _loaded = false; 

    public Vector3 PlayerSpawn = Vector3.zero;

    public string NextLevel;

    public List<PacificationComponent> Enemies = new List<PacificationComponent>(); 

    // Start is called before the first frame update
    void Start()
    {
        //Enemies = new List<PacificationComponent>();
    }

    // Update is called once per frame
    void Update()
    {
        if (_loaded && !string.IsNullOrWhiteSpace(NextLevel) && !Enemies.Any(x => x.CurrentMood != PacificationComponent.Mood.Pacified))
        {
            if (NextLevel == "win")
            {
                GameManager.Instance.UIScript.WinScreen(); 
            }
            else
                GameManager.Instance.LoadLevel(NextLevel); 
        }
    }

    public IEnumerator LoadWorld()
    {
        yield return null;
        if (GameManager.Instance.Player != null) 
            GameManager.Instance.Player.transform.position = PlayerSpawn;
        yield return null;
        Enemies = FindObjectsOfType<PacificationComponent>().ToList();

        _loaded = true;
    }


    public void RegisterEnemy(PacificationComponent pacificationComponent)
    {
        Enemies.Add(pacificationComponent);
    }
}
