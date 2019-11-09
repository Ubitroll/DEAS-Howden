using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Machine : MonoBehaviour
{
    public enum MachineState { BROKEN, BREAKING, WORKING }
    public MachineState currentState;
    Timer timer;
    float lifeTime;

    void Start()
    {
        currentState = MachineState.WORKING;
        GenerateLifeTime();
        timer = new Timer(lifeTime);
    }
    void Update()
    {
        //currentState = CheckStatus();
        timer.Update();
        Debug.Log(timer.TimeLeft());
        if (timer.timeLeft < 0)
        {
            currentState = MachineState.BROKEN;

        }

        switch (currentState)
        {
            case MachineState.WORKING:

                transform.GetChild(0).gameObject.SetActive(false);

                break;

            case MachineState.BROKEN:
                transform.GetChild(0).gameObject.SetActive(true);
                break;

            case MachineState.BREAKING:

                break;

        }

    }

    void GenerateLifeTime()
    {
        lifeTime = Random.Range(10, 23);
    }

    MachineState CheckStatus()
    {
        if (!timer.IsActive())
        {
            return MachineState.BROKEN;
        }
        else
        {
            return currentState;
        }
    }
}
