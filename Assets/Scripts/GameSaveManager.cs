using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class GameSaveManager : MonoBehaviour
{
    public int score;

    void Awake()
    {
        GameObject[] objs = GameObject.FindGameObjectsWithTag("GameStateManager");
        if (objs.Length > 1)
        {
            Destroy(this.gameObject);
        }
        DontDestroyOnLoad(this.gameObject);
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void LoadFromDisk()
    {
        string dataPath = Path.Combine(Application.persistentDataPath,"Pinball_Highscore.txt");

        if (File.Exists(dataPath))
        {

        }
    }
}
