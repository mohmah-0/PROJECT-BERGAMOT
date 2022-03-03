using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class startup : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        gameObject.GetComponent<playerSelection>().playerCellPrefab = GameObject.Find("SelectionCanvasP1").transform.Find("GridCarSelection").transform.GetChild(1).gameObject;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
