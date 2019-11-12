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
    public bool isActive = false;
    public Collider pipeCollder;
    public GameObject pipeConnector1;
    public GameObject pipeConnector2;


    // Start is called before the first frame update
    void Start()
    {
        // If its the starting pipe then make it produce water
        if (this.tag == "Start Pipe")
        {
            isActive = true;
        }

        // apply the connector tag to the connecting pieces
        pipeConnector1.tag = "connector";
        pipeConnector2.tag = "connector";
    }

    // Update is called once per frame
    void Update()
    {
        // If it isnt the Starting pipe
        if (this.tag != "Start Pipe")
        {
            // If it isnt the Ending pipe
            if (this.tag != "End Pipe")
            {
                // If active then apply the tag activated
                if (isActive == true)
                {
                    this.tag = "activated";
                }
                // Else if not active then apply the tag unactivated
                else if (isActive == false)
                {
                    this.tag = "unactivated";
                }
            }
        }

        // Create 2 raycast rays. One out each of the pipes connectors
        RaycastHit hit1;
        RaycastHit hit2;
        Ray connector1Ray = new Ray(pipeConnector1.transform.position, pipeConnector1.transform.TransformDirection(Vector3.forward));
        Ray connector2Ray = new Ray(pipeConnector2.transform.position, pipeConnector2.transform.TransformDirection(Vector3.forward));

        // If its not the starting pipe
        if (this.tag != "Start Pipe")
        {
            // If the first connector collides with something within the range of 5
            if (Physics.Raycast(connector1Ray, out hit1, 5))
            {
                // If the collided object has the tag connector
                if (hit1.collider.gameObject.tag == "connector")
                {
                    // If the pipe it is connected to is active
                    if (hit1.collider.GetComponentInParent<PipeManager>().isActive == true)
                    {
                        // Make this pipe active
                        this.isActive = true;
                    }
                }
            }
            // Else the pipe should be inactive
            else
            {
                this.isActive = false;
            }
            // If the second connector collides with something within the range of 5
            if (Physics.Raycast(connector2Ray, out hit2, 5))
            {
                // If the collided object has the tag connector
                if (hit2.collider.gameObject.tag == "connector")
                {
                    
                    if (hit2.collider.GetComponentInParent<PipeManager>().isActive == true)
                    {
                        this.isActive = true;
                    }
                }
            }
            else
            {
                this.isActive = false;
            }
        }
        

        UpdateColour();
    }

    

    void UpdateColour()
    {
        if (this.tag == "Start Pipe")
        {
            GetComponent<Renderer>().material.color = active;
            pipeConnector1.GetComponent<Renderer>().material.color = start;
        }

        if (this.tag == "activated")
        {
            GetComponent<Renderer>().material.color = active;
        }

        if (this.tag == "unactivated")
        {
            GetComponent<Renderer>().material.color = inactive;
        }

        if (this.tag == "End Pipe")
        {
            pipeConnector1.GetComponent<Renderer>().material.color = end;
            if (this.isActive == true)
            {
                GetComponent<Renderer>().material.color = active;
            }
            else
            {
                GetComponent<Renderer>().material.color = inactive;
            }
            
        }
    }


}
