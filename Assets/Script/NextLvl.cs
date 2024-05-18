using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NextLvl : MonoBehaviour
{
    [SerializeField] string nameScene;

    void OnTriggerEnter(Collider othe)
    {
        if(othe.gameObject.tag == "Player")
        {
            SceneManager.LoadScene(nameScene);
        }
    }
}
