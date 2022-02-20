using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AlienPath : MonoBehaviour
{
    float rotationSpeed = 180f;
    Transform player;
    //find the player
    void Update()
    {
        if (player == null)
        {
            GameObject obj = GameObject.FindWithTag("Player");
            if (obj != null)
            {
                player = obj.transform;
            }
            // else if(  GameObject.Find("SpaceShipClone")!=null){
            //     obj= GameObject.Find("SpaceShipClone");
            //     player = obj.transform;
           // }
        }
        if (player == null)
            return;


        Vector3 dir = player.position - transform.position;
        dir.Normalize();
        float zAngle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg - 90;
        Quaternion AlienPath = Quaternion.Euler(0, 0, zAngle);
        transform.rotation = Quaternion.RotateTowards(transform.rotation, AlienPath, rotationSpeed * Time.deltaTime);
    }
}
