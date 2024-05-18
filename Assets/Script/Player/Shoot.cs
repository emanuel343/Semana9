using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shoot : MonoBehaviour
{
    [SerializeField] GameObject bullet;
    [SerializeField] Transform pointShoot;
    PlayerInput input;

    void Start()
    {
        input = GetComponent<PlayerInput>();
        input.OnShoot += () => ExecuteShoot();
    }
    
    void ExecuteShoot()
    {
        Controller.gameJoltController.TrophieShoot();
        Instantiate(bullet,pointShoot.position,pointShoot.rotation);
    }
}
