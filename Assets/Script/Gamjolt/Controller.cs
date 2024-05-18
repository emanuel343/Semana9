using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GameJolt.UI;
using GameJolt.API;
using UnityEngine.SceneManagement;

public class Controller : MonoBehaviour
{
    static public Controller gameJoltController;
    int countDeleteEnemy;
    int countShoots;
    [SerializeField] GameObject menu;
    [SerializeField] bool checkSignIn;
    
    void Awake()
    {
        menu = GameObject.FindGameObjectWithTag("Menu");
        
        if(gameJoltController != null)
        {
            Destroy(gameObject);
        }
        else
        {
            SceneManager.sceneLoaded += OnSceneLoaded;
            gameJoltController = this;
            DontDestroyOnLoad(gameObject);
            
            
        }
    }

    public void TrophieDeleteEnemy()
    {
        countDeleteEnemy++;

        if(countDeleteEnemy > 10)
        Trophies.TryUnlock(233092);

        if(countDeleteEnemy > 20)
        Trophies.TryUnlock(233093);

        if(countDeleteEnemy > 50)
        Trophies.TryUnlock(233094);

        if(countDeleteEnemy > 80)
        Trophies.TryUnlock(233097);

        if(countDeleteEnemy > 100)
        Trophies.TryUnlock(233091);
    }

    public void TrophieShoot()
    {
        countShoots++;
        if(countShoots > 1)
        Trophies.TryUnlock(233080);
        if(countShoots > 40)
        Trophies.TryUnlock(233098);
        if(countShoots > 1000)
        Trophies.TryUnlock(233099);
    }

    public void CheckTrophieLvl(int lvl)
    {
        if(lvl == 1)
        {
            Trophies.TryUnlock(233095);
        }
        else if(lvl == 2)
        {
            Trophies.TryUnlock(233096);
        }
    }

    public void ShowTrophies()
    {
        GameJoltUI.Instance.ShowTrophies();
    }

    void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        if (scene.name == "Menu")
        {
            menu = GameObject.FindGameObjectWithTag("Menu");
            if (checkSignIn)
            {
                if (menu != null)
                {
                    menu.SetActive(true);
                }

                return;
            }
            else
            {
                if(checkSignIn)
                return;

                if(GameJoltUI.Instance != null)
                {
                    menu.SetActive(false);
                    GameJoltUI.Instance.ShowSignIn((bool isSignedIn) =>
                    {
                        if (isSignedIn)
                        {
                            checkSignIn = true;
                            if(menu != null)
                            menu.SetActive(true);
                        }
                        else
                        {
                            Debug.Log("Ocurrió un error");
                        }
                    });
                }
            }
        }
    }
    
}
