using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Checkpoint : MonoBehaviour
{
    public bool checkpointTriggered = false;

    public Sprite triggered;

    public Color triggeredColor;
    private SpriteRenderer spr;
    //private AudioSource collectNoise;
    
    
    // Start is called before the first frame update
    void Start()
    {
        spr = GetComponent<SpriteRenderer>();
        //collectNoise = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            
            checkpointTriggered = true;
            spr.sprite = triggered;
            //collectNoise.Play();
        }
        else
        {

            Debug.Log("Tag on other object is " + other.tag);
        }
    }
}
