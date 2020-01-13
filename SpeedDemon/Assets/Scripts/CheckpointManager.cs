using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CheckpointManager : MonoBehaviour
{
    public List<GameObject> checkpoints;
    List<GameObject> selectedCheckpoints = new List<GameObject>();
    public int checkPoints_completed = 0;

    bool [] alreadyAdded = new bool[3];

    public Text tracker;


    // Start is called before the first frame update
    void Start()
    {
        int check1 = 0;
        int check2 = 0;
        int check3 = 0;

        check1 = Random.Range(0, 10);

        check2 = Random.Range(0, 10);

        while (check2 == check1)
        {
            check2 = Random.Range(0, 10);
        }

        check3 = Random.Range(0, 10);

        while(check3 == check2 || check3 == check1)
        {
            check3 = Random.Range(0, 10);
        }

        
        selectedCheckpoints.Add(checkpoints[check1]);
        selectedCheckpoints.Add(checkpoints[check2]);
        selectedCheckpoints.Add(checkpoints[check3]);
    }

    // Update is called once per frame
    void Update()
    {
        for (int i = 0; i < 3; i++)
        {
            if (selectedCheckpoints[i].GetComponent<Checkpoint>().checkpointTriggered && alreadyAdded[i] == false)
            {
                alreadyAdded[i] = true;
                checkPoints_completed++;
            }
        }

        tracker.text = checkPoints_completed.ToString() + "/3";
    }
}
