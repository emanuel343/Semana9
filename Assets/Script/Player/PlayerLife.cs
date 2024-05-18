using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerLife : MonoBehaviour,IHittable
{
    PlayerInput input;
    [SerializeField] int life;

    void Start()
    {
        input = GetComponent<PlayerInput>();
    }

    public void GetDamage(int damage)
    {
        life-= damage;
        if(life <= 0)
        {
            input.enabled = false;
            VictoryLose.instance.Lose();
        }
    }

    
}
