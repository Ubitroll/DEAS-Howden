using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PipeManager : MonoBehaviour
{
    // Variables
    Color active = Color.blue;
    Color inactive = Color.grey;
    Color start = Color.green;
    Color end = Color.red;
    public bool pipeActive = false;
    public Collider pipeCollder;
    public GameObject pipeConnector1;
    public GameObject pipeConnector2;
    

    enum WinState
    {
        Win,
        Fail,
        Playing
    }


    // Start is called before the first frame update
    void Start()
    {
        // If its the starting pipe then make it produce water
        if (this.tag == "Start Pipe")
        {
            pipeActive = true;
        }
        UpdateColour();
    }

    // Update is called once per frame
    void Update()
    {
        // Create 2 raycast rays. One out each of the pipes connectors
        RaycastHit hit1;
        RaycastHit hit2;
        
        Ray ray1 = new Ray(pipeConnector1.transform.position, pipeConnector1.transform.TransformDirection(Vector3.forward));
        Ray ray2 = new Ray(pipeConnector2.transform.position, pipeConnector2.transform.TransformDirection(Vector3.forward));

        WinState currentState = WinState.Playing;

        Debug.DrawRay(this.transform.position, this.transform.TransformDirection(Vector3.forward));
        Debug.DrawRay(this.transform.position, this.transform.TransformDirection(Vector3.back));

        // If its not the starting pipe
        if (this.tag != "Start Pipe")
        {
            // If the first connector collides with something within the range of 5
            if (Physics.Raycast(ray1, out hit1, 15))
            {
                if (Physics.Raycast(ray2, out hit2, 15))
                {
                    if (hit1.collider.tag == "Midpipe" || hit2.collider.tag == "Midpipe")
                    { 
                        // If the pipe it is connected to is active
                        if (hit1.collider.GetComponent<PipeManager>().pipeActive == true)
                        {
                            // Make this pipe active
                            this.pipeActive = true;
                        }
                        else if (hit2.collider.GetComponent<PipeManager>().pipeActive == true)
                        {
                            // Make this pipe active
                            this.pipeActive = true;
                        }
                    }
                }
            }
            // Else the pipe should be inactive
            else
            {
                this.pipeActive = false;
            }
        }
        // If its the start pipe
        if (this.tag == "End Pipe")
        {
            // If it is active then the player wins
            if (this.pipeActive == true)
            {
                currentState = WinState.Win;
            }
        }
        UpdateColour();
    }

    
    // Updates the colour of the pipe
    void UpdateColour()
    {
        // If its the start pipe set up its colours
        if (this.tag == "Start Pipe")
        {
            GetComponent<Renderer>().material.color = active;
            pipeConnector1.GetComponent<Renderer>().material.color = start;
        }
        // If the water is flowing set to blue
        if (this.pipeActive == true)
        {
            GetComponent<Renderer>().material.color = active;
        }
        // If thte water isn't flowing set to grey
        if (this.pipeActive == false)
        {
            GetComponent<Renderer>().material.color = inactive;
        }
        // If its tthe end pipe set up its colours
        if (this.tag == "End Pipe")
        {
            if (this.pipeActive == true)
            {
                GetComponent<Renderer>().material.color = active;
            }
            else if(this.pipeActive == false)
            {
                GetComponent<Renderer>().material.color = inactive;
            }
            pipeConnector1.GetComponent<Renderer>().material.color = end;
        }
    }


}
