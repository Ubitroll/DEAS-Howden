using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Button_Grate : MonoBehaviour
{
    public float ButtonTimer;


    // Start is called before the first frame update
    void Start()
    {
      
    }

    // Update is called once per frame
    void Update()
    {
        //visually moves the button down to indicate its been pressed
        if(ButtonTimer <= 0)
           transform.position -= new Vector3(transform.position.x, transform.position.y, transform.position.z);

        if (ButtonTimer > 0)
            ButtonTimer -= Time.deltaTime;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        //detects if player has walked into the button and moves the button down to indicate being pressed
        if(collision.gameObject.tag == "player")
        {
            transform.position -= new Vector3(transform.position.x, transform.position.y - 10, transform.position.z);
            ButtonTimer = 5;
        }
    }
}

