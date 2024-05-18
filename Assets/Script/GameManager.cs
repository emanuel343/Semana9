using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    [SerializeField] Spawner[] spawns;
    static public GameManager instance;
    [SerializeField] int countDelete;
    [SerializeField] int enemiesToDelete;
    [SerializeField] int progression = 1;
    float time;
    public Action<int> OnPregression;
    
    void Awake()
    {
        
        if(instance != null)
        {
            Destroy(gameObject);
        }
        else
        {
            SceneManager.sceneLoaded += OnSceneLoaded;
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
    }

    void Update()
    {
        time += Time.deltaTime;
        if(time > progression*10)
        {
            progression++;
            OnPregression?.Invoke(progression);
        }
    }

    public int GetProgression()
    {
        return progression;
    }

    public void CheckVictory()
    {
        countDelete++;
        if(countDelete >= enemiesToDelete)
        {
            VictoryLose.instance.Victory();
        }
    }

    void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        if(scene.name == "Nivel1" || scene.name == "Nivel2")
        {
            time = 0;
            progression = 1;
            countDelete = 0;
            enemiesToDelete = 0;
            if(scene.name == "Nivel2")
            {
                progression = 5;
            }

            spawns = GameObject.FindObjectsOfType<Spawner>();
            foreach(var item in spawns)
            {
                enemiesToDelete += item.maxSpawn;
            }
        }
    }
}
