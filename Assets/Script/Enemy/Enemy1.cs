using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy1 : MonoBehaviour,IHittable
{
    [SerializeField] int damage;
    [SerializeField] int life;
    [SerializeField] Transform playerPos;
    [SerializeField] float velocityMove;
    Rigidbody rb;

    public void GetDamage(int damage)
    {
        life -= damage;
        if(life <= 0)
        {
            GameManager.instance.CheckVictory();
            Controller.gameJoltController.TrophieDeleteEnemy();
            GameManager.instance.OnPregression -= (progression) => Upgrade(progression);
            Destroy(gameObject);
        }
    }

    void Start()
    {
        playerPos = GameObject.FindGameObjectWithTag("Player").transform;
        rb = GetComponent<Rigidbody>();

        Upgrade(GameManager.instance.GetProgression());
        GameManager.instance.OnPregression += (progression) => Upgrade(progression);
    }

    void Update()
    {
        Vector3 dir = playerPos.position - transform.position;

        rb.velocity = dir.normalized * velocityMove;
    }

    void Upgrade(int progression)
    {
        velocityMove = progression;
        life = progression;
    }

    void OnCollisionEnter(Collision other)
    {
        if(other.gameObject.tag == "Player")
        {
            GameManager.instance.CheckVictory();
            GameManager.instance.OnPregression -= (progression) => Upgrade(progression);
            other.gameObject.GetComponent<IHittable>().GetDamage(damage);
            Destroy(gameObject);
        }
    }
}
