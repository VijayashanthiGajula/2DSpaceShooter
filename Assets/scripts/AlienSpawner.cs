using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AlienSpawner : MonoBehaviour
{
   public GameObject AlienPrefab;
   float spawnRate=4;
   float spawnFrequency=1;
   float spawnDistance=10f;
    void Update()
    {
        if (GameObject.FindWithTag("Player") )
        { 
        spawnFrequency-= Time.deltaTime;
        if(spawnFrequency<=0){
            spawnFrequency=spawnRate;
            
            Vector3 offset=Random.onUnitSphere;
            offset.z=0;
            offset=offset.normalized *spawnDistance;
            Instantiate(AlienPrefab,transform.position+offset, Quaternion.identity);
        }

        }
        
    }
}
