using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBullet : MonoBehaviour
{
    [SerializeField] float velocity;
    [SerializeField] int damage;
    Rigidbody rb;
    
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        
        Destroy(gameObject,4);
    }

    void Update()
    {
        rb.velocity = transform.forward * velocity;
    }

    void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.GetComponent<IHittable>() != null)
        {
            other.gameObject.GetComponent<IHittable>().GetDamage(damage);
        }
    }
}
