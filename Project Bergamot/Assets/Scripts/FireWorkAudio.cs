using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireWorkAudio : MonoBehaviour
{
    private void Start()
    {
        StartCoroutine(PlaySound());
    }

    IEnumerator PlaySound()
    {
        while (true)
        {
            FindObjectOfType<AudioManager>().Play("Explosion");
            yield return new WaitForSeconds((float)Random.Range(100,200)/150);
        }
    }
}
