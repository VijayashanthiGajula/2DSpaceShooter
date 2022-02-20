using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReSpawner : MonoBehaviour
{
    public GameObject SpaceShipPrefab;
    public GameObject playerInstance;
    public int lives;
    float respawnTimer;


    // Start is called before the first frame update
    void Start()
    {
        Spawner();
    }

    void Spawner()
    {
        lives--;
       
        if (playerInstance == null && lives >= 0)
        { 
            respawnTimer = 0.5f;
            playerInstance = (GameObject)Instantiate(SpaceShipPrefab, transform.position, Quaternion.identity);
        }

    }
    void Update()
    {
        if (playerInstance == null && lives >= 0)
        {
            respawnTimer -= Time.deltaTime;
            if (respawnTimer <= 0)
            {
                Spawner();

            }
        }


    }

    // void Spawner()
    // {
    //     lives--;
    //     if (playerInstance == null && lives > 0)
    //     {
    //         playerInstance = GameObject.FindWithTag("Player");
    //         Instantiate(SpaceShipPrefab, playerInstance.transform.position, playerInstance.transform.rotation);
    //         Debug.Log(" spawner created");
    //     }
    //     else if (playerInstance == null)
    //     {
    //         return;
    //     }
    // }
    void OnGUI()
    {
        {
            if (lives >= 0)
            {
                GUI.Label(new Rect(0, 0, 100, 50), "Lives left- " + lives);
            }
            else
            {
                GUI.Label(new Rect(0, 0, 100, 50), "Lives - 0");
            }
            if (lives <0)
            {

                GUI.Label(new Rect(Screen.width / 2 - 50, Screen.height / 2 - 25, 100, 50), "GameOver");
            }
        }
    }
}

