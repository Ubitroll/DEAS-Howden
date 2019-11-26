using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class SimpleAI : MonoBehaviour
{
    //Variables
    public GameObject desk;
    public GameObject machine;

    // AI States
    protected enum state
    {
        Working,
        Fixing
    }

    // Time it takes to fix a machine
    private const float fixTime = 5f;

    // Time untill moveing
    private float timeLeftUntilFix = fixTime;
    private float timeLeftUntilWork = fixTime;

    // Denotes the current state
    private state currentState;

    // Navmesh agent
    public NavMeshAgent agent;

    // Start is called before the first frame update
    void Start()
    {
        currentState = state.Working;
        agent.SetDestination(desk.transform.position);
    }

    // Update is called once per frame
    void Update()
    {
        if (currentState == state.Working)
        {
            float distanceToDesk = (desk.transform.position - this.transform.position).magnitude;
            if (distanceToDesk <= 4)
            {
                timeLeftUntilFix -= Time.deltaTime;
                if (timeLeftUntilFix <= 0.0f)
                {
                    timeLeftUntilFix = fixTime;
                }

                if (timeLeftUntilFix == fixTime)
                {
                    agent.SetDestination(machine.transform.position);
                    currentState = state.Fixing;
                }

            }
        }

        if (currentState == state.Fixing)
        {
            float distanceToMachine = (machine.transform.position - this.transform.position).magnitude;
            if (distanceToMachine <= 4)
            {
                timeLeftUntilWork -= Time.deltaTime;
                if (timeLeftUntilWork <= 0.0f)
                {
                    timeLeftUntilWork = fixTime;
                }

                if (timeLeftUntilWork == fixTime)
                {
                    agent.SetDestination(desk.transform.position);
                    currentState = state.Working;
                }
            }
        }

        //ADDED
           switch (machine.GetComponent<Machine>().currentState)
            {
                case Machine.MachineState.WORKING:
                currentState = state.Working;

                    break;
                case Machine.MachineState.BROKEN:
                currentState = state.Fixing;
                    break;
            }
        

    }
}
