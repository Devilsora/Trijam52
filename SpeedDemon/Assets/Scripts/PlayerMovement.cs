using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices.ComTypes;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private Rigidbody2D rb;
    public bool clickedOnce;
    public LineRenderer lr;
    public Animation playerAnim;
    public Camera cam;
    

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        lr.enabled = false;
        cam = Camera.main;
    }

    // Update is called once per frame
    void Update()
    {
        cam.transform.position = new Vector3(transform.position.x, transform.position.y, -10);

        Vector3[] points = new Vector3[2];

        //RaycastHit2D

        if (Input.GetMouseButtonDown(0))
        {
            //get location where player clicked
            Vector3 mouseClick = Input.mousePosition;
            Vector3 worldPos = Camera.main.ScreenToWorldPoint(mouseClick);

            Debug.Log(mouseClick + "  clicked");
            Debug.Log(worldPos + "  clicked");

            Vector3 launchDir = worldPos - gameObject.transform.position;

            Vector3 desiredDir = launchDir.normalized;
            float desiredMag;

            
            points[0] = worldPos;
            points[1] = gameObject.transform.position;

            if (clickedOnce)
            {
                desiredMag = rb.velocity.magnitude * 2.05f;
            }
            else
            {
                desiredMag = 25;
            }


            Debug.DrawLine(gameObject.transform.position, worldPos, Color.yellow, 5f);

            Vector2 newV = (desiredDir * desiredMag);

            //rb.velocity = launchDir;

            transform.rotation.eulerAngles.Set(desiredDir.x, desiredDir.y, desiredDir.z);

            rb.velocity = desiredDir * desiredMag;

            float angle = Mathf.Atan2(rb.velocity.y, rb.velocity.x) * Mathf.Rad2Deg;
            transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);

            rb.AddForce(desiredDir*0.01f);

            lr.enabled = true;
            lr.alignment = LineAlignment.View;

            lr.SetPosition(0, worldPos);

          
            lr.SetPosition(1, gameObject.transform.position);

            //if (clickedOnce)
            //{
            //    Debug.Log("Current velocity: " + rb.velocity);
            //    float lastMagnitude = rb.velocity.magnitude;
            //    Debug.Log("Last magnitude: " + lastMagnitude);
            //    rb.velocity = Vector3.zero;
            //    rb.AddForce(launchDir * lastMagnitude);
            //}
            //else
            //{
            //    
            //    clickedOnce = true;
            //}

        }

        lr.SetPosition(1, gameObject.transform.position);
    }
}
