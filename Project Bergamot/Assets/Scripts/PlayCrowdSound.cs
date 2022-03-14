using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayCrowdSound : MonoBehaviour
{
    void Start()
    {
        FindObjectOfType<AudioManager>().Play("Cheer");
        FindObjectOfType<AudioManager>().Play("Clap");
    }
}
