using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] GameObject enemy;
    [SerializeField] public int maxSpawn;
    int countSpawn;

    void Start()
    {
        StartCoroutine(Spawn());
    }

    IEnumerator Spawn()
    {
        while(countSpawn < maxSpawn)
        {
            countSpawn++;
            SetPosSpawn();
            yield return new WaitForSeconds(2);
        }
    }

    void SetPosSpawn()
    {
        Vector3 pos = new Vector3(transform.position.x + Random.Range(-10,11),
                                1,transform.position.z + Random.Range(-10,11));

        Instantiate(enemy,pos,Quaternion.identity);
    }

    
}
