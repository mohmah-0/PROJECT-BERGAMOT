using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDetails : MonoBehaviour//may be removed
{
    public int playerID;
    public Vector3 startPos;
    // Start is called before the first frame update
    void Awake()//Maybe just use car position directly---
    {
        transform.position = startPos;
    }
}
