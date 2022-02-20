using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpaceShipMoves : MonoBehaviour
{
    public  float maxSpeed = 8f;

    private readonly float rotSpeed = 180f;

    private readonly float BoundaryRadius = 0.5f;

    // Start is called before the first frame update
    private void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        //Rotating the spaceship
        Quaternion R = transform.rotation;
        float z = R.eulerAngles.z;

        // -= rotates the object right on right arrow and left on left arrow
        z -= Input.GetAxis("Horizontal") * rotSpeed * Time.deltaTime;
        R = Quaternion.Euler(0, 0, z);
        transform.rotation = R;

        //Moving the ship along with rotation
        Vector3 p = transform.position;
        Vector3 velocity =
            new Vector3(0,
                Input.GetAxis("Vertical") * maxSpeed * Time.deltaTime,
                0);
        p += R * velocity;

        //top and down boundaries
        if (p.y + BoundaryRadius > Camera.main.orthographicSize)
        {
            p.y = Camera.main.orthographicSize - BoundaryRadius;
        }

        if (p.y + BoundaryRadius < -Camera.main.orthographicSize)
        {
            p.y = -Camera.main.orthographicSize + BoundaryRadius;
        }

        //side boundaries
        float screenRatio = (float) Screen.width / (float) Screen.height;
        float widthOrtho = Camera.main.orthographicSize * screenRatio;

        if (p.x + BoundaryRadius > widthOrtho)
        {
            p.x = widthOrtho - BoundaryRadius;
        }

        if (p.x + BoundaryRadius < -widthOrtho)
        {
            p.x = -widthOrtho + BoundaryRadius;
        }
        transform.position = p;
        //Moving the ship up n down w.r.t y axis
        /* Vector3 p = transform.position;
         p.y += Input.GetAxis("Vertical")* maxSpeed * Time.deltaTime;
         transform.position=p;*/
    }
}
