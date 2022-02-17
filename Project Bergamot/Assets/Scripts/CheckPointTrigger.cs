using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckPointTrigger : MonoBehaviour
{
    public CrossChecking crossChecking;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)//just sends information to crosscheck to make them do thier job(cant do this from there sadly).
    {
        crossChecking.checkpointTriggerOccurred(other.gameObject, transform.GetChild(0).gameObject);
    }
}
