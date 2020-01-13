using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MinimapChanger : MonoBehaviour
{
    private SpriteRenderer spr;

    // Start is called before the first frame update
    void Start()
    {
        spr = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        spr.sprite = transform.parent.GetComponent<SpriteRenderer>().sprite;
    }
}
