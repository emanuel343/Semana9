using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement; 

public class Menu : MonoBehaviour
{
    [SerializeField] GameObject creditos;
    [SerializeField] GameObject menu;

    public void LoadScene(string name)
    {
        SceneManager.LoadScene(name);
    }
    
    public void Trophies()
    {
        Controller.gameJoltController.ShowTrophies();
    }

    public void Creditos()
    {
        creditos.SetActive(true);
        menu.SetActive(false);
    }

    public void Back()
    {
        creditos.SetActive(false);
        menu.SetActive(true);
    }
}
