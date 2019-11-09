using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;


public class Mover : MonoBehaviour
{
    [SerializeField] Transform target;
    // Start is called before the first frame update
    void Start()
    {
        target = null;
    }

    // Update is called once per frame
    void Update()
    {
        switch (GameData.currentGameMode)
        {
            case GameData.GameMode.MOBILE:
                //----Still mouse controls, change for mobile touch.
                if (Input.GetMouseButton(0)) MoveToCursor();
                if (target != null)GetComponent<NavMeshAgent>().destination = target.position;
                break;
                case GameData.GameMode.PC:
                //----WASD Player move code.
                break;
        }
        if(Input.GetKeyDown(KeyCode.A)){
            GameData.ChangeGameMode();

        }else if(Input.GetKeyDown(KeyCode.E))
        {
              GameData.EditMode();  
        }
    }

    public void MoveToCursor()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;
        bool hasHit = Physics.Raycast(ray, out hit);
        if (hasHit)
        {
            if (hit.transform.tag == "Target")
            {
                Debug.Log("enemy hit");
                GetComponent<NavMeshAgent>().stoppingDistance = 1f;
                GetComponent<NavMeshAgent>().destination = hit.point;
            }
            else
            {
                GetComponent<NavMeshAgent>().stoppingDistance = 0f;
                GetComponent<NavMeshAgent>().destination = hit.point;
            }
        }


    }


}
