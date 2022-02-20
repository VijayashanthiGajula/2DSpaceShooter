using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpaceShipShooting : MonoBehaviour
{
    //public GameObject bulletPreFab;
    public GameObject projectilePrefab;
    int layer;
        public float fireDelay=0.20f;
    private float cooldownTimer=0;
    private void Start() {
        layer=gameObject.layer;
    }
    // Update is called once per frame
    void Update()
    {
        cooldownTimer-= Time.deltaTime;
        if (Input.GetButton("Fire1")&& cooldownTimer<=0)
        {
            Debug.Log("Shooting");
            cooldownTimer=fireDelay;
            //setting projectile direction towards the direction player is facing.( rotation will set projectile while player rotates)
            Vector3 offset=transform.rotation * new Vector3(0,0.5f,0);
            GameObject ProjectileObj=(GameObject) Instantiate(projectilePrefab, transform.position, transform.rotation);
            ProjectileObj.layer=layer;

        }
    }
}
