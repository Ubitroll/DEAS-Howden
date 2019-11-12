using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Blue_Gate : MonoBehaviour
{

    public bool isButtonPressed;
    public float destroyTimer;


    // Update is called once per frame
    void Update()
    {

        isButtonPressed = GameObject.Find("blue button").GetComponent<Blue_Button>().isButtonPressed;

        if (isButtonPressed == true)
        {
            transform.Translate(0, -2 * Time.deltaTime, 0);
            destroyTimer = 2;
        }

        if (destroyTimer > 0)
            destroyTimer -= Time.deltaTime;

        if (destroyTimer < 0)
            Destroy(gameObject);
    }
}
