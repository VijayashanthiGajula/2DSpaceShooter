using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageScript : MonoBehaviour
{

    public int Aspirin;
    private bool Smasher ;
    public float NuteralPeriod = 5;
    public float NuteralPeriodTimer = 0;
    private int correctLayer;
    private string otherObj;
    private void Start()
    {
        correctLayer = gameObject.layer;
    }


    private void OnTriggerEnter2D(Collider2D other)
    {


        if (GameObject.FindWithTag("Player") && other.gameObject.tag == "Enemy")
        {
        
            Aspirin = 0;
            NuteralPeriodTimer = NuteralPeriod;
            gameObject.layer = 8;
            Smasher = true;
        }
        

            Aspirin--;
        
    }

    void Update()
    {
        NuteralPeriodTimer -= Time.deltaTime;
        if (NuteralPeriodTimer < 0)
        {
            gameObject.layer = correctLayer;
        }
        if (Aspirin <= 0)
        {
            Destroy(gameObject);
        }
    }
    void OnGUI()
    {
        {
            if (Aspirin > 0 )
            {
                GUI.Label(new Rect(100, 0, 100, 50), "Aspirin - " + Aspirin);
            }
            if( Smasher == true)
            {

                GUI.Label(new Rect(Screen.width / 2 - 50, Screen.height / 2 - 25, 100, 50), "Spaceship Smashed");
            }
        }
    }

}
