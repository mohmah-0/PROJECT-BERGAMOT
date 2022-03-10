using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using PathCreation;

public class StartCountDown : MonoBehaviour
{
    [SerializeField, Tooltip("The countdown time")]
    private float countDownTime = 3f;
    [SerializeField, Tooltip("Text for the 3...2...1...GO!")]
    private Text countDownText;
    [SerializeField, Tooltip("StartSound")]
    private AudioSource StartSound;

    private GameObject[] cars;
    void Start()
    {
        cars = GameObject.FindGameObjectsWithTag("Player");
        //Temp code!
        foreach (GameObject car in cars)
        {
            car.GetComponent<CarMovment>().EnteredGoal = true;
        }

        StartCoroutine(CountDown());
    }

    /*
     * Coroutine for the countdown.
     * Starts with activating the text then counts down
     * using yeild Waitforseconds.
     * 
     * Then it un freeze the cars so they can move!
     */
    IEnumerator CountDown()
    {
        countDownText.gameObject.SetActive(true);

        if(StartSound != null)
        {
            StartSound.Play();
        }
        while (countDownTime > 0)
        {
            countDownText.text = countDownTime.ToString();

            yield return new WaitForSeconds(1f);

            countDownTime--;
        }

        countDownText.text = "GO!";

        foreach(GameObject car in cars)
        {
            car.GetComponent<CarMovment>().EnteredGoal = false;
        }

        yield return new WaitForSeconds(1f);
        countDownText.gameObject.SetActive(false);

    }

}
