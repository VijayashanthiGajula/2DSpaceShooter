using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AlienShooter : MonoBehaviour
{
    public GameObject bulletPreFab;
    Transform player;
    int layer;
    public float fireDelay = 0.4f;
    private float cooldownTimer = 0;
    private void Start()
    {
        layer = gameObject.layer;
    }
    // Update is called once per frame
    void Update()
    {
         if (player == null)
        {
            GameObject obj = GameObject.FindWithTag("Player");
            if (obj != null)
            {
                player = obj.transform;
            }
        }
        cooldownTimer -= Time.deltaTime;
        //setting minimum distance to start shooting
        if (cooldownTimer <= 0 && player!=null && Vector3.Distance(transform.position, player.position)<5)
        {
            Debug.Log("AlienShooting");
            cooldownTimer = fireDelay;
            //setting projectile direction towards the direction player is facing.( rotation will set projectile while player rotates)
            Vector3 offset = transform.rotation * new Vector3(0, 0.5f, 0);
            //Instantiate(bulletPreFab, transform.position, transform.rotation);
            GameObject bulletObj = (GameObject)Instantiate(bulletPreFab, transform.position + offset, transform.rotation);
            bulletObj.layer = layer;

        }
    }
}
