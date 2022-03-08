using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarCheckPointData : MonoBehaviour
{
    [SerializeField]
    private int currentCheckpoint = 0;
    [SerializeField]
    private int currentLap = 0;

    public void setCurrentCheckpoint(int checkpointID)
    {
        currentCheckpoint = checkpointID;
    }

    public int getCurrentCheckpoint()
    {
        return currentCheckpoint;
    }

    public void setCurrentLap(int LapNumber)
    {
        currentLap = LapNumber;
    }

    public int getCurrentLap()
    {
        return currentLap;
    }
}
