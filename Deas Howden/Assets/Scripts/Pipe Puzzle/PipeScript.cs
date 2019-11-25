using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PipeScript : MonoBehaviour
{
    public Camera cam;

    private void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {
        // If left mouse clicked
        if (Input.GetMouseButtonDown(0))
        {
            RaycastHit hit;
            Ray ray = cam.ScreenPointToRay(Input.mousePosition);

            if (Physics.Raycast(ray, out hit))
            {
                
                hit.transform.Rotate(0, 90, 0);
            }
        }
    } 
}
