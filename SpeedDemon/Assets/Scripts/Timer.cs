using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    public float currentTime;
    public string displayTime;

    public float milliseconds;

    public Text timer;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        displayTime = "";

        currentTime += Time.deltaTime;
        milliseconds += (Time.deltaTime * 100);

        if (milliseconds >= 100)
            milliseconds = 0;

        

        

        //get currenttime minutes, seconds, etc.

       int seconds = (int)currentTime % 60;

        if (seconds >= 60)
            seconds = 0;

       int minutes = seconds / 60;
       
       if (minutes < 10)
           displayTime += "0" + minutes.ToString() + ":";
       else if (minutes < 10)
           displayTime += minutes.ToString() + ":";
       
       if (seconds < 10)
           displayTime += "0" + seconds.ToString() + ":";
       else
           displayTime += seconds.ToString() + ":";
       
       if(milliseconds < 1)
           displayTime += "0" + milliseconds.ToString();
       else
           displayTime += milliseconds.ToString();
       

        timer.text = displayTime;


    }
}
