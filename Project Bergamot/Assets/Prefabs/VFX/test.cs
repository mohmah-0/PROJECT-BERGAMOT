using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class test : MonoBehaviour
{
    [SerializeField] AudioSource soundFile;
    // Start is called before the first frame update
    void Start()
    {
        soundFile = GetComponent<AudioSource>();
        soundFile.PlayDelayed(4.5f);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
